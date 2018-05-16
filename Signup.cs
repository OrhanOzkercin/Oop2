﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop2
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        Costumer costumer = Costumer.getInstance();
        Image img=Image.getInstance();
        Getdatabase db=Getdatabase.getInstance();
        string path;
        private void btnFoto_Click(object sender, EventArgs e)
        {
            path = img.Connect();
            txtFoto.Text = path;
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            costumer.Username = txtUsername.Text;
            costumer.Name = txtName.Text;
            if (txtPass.Text==txtRepass.Text)
            {
                costumer.Password = txtPass.Text;
            }
            else
            {
                MessageBox.Show("Password are not match!");
            }
           costumer.Adress = txtAdress.Text;
           costumer.Email = txtMail.Text;

           if (radioButton1.Enabled)
            {
                costumer.Gender = true;
            }
            else
            {
                costumer.Gender = false;    
            }
            
            try
            {
                db.UpdateImage(path, txtUsername.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Somethings Wrong!");

            }
            db.CreateCostumer(costumer,path);
           
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                btnFoto.Enabled = false;
                txtFoto.Enabled = false;
                btnSign.Enabled = false;
            }
            else
            {
                btnFoto.Enabled = true;
                txtFoto.Enabled = true;
            }
            txtFoto.Text = "";
        }

        private void txtFoto_TextChanged(object sender, EventArgs e)
        {
            if (txtFoto.Text=="")
            {
                btnSign.Enabled = false;
            }
            else
            {
                btnSign.Enabled = true;
            }
        }
    }
}
