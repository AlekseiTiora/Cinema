using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    class cinema : Form
    {
        Label message = new Label();
        Button[] btn = new Button[4];
        string[] texts = new string[4];
        TableLayoutPanel tlp = new TableLayoutPanel();
        Button btn_tabel;

        public cinema()
        {
        }
        public cinema(string title, string body, string button1, string button2, string button3, string button4)
        {

            texts[0] = button1;
            texts[1] = button2;
            texts[2] = button3;
            texts[3] = button4;
            this.ClientSize = new System.Drawing.Size(500, 00);
            this.Text = title;
            int x = 10;
            for (int i = 0; i < 4; i++)
            {
                cinema cinema = this;
                btn[i] = new Button
                {
                    Location = new Point(x, 50),
                    Size = new Size(85, 25),
                    Text = texts[i],


                };
                
                x += 100;
                this.Controls.Add(btn[i]);

            }
            message.Location = new Point(10, 10);
            message.Text = body;
            this.Controls.Add(message);


        }



        public cinema(int kohad, int read)
        {
            this.tlp.ColumnCount = kohad;
            this.tlp.RowCount = read;
            this.tlp.ColumnStyles.Clear();
            this.tlp.RowStyles.Clear();
            int i, j;
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
            this.tlp.RowStyles[0].Height = 100 / kohad;
            this.Size = new System.Drawing.Size(kohad * 100, read * 100);


            for (i = 0; i < read; i++)
            {
                for (j = 0; j < kohad; j++)
                {
                    btn_tabel = new Button
                    {
                        Text = string.Format("rida {0}, koht{1}", i + 1, j + 1),
                        Name = string.Format("btn_{0}{1}", i, j),
                        Dock = DockStyle.Fill,
                        BackColor = Color.LightGreen,
                    };
                    btn_tabel.MouseClick += Btn_tabel_MouseClick;
                    this.tlp.Controls.Add(btn_tabel, j, i);
                }
            }

            this.tlp.Dock = DockStyle.Fill;

            this.Controls.Add(tlp);
        }

        private void Btn_tabel_MouseClick(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.Red;
        }
    }
}
