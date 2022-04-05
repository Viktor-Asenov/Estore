namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class CartsService : ICartsService
    {
        private readonly ApplicationDbContext context;

        public CartsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddProductInOrdersAsync(string userId, string productId, int quantity)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            var product = await this.CheckIfProductExistAsync(productId);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            if (!this.context.Orders
                .Any(o => o.ProductId == productId
                && o.CartId == user.CartId))
            {
                var newOrder = new Order
                {
                    CartId = user.CartId,
                    ProductId = product.Id,
                    Quantity = quantity,
                    TotalPerProduct = product.Price * quantity,
                };

                var productPrice = product.Price;
                var productDiscount = product.Discount;

                if (newOrder.Quantity >= product.ItemApplyDiscount)
                {
                    var calculatedDiscount = productPrice * productDiscount;
                    newOrder.TotalPerProduct -= calculatedDiscount ?? newOrder.TotalPerProduct;

                    newOrder.IsDiscountGiven = true;
                }

                await this.context.Orders.AddAsync(newOrder);
            }
            else
            {
                var orderedProduct = await this.context.Orders
                    .FirstOrDefaultAsync(o => o.ProductId == productId
                        && o.CartId == user.CartId);

                var productPrice = orderedProduct.Product.Price;
                var productDiscount = orderedProduct.Product.Discount;

                orderedProduct.Quantity += quantity;

                if (orderedProduct.IsDiscountGiven != false)
                {
                    var currentOrderCalculationTotalPerProduct = productPrice * quantity;
                    orderedProduct.TotalPerProduct += currentOrderCalculationTotalPerProduct;
                }
                else if (orderedProduct.Quantity >= product.ItemApplyDiscount)
                {
                    orderedProduct.TotalPerProduct = productPrice * orderedProduct.Quantity;
                    var calculatedDiscount = productPrice * productDiscount;
                    orderedProduct.TotalPerProduct -= calculatedDiscount ?? orderedProduct.TotalPerProduct;

                    orderedProduct.IsDiscountGiven = true;
                }
                else
                {
                    orderedProduct.TotalPerProduct = productPrice * orderedProduct.Quantity;
                }
            }

            await this.context.SaveChangesAsync();

            var message = $"You have successfully added {product.Name}.";

            return message;
        }

        public async Task<Product> CheckIfProductExistAsync(string id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product;
        }
    }
}
