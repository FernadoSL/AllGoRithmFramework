using AllGoRithmFramework.Domain.Enums;

namespace AllGoRithmFramework.Domain.Entities
{
    public class SystemParameter : BaseEntity
    {
        public int SystemParameterId { get; private set; }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public ParameterDataType DataType { get; private set; }

        private SystemParameter() { }

        public SystemParameter(string name, string value, int dataType)
        {
            this.Name = name;
            this.Value = value;
            this.DataType = (ParameterDataType)dataType;
        }
    }
}
