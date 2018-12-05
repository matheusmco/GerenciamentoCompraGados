using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Repository.Interface;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryPecuarista : RepositoryBase, IRepositoryPecuarista
    {
        public IEnumerable<PecuaristaDto> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}