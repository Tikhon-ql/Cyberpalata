using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        protected async Task<IActionResult> ReturnFileSuccess(byte[] bytes)
        {
            await _unitOfWork.CommitAsync();
            return File(bytes,"image/bmp");
        }
        protected async Task<IActionResult> ReturnSuccess()
        {
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        protected IActionResult BadRequestJson(Result error)
        {
            var errorsDictionary = new Dictionary<string, string>();
            errorsDictionary.Add("Other", error.Error);
            var json = JsonConvert.SerializeObject(errorsDictionary);
            return BadRequest(json);
        }
    }
}
