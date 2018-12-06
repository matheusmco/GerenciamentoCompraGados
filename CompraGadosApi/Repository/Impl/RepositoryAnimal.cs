using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Repository.Interface;
using Dapper;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryAnimal : RepositoryBase, IRepositoryAnimal
    {
        public IEnumerable<AnimalDto> Get()
        {
            using (var connection = Connection)
            {
                return connection.Query<AnimalDto>("SELECT ID, DESCRICAO AS NOME, PRECO FROM ANIMAL");
            }
        }
    }
}