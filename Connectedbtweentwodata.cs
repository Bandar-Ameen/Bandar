using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication12
{
    public partial class Connectedbtweentwodata : Form
    {
        // OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bandaraccounting.accdb;");
        int sa;
        public Connectedbtweentwodata()
        {
            InitializeComponent();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                sa = 0;
                label2.Visible = true;
                comboBox1.Visible = true;
            }
        }

        private void Connectedbtweentwodata_Load(object sender, EventArgs e)
        {

            AppSetting setting = new AppSetting();
            // setting.SaveConnectionString("acc", connectionStringg);
            try
            {
                int s = Convert.ToInt32(setting.GetConnectionString("cnn"));
                if (s == 1)
                {
                    groupBox1.Visible = true;
                    this.Text = "تسجيـــل دخول";
                    radioButton2.Checked = true;
                    label4.Text = "اكسس الان متصل يقاعدة اليانات";
                  
                }
                else if (s == 0)
                {
                    this.Text = "تسجيـــل دخول";
                    radioButton1.Checked = true;
                    label4.Text = " الان متصل يقاعدة اليانات اس كيو إل";
                    groupBox1.Visible = true;
                }
                else
                {
                    this.Text = "إعدادات قاعدة البيانات";
                    label3.Text = "الرجاء تحديد قاعدة البيانات";
                    groupBox2.Visible = true;
                }
            }
            catch (Exception) {
                groupBox2.Visible = true;
                this.Text = "إعدادات قاعدة البيانات";
                label3.Text = "الرجاء تحديد قاعدة البيانات";
            }
            // radioButton2.Checked = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                sa = 1;
                label2.Visible = false;
                comboBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                String connectionStringg = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\" + textBox1.Text + ".accdb;";
                try
                {
                    SqlHelper helper = new SqlHelper(1, connectionStringg);
                    if (helper.IsConnection1) MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButton1.Checked == true)
            {
                string ff = @"Data Source =DESKTOP-4KP68NB\BANDARAMEEN; Initial Catalog=" + textBox1.Text + "; Integrated Security=true;";
                // String connectionStringg = @"Data Source=DESKTOP-4KP68NB\BANDARAMEEN;Initial Catalog=cc;Integrated Security;";
                try
                {
                    SqlHelper helper = new SqlHelper(ff);
                    if (helper.IsConnection) MessageBox.Show("Test connection Sql.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                String connectionStringg = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\" + textBox1.Text + ".accdb;";
                try
                {

                    SqlHelper helper = new SqlHelper(1,connectionStringg);
                    if (helper.IsConnection1)
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("acc", connectionStringg);
                        setting.SaveConnectionString("cnn", Convert.ToString(sa));
                        MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // this.Hide();
                        Application.Restart();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButton1.Checked == true)
            {
                string ff = @"Data Source =DESKTOP-4KP68NB\BANDARAMEEN; Initial Catalog=" + textBox1.Text + "; Integrated Security=true;";
                try
                {

                    SqlHelper helper = new SqlHelper(ff);
                    if (helper.IsConnection)
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("mycon", ff);
                        setting.SaveConnectionString("cnn", Convert.ToString(sa));
                        MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                        //this.Refresh();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Application.Restart();
            //MessageBox.Show(Convert.ToString(sa));
        }
    }
    public class SqlHelperg
    {
        SqlConnection cn;
        OleDbConnection cnn;
        public SqlHelperg(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }
        public SqlHelperg(int a, string connectionString)
        {
            int s = 1;
            a = s;
            cnn = new OleDbConnection(connectionString);
            //cnn.Open();
        }
        public bool IsConnection
        {
            get
            {
                if
                  (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }

        public bool IsConnection1
        {
            get
            {
                if
                  (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                return true;
            }
        }
    }
    public class AppSettingf
    {
        Configuration config;
        public AppSettingf()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }          //Get connection string from App.Config file      
        public string GetConnectionString(string key)
        {

            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        //Save connection string to App.config file        
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }

    }

    /*

    هذا اب
    <?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="cn" connectionString="Data Source=.;Initial Catalog=Northwind;User ID=sa;Password=123@qaz?;" providerName="System.Data.SqlClient"/>
   <add name="cnn" connectionString=" "/>
    <add name="mycon" connectionString="0"/>
    <add name="acc" connectionString="0"/>
  
</connectionStrings>

</configuration>
    
    */
}
