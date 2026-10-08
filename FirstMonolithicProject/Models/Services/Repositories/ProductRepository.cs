using FirstMonolithicProject.Models.DomainModels.ProductAggregates;
using FirstMonolithicProject.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FirstMonolithicProject.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _projectDbContext;
        #region [- ctor -]
        public ProductRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        #endregion

        #region [- Update() -]
        public async Task Update(Product product)
        {
            try
            {
                _projectDbContext.Update(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;
            }
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(Product product)
        {
            try
            {
                _projectDbContext.Remove(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;
            }
        }
        #endregion

        #region [- Insert() -]
        public async Task Insert(Product product)
        {
            try
            {
                _projectDbContext.Add(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;
            }
        }
        #endregion

        #region [- SelectAll() -]
        public async Task<List<Product>> SelectAll()
        {
            try
            {
                return await _projectDbContext.Product.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region [- SelectById() -]
        public async Task<Product> SelectById(int Id)
        {
            try
            {
                return await _projectDbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception )
            {
                throw;
            }
        }  
        #endregion

    }
}
