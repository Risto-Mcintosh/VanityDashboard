using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder();
        Order CreateOrder();
        void DeleteOrder();
        Order UpdateOrder();
    }
}
