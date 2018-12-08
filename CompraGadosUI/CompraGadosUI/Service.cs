using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompraGadosUI
{
    class Service
    {
        public static T ObterCompraSelecionada<T>(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                return (T)grid.CurrentRow.DataBoundItem;
            }

            return default(T);
        }

        public static bool IsNullEmptyOrWhiteSpace(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value == null;
        }

        public static string GetApiUrl()
        {
            return ConfigurationManager.AppSettings["apiUrl"];
        }

        public static async Task<string> GetApi(string url)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        MessageBox.Show("Erro na chamada da Api");
                        return null;
                    }
                }
            }
        }

        public static async Task<bool> DeleteApi(string url)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.DeleteAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Erro na chamada da Api");
                        return false;
                    }
                }
            }
        }

        public static async Task<bool> PostApi(string url, object obj)
        {
            var content = JsonConvert.SerializeObject(obj);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var client = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var response = await client.PostAsync(url, byteContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Erro na chamada da Api");
                        return false;
                    }
                }
            }
        }
    }
}
