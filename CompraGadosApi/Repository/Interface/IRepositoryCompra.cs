using System;
using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;

namespace CompraGadosApi.Repository.Interface
{
    interface IRepositoryCompra
    {
        IEnumerable<CompraGadoDto> Get(int id);
        CompraGadoDto Get(int id, int pecuaristaId, DateTime? dataInicio, DateTime? dataFim);
        int Post(CompraGadoModel Compra); // TODO: diferenciar gravar a atualizar
        int GravarItem(CompraGadoItemModel Compra);
        void Delete(int id);
    }
}