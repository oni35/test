using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace module1.Controllers
{
    public class EmployesController : Controller
    {
        private ProjetDB db = new ProjetDB();

        // GET: Employes
        [HttpGet]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Employes.ToListAsync());
        }

        // GET: Employes/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = await db.Employes.FindAsync(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: Employes/Create
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.Projet = db.Projets.ToList();
            return View();
        }

        // POST: Employes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeId,Nom,Prenom")] Employe employe, int[] projetsIds)
        {
            if (ModelState.IsValid)
            {
                if (projetsIds != null)
                {
                    foreach (var id in projetsIds)
                    {
                        employe.Projets.Add(db.Projets.Find(id));
                    }
                }

                db.Employes.Add(employe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        // GET: Employes/Edit/5
        [Route("Edit")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = await db.Employes.FindAsync(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeId,Nom,Prenom")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: Employes/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = await db.Employes.FindAsync(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employe employe = await db.Employes.FindAsync(id);
            db.Employes.Remove(employe);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetList()
        {
            return PartialView("~/Views/Shared/Employees/_EmployeeList.cshtml", db.Employes.ToList());
        }

        [ChildActionOnly]
        public ActionResult GetListByTitle(int projetId)
        {
            return PartialView("~/Views/Shared/Employees/_EmployeeList.cshtml",
                db.Projets.Include(x => x.Employes).First(p => p.ProjetId == projetId).Employes);
        }

        public async Task<ActionResult> ListEmployes(string projetRef)
        {
            return View("Index", (await db.Projets.Include(x => x.Employes).FirstAsync(x => x.Intitule.Equals(projetRef))).Employes);
        }

        public ActionResult RechercheEmploye(string nom)
        {
            ActionResult result = null;
            List<Employe> employes = db.Employes.Where(x => x.Nom.Equals(nom)).ToList();
            if (employes.Count == 1)
            {
                result = View("Details", employes.ElementAt(0));
            }
            else
            {
                if (employes.Count == 0)
                {
                    employes = db.Employes.Where(x => x.Nom.Contains(nom)).ToList();
                }
                result = View("Listing", employes);
            }
            
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
