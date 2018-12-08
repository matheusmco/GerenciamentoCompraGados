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

                        gridItems.Columns["NomeAnimal"].HeaderText = "Animal";
                        gridItems.Columns["QuantidadeAnimal"].HeaderText = "Quantidade";
                        gridItems.Columns["PrecoAnimal"].HeaderText = "Preço";

                        gridItems.Columns["Id"].Visible = false;
                        gridItems.Columns["AnimalId"].Visible = false;
                        gridItems.Columns["FlagExcluir"].Visible = false;
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //TODO: validar valores selecionados na tela
            if (!ValidarGravacao())
            {
                return;
            }


            //TODO: pegar valores de tela e valorizar objeto DTO
            var Compra = new CompraGado() { };

            var id = txtId.Text;

            Compra.Id = IsNullEmptyOrWhiteSpace(id) ? 0 : Int32.Parse(id);
            Compra.DataEntrega = Convert.ToDateTime(txtDataEntrega.Text);
            Compra.PecuaristaId = (cmbPecuarista.SelectedItem as ComboboxItem).Value;
            Compra.Itens = (List<CompraGadoItem>)gridItems.DataSource;

            //TODO: chamada Async para gravação
            PostCompraGado(Compra);
            //TODO: necessário pegar id, verificar se post está retornando
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

                    }
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //TODO: get items from dataGrid
            var a = (List<CompraGadoItem>)gridItems.DataSource;
            a.Add(new CompraGadoItem());
            gridItems.DataSource = a;
            //TODO: add new empty item
            //TODO: add items to dataGrid
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //TODO: get id from selected item
            //TODO: send delete
            //TODO: delete it from datagridview
        }
    }
}
