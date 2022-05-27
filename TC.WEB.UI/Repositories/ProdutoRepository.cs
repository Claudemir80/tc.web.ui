using Newtonsoft.Json;
using System.Text;
using TC.WEB.UI.Interfaces;
using TC.WEB.UI.Models;

namespace TC.WEB.UI.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private readonly string urlapi = "https://localhost:44361/";
        private readonly string myroute = "api/Produto/";

        private static HttpClient client = new HttpClient();

        public Produto Create(Produto produto)
        {
            var produtocriado = new Produto();

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(produto);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.PostAsync(urlapi + myroute, content);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    produtocriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtocriado;
        }

        public Produto Update(Produto produto)
        {
            var produtocriado = new Produto();

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(produto);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.PutAsync(urlapi + myroute + produto.Id, content);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    produtocriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtocriado;
        }

        public Produto Delete(int id)
        {
            var produtocriado = new Produto();

            produtocriado.Id = id;

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(produtocriado);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.DeleteAsync(urlapi + myroute + id);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    produtocriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return produtocriado;
        }

        public Produto GetOne(int id)
        {
            var produtocriado = new Produto();

            produtocriado.Id = id;

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(produtocriado);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.GetAsync(urlapi + myroute + id);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    produtocriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtocriado;
        }

        public List<Produto> Get()
        {
            var retorno = new List<Produto>();

            try
            {
                var resposta = client.GetStringAsync(urlapi + myroute);

                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<Produto[]>(resposta.Result).ToList();

            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }
    }
}
