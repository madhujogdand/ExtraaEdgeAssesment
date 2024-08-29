using ExtraaEdgeAssesment.Data;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExtraaEdgeAssesment.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext db)
        {
            this._context = db;
        }
        public int AddOrder(Orders orders)
        {
            int result = 0;
            _context.Orders.Add(orders);
            result = _context.SaveChanges();
            return result;
        }

        public int DeleteOrder(int id)
        {
            int result = 0;
            var model = _context.Orders.SingleOrDefault(x => x.OrderID == id);
            if (model != null)
            {
                _context.Orders.Remove(model);
                result = _context.SaveChanges();
            }
            return result;
        }

        public Orders GetOrderById(int id)
        {
            var model = _context.Orders.Where(x => x.OrderID == id).SingleOrDefault();
            return model;
        }

        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public int UpdateOrder(Orders orders)
        {
            int result = 0;
            var model = _context.Orders.Where(x => x.OrderID == orders.OrderID).SingleOrDefault();
            if (model != null)
            {
                model.OrderDate = orders.OrderDate;
                model.CustomerName = orders.CustomerName;
                model.TotalAmount = orders.TotalAmount;
                model.PaymentMethod = orders.PaymentMethod;
                result = _context.SaveChanges();
            }
            return result;
        }


        public void BulkInsertOrders(List<Orders> orders)
        {
            var model = orders.Select(m => new Orders
            {
                OrderDate = m.OrderDate,
                CustomerName = m.CustomerName,
                TotalAmount = m.TotalAmount,
                PaymentMethod = m.PaymentMethod
            }).ToList();

            _context.Orders.AddRange(model);
            _context.SaveChanges();
        }

        public void BulkUpdateOrders(List<Orders> orders)
        {
            var orderFields = _context.Orders
     .Where(m => orders.Select(n => n.OrderID).Contains(m.OrderID))
     .ToList();

            foreach (var order in orders)
            {
                var existingOrder = orderFields.FirstOrDefault(m => m.OrderID == order.OrderID);
                if (existingOrder != null)
                {
                    existingOrder.OrderDate = order.OrderDate;
                    existingOrder.CustomerName = order.CustomerName;
                    existingOrder.TotalAmount = order.TotalAmount;
                    existingOrder.PaymentMethod = order.PaymentMethod;
                }
            }

            _context.SaveChanges();
        }

    }
}
