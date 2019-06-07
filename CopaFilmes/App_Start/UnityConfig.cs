using CopaFilmes.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CopaFilmes
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IFilmeRepository, FilmeRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}