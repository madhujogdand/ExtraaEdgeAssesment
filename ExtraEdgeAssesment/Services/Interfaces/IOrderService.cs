using ExtraaEdgeAssesment.Models;

namespace ExtraaEdgeAssesment.Services.Interfaces
{
    public interface IOrderService
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
