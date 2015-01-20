using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelticEgyptianRatscrewKata
{
    public interface ISnapValidator
    {
        string Name { get; }
        bool IsValidSnap(Stack stack);
    }
}
