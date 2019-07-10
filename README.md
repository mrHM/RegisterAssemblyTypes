# RegisterAssemblyTypes

#Simple helper method to register Services and Repository based on assembly instead on adding each and every class one by one

#Uses

#add reference to the project

#use  Builder.RegisterAssemblyTypes(services, typeof(UserService).Assembly, "Service", ServiceLifetime.Scoped) inside ConfigureServices method of Startup class

e.g
 public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Builder.RegisterAssemblyTypes(services, typeof(UserService).Assembly, "Service", ServiceLifetime.Scoped);
            Builder.RegisterAssemblyTypes(services, typeof(UserRepository).Assembly, "Repository", ServiceLifetime.Scoped);
