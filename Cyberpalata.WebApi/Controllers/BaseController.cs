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

        public IActionResult ReturnSuccess<T>(T data)
        {
            _unitOfWork.CommitAsync();
            return Ok((data));
        }
    }
}
