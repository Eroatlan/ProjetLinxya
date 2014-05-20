using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    public class Ways
    {
        //La classe ways permet d'acéder a la base de données des chemins d'accès déjà connus.
        private Dictionary<NamedValue, PathValue> dico;

        //Initialise un dictionnaire avec le fichiers Ways.txt
        public Ways()
        {
            dico = new Dictionary<NamedValue, PathValue>();
            //Doit être redéfini avec l'adresse internet ( et l'éventuel cryptage du fichier ).
            String[] ways = System.IO.File.ReadAllLines(@"C:\Users\Thomas\Desktop\Pro\Visual\ListingAppLinxya\ConsoleApplication1\ways.txt");
            foreach (String s in ways)
            {
                String[] d = s.Split(';');
                PathValue p = new PathValue(d[2], d[3]);
                //La namedValue a pour nom le logiciel, et pour value la version.
                NamedValue n = new NamedValue(d[0], d[1]);
                dico.Add(n, p);
            }

        }
        //Rajoute une référence dans le fichier txt utilisé.
        //A modifier vers un stockage en ligne avec des autorisations ( version admin. )
        public static void addNewWay(String key, String way, String value)
        {
            string insert = key + ";" + way + ";" + value;
            string[] a = new String[1];
            a[0] = insert;
            System.IO.File.AppendAllLines(@"ways.txt", a);
        }

        public Dictionary<NamedValue, PathValue> getDico()
        {
            return dico;
        }
    }
}
