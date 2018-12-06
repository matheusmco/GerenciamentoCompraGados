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
            using (var connection = Connection)
            {
                return connection.QueryFirst<CompraGadoDto>("SELECT ID, PECUARISTA_ID, DATA_ENTREGA, FLAG_IMPRESSO AS IS_IMPRESSO FROM COMPRA_GADO WHERE ID = @id",
                    param: new
                    {
                        id
                    });
            }
        }

        public IEnumerable<CompraGadoItemDto> ConsultarItensPorCompra(int id)
        {
            using (var connection = Connection)
            {
                return connection.Query<CompraGadoItemDto>("SELECT COMPRA_GADO_ITEM.ID, ANIMAL.NOME AS NOME_ANIMAL, COMPRA_GADO.QUANTIDADE AS QUANTIDADE_ANIMAL FROM COMPRA_GADO_ITEM WHERE COMPRA_GADO_ID = @id",
                    param: new
                    {
                        id
                    });
            }
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
                    + "SELECT COMPRA_GADO.ID, PECUARISTA.NOME AS NOME_PECUARISTA, COMPRA_GADO.DATA_ENTREGA, SUM(COMPRA_GADO_ITEM.QUANTIDADE * ANIMAL.PRECO) AS VALOR_TOTAL "
                    + "FROM "
                    + "COMPRA_GADO INNER JOIN PECUARISTA ON COMPRA_GADO.PECUARISTA_ID = PECUARISTA.ID "
                    + "INNER JOIN COMPRA_GADO_ITEM ON COMPRA_GADO.ID = COMPRA_GADO_ITEM.COMPRA_GADO_ID "
                    + "INNER JOIN ANIMAL ON COMPRA_GADO_ITEM.ANIMAL_ID = ANIMAL.ID "
                    + "WHERE COMPRA_GADO.ID = @id OR COMPRA_GADO.PECUARISTA_ID = @pecuaristaId OR COMPRA_GADO.DATA_ENTREGA BETWEEN @dataInicio AND @dataFim "
                    + "GROUP BY COMPRA_GADO.ID, PECUARISTA.NOME, COMPRA_GADO.DATA_ENTREGA",
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