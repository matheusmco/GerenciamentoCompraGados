using System;
using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;
using CompraGadosApi.Repository.Interface;
using Dapper;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryCompra : RepositoryBase, IRepositoryCompra
    {
        public int AtualizarCompra(CompraGadoModel Compra)
        {
            throw new NotImplementedException();
        }

        public int AtualizarItem(CompraGadoItemModel Compra)
        {
            throw new NotImplementedException();
        }

        public CompraGadoDto ConsultarCompra(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompraGadoItemDto> ConsultarItensPorCompra(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarCompra(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarItem(int id)
        {
            throw new NotImplementedException();
        }

        public int GravarCompra(CompraGadoModel Compra)
        {
            throw new NotImplementedException();
        }

        public int GravarItem(CompraGadoItemModel Compra)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompraGadoDto> RelatorioCompra(int? id, int? pecuaristaId, DateTime? dataInicio, DateTime? dataFim)
        {
            using (var connection = Connection)
            {
                return connection.Query<CompraGadoDto>(""
                    + "SELECT COMPRA_GADO.ID, PECUARISTA.NOME, COMPRA_GADO.DATA_ENTREGA "
                    + "FROM "
                    + "COMPRA_GADO INNER JOIN PECUARISTA ON COMPRA_GADO.PECUARISTA_ID = PECUARISTA.ID "
                    + "WHERE COMPRA_GADO.ID = @id OR COMPRA_GADO.PECUARISTA_ID = @pecuaristaId OR COMPRA_GADO.DATA_ENTREGA BETWEEN @dataInicio AND @dataFim",
                    param: new
                    {
                        id,
                        pecuaristaId,
                        dataInicio,
                        dataFim
                    });
            }
        }
    }
}