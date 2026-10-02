using FirstMonolithicProject.Models.DomainModels.ProductAggregates;

namespace FirstMonolithicProject.Models.Services.Contracts
{
    public interface IProductRepository
    {
        //Task Detail (Product product);

        #region [- Update() -]
        Task Update(Product product);

        #endregion    

        #region [- Delete() -]
        Task Delete(Product product);

        #endregion     

        #region [- Insert() -]
        Task Insert(Product product);
        #endregion

        #region [- SelectAll() -]
        Task<List<Product>> SelectAll();
        #endregion

        #region [- SelectById() -]
        Task<Product> SelectById(int Id);

        #endregion
    }
}
