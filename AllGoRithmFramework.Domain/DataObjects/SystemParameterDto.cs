namespace AllGoRithmFramework.Domain.DataObjects
{
    public class SystemParameterDto : BaseDto
    {
        public int SystemParameterId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DataType { get; set; }
    }
}
