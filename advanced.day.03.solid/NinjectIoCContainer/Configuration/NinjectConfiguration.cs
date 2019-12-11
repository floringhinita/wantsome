namespace NinjectIoCContainer.Configuration
{
    using Contracts;
    using Ninject.Modules;

    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICourseData>().To<CourseData>();
        }
    }
}
