using System;

namespace CompraGadosApi.Data.Dtos
{
    public class CompraGadoDto
    {
        public int Id { get; set; }
        public string NomePecuarista { get; set; }
        public DateTime DataEntrega { get; set; }
        public double ValorTotal { get; set; }
    }
}