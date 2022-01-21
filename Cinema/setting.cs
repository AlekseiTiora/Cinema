using System;
using System.Collections.Generic;
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


        public setting()
        { }

        public string[] Ostu_piletid()
        {
            try
            {
                StreamReader f = new StreamReader(@"..\..\piletid.txt");
                read_kohad = f.ReadToEnd().Split(';');

                f.Close();
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


        private void Saada_piletid(List<Pilet> piletid)
        {
            var film = File.ReadLines(@"..\..\zapisf.txt").Last();

            string text = "PEREC\n";
            foreach (var item in piletid)
            {
                
                text += " film on "+ film + "\n" + " Rida: " + item.Rida + " Koht: " + item.Koht + "\n"+"\n Aleksei Tiora";
            }
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress("programmeeriminetthk@gmail.com"));
            message.From = new MailAddress("programmeeriminetthk@gmail.com");
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
