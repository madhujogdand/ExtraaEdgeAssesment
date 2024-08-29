using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Repository.Interfaces;
using ExtraaEdgeAssesment.Services.Interfaces;

namespace ExtraaEdgeAssesment.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repo;
        public OrderService(IOrderRepository repo)
        {
            this.repo = repo;
        }
        public int AddOrder(Orders orders)
        {
          return repo.AddOrder(orders);
        }

        public int DeleteOrder(int id)
        {
          return repo.DeleteOrder(id);  
        }

        public Orders GetOrderById(int id)
        {
          return repo.GetOrderById(id);
        }

        public IEnumerable<Orders> GetOrders()
        {
          return repo.GetOrders();
        }

        public int UpdateOrder(Orders orders)
        {
         return repo.UpdateOrder(orders);
        }
        public void BulkInsertOrders(List<Orders> orders)
        {
           repo.BulkInsertOrders(orders);
        }

        public void BulkUpdateOrders(List<Orders> orders)
        {
         repo.BulkUpdateOrders(orders); 
        }

    }
}
