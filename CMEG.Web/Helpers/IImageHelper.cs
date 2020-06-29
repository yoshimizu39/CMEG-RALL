using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CMEG.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UpLoadImageAsync(IFormFile formFile, string folder);
    }
}
