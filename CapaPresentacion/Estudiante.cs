using CapaLogica;
using CapaModelos;

namespace CapaPresentacion
{
    public partial class Estudiante : Form
    {
        private LogicaEstudiante InstanciaEstudianteLogica;
        private Profesor _ventanaProfesor;
        public Estudiante()
        {
            InitializeComponent();
            InstanciaEstudianteLogica = new LogicaEstudiante();
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            DGVEstudiantes.DataSource = InstanciaEstudianteLogica.ObtenerEstudiantes();
            DGVEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarDatos()
        {
            TXTId.Text = string.Empty;
            TXTNombre.Text = string.Empty;
            TXTEdad.Text = string.Empty;
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            CapaModelos.Estudiante NuevoEstudiante = new CapaModelos.Estudiante();
            NuevoEstudiante.Nombre = TXTNombre.Text;
            int edad;
            Int32.TryParse(TXTEdad.Text, out edad);
            NuevoEstudiante.Edad = edad;

            InstanciaEstudianteLogica.AgregarEstudiante(NuevoEstudiante);
            MessageBox.Show("Estudiante agregado correctamente");
            LimpiarDatos();
            ActualizarDatos();
        }

        private void BTNActualizar_Click(object sender, EventArgs e)
        {
            CapaModelos.Estudiante EstudianteEditado = new CapaModelos.Estudiante();
            EstudianteEditado.Nombre = TXTNombre.Text;
            int edad;
            Int32.TryParse(TXTEdad.Text, out edad);
            EstudianteEditado.Edad = edad;
            int id;
            Int32.TryParse(TXTId.Text, out id);
            EstudianteEditado.IdEstudiante = id;

            if (InstanciaEstudianteLogica.ActualizarEstudiante(EstudianteEditado))
            {
                MessageBox.Show("Estudiante actualizado correctamente");
                LimpiarDatos();
                ActualizarDatos();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al actualizar el estudiante");
            }
        }

        private void DGVEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CapaModelos.Estudiante estudianteSeleccionado = (CapaModelos.Estudiante)DGVEstudiantes.CurrentRow.DataBoundItem;
            if (estudianteSeleccionado != null)
            {
                TXTId.Text = estudianteSeleccionado.IdEstudiante.ToString();
                TXTNombre.Text = estudianteSeleccionado.Nombre;
                TXTEdad.Text = estudianteSeleccionado.Edad.ToString();
            }
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            int IdEstudianteAEliminar;
            Int32.TryParse(TXTId.Text, out IdEstudianteAEliminar);

            if (InstanciaEstudianteLogica.EliminarEstudiante(IdEstudianteAEliminar))
            {
                MessageBox.Show("Estudiante eliminado correctamente");
                LimpiarDatos();
                ActualizarDatos();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminado el estudiante");
            }
        }

        private void BTN_MenoresDeEdad_Click(object sender, EventArgs e)
        {
            MessageBox.Show(InstanciaEstudianteLogica.ObtenerMenoresDeEdad());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ventanaProfesor = new Profesor();
            _ventanaProfesor.Owner = this;
            _ventanaProfesor.Visible = true;
            this.Visible = false;

        }
        
    }
}
