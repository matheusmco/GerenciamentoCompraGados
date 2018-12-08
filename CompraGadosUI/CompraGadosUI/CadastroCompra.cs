using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private void gbAnimais_Enter(object sender, EventArgs e)
        {

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

        private async void GetCompra()
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.GetAsync("http://localhost:5000/api/Compras/" + CompraId.ToString()))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        var Model = JsonConvert.DeserializeObject<CompraGado>(JsonString);

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
                }
            }
        }

        private async void GetAllPecuarista()
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.GetAsync("http://localhost:5000/api/Pecuarista"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var PecuaristaJsonString = await response.Content.ReadAsStringAsync();
                        foreach (var item in JsonConvert.DeserializeObject<Pecuarista[]>(PecuaristaJsonString))
                        {
                            cmbPecuarista.Items.Add(new ComboboxItem()
                            {
                                Text = item.Nome,
                                Value = item.Id
                            });
                        }
                    }
                }
            }
        }

        private async void GetAllAnimal()
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.GetAsync("http://localhost:5000/api/Animal"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var PecuaristaJsonString = await response.Content.ReadAsStringAsync();
                        listaAnimal = JsonConvert.DeserializeObject<List<Animal>>(PecuaristaJsonString);
                        foreach (var item in listaAnimal)
                        {
                            cmbAnimal.Items.Add(new ComboboxItem()
                            {
                                Text = item.Nome,
                                Value = item.Id
                            });
                        }
                    }
                }
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

            Compra.Id = IsNullEmptyOrWhiteSpace(id) ? 0 : Int32.Parse(id);
            Compra.DataEntrega = Convert.ToDateTime(txtDataEntrega.Text);
            Compra.PecuaristaId = (cmbPecuarista.SelectedItem as ComboboxItem).Value;
            Compra.Itens = (List<CompraGadoItem>)gridItems.DataSource;
            Compra.Itens.AddRange(itensExcluidos);

            PostCompraGado(Compra);
        }

        private bool IsNullEmptyOrWhiteSpace(string value)
        {
            return String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || value == null;
        }

        private bool ValidarGravacao()
        {
            var valido = true;
            var mensagem = "";

            if (IsNullEmptyOrWhiteSpace(txtDataEntrega.Text))
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

            return valido;
        }

        private async void PostCompraGado(CompraGado Compra)
        {
            var compra = JsonConvert.SerializeObject(Compra);

            var buffer = System.Text.Encoding.UTF8.GetBytes(compra);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.PostAsync("http://localhost:5000/api/Compras", byteContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Registro gravado com sucesso");
                    }
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarAnimal();
        }

        private void AdicionarAnimal()
        {
            if (cmbAnimal.SelectedItem == null)
            {
                MessageBox.Show("Selecione um animal");
                return;
            }

            var Item = new CompraGadoItem();

            var id = txtIdItemHidden.Text;
            if (IsNullEmptyOrWhiteSpace(id))
            {
                Item.Id = 0;
            }
            else
            {
                Item.Id = int.Parse(id);
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

            if (IsNullEmptyOrWhiteSpace(quantidade))
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

            if (lista != null)
            {
                lista.Remove(lista.Where(x => x.Id == Item.Id).First());

            }
            else
            {
                lista = new List<CompraGadoItem>();
            }


            lista.Add(Item);

            gridItems.DataSource = null;
            gridItems.DataSource = lista;

            ConfigurarColunasDataGrid();
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

        private bool ConsistirItemSelecionado()
        {
            if (gridItems.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item para excluir");
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ConsistirItemSelecionado())
            {
                return;
            }

            var a = (CompraGadoItem)gridItems.CurrentRow.DataBoundItem;
            for (var i = 0; i < cmbPecuarista.Items.Count; i++)
            {
                if ((cmbAnimal.Items[i] as ComboboxItem).Value == a.AnimalId)
                {
                    cmbAnimal.SelectedIndex = i;
                    break;
                }
            }
            txtQuantidade.Value = a.QuantidadeAnimal;
            txtIdItemHidden.Text = a.Id.ToString();
        }

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
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
