using System;
using System.Collections.Generic;

namespace CompraGadosApi.Data.Dtos
{
    public class CompraGadoDto
    {
        public int Id { get; set; }
        public int PecuaristaId { get; set; }
        public string NomePecuarista { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double ValorTotal { get; set; }
        public bool IsImpresso { get; set; }
        public List<CompraGadoItemDto> Itens { get; set; }
    }
}