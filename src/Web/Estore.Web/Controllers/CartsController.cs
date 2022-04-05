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

    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : BaseController
    {
        private readonly ICartsService cartsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartsController(ICartsService cartsService, UserManager<ApplicationUser> userManager)
        {
            this.cartsService = cartsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<AddProductInOrdersModel>> Add(AddProductInOrdersModel product)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var result = await this.cartsService.AddProductInOrdersAsync(user.Id, product.ProductId, product.Quantity);

                this.TempData["Message"] = result;

                return product;
            }
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
