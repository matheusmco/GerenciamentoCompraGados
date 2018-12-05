using System;
using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;
using CompraGadosApi.Repository.Interface;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryCompra : RepositoryBase, IRepositoryCompra
    {
        public int AtualizarCompra(CompraGadoModel Compra)
        {
            throw new NotImplementedException();
        }

        public int AtualizarItem(CompraGadoItemModel Compra)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompraGadoDto> ConsultarCompra(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarCompra(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarItem(int id)
        {
            throw new NotImplementedException();
        }

        public int GravarCompra(CompraGadoModel Compra)
        {
            throw new NotImplementedException();
        }

        public int GravarItem(CompraGadoItemModel Compra)
        {
            throw new NotImplementedException();
        }

        public CompraGadoDto RelatorioCompra(int id, int pecuaristaId, DateTime? dataInicio, DateTime? dataFim)
        {
            throw new NotImplementedException();
        }
    }
}