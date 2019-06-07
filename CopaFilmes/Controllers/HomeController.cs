using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using CopaFilmes.Repository;
using CopaFilmes.Models;

namespace CopaFilmes.Controllers
{
    public class HomeController : Controller
    {
        readonly IFilmeRepository filmeRepository;

        public HomeController(IFilmeRepository repository)
        {
            this.filmeRepository = repository;
        }

        public ActionResult Index()
        {
            return View(filmeRepository.GetAll());
        }

        public JsonResult GetCampeao(Filme model)
        {
            return Json(filmeRepository.GetCampeao(model), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _CampeaoHead()
        {
            return PartialView();
        }

        public PartialViewResult _CampeaoBody()
        {
            return PartialView();
        }

        public PartialViewResult _SelecaoHead()
        {
            return PartialView();
        }

        public PartialViewResult _SelecaoBody()
        {
            return PartialView();
        }
    }
}