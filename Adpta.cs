using DevExpress.XtraEditors;
using MyLibBandar.DBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace BsalsePro.ClassForm
{
    class Adpta
    {

        OleDbCommand cmd;
        OleDbDataReader rdr = null;
        OleDbConnection con;
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataView dv = new DataView();
        public  bool Insert(string quary) {

            bool d = false;
            if (MessageBox.Show("هــل تريد الحفظ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                // delete_records();
            
                // b();
                try
                {
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    // "SELECT Stor_id_num,Store_name,Owner ,Tele,Avl from Stores";
                    // string cb = "insert into Units(Unitnam,Unit_name,Avl,unitberfor1) VALUES ('" + textEdit2.Text + "','" + textEdit3.Text + "','" + a1 + "','" + textEdit1.Text + "')";

                    cmd = new OleDbCommand(quary);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    d = true;
                }
                catch (Exception ex) {

                    MessageBox.Show(ex.Message);
                }
            }
            return d;

        }

        public bool Insertwith(string quary)
        {

            bool d = false;
            
                // delete_records();

                // b();
                try
                {
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    // "SELECT Stor_id_num,Store_name,Owner ,Tele,Avl from Stores";
                    // string cb = "insert into Units(Unitnam,Unit_name,Avl,unitberfor1) VALUES ('" + textEdit2.Text + "','" + textEdit3.Text + "','" + a1 + "','" + textEdit1.Text + "')";

                    cmd = new OleDbCommand(quary);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                   // MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    d = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            
            return d;

        }
        public bool FillCombo(System.Windows.Forms.ComboBox a, string Column, string table, bool ch, string condation)
        {
            bool f = false;
            try
            {
                if (ch == false)
                {

                    String w = " " + Column + " ";
                    String ww = " " + table + " ";
                    string query = "select " + w + " from " + ww + "";
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Fleet");
                    a.DisplayMember = Column;
                    a.DataSource = ds.Tables["Fleet"];
                    f = true;
                    return f;
                }
                if (ch == true)
                {

                    String w = " " + Column + " ";
                    String ww = " " + table + " ";
                    String ww1 = " " + condation + " ";
                    string query = "select " + w + " from " + ww + " where " + ww1 + "=" + ch + "";
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Fleet");
                    a.DisplayMember = Column;
                    a.DataSource = ds.Tables["Fleet"];
                    f = true;
                    return f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return f;


        }
        public bool FillComb1o(ComboBoxEdit a, string Column, string table, bool ch, string condation)
        {
            bool f = false;
            try
            {
                if (ch == false)
                {

                    String w = " " + Column + " ";
                    String ww = " " + table + " ";
                    string query = "select " + w + " from " + ww + "";
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Fleet");
                    a.Properties.Items.Add(Column);
                    //a.DisplayMember = Column;
                    //a.DataSource = ds.Tables["Fleet"];
                    f = true;
                    return f;
                }
                if (ch == true)
                {

                    String w = " " + Column + " ";
                    String ww = " " + table + " ";
                    String ww1 = " " + condation + " ";
                    string query = "select " + w + " from " + ww + " where " + ww1 + "=" + ch + "";
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Fleet");

                    a.Properties.Items.Add( Column);
                    //a.DisplayMember = Column;
                    //a.DataSource = ds.Tables["Fleet"];
                    f = true;
                    return f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return f;


        }
        public bool raFillCombo(RadDropDownList a, string Column, string table, bool ch, string condation)
        {
            bool f = false;
            try { 
                if (ch == false)
                {

                    String w = " " + Column + " ";
                    String ww = " " + table + " ";
                    string query = "select " + w + " from " + ww + "";
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Fleet");
                    a.DisplayMember = Column;
                    a.DataSource = ds.Tables["Fleet"];
                    f = true;
                    return f;
                }
                if (ch == true)
                {

                    String w = " " + Column + " ";
                    String ww = " " + table + " ";
                    String ww1 = " " + condation + " ";
                    string query = "select " + w + " from " + ww + " where " + ww1 + "=" + ch + "";
                    con = new OleDbConnection(MyConnec.myconn());
                    con.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Fleet");
                    a.DisplayMember = Column;
                    a.DataSource = ds.Tables["Fleet"];
                    f = true;
                    return f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return f;
           

        }

        public  String FillCombooToText(String col, String ta, String whe, String com)
        {



            String qa = null;
            try
            {
                string f="0";
                con = new OleDbConnection(MyConnec.myconn());

                String w = " " + col + " ";
                String ww = " " + ta + " ";
                String ww1 = " " + whe + " ";
                string query = "select " + w + " from " + ww + " where " + ww1 + "='" + com + "'";
                

                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();
                float c;

                OleDbDataReader aad = da.ExecuteReader();
                while (aad.Read())
                {
                    //مجموع الوحدة في الجملة
                    qa = (aad[col].ToString());
                    ////الجملة في الكرتون الواحد
                    // MessageBox.Show(qa);


                }

            

               


            }
            catch (Exception)
            {

               
            }
            return qa;

        }
        /// <summary>
        /// لجلب البيانات عندما نقوم بإختيار من الكمبوبوكس
        /// </summary>
        /// <param name="col"></param>
        /// <param name="ta"></param>
        /// <param name="whe"></param>
        /// <param name="com"></param>
        
                                                    
            /// <returns></returns>
        public String[] FillCombooToText120(String[] col, String ta, String whe, String com)
        {


            

            String[] myreturn =new String[col.Length];

            String qa = null;
          
            for (int i = 0; i < col.Length; i++)
            {
                string f = "0";
                con = new OleDbConnection(MyConnec.myconn());

                String w = " " + col[i]+ " ";
                String ww = " " + ta + " ";
                String ww1 = " " + whe + " ";
                string query = "select " + w + " from " + ww + " where " + ww1 + "='" + com + "'";


                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();
                float c;

                OleDbDataReader aad = da.ExecuteReader();
                while (aad.Read())
                {

                    
                    myreturn[i]= aad[col[i]].ToString();
                 


                }
                con.Close();






            }
            return myreturn;

        }
        public String FillCombooToText55(String col, String ta, String whe, String com)
        {

            String qa = null;



            try
            {



                con = new OleDbConnection(MyConnec.myconn());

                String w = " " + col + " ";
                String ww = " " + ta + " ";
                String ww1 = " " + whe + " ";
                string query = "select " + w + " from " + ww + " where " + ww1 + "=" + com + "";


                OleDbCommand da = new OleDbCommand(query, con);

                con.Open();

                float c;

                OleDbDataReader aad = da.ExecuteReader();


                while (aad.Read())
                {
                    //مجموع الوحدة في الجملة
                    qa = (aad[col].ToString());
                    ////الجملة في الكرتون الواحد
                    // MessageBox.Show(qa);


                }


                con.Close();
            }
            catch (Exception) {


            }
            return qa;

           




        }
        public String FillCombooToText66(String col, String ta, String whe, String com)
        {

            String qa = null;

            try
            {
                con = new OleDbConnection(MyConnec.myconn());

                String w = " " + col + " ";
                String ww = " " + ta + " ";
                String ww1 = " " + whe + " ";
                string query = "select " + w + " from " + ww + " where " + ww1 + "=" + com + "";


                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();
                float c;

                OleDbDataReader aad = da.ExecuteReader();
                while (aad.Read())
                {
                    //مجموع الوحدة في الجملة
                    qa = (aad[col].ToString());
                    ////الجملة في الكرتون الواحد
                    // MessageBox.Show(qa);


                }

            }
            catch (Exception ex)
            {

                return qa;
            }
            return qa;






        }
        public Int64 FillCombooToText2(String col, String ta, String whe, String com, String ee, String ee1)
        {


            Int64 qa = 0;

            con = new OleDbConnection(MyConnec.myconn());
            try
            {
                String w = " " + col + " ";
            String ww = " " + ta + " ";
            String ww1 = " " + whe + " ";
            String ww11 = " " + ee + " ";
            String ww112 = " " + ee1 + " ";
            string query = "select " + w + " from " + ww + " where " + ww1 + "=" + Convert.ToInt64(com )+ " and " + ww11 + "=" + Convert.ToInt64(ww112) + "";
            
            
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();
                float c;

                OleDbDataReader aad = da.ExecuteReader();
                while (aad.Read())
                {
                    //مجموع الوحدة في الجملة
                    qa = Convert.ToInt64((aad[col].ToString()));
                    ////الجملة في الكرتون الواحد
                    // MessageBox.Show(qa);


                }

            }
            catch (Exception) {

                
            }

            return qa;




        }

        public bool Filldatagridviw(DataGridView dataGridView1,int coumn,string coumnname,string coundation) {
            bool d = false;
            try
            {
                Connecteddata dd = new Connecteddata();
              
                dd.cs = MyConnec.myconn();
                dd.Bfilldatagridview(dataGridView1, 2, coumnname, coundation);
                d = true;
            }


            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return d;

        }



        public bool updated(string at,Double daeenn,Double madeenn)
        {

            bool w = false;
            try
            {
                float a;
               // int aa = 1;
                // String ad = "hello";
                string query = "select ajel_total_Supplise_madeen,ajel_total_Supplise_daeen  from T_ajel_total_Supplise where ajel_total_Supplise_name=" + Convert.ToInt64(at) + "";
                con = new OleDbConnection(MyConnec.myconn());
              
                string daeen;
                string madeen;
                Double d;
                Double mad;
                Double ress;
                // String qa1;
                //String ww = null;
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();

                OleDbDataReader aad = da.ExecuteReader();

                if (aad.Read())
                {
                    w = true;
                     madeen = (aad["ajel_total_Supplise_madeen"].ToString());
                    daeen = (aad["ajel_total_Supplise_daeen"].ToString());

                    mad = Convert.ToDouble(madeen);
                    d = Convert.ToDouble(daeen);
                    ress = d - mad;

                    
                        updat1(Convert.ToString(d + daeenn), Convert.ToString(mad + madeenn), at.ToString(), Convert.ToString(ress));
                    
                    //  updat1();

                    //dd.Text

                    // MessageBox.Show("تم الدخول");
                }
                else
                {

                    return w;
                    // MessageBox.Show("قد يكون خطاء");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return w;

        }

        public bool updatedCustomers(string at, Double daeenn, Double madeenn)
        {

            bool w = false;
            try
            {
                float a;
                // int aa = 1;
                // String ad = "hello";
                string query = "select ajel_total_Customers_madeen,ajel_total_Customers_daeen  from T_ajel_total_Customers where ajel_total_Customers_name=" + Convert.ToInt64(at) + "";
                con = new OleDbConnection(MyConnec.myconn());

                string daeen;
                string madeen;
                Double d;
                Double mad;
                Double ress;
                // String qa1;
                //String ww = null;
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();

                OleDbDataReader aad = da.ExecuteReader();

                if (aad.Read())
                {
                    w = true;
                    madeen = (aad["ajel_total_Customers_madeen"].ToString());
                    daeen = (aad["ajel_total_Customers_daeen"].ToString());

                    mad = Convert.ToDouble(madeen);
                    d = Convert.ToDouble(daeen);
                    ress = d - mad;


                    updat1Costomer(Convert.ToString(d + daeenn), Convert.ToString(mad + madeenn), at.ToString(), Convert.ToString(ress));

                    //  updat1();

                    //dd.Text

                    // MessageBox.Show("تم الدخول");
                }
                else
                {

                    return w;
                    // MessageBox.Show("قد يكون خطاء");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return w;

        }

        public bool updated123vv(string at, Double daeenn, Double madeenn)
        {

            bool w = false;
            try
            {
                float a;
                // int aa = 1;
                // String ad = "hello";
                string query = "select ajel_total_Supplise_madeen,ajel_total_Supplise_daeen  from T_ajel_total_Supplise where ajel_total_Supplise_name=" + Convert.ToInt64(at) + "";
                con = new OleDbConnection(MyConnec.myconn());

                string daeen;
                string madeen;
                Double d;
                Double mad;
                Double ress;
                // String qa1;
                //String ww = null;
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();

                OleDbDataReader aad = da.ExecuteReader();

                if (aad.Read())
                {
                    w = true;
                    madeen = (aad["ajel_total_Supplise_madeen"].ToString());
                    daeen = (aad["ajel_total_Supplise_daeen"].ToString());

                    mad = Convert.ToDouble(madeen);
                    d = Convert.ToDouble(daeen);
                    ress = d - mad;

                    if (d <= mad)
                    {
                        
                        return false;
                    }
                    else
                    {
                        updat1(Convert.ToString(d + daeenn), Convert.ToString(mad + madeenn), at.ToString(), Convert.ToString(ress));
                    }
                    //  updat1();

                    //dd.Text

                    // MessageBox.Show("تم الدخول");
                }
                else
                {

                    return w;
                    // MessageBox.Show("قد يكون خطاء");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return w;

        }

        public bool updatedAjel(string at, Double daeenn, Double madeenn)
        {

            bool w = false;
            try
            {
                float a;
                // int aa = 1;
                // String ad = "hello";
                string query = "select ajel_total_Supplise_madeen,ajel_total_Supplise_daeen  from T_ajel_total_Supplise where ajel_total_Supplise_name=" + Convert.ToInt64(at) + "";
                con = new OleDbConnection(MyConnec.myconn());

                string daeen;
                string madeen;
                Double d;
                Double mad;
                Double ress;
                // String qa1;
                //String ww = null;
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();

                OleDbDataReader aad = da.ExecuteReader();

                if (aad.Read())
                {
                    w = true;
                    madeen = (aad["ajel_total_Supplise_madeen"].ToString());
                    daeen = (aad["ajel_total_Supplise_daeen"].ToString());

                    mad = Convert.ToDouble(madeen);
                    d = Convert.ToDouble(daeen);
                    ress = d - mad;
                    updat1(Convert.ToString(d + daeenn), Convert.ToString(mad + madeenn), at.ToString(), Convert.ToString(ress));

                    //  updat1();

                    //dd.Text

                    // MessageBox.Show("تم الدخول");
                }
                else
                {

                    return w;
                    // MessageBox.Show("قد يكون خطاء");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return w;

        }
        public void updat1(string daeen,string madeen,string cond,string result)
        {

            try
            {
               
                // Store_name,Owner,Tele,Avl,Stor_id_num
                con = new OleDbConnection(MyConnec.myconn());
                con.Open();
                //ajel_total_Supplise_totl
                String er = "update T_ajel_total_Supplise set ajel_total_Supplise_madeen='" + Convert.ToDouble(madeen) + "',ajel_total_Supplise_daeen='" + Convert.ToDouble(daeen) + "',ajel_total_Supplise_totl='" + Convert.ToDouble(result) + "'where ajel_total_Supplise_name=" + Convert.ToInt64(cond) + "";
                // String cb = "update Stores set Store_name= " + textEdit3.Text + ",Owner= " + textEdit4.Text + ",Tele= " + textEdit5.Text + ",Avl=" + a1 + "";
                cmd = new OleDbCommand(er);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
               // MessageBox.Show("تم التعديل بنجاح");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updat1Costomer(string daeen, string madeen, string cond, string result)
        {

            try
            {

                // Store_name,Owner,Tele,Avl,Stor_id_num
                con = new OleDbConnection(MyConnec.myconn());
                con.Open();
                //ajel_total_Supplise_totl
                String er = "update T_ajel_total_Customers set ajel_total_Customers_madeen='" + Convert.ToDouble(madeen) + "',ajel_total_Customers_daeen='" + Convert.ToDouble(daeen) + "',ajel_total_Customers_totl='" + Convert.ToDouble(result) + "'where ajel_total_Customers_name=" + Convert.ToInt64(cond) + "";
                // String cb = "update Stores set Store_name= " + textEdit3.Text + ",Owner= " + textEdit4.Text + ",Tele= " + textEdit5.Text + ",Avl=" + a1 + "";
                cmd = new OleDbCommand(er);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                // MessageBox.Show("تم التعديل بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updat1vc(string cond, string result)
        {

            try
            {

                // Store_name,Owner,Tele,Avl,Stor_id_num
                con = new OleDbConnection(MyConnec.myconn());
                con.Open();
                //ajel_total_Supplise_totl
                String er = "update T_ajel_total_Supplise set ajel_total_Supplise_totl='" + Convert.ToDouble(result) + "'where ajel_total_Supplise_name=" + Convert.ToInt64(cond) + "";
                // String cb = "update Stores set Store_name= " + textEdit3.Text + ",Owner= " + textEdit4.Text + ",Tele= " + textEdit5.Text + ",Avl=" + a1 + "";
                cmd = new OleDbCommand(er);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                // MessageBox.Show("تم التعديل بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool updated12(string proudact_ID, string Store_ID, Double quantaty)
        {

            bool w = false;
            try
            {
                float a;
                // int aa = 1;
                // String ad = "hello";
                string query = "select quntaty  from Stor_total where Proudat_ID=" +Convert.ToInt32(proudact_ID.ToString()) + "and Store_ID=" + Convert.ToInt32(Store_ID.ToString()) + "";
                con = new OleDbConnection(MyConnec.myconn());

                string daeen;
                string quantatiy;
                Double d;
                Double mad;
                // String qa1;
                //String ww = null;
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();

                OleDbDataReader aad = da.ExecuteReader();

                if (aad.Read())
                {
                    w = true;
                    quantatiy = (aad["quntaty"].ToString());
                    // daeen = (aad["ajel_total_Supplise_daeen"].ToString());

                    //mad = Convert.ToDouble(madeen);
                    d = Convert.ToDouble(quantatiy);


                  
                    //mad = d  + quantaty;

                    //updat1(Convert.ToString(d + daeenn), Convert.ToString(mad + madeenn), at.ToString());

                    updat1121(Convert.ToString(d + quantaty), Store_ID.ToString(), proudact_ID.ToString());
                    //  updat1();

                    //dd.Text

                    // MessageBox.Show("تم الدخول");
                }
                else
                {

                    return w;
                    // MessageBox.Show("قد يكون خطاء");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"bbbbbb");
            }

            return w;

        }
        public bool updated1212(string proudact_ID, string Store_ID, Double quantaty)
        {

            bool w = false;
            try
            {
                float a;
                // int aa = 1;
                // String ad = "hello";
                string query = "select quntaty  from Stor_total where Proudat_ID=" + Convert.ToInt32(proudact_ID.ToString()) + "and Store_ID=" + Convert.ToInt32(Store_ID.ToString()) + "";
                con = new OleDbConnection(MyConnec.myconn());

                string daeen;
                string quantatiy;
                Double d;
                Double mad;
                // String qa1;
                //String ww = null;
                OleDbCommand da = new OleDbCommand(query, con);
                con.Open();

                OleDbDataReader aad = da.ExecuteReader();

                if (aad.Read())
                {
                    w = true;
                    quantatiy = (aad["quntaty"].ToString());
                    // daeen = (aad["ajel_total_Supplise_daeen"].ToString());

                    //mad = Convert.ToDouble(madeen);
                    d = Convert.ToDouble(quantatiy);


                    if (quantaty<d)
                    {


                        //mad = d  + quantaty;

                        //updat1(Convert.ToString(d + daeenn), Convert.ToString(mad + madeenn), at.ToString());

                        updat1121(Convert.ToString(d - quantaty), Store_ID.ToString(), proudact_ID.ToString());
                        return true;
                    }
                    else {

                        MessageBox.Show("عفوا الكمية المدخلة اكبر من الكمية الموجودة في المخزن");

                    }
                        //  updat1();

                    //dd.Text

                    // MessageBox.Show("تم الدخول");
                }
                else
                {

                    return w;
                    // MessageBox.Show("قد يكون خطاء");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "bbbbbb");
            }

            return w;

        }
        public void updat1121(string quantaty, string Store_ID, string proudact_ID)
        {

            try
            {

                // Store_name,Owner,Tele,Avl,Stor_id_num
                con = new OleDbConnection(MyConnec.myconn());
                con.Open();

                String er = "update Stor_total  set quntaty=" + Convert.ToDouble(quantaty) + " where Proudat_ID=" + Convert.ToInt64(proudact_ID.ToString()) + "and Store_ID=" + Convert.ToInt64(Store_ID.ToString()) + "";
                // String cb = "update Stores set Store_name= " + textEdit3.Text + ",Owner= " + textEdit4.Text + ",Tele= " + textEdit5.Text + ",Avl=" + a1 + "";
                cmd = new OleDbCommand(er);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                // MessageBox.Show("تم التعديل بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"hhhhhh");
            }
        }


    }
}
