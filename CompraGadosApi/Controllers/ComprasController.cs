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
    public class ComprasController : ControllerBase
    {
        IRepositoryCompra _repository;

        public ComprasController()
        {
            _repository = new RepositoryCompra();
        }

        [HttpGet]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CompraGadoDto>> Get(int id)
        {
            // TODO: pass filters
            return Ok(_repository.Get(id));
        }

        [HttpGet("{id}/{pecuaristaId}/{dataInicio}/{dataFim}")]
        public ActionResult<CompraGadoDto> Get(int id, int pecuaristaId, DateTime? dataInicio, DateTime? dataFim)
        {
            // TODO: buscar compra e seus itens
            return Ok(_repository.Get(id, pecuaristaId, dataInicio, dataFim));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CompraGadoDto Compra)
        {
            var Model = new CompraGadoModel()
            {
                Id = Compra.Id,
                DataEntrega = Compra.DataEntrega,
                PecuaristaId = Compra.PecuaristaId
            };

            if (Model.DataEntrega == null)
            {
                return BadRequest("A compra deve possuir uma data de entrega");
            }

            if (Model.PecuaristaId == 0)
            {
                return BadRequest("A compra deve possuir um pecuarista");
            }

            if (Model.PecuaristaId == 0)
            {
                return BadRequest("A compra deve possuir um pecuarista");
            }

            if (Compra.Itens.GroupBy(x => x.AnimalId).Count() > 1)
            {
                return BadRequest("A compra não pode possuir mais de dois itens com o mesmo animal");
            }

            if (Compra.Itens.Where(x => x.QuantidadeAnimal <= 0).Count() > 0)
            {
                return BadRequest("Nenhum item na compra pode ter quantidade menor ou igual a zero");
            }

            _repository.Post(Model);

            Compra.Itens.ForEach(x =>
            {
                if (x.FlagExcluir)
                {
                    // TODO: delete item
                }
                else
                {
                    if (x.Id > 0)
                    {
                        // TODO: gravar
                    }
                    else
                    {
                        // TODO: atualizar
                    }
                }
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}