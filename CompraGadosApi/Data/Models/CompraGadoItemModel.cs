using CompraGadosApi.Data.Dtos;

namespace CompraGadosApi.Data.Models
{
    class CompraGadoItemModel
    {
        public int Id { get; set; }
        // public int PecuaristaId { get; set; }
        public int Quantidade { get; set; }
        public int CompraGadoId { get; set; }
        public int AnimalId { get; set; }

        public CompraGadoItemModel(CompraGadoItemDto Dto, int CompraGadoId)
        {
            Id = Dto.Id;
            Quantidade = Dto.QuantidadeAnimal;
            this.CompraGadoId = CompraGadoId;
            AnimalId = Dto.AnimalId;
        }
    }
}