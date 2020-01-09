namespace DependencyInversionWorkerAfter
{
    public class Manager
    {
        protected IWorker worker;

        public Manager(IWorker worker)
        {
            this.worker = worker;
        }

        public void Manage()
        {
            this.worker.Work();
        }
    }
}
