namespace AllGoRithmFramework.Domain.Entities
{
    public class App : BaseEntity
    {
        public int AppId { get; private set; }

        public string Name { get; private set; }

        public string Url { get; private set; }

        public string Image { get; private set; }

        public App()
        {
        }

        public App(int appId, string name, string url, string image)
        {
            this.AppId = appId;
            this.Name = name;
            this.Url = url;
            this.Image = image;
        }
    }
}