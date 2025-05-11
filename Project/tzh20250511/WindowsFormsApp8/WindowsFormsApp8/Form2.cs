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
namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Dictionary<string, string> yx;
        Dictionary<string, Dictionary<string, string>> zy;
        private void Form2_Load(object sender, EventArgs e)
        {
            yx = UtilClass<Dictionary<string, string>>.ReadJson("yx.json");

            zy = UtilClass<Dictionary<string, Dictionary<string, string>>>.ReadJson("zy.json");

            Bangd(yx, comboBox1);
            Bangd(zy["1"], comboBox2);
        }

        private void Bangd(Dictionary<string, string> dic,ComboBox cb)
        {
            DataTable data= new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("name");
            foreach (var item in dic)
            {
                DataRow dr = data.NewRow();
                dr["id"] = item.Key;
                dr["name"] = item.Value;
                data.Rows.Add(dr);

            }
            cb.DataSource = data;
            cb.DisplayMember = "Name";
            cb.ValueMember = "id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  yx=comboBox1.SelectedValue.ToString();
            try
            {
                Bangd(zy[yx], comboBox2);
            }
            catch (Exception)
            {

          
            }
         
        }
    }
}
