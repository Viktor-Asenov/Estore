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

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService cartsService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(IOrdersService cartsService, UserManager<ApplicationUser> userManager)
        {
            this.cartsService = cartsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<string>> Add(AddProductInOrdersModel product)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var result = await this.cartsService.AddProductInOrdersAsync(user.Id, product.ProductId, product.Quantity);

                return result;
            }
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Delete(string productId)
        {
            try
            {
                await this.cartsService.DeleteProductFromOrdersAsync(productId);

                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        //[HttpGet]
        //public async Task<ActionResult<OrdersDetailsViewModel>> Info()
        //{
        //    var model = new OrdersDetailsViewModel();
        //    var user = await this.userManager.GetUserAsync(this.User);

        //    if (user != null)
        //    {
        //        model.OrderedProducts = await this.cartsService.GetOrderedProductsAsync<OrderedProductViewModel>(user.Id);
        //    }

        //    return model;
        //}
    }
}
