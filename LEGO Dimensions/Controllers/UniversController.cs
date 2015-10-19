using LEGO_Dimensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEGO_Dimensions.Controllers
{
    public class UniversController : Controller
    {
        //
        // GET: /Univers/

        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                IEnumerable<Univers> univers = dal.ObtientTousLesUnivers();
                return View(univers);
            }
        }

        public ActionResult Create()
        {
            Univers univers = new Univers();
            return View(univers);
        }

        [HttpPost]
        public ActionResult Create(Univers univers)
        {
            using (IDal dal = new Dal())
            {
                dal.CreerUnivers(univers.Nom);

                IEnumerable<Univers> lstUnivers = dal.ObtientTousLesUnivers();
                return View("Index", lstUnivers);
            }
        }

        public ActionResult Edit(int id)
        {
            using (IDal dal = new Dal())
            {
                Univers univers = dal.ObtientUnUnivers(id);
                return View("Edit", univers);
            }
        }

        [HttpPost]
        public ActionResult Edit(Univers pUnivers)
        {
            using (IDal dal = new Dal())
            {
                dal.ModifierUnivers(pUnivers.UniversId, pUnivers.Nom);

                IEnumerable<Univers> lstUnivers = dal.ObtientTousLesUnivers();
                return View("Index", lstUnivers);
            }
        }

        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal())
            {
                dal.SupprimerUnUnivers(id);
                List<Univers> univers = dal.ObtientTousLesUnivers();
                return View("Index", univers);
            }
        }
    }
}
