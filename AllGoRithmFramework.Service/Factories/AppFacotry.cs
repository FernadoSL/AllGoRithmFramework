using AllGoRithmFramework.Domain.DataObjects;
using AllGoRithmFramework.Domain.Entities;

namespace AllGoRithmFramework.Service.Factories
{
    public class AppFactory : IBaseFactory<App, AppDto>
    {
        public App Create(AppDto source)
        {
            return new App(source.AppId, source.Name, source.Url, source.Image);
        }
    }
}