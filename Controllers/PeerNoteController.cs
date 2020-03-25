using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team_16_Centric_Project.Controllers
{
    public class PeerNoteController : Controller
    {
        // GET: PeerNote
        public ActionResult Index()
        {
            ViewBag.ItemList = "Recognize a Peer for Their Centric Values";
            return View();
        }
    }
}