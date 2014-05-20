using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    public class Comp
    {
        // inList permet la comparaison d'un string avec la liste passée en paramètre. Elle est appelée uniquement en privé par la fonction inLists
        private static bool inList(List<String> l, String s)
        {
            if (l.BinarySearch(s) < 0)
                return false;
            else
                return true;
        }
        public static int inLists(List<String> logs, List<String> companies, String s)
        {
            if (inList(logs, s))
                return 1;
            else if (inList(companies, s))
                return 2;
            else
                return 0;
        }

        //Méthode pour déterminer si les listes de string 1 et 2 passées en paramètre ont au moins un élément en commun
        public static bool haveCommonString(List<String> l1, List<String> l2)
        {
            foreach (String s in l1)
            {
                if (l2.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }
        //Méthode pour déterminer si les listes de string 1 et 2 passées en paramètre ont au moins un élément en commun
        public static NamedValue haveCommonString(List<NamedValue> l1, List<String> l2)
        {
            foreach (NamedValue n in l1)
            {
                if (l2.Contains(n.value))
                {
                    return n;
                }
            }
            return null;
        }
        //Méthode utilisée pour tester une regGuess entière.
        public static List<WeightedKey> regGuessTest(RegGuess r)
        {
            List<WeightedKey> result = new List<WeightedKey>();
            foreach (NamedValue nv in r.getValues())
            {
                if (namedValueTest(nv) >= 60)
                {
                    int i = 0;
                    WeightedKey k = new WeightedKey(nv.value, namedValueTest(nv));
                    foreach (WeightedKey v in result)
                    {
                        if (v.getValue().Equals(nv.value))
                        {
                            i=1;
                        }
                    }
                    if( i ==0 )
                        result.Add(k);
                }
            }
            return result;
        }
        //Méthode utilisée pour tester une namedValue
        public static int namedValueTest(NamedValue n)
        {
            int result = 0;
            Regex nameTest = new Regex("#|Serial|key|licence|license|id|#i", RegexOptions.IgnoreCase);
            if (nameTest.IsMatch(n.name))
            {
                result = 20;
            }
            result += keyTest(n.value);
            return result;
        }
        //Méthode utilisée pour tester une chaîne, utilisant les méthodes de test privées.
        public static int keyTest(String s)
        {
            Regex r = new Regex("^(([A-Z]):)");
            Regex date = new Regex("^[0-3]?[0-9]/[0-3]?[0-9]/(?:[0-9]{2})?[0-9]{2}$");
            if (s.StartsWith("{") || r.Match(s).Success || date.Match(s).Success || s.StartsWith("http:"))
            {
                return 0;
            }
            else if (s.Contains("-") || s.Contains(" ") && !s.Contains(".") && !s.Contains("\\"))
            {
                if (isBasicKey(s) == 1)
                {
                    return 80;
                }
                else if (isWeirdBasickey(s) == 1)
                {
                    return 65;
                }
                else return 0;
            }
            else return (isKeyBloc(s) * 10) - 25;

        }

        //isBasicKey permet de tester la ressemblance d'un String avec le format que nous appelons "basique": AAAA-AAAA-AAAA, ou encore AAAAA AAAAA AAAAA
        private static int isBasicKey(String toTest)
        {
            int tot = 0;
            int beforeFirst = 0;
            int charsBetweenLastFound = 0;
            for (int i = 0; i < toTest.Length; i++)
            {
                bool b = (toTest.Substring(i, 1).Equals("-") || Char.IsWhiteSpace(toTest[i]));
                if (b)
                {
                    tot += 1;
                }
                if (b && beforeFirst == 0)
                {
                    //premier "-" trouvé 
                    beforeFirst = i;
                }
                else if (b && charsBetweenLastFound == 0)
                {
                    //caractères séparant le - à 
                    charsBetweenLastFound = i - (beforeFirst + 1);
                    if (charsBetweenLastFound == beforeFirst)
                    {
                        //Même nombre de caractères, on continue
                        charsBetweenLastFound = i - (charsBetweenLastFound + 1);
                    }
                }
                else if (b && !(charsBetweenLastFound == beforeFirst))
                {
                    return 0;
                }

            }
            if (((tot + 1) * (beforeFirst) + tot) == toTest.Length && beforeFirst > 2 && toTest.Length > 8)
            {
                return 1;
            }
            else return 0;
        }

        //Cette méthode est utilisée pour vérifier si le string ressemble à une clé CD découpée "bizarrement" --> AAAAAAAAA-AAA-AAAAA
        private static int isWeirdBasickey(String toTest)
        {
            //int prob = 0;
            int tot = 0;
            int beforeFirst = 0;
            int charsBetweenLastFound = 0;
            for (int i = 0; i < toTest.Length; i++)
            {
                bool b = (toTest.Substring(i, 1).Equals("-"));
                if (b)
                {
                    tot += 1;
                }
                if (b && beforeFirst == 0)
                {
                    //premier "-" trouvé 
                    beforeFirst = i;
                }
                else if (b && charsBetweenLastFound == 0)
                {
                    //caractères séparant le - à 
                    charsBetweenLastFound = i - (beforeFirst + 1);
                    if (charsBetweenLastFound == beforeFirst)
                    {
                        //Même nombre de caractères, on continue
                        charsBetweenLastFound = i - (charsBetweenLastFound + 1);
                    }
                }
            }
            if (beforeFirst > 5 && tot >= 2 && toTest.Length > 12)
            {
                return 1;
            }
            else return 0;
        }

        //Méthode qui permet de renvoyer un coeff de probabilité pour les chaines sans espace
        private static int isKeyBloc(String toTest)
        {
            if (toTest.Contains("\\") || toTest.Contains(".") || toTest.Contains(" ") || toTest.Contains("_") || toTest.Length < 7 || toTest.StartsWith("{"))
            {
                return 0;
            }
            int prob = 0;
            int nums = 0;
            int autre = 0;
            for (int i = 0; i < toTest.Length; i++)
            {
                Char c = toTest[i];
                if (Char.IsWhiteSpace(c) || c.Equals("-"))
                    return 0;
                else if (Char.IsDigit(c))
                    nums += 1;
                else
                    autre += 1;
            }
            //Attribution de coefficients de probabilité.
            if (nums == 0)
                return 0;
            if (nums >= 3)
                prob += 5;
            if (autre > 3)
                prob += 5;
            if (autre >= 1)
                prob += 2;
            if (nums - autre > 5)
                prob += 2;
            if (autre - nums > 10)
                prob -= 2;
            if (nums == toTest.Length)
                prob += 1;
            return prob;
        }

        //Méthode qui crée les noms décomposés des logiciels
        public static List<String> SplitStringList(List<String> ls)
        {
            List<String> back = new List<string>();
            foreach (String s1 in ls)
            {
                foreach (String s2 in s1.Split(' '))
                {
                    back.Add(s2);
                }
            }
            return back;
        }
        //Méthode qui crée les noms décoposés des logiciels en conservant leurs noms.
        public static List<NamedValue> SplitStringListAndKeep(List<String> ls)
        {
            List<NamedValue> back = new List<NamedValue>();
            foreach (String s1 in ls)
            {
                foreach (String s2 in s1.Split(' '))
                {
                    back.Add(new NamedValue(s1, s2));
                }
            }
            return back;
        }
        //Méthode de tri des String a comparer
        public static List<String> lSort(List<String> l)
        {
            List<String> k = new List<String>();
            l.Sort();
            foreach (String b in l.Distinct())
            {
                k.Add(b);
            }
            Regex r = new Regex("[a-zA-Z]");
            List<String> toRem = new List<string>();
            foreach (String z in k)
            {

                if (z.Length < 4 || z.StartsWith("(") || !r.Match(z).Success)
                {
                    toRem.Add(z);
                }
            }
            foreach (String o in toRem)
            {
                k.Remove(o);
            }
            return k;
        }
        //Méthode utilisée pour l'essai de la classe globale. Renvoie le nombre d'erreurs (+de 10% d'erreurs) sur une liste de test
        public static double compTest()
        {
            List<String> k = initListTest();
            List<bool> val = initResultsList();
            int er10 = 0;
            int er20 = 0;
            int er05 = 0;
            int r;
            for (int i = 0; i < k.Count; i++)
            {
                //Console.WriteLine("ligne" + i + " : " + k[i] + " a pour valeur " + val[i]);
                if (val[i])
                    r = 100 - keyTest(k[i]);
                else r = keyTest(k[i]);
                if (r > 20)
                {
                    //Console.WriteLine("erreur au test " + i);
                }
                if (r > 20)
                {
                    er05 += 1;
                    er10 += 1;
                    er20 += 1;
                }
                else if (r > 10)
                {
                    er10 += 1;
                    er05 += 1;
                }
                else if (r > 5)
                {
                    er05 += 1;
                }

            }
            return er20;
        }
        //Méthodes utilisée pour l'initialisation de listes de tests.
        public static List<String> initListTest()
        {
            List<String> t = new List<String>();
            t.Add("AAAAA-AAAAA-AAAAA-AAAAA");       //1
            t.Add("AA88AA-AAAAAA-AAACAA-AAA6AA");   //2
            t.Add("fr_FR");
            t.Add("fr-FR");
            t.Add("70FEE2FD");                      //5
            t.Add("AAAAAAA-595-ADCCP");
            t.Add("A-B-C-D-E");
            t.Add("GPK948 UR3RS9 RZ54Y3");
            t.Add("270272787881");
            t.Add("Bonjour!");                      //10
            t.Add("2014-13-11");
            t.Add("a1");

            return t;
        }
        public static List<bool> initResultsList()
        {
            List<bool> s = new List<bool>();
            s.Add(true);        //1
            s.Add(true);
            s.Add(false);
            s.Add(false);
            s.Add(true);        //5
            s.Add(true);
            s.Add(false);
            s.Add(true);
            s.Add(true);
            s.Add(false);       //10
            s.Add(false);
            s.Add(false);

            return s;
        }
    }
}