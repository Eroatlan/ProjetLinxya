using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security;
using System.Windows.Forms;

namespace ProjetLinxya
{
    public class Registre
    {
        //La classe registre permet les différents accès au registre.
        private RegistryKey myRegKey = Registry.LocalMachine;
        List<String> toAvoid;

        public Registre()
        {
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_LOCAL_MACHINE"); //SOFTWAREMicrosoftWindows NTCurrentVersion
                regPermission.Demand();
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred : " + e.Message);
                //Console.WriteLine(e.Message);
                return;
            }

        }

        //Fonction initiale pour la lecture de registre (sans paramètre) appelle la version surchargé pour la suite.
        public List<RegGuess> LectureReg(List<String> softList)
        {
            myRegKey = myRegKey.OpenSubKey(@"SOFTWARE", false);
            RegistryKey temp = myRegKey;

            List<RegGuess> guessList = new List<RegGuess>();

            try
            {
                //Bloc d'affichage simple
                String[] subkeys = myRegKey.GetSubKeyNames();

                for (int i = 0; i < subkeys.Length; i++)
                {
                    //Console.WriteLine(subkeys[i]);
                    if (softList.Contains(subkeys[i]))
                    {
                        guessList.Add(FindValues(subkeys[i]));
                    }
                    else
                    {
                        if (!subkeys[i].Equals("Classes"))
                        guessList.AddRange(LectureReg(subkeys[i], softList));
                    }
                    myRegKey = temp;
                }

                return (guessList);
            }
            catch (SecurityException se)
            {
                //Console.WriteLine("\t Impossible to access SOFTWARE.");
                return (guessList);
            }
        }

        //Fonction surchargée de lecture de registre, lit jusqu'à trouver un noeud correspondant à un programme
        public List<RegGuess> LectureReg(String regPath, List<String> softList)
        {
            //On crée la liste des mots clés qui doivent être reconnus. La liste des noms seule ne suffit pas car 
            List<String> f = Comp.SplitStringList(softList);
            f = Comp.lSort(f);
            List<RegGuess> guessList = new List<RegGuess>();
            RegistryKey temp = myRegKey;
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, regPath);
                try
                {

                    regPermission.Demand();
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    //Console.ReadLine();
                    return (null);
                }
                myRegKey = myRegKey.OpenSubKey(regPath);
                temp = myRegKey;

                String[] subkeys = myRegKey.GetSubKeyNames();
                String[] values = myRegKey.GetValueNames();
                //Boucle qui permet la reconnaissance dess noms de logiciels
                for (int i = 0; i < subkeys.Length; i++)
                {
                    //Condition a modifier pour une meilleure reconnaissance des logiciels
                    if (softList.Contains(subkeys[i]))
                    {
                        //Console.WriteLine(subkeys[i]);
                        guessList.Add(FindValues(subkeys[i]));
                    }
                    else
                    {
                        if (!subkeys[i].Equals("Classes"))
                        guessList.AddRange(LectureReg(subkeys[i], softList));
                    }
                    myRegKey = temp;
                }
                return (guessList);
            }
            catch (SecurityException se)
            {
                //Console.WriteLine("\t Impossible to access : " + regPath);
                return (guessList);
            }
        }
        // Fonction qui pour une clé permet de créer une liste des NamedValues qu'elle contient.
        public RegGuess FindValues(String regPath)
        {
            RegGuess current = new RegGuess(regPath);
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, regPath);
                regPermission.Demand();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return (null);
            }
            myRegKey = myRegKey.OpenSubKey(regPath);
            RegistryKey temp = myRegKey;

            String[] subkeys = myRegKey.GetSubKeyNames();
            String[] values = myRegKey.GetValueNames();

            //Selection criterias
            for (int i = 0; i < values.Length; i++)
            {
                //On crée un objet NamedValue pour pouvoir l'ajouter a la liste dans le RegGuess
                NamedValue n = new NamedValue(values[i], myRegKey.GetValue(values[i]).ToString());
                current.addValue(n);
                //Console.Write("\t " + myRegKey.GetValue(values[i]));
            }

            for (int i = 0; i < subkeys.Length; i++)
            {
                current.addValueRange(FindUnderValues(subkeys[i]));
                myRegKey = temp;
            }
            return current;
        }
        //Permet de trouver les NamedValues en dessous d'une key. Est notamment utilisé pour la fonction FindValues.
        public List<NamedValue> FindUnderValues(String path)
        {
            List<NamedValue> foundValues = new List<NamedValue>();
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, path);
                regPermission.Demand();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return (null);
            }
            myRegKey = myRegKey.OpenSubKey(path);
            RegistryKey temp = myRegKey;

            String[] subkeys = myRegKey.GetSubKeyNames();
            String[] values = myRegKey.GetValueNames();

            //Selection criterias
            for (int i = 0; i < values.Length; i++)
            {
                NamedValue n = new NamedValue(values[i], myRegKey.GetValue(values[i]).ToString());
                foundValues.Add(n);
                //Console.Write("\t " + myRegKey.GetValue(values[i]));
            }
            for (int i = 0; i < subkeys.Length; i++)
            {
                foundValues.AddRange(FindUnderValues(subkeys[i]));
                myRegKey = temp;
            }

            return (foundValues);
        }

        //Permet de lire précisément une valeur dans un chemin déterminé. Utilisé dans le premier parcours.
        public String readValue(PathValue p)
        {
            String[] subToOpen = p.path.Split('\\');
            RegistryKey regKey = myRegKey;
            foreach (String s in subToOpen)
            {
                regKey = regKey.OpenSubKey(s);
            }
            String result = (String)regKey.GetValue(p.value);
            return result;
        }
    }
}
