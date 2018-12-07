using System;
using System.Windows.Forms;

namespace CompraGadosUI
{
    public partial class CadastroCompra : Form
    {
        public CadastroCompra()
        {
            InitializeComponent();
        }

        private void gbAnimais_Enter(object sender, EventArgs e)
        {

        }

        private void CadastroCompra_Deactivate(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
