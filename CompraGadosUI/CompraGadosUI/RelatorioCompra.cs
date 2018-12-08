using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace CompraGadosUI
{
    public partial class RelatorioCompra : Form
    {
        int index = 1;
        int numberOfItems = 0;
        int itemsPerPage = 10;
        int numberOfPages = 1;
        CompraGado[] listaCompras;

        public RelatorioCompra()
        {
            InitializeComponent();
        }

        private void RelatorioCompra_Load(object sender, EventArgs e)
        {
            GetAllPecuarista();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            DateTime dataEntregaDe;
            DateTime dataEntregaAte;
            var comboItem = cmbPecuarista.SelectedItem as ComboboxItem;
            var pecuaristaId = (comboItem == null ? "" : comboItem.Value.ToString());

            if ((IsNullEmptyOrWhiteSpace(txtId.Text)) && (IsNullEmptyOrWhiteSpace(pecuaristaId)) && !DateTime.TryParse(txtDataEntregaDe.Text, out dataEntregaDe) && !DateTime.TryParse(txtDataEntregaAte.Text, out dataEntregaAte))
            {
                MessageBox.Show("Pelo menos um dos filtros deve ser preenchido para que seja realizada a pesquisa");
                return;
            }

            index = 1;
            numberOfPages = 0;
            GetCompras();
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

        private async void GetCompras()
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                var id = txtId.Text;
                var pecuaristId = (cmbPecuarista.SelectedItem as ComboboxItem).Value.ToString();

                var url = "http://localhost:5000/api/Compras/Relatorio/" + (IsNullEmptyOrWhiteSpace(id) ? "0" : id) + "/" + (IsNullEmptyOrWhiteSpace(pecuaristId) ? "0" : pecuaristId);

                var sDataEntregaDe = txtDataEntregaDe.Text;
                DateTime dataEntregaDe;
                if (DateTime.TryParse(sDataEntregaDe, out dataEntregaDe))
                {
                    url += JsonConvert.SerializeObject(dataEntregaDe) + "/";
                }

                var sDataEntregaAte = txtDataEntregaAte.Text;
                DateTime dataEntregaAte;
                if (DateTime.TryParse(sDataEntregaAte, out dataEntregaAte))
                {
                    url += JsonConvert.SerializeObject(Convert.ToDateTime(sDataEntregaAte)) + "/";
                }

                using (var response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        listaCompras = JsonConvert.DeserializeObject<CompraGado[]>(JsonString);

                        numberOfItems = listaCompras.Count();

                        if (numberOfItems <= itemsPerPage)
                        {
                            numberOfPages = 1;
                        }
                        else
                        {
                            numberOfPages = numberOfItems / itemsPerPage;

                            if (numberOfItems % itemsPerPage > 0)
                            {
                                numberOfPages++;
                            }
                        }

                        Paginar();
                    }
                }
            }
        }

        private void Paginar()
        {
            gridResultado.DataSource = listaCompras.Skip(itemsPerPage * (index - 1)).Take(itemsPerPage).ToArray();

            gridResultado.Columns["NomePecuarista"].HeaderText = "Pecuarista";
            gridResultado.Columns["DataEntrega"].HeaderText = "Data Entrega";
            gridResultado.Columns["ValorTotal"].HeaderText = "Valor Total";

            gridResultado.Columns["PecuaristaId"].Visible = false;
            gridResultado.Columns["IsImpresso"].Visible = false;
        }

        private bool IsNullEmptyOrWhiteSpace(string value)
        {
            return String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || value == null;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index == 1)
            {
                return;
            }

            index--;
            Paginar();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index == numberOfPages)
            {
                return;
            }

            index++;
            Paginar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var Compra = ObterCompraSelecionada();
            DeleteCompraGado(Compra.Id);
        }

        private async void DeleteCompraGado(int id)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.DeleteAsync("http://localhost:5000/api/Compras/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Pesquisar();
                    }
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Global.CompraId = 0;
            ChamarFormCadastro();
        }

        private CompraGado ObterCompraSelecionada()
        {
            if (gridResultado.CurrentRow != null)
            {
                return (CompraGado)gridResultado.CurrentRow.DataBoundItem;
            }

            return null;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var Compra = ObterCompraSelecionada();

            if (Compra == null)
            {
                MessageBox.Show("Selecione uma compra para alterar");
                return;
            }

            Global.CompraId = Compra.Id;
            ChamarFormCadastro();
        }

        private void ChamarFormCadastro()
        {
            var formCadastro = new CadastroCompra();
            formCadastro.Show();
        }
    }

    public class Pecuarista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class CompraGado
    {
        public int Id { get; set; }
        public int PecuaristaId { get; set; }
        public string NomePecuarista { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double ValorTotal { get; set; }
        public bool IsImpresso { get; set; }
        public List<CompraGadoItem> Itens { get; set; }
    }

    public class CompraGadoItem
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string NomeAnimal { get; set; }
        public int QuantidadeAnimal { get; set; }
        public double PrecoAnimal { get; set; }
        public bool FlagExcluir { get; set; }
        public double ValorTotal { get; set; }
    }
}
