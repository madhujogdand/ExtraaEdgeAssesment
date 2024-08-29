using ExtraaEdgeAssesment.Models;

namespace ExtraaEdgeAssesment.Repository.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetOrders();
        Orders GetOrderById(int id);
        int AddOrder(Orders orders);
        int UpdateOrder(Orders orders);
        int DeleteOrder(int id);
        public void BulkInsertOrders(List<Orders> orders);
        public void BulkUpdateOrders(List<Orders> orders);
    }
}
