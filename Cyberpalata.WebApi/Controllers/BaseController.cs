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

        protected IActionResult ReturnSuccess<T>(T data)
        {
            _unitOfWork.CommitAsync();
            return Ok((data));
        }
        protected IActionResult ReturnSuccess()
        {
            _unitOfWork.CommitAsync();
            return Ok();
        }
    }
}
