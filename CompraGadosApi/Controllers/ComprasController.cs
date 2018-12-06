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
        public ActionResult<CompraGadoDto> Get(int id)
        {
            var Compra = _repository.ConsultarCompra(id);
            Compra.Itens = _repository.ConsultarItensPorCompra(Compra.Id).ToList();
            Compra.ValorTotal = Compra.Itens.Select(x => x.QuantidadeAnimal * x.PrecoAnimal).Sum();
            return Ok(Compra);
        }

        // [Route("Relatorio?id={id}&pecuaristaId={pecuaristaId}&dataInicio={dataInicio}&dataFim={dataFim}")]
        [Route("Relatorio/{id}/{pecuaristaId}/{dataInicio:DateTime?}/{dataFim:DateTime?}")]
        public ActionResult<IEnumerable<CompraGadoDto>> Get(int id, int pecuaristaId, DateTime? dataInicio = null, DateTime? dataFim = null)
        {
            return Ok(_repository.RelatorioCompra(id, pecuaristaId, dataInicio, dataFim));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CompraGadoDto Compra)
        {
            if (Compra.IsImpresso)
            {
                return BadRequest("A compra já está impressa, não pode ser excluída");
            }

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

            if (Model.Id == 0)
            {
                Model.Id = _repository.GravarCompra(Model);
            }
            else
            {
                _repository.AtualizarCompra(Model);
            }

            Compra.Itens.ForEach(x =>
            {
                if (x.FlagExcluir)
                {
                    _repository.DeletarItem(x.Id);
                }
                else
                {
                    if (x.Id == 0)
                    {
                        _repository.GravarItem(new CompraGadoItemModel(x, Model.Id));
                    }
                    else
                    {
                        _repository.AtualizarItem(new CompraGadoItemModel(x, Model.Id));
                    }
                }
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeletarCompra(id);
        }
    }
}