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
    public class PecuaristaController : ControllerBase
    {
        IRepositoryPecuarista _repository;

        public PecuaristaController()
        {
            _repository = new RepositoryPecuarista();
        }

        [HttpGet]
        public ActionResult<IEnumerable<PecuaristaDto>> Get()
        {
            // this endpoint has a business rule
            return Ok(_repository.Get());
        }
    }
}
