namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Wishlists;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
                    WishProducts = await this.wishlistsService.GetWishedProducts<WishlistProductViewModel>(user.Id),
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
