using FirstMonolithicProject.ApplicationServices.Dtos.ProductDtos;

namespace FirstMonolithicProject.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
    {
        #region [- Put() -]
        Task Put(UpdateProductDto updateProductDto);

        #endregion

        #region [- Delete() -]
        Task Delete(DeleteProductDto deleteProductDto);

        #endregion

        #region [- Post() -]
        Task Post(PostProductDto postProductDto);

        #endregion

        #region [- GetAllProducts() -]
        Task<List<GetProductDto>> GetAllProducts();

        #endregion    

        Task<GetProductDtoById> GetById(int id);
    }
}
