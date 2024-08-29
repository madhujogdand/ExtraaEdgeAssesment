using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Repository.Interfaces;
using ExtraaEdgeAssesment.Services.Interfaces;

namespace ExtraaEdgeAssesment.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository repo;
        public OrderDetailsService(IOrderDetailsRepository repo)
        {
            this.repo = repo;
        }
        public int AddOrderDetails(OrderDetails orderDetails)
        {
          return repo.AddOrderDetails(orderDetails);
        }

        public int DeleteOrderDetails(int id)
        {
          return repo.DeleteOrderDetails(id);
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
        return repo.GetOrderDetails();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
        return repo.GetOrderDetailsById(id);
        }

        public int UpdateOrderDetails(OrderDetails orderDetails)
        {
           return repo.UpdateOrderDetails(orderDetails);
        }


        public void BulkInsertOrderDetails(List<OrderDetails> orderDetails)
        {
          repo.BulkInsertOrderDetails(orderDetails);
        }

        public void BulkUpdateOrderDetails(List<OrderDetails> orderDetails)
        {
           repo.BulkUpdateOrderDetails(orderDetails);   
        }

    }
}
