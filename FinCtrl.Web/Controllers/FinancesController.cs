using FinCtrl.Domain.Entities;
using FinCtrl.Persistence;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FinCtrl.Web.Controllers
{
    public class FinancesController : Controller
    {
        private FinCtrlDbContext _ctx;

        // GET: Finances
        [HttpGet]
        public ActionResult Index()
        {
            _ctx = new FinCtrlDbContext();

            ViewBag.totalDespesas = _ctx.Financas.Where(x => x.Tipo.Id == 1).Select(x => x.Valor).Sum();
            ViewBag.totalRendimentos = _ctx.Financas.Where(x => x.Tipo.Id == 2).Select(x => x.Valor).Sum();

            ViewBag.months = _ctx.Financas.Select(x => x.Data.Month).Distinct();            

            var finances = _ctx.Financas.OrderBy(x => x.Data).ToList();

            return View(finances);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            _ctx = new FinCtrlDbContext();
            var financeDetail = _ctx.Financas.Find(id);

            return PartialView(financeDetail);
        }

        [HttpGet]
        public ActionResult Create()
        {
            _ctx = new FinCtrlDbContext();

            ViewBag.tipos = new SelectList(_ctx.Tipos.ToList(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Financas financa)
        {
            if (ModelState.IsValid)
            {
                _ctx = new FinCtrlDbContext();
                _ctx.Financas.Add(financa);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            _ctx = new FinCtrlDbContext();

            ViewBag.tipos = new SelectList(_ctx.Tipos.ToList(), "Id", "Nome");

            var finance = _ctx.Financas.Find(id);
            if (finance == null)
            {
                return HttpNotFound();
            }

            return View(finance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Financas financa)
        {
            _ctx = new FinCtrlDbContext();            

            if (ModelState.IsValid)
            {
                _ctx.Entry(financa).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }        

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _ctx = new FinCtrlDbContext();
            var financeToDelete = _ctx.Financas.Find(id);
            _ctx.Financas.Remove(financeToDelete);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}