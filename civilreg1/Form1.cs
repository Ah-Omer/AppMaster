using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace civilreg1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        
        #region Properites
        string Results, Results1, Results2, Results3, flag, z;
     
        DES_Algorithm des = new DES_Algorithm();
        AES_Algorithm aes = new AES_Algorithm();
        RSA_ALGO R = new RSA_ALGO();
      
        CRS_API.CRSMETHOD ws = new CRS_API.CRSMETHOD();
        #endregion

        #region Save Data
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string s = TXTFname.Text + "#" + TXTNnumber.Text + "#" + TXTFaName.Text + "#" + TXTDa.Text + "#" + TXTmo.Text + "#" + TXTYE.Text + "#" + TXTName.Text + "#" + TXTSname.Text + "#" + TXTThName.Text + "#" + TXTfoName.Text + "#" + TXTnNUM.Text + "#" + TXTBstate.Text + "#" + TXTwk.Text + "#" + CBSstatus.Text + "#" + CBbT.Text + "#" + CBGender.Text + "#" + CBQUL.Text + "#" + TXTMN.Text + "#" + TXTBCN.Text + "#" + TXTIDN.Text + "#" + TXTNN.Text + "#" + TXTPB.Text + "#" + TXTAdd.Text + "#" + TXTPW.Text + "#" + TXTFMN.Text + "#" + TXTSMN.Text + "#" + TXTthMN.Text + "#" + TXTfoMN.Text;
            string[] rrrr = s.Split('#');
            CRS_API.CRSMETHOD ws = new CRS_API.CRSMETHOD();
            int r1 = r.Next((s.Length * 10 / 100), (s.Length * 40 / 100));
            string s1 = s.Substring(0, r1);
            string a1 = s.Substring(r1);
            int r2 = r.Next((a1.Length * 10 / 100), (a1.Length * 60 / 100));
            string s2 = a1.Substring(0, r2);
            string s3 = a1.Substring(r2);
            int com = s.CompareTo(s1 + s2 + s3);

            int r3 = r.Next((1), (9));



            if (ws.saveddata(Random_selection(s1, s2, s3)))
            {
                MessageBox.Show("Saved Secsessfull .........");
                clerScreen();
            }
            else
            {
                MessageBox.Show("Eroor ..... ");

            }





        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            TXTIDN.Text = ws.getNatNum();
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;
            panel6.Enabled = true;
            panel8.Enabled = true;
            panel9.Enabled = true;
            panel10.Enabled = true;
            TXTNN.Focus();
            SaveBtn.Enabled = true;
            TestData();
            clerScreen();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            CRS_API.CRSMETHOD ws = new CRS_API.CRSMETHOD();
            Random r = new Random();
            string s = TXTFname.Text + "#" + TXTNnumber.Text + "#" + TXTFaName.Text + "#" + TXTDa.Text + "#" + TXTmo.Text + "#" + TXTYE.Text + "#" + TXTName.Text + "#" + TXTSname.Text + "#" + TXTThName.Text + "#" + TXTfoName.Text + "#" + TXTnNUM.Text + "#" + TXTBstate.Text + "#" + TXTwk.Text + "#" + CBSstatus.Text + "#" + CBbT.Text + "#" + CBGender.Text + "#" + CBQUL.Text + "#" + TXTMN.Text + "#" + TXTBCN.Text + "#" + TXTIDN.Text + "#" + TXTNN.Text + "#" + TXTPB.Text + "#" + TXTAdd.Text + "#" + TXTPW.Text + "#" + TXTFMN.Text + "#" + TXTSMN.Text + "#" + TXTthMN.Text + "#" + TXTfoMN.Text;
            int r1 = r.Next((s.Length * 10 / 100), (s.Length * 40 / 100));
            string s1 = s.Substring(0, r1);
            string a1 = s.Substring(r1);
            int r2 = r.Next((a1.Length * 10 / 100), (a1.Length * 60 / 100));
            string s2 = a1.Substring(0, r2);
            string s3 = a1.Substring(r2);
            int r3 = r.Next((1), (9));

            string enc = Random_selection(s1, s2, s3);

            if (ws.saveddata(enc))
            {
                MessageBox.Show("Saved Secsessfull .........");
                clerScreen();
            }
            else
            {
                MessageBox.Show("Eroor ....................");

            }



        }
        #endregion

        #region Load
        private void Form1_Load(object sender, EventArgs e)
        {
         
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
            panel6.Enabled = false;
            panel8.Enabled = false;
            panel9.Enabled = false;
            panel10.Enabled = false;
            TXTNN.Focus();
            SaveBtn.Enabled = false;
           //TestData();
          
        }

        public void TestData()
        {
            TXTFname.Text = "";
            TXTFaName.Text = "";
            TXTNnumber.Text = "1111";
            TXTDa.Text = "";
            TXTmo.Text = "";
            TXTYE.Text = "";
            TXTName.Text = "";
            TXTSname.Text = "";
            TXTThName.Text = "";
            TXTfoName.Text = "";
            TXTnNUM.Text = "";
            TXTBstate.Text = "";
            TXTwk.Text = " ";
            TXTMN.Text = "";
            TXTBCN.Text = "";
            TXTNN.Text = "";
            TXTFMN.Text = "";
            TXTSMN.Text = "";
            TXTthMN.Text = "";
            TXTfoMN.Text = "";
            TXTPB.Text = "  ";
            TXTPW.Text = " ";
            TXTAdd.Text = " ";
            CBSstatus.SelectedIndex = 4;
            CBbT.SelectedIndex = 1;
            CBGender.SelectedIndex = 0;
            CBQUL.SelectedIndex = 1;


        }

        #endregion

        #region Add New
        private void addBtn_Click(object sender, EventArgs e)
        {
            TXTIDN.Text =  ws.getNatNum();
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;
            panel6.Enabled = true;
            panel8.Enabled = true;
            panel9.Enabled = true;
            panel10.Enabled = true;
            TXTNN.Focus();
            SaveBtn.Enabled = true;
        }

        #endregion

        #region select random
        public string Random_selection(string s1, string s2, string s3)
        {
            Random r = new Random();
            int RandomNum = r.Next((1), (6));
        
            // *********RSA----DES-----AES********flag = !
            if (RandomNum == 1)
            {
                Results1 =  R.Encryption(s1);
                Results2  = des.Encryption(s2);
                Results3  = aes.Encryption(s3);
                flag = "!";
            }
            // *********RSA----AES-----DES********flag =@
            if (RandomNum == 2)
            {
                Results1 =  R.Encryption(s1);
                Results2 = aes.Encryption(s2);
                Results3 = des.Encryption(s3);
                flag = "@";
            }
            // *********AES----RSA-----DES********flag =#
            if (RandomNum == 3)
            {
                Results1 = aes.Encryption(s1);
                Results2 =  R.Encryption(s2);
                Results3 = des.Encryption(s3);
                flag = "#";
            }
            // *********AES----DES-----RSA********flag =$
            if (RandomNum == 4)
            {
                Results1 = aes.Encryption(s1);
                Results2 = des.Encryption(s2);
                Results3 =  R.Encryption(s3);
                flag = "$";
            }
            // *********DES----RSA-----AES********flag =%
            if (RandomNum == 5)
            {
               
                Results1 = des.Encryption(s1);
                Results2 =  R.Encryption(s2);
                Results3 = aes.Encryption(s3);
                flag = "%";

            }
            // *********DES-----AES----RSA********flag =&
            if (RandomNum == 6)
            {
                Results1 = des.Encryption(s1);
                Results2 = aes.Encryption(s2);
                Results3 =  R.Encryption(s3);
                flag = "&";
            }
            Results = flag + Results1 + "õ" + Results2 + "õ" + Results3;


            return Results;
        }
        #endregion

        #region cler Screen
        public void clerScreen()
        {
            TXTIDN.Clear();

            TXTFname.Clear();
            TXTFaName.Clear();
            TXTNnumber.Clear();
            TXTDa.Clear();
            TXTmo.Clear();
            TXTYE.Clear();
            TXTName.Clear();
            TXTSname.Clear();
            TXTThName.Clear();
            TXTfoName.Clear();
            TXTnNUM.Clear();
            TXTBstate.Clear();
            TXTwk.Clear();
            TXTMN.Clear();
            TXTBCN.Clear();
            TXTNN.Clear();
            TXTFMN.Clear();
            TXTSMN.Clear();
            TXTthMN.Clear();
            TXTfoMN.Clear();
            TXTPB.Clear();
            TXTPW.Clear();
            TXTAdd.Clear();
            CBSstatus.SelectedIndex = -1;
            CBbT.SelectedIndex = -1;
            CBGender.SelectedIndex = -1;
            CBQUL.SelectedIndex = -1;

        }
        #endregion
    }
}
