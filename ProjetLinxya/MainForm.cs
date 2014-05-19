using System;
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

        public MainForm()
        {
            InitializeComponent();
        }

        public void AddToListBoxSoftwares(String soft)
        {
            if (! (soft==null))
                this.softwaresListBox.Items.Add(soft);
        }
        
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

        private void launchButton_Click(object sender, EventArgs e)
        {
            this.Run();
            //this.softwaresListBox.
        }

        private void softwaresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.keysListBox.Items.Clear();
                Software s = softList.getSoftByName(this.softwaresListBox.SelectedItem.ToString());
                foreach (WeightedKey wk in s.getKeys())
                {
                    this.keysListBox.Items.Add(wk);
                }
            }
            catch (Exception ex)
            { }
        }

        private void keysListBox_ItemCheck(object sender, ItemCheckEventArgs e)
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

                    //String[] parsedItem = listBoxSelectedSoftwares.SelectedItem.ToString().Split('\t');
                    if (listBoxSelectedSoftwares.Items.Contains(softwaresListBox.SelectedItem))
                    { }
                    else
                        listBoxSelectedSoftwares.Items.Add(softwaresListBox.SelectedItem.ToString() + " \t " + keysListBox.SelectedItem.ToString());
                }

                /*if (e.CurrentValue == CheckState.Unchecked)
                {
                    if (keysListBox.CheckedItems.Count == 0)
                    {
                        try
                        {
                            listBoxSelectedSoftwares.Items.Remove(softwaresListBox.SelectedItem);
                        }
                        catch (Exception exc)
                        { }
                    }
                }*/
            
        }

        private void softwaresListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
               
        }
            
    }  
}
