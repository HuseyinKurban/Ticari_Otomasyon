﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtmail.Text = mail;
        }



        private void btngonder_Click(object sender, EventArgs e)
        {

            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("tcan6623@gmail.com", "Abc.1234.l");
            istemci.Host = "smtp.gmail.com";
            istemci.Port = 587;
            istemci.EnableSsl = true;
            mesaj.To.Add(txtmail.Text);
            mesaj.From = new MailAddress("tcan6623@gmail.com");
            mesaj.Subject = txtkonu.Text;
            mesaj.Body = rchtxtmesaj.Text;
            istemci.Send(mesaj);
            MessageBox.Show("Mail Başarılı Bir Şekilde Gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

