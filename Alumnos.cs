using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultasLINQ
{
    public partial class Alumnos : Form
    {
        ConsultasAlumnos objAlumno = new ConsultasAlumnos();
        string acción;

        public Alumnos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtAlumnoID.Text != "")
            {
                objAlumno.BuscarAlumno(txtAlumnoID, txtNombre, txtDirección, txtEdad, txtCarrera);
                if(txtAlumnoID.Text != "")
                {
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un ID de alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtAlumnoID.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtAlumnoID.Enabled = false;
            txtNombre.Enabled = true;
            txtDirección.Enabled = true;
            txtEdad.Enabled = true;
            txtCarrera.Enabled = true;

            txtAlumnoID.Text = "";
            txtNombre.Text = "";
            txtDirección.Text = "";
            txtEdad.Text = "";
            txtCarrera.Text = "";

            txtNombre.Focus();
            acción = "agregar";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtAlumnoID.Enabled = false;
            txtNombre.Enabled = true;
            txtDirección.Enabled = true;
            txtEdad.Enabled = true;
            txtCarrera.Enabled = true;

            txtNombre.Focus();
            acción = "actualizar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDirección.Text != "" && txtEdad.Text != "" && txtCarrera.Text != "")
            {
                if (acción == "agregar")
                {
                    objAlumno.GuardarAlumno(txtNombre, txtDirección, txtEdad, txtCarrera);
                }
                else if (acción == "actualizar")
                {
                    objAlumno.ActualizarAlumno(txtAlumnoID, txtNombre, txtDirección, txtEdad, txtCarrera);
                }

                btnBuscar.Enabled = true;
                btnAgregar.Enabled = true;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;

                txtAlumnoID.Enabled = true;
                txtNombre.Enabled = false;
                txtDirección.Enabled = false;
                txtEdad.Enabled = false;
                txtCarrera.Enabled = false;

                txtAlumnoID.Text = "";
                txtNombre.Text = "";
                txtDirección.Text = "";
                txtEdad.Text = "";
                txtCarrera.Text = "";

                acción = "";
                txtAlumnoID.Focus();
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos de texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtAlumnoID.Text != "")
            {
                objAlumno.EliminarAlumno(txtAlumnoID);

                btnBuscar.Enabled = true;
                btnAgregar.Enabled = true;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;

                txtAlumnoID.Enabled = true;
                txtNombre.Enabled = false;
                txtDirección.Enabled = false;
                txtEdad.Enabled = false;
                txtCarrera.Enabled = false;

                txtNombre.Text = "";
                txtDirección.Text = "";
                txtEdad.Text = "";
                txtCarrera.Text = "";
            }
            else
            {
                MessageBox.Show("Debes ingresar un ID de alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtAlumnoID.Focus();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            objAlumno.MostrarTodos(dgvAlumnos);
        }

        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo puedes ingresar números en este campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void soloLetras(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo puedes ingresar letras en este campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            txtAlumnoID.Enabled = true;
            txtNombre.Enabled = false;
            txtDirección.Enabled = false;
            txtEdad.Enabled = false;
            txtCarrera.Enabled = false;

            if (acción == "agregar")
            {
                txtAlumnoID.Text = "";
                txtNombre.Text = "";
                txtDirección.Text = "";
                txtEdad.Text = "";
                txtCarrera.Text = "";
            } else if (acción == "actualizar")
            {
                if (txtAlumnoID.Text != "")
                {
                    objAlumno.BuscarAlumno(txtAlumnoID, txtNombre, txtDirección, txtEdad, txtCarrera);
                    if (txtAlumnoID.Text != "")
                    {
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Debes ingresar un ID de alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            acción = "";
            txtAlumnoID.Focus();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            txtAlumnoID.Focus();
        }
    }
}
