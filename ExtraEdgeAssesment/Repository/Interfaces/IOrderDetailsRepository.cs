using ExtraaEdgeAssesment.Models;

namespace ExtraaEdgeAssesment.Repository.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetailsById(int id);
        int AddOrderDetails(OrderDetails orderDetails);
        int UpdateOrderDetails(OrderDetails orderDetails);
        int DeleteOrderDetails(int id);
        public void BulkInsertOrderDetails(List<OrderDetails> orderDetails);
        public void BulkUpdateOrderDetails(List<OrderDetails> orderDetails);
    }
}
