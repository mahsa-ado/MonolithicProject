
using FirstMonolithicProject.ApplicationServices.Dtos.ProductDtos;
using FirstMonolithicProject.ApplicationServices.Services.Contracts;
using FirstMonolithicProject.Models;
using FirstMonolithicProject.Models.DomainModels.ProductAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    private readonly IProductApplicationService _productApplicationService;
    #region [- ctor -]
    public ProductController(IProductApplicationService productApplicationService)
    {
        _productApplicationService = productApplicationService;
    }
    #endregion

    #region [- Detail() -]
    [HttpGet]
    public async Task<IActionResult> Detail(int Id)
    {
        var product = await _productApplicationService.GetById(Id);
        if (product == null)
        {
            return NotFound();
        }
        var detailDto = new DetailProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price,
            Description = product.Description,

        };
        return View(detailDto);
    } 
    #endregion

    #region [- Edit() -]
    #region [-Get-]
    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        var product =await _productApplicationService.GetById(Id);
        if(product==null)
        {
            return NotFound();
        }
        var updateDto = new UpdateProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price,
            Description = product.Description
        };
        

        return View(updateDto);
    }
    #endregion
    #region [-Post-]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateProductDto updateProductDto)
    {
        if (ModelState.IsValid)
        {
            await _productApplicationService.Put(updateProductDto);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(updateProductDto);
        }
    }
    #endregion
    #endregion

    #region [- Delete() -]
    #region [-Get-]
    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        var product=await _productApplicationService.GetById(Id);
        if( product==null)
        {
            return NotFound();
        }

        var deleteDto = new DeleteProductDto
        {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
        };
        
        return View(deleteDto);

    }
    #endregion

    #region [- Post -]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
    {
        if (ModelState.IsValid)
        {
            await _productApplicationService.Delete(deleteProductDto);

            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(deleteProductDto);
        }
    }
    #endregion
    #endregion

    #region [- Create() -]
    #region [-Get-]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    #endregion
    #region [-Post-]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostProductDto postProductDto)
    {
        if (ModelState.IsValid)
        {
            await _productApplicationService.Post(postProductDto);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(postProductDto);
        }
    }
    #endregion
    #endregion

    #region [- Index() -]
    public async Task<IActionResult> Index()
    {
        var result = await _productApplicationService.GetAllProducts();
        return View(result);
    }
    #endregion

}
