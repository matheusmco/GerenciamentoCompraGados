using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;
using CompraGadosApi.Repository.Impl;
using CompraGadosApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CompraGadosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasItemController : ControllerBase
    {
        IRepositoryItem _repository;

        public ComprasItemController()
        {
            _repository = new RepositoryItem();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompraGadoItemDto>> Get()
        {
            return Ok(_repository.Get());
        }

        // [HttpPost]
        // public void Post([FromBody] CompraGadoItemDto Item)
        // {
        //     var Model = new CompraGadoItemModel()
        //     {
        //         Id = Item.Id,
        //         AnimalId = Item.AnimalId,
        //         Quantidade = Item.QuantidadeAnimal
        //     };

        //     _repository.Post(Model);
        // }

        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //     _repository.Delete(id);
        // }
    }
}
