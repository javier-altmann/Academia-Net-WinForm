using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpleadosProyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cargarEmpleados()
        {
            EmpleadoDAO _empleadoDAO = new EmpleadoDAO();

            dataGridView1.DataSource = _empleadoDAO.listadoDeEmpleados();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleado = new EmpleadoDAO();

            empleado.InsertarEmpleado(new EmpleadoDTO()
            {
                nombre = textNombre.Text,
                apellido = textApellido.Text,
                sueldo = Double.Parse(textSueldo.Text)
            });


        }

        private void txtId_Click(object sender, EventArgs e)
        {

        }

        private void txtSueldo_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmpleadoDAO _empleadoDAO = new EmpleadoDAO();
            EmpleadoDTO empleado = _empleadoDAO.consultaEmpleados(int.Parse(textId.Text));
            string sueldo = empleado.sueldo.ToString();

            textNombre.Text = empleado.nombre;
            textApellido.Text = empleado.apellido;
            textSueldo.Text = sueldo;

        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleado = new EmpleadoDAO();
            //empleado.ModificarEmpleado((int.Parse(textId.Text)),textNombre.Text, textApellido.Text, (Double.Parse(textSueldo.Text)));


            empleado.ModificarEmpleado(new EmpleadoDTO()
            {
                Id_Empleado = (int.Parse(textId.Text)),
                nombre = textNombre.Text,
                apellido = textApellido.Text,
                sueldo = Double.Parse(textSueldo.Text)
            });


        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleado = new EmpleadoDAO();
            // empleado.EliminarEmpleado(int.Parse(textId.Text));

            empleado.EliminarEmpleado(new EmpleadoDTO() {
                Id_Empleado = (int.Parse(textId.Text))
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cargarEmpleados();
        }
    }
}
