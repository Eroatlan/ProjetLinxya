using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    //Classe utilisée pour regrouper deu String, notamment utile pour un nom de valeur et une valeur.
    public class NamedValue
    {
        public String name;
        public String value;
        public NamedValue(String n, String v)
        {
            this.name = n;
            this.value = v;
        }
    }
}
