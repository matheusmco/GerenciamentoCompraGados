using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;

namespace CompraGadosApi.Repository.Interface
{
    interface IRepositoryCompra
    {
        IEnumerable<CompraGadoDto> Get();
        CompraGadoDto Get(int id);
        int Post(CompraGadoModel Compra);
        void Delete(int id);
    }
}