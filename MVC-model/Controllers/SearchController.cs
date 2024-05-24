using Entity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
{
    public class SearchController : Controller
    {
        private IProductService _productService;
        public SearchController (IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var model = _productService.GetAll().Select(product => new SearchViewModel
            {
                productID = product.productID,
                productName = product.productName,
                brand = product.brand,
                price = product.price,
                category = product.category,
                imgURL = product.imgURL,
                discountPercentage = product.discountPercentage,
            });
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.productName.Contains(searchString)
                                       || s.productName.Contains(searchString));
            }
            model = model.OrderByDescending(s => s.productID);
            int pageSize = 8;
            return View(PaginatedList<SearchViewModel>.CreateAsync(model.AsQueryable(), pageNumber ?? 1, pageSize));
        }
    }
}
