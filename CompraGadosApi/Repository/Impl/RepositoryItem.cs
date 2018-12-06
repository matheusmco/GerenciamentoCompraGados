using System.Collections.Generic;
using CompraGadosApi.Data.Dtos;
using CompraGadosApi.Data.Models;
using CompraGadosApi.Repository.Interface;

namespace CompraGadosApi.Repository.Impl
{
    class RepositoryItem : RepositoryBase, IRepositoryItem
    {
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CompraGadoItemDto> Get()
        {
            throw new System.NotImplementedException();
        }

        public int Post(CompraGadoItemModel Compra)
        {
            throw new System.NotImplementedException();
        }
    }
}