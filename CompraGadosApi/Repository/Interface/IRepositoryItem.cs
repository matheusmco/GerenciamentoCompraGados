using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;

namespace CompraGadosApi.Repository.Interface
{
    interface IRepositoryItem
    {
        IEnumerable<CompraGadoItemDto> Get();
        int Post(CompraGadoItemModel Compra); // TODO: diferenciar gravar a atualizar
        void Delete(int id);
    }
}