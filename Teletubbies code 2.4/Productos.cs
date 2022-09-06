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
    public partial class Productos : UserControl
    {
        public Productos()
        {
            InitializeComponent();
            pnlProductos.Dock = DockStyle.Fill;
        }

        SqlConnection conexion = new SqlConnection("server=DESKTOP-75N8191;database=tienda2;integrated security=true");

        public void llenar_tabla()
        {
            string consulta = "select*from producto";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "insert into producto values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro agregado");
            llenar_tabla();

            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string consulta = "delete from producto where id_producto=" + textBox1.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");
            llenar_tabla();

            conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "update producto set id_producto=" + textBox1.Text + ",nombre_producto='" + textBox2.Text + "',precio='" + textBox3.Text + "',Cantidad='" + textBox4.Text + "'where id_producto=" + textBox1.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant > 0)
            {
                MessageBox.Show("Registro modificado");
            }
            llenar_tabla();

            conexion.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlProductos_Paint(object sender, PaintEventArgs e)
        {
            string consulta = "select*from producto";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }
    }
}
