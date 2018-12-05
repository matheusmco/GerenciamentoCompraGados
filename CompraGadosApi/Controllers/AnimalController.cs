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
    public class AnimalController : ControllerBase
    {
        IRepositoryAnimal _repository;

        public AnimalController()
        {
            _repository = new RepositoryAnimal();
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalDto>> Get()
        {
            // this endpoint has a business rule
            return Ok(_repository.Get());
        }
    }
}
