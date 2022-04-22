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

    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext context;

        public OrdersService(ApplicationDbContext context)
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

            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == productId);

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
                var productDiscount = product.Discount / 100;

                if (newOrder.Quantity >= product.ItemApplyDiscount && product.ItemApplyDiscount != 0)
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
                var productDiscount = orderedProduct.Product.Discount / 100;

                orderedProduct.Quantity += quantity;

                if (orderedProduct.IsDiscountGiven != false && product.ItemApplyDiscount != 0)
                {
                    var currentOrderCalculationTotalPerProduct = productPrice * quantity;
                    orderedProduct.TotalPerProduct += currentOrderCalculationTotalPerProduct;
                }
                else if (orderedProduct.Quantity >= product.ItemApplyDiscount && product.ItemApplyDiscount != 0)
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

        public async Task DeleteProductFromOrdersAsync(string productId)
        {
            var orderedProduct = await this.context.Orders
                .FirstOrDefaultAsync(o => o.ProductId == productId);

            if (orderedProduct == null)
            {
                throw new NullReferenceException();
            }

            this.context.Orders
                .Remove(orderedProduct);

            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetOrderedProductsAsync<T>(string userId)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            var orderedProducts = await this.context.Orders
                .Where(o => o.CartId == user.CartId)
                .OrderByDescending(o => o.CreatedOn)
                .To<T>()
                .ToListAsync();

            return orderedProducts;
        }

        public async Task Checkout(string userId)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            var userOrders = await this.context.Orders
                .Where(o => o.CartId == user.Cart.Id)
                .ToListAsync();

            this.context.Orders.RemoveRange(userOrders);
            await this.context.SaveChangesAsync();
        }
    }
}
