/*
 Raheem Hampton
 801060953
 ITCS-3112-051
 Fall 2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cindys_Catering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Event handler for the Form1 Load
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /*
         TextBox4 handler that stores entered text and verifies whether or not it's a digit. If it's not
         no input is entered into the TextBox. It also output's the total price of guests attended
         to TextBox5.
         */
private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            int value;
            if (int.TryParse(textBox4.Text, out value))
            {
                value = int.Parse(textBox4.Text) * 35;
            }
            else
            {     
            }
            textBox5.Text = value.ToString();

        }
        /*
         CheckedListBox1 handler that clears the entire entry if more than one entree is selected.
         */
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numChecked = 0;
            numChecked = checkedListBox1.CheckedItems.Count;

            if (numChecked >= 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }
        /*
        CheckedListBox3 handler that clears the entire entry if more than two sides are selected.
        */
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numChecked = 0;
            numChecked = checkedListBox3.CheckedItems.Count;

            if (numChecked >= 2)
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, false);
                }
            }
        }
        /*
        CheckedListBox2 handler that clears the entire entry if more than one dessert is selected.
        */
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numChecked = 0;
            numChecked = checkedListBox2.CheckedItems.Count;

            if (numChecked >= 1)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
        }
        /*
        Button1_Click handler that gets the CheckListBox 1 - 3's checked boxes as well as inputs 
        from TextBoxes 1 - 5 and saves them to a string that is then outputted to a text file.
        A message box relays completion of order and the entire form is cleared for the next entry.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            string list1 = "";
            String list3 = "";
            String list2 = "";
            for (int i = 0; i < 3; i++)
            {
                if (checkedListBox1.GetSelected(i) == true)
                {
                    list1 += checkedListBox1.Items[i].ToString() + " ";
                }
                if (checkedListBox2.GetSelected(i) == true)
                {
                    list2 += checkedListBox2.Items[i].ToString() + " ";
                }
            }

            foreach(string s in checkedListBox3.CheckedItems)
            {
                list3 += s + ", ";
            }
            list3 = list3.Substring(0, list3.Length - 2);

            String orderInfo =
                       "First Name: " + textBox1.Text + "\n" +
                       "Last Name:  " + textBox2.Text + "\n" +
                       "Phone #:    " + textBox3.Text + "\n" +
                       "Entree's:   " + list1 + "\n" +
                       "Sides:      " + list3 + "\n" +
                       "Dessert's:  " + list2 + "\n" +
                       "Price:      " + textBox5.Text + "\n";

            using (StreamWriter writer = new StreamWriter(@"C:\Users\ihear\source\repos\Cindys_Catering\Cindys_Catering\Event.txt", true))
            {
                writer.WriteLine(orderInfo);
            }

            string message = "Your Order Has Been Placed!";
            MessageBox.Show(message);

            clearForm();
        }
        /*
         ClearForm method that clear each part of the form and converts it to its original
         state before input.
         */
        public void clearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkedListBox1.ClearSelected();
            checkedListBox2.ClearSelected();
            checkedListBox3.ClearSelected();
        }
    }
}
