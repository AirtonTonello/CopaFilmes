using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopaFilmes.Controllers;
using CopaFilmes.Repository;
using CopaFilmes.Models;

namespace CopaFilmes.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// O teste verifica se index não é retornada nula e se retorno é uma ViewResult
        /// </summary>
        #region IndexTest()
        [TestMethod]
        public void IndexTest()
        {
            IFilmeRepository repository = new FilmeRepository();

            HomeController controller = new HomeController(repository);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result);
        }
        #endregion

        /// <summary>
        /// O teste verifica se o retorno da API não é nulo e se o retorna é um IEnumerable
        /// </summary>
        #region GetAllTest()
        [TestMethod]
        public void GetAllTest()
        {
            FilmeRepository repository = new FilmeRepository();

            var data = repository.GetAll();

            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(IEnumerable<Filme>));
        }
        #endregion

        /// <summary>
        /// O teste verifica se o retorno do vencedor não é nulo e se o retorno é uma classe Filme
        /// </summary>
        #region GetCampeaoTest()
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
            Assert.IsInstanceOfType(result, typeof(Filme));
        }
        #endregion
    }
}
