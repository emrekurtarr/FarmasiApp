using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Shared.CustomControllerBase
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,

            };
        }
    }
}
