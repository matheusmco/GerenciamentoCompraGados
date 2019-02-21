using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        string urlApi;

        public RelatorioCompra()
        {
            InitializeComponent();
            urlApi = Service.GetApiUrl();
        }

        private void RelatorioCompra_Load(object sender, EventArgs e)
        {
            GetAllPecuarista();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
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
            var Compra = Service.ObterCompraSelecionada<CompraGado>(gridResultado);

            if (Compra.IsImpresso)
            {
                MessageBox.Show("A compra está impressa, não pode ser alterada e nem excluída");
                return;
            }

            DeleteCompraGado(Compra.Id);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Global.CompraId = 0;
            ChamarFormCadastro();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var Compra = Service.ObterCompraSelecionada<CompraGado>(gridResultado);

            if (Compra == null)
            {
                MessageBox.Show("Selecione uma compra para alterar");
                return;
            }

            Global.CompraId = Compra.Id;
            ChamarFormCadastro();
        }

        //Support
        private void ChamarFormCadastro()
        {
            var formCadastro = new CadastroCompra();
            formCadastro.Show();
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

        private void Pesquisar()
        {
            DateTime dataEntregaDe;
            DateTime dataEntregaAte;
            var comboItem = cmbPecuarista.SelectedItem as ComboboxItem;
            var pecuaristaId = (comboItem == null ? "" : comboItem.Value.ToString());

            if ((Service.IsNullEmptyOrWhiteSpace(txtId.Text)) && (Service.IsNullEmptyOrWhiteSpace(pecuaristaId)) && !DateTime.TryParse(txtDataEntregaDe.Text, out dataEntregaDe) && !DateTime.TryParse(txtDataEntregaAte.Text, out dataEntregaAte))
            {
                MessageBox.Show("Pelo menos um dos filtros deve ser preenchido para que seja realizada a pesquisa");
                return;
            }

            index = 1;
            numberOfPages = 0;
            GetCompras();
        }

        // async
        private async void DeleteCompraGado(int id)
        {
            var json = await Service.DeleteApi(Service.GetApiUrl() + "Compras/" + id);

            Pesquisar();
        }

        private async void GetCompras()
        {
            using (var client = new HttpClient())
            {
                var id = txtId.Text;
                var pecuaristId = (cmbPecuarista.SelectedItem as ComboboxItem).Value.ToString();

                var url = "Compras/Relatorio/" + (Service.IsNullEmptyOrWhiteSpace(id) ? "0" : id) + "/" + (Service.IsNullEmptyOrWhiteSpace(pecuaristId) ? "0" : pecuaristId);

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

                var json = await Service.GetApi(Service.GetApiUrl() + url);

                listaCompras = JsonConvert.DeserializeObject<CompraGado[]>(json);

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
    }

    // TODO: chamar Dto
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
