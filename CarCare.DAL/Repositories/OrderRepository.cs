using CarCare.DAL;
using CarCare.Domain.Entities;
using CarCare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; // Added for Include
using System.Threading.Tasks;

namespace CarCare.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                                 .Include(o => o.Items) // Include order items
                                 .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders
                                 .Include(o => o.Items) // Include order items
                                 .FirstOrDefaultAsync(o => o.Id == id); // Use FirstOrDefaultAsync for Include
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                // Update OrderItems if they are part of the order object and marked for update
                // This requires careful handling of child entities (add, update, delete)
                foreach (var item in order.Items)
                {
                    if (item.Id == Guid.Empty) // New item
                    {
                        _context.Entry(item).State = EntityState.Added;
                    }
                    else // Existing item, check if modified or deleted
                    {
                        _context.Entry(item).State = EntityState.Modified;
                    }
                }
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        // OrderItem specific methods
        public async Task<OrderItem?> GetOrderItemByIdAsync(Guid id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<bool> UpdateOrderItemAsync(OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderItemAsync(Guid id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return false;
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
