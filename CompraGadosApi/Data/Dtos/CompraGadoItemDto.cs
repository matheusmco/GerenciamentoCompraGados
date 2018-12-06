namespace CompraGadosApi.Data.Dtos
{
    public class CompraGadoItemDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string NomeAnimal { get; set; }
        public int QuantidadeAnimal { get; set; }
        public double PrecoAnimal { get; set; }
        public bool FlagExcluir { get; set; }
    }
}