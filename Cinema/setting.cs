using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class setting : Form
    {
        Label message = new Label();
        Button[] btn = new Button[4];
        string[] texts = new string[4];
        TableLayoutPanel tlp = new TableLayoutPanel();
        Button btn_tabel;
        static List<Pilet> piletid;
        int k, r;
        static string[] read_kohad;

        static string conn_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mrljo\Source\Repos\Cinema887\Cinema\AppData\Kino_DB.mdf;Integrated Security=True";
        SqlConnection connect_to_DB = new SqlConnection(conn_KinoDB);

        SqlCommand command;
        SqlDataAdapter adapter;


        public setting()
        { }

        public string[] Ostu_piletid()
        {
            try
            {
                /*StreamReader f = new StreamReader(@"..\..\piletid.txt");
                read_kohad = f.ReadToEnd().Split(';');
                
                f.Close();*/
                connect_to_DB.Open();
                adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Piletid]", connect_to_DB);
                DataTable tabel = new DataTable();
                adapter.Fill(tabel);
                read_kohad = new string[tabel.Rows.Count];
                var index = 0;
                foreach (DataRow row in tabel.Rows)
                {
                    var rida = row["Rida"];
                    var koht = row["Koht"];
                    read_kohad[index++] = $"{rida}{koht}";
                }
                connect_to_DB.Close();
            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return read_kohad;

        }
        public setting(int read, int kohad)
        {
            this.tlp.ColumnCount = kohad;
            this.tlp.RowCount = read;
            this.tlp.ColumnStyles.Clear();
            this.tlp.RowStyles.Clear();
            int i, j;
            read_kohad = Ostu_piletid();
            piletid = new List<Pilet> { };


            for (i = 0; i < read; i++)
            {
                this.tlp.RowStyles.Add(new RowStyle(SizeType.Percent));
                this.tlp.RowStyles[i].Height = 100 / read;
            }

            for (j = 0; j < kohad; j++)
            {
                this.tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                this.tlp.ColumnStyles[j].Width = 100 / kohad;
            }

            this.Size = new System.Drawing.Size(kohad * 100, read * 100);
            for (int r = 0; r < read; r++)
            {
                for (int k = 0; k < kohad; k++)
                {

                    btn_tabel = new Button
                    {
                        Text = string.Format("rida {0},koht {1}", r + 1, k + 1),
                        Name = string.Format("{1}{0}", k + 1, r + 1),
                        Dock = DockStyle.Fill,
                        BackColor = Color.Green
                    };

                    foreach (var item in read_kohad)
                    {

                        if (item.ToString() == btn_tabel.Name)
                        {

                            btn_tabel.BackColor = Color.Red;
                            btn_tabel.Enabled = false;

                        }
                    }
                    btn_tabel.Click += new EventHandler(Pileti_valik);
                    this.tlp.Controls.Add(btn_tabel, k, r);

                }

            }


            this.tlp.Dock = DockStyle.Fill;
            this.Controls.Add(tlp);
        }

        string po4ta = "";
        private void Saada_piletid(List<Pilet> piletid)
        {
            po4ta = Interaction.InputBox("Email", "Email");
            if (po4ta != "")
            {
                var film = File.ReadLines(@"..\..\zapisf.txt").Last();
                connect_to_DB.Open();
                string text = "PEREC\n";


                foreach (var item in piletid)
                {
                    text += " film on " + film + "\n" + " Rida: " + item.Rida + " Koht: " + item.Koht + "\n" + "\n Aleksei Tiora";
                    command = new SqlCommand("INSERT INTO Piletid(Rida,Koht,Film) Values(@rida,@koht,@film)", connect_to_DB);
                    command.Parameters.AddWithValue("@rida", item.Rida);
                    command.Parameters.AddWithValue("@koht", item.Koht);
                    command.Parameters.AddWithValue("@film", 1);
                    command.ExecuteNonQuery();
                }
                connect_to_DB.Close();

                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(po4ta));
                message.From = new MailAddress(po4ta);
                message.Subject = "Ostetud piletid";
                message.Body = text;
                string email = "programmeeriminetthk@gmail.com";
                string password = "2.kuursus tarpv20";
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = true,
                };
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                if (MessageBox.Show("E-post on valesti sisestatud.\nKas soovite korrata?", "Viga", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Saada_piletid(piletid);
                }
                else
                {
                    Environment.Exit(0);
                }

            }
        }
        private void Pileti_valik(object sender, EventArgs e)
        {
            Button btn_click = (Button)sender;
            btn_click.BackColor = Color.Yellow;
            MessageBox.Show(btn_click.Name.ToString());
            var rida = int.Parse(btn_click.Name[0].ToString());
            var koht = int.Parse(btn_click.Name[1].ToString());
            var vas = MessageBox.Show("Sinu pilet on: Rida: " + rida + " Koht: " + koht, "Kas ostad?", MessageBoxButtons.YesNo);
            if (vas == DialogResult.Yes)
            {
                btn_click.BackColor = Color.Red;
                try
                {
                    Pilet pilet = new Pilet(rida, koht);
                    piletid.Add(pilet);
                    StreamWriter ost = new StreamWriter(@"..\..\piletid.txt", true);
                    ost.Write(btn_click.Name.ToString() + ';');
                    ost.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (vas == DialogResult.No)
            {
                btn_click.BackColor = Color.Green;
            };

            if (MessageBox.Show("Sul on ostetud: " + piletid.Count() + "piletid", "Kas tahad saada neid e-mailile?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Saada_piletid(piletid);
            }

        }
        private void MyForm_Click(object sender, EventArgs e)
        {
            Button btn_click = (Button)sender;
            MessageBox.Show("Oli valitud " + btn_click.Text + " nupp");
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Kino";
            this.ResumeLayout(false);
        }


    }
}
