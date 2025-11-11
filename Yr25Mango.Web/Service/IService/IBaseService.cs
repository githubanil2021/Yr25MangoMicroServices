using Yr25Mango.Web.Models.DTO;

namespace Yr25Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}
