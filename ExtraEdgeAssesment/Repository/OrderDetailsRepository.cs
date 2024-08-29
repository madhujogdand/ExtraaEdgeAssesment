using ExtraaEdgeAssesment.Data;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Repository.Interfaces;

namespace ExtraaEdgeAssesment.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailsRepository(ApplicationDbContext db)
        {
            this._context = db;
        }
        public int AddOrderDetails(OrderDetails orderDetails)
        {
            int result = 0;
            _context.OrderDetails.Add(orderDetails);
            result = _context.SaveChanges();
            return result;
        }

        public int DeleteOrderDetails(int id)
        {
            int result = 0;
            var model = _context.OrderDetails.SingleOrDefault(x => x.OrderDetailID == id);
            if (model != null)
            {
                _context.OrderDetails.Remove(model);
                result = _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            var model = _context.OrderDetails.Where(x => x.OrderDetailID == id).SingleOrDefault();
            return model;
        }

        public int UpdateOrderDetails(OrderDetails orderDetails)
        {
            int result = 0;
            var model = _context.OrderDetails.Where(x => x.OrderDetailID == orderDetails.OrderDetailID).SingleOrDefault();
            if (model != null)
            {
                model.OrderID = orderDetails.OrderID;
                model.MobileID = orderDetails.MobileID;
                model.Quantity = orderDetails.Quantity;
                model.UnitPrice = orderDetails.UnitPrice;
                model.TotalPrice= orderDetails.TotalPrice;
                model.Discount= orderDetails.Discount;
                result = _context.SaveChanges();
            }
            return result;
        }
        public void BulkInsertOrderDetails(List<OrderDetails> orderDetails)
        {
            var model = orderDetails.Select(m => new OrderDetails
            {
                OrderID = m.OrderID,
                MobileID = m.MobileID,
                Quantity = m.Quantity,
                UnitPrice = m.UnitPrice,
                TotalPrice = m.TotalPrice,
                Discount = m.Discount,
            }).ToList();

            _context.OrderDetails.AddRange(model);
            _context.SaveChanges();
        }

        public void BulkUpdateOrderDetails(List<OrderDetails> orderDetails)
        {
            var orderDetailsFields = _context.OrderDetails
      .Where(m => orderDetails.Select(n => n.OrderDetailID).Contains(m.OrderDetailID))
      .ToList();

            foreach (var orderdetails in orderDetails)
            {
                var existingOrderDetails = orderDetailsFields.FirstOrDefault(m => m.OrderDetailID == orderdetails.OrderDetailID);
                if (existingOrderDetails != null)
                {
                    existingOrderDetails.OrderID = orderdetails.OrderID;
                    existingOrderDetails.MobileID = orderdetails.MobileID;
                    existingOrderDetails.Quantity = orderdetails.Quantity;
                    existingOrderDetails.UnitPrice = orderdetails.UnitPrice;
                    existingOrderDetails.TotalPrice = orderdetails.TotalPrice;
                    existingOrderDetails.Discount = orderdetails.Discount;
                }
            }

            _context.SaveChanges();
        }

    }
}
