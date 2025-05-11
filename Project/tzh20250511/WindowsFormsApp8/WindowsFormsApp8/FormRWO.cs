using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game3231;
using static WindowsFormsApp8.FormRWO;

namespace WindowsFormsApp8
{
    public partial class FormRWO : Form
    {
        public FormRWO()
        {
            InitializeComponent();
        }
        List<UserInfo> users;

     

        private void FormRWO_Load(object sender, EventArgs e)
        {
            try
            {
                users = UtilClass<List<UserInfo>>.ReadObject("users");

            }
            catch (Exception)
            {


            }
            if (users == null)
            {
                users = new List<UserInfo>();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserInfo ui = new UserInfo(textBox1.Text, textBox2.Text);
                string fileName = saveFileDialog.FileName;
                UtilClass<UserInfo>.SaveObject(fileName, ui);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserInfo ui = UtilClass<UserInfo>.ReadObject(openFileDialog.FileName);
                textBox1.Text = ui.UserName;
                textBox2.Text = ui.Password;
            }
        }

        private void FormRWO_FormClosing(object sender, FormClosingEventArgs e)
        {
            UtilClass<List<UserInfo>>.SaveObject("users", users);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserInfo ui = new UserInfo(textBox1.Text, textBox2.Text);
            foreach (var item in users)
            {
                if (item.UserName.Equals(ui.UserName))
                {
                    MessageBox.Show("已存在");
                    return;
                }
            }
            users.Add(ui);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserInfo ui = new UserInfo(textBox1.Text, textBox2.Text);
            foreach (var item in users)
            {
                if (item.Equals(ui))
                {
                    MessageBox.Show("成功");
                    return;
                }
                MessageBox.Show("失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Teacher t1 = new Teacher("Tom", "Tom", new UserInfo("11", "11"));
            Teacher t2 = new Teacher("Tom", "Tom", new UserInfo("11", "11"));
            t2 = t1;
            if (t1 == t2)
            {
                MessageBox.Show("t1==t2");
            }
            if (t1.Equals(t2))
            {
                MessageBox.Show("t1.Equals(t2)");
            }

        }
    }

    public class Teacher
    {
        string name;
        string pwd;
        UserInfo ui;

        public Teacher(string name, string pwd, UserInfo ui)
        {
            this.name = name;
            this.pwd = pwd;
            this.ui = ui;
        }

        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   name == teacher.name &&
                   pwd == teacher.pwd &&
                   EqualityComparer<UserInfo>.Default.Equals(ui, teacher.ui);
        }
    }
    [Serializable]


    public class UserInfo
    {
        string userName;
        string password;

        public override string ToString()
        {
            return "userName:" + userName + ",password:" + password;
        }
      
        public UserInfo(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public UserInfo()
        {

        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public override bool Equals(object obj)
        {
            return obj is UserInfo infor &&
                   userName == infor.userName &&
                   password == infor.password;
        }
    }
}


