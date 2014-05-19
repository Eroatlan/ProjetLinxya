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

        //implementation of List constructor
        public SoftList()
            : base()
        {
            this.list = new List<Software>();
        }

        public SoftList(List<Software> l)
        {
            this.list = l;
        }
        //method that returns the Softwares with a given Vendor. Returns null if it doesn't exist
        public SoftList getSoftWaresByVendor(String name)
        {
            List<Software> r = new List<Software>();
            if (this.getVendors().Contains(name))
            {
                foreach (Software s in this.getList())
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
                    if (soft.getName().Contains(name) || name.Contains(soft.getName()))
                    {
                        return true;
                    }
                }
                catch (Exception)
                { }
            }
            return false;
        }

        //méthode retournant le software correspondant au nom donné en paramètre, null sinon
        public Software getSoftByName(String name)
        {
            if (match(name))
            {
                foreach (Software s in this.list)
                {
                    try
                    {
                        if (s.getName().Contains(name) || name.Contains(s.getName()))
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

        //Méthode permettant de supprimer le software au nom indiqué parmis ceux de la liste
        public void removeByName (String name)
        {
            if (match(name))
            {
                foreach (Software s in this.list)
                {
                    try
                    {
                        if (s.getName().Equals(name))
                        {
                            list.Remove(s);
                            return;
        }
                    }
                    catch (Exception)
                    { }
                }
            }
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
        { return this.list; }

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
        
        public void setFinalKey(String softName, WeightedKey finalKey)
        {
            foreach (Software soft in this.list)
            {
                if (soft.getName().Equals(softName))
                {
                    soft.setFinalKey(finalKey);
                    return;
                }
            }
        }

    }
}
