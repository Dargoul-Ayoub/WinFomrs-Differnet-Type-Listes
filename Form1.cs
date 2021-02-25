using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiffernetLystesListes
{
    public partial class Form1 : Form
    {
        ArrayList list_ItemSelected = new ArrayList();
        ArrayList list_OneItem = new ArrayList();
        ArrayList list_of_month = new ArrayList() { "Janvier","Féverier","Mars","Avril" };
        string[] month1 = { "Mai", "Juin", "Juillet","Aout"};
         string[] month2 = new string[] { "Septembre","Octobre", "Novembre", "Decembre" };

       // List<string> lis = new List<string> { "1", "2" };
        public Form1()
        {
            // listBox1.Items.AddRange(lis); il ne peut pas accepter list et arraylist

            InitializeComponent();
            listBox1.DataSource = list_of_month;
            checkedListBox1.Items.AddRange(month1);
            comboBox1.DataSource = month2;
            textBox1.Text = string.Empty;
            listBox1.ClearSelected();
            
            label1.Text = "0 Element(s) Coché(s)";

        }
        bool selected_multiple = false;
        string iteme = null;



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
              selected_multiple = true;
            else
               selected_multiple = false;


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           textBox1.Text = string.Empty;
            int nbr_ElementCoche=0;

            if (!selected_multiple)
            {
                list_OneItem.Clear();
                list_ItemSelected.Clear(); // i did it because i want when i selected an item , the only one shown in textBox is him

                listBox1.SelectionMode = SelectionMode.One;
                  iteme = Convert.ToString(listBox1.SelectedItem);
                if (iteme != null)
                    list_OneItem.Add(iteme);
                nbr_ElementCoche++;

            }
            else
            {
                list_ItemSelected.Clear();
                list_OneItem.Clear();
                listBox1.SelectionMode = SelectionMode.MultiSimple;
                foreach (var item in listBox1.SelectedItems)
                {

                    list_ItemSelected.Add(item);
                    nbr_ElementCoche++;
                }
                list_OneItem.AddRange(list_ItemSelected);

            }

            

            
            foreach (var item in list_OneItem)
                textBox1.Text += Convert.ToString(item) + Environment.NewLine;

            label1.Text = nbr_ElementCoche.ToString()+" Element(s) Coché(s)";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
                foreach (var item in list_OneItem)
                textBox1.Text += Convert.ToString(item) + Environment.NewLine;
            foreach (var item in checkedListBox1.CheckedItems)
            textBox1.Text += Convert.ToString(item) +Environment.NewLine;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text += Convert.ToString(comboBox1.SelectedItem) + Environment.NewLine;
        }
    }
}
