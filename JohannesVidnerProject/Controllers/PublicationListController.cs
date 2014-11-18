using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Publication = JohannesVidnerProject.Models.Publication;

namespace JohannesVidnerProject.Controllers
{
    public class PublicationListController : Controller
    {
        // GET: PublicationList
        public ActionResult Details(Publication p)
        {
            return View(p.CurrentEdition());
        }
    }
}