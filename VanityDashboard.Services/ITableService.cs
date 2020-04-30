using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public interface ITableService
    {
        Table GetTable(Sizes size);
        Table UpdateTable(Table table);
        IEnumerable<Table> GetTables();
        Table CreateTable(Table table);
    }
}
