using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer updatedCustomer);
    }
}
