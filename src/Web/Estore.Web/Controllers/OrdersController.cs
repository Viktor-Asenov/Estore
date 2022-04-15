namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(
            IOrdersService ordersService,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add(AddProductInOrdersModel product)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var result = await this.ordersService.AddProductInOrdersAsync(user.Id, product.ProductId, product.Quantity);

                return result;
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string productId)
        {
            try
            {
                var productIdNormalized = productId.Replace("item_", string.Empty);

                await this.ordersService.DeleteProductFromOrdersAsync(productIdNormalized);

                return this.Ok();
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }
    }
}
