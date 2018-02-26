namespace AllGoRithmFramework.Domain.DataObjects
{
    public class AppDto : BaseDto
    {
        public int AppId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }
    }
}