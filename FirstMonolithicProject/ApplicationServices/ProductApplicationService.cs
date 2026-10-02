using FirstMonolithicProject.ApplicationServices.Dtos.ProductDtos;
using FirstMonolithicProject.ApplicationServices.Services.Contracts;
using FirstMonolithicProject.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstMonolithicProject.ApplicationServices
{
    public class ProductApplicationService:IProductApplicationService
    {
        private readonly IProductRepository _productRepository;
        #region [-ctor-]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region [- Put() -]
        public async Task Put(UpdateProductDto updateProductDto)
        {
            var products = new Models.DomainModels.ProductAggregates.Product()
            {
                Id=updateProductDto.Id,
                Title = updateProductDto.Title,
                Price = updateProductDto.Price,
                Description = updateProductDto.Description,
            };
            await _productRepository.Update(products);
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(DeleteProductDto deleteProductDto)
        {
            var deleteProducts = new Models.DomainModels.ProductAggregates.Product()
            {
                Id=deleteProductDto.Id,
                Title = deleteProductDto.Title,
                Price = deleteProductDto.Price,
                Description = deleteProductDto.Description,
            };
            await _productRepository.Delete(deleteProducts);
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostProductDto postProductDto)
        {
            var products = new Models.DomainModels.ProductAggregates.Product()
            {
                Title = postProductDto.Title,
                Price = postProductDto.Price,
                Description = postProductDto.Description,
            };
            await _productRepository.Insert(products);
        }

        #endregion

        #region [- GetAll() -]
        public async Task<List<GetProductDto>> GetAllProducts()
        {
            var products = await _productRepository.SelectAll();
            var getProductDto = new List<GetProductDto>();
            foreach (var product in products)
            {
                var productDto = new GetProductDto()
                {
                    Id= product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    Description = product.Description,
                };
                getProductDto.Add(productDto);
            }
            return getProductDto;
        }


        #endregion

        #region [- GetById() -]
        public async Task<GetProductDtoById> GetById(int Id)
        {
            var product = await _productRepository.SelectById(Id);
            if (product == null)
            {
                return null;
            }
            var getById = new GetProductDtoById()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
            };

            return getById;
        }

        #endregion



    }
}
