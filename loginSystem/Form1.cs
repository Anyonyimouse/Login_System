using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace loginSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        List<string> dbUN = new List<string>();
        List<string> dbPW = new List<string>();
        List<string> logs = new List<string>();
        List<string> pos = new List<string>();



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addAcct();
            displayData();

        }

        void report(string Reports)
        {
            logs.Add(Reports);

            listBox2.Items.Clear();
            foreach (string stamp in logs)
            {
                listBox2.Items.Add(stamp);
            }
        }


        void addAcct()
        {
            string un = textBox3.Text;
            string pw = textBox4.Text;
            string old = listBox2.Text;

            bool isAdmin = radioButton1.Checked;
            bool isUser = radioButton2.Checked;

            dbUN.Add(un);
            dbPW.Add(pw);

            if (isAdmin)
            {
                pos.Add("     (admin)");
                report(old + un + " has been created as an admin");
            }
            else if (isUser)
            {
                pos.Add("     (user)");
                report(old + un + " has been created as a user");
            }
        }


        void displayData()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < dbUN.Count; i++)
            {
                string un = dbUN[i];
                string pw = dbPW[i];
                string posi = pos[i];

                listBox1.Items.Add(i + ": " + un + " / " + pw + posi);

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;

            if (i >= 0 && i < dbUN.Count)
            {
                string removedUser = dbUN[i];
                dbUN.RemoveAt(i);
                dbPW.RemoveAt(i);

                displayData();

                report(removedUser + " has been removed");
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;

            textBox3.Text = dbUN[i];
            textBox4.Text = dbPW[i];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            string un = dbUN[i];



            if (i >= 0 && i < dbUN.Count)
            {

                dbUN[i] = textBox3.Text;
                dbPW[i] = textBox4.Text;


                displayData();


                report(un + " has been updated into " + dbUN[i]);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {


            string un = textBox1.Text;
            string pw = textBox2.Text;




            if (textBox1.Text == "admin" && textBox2.Text == "admin123")
            {
                panel3.Hide();
                panel1.Hide();
                panel2.Show();
            }

            for (int i = 0; i < dbUN.Count; i++)
            {
                if (un.Equals(dbUN[i]) && pw.Equals(dbPW[i]))
                {
                    if (pos[i] == "     (admin)") 
                    {
                        
                        panel2.Show();
                        panel1.Hide();
                        panel3.Hide();
                        report("Admin " + dbUN[i] + " has been logged in");
                    }
                    else if (pos[i] == "     (user)")
                    {
                        
                        panel2.Hide();
                        panel1.Hide();
                        panel3.Show();
                        report("User " + dbUN[i] + " has been logged in");
                    }
                    return; 
                }
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {

            panel3.Hide();
            panel1.Show();
            panel2.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel1.Show();
            panel2.Hide();

            for (int i = 0; i < dbUN.Count; i++)
            {
                report("User " + dbUN[i] + " has been logged out");
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
