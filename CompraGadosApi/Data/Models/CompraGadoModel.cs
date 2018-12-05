using System;
using System.Collections.Generic;

namespace CompraGadosApi.Data.Models
{
    class CompraGadoModel
    {
        public int Id { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int PecuaristaId { get; set; }
        public bool IsImpresso { get; set; }
        public List<CompraGadoItemModel> Itens { get; set; }
    }
}