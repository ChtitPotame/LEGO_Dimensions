﻿using LEGO_Dimensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEGO_Dimensions.Controllers
{ 
    public class PersonnagesController : Controller
    {
        //
        // GET: /Personnages/

        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                IEnumerable<Personnage> personnages = dal.ObtientTousLesPersonnages();
                return View(personnages);
            }
        }

        public ActionResult Create()
        {
            Personnage personnage = new Personnage();
            return View(personnage);
        }

        [HttpPost]
        public ActionResult Create(Personnage personnage)
        {
            using (IDal dal = new Dal())
            {
                if (ModelState.IsValid)
                {
                    personnage.Pouvoirs = new List<Pouvoir>();
                    if (personnage.PouvoirsId != null)
                        foreach (int pouvoirId in personnage.PouvoirsId)
                            personnage.Pouvoirs.Add(dal.ObtientUnPouvoir(pouvoirId));

                    dal.CreerPersonnage(personnage);
                    List<Personnage> personnages = dal.ObtientTousLesPersonnages();
                    return View("Index", personnages);
                }
                else
                {
                    return View(personnage);
                }
            }
        }

        public ActionResult Edit(int id)
        {
            using (IDal dal = new Dal())
            {
                Personnage personnage = dal.ObtientUnPersonnage(id);
                personnage.PouvoirsId = new List<int>();
                foreach (Pouvoir pouvoir in personnage.Pouvoirs)
                    personnage.PouvoirsId.Add(pouvoir.PouvoirId);
                return View("Edit", personnage);
            }
        }

        [HttpPost]
        public ActionResult Edit(Personnage personnage)
        {
            using (IDal dal = new Dal())
            {
                if (ModelState.IsValid)
                {
                    personnage.Pouvoirs = new List<Pouvoir>();
                    if (personnage.PouvoirsId != null)
                        foreach (int pouvoirId in personnage.PouvoirsId)
                            personnage.Pouvoirs.Add(dal.ObtientUnPouvoir(pouvoirId));

                    dal.ModifierPersonnage(personnage.PersonnageId, personnage.Nom, personnage.UniversId, personnage.Pouvoirs);
                    List<Personnage> personnages = dal.ObtientTousLesPersonnages();
                    return View("Index", personnages);
                }
                else
                {
                    return View(personnage);
                }
            }
        }

        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal())
            {
                dal.SupprimerUnPersonnage(id);
                List<Personnage> personnages = dal.ObtientTousLesPersonnages();
                return View("Index", personnages);
            }
        }

    }
}
