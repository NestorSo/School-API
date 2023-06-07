using Newtonsoft.Json;
using School.Dto;
using SchoolAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class frmSchool : Form
    {
        public frmSchool()
        {
            InitializeComponent();
        }

        private void frmSchool_Load(object sender, EventArgs e)
        {
            GetAllStudents();
        }

        private async void GetAllStudents()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7286/api/Student"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var student = await response.Content.ReadAsStringAsync();
                        var displayData = JsonConvert.DeserializeObject<List<StudentDto>>(student);
                        dgvStudents.DataSource = displayData.ToList();
                    }
                    else
                    {
                        MessageBox.Show($"No se puede obtener la lista de estudiantes: {response.StatusCode}");
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddStudent();
        }
        
        private async void AddStudent()
        {

            StudentCreateDto student = new StudentCreateDto();
            student.StudentName = txtStudentName.Text;
            student.DateOfBirth = dtmDateOfBirth.Value;
            student.GradeId= int.Parse(txtGradeId.Text);
            
            using (var client = new HttpClient())
            {
                var serializedStudent = JsonConvert.SerializeObject(student);
                var content = new StringContent(serializedStudent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7286/api/Student", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Estudiante Agregado");
                }
                else
                {
                    MessageBox.Show($"error al guardar al estudiante: {response.Content.ReadAsStringAsync().Result}");
                }

            }
            Clear();
            GetAllStudents();
        }
        private static int id = 0;
        private void Clear()
        {
            txtId.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            id = 0;
            txtGradeId.Text = string.Empty;
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {

                if (row.Index == e.RowIndex)
                {
                    id = int.Parse(row.Cells[0].Value.ToString());
                    GetStudentByID(id);
                }
            }
        }

        private async void GetStudentByID(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(String.Format("{0}/{1}", "https://localhost:7286/api/Student", id));
                if (response.IsSuccessStatusCode)
                {
                    var student = await response.Content.ReadAsStringAsync();
                    StudentDto studentDto = JsonConvert.DeserializeObject<StudentDto>(student);
                    txtId.Text = studentDto.StudentId.ToString();
                    txtStudentName.Text = studentDto.StudentName;
                    txtGradeId.Text= studentDto.GradeId.ToString();
                }
                else
                {
                    MessageBox.Show($"No se pudo obtener el estudiante: {response.StatusCode}");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                UpdateStudent();
            }
        }

        private async void UpdateStudent()
        {
            StudentUpdateDto studentUpdate = new StudentUpdateDto();
            studentUpdate.StudentId = id;
            studentUpdate.StudentName = txtStudentName.Text;
            studentUpdate.DateOfBirth = dtmDateOfBirth.Value;
            studentUpdate.GradeId= int.Parse(txtGradeId.Text);
            using (var client = new HttpClient())
            {
                var student = JsonConvert.SerializeObject(studentUpdate);
                var content = new StringContent(student, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Format("{0}/{1}", "https://localhost:7286/api/Student", id), content);
            }
            Clear();
            GetAllStudents();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                DeleteStudent(id);
            }
        }

        private async void DeleteStudent(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7286/api/Student");
                var response = await client.DeleteAsync(String.Format("{0}/{1}",
                    "https://localhost:7286/api/Student", id));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Estudiante eliminado con éxito");
                }
                else
                {
                    MessageBox.Show($"No se puede eliminar el estudiante: {response.StatusCode}");
                }
            }
            Clear();
            GetAllStudents();

        }
    }

}
