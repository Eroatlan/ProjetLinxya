using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    //Classe représentant les clés CD pondérées, avec une valeur et un poids
    public class WeightedKey
    {
        private String value;
        private int weight;

        public WeightedKey(String val, int weight)
        {
            this.value = val;
            this.weight = weight;
        }

        public String getValue()
        { return this.value; }
        public int getWeight()
        { return this.weight; }

        override public string ToString()
        {
            return value + " - " + weight;
        }
    }
}