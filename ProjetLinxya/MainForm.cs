﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjetLinxya
{
    public partial class MainForm : Form
    {
        private static Registre reg;
        private static SoftList softList;
        private static SoftList selectedList = new SoftList();

        //Constructeur pour la fenêtre d'affichage principale
        public MainForm()
        {
            InitializeComponent();
        }

        //Fonction permettant l'ajout de softwares à la boxList des softwares
        public void AddToListBoxSoftwares(String soft)
        {
            if (! (soft==null))
                this.softwaresListBox.Items.Add(soft);
        }
        
        //Fonction principale du logiciel, lance la recherche des logiciels installés
        //puis cherche les correspondances en registre système et affiche les résultats
        public void Run()
        {
            Ways wat = new Ways();
            softList = new SoftList();

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Product");

                int i = 0;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    i++;
                    String idN = "";
                    String name = "";
                    String vend = "";
                    String instLoc = "";
                    String prodID = "";
                    String version = "";

                    try { idN = queryObj["IdentifyingNumber"].ToString(); }
                    catch (Exception) { }
                    try { name = queryObj["Name"].ToString(); }
                    catch (Exception) { }
                    try { vend = queryObj["Vendor"].ToString(); }
                    catch (Exception) { }
                    try { instLoc = queryObj["InstallLocation"].ToString(); }
                    catch (Exception) { }
                    try { prodID = queryObj["ProductID"].ToString(); }
                    catch (Exception) { }
                    try { version = queryObj["Version"].ToString(); }
                    catch (Exception) { }

                    softList.addSoft(new Software(idN, name, vend, instLoc, prodID, version));
                    
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

            softList.secondTurn();

            foreach (Software s in softList.getList())
            {
                this.AddToListBoxSoftwares(s.toStringKey());
            }
        }

        //Fonction liée au bouton permettant le lancement de la fonction principale
        private void launchButton_Click(object sender, EventArgs e)
        {
            this.launchButton.Visible = false;
            MessageBox.Show("Traitement en cours.", "Parcours du registre", MessageBoxButtons.OK);
            this.Run();
        }

        //Fonction déclenchée au changement d'index sélectionné par l'utilisatieur dans
        //la ListBox correspondant aux softwares
        private void softwaresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.keysListBox.Items.Clear();
                Software s = softList.getSoftByName(this.softwaresListBox.SelectedItem.ToString());
                int it = 0;
                foreach (WeightedKey wk in s.getKeys())
                {
                    this.keysListBox.Items.Add(wk);
                    if (s.getFinalKey() != null)
                    {
                        if (s.getFinalKey().getValue() == wk.getValue())
                        {
                            this.keysListBox.SetItemCheckState(it, CheckState.Checked);
                        }
                    }
                    it++;
                }
            }
            catch (Exception ex)
            { }
        }

        //Fonction déclenchée lorsqu'une ligne est checkée par l'utilisateur dans
        //la ListBox correspondant aux clés liées à un software
        private void keysListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                if (e.Index == keysListBox.SelectedIndex)
                {
                    if (keysListBox.CheckedItems.Count > 0)
                    {
                        for (int i = 0; i < keysListBox.Items.Count; i++)
                        {
                            if (i != keysListBox.SelectedIndex)
                                keysListBox.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                    softwaresListBox.SetItemCheckState(softwaresListBox.SelectedIndex, CheckState.Checked);
                    String softName = softwaresListBox.SelectedItem.ToString();

                    softList.setFinalKey(softName, softList.getSoftByName(softName).getKeyByName(keysListBox.SelectedItem.ToString()));
                    
                    if (!(selectedList.getNames().Contains(softName)))
                        selectedList.addSoft(softList.getSoftByName(softName));
                }
            }
            else
            {
                if (softwaresListBox.CheckedItems.Count == 1)
                {
                    softwaresListBox.SetItemCheckState(softwaresListBox.SelectedIndex, CheckState.Unchecked);
                }
            }

            displaySelected();    
            
        }

        //Fonction permettant le rafraichissement de l'affichage des softwares sélectionnés
        private void displaySelected ()
        {
            listBoxSelectedSoftwares.Items.Clear();
            foreach (Software soft in selectedList.getList())
            {
                listBoxSelectedSoftwares.Items.Add(soft.getName());
            }
        }

        //Fonction déclenchée lorsqu'une ligne est checkée par l'utilisateur ou automatiquement dans
        //la ListBox correspondant aux softwares
        private void softwaresListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                selectedList.removeByName(softwaresListBox.SelectedItem.ToString());
                displaySelected();
            }
            else
            {
                selectedList.addSoft(softList.getSoftByName(softwaresListBox.SelectedItem.ToString()));
                displaySelected();
                //softwaresListBox.SetItemCheckState(softwaresListBox.SelectedIndex, CheckState.Unchecked);
            }
        }

        //Fonction liée au bouton permettant la finalisation de l'utilisation
        //A redéfinir par l'entreprise afin d'être intégrée
        private void submitButton_Click(object sender, EventArgs e)
        {
            String mess = "";
            foreach (Software soft in selectedList.getList())
            {
                mess = mess + "\n" + soft.getName() + " - " + soft.getFinalKey();
            }
            MessageBox.Show(mess, "Output", MessageBoxButtons.OK);
        }

            
    }  
}
