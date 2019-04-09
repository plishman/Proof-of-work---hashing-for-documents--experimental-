using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;
using System.Globalization;

namespace powapptest
{
    public partial class Form1 : Form
    {
        private string texttoprocess = "";
        private ulong secondselapsed = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private byte[] calcMd5Sum(String text)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] md5hash = md5.ComputeHash(bytes);
            return md5hash;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            byte[] md5sum = calcMd5Sum(textBox1.Text);
            txtMd5Sum.Text = ByteArrayToString(md5sum);
            texttoprocess = textBox1.Text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ResetTimerDisplay();
            tmrComputationTimer.Start();
            doProofOfWork(texttoprocess);
            tmrComputationTimer.Stop();
        }

        private void doProofOfWork(string text)
        {
            int salt_num = 0;

            if (txtMod.Text == "") txtMod.Text = "10";
            BigInteger modulo = BigInteger.Parse(txtMod.Text);

            if (modulo == 0)
            {
                modulo = 10;
                txtMod.Text = "10";
            }

            string strPow = "<pow salt=\"" + salt_num.ToString() + "\" mod=\"" + modulo.ToString() + "\"/>";
            string currtext = text + strPow;

            byte[] md5sum = calcMd5Sum(currtext);
            string strMd5Sum = ByteArrayToString(md5sum);

            BigInteger bigintMd5Sum = BigInteger.Parse(strMd5Sum, NumberStyles.AllowHexSpecifier);
            BigInteger count = 0;

            while (bigintMd5Sum % modulo != 0)
            {
                count++;

                if (count % 100 == 0) Application.DoEvents();

                currtext = text;
                salt_num++;
                strPow = "<pow salt=\"" + salt_num.ToString() + "\" mod=\"" + modulo.ToString() + "\"/>";
                currtext += strPow;

                md5sum = calcMd5Sum(currtext);
                strMd5Sum = ByteArrayToString(md5sum);
                bigintMd5Sum = BigInteger.Parse(strMd5Sum, NumberStyles.AllowHexSpecifier);
            }

            textBox1.Text = currtext;
            txtMd5SummodMod.Text = (bigintMd5Sum % modulo).ToString();
            txtMd5Sum.Text = strMd5Sum;
            txtNumIterations.Text = count.ToString();
            txtFoundSaltValue.Text = salt_num.ToString();
        }

        void doProofOfWorkTest(string text)
        {
            if (txtMod.Text == "") txtMod.Text = "10";
            BigInteger modulo = BigInteger.Parse(txtMod.Text);

            if (modulo == 0)
            {
                modulo = 10;
                txtMod.Text = "10";
            }

            byte[] md5sum = calcMd5Sum(text);
            string strMd5Sum = ByteArrayToString(md5sum);

            BigInteger bigintMd5Sum = BigInteger.Parse(strMd5Sum, NumberStyles.AllowHexSpecifier);
            BigInteger result = bigintMd5Sum % modulo;

            txtTestResult.Text = result.ToString();           
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            doProofOfWorkTest(textBox1.Text);
        }

        private void tmrComputationTimer_Tick(object sender, EventArgs e)
        {
            secondselapsed++;
            SetTimerDisplay();
            tmrComputationTimer.Start();
        }

        private void ResetTimerDisplay()
        {
            tmrComputationTimer.Stop();
            tmrComputationTimer.Interval = 1000;
            secondselapsed = 0;
            SetTimerDisplay();
        }

        private void SetTimerDisplay()
        {
            ulong hours = secondselapsed / 3600;
            ulong minutes = (secondselapsed / 60) % 60;
            ulong seconds = secondselapsed % 60;
            lblStopwatch.Text = string.Format("{0}:{1}:{2}",hours.ToString("000"), minutes.ToString("00"), seconds.ToString("00"));
        }

    }
}
