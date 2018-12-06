using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Repository.Interface;
using Dapper;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryPecuarista : RepositoryBase, IRepositoryPecuarista
    {
        public IEnumerable<PecuaristaDto> Get()
        {
            using (var connection = Connection)
            {
                return connection.Query<PecuaristaDto>("SELECT ID, NOME FROM PECUARISTA");
            }
        }
    }
}