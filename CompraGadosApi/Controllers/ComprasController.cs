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

        // TODO: fazer endpoint para update de impressão

        [HttpGet]
        [HttpGet("{id}")]
        public ActionResult<CompraGadoDto> Get(int id)
        {
            var Compra = _repository.ConsultarCompra(id);
            Compra.Itens = _repository.ConsultarItensPorCompra(Compra.Id).ToList();
            Compra.Itens.ForEach(x =>
            {
                x.ValorTotal = x.QuantidadeAnimal * x.PrecoAnimal;
            });
            return Ok(Compra);
        }

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

            if (Compra.DataEntrega == null)
            {
                return BadRequest("A compra deve possuir uma data de entrega");
            }

            if (Compra.PecuaristaId == 0)
            {
                return BadRequest("A compra deve possuir um pecuarista");
            }

            if (Compra.Itens == null)
            {
                return BadRequest("A compra deve possuir pelo menos 1 item");
            }

            // agrupo pelo id do animal, se a lista resultante for menor que a lista de itens, temos itens com animais repetidos
            if (Compra.Itens.GroupBy(x => x.AnimalId).Count() < Compra.Itens.Count())
            {
                return BadRequest("A compra não pode possuir mais de dois itens com o mesmo animal");
            }

            if (Compra.Itens.Where(x => x.QuantidadeAnimal <= 0).Count() > 0)
            {
                return BadRequest("Nenhum item na compra pode ter quantidade menor ou igual a zero");
            }

            var Model = new CompraGadoModel()
            {
                Id = Compra.Id,
                DataEntrega = Compra.DataEntrega,
                PecuaristaId = Compra.PecuaristaId
            };

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

            return Ok(Model.Id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeletarItemPorCompra(id);
            _repository.DeletarCompra(id);
        }
    }
}