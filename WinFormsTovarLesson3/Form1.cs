namespace WinFormsTovarLesson3
{
    public partial class Form1 : Form
    {
        Tovar t = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)// Если товар
                                             // не выбран
            {
                MessageBox.Show("Вы не выбрали товар");
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)// Если товар
                                             // не выбран
            {
                MessageBox.Show("Вы не выбрали товар");
                return;
            }
            int n = listBox1.SelectedIndex;// запоминаем
                                           // выделенный элемент
                                           // Забираем ссылку на выделенный элемент
            t = (Tovar)listBox1.Items[n];
            Form2 editform = new Form2(t, false);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n); // Удаляем
                                        // выделенный элемент
            /* и добавляем его снова в ту же позицию,
            чтобы он перерисовался в списке */
            listBox1.Items.Insert(n, t);
            listBox1.SelectedIndex = n;
            // Снова выделяем этот элемент

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            t = new Tovar();
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {// если пользователь нажал ок, добавляем
             // товар в список
                listBox1.Items.Add(t);
            }
        }
    }
    public class Tovar
    {
        string name; //название товара
        string made_in; //страна производитель
        double price; //цена
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Made_in
        {
            get { return made_in; }
            set { made_in = value; }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (price < 0)
                    throw new System.Exception("Цена не может быть меньше нуля");

                price = value;
            }
        }
        public Tovar()
        {
            Name = "unknown"; Price = 0;
            Made_in = "unknown";
        }
        public Tovar(string name, string made, double price)
        {
            Name = name; Made_in = made; Price = price;
        }
        public override string ToString()
        {
            return Name + " Изготовитель: " + Made_in +
            " Цена: " + Price;
        }
    }
}