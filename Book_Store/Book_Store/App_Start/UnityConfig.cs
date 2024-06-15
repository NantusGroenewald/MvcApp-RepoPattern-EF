using Book_Store.DAL;
using Book_Store.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Book_Store
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IRepository<Book>, Repository<Book>>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}