using LEGO_Dimensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEGO_Dimensions.Controllers
{
    public class PouvoirsController : Controller
    {
        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                IEnumerable<Pouvoir> pouvoirs = dal.ObtientTousLesPouvoirs();
                return View(pouvoirs);
            }
        }

        public ActionResult Create()
        {
            Pouvoir pouvoir = new Pouvoir();
            return View(pouvoir);
        }

        [HttpPost]
        public ActionResult Create(Pouvoir pouvoir)
        {
            using (IDal dal = new Dal())
            {
                if (ModelState.IsValid)
                {
                    dal.CreerPouvoir(pouvoir);
                    List<Pouvoir> pouvoirs = dal.ObtientTousLesPouvoirs();
                    return View("Index", pouvoirs);
                }
                else
                {
                    return View(pouvoir);
                }
            }
        }

        public ActionResult Edit(int id)
        {
            using (IDal dal = new Dal())
            {
                Pouvoir pouvoir = dal.ObtientUnPouvoir(id);
                return View("Edit", pouvoir);
            }
        }

        [HttpPost]
        public ActionResult Edit(Pouvoir pouvoir)
        {
            using (IDal dal = new Dal())
            {
                if (ModelState.IsValid)
                {
                    dal.ModifierPouvoir(pouvoir.PouvoirId, pouvoir.Nom);
                    List<Pouvoir> pouvoirs = dal.ObtientTousLesPouvoirs();
                    return View("Index", pouvoirs);
                }
                else
                {
                    return View(pouvoir);
                }
            }
        }
        
        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal())
            {
                dal.SupprimerUnPouvoir(id);
                List<Pouvoir> pouvoirs = dal.ObtientTousLesPouvoirs();
                return View("Index", pouvoirs);
            }
        }
    }
}
