using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public static class Context<T>
    {
        public static List<T> entities = new List<T>();

    }
}
