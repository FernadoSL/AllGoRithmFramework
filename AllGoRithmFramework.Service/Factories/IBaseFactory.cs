using AllGoRithmFramework.Domain.DataObjects;
using AllGoRithmFramework.Domain.Entities;

namespace AllGoRithmFramework.Service.Factories
{
    public interface IBaseFactory<out TEntity, in TSource> where TEntity : BaseEntity where TSource : BaseDto
    {
        TEntity Create(TSource source);
    }
}
