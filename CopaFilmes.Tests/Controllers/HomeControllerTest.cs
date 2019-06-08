using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopaFilmes;
using CopaFilmes.Controllers;
using CopaFilmes.Repository;
using CopaFilmes.Models;

namespace CopaFilmes.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            IFilmeRepository repository = new FilmeRepository();

            HomeController controller = new HomeController(repository);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllTest()
        {
            FilmeRepository repository = new FilmeRepository();

            var data = repository.GetAll();

            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void GetCampeaoTest()
        {
            Filme f = new Filme();
            FilmeRepository repository = new FilmeRepository();

            f.FilmesSelecionados = new List<string>();
            f.FilmesSelecionados.Add("Filme 1-8,1");
            f.FilmesSelecionados.Add("Filme 2-7,1");
            f.FilmesSelecionados.Add("Filme 3-6,1");
            f.FilmesSelecionados.Add("Filme 4-5,1");
            f.FilmesSelecionados.Add("Filme 5-5,1");
            f.FilmesSelecionados.Add("Filme 6-4,1");
            f.FilmesSelecionados.Add("Filme 7-3,1");
            f.FilmesSelecionados.Add("Filme 8-2,1");

            var result = repository.GetCampeao(f);

            Assert.IsNotNull(result.Campeao);
        }
    }
}
