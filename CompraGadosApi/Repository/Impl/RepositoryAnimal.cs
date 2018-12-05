using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Repository.Interface;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryAnimal : RepositoryBase, IRepositoryAnimal
    {
        public IEnumerable<AnimalDto> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}