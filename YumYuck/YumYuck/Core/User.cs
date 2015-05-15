using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYuck.Core
{
    class User
    {
        String Name { get; set; }
        List<Food> Yums { get; set; }
        List<Food> Yucks { get; set; }
    }
}
