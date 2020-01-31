namespace ExpressionTreesAndRuleEngine.Tests.SampleRules
{
    public class CarData
    {
        public static CarData FromCsv(string csvLine)
        {
            var values = csvLine.Split(',');
            return new CarData
            {
                Id = values[0],
                Make = values[1],
                FuelType = values[2],
                Aspiration = values[3],
                NumberOfDoors = values[4],
                BodyStyle = values[5],
                DriveWheels = values[6],
                EngineLocation = values[7],
                WheelBase = values[8],
                Length = values[9],
                Width = values[10],
                Height = values[11],
                CurbWeight = values[12],
                EngineType = values[13],
                NumberOfCylinders = values[14],
                EngineSize = values[15],
                FuelSystem = values[16],
                CompressionRatio = values[17],
                Horsepower = values[18],
                PeakRpm = values[19],
                CityMpg = values[20],
                HighwayMpg = values[21],
                Price = values[22],
            };
        }
        public string Id { get; set; }
        public string Make { get; set; }
        public string FuelType { get; set; }
        public string Aspiration { get; set; }
        public string NumberOfDoors { get; set; }
        public string BodyStyle { get; set; }
        public string DriveWheels { get; set; }
        public string EngineLocation { get; set; }
        public string WheelBase { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string CurbWeight { get; set; }
        public string EngineType { get; set; }
        public string NumberOfCylinders { get; set; }
        public string EngineSize { get; set; }
        public string FuelSystem { get; set; }
        public string CompressionRatio { get; set; }
        public string Horsepower { get; set; }
        public string PeakRpm { get; set; }
        public string CityMpg { get; set; }
        public string HighwayMpg { get; set; }
        public string Price { get; set; }
    }
}