using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    class admin : System.Windows.Forms.Form
    {
        static string connect_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\Cinema887\Cinema\AppData\Kino_DB.mdf;Integrated Security=True";
        public SqlConnection connect_to_DB = new SqlConnection(connect_KinoDB);

        SqlCommand command;
        SqlDataAdapter adapter;
        public admin()
        {
            this.Size = new System.Drawing.Size(600, 800);

            Button btn = new Button()
            {
                Size = new Size(75, 75),
                Location = new Point(20, 30),
                Text = "vaata tabel"
            };
            btn.MouseClick += Btn_MouseClick;
            this.Controls.Add(btn);

            Button filmiAdd = new Button()
            {
                Size = new Size(75, 75),
                Location = new Point(220, 300),
                Text = "Lisa film"
            };
            this.Controls.Add(filmiAdd);
            filmiAdd.MouseClick += FilmiAdd_MouseClick;
        }

        private void FilmiAdd_MouseClick(object sender, MouseEventArgs e)
        {
            if (name.Text != "" && date.Text != "" && posters.Image != null)
            {
                command = new SqlCommand("UPDATE Film  SET nimetus=@nimetus,aasta=@aasta,pilt=@pilt WHERE id_film=@if_film", connect_to_DB);
                connect_to_DB.Open();
                command.Parameters.AddWithValue("@id_film", id);
                command.Parameters.AddWithValue("@nimetus", name.Text);
                command.Parameters.AddWithValue("@aasta", date.Text);
                string file_pilt = image.Text + ".jpg";
                command.Parameters.AddWithValue("@pilt", file_pilt);
                command.ExecuteNonQuery();
                connect_to_DB.Close();
                MessageBox.Show("Andmed uuendatud");
            }
            else
            {
                MessageBox.Show("Viga");
            }
        }
        TextBox name, date, genre, image;
        PictureBox posters;
        DataGridView dataGridView;
        int id = 0;
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            name = new TextBox
            {
                Location = new System.Drawing.Point(100, 200)
            };
            date = new TextBox
            {
                Location = new System.Drawing.Point(100, 225)
            };
            genre = new TextBox
            {
                Location = new System.Drawing.Point(100, 250)
            };
            image = new TextBox
            {
                Location = new System.Drawing.Point(100, 275)
            };
            posters = new PictureBox()
            {
                Size = new System.Drawing.Size(180, 250),
                Location = new System.Drawing.Point(300, 150)
            };
            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();
            dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick1;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id_film,nimetus,aasta FROM [dbo].[Film]", connect_KinoDB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new System.Drawing.Point(150, 400);
            dataGridView.Size = new System.Drawing.Size(400, 200);
            this.Controls.Add(dataGridView);

            
            this.Controls.Add(name);
            this.Controls.Add(date);
            this.Controls.Add(genre);
            this.Controls.Add(image);
            this.Controls.Add(posters);
            connect_to_DB.Close();
        }

        private void DataGridView_RowHeaderMouseClick1(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            name.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            date.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            genre.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            image.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            posters.Image = Image.FromFile(@"C:..\..\img\" + dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
            //string v = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            //comboBox1.SelectedIndex = Int32.Parse(v) - 1;
        }

    }
}