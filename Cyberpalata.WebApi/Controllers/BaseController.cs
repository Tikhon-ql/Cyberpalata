using Cyberpalata.Common.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;

        public BaseController(IUnitOfWork uinOfWork, ILogger logger)
        {
            _unitOfWork = uinOfWork;
            _logger = logger;
        }

        protected async Task<IActionResult> ReturnSuccess<T>(T data)
        {
            await _unitOfWork.CommitAsync();
            return Ok((data));
        }
        protected async Task<IActionResult> ReturnSuccess()
        {
            await _unitOfWork.CommitAsync();
            return Ok();
        }
    }
}
