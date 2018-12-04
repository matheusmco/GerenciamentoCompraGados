using System;

namespace CompraGadosApi.Data.Models
{
    class CompraGadoItemModel
    {
        public int Id { get; set; }
        public DateTime DatEntrega { get; set; }
        public int PecuaristaId { get; set; }
    }
}