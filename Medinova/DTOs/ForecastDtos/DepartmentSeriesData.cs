using Microsoft.ML.Data;

namespace Medinova.DTOs.ForecastDtos
{
    public class DepartmentSeriesData
    {
        public float DailyAppointmentCount { get; set; }
    }

    public class DepartmentSeriesPrediction
    {
        [VectorType]
        public float[] ForecastedValues { get; set; }

        [VectorType]
        [ColumnName("ForecastedValues_LB")]
        public float[] LowerBoundValues { get; set; }

        [VectorType]
        [ColumnName("ForecastedValues_UB")]
        public float[] UpperBoundValues { get; set; }
    }

    public class HourlyDemandData
    {
        public float Month { get; set; }
        public float DayOfWeek { get; set; }
        public float Hour { get; set; }
        public float AppointmentCount { get; set; }
    }

    public class HourlyDemandPrediction
    {
        [ColumnName("Score")]
        public float PredictedCount { get; set; }
    }
}