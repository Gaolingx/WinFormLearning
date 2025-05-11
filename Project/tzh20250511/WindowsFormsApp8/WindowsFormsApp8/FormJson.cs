using Game3231;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp8
{
    public partial class FormJson : Form
    {
        public FormJson()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            UserInfo us =new UserInfo(textBox1.Text,textBox2.Text);
            UtilClass<UserInfo>.SaveJson("json", us);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfo us = UtilClass<UserInfo>.ReadJson("json");
            if (us==null)
                return;
            textBox1.Text = us.UserName;
            textBox2.Text = us.Password;
        }
        List<UserInfo> list = new List<UserInfo>();
        private void button4_Click(object sender, EventArgs e)
        {
            UserInfo us = new UserInfo(textBox1.Text, textBox2.Text);
            foreach (var item in list)
            {
                if (us.UserName.Equals(item.UserName))
                {
                    MessageBox.Show("存在");
                    return;
                }
            }
            list.Add(us);
            MessageBox.Show("成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserInfo us = new UserInfo(textBox1.Text, textBox2.Text);
            foreach (var item in list)
            {
                if (us.Equals(item))
                {
                    MessageBox.Show("成功");

                    return;
                }
            }
            list.Add(us);
            MessageBox.Show("失败");
        }

        private void FormJson_Load(object sender, EventArgs e)
        {
            

            list=UtilClass<List<UserInfo>>.ReadJson("users.json");
            if (null==list)
            {
                list = new List<UserInfo>();
            }

        }

        private void FormJson_FormClosing(object sender, FormClosingEventArgs e)
        {
            UtilClass<List<UserInfo>>.SaveJson("users",list);
        }
    }
}
