using AllGoRithmFramework.Domain.DataObjects;
using AllGoRithmFramework.Domain.Entities;

namespace AllGoRithmFramework.Service.Factories
{
    public class SystemParameterFactory : IBaseFactory<SystemParameter, SystemParameterDto>
    {
        public SystemParameter Create(SystemParameterDto source)
        {
            return new SystemParameter(source.SystemParameterId, source.Name, source.Value, source.DataType);
        }
    }
}
