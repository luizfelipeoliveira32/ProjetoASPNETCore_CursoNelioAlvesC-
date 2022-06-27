using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selllerService;

        public SellersController(SellerService selllerService)
        {
            _selllerService = selllerService;
        }

        public IActionResult Index()
        {
            var list = _selllerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _selllerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
