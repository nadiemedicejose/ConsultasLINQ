using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultasLINQ
{
    class ConsultasAlumnos
    {
        SQLConnectionDBEscuelaDataContext dbEscuela = new SQLConnectionDBEscuelaDataContext();

        public void GuardarAlumno(TextBox nombre, TextBox dirección, TextBox edad, TextBox carrera)
        {
            Estudiante objAlumno = new Estudiante();

            try
            {
                objAlumno.Nombre = nombre.Text;
                objAlumno.Dirección = dirección.Text;
                objAlumno.Edad = Convert.ToInt32(edad.Text);
                objAlumno.Carrera = carrera.Text;

                dbEscuela.Estudiantes.InsertOnSubmit(objAlumno);

                dbEscuela.SubmitChanges();
                MessageBox.Show("Ingresaste un nuevo estudiante", "Éxito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nombre.Text = "";
                dirección.Text = "";
                edad.Text = "";
                carrera.Text = "";
            } catch (Exception error)
            {
                MessageBox.Show("Error al ingresar un nuevo estudiante: " + error.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarTodos(DataGridView dgvAlumnos)
        {
            var Registros = from valor in dbEscuela.Estudiantes
                            select valor;
            dgvAlumnos.DataSource = Registros;
        }

        public void ActualizarAlumno(TextBox idAlumno, TextBox nombre, TextBox dirección, TextBox edad, TextBox carrera)
        {
            var Registros = from valor in dbEscuela.Estudiantes
                            where valor.AlumnoID == Convert.ToInt32(idAlumno.Text)
                            select valor;
            foreach(var valor in Registros)
            {
                valor.Nombre = nombre.Text;
                valor.Dirección = dirección.Text;
                valor.Edad = Convert.ToInt32(edad.Text);
                valor.Carrera = carrera.Text;
            }
            try
            {
                dbEscuela.SubmitChanges();
                MessageBox.Show("Actualizaste un estudiante", "Éxito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception error)
            {
                MessageBox.Show("Error al actualizar un estudiante: " + error.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarAlumno(TextBox idAlumno)
        {
            var Registros = from valor in dbEscuela.Estudiantes
                            where valor.AlumnoID == Convert.ToInt32(idAlumno.Text)
                            select valor;
            foreach(var valor in Registros)
            {
                dbEscuela.Estudiantes.DeleteOnSubmit(valor);
            }
            try
            {
                dbEscuela.SubmitChanges();
                MessageBox.Show("Eliminaste un estudiante", "Éxito al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                idAlumno.Text = "";
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar estudiante: " + error.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarAlumno(TextBox idAlumno, TextBox nombre, TextBox dirección, TextBox edad, TextBox carrera)
        {
            nombre.Text = "";
            dirección.Text = "";
            edad.Text = "";
            carrera.Text = "";

            var Registros = from valor in dbEscuela.Estudiantes
                            where valor.AlumnoID == Convert.ToInt32(idAlumno.Text)
                            select valor;

            if (Registros.Any())
            {
                foreach (var valor in Registros)
                {
                    nombre.Text = valor.Nombre;
                    dirección.Text = valor.Dirección;
                    edad.Text = valor.Edad.ToString();
                    carrera.Text = valor.Carrera;
                }
            }
            else
            {
                MessageBox.Show("No existe ningún estudiante con ID: " + idAlumno.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idAlumno.Text = "";
                idAlumno.Focus();
            }
        }
    }
}
