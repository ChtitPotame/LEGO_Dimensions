using LEGO_Dimensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEGO_Dimensions.Controllers
{
    public class AccessoiresController : Controller
    {
        //
        // GET: /Personnages/

        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                IEnumerable<Accessoire> accessoires = dal.ObtientTousLesAccessoires();
                return View(accessoires);
            }
        }

        public ActionResult Create()
        {
            Accessoire accessoire = new Accessoire();
            return View(accessoire);
        }

        [HttpPost]
        public ActionResult Create(Accessoire accessoire)
        {
            using (IDal dal = new Dal())
            {
                if (ModelState.IsValid)
                {
                    accessoire.Pouvoirs = new List<Pouvoir>();
                    if (accessoire.PouvoirsId != null)
                        foreach (int pouvoirId in accessoire.PouvoirsId)
                            accessoire.Pouvoirs.Add(dal.ObtientUnPouvoir(pouvoirId));

                    dal.CreerAccessoire(accessoire);
                    List<Accessoire> accessoires = dal.ObtientTousLesAccessoires();
                    return View("Index", accessoires);
                }
                else
                {
                    return View(accessoire);
                }
            }
        }

        public ActionResult Edit(int id)
        {
            using (IDal dal = new Dal())
            {
                Accessoire accessoire = dal.ObtientUnAccessoire(id);

                accessoire.PouvoirsId = new List<int>();
                foreach (Pouvoir pouvoir in accessoire.Pouvoirs)
                    accessoire.PouvoirsId.Add(pouvoir.PouvoirId);

                return View("Edit", accessoire);
            }
        }

        [HttpPost]
        public ActionResult Edit(Accessoire accessoire)
        {
            using (IDal dal = new Dal())
            {
                if (ModelState.IsValid)
                {
                    accessoire.Pouvoirs = new List<Pouvoir>();
                    if (accessoire.PouvoirsId != null)
                        foreach (int pouvoirId in accessoire.PouvoirsId)
                            accessoire.Pouvoirs.Add(dal.ObtientUnPouvoir(pouvoirId));

                    dal.ModifierAccessoire(accessoire.AccessoireId, accessoire.Nom, accessoire.PersonnageId, accessoire.Pouvoirs);
                    List<Accessoire> accessoires = dal.ObtientTousLesAccessoires();
                    return View("Index", accessoires);
                }
                else
                {
                    return View(accessoire);
                }
            }
        }

        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal())
            {
                dal.SupprimerUnAccessoire(id);
                List<Accessoire> accessoires = dal.ObtientTousLesAccessoires();
                return View("Index", accessoires);
            }
        }

    }
}
