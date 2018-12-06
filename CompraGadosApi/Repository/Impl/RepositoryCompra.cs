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
            using (var connection = Connection)
            {
                connection.Execute("UPDATE COMPRA_GADO SET DATA_ENTREGA = @dataEntrega, PECUARISTA_ID = @pecuaristaId WHERE ID = @id",
                    param: new
                    {
                        dataEntrega = Compra.DataEntrega,
                        pecuaristaId = Compra.PecuaristaId,
                        id = Compra.Id
                    });
            }

            return Compra.Id;
        }

        public int AtualizarItem(CompraGadoItemModel Compra)
        {
            using (var connection = Connection)
            {
                connection.QueryFirst("UPDATE COMPRA_GADO_ITEM SET QUANTIDADE = @quantidade, ANIMAL_ID = @animalId WHERE ID = @id",
                    param: new
                    {
                        quantidade = Compra.Quantidade,
                        animalId = Compra.AnimalId,
                        id = Compra.Id
                    });
            }

            return Compra.Id;
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
            using (var connection = Connection)
            {
                connection.Execute("DELETE FROM COMPRA_GADO WHERE ID = @id",
                    param: new
                    {
                        id = id
                    });
            }
        }

        public void DeletarItem(int id)
        {
            using (var connection = Connection)
            {
                connection.Execute("DELETE FROM COMPRA_GADO_ITEM WHERE ID = @id",
                    param: new
                    {
                        id = id
                    });
            }
        }

        public int GravarCompra(CompraGadoModel Compra)
        {
            using (var connection = Connection)
            {
                return connection.QueryFirst<int>("INSERT INTO COMPRA_GADO (DATA_ENTREGA, PECUARISTA_ID) VALUES (@dataEntrega, @pecuaristaId); SELECT SCOPE_IDENTITY()",
                    param: new
                    {
                        dataEntrega = Compra.DataEntrega,
                        pecuaristaId = Compra.PecuaristaId
                    });
            }
        }

        public int GravarItem(CompraGadoItemModel Compra)
        {
            using (var connection = Connection)
            {
                return connection.QueryFirst<int>("INSERT INTO COMPRA_GADO_ITEM (COMPRA_GADO_ID, QUANTIDADE, ANIMAL_ID) VALUES (@compraGadoId, @quantidade, @animalId); SELECT SCOPE_IDENTITY()",
                    param: new
                    {
                        compraGadoId = Compra.CompraGadoId,
                        quantidade = Compra.Quantidade,
                        animalId = Compra.AnimalId
                    });
            }
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