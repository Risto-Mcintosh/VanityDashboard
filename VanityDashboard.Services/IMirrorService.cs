using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public interface IMirrorService
    {
        Mirror GetMirror(Sizes size);
        Mirror UpdateMirror(Mirror mirror);
        IEnumerable<Mirror> GetMirrors();
        public int CommitChanges();
    }
}
