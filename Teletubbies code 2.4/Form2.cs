using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Teletubbies_code_2._4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=DESKTOP-75N8191;database=tienda2;integrated security=true");


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "select * from vendedor where usuario='" + textBox1.Text + "'and contrasena='" + textBox2.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                Form1 frmbienvenido = new Form1();
                this.Hide();
                frmbienvenido.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto","sistema de teletubbies");
            }
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
