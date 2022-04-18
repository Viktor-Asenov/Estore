namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Wishlists;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class WishlistsController : BaseController
    {
        private readonly IWishlistsService wishlistsService;
        private readonly UserManager<ApplicationUser> userManager;

        public WishlistsController(
            IWishlistsService wishlistsService,
            UserManager<ApplicationUser> userManager)
        {
            this.wishlistsService = wishlistsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var model = new WishlistViewModel
                {
                    WishProducts = await this.wishlistsService.GetWishedProductsAsync<WishlistProductViewModel>(user.Id),
                };

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(string productId)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var result = await this.wishlistsService.AddProductToWishlistAsync(user.Id, productId);
                this.TempData["Message"] = result;

                return this.Redirect("/Products/Details/" + productId);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string productId)
        {
            try
            {
                await this.wishlistsService.DeleteProductFromOrdersAsync(productId);

                return this.RedirectToAction("Details");
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }
    }
}
