using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TC.WEB.UI.Interfaces;
using TC.WEB.UI.Models;

namespace TC.WEB.UI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoria _categoria;

        public CategoriaController(ICategoria icategoria)
        {
            _categoria = icategoria;
        }

        // GET: CategoriaController
        public ActionResult Index()
        {
            return View(_categoria.Get());
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoria.GetOne(id));
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria collection)
        {
            try
            {
                _categoria.Create(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_categoria.GetOne(id));
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria collection)
        {
            try
            {
                _categoria.Update(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_categoria.GetOne(id));
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categoria collection)
        {
            try
            {
                _categoria.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
