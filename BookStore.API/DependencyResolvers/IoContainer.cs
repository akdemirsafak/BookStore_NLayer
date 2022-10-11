using System.Reflection;
using Autofac;
using BookStore.Core.RepositoryCore;
using BookStore.Core.ServiceCore;
using BookStore.Core.UnitOfWorkCore;
using BookStore.Repository;
using BookStore.Repository.Repositories;
using BookStore.Repository.UnitOfWork;
using BookStore.Service.Mapping;
using BookStore.Service.Services;
using Module = Autofac.Module;

namespace BookStore.API.DependencyResolvers;

public class IoContainer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        //Tip güvenli
        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssembly = Assembly.GetAssembly(typeof(BookStoreDBContext));
        var serviceAssembly = Assembly.GetAssembly(typeof(MyMapper));


        //Tüm service ve respositoryleri tek tek belirtmek yerine service veya repository ile bitenleri inject etmesini istedik.
        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}