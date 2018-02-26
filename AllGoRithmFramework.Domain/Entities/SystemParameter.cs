using AllGoRithmFramework.Domain.Enums;

namespace AllGoRithmFramework.Domain.Entities
{
    public class SystemParameter : BaseEntity
    {
        public int SystemParameterId { get; private set; }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public ParameterDataType DataType { get; private set; }

        public string DataTypeName
        {
            get
            {
                return this.DataType.ToString();
            }
        }

        private SystemParameter() { }

        public SystemParameter(string name, string value, int dataType)
        {
            this.Name = name;
            this.Value = value;
            this.DataType = (ParameterDataType)dataType;
        }

        public SystemParameter(int id, string name, string value, int dataType) : this(name, value, dataType)
        {
            this.SystemParameterId = id;
        }
    }
}
