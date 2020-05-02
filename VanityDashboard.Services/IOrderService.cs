using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        Order CreateOrder(Order order);
        void DeleteOrder(int id);
        Order UpdateOrder(Order order);
    }
}
