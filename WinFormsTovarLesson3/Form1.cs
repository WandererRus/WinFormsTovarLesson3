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
            if (listBox1.SelectedIndex == -1)// ���� �����
                                             // �� ������
            {
                MessageBox.Show("�� �� ������� �����");
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)// ���� �����
                                             // �� ������
            {
                MessageBox.Show("�� �� ������� �����");
                return;
            }
            int n = listBox1.SelectedIndex;// ����������
                                           // ���������� �������
                                           // �������� ������ �� ���������� �������
            t = (Tovar)listBox1.Items[n];
            Form2 editform = new Form2(t, false);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n); // �������
                                        // ���������� �������
            /* � ��������� ��� ����� � �� �� �������,
            ����� �� ������������� � ������ */
            listBox1.Items.Insert(n, t);
            listBox1.SelectedIndex = n;
            // ����� �������� ���� �������

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            t = new Tovar();
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {// ���� ������������ ����� ��, ���������
             // ����� � ������
                listBox1.Items.Add(t);
            }
        }
    }
    public class Tovar
    {
        string name; //�������� ������
        string made_in; //������ �������������
        double price; //����
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
                    throw new System.Exception("���� �� ����� ���� ������ ����");

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
            return Name + " ������������: " + Made_in +
            " ����: " + Price;
        }
    }
}