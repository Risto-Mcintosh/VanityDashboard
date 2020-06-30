using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        Order CreateOrder(Order newOrder);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        public int CommitChanges();
    }
}
