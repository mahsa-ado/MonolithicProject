using FirstMonolithicProject.ApplicationServices.Dtos.ProductDtos;
using FirstMonolithicProject.ApplicationServices.Services.Contracts;
using FirstMonolithicProject.Models.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if(updateProductDto == null)
            {
                return;
            }
            var updateProduct = new Models.DomainModels.ProductAggregates.Product()
            {
                Id=updateProductDto.Id,
                Title = updateProductDto.Title,
                Price = updateProductDto.Price,
                Description = updateProductDto.Description,
            };
            
            await _productRepository.Update(updateProduct);
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(DeleteProductDto deleteProductDto)
        {
            if(deleteProductDto== null)
            {
                return;
            }
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
            if(postProductDto == null)
            {
                return;
            }
            var products = new Models.DomainModels.ProductAggregates.Product()
            {
                Id= postProductDto.Id,
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
            var getDto = new List<GetProductDto>();
            foreach (var product in products)
            {
                var productDto = new GetProductDto()
                {
                    Id= product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    Description = product.Description,
                };
                getDto.Add(productDto);
            }
            return getDto;
        }


        #endregion

        #region [- GetById() -]
        public async Task<GetProductDtoById?> GetById(int Id)
        {
            
            var product = await _productRepository.SelectById(Id);
            if (product == null)
            {
                return null;
            }
            var getProduct = new GetProductDtoById()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
            };

            return getProduct;
        }

        #endregion



    }
}
