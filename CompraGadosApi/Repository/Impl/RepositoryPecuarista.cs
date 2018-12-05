using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;

namespace CompraGadosApi.Repository.Interface
{
    interface IRepositoryPecuarista
    {
        IEnumerable<PecuaristaDto> Get();
    }
}