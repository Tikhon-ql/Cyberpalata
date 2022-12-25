using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    //public class MenuItemService : IMenuItemService
    //{

    //    private readonly IMapper _mapper;
    //    private readonly IMenuItemRepository _repository;

    //    public MenuItemService(IMapper mapper, IMenuItemRepository repository)
    //    {
    //        _mapper = mapper;
    //        _repository = repository;
    //    }

    //    public Task CreateAsync(MenuItemDto entity)
    //    {
    //        return _repository.CreateAsync(_mapper.Map<MenuItem>(entity));
    //    }

    //    public MenuItemDto Read(Guid id)
    //    {
    //        return _mapper.Map<MenuItemDto>(_repository.ReadAsync(id));
    //    }

    //    public void Update(MenuItemDto entity)
    //    {
    //        //_repository.Update(_mapper.Map<MenuItem>(entity));
    //    }

    //    public void Delete(Guid id)
    //    {
    //        _repository.DeleteAsync(id);
    //    }

    //    public PagedList<MenuItemDto> GetPagedList(int pageNumber)
    //    {
    //        return _mapper.Map<PagedList<MenuItemDto>>(_repository.GetPageListAsync(pageNumber));
    //    }
    //}
}
