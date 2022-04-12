namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
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

        public async Task<IEnumerable<T>> GetWishedProducts<T>(string userId)
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
    }
}
