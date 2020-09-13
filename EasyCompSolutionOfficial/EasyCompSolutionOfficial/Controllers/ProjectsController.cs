using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyCompSolutionOfficial.Models;


namespace EasyCompSolutionOfficial.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            YoutubeLinksLayer layers = new YoutubeLinksLayer();

            List<YoutubeLink> list = layers.GetAllLinks();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            YoutubeLinksLayer layers = new YoutubeLinksLayer();
            YoutubeLink ll = new YoutubeLink();

            ll.Link = formCollection["Link"];
            ll.Title = formCollection["Title"];

            bool v = layers.AddNewLink(ll);
            RedirectToAction("Index",);
            return View();
        }
    }
}
