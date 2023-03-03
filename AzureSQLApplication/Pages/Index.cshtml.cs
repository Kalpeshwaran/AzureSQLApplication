using AzureSQLApplication.Models;
using AzureSQLApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureSQLApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Products>? Products = null;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}