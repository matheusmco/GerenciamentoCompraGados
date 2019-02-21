using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CompraGadosUI
{
    public partial class CadastroCompra : Form
    {
        int CompraId = 0;
        List<CompraGadoItem> itensExcluidos = new List<CompraGadoItem>();
        List<Animal> listaAnimal = new List<Animal>();

        public CadastroCompra()
        {
            InitializeComponent();
        }

        private void CadastroCompra_Deactivate(object sender, EventArgs e)
        {
            //Global.CompraId = 0;
            //Dispose();
        }

        private void CadastroCompra_Load(object sender, EventArgs e)
        {
            CompraId = Global.CompraId;

            GetAllPecuarista();
            GetAllAnimal();

            if (Global.CompraId > 0)
            {
                GetCompra();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (!ValidarGravacao())
            {
                return;
            }

            var Compra = new CompraGado() { };

            var id = txtId.Text;

            Compra.Id = Service.IsNullEmptyOrWhiteSpace(id) ? 0 : int.Parse(id);
            Compra.DataEntrega = Convert.ToDateTime(txtDataEntrega.Text);
            Compra.PecuaristaId = (cmbPecuarista.SelectedItem as ComboboxItem).Value;
            Compra.Itens = (List<CompraGadoItem>)gridItems.DataSource;
            Compra.Itens.AddRange(itensExcluidos);

            PostCompraGado(Compra);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarAnimal();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!ConsistirItemSelecionado())
            {
                return;
            }

            var a = (CompraGadoItem)gridItems.CurrentRow.DataBoundItem;

            a.FlagExcluir = true;
            itensExcluidos.Add(a);

            var lista = (List<CompraGadoItem>)gridItems.DataSource;
            lista.Remove(a);
            gridItems.DataSource = null;
            gridItems.DataSource = lista;

            ConfigurarColunasDataGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ConsistirItemSelecionado())
            {
                return;
            }

            var a = Service.ObterCompraSelecionada<CompraGadoItem>(gridItems);
            for (var i = 0; i < cmbAnimal.Items.Count; i++)
            {
                if ((cmbAnimal.Items[i] as ComboboxItem).Value == a.AnimalId)
                {
                    cmbAnimal.SelectedIndex = i;
                    break;
                }
            }
            txtQuantidade.Value = a.QuantidadeAnimal;
            txtIdItemHidden.Text = a.Id.ToString();
            txtControlGravarAlterar.Text = "1";
        }

        //support
        private void CalcularValorTotalCompra()
        {
            var lista = (List<CompraGadoItem>)gridItems.DataSource;
            var valorTotal = 0.0;

            if (lista != null)
            {
                valorTotal = lista.Select(x => x.ValorTotal).Sum();
            }

            lblValorTotal.Text = valorTotal.ToString();
        }

        private bool ConsistirItemSelecionado()
        {
            if (gridItems.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item");
                return false;
            }
            return true;
        }

        private void ConfigurarColunasDataGrid()
        {
            gridItems.Columns["NomeAnimal"].HeaderText = "Animal";
            gridItems.Columns["QuantidadeAnimal"].HeaderText = "Quantidade";
            gridItems.Columns["PrecoAnimal"].HeaderText = "Preço";
            gridItems.Columns["ValorTotal"].HeaderText = "Valor Total";

            gridItems.Columns["Id"].Visible = false;
            gridItems.Columns["AnimalId"].Visible = false;
            gridItems.Columns["FlagExcluir"].Visible = false;

            CalcularValorTotalCompra();
        }

        private void AdicionarAnimal()
        {
            if (cmbAnimal.SelectedItem == null || cmbAnimal.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um animal");
                return;
            }

            var Item = new CompraGadoItem();

            var control = txtControlGravarAlterar.Text;
            if (control == "0")
            {
                Item.Id = 0;
            }
            else
            {
                Item.Id = int.Parse(txtIdItemHidden.Text);
            }

            Item.AnimalId = (cmbAnimal.SelectedItem as ComboboxItem).Value;

            var dataSource = (List<CompraGadoItem>)gridItems.DataSource;
            if (dataSource != null)
            {
                if (dataSource.Where(x => x.AnimalId == Item.AnimalId && x.Id != Item.Id).Count() > 0)
                {
                    MessageBox.Show("Não é permitido mais de um item com o mesmo animal");
                    return;

                }
            }

            Item.NomeAnimal = (cmbAnimal.SelectedItem as ComboboxItem).Text;

            var quantidade = txtQuantidade.Text;
            if (Service.IsNullEmptyOrWhiteSpace(quantidade))
            {
                MessageBox.Show("Preencha quantidade");
                return;
            }

            Item.QuantidadeAnimal = int.Parse(quantidade);
            if (Item.QuantidadeAnimal == 0)
            {
                MessageBox.Show("Preencha quantidade com  valor maior que 0");
                return;
            }

            Item.PrecoAnimal = listaAnimal.Where(x => x.Id == Item.AnimalId).Select(x => x.Preco).First();
            Item.ValorTotal = Item.QuantidadeAnimal * Item.PrecoAnimal;

            var lista = (List<CompraGadoItem>)gridItems.DataSource;
            if (lista == null)
            {
                lista = new List<CompraGadoItem>();
            }
            else if(control == "1")
            {
                lista.Remove(lista.Where(x => x.Id == Item.Id).First());
            }

            lista.Add(Item);

            gridItems.DataSource = null;
            gridItems.DataSource = lista;

            ConfigurarColunasDataGrid();

            txtControlGravarAlterar.Text = "0";
            txtQuantidade.Value = 1;
            cmbAnimal.SelectedIndex = cmbAnimal.FindStringExact("");
        }

        private bool ValidarGravacao()
        {
            var valido = true;
            var mensagem = "";

            if (Service.IsNullEmptyOrWhiteSpace(txtDataEntrega.Text))
            {
                valido = false;
                mensagem += "Preencha Data de entrega\n";
            }

            if ((cmbPecuarista.SelectedItem as ComboboxItem).Value == 0)
            {
                valido = false;
                mensagem += "Preencha Pecuarista\n";
            }

            var a = (List<CompraGadoItem>)gridItems.DataSource;
            if (a == null)
            {
                valido = false;
                mensagem += "Pelo menos um item deve ser selecionado\n";
            }
            else
            {
                if (a.GroupBy(x => x.AnimalId).Count() < a.Count())
                {
                    valido = false;
                    mensagem += "A compra não pode possuir mais de dois itens com o mesmo animal";
                }

                if (a.Where(x => x.QuantidadeAnimal <= 0).Count() > 0)
                {
                    valido = false;
                    mensagem += "Nenhum item na compra pode ter quantidade menor ou igual a zero";
                }
            }

            if (!valido)
            {
                MessageBox.Show(mensagem);
            }

            return valido;
        }

        //async
        private async void GetCompra()
        {
            var json = await Service.GetApi(Service.GetApiUrl() + "Compras/" + CompraId.ToString());

            if (Service.IsNullEmptyOrWhiteSpace(json))
            {
                return;
            }

            var Model = JsonConvert.DeserializeObject<CompraGado>(json);

            if (Model.IsImpresso)
            {
                btnGravar.Visible = false;
            }

            txtId.Text = Model.Id.ToString();
            txtDataEntrega.Text = Model.DataEntrega.Value.ToString("dd/MM/yyyy");

            for (var i = 0; i < cmbPecuarista.Items.Count; i++)
            {
                if ((cmbPecuarista.Items[i] as ComboboxItem).Value == Model.PecuaristaId)
                {
                    cmbPecuarista.SelectedIndex = i;
                    break;
                }
            }

            gridItems.DataSource = Model.Itens;

            ConfigurarColunasDataGrid();
        }

        private async void GetAllPecuarista()
        {
            var json = await Service.GetApi(Service.GetApiUrl() + "Pecuarista");

            if (Service.IsNullEmptyOrWhiteSpace(json))
            {
                return;
            }

            foreach (var item in JsonConvert.DeserializeObject<Pecuarista[]>(json))
            {
                cmbPecuarista.Items.Add(new ComboboxItem()
                {
                    Text = item.Nome,
                    Value = item.Id
                });
            }
        }

        private async void GetAllAnimal()
        {
            var json = await Service.GetApi(Service.GetApiUrl() + "Animal");

            if (Service.IsNullEmptyOrWhiteSpace(json))
            {
                return;
            }

            listaAnimal = JsonConvert.DeserializeObject<List<Animal>>(json);
            cmbAnimal.Items.Add(new ComboboxItem()
            {
                Text = "",
                Value = 0
            });
            foreach (var item in listaAnimal)
            {
                cmbAnimal.Items.Add(new ComboboxItem()
                {
                    Text = item.Nome,
                    Value = item.Id
                });
            }
        }

        private async void PostCompraGado(CompraGado Compra)
        {
            if (await Service.PostApi(Service.GetApiUrl() + "Compras", Compra))
            {
                MessageBox.Show("Registro gravado com sucesso");
            }
        }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
