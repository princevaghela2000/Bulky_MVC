using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        /*
         * In this unit of work we create one method for save and we implement all the repository here so we can get the implementation of all the repository in this unit of work.
         * Advantage of unit of work is we can get all the repository implementation at once
         * and we do not have to write all the dependency in controller that we need we just have to call unit of work repo using dependecny injection.
         * 
         * Disadvantage is that in some controller we only need some repository but now all repository and in that case we call unit of work pattern then it will load all the repository using dependency injection at once and give all implementations to us.
        */
        private ApplicationDbContext _dbContext;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Category = new CategoryRepository(dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
