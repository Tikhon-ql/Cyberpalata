using Cyberpalata.Common.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cyberpalata.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork uinOfWork)
        {
            _unitOfWork = uinOfWork;
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
        protected async Task<IActionResult> BadRequestJson(string error)
        {
            return BadRequest(new MyCustomError { Error = error} );
        }
        protected async Task<IActionResult> BadRequestJson(ModelStateDictionary state)
        {
            //return BadRequest(new MyCustomError { Error = error });
            return BadRequest();
        }
        private class MyCustomError 
        {
            public string Error { get; set; }
        }
    }
}
