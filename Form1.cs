using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace tst_db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Carica_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=MN0CED010NTB;Initial Catalog=LeanMaint;User ID=sa;Password=$Obj_lab2019?";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }

        private void StatoTxtBox_TextChanged(object sender, EventArgs e)
        {
            var rtb = new RichTextBox { };
            rtb.AppendText("LOGGING");
        }

        private void Billing_Click(object sender, EventArgs e)
        {
            var myForm = new Form2();
            myForm.Show();
        }
    }
    
}
