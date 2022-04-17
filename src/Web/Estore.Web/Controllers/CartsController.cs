namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Carts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CartsController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartsController(
            IOrdersService ordersService,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var model = new CartDetailsViewModel
                {
                    OrderedProducts = await this.ordersService.GetOrderedProductsAsync<CartProductViewModel>(user.Id),
                };

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CartProductInputModel model)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var result = await this.ordersService.AddProductInOrdersAsync(user.Id, model.ProductId, model.Quantity);
                this.TempData["Message"] = result;

                return this.Redirect("/Products/Details/" + model.ProductId);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.ordersService.DeleteProductFromOrdersAsync(id);

                return this.RedirectToAction("Details");
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }
    }
}
