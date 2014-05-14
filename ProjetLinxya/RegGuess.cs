using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    //La classe RegGuess est utilisée pour lister un nom de key et les values qu'elle contient. Cela est utilisé pour retrouver ce qui serait une serial key.
    public class RegGuess
    {
        //Les attributs de la classe sont: le nom de la Key et ses NamedValues (nom+valeur associée)
        private String name;
        private List<NamedValue> values;

        public RegGuess(String name)
        {
            this.name = name;
            this.values = new List<NamedValue>();
        }

        public void addValue(NamedValue val)
        {
            this.values.Add(val);
        }

        public void addValueRange(List<NamedValue> val)
        {
            this.values.AddRange(val);
        }

        public List<NamedValue> getValues()
        { return this.values; }

        public String getName()
        { return this.name; }

        public String toString()
        {
            String result = ("Reg entry ==> Name : \t" + this.name + "\nValues : ");
            foreach (NamedValue imp in values)
            { result = result + "\n\t" + imp.name + " \t " + imp.value; }
            return result;
        }
    }
}
