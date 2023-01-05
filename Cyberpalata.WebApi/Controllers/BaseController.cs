using Cyberpalata.Common.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork uinOfWork)
        {
                _unitOfWork = uinOfWork;
        }

        protected async Task<IActionResult> ReturnSuccessAsync<T>(T data)
        {
            await _unitOfWork.CommitAsync();
            return Ok((data));
        }
        protected async Task<IActionResult> ReturnSuccessAsync()
        {
            await _unitOfWork.CommitAsync();
            return Ok();
        }
    }
}
