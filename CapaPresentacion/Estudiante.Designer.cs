namespace CapaPresentacion
{
    partial class Estudiante
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TXTId = new TextBox();
            TXTNombre = new TextBox();
            TXTEdad = new TextBox();
            BTNAgregar = new Button();
            DGVEstudiantes = new DataGridView();
            BTNActualizar = new Button();
            BTNEliminar = new Button();
            BTN_MenoresDeEdad = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVEstudiantes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 38);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Id Estudiante";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 73);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 108);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 2;
            label3.Text = "Edad";
            // 
            // TXTId
            // 
            TXTId.Enabled = false;
            TXTId.Location = new Point(180, 35);
            TXTId.Name = "TXTId";
            TXTId.Size = new Size(261, 23);
            TXTId.TabIndex = 3;
            // 
            // TXTNombre
            // 
            TXTNombre.Location = new Point(180, 70);
            TXTNombre.Name = "TXTNombre";
            TXTNombre.Size = new Size(261, 23);
            TXTNombre.TabIndex = 4;
            // 
            // TXTEdad
            // 
            TXTEdad.Location = new Point(180, 105);
            TXTEdad.Name = "TXTEdad";
            TXTEdad.Size = new Size(261, 23);
            TXTEdad.TabIndex = 5;
            // 
            // BTNAgregar
            // 
            BTNAgregar.Location = new Point(472, 104);
            BTNAgregar.Name = "BTNAgregar";
            BTNAgregar.Size = new Size(75, 23);
            BTNAgregar.TabIndex = 6;
            BTNAgregar.Text = "Agregar";
            BTNAgregar.UseVisualStyleBackColor = true;
            BTNAgregar.Click += BTNAgregar_Click;
            // 
            // DGVEstudiantes
            // 
            DGVEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVEstudiantes.Location = new Point(74, 172);
            DGVEstudiantes.Name = "DGVEstudiantes";
            DGVEstudiantes.Size = new Size(473, 150);
            DGVEstudiantes.TabIndex = 7;
            DGVEstudiantes.CellClick += DGVEstudiantes_CellClick;
            // 
            // BTNActualizar
            // 
            BTNActualizar.Location = new Point(472, 35);
            BTNActualizar.Name = "BTNActualizar";
            BTNActualizar.Size = new Size(75, 23);
            BTNActualizar.TabIndex = 8;
            BTNActualizar.Text = "Actualizar";
            BTNActualizar.UseVisualStyleBackColor = true;
            BTNActualizar.Click += BTNActualizar_Click;
            // 
            // BTNEliminar
            // 
            BTNEliminar.Location = new Point(472, 70);
            BTNEliminar.Name = "BTNEliminar";
            BTNEliminar.Size = new Size(75, 23);
            BTNEliminar.TabIndex = 9;
            BTNEliminar.Text = "Eliminar";
            BTNEliminar.UseVisualStyleBackColor = true;
            BTNEliminar.Click += BTNEliminar_Click;
            // 
            // BTN_MenoresDeEdad
            // 
            BTN_MenoresDeEdad.Location = new Point(180, 340);
            BTN_MenoresDeEdad.Name = "BTN_MenoresDeEdad";
            BTN_MenoresDeEdad.Size = new Size(234, 23);
            BTN_MenoresDeEdad.TabIndex = 10;
            BTN_MenoresDeEdad.Text = "Listar estudiantes menores de edad";
            BTN_MenoresDeEdad.UseVisualStyleBackColor = true;
            BTN_MenoresDeEdad.Click += BTN_MenoresDeEdad_Click;
            // 
            // button1
            // 
            button1.Location = new Point(444, 340);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Profesor";
            button1.UseVisualStyleBackColor = true;
            button1.Click += this.button1_Click;
            // 
            // Estudiante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 450);
            Controls.Add(button1);
            Controls.Add(BTN_MenoresDeEdad);
            Controls.Add(BTNEliminar);
            Controls.Add(BTNActualizar);
            Controls.Add(DGVEstudiantes);
            Controls.Add(BTNAgregar);
            Controls.Add(TXTEdad);
            Controls.Add(TXTNombre);
            Controls.Add(TXTId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Estudiante";
            Text = "Ventana";
            ((System.ComponentModel.ISupportInitialize)DGVEstudiantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TXTId;
        private TextBox TXTNombre;
        private TextBox TXTEdad;
        private Button BTNAgregar;
        private DataGridView DGVEstudiantes;
        private Button BTNActualizar;
        private Button BTNEliminar;
        private Button BTN_MenoresDeEdad;
        private Button button1;
    }
}
