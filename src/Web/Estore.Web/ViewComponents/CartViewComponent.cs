namespace Estore.Web.ViewComponents
{
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents.Cart;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsService cartsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartViewComponent(ICartsService cartsService, UserManager<ApplicationUser> userManager)
        {
            this.cartsService = cartsService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var model = new OrdersDetailsViewModel()
            {
                OrderedProducts = await this.cartsService.GetOrderedProductsAsync<OrderedProductViewModel>(user.Id),
                TotalAmount = await this.cartsService.GetTotalAmount(user.Id),
            };

            return this.View(model);
        }
    }
}
