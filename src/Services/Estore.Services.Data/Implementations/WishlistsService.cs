namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class WishlistsService : IWishlistsService
    {
        private readonly ApplicationDbContext context;

        public WishlistsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetWishedProductsAsync<T>(string userId)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            var wishedProducts = await this.context.Wishlists
                .Where(w => w.UserId == user.Id)
                .To<T>()
                .ToListAsync();

            return wishedProducts;
        }

        public async Task<string> AddProductToWishlistAsync(string userId, string productId)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            var product = await this.context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            var wishlistProduct = await this.context.Wishlists
                .FirstOrDefaultAsync(wp => wp.ProductId == productId);

            if (wishlistProduct == null)
            {
                wishlistProduct = new Wishlist
                {
                    UserId = user.Id,
                    ProductId = product.Id,
                };
            }
            else
            {
                return $"You already have this product in your wishlist.";
            }

            await this.context.Wishlists.AddAsync(wishlistProduct);
            await this.context.SaveChangesAsync();

            return $"You have added {product.Name} into your wishlist.";
        }
    }
}
