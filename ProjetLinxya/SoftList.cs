using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    public class SoftList : List<Software>
    {
        private List<Software> list;
        public SoftList(List<Software> l)
        {
            this.list = l;
        }
        //implementation of List constructor
        public SoftList()
            : base()
        {
            List<String> k = new List<string>();
            k.Add("aa"); k.Add(" i ");
            List<String> g = new List<string>();
            g.Add("zzzz"); g.Add(" i "); g.Add("ok");
            Console.WriteLine(Comp.haveCommonString(k, g));

            this.list = new List<Software>();
        }
        //method that returns the Softwares with a given Vendor. Returns null if it doesn't exist
        public SoftList getSoftWaresByVendor(String name)
        {
            List<Software> r = new List<Software>();
            if (this.getVendors().Contains(name))
            {
                foreach(Software s in this.getList())
                {
                    if (s.getVendor().Equals(name))
                    {
                        r.Add(s);
                    }
                }
                return new SoftList(r);
            }
            else return null;

        }
        //method to tell if a value exists with the given name in the list
        public bool match(String name)
        {
            foreach (Software soft in this.list)
            {
                try
                {
                    if (soft.getName().Equals(name))
                    {
                        return true;
                    }
                }
                catch (Exception)
                { }
            }
            return false;
        }
        //method that returns the Software with a given name. Returns null if it doesn't exist
        public Software getSoftByName(String name)
        {
            if (match(name))
            {
                foreach (Software s in this.list)
                {
                    try
                    {
                        if (s.getName().Equals(name))
                        {
                            return s;
                        }
                    }
                    catch (Exception)
                    { }
                }
                return null;
            }
            else return null;

        }
        public void addSoft(Software soft)
        {
            this.list.Add(soft);
        }

        //Méthode utilisée pour renvoyer la liste des éditeurs
        public List<String> getVendors()
        {
            List<String> names = new List<String>();
            foreach (Software soft in this.list)
            {
                try
                {
                    names.Add(soft.getVendor());
                }
                catch (Exception)
                { }
            }
            return names;
        }

        public List<Software> getList()
        { 
            return this.list; 
        }
        //Méthode utilisée pour renvoyer les noms de programmes. ( Renvoie les noms donnés par microsoft )
        public List<String> getNames()
        {
            List<String> names = new List<String>();
            foreach (Software soft in this.list)
            {
                try
                {
                    names.Add(soft.getName());
                }
                catch (Exception)
                { }
            }
            return names;
        }
        //Cette méthode appelle tout ce qui est nécessaire dans le premier tour de boucle: lecture du dictionnaire pour accès aux données.
        public void firstTurn()
        {
            //Définition de l'accès au regisre par la classe Registre
            Registre r = new Registre();
            //La classe Ways et celle qui contient le chemin d'accès au dictionnaire.
            Ways w = new Ways();

            Dictionary<String, PathValue> d = w.getDico();

            foreach (Software s in list)
            {
                if (d.ContainsKey(s.getName()))
                {
                    s.addKey(r.readValue(d[s.getName()]), 100);
                }
            }
        }
        //Cette méthode est celle qui permet le second tour: recherche dynamique dans le registre de clés CD.
        public void secondTurn()
        {
            //Définition des variables registre et guessList qui sont nécessaires.
            Registre reg = new Registre();
            List<RegGuess> GuessList = new List<RegGuess>();
            //Tour du registre complet:
            //Récupération des entrées registres qui pourraient correspondre avec ce que l'on attend
            GuessList = reg.LectureReg(this);
            foreach (RegGuess guess in GuessList)
            {
                foreach (WeightedKey k in Comp.regGuessTest(guess))
                
                {

                    //C'est la merde que ça soit en fonction du name du guess.......
                    Software r = this.getSoftByName(guess.getName());
                    if (!(r == null))
                    {

                        //Si on n'a  pas déjà trouvé une clé avec 100% de chance
                        if (!r.IsCompleted())
                        {
                            //Si cette méthode a trouvé une clé avec pour valeur 100, on supprime les anciennes.
                            if (k.getWeight() == 100)
                            {
                                r.ResetKeys();
                            }
                            r.addKey(k);
                        }
                    }
                    else
                    {
                        Console.WriteLine("aHA");
                    }
                }
            }
        }
    }
}
