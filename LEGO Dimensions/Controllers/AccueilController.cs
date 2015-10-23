using LEGO_Dimensions.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEGO_Dimensions.Controllers
{
    public class AccueilController : Controller
    {
        //
        // GET: /Accueil/

        public ActionResult Index()
        {
            //IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            //Database.SetInitializer(init);
            //init.InitializeDatabase(new BddContext());
            return View();
        }

    }
}
