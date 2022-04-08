namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Carts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CartsController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartsController(IOrdersService ordersService, UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

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
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
