using Medinova.DTOs.ForecastDtos;
using Medinova.Models;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class ForecastController : Controller
    {
        private readonly MedinovaContext _context = new MedinovaContext();
        private readonly MLContext _mLContext = new MLContext();

        public ActionResult DepartmentForecast()
        {
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2025, 12, 31);

            var rawData = _context.Appointments
                .Include("Doctor.Departmen")
                .Where(o => o.AppointmentDate >= startDate && o.AppointmentDate <= endDate)
                .ToList()
                .Select(x => new
                {
                    ParsedDate = Convert.ToDateTime(x.AppointmentDate),
                    DepartmentName = x.Doctor.Departmen != null ? x.Doctor.Departmen.Name : "Tanımsız Bölüm"
                })
                .ToList();

            var monthlyDepartmentData = rawData
                .GroupBy(o => new
                {
                    Month = new DateTime(o.ParsedDate.Year, o.ParsedDate.Month, 1),
                    DepartmentName = o.DepartmentName
                })
                .Select(g => new
                {
                    Date = g.Key.Month,
                    DepartmentName = g.Key.DepartmentName,
                    OrderCount = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToList();

            var forecasts = new List<DepartmentForecastViewModel>();

            var distinctDepartments = monthlyDepartmentData.Select(x => x.DepartmentName).Distinct().ToList();

            foreach (var deptName in distinctDepartments)
            {
                var deptData = monthlyDepartmentData
                    .Where(x => x.DepartmentName == deptName)
                    .Select(x => new DepartmentSeriesData
                    {
                        DailyAppointmentCount = (float)x.OrderCount
                    }).ToList();

                if (deptData.Count < 5) continue;

                var dataView = _mLContext.Data.LoadFromEnumerable(deptData);

                var pipeline = _mLContext.Forecasting.ForecastBySsa(
                    outputColumnName: "ForecastedValues",
                    inputColumnName: nameof(DepartmentSeriesData.DailyAppointmentCount),
                    windowSize: 4,
                    seriesLength: deptData.Count,
                    trainSize: deptData.Count,
                    horizon: 3,
                    confidenceLevel: 0.95f
                );

                var model = pipeline.Fit(dataView);
                var engine = model.CreateTimeSeriesEngine<DepartmentSeriesData, DepartmentSeriesPrediction>(_mLContext, ignoreMissingColumns: true);
                var prediction = engine.Predict();

                if (prediction.ForecastedValues != null)
                {
                    for (int i = 0; i < prediction.ForecastedValues.Length; i++)
                    {
                        float lowerBound = (prediction.LowerBoundValues != null && prediction.LowerBoundValues.Length > i)
                                            ? prediction.LowerBoundValues[i] : 0;
                        float upperBound = (prediction.UpperBoundValues != null && prediction.UpperBoundValues.Length > i)
                                            ? prediction.UpperBoundValues[i] : 0;

                        forecasts.Add(new DepartmentForecastViewModel
                        {
                            Department = deptName,
                            Date = new DateTime(2026, i + 1, 1).ToString("MMMM yyyy"),
                            ForecastedCount = (int)Math.Max(0, prediction.ForecastedValues[i]),
                            LowerBound = (int)Math.Max(0, lowerBound),
                            UpperBound = (int)Math.Max(0, upperBound)
                        });
                    }
                }
            }

            return View(forecasts);
        }


        public ActionResult HourlyDemandForecast()
        {
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2025, 12, 31);

            var rawData = _context.Appointments
                .Where(x => x.AppointmentDate >= startDate && x.AppointmentDate <= endDate)
                .ToList()
                .Select(x =>
                {
                    DateTime dt = Convert.ToDateTime(x.AppointmentDate);
                    return new
                    {
                        Hour = float.Parse(x.AppointmentTime.Split(':')[0]),
                        DayOfWeek = (float)dt.DayOfWeek,
                        Month = (float)dt.Month
                    };
                })
                .GroupBy(x => new { x.Month, x.DayOfWeek, x.Hour })
                .Select(g => new HourlyDemandData
                {
                    Month = g.Key.Month,
                    DayOfWeek = g.Key.DayOfWeek,
                    Hour = g.Key.Hour,
                    AppointmentCount = (float)g.Count()
                })
                .ToList();

            var dataView = _mLContext.Data.LoadFromEnumerable(rawData);

            var pipeline = _mLContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(HourlyDemandData.AppointmentCount))
                .Append(_mLContext.Transforms.Concatenate("Features", "Month", "DayOfWeek", "Hour"))
                .Append(_mLContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);
            var predictionEngine = _mLContext.Model.CreatePredictionEngine<HourlyDemandData, HourlyDemandPrediction>(model);

            var forecasts = new List<HourlyForecastViewModel>();

            for (int hour = 9; hour <= 17; hour++)
            {
                var sampleData = new HourlyDemandData
                {
                    Month = 1,
                    DayOfWeek = 1,
                    Hour = hour,
                    AppointmentCount = 0
                };

                var prediction = predictionEngine.Predict(sampleData);

                forecasts.Add(new HourlyForecastViewModel
                {
                    Hour = $"{hour}:00",
                    PredictedLoad = (int)Math.Max(0, prediction.PredictedCount),
                    Note = "2026 Ocak / Pazartesi Tahmini"
                });
            }

            return View(forecasts);
        }
    }
}