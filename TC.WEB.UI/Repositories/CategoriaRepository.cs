using Newtonsoft.Json;
using System.Text;
using TC.WEB.UI.Interfaces;
using TC.WEB.UI.Models;

namespace TC.WEB.UI.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly string urlapi = "https://localhost:44361/";
        private readonly string myroute = "api/Categoria/";

        private static HttpClient client = new HttpClient();

        public Categoria Create(Categoria categoria)
        {
            var categoriacriada = new Categoria();

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(categoria);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.PostAsync(urlapi + myroute, content);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    categoriacriada = JsonConvert.DeserializeObject<Categoria>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return categoriacriada;
        }

        public Categoria Update(Categoria categoria)
        {
            var categoriacriada = new Categoria();

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(categoria);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.PutAsync(urlapi + myroute + categoria.Id, content);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    categoriacriada = JsonConvert.DeserializeObject<Categoria>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return categoriacriada;
        }

        public Categoria Delete(int id)
        {
            var categoriacriada = new Categoria();

            categoriacriada.Id = id;

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(categoriacriada);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.DeleteAsync(urlapi + myroute + id);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    categoriacriada = JsonConvert.DeserializeObject<Categoria>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return categoriacriada;
        }

        public Categoria GetOne(int id)
        {
            var categoriacriada = new Categoria();

            categoriacriada.Id = id;

            try
            {
                string jsonObjeto = JsonConvert.SerializeObject(categoriacriada);

                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = client.GetAsync(urlapi + myroute + id);

                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();

                    categoriacriada = JsonConvert.DeserializeObject<Categoria>(retorno.Result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return categoriacriada;
        }

        public List<Categoria> Get()
        {
            var retorno = new List<Categoria>();

            try
            {
                var resposta = client.GetStringAsync(urlapi + myroute);

                resposta.Wait();
                retorno = JsonConvert.DeserializeObject<Categoria[]>(resposta.Result).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }
    }
}
