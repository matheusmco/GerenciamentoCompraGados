using System;
using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;

namespace CompraGadosApi.Repository.Interface
{
    interface IRepositoryCompra
    {
        IEnumerable<CompraGadoDto> ConsultarCompra(int id);
        CompraGadoDto RelatorioCompra(int id, int pecuaristaId, DateTime? dataInicio, DateTime? dataFim);
        int GravarCompra(CompraGadoModel Compra);
        int AtualizarCompra(CompraGadoModel Compra);
        int GravarItem(CompraGadoItemModel Compra);
        int AtualizarItem(CompraGadoItemModel Compra);
        void DeletarItem(int id);
        void DeletarCompra(int id);
    }
}