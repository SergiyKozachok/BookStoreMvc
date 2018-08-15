using System.Reflection;
using System.Runtime.InteropServices;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Logic.Services;
using Logic.Services.Interface;

namespace WebApi
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AuthorsService>().As<IAuthorsService>().InstancePerRequest();
            builder.RegisterType<BooksService>().As<IBooksService>().InstancePerRequest();
            builder.RegisterType<PageService>().As<IPageService>().InstancePerRequest();
            builder.RegisterType<SidebarService>().As<ISidebarService>().InstancePerRequest();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
        

    }
}