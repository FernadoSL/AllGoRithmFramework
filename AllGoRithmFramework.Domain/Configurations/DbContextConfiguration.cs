namespace AllGoRithmFramework.Domain.Configurations
{
    public class DbContextConfiguration
    {
        public string ConnectionString { get; set; }

        public string SpecifiedSchema { get; set; }

        public string PrimaryKeyConvention { get; set; }
    }
}