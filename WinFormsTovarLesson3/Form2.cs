using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTovarLesson3
{
    public partial class Form2 : Form
    {
        Tovar t = null;
        bool addnew;
        public Form2(Tovar t, bool addnew)
        {
            InitializeComponent();
            this.t = t;
            this.addnew = addnew;

            if (this.addnew)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                this.Name = "Добавление товара";
            }
            else
            {
                textBox1.Text = t.Name;
                textBox3.Text = t.Made_in;
                textBox2.Text = t.Price.ToString();
                this.Name = "Редактирование товара";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                double price = 0;
                try { price = Convert.ToDouble(textBox2.Text); } catch (Exception ex) { MessageBox.Show("В цене должны быть только цифры"); }
                if (t == null) t = new Tovar();
                t.Name = textBox1.Text;
                t.Made_in = textBox3.Text;
                t.Price = price;
                this.DialogResult = DialogResult.OK;
            }    
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
