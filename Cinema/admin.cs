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
        static string conn_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Cinema998\Cinema\AppData\Kino_DB.mdf;Integrated Security=True";
        SqlConnection connect_to_DB = new SqlConnection(conn_KinoDB);

        SqlCommand command;
        SqlDataAdapter adapter;
        Button film_uuenda, film_kustuta, film_naita;
        Label title_;
        Label lbl1;
        Label lbl2;
        Label lbl3;
        TextBox text1;

        TextBox text3;
        TextBox text4;
        Button add;
        public admin()
        {

            this.Size = new System.Drawing.Size(800, 800);
            /*Button pilet_naita = new Button
            {
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(80, 25),
                Text = "Ostetud \npiletid"
            };
            this.Controls.Add(pilet_naita);
            pilet_naita.Click += Pilet_naita_Click;*/
            film_naita = new Button
            {
                Location = new System.Drawing.Point(50, 25),
                Size = new System.Drawing.Size(80, 25),
                Text = "Näita filmid"
            };
            this.Controls.Add(film_naita);
            film_naita.Click += Film_naita_Click;
            film_uuenda = new Button
            {
                Location = new System.Drawing.Point(650, 75),
                Size = new System.Drawing.Size(80, 25),
                Text = "Uuendamine",

            };
            this.Controls.Add(film_uuenda);
            film_uuenda.Click += Film_uuenda_Click;
            film_kustuta = new Button
            {
                Location = new System.Drawing.Point(650, 100),
                Size = new System.Drawing.Size(80, 25),
                Text = "Kustutamine",


            };
            this.Controls.Add(film_kustuta);

            Button insert = new Button()
            {
                Text = "Insert",
                Size = new Size(100, 40),
                Location = new Point(210, 20)
            };
            this.Controls.Add(insert);
            insert.Click += Insert_Click;

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (dataGridView != null)
            {
                dataGridView.Hide();

            }
            if (title_ != null)
            { 
                film_uuenda.Hide();
                film_txt.Hide();
                aasta_txt.Hide();
                poster_txt.Hide();
                poster.Hide();
            }


            lbl1 = new Label()
            {
                Text = "nimetus: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(20, 160),

            };


            lbl2 = new Label()
            {
                Text = "aasta: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(20, 200),
            };

            lbl3 = new Label()
            {
                Text = "pilt: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(20, 240),
            };

            text1 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(90, 160)
            };


            text3 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(90, 200)
            };

            text4 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(90, 240)
            };

            add = new Button()
            {
                Text = "lisama",
                Size = new Size(160, 40),
                Location = new Point(50, 290),
                Font = new Font(Font.FontFamily, 10)
            };
            add.Click += Add_Click;

            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(text1); 
            this.Controls.Add(text3);
            this.Controls.Add(text4);
            this.Controls.Add(add);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("insert into Filmid(nimetus, aasta,pilt) values(@nimetus, @aasta, @pilt)", connect_to_DB);
            command.Parameters.AddWithValue("@nimetus", text1.Text);
            command.Parameters.AddWithValue("@aasta", text3.Text);
            command.Parameters.AddWithValue("@pilt", text4.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("lisatud tabelisse.");

            connect_to_DB.Close();

        }

        static int Id = 0;

        private void Film_uuenda_Click(object sender, EventArgs e)
        {

            if (film_txt.Text != "" && aasta_txt.Text != "" && poster_txt.Text != "" && poster.Image != null)
            {
                connect_to_DB.Open();
                command = new SqlCommand("UPDATE Filmid  SET nimetus=@film,Aasta=@aasta,pilt=@poster WHERE film_id=@id", connect_to_DB);

                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@film", film_txt.Text);
                command.Parameters.AddWithValue("@aasta", aasta_txt.Text);
                command.Parameters.AddWithValue("@poster", poster_txt.Text);
                //string file_pilt = poster_txt.Text + ".jpg";
                //command.Parameters.AddWithValue("@poster", file_pilt);
                command.ExecuteNonQuery();
                connect_to_DB.Close();
                ClearData();
                Data();
                MessageBox.Show("Andmed uuendatud");
            }
            else
            {
                MessageBox.Show("Viga");
            }

        }

        private void Pilet_naita_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();
            DataTable tabel_p = new DataTable();
            DataGridView dataGridView_p = new DataGridView();
            DataSet dataset_p = new DataSet();
            SqlDataAdapter adapter_p = new SqlDataAdapter("SELECT Rida,Koht,Film_Id FROM [dbo].[Piletid]; SELECT nimetus FROM [dbo].[Filmid]", connect_to_DB);

            //adapter_p.TableMappings.Add("Piletid", "Rida");
            //adapter_p.TableMappings.Add("Filmid", "Filmi_nimetus");
            //adapter_p.Fill(dataset_p);
            adapter_p.Fill(tabel_p);
            dataGridView_p.DataSource = tabel_p;
            dataGridView_p.Location = new System.Drawing.Point(10, 75);
            dataGridView_p.Size = new System.Drawing.Size(400, 200);


            SqlDataAdapter adapter_f = new SqlDataAdapter("SELECT nimetus FROM [dbo].[Filmid]", connect_to_DB);
            DataTable tabel_f = new DataTable();
            DataSet dataset_f = new DataSet();
            adapter_f.Fill(tabel_f);
            /*fkc = new ForeignKeyConstraint(tabel_f.Columns["Id"], tabel_p.Columns["Film_Id"]);
            tabel_p.Constraints.Add(fkc);*/
            poster.Image = Image.FromFile("../../Posterid/Start.jpg");

            DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
            ComboBox com_f = new ComboBox();
            foreach (DataRow row in tabel_f.Rows)
            {
                com_f.Items.Add(row["nimetus"]);
                cbc.Items.Add(row["nimetus"]);
            }
            cbc.Value = com_f;
            connect_to_DB.Close();
            this.Controls.Add(dataGridView_p);
            this.Controls.Add(com_f);

        }


        TextBox film_txt, aasta_txt, poster_txt;
        PictureBox poster;
        DataGridView dataGridView;
        DataTable tabel;
        private void Film_naita_Click(object sender, EventArgs e)
        {
            film_naita.Text = "Peida filmid";
            film_uuenda.Visible = true;
            film_kustuta.Visible = true;

            film_txt = new TextBox
            { Location = new System.Drawing.Point(450, 75) };
            aasta_txt = new TextBox
            { Location = new System.Drawing.Point(450, 100) };
            poster_txt = new TextBox
            { Location = new System.Drawing.Point(450, 125) };
            poster = new PictureBox
            {
                Size = new System.Drawing.Size(300, 500),
                Location = new System.Drawing.Point(450, 150),
                Image = Image.FromFile("../../Posterid/Start.jpg")
            };

            Data();


        }
        public void Data()
        {
            connect_to_DB.Open();
            tabel = new DataTable();
            dataGridView = new DataGridView();
            dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;
            adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Filmid]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new System.Drawing.Point(10, 75);
            dataGridView.Size = new System.Drawing.Size(400, 200);
            connect_to_DB.Close();
            this.Controls.Add(dataGridView);
            this.Controls.Add(film_txt);
            this.Controls.Add(aasta_txt);
            this.Controls.Add(poster_txt);
            this.Controls.Add(poster);
        }
        private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            film_txt.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            aasta_txt.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            poster_txt.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            poster.Image = Image.FromFile(@"..\..\Posterid\" + dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
            this.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
        private void ClearData()
        {
            //Id = 0;
            film_txt.Text = "";
            aasta_txt.Text = "";
            poster_txt.Text = "";
            //save.FileName = "";
            poster.Image = Image.FromFile("../../Posterid/Start.jpg");

        }
    }
}
