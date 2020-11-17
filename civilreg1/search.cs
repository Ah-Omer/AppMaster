using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace civilreg1
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        #region Properites
        
        CRS_API.CRSMETHOD ws = new CRS_API.CRSMETHOD();
        RSA_ALGO RSA = new RSA_ALGO();
        DES_Algorithm DES = new DES_Algorithm();
        AES_Algorithm AES = new AES_Algorithm();
        string Results, Results1, Results2, Results3;
        #endregion

        #region Search Btn 
        private void sesrchBtn_Click(object sender, EventArgs e)
        {

            string data = "";// ws.(natNum.Text);
            string flag = data.Substring(0, 1);
            string data2 = data.Substring(1);
            string[] a = data2.Split('õ');
            string s1 = a[0];
            string s2 = a[1];
            string s3 = a[2];

            if (flag == "!")
            {
                Results1 = RSA.Decryption(s1);
                Results2 = DES.Decryption(s2);
                Results3 = AES.Decryption(s3);
            }
            if (flag == "@")
            {
                Results1 = RSA.Decryption(s1);
                Results2 = AES.Decryption(s2);
                Results3 = DES.Decryption(s3);
            }
            if (flag == "#")
            {
                Results1 = AES.Decryption(s1);
                Results2 = RSA.Decryption(s2);
                Results3 = DES.Decryption(s3);
            }
            if (flag == "$")
            {
                Results1 = AES.Decryption(s1);
                Results2 = DES.Decryption(s2);
                Results3 = RSA.Decryption(s3);
            }
            if (flag == "%")
            {
                Results1 = DES.Decryption(s1);
                Results2 = RSA.Decryption(s2);
                Results3 = AES.Decryption(s3);
            }
            if (flag == "&")
            {
                Results1 = DES.Decryption(s1);
                Results2 = AES.Decryption(s2);
                Results3 = RSA.Decryption(s3);
            }

            Results = Results1 + Results2 + Results3;

            //string e = r1 + r2 + r3;
            string[] res = Results.Split('#');
            TXTIDN.Text = res[0];
            TXTFname.Text = res[1];
            TXTNnumber.Text = res[8];
            TXTFaName.Text = res[2];
            string[] date = res[3].Split('/') ;
            TXTDa.Text = date[0];
            TXTmo.Text = date[1];
            TXTYE.Text = date[2];
            TXTName.Text = res[4];
            TXTSname.Text = res[5];
            TXTThName.Text = res[6];
            TXTfoName.Text = res[7];
            TXTnNUM.Text = res[16];
            TXTBstate.Text = res[9];
            TXTwk.Text = res[10];
            CBSstatus.Text = res[11];
            CBbT.Text = res[12];
            CBGender.Text = res[13];
            TXTMN.Text = res[14];
            TXTBCN.Text = res[15];
            TXTFMN.Text = res[17];
            TXTSMN.Text = res[18];
            TXTthMN.Text = res[19];
            TXTfoMN.Text = res[20];
            TXTPB.Text = res[21];
            TXTPW.Text = res[22];
            TXTAdd.Text = res[23];
            TXTNN.Text = res[24];
            CBQUL.Text = res[25];
        }
        #endregion

        #region Close Btn
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
