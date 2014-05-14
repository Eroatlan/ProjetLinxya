﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    public class Ways
    {
        private Dictionary<String, PathValue> dico;

        //Initialise un dictionnaire avec le fichiers Ways.txt
        public Ways()
        {
            dico = new Dictionary<string, PathValue>();
            String[] ways = System.IO.File.ReadAllLines(@"ways.txt");
            foreach (String s in ways)
            {
                String[] d = s.Split(';');
                PathValue p = new PathValue(d[1], d[2]);
                dico.Add(d[0], p);
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

        public Dictionary<String, PathValue> getDico()
        {
            return dico;
        }
    }
}