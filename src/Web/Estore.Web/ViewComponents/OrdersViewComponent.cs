namespace Estore.Web.ViewComponents
{
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents.Orders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersViewComponent : ViewComponent
    {
        private readonly IOrdersService cartsService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersViewComponent(IOrdersService cartsService, UserManager<ApplicationUser> userManager)
        {
            this.cartsService = cartsService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new OrdersDetailsViewModel();
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            if (user != null)
            {
                model.OrderedProducts = await this.cartsService.GetOrderedProductsAsync<OrderedProductViewModel>(user.Id);
            }

            return this.View(model);
        }
    }
}
