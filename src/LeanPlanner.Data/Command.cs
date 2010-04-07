namespace LeanPlanner.Data
{
    public abstract class Command
    {
        private readonly IRepository _repository;

        protected Command(IRepository repository)
        {
            _repository = repository;
        }

        protected IRepository Repository
        {
            get { return _repository; }
        }

        public virtual void Execute()
        {
            try
            {
                DoWork();
                Repository.Commit();
            }
            catch
            {
                Repository.Rollback();
                throw;
            }
        }

        protected abstract void DoWork();
    }
}
