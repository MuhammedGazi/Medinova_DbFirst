using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medinova.DTOs.ForecastDtos
{
    public class DepartmentForecastViewModel
    {
        public string Department { get; set; }
        public string Date { get; set; }
        public int ForecastedCount { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
    }

    public class HourlyForecastViewModel
    {
        public string Hour { get; set; }
        public int PredictedLoad { get; set; }
        public string Note { get; set; }
    }
}