using static Yr25Mango.Web.Utility.SD;

namespace Yr25Mango.Web.Models.DTO
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
