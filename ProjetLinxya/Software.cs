using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLinxya
{
    public class Software
    {
        private String identifyingNumber;
        private String name;
        private String vendor;
        private String installLocation;
        private String productID;
        private String version;
        private List<WeightedKey> keys;
        private WeightedKey finalKey;

        public Software(String idN, String name, String vend, String instLoc, String prodID, String ver)
        {
            this.identifyingNumber = idN;
            this.name = name;
            this.vendor = vend;
            this.installLocation = instLoc;
            this.productID = prodID;
            this.version = ver;
            this.keys = new List<WeightedKey>();
        }


        public String getIdentifyingNumber()
        { return this.identifyingNumber; }
        public String getName()
        { return this.name; }
        public String getVendor()
        { return this.vendor; }
        public String getInstallLocation()
        { return this.installLocation; }
        public String getProductID()
        { return this.productID; }
        public String getVersion()
        { return this.version; }


        //Functions to manipulate weighted keys
        public void addKey(String val, int weight)
        { this.keys.Add(new WeightedKey(val, weight)); }
        public void addKey(WeightedKey k)
        { this.keys.Add(k); }
        public List<WeightedKey> getKeys()
        { return this.keys; }


        public String toString()
        {
            String ret;
            ret = "Entry ==> Name : " + this.name; //+ " - Vendor : " + this.vendor;
            return ret;
        }

        public String toStringKey()
        {
            String ret;
            if (this.getKeys().Count > 0)
            {
                String sKeys = " ";
                List<WeightedKey> key = this.getKeys();
                foreach (WeightedKey k in key)
                {
                    sKeys = sKeys + " => " + k.getValue() + " avec poids: " + k.getWeight();
                }
                //ret = "Entry ==> Name : " + this.name + " - Vendor : " + this.vendor + " - Keys : " + sKeys;
                ret = this.name;
                return ret;
            }
            else return null;
        }
        //Méthode qui sert lors de la vérification de si on insère ou non une clé
        public bool IsCompleted()
        {
            foreach (WeightedKey k in getKeys())
            {
                if (k.getWeight() == 100)
                {
                    return true;
                }
            }
            return false;
        }
        //Fonction qui permet de supprimer les clés déjà stockées.s
        public void ResetKeys()
        {
            this.keys = new List<WeightedKey>();
        }

        public WeightedKey getFinalKey()
        {
            return this.finalKey;
        }

        public void setFinalKey(WeightedKey val)
        {
            this.finalKey = val;
        }

        public WeightedKey getKeyByName(String name)
        {
            for (int i = 0; i<this.keys.Count ; i++)
            {
                if (name.Contains(this.keys[i].getValue()))
                    return this.keys[i];
            }
            return null;
        }
    }
}
