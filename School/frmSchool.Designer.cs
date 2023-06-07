namespace School
{
    partial class frmSchool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvStudents = new DataGridView();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            txtStudentName = new TextBox();
            label3 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            txtGradeId = new TextBox();
            label5 = new Label();
            dtmDateOfBirth = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Bottom;
            dgvStudents.Location = new Point(0, 212);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(800, 165);
            dgvStudents.TabIndex = 19;
            dgvStudents.CellClick += dgvStudents_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(494, 162);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(313, 162);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(180, 162);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(48, 162);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(148, 102);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(171, 23);
            txtStudentName.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 13;
            label3.Text = "Nombre del Estuiante";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(148, 47);
            txtId.Name = "txtId";
            txtId.Size = new Size(120, 23);
            txtId.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 11;
            label2.Text = "Codigo Del Estudiante";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(421, 18);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 10;
            label1.Text = "LISTADE ESTUDIANTES";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 55);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 20;
            label4.Text = "Fecha De Nacimiento";
            // 
            // txtGradeId
            // 
            txtGradeId.Location = new Point(504, 102);
            txtGradeId.Name = "txtGradeId";
            txtGradeId.Size = new Size(171, 23);
            txtGradeId.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(368, 110);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 22;
            label5.Text = "Grade Id";
            // 
            // dtmDateOfBirth
            // 
            dtmDateOfBirth.Location = new Point(516, 55);
            dtmDateOfBirth.Name = "dtmDateOfBirth";
            dtmDateOfBirth.Size = new Size(200, 23);
            dtmDateOfBirth.TabIndex = 24;
            // 
            // frmSchool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 377);
            Controls.Add(dtmDateOfBirth);
            Controls.Add(txtGradeId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvStudents);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(txtStudentName);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmSchool";
            Text = "frmSchool";
            Load += frmSchool_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStudents;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private TextBox txtStudentName;
        private Label label3;
        private TextBox txtId;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox txtGradeId;
        private Label label5;
        private DateTimePicker dtmDateOfBirth;
    }
}