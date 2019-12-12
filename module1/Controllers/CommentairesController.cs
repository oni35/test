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
using System.Text;

namespace module1.Controllers
{
    public class CommentairesController : Controller
    {
        private ProjetDB db = new ProjetDB();

        // GET: Commentaires
        public async Task<ActionResult> Index()
        {
            return View(await db.Commentaires.ToListAsync());
        }

        // GET: Commentaires/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // GET: Commentaires/Create
        public ActionResult Create()
        { 
            ViewBag.Projet = db.Projets.ToList();
            
            return View();
        }

        // POST: Commentaires/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CommentaireId,Texte")] Commentaire commentaire, int? projetId)
        {
            if (ModelState.IsValid)
            {
                commentaire.Projet = db.Projets.Find(projetId);
                db.Commentaires.Add(commentaire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(commentaire);
        }

        // GET: Commentaires/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // POST: Commentaires/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CommentaireId,Texte")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentaire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(commentaire);
        }

        // GET: Commentaires/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // POST: Commentaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            db.Commentaires.Remove(commentaire);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetList()
        {
            return PartialView("~/Views/Shared/Comments/_CommentList.cshtml", new CommentViewModel() { Datas = db.Commentaires.ToList() });
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
