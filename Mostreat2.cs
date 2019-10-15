using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BsalsePro.ClassForm;
using System.Security.Cryptography;

namespace BsalsePro.Dreamsoft
{

    public partial class Mostreat2 : DevExpress.XtraEditors.XtraForm
    {
        Adpta dd = new Adpta();
        int datee;
        int ajel;
        string s;
        Double wer;
        bool q;
        public Mostreat2()
        {
            InitializeComponent();
        }
        public void eev()
        {
            //string a = "1";
            s = dd.FillCombooToText55("Tota_price_gtaee", "T_Proudact", "Proudact_ID", textEdit3.Text);
        }

        public void search() {

            string a;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                   // MessageBox.Show(row.Cells[4].Value.ToString());
                    if (row.Cells[4].Value.ToString().Equals(comboBox1.Text))
                    {
                        dataGridView2.Rows.Add(comboBox4.Text, textEdit1.Text, textEdit4.Text, textEdit5.Text, comboBox1.Text, textEdit3.Text, textEdit2.Text, textEdit10.Text, textEdit11.Text, textEdit11.Text, textEdit9.Text, dateEdit3.DateTime, textBox1.Text, textEdit5.Text, ajel, textEdit6.Text, textEdit7.Text, textEdit17.Text, textEdit13.Text);
                        // savalltodata();
                        // dataGridView2.Rows.Add(comboBox4.Text, textEdit1.Text, textEdit4.Text, comboBox1.Text, textEdit5.Text);
                        // row.Selected = true;
                        break;
                    }
                    else {


                        MessageBox.Show("يجب ان يكون في الفاتورة مورد واحد فقط");
                        break;
                        //dataGridView1.Rows.Add(comboBox4.Text, textEdit1.Text, textEdit4.Text, comboBox1.Text);

                    }

                }

            }
            catch (Exception ex) {
                //savalltodata();

                dataGridView2.Rows.Add(comboBox4.Text, textEdit1.Text, textEdit4.Text, textEdit5.Text, comboBox1.Text, textEdit3.Text, textEdit2.Text, textEdit10.Text, textEdit11.Text, textEdit11.Text, textEdit9.Text, dateEdit3.DateTime, textBox1.Text, textEdit5.Text, ajel, textEdit6.Text, textEdit7.Text, textEdit17.Text, textEdit13.Text);
                // dataGridView2.Rows.Add(comboBox4.Text, textEdit1.Text, textEdit4.Text, comboBox1.Text, textEdit5.Text);
                //MessageBox.Show(ex.Message);
            }


        }
        private void Mostreat2_Load(object sender, EventArgs e)
        {
            //comboBox4.Text = " ";
            //comboBox1.Text = " ";
            //comboBox3.Text = " ";
            //comboBox6.Text = " ";
            checkEdit2.Checked = true;
            textEdit6.Enabled = true;
            textEdit7.Text = "0";
            dateEdit3.DateTime = DateTime.Now;
           combobx();
            //combobo1();
            combobo2();
            combobo3();
            combobo4();
            combobo5();
        }
        public void combobo2()
        {
            if (dd.FillCombo(comboBox1, "Suppliers_name", "T_Suppliers", false, null))
            {
                return;
            }
        }
        public void combobo3()
        {
            if (dd.FillCombo(comboBox3, "Stores_name", "T_Stores", false, null))
            {
                return;
            }
        }
        public void combobo4()
        {
            if (dd.FillCombo(comboBox6, "Currency_name", "T_Currency", false, null))
            {
                return;
            }
        }
        public void combobo5()
        {
            if (dd.FillCombo(comboBox2, "User_name", "T_User", false, null))
            {
                return;
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                checkEdit2.Checked = false;
                ajel = 1;
                textEdit7.Enabled = true;
                textEdit6.Enabled = false;
                textEdit6.Text = "0";
                textEdit7.Text = textEdit4.Text;
                // MessageBox.Show(Convert.ToString(ajel));

            }
            else if (checkEdit2.Checked)
            {
                textEdit6.Text = textEdit4.Text;
                textEdit7.Text = "0";
                checkEdit1.Checked = false;
                ajel = 0;
                textEdit7.Enabled = false;
                textEdit6.Enabled = true;
                // MessageBox.Show(Convert.ToString(ajel));

            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked)
            {
                checkEdit1.Checked = false;


                //MessageBox.Show(Convert.ToString(ajel));
            }
            else if (checkEdit1.Checked)
            {
                checkEdit2.Checked = false;

            }
        }
        public void combobx()
        {

            if (dd.FillCombo(comboBox4, "Proudact_name", "T_Proudact", false, null))
            {
                return;
            }


        }

        public void getallnum()
        {

            try
            {
                double a;
                double c;
                double f;
                double texted4;

                a = Convert.ToDouble(textEdit1.Text);
                c = Convert.ToDouble(textEdit13.Text);
                f = a * c;
                textEdit17.Text = Convert.ToString(f);
                textEdit4.Text = Convert.ToString(a * Convert.ToDouble(s));
                //rty = Convert.ToString(a * Convert.ToDouble(s));

                //double aa;
                //double ccc;
                //double er;
                //double ff;
                //double m;

                //aa = Convert.ToDouble(textEdit4.Text);
                //ccc = Convert.ToDouble(textEdit1.Text);
                //ff = aa / ccc;
                //textEdit6.Text = Convert.ToString(f);
                //er = Convert.ToDouble(textEdit13.Text);
                //m = f / er;
                //textEdit12.Text = Convert.ToString(m);

            }
            catch (Exception)
            {

                return;
            }

        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEdit3.Text = dd.FillCombooToText("Proudact_ID", "T_Proudact", "Proudact_name", comboBox4.Text);
            textEdit2.Text = dd.FillCombooToText("Unit_ID", "T_Proudact", "Proudact_name", comboBox4.Text);
            textEdit13.Text = dd.FillCombooToText55("Units_number", "T_Units", "Units_ID", textEdit2.Text);
            eev();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEdit9.Text = dd.FillCombooToText("Suppliers_ID", "T_Suppliers", "Suppliers_name", comboBox1.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEdit10.Text = dd.FillCombooToText("Stores_ID", "T_Stores", "Stores_name", comboBox3.Text);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEdit11.Text = dd.FillCombooToText("Currency_ID", "T_Currency", "Currency_name", comboBox6.Text);
            textEdit19.Text = dd.FillCombooToText("Currency_symbol", "T_Currency", "Currency_name", comboBox6.Text);
            eev();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            getallnum();
        }

        private void textEdit13_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEdit18.Text = dd.FillCombooToText("User_ID", "T_User", "User_name", comboBox2.Text);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            
            textEdit5.Text = "B" + GetUniqueKey(7) + "";
            simpleButton1.Enabled = true;
            simpleButton3.Enabled = true;
            simpleButton11.Enabled = false;
        }

        public bool check() {

            bool q;
            if (comboBox4.Text == "")
            {

                MessageBox.Show("الرجاء إختيار الصنف");
                return q = false;

            }
            else if (comboBox1.Text == "")
            {

                MessageBox.Show("الرجاء إختيار اسم المورد");
                return q = false;

            }
            else if (comboBox3.Text == "")
            {

                MessageBox.Show("الرجاء إختيار اسم المخزن");
                return q = false;

            }
            else if (comboBox6.Text == "")
            {

                MessageBox.Show("الرجاء إختيار اسم العملة");
                return q = false;

            }
            else if (textEdit1.Text == "")
            {

                MessageBox.Show("الرجاء إدخال الكمية");
                return q = false;

            }
            else if (textEdit4.Text == "")
            {

                MessageBox.Show("الرجاء إدخال السعر الاجمالي");
                return q = false;

            }
            else {

                return q = true;
            }


            return q;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            savefromdatagridviewtodb();
            simpleButton3.Enabled = true;
            // search();

        }
        public void savalltodata() {
            string we = "Proudact_ID,Units_ID,Store_ID,User_ID,Cureency_ID,Suppliers_ID,buy_Date,buy_notes,buy_ballnumber,buy_type,almodfoo,Motabakee";
            //User_ID,Currency_symbol,buy_Date,
            //  string rr =                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "buy_price_for_one_Jomlah,,,,buy_price_for_one_only,,,,,buy_amount,,,,,buy_price_all,,,,,,Salse_price_forone,,,,,,,Salse_price_forall,,,,,,buy_Back,,,,,buy_adfooh,,,,,,,buy_Motabkee,,,,,Date_expireifyes,Date_expirFrom,Date_expir_to,buy_notes,buy_ballnumber,buy_type,User_ID,      Currency_symbol    ,buy_Date";
            // string fd= "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  buy_notes               buy_ballnumber      buy_type                                   User_ID                Currency_symbol                 buy_Date                                ";
            string cb = "insert into T_buyn(" + we + ") VALUES ('" + Convert.ToInt64(textEdit3.Text) + "','" + Convert.ToInt64(textEdit2.Text) + "','" + Convert.ToInt64(textEdit10.Text) + "','" + Convert.ToInt64(textEdit11.Text) + "','" + Convert.ToInt64(textEdit11.Text) + "','" + Convert.ToInt64(textEdit9.Text) + "','" + dateEdit3.DateTime + "','" + textBox1.Text + "','" + textEdit5.Text + "','" + ajel + "','" + Convert.ToDouble(textEdit6.Text) + "','" + Convert.ToDouble(textEdit7.Text) + "')";

            if (dd.Insert(cb))
            {
                ee1();
                if (ajel == 1)
                {

                    savetoajel();
                }
                else
                {

                    return;
                }

            }
            else
            {
                return;
                //MessageBox.Show("ffffffffffffffff");
            }
        }
        public void ee1()
        {
            if (dd.updated12(textEdit3.Text, textEdit10.Text, Convert.ToDouble(textEdit17.Text)))
            {



                return;
            }
            else
            {

                string cbb = "insert into Stor_total(quntaty,Proudat_ID,Store_ID,units_number) VALUES ('" + Convert.ToDouble(textEdit17.Text) + "','" + Convert.ToInt64(textEdit3.Text) + "','" + Convert.ToInt64(textEdit10.Text) + "','" + Convert.ToDouble(textEdit13.Text) + "')";
                if (dd.Insertwith(cbb))
                {

                    //return;
                }

            }
        }

        public void ee11(string proudatID, string Storeid, string quintaty, string unitsd)
        {
            if (dd.updated12(proudatID, Storeid, Convert.ToDouble(quintaty)))
            {



                return;
            }
            else
            {

                string cbb = "insert into Stor_total(quntaty,Proudat_ID,Store_ID,units_number) VALUES ('" + Convert.ToDouble(quintaty) + "','" + Convert.ToInt64(proudatID) + "','" + Convert.ToInt64(Storeid) + "','" + Convert.ToDouble(unitsd) + "')";
                if (dd.Insertwith(cbb))
                {

                    //return;
                }

            }
        }
        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                /*
                Double a;
                Double eff;
                a = Convert.ToDouble(textEdit4.Text);
                eff = Convert.ToDouble(textEdit6.Text);
                textEdit7.Text = Convert.ToString(a - eff);

                Double ww;
                Double tt;
                ww = Convert.ToDouble(textEdit7.Text);
                textEdit22.Text = Convert.ToString( ww- eff);*/


            }
            catch (Exception) {




            }
        }

        public void savetoajel()
        {
            string a = "0";

            string cb = "insert into T_AjelForSupplise(Supplise_ID,AjelForSupplise_daeen,AjelForSupplise_madeen,AjelForSupplise_date,User_ID,Billnumber) VALUES ('" + textEdit9.Text + "','" + Convert.ToDouble(textEdit7.Text) + "','" + Convert.ToDouble(a) + "','" + dateEdit3.DateTime + "','" + textEdit18.Text + "','" + textEdit5.Text + "')";
            if (dd.Insertwith(cb))
            {

                ee();

                //ajel_total_Supplise_name,ajel_total_Supplise_madeen,ajel_total_Supplise_daeen,ajel_total_Supplise_totl

                // return;
                // MessageBox.Show("تم بنجاح");
            }
            else
            {


                return;
                //MessageBox.Show("ffffffffffffffff");
            }

            //AjelForSupplise

        }


        public bool savetoajelvvc(string Supplise_ID,string colum17,string colum16,string Supplise_date,string User_ID,string Billnumber)
        {
            string a = "0";
            bool ss = false;
            string cb = "insert into T_AjelForSupplise(Supplise_ID,AjelForSupplise_daeen,AjelForSupplise_madeen,AjelForSupplise_date,User_ID,Billnumber) VALUES ('" + Supplise_ID + "','" + Convert.ToDouble(colum17) + "','" + Convert.ToDouble(a) + "','" + Convert.ToDateTime(Supplise_date) + "','" + User_ID + "','" + Billnumber + "')";
            if (dd.Insertwith(cb))
            {

                ss = true;
               // ee();

                //ajel_total_Supplise_name,ajel_total_Supplise_madeen,ajel_total_Supplise_daeen,ajel_total_Supplise_totl

                // return;
                // MessageBox.Show("تم بنجاح");
            }
            else
            {


                return false;
                //MessageBox.Show("ffffffffffffffff");
            }

            return ss;

            //AjelForSupplise

        }
        public void rr()
        {

            Double a = 0;
            Double b = 0;
            if (dd.updated(textEdit9.Text, a, a))
            {



                //return;
            }
        }
        public void rr1(string supplisid)
        {

            Double a = 0;
            Double b = 0;
            if (dd.updated(supplisid, a, a))
            {



                //return;
            }
        }

        public void ee()
        {

            string a = "0";

            if (dd.updated(textEdit9.Text, Convert.ToDouble(textEdit7.Text), Convert.ToDouble(a)))
            {


                rr();
               // return;
            }
            else
            {


                string cbb = "insert into T_ajel_total_Supplise(ajel_total_Supplise_name,ajel_total_Supplise_madeen,ajel_total_Supplise_daeen,ajel_total_Supplise_totl) VALUES ('" + Convert.ToInt64(textEdit9.Text) + "','" + Convert.ToDouble(textEdit6.Text) + "','" + Convert.ToDouble(textEdit7.Text) + "','" + Convert.ToDouble(textEdit7.Text) + "')";
                if (dd.Insertwith(cbb))
                {
                    rr();
                    //return;
                }

            }
        }

        public void ee12(string SuppliseID, string colum17, string colum16)
        {

            string a = "0";

            if (dd.updated(SuppliseID, Convert.ToDouble(colum17), Convert.ToDouble(a)))
            {


                rr1(SuppliseID);
                // return;
            }
            else
            {


                string cbb = "insert into T_ajel_total_Supplise(ajel_total_Supplise_name,ajel_total_Supplise_madeen,ajel_total_Supplise_daeen,ajel_total_Supplise_totl) VALUES ('" + Convert.ToInt64(textEdit9.Text) + "','" + Convert.ToDouble(colum16) + "','" + Convert.ToDouble(colum17) + "','" + Convert.ToDouble(colum17) + "')";
                if (dd.Insertwith(cbb))
                {
                    rr1(SuppliseID);
                    //return;
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)


        {
            if (check())
            {

                search();
                simpleButton2.Enabled = true;


            }
        }


        public void savefromdatagridviewtodb() {
            if (check())
            {


                MessageBox.Show("تم الحفظ بنجاح");
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    try
                    {
                        
                        // MessageBox.Show(dataGridView1.Rows[i].Cells["Column3"].Value.ToString());
                        string we = "Proudact_ID,Units_ID,Store_ID,User_ID,Cureency_ID,Suppliers_ID,buy_Date,buy_notes,buy_ballnumber,buy_type,almodfoo,Motabakee";
                        //User_ID,Currency_symbol,buy_Date,
                        //  string rr =                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "buy_price_for_one_Jomlah,,,,buy_price_for_one_only,,,,,buy_amount,,,,,buy_price_all,,,,,,Salse_price_forone,,,,,,,Salse_price_forall,,,,,,buy_Back,,,,,buy_adfooh,,,,,,,buy_Motabkee,,,,,Date_expireifyes,Date_expirFrom,Date_expir_to,buy_notes,buy_ballnumber,buy_type,User_ID,      Currency_symbol    ,buy_Date";
                        // string fd= "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  buy_notes               buy_ballnumber      buy_type                                   User_ID                Currency_symbol                 buy_Date                                ";
                        string cb = "insert into T_buyn(" + we + ") VALUES ('" + Convert.ToInt64(dataGridView2.Rows[i].Cells["Column6"].Value.ToString()) + "','" + Convert.ToInt64(dataGridView2.Rows[i].Cells["Column7"].Value.ToString()) + "','" + Convert.ToInt64(dataGridView2.Rows[i].Cells["Column8"].Value.ToString()) + "','" + Convert.ToInt64(dataGridView2.Rows[i].Cells["Column9"].Value.ToString()) + "','" + Convert.ToInt64(dataGridView2.Rows[i].Cells["Column10"].Value.ToString()) + "','" + Convert.ToInt64(dataGridView2.Rows[i].Cells["Column11"].Value.ToString()) + "','" + Convert.ToDateTime(dataGridView2.Rows[i].Cells["Column12"].Value.ToString()) + "','" + dataGridView2.Rows[i].Cells["Column13"].Value.ToString() + "','" + dataGridView2.Rows[i].Cells["Column14"].Value.ToString() + "','" + Convert.ToInt32(dataGridView2.Rows[i].Cells["Column15"].Value.ToString()) + "','" + Convert.ToDouble(dataGridView2.Rows[i].Cells["Column16"].Value.ToString()) + "','" + Convert.ToDouble(dataGridView2.Rows[i].Cells["Column17"].Value.ToString()) + "')";

                        if (dd.Insertwith(cb))
                        {

                            ee11(dataGridView2.Rows[i].Cells["Column6"].Value.ToString(), dataGridView2.Rows[i].Cells["Column8"].Value.ToString(), dataGridView2.Rows[i].Cells["Column18"].Value.ToString(), dataGridView2.Rows[i].Cells["Column19"].Value.ToString());

                            // MessageBox.Show(dataGridView2.Rows[i].Cells["Column15"].Value.ToString());

                            if (dataGridView2.Rows[i].Cells["Column15"].Value.ToString() == "1")
                            {
                                // MessageBox.Show("ggggggggggggg");
                                if (savetoajelvvc(dataGridView2.Rows[i].Cells["Column6"].Value.ToString(), dataGridView2.Rows[i].Cells["Column17"].Value.ToString(), dataGridView2.Rows[i].Cells["Column16"].Value.ToString(), dataGridView2.Rows[i].Cells["Column12"].Value.ToString(), dataGridView2.Rows[i].Cells["Column9"].Value.ToString(), dataGridView2.Rows[i].Cells["Column14"].Value.ToString()))
                                {

                                    ee12(dataGridView2.Rows[i].Cells["Column11"].Value.ToString(), dataGridView2.Rows[i].Cells["Column17"].Value.ToString(), dataGridView2.Rows[i].Cells["Column16"].Value.ToString());

                                }
                            }
                            else
                            {

                                // return;
                            }

                            //  MessageBox.Show("jjjjjjjjjjjj");

                        }


                    }
                    catch (Exception ex)
                    {

                        return;
                        // MessageBox.Show(ex.Message);
                    }


                }
                //search();

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Column20", typeof(string));
            dt.Columns.Add("Column21", typeof(Int64));
            dt.Columns.Add("Column22", typeof(Double));
            dt.Columns.Add("Column23", typeof(string));
            foreach (DataGridViewRow dgr in dataGridView2.Rows)
            {
                dt.Rows.Add(dgr.Cells[0].Value, dgr.Cells[1].Value, dgr.Cells[2].Value, dgr.Cells[3].Value);
            }
            ds.Tables.Add(dt);
           // ds.WriteXmlSchema(@"D:\Sampleemc.xml");//هذا مهم
            crrport.CrystalReport1 cr = new crrport.CrystalReport1();
            
            cr.SetDataSource(ds);
            frmCryst dd = new frmCryst();
            dd.crystalReportViewer1.ReportSource = cr;
            cr.SetParameterValue("bill", textEdit5.Text);
            cr.SetParameterValue("user", comboBox2.Text);
            cr.SetParameterValue("sup", comboBox1.Text);
            cr.SetParameterValue("mon", comboBox6.Text);
            cr.SetParameterValue("sm", textEdit19.Text);
            dd.Show();
            // dd.crystalReportViewer1.Refresh();

                
            // dataGridView2.Rows.Add(comboBox4.Text,textEdit1.Text,textEdit4.Text, textEdit5.Text, comboBox1.Text, textEdit3.Text,textEdit2.Text,textEdit10.Text,textEdit11.Text,textEdit11.Text,textEdit9.Text,dateEdit3.DateTime, textBox1.Text , textEdit5.Text , ajel ,textEdit6.Text,textEdit7.Text, textEdit17.Text, textEdit13.Text);

            // dataGridView1.Rows.Clear();
            // dataGridView1.Refresh();

        }



        public void sav() {


       
            
               
            
           

        }
    }
}