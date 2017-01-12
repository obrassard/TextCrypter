using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextCrypter
{
    public partial class TextCrypter : Form
    {
        int rail = 3;

        public TextCrypter()
        {
            InitializeComponent();
        }
        private void UPPER()
        {
            txtInput.Text = txtInput.Text.ToUpper();
        }
        private string CompleterInput()
        {
            string textInput = txtInput.Text;

            rail = (int)numRails.Value;
            while (textInput.Length %rail != 0)
            {
                textInput += "%";
            }
            return textInput.ToUpper() ;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            UPPER();
            string motAEncrypter = CompleterInput();
            char[,] tabEncryption = new char[rail, motAEncrypter.Length / rail];

            //placer les caractère en colonnes
            int indexCaractere = 0;
            for (int col=0; col<tabEncryption.GetLength(1); col++)
            {
                for (int row=0; row<tabEncryption.GetLength(0); row++)
                {
                    tabEncryption[row, col] = motAEncrypter[indexCaractere];
                    indexCaractere++;
                }
            }

            //retourner le résultat lut normalement
            string motCrypté = "";
            for (int row = 0; row < tabEncryption.GetLength(0); row++)
            {
                for (int col = 0; col < tabEncryption.GetLength(1); col++)
                {
                    motCrypté += tabEncryption[row, col];
                }
            }

            txtOutput.Text = motCrypté;

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            UPPER();
            rail = (int)numRails.Value;
            string motADecrypter = txtInput.Text;
            char[,] tabDecrypt = new char[rail, motADecrypter.Length / rail];

            int indexCaractere = 0;
            for (int row = 0; row < tabDecrypt.GetLength(0); row++)
            {
                for (int col = 0; col < tabDecrypt.GetLength(1); col++)
                {
                    tabDecrypt[row, col] = motADecrypter[indexCaractere];
                    indexCaractere++;
                }
            }

            string motClair = "";
            for (int col = 0; col < tabDecrypt.GetLength(1); col++)
            {
                for (int row = 0; row < tabDecrypt.GetLength(0); row++)
                {
                    motClair += tabDecrypt[row, col];
                }
            }

            txtOutput.Text = motClair.ToUpper();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/obrassard");
            MessageBox.Show("[v1.0] - Codé par Olivier Brassard, 2017.");
        }
    }
}
