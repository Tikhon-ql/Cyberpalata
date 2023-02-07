using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        //protected IActionResult BadRequestJson<T>(Result<T> error)
        //{
        //    var errorsDictionary = new Dictionary<string, string>();
        //    errorsDictionary.Add("Other", error.Error);
        //    var json = JsonConvert.SerializeObject(errorsDictionary);
        //    return BadRequest(json);
        //}
        //protected async Task<IActionResult> BadRequestJson(ModelStateDictionary state)
        //{
        //    //return BadRequest(new MyCustomError { Error = error });
        //    return BadRequest();
        //}
    }
}
