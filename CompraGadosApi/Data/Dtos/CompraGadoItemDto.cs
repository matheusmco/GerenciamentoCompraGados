namespace CompraGadosApi.Data.Dtos
{
    public class CompraGadoItemDto
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public string NomeAnimal { get; set; }
        public int QuantidadeAnimal { get; set; }
        public double PrecoAnimal { get; set; }
    }
}