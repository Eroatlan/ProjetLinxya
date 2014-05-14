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

namespace ProjetLinxya
{
    public partial class MainForm : Form
    {
        private static Registre reg;

        public MainForm()
        {
            InitializeComponent();
        }

        public void AddToListBoxSoftwares(Software soft)
        {
            if (! (soft==null))
                this.softwaresListBox.Items.Add(soft);
        }
        
        public void Run()
        {
            Ways wat = new Ways();
            SoftList softList = new SoftList();

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
                    this.softwaresListBox.Items.Add(name);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

            softList.secondTurn();

            foreach (Software s in softList.getList())
            {
                this.AddToListBoxSoftwares(s);
            }
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            this.Run();
        }

        private void softwaresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.keysListBox.Items.Clear();
            Software s = (Software)(this.softwaresListBox.SelectedItem);
            this.keysListBox.Items.Add(s.getKeys()[0]);
        }
    }  
}
