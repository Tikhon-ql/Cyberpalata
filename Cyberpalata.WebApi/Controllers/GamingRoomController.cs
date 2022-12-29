using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.GamingRoom;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/gamingRoom")]
    public class GamingRoomController : BaseController
    {
        private readonly IPcService _pcService;
        private readonly IPeripheryService _peripheryService;
        private readonly IPriceService _priceService;
        public GamingRoomController(IPcService pcService, IPeripheryService peripheryService, IPriceService priceService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _pcService = pcService;
            _peripheryService = peripheryService;
            _priceService = priceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //???????????????
  
            var viewModel = new GamingRoomViewModel
            {
                PcInfos = _pcService.GetPagedListAsync(1).Result.Items.ToList().Select(d=>new PcInfo(d.Name,d.Value)).ToList(),
                Peripheries = _peripheryService.GetPagedListAsync(1).Result.Items.Select(p=>new Periphery(p.Name,p.Type.Name)).ToList(),
                Prices = _priceService.GetPagedListAsync(1).Result.Items.Select(p=>new Price(p.Hours,p.Cost)).ToList()
            };
            return ReturnSuccess(viewModel);
        }
    }
}
