using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Profesor : Form
    {
        public Profesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante VentanaEstudiante = (Estudiante)this.Owner;
            VentanaEstudiante.Visible = true;
            this.Visible = false;

        }
    }
}
