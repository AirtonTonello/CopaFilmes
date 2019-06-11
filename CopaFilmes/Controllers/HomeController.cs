using System.Web.Mvc;
using CopaFilmes.Repository;
using CopaFilmes.Models;

namespace CopaFilmes.Controllers
{
    public class HomeController : Controller
    {
        readonly IFilmeRepository filmeRepository;

        /// <summary>
        /// Construtor da Classe Home
        /// Instancia a Injeção de Dependencia do Repository Filme
        /// </summary>
        /// <param name="repository"></param>
        #region Construtor HomeController
        public HomeController(IFilmeRepository repository)
        {
            this.filmeRepository = repository;
        }
        #endregion

        /// <summary>
        /// ActionResult da View Index, retornando a lista de Filmes consumida pela API
        /// </summary>
        /// <returns></returns>
        #region Get: Index
        public ActionResult Index()
        {
            return View(filmeRepository.GetAll());
        }
        #endregion

        /// <summary>
        /// Retorna o resultado do campeonato em Formato Json
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #region Get: Json do Campeão
        public JsonResult GetCampeao(Filme model)
        {
            return Json(filmeRepository.GetCampeao(model), JsonRequestBehavior.AllowGet);
        }
        #endregion

        /// <summary>
        /// PartialView que retorna o cabeçalho da View que mostra o Campeão
        /// </summary>
        /// <returns></returns>
        #region Get: PartialView CampeaoHead
        public PartialViewResult _CampeaoHead()
        {
            return PartialView();
        }
        #endregion

        /// <summary>
        /// PartialView que retorna o corpo da View que mostra o Campeão
        /// </summary>
        /// <returns></returns>
        #region Get: PartialView CampeaoBody
        public PartialViewResult _CampeaoBody()
        {
            return PartialView();
        }
        #endregion

        /// <summary>
        /// PartialView que retorna o cabeçalho da View para seleção dos Filmes
        /// </summary>
        /// <returns></returns>
        #region Get: PartialView SelecaoHead
        public PartialViewResult _SelecaoHead()
        {
            return PartialView();
        }
        #endregion

        /// <summary>
        /// PartialView que retorna o corpo da View para seleção dos Filmes
        /// </summary>
        /// <returns></returns>
        #region Get: PartialView SelecaoBody
        public PartialViewResult _SelecaoBody()
        {
            return PartialView();
        }
        #endregion
    }
}