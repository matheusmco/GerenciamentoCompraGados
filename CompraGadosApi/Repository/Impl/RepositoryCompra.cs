using System;
using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;
using CompraGadosApi.Repository.Interface;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryCompra : RepositoryBase, IRepositoryCompra
    {
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CompraGadoDto> Get()
        {
            throw new System.NotImplementedException();
        }

        public CompraGadoDto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public CompraGadoDto Get(int id, int pecuaristaId, DateTime? dataInicio, DateTime? dataFim)
        {
            throw new NotImplementedException();
        }

        public int GravarItem(CompraGadoItemModel Compra)
        {
            throw new System.NotImplementedException();
        }

        public int Post(CompraGadoModel Compra)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<CompraGadoDto> IRepositoryCompra.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}