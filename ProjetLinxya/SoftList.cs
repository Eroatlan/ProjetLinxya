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

        //Constructeur de liste de software
        public SoftList()
            : base()
        {
            this.list = new List<Software>();
        }

        //Méthode permettant de retourner si une valeur existe au nom indiqué dans la liste
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

        public List<Software> getList()
        { return this.list; }

        //Méthode retournant la liste des noms de softwares dans la liste courante
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
            GuessList = reg.LectureReg(this.getNames(), getVendors());
            foreach (RegGuess guess in GuessList)
            {
                foreach (WeightedKey k in Comp.regGuessTest(guess))
                {
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

        public List<String> getVendors()
        {
            List<String> res = new List<string>();
            foreach (Software soft in this.list)
            {
                try
                {
                    res.Add(soft.getVendor());
                }
                catch (Exception cc)
                { }
            }
            return res;
        }
    }
}
