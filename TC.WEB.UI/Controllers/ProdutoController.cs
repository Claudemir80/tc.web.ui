using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TC.WEB.UI.Interfaces;
using TC.WEB.UI.Models;

namespace TC.WEB.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProduto _iproduto;
        private readonly ICategoria _categoria;

        public ProdutoController(IProduto iProduto, ICategoria categoria)
        {
            _iproduto = iProduto;
            _categoria = categoria;
        }

        // GET: ProdutoController
        public ActionResult Index()
        {
            return View(_iproduto.Get());
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View(_iproduto.GetOne(id));
        }

        // GET: ProdutoController/Create

        List<SelectListItem> cities = new List<SelectListItem>();
        public ActionResult Cadastro()
        {
            foreach (var item in _categoria.Get())
            {
                cities.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Nome
                }) ;
            }

            ViewBag.cities = cities;

            var datas = DateTime.Now.ToShortDateString();

            ViewBag.datas = datas;

            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Produto collection)
        {
            try
            {
                _iproduto.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_iproduto.GetOne(id));
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produto collection)
        {
            try
            {
                _iproduto.Update(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_iproduto.GetOne(id));
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produto collection)
        {
            try
            {
                _iproduto.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
