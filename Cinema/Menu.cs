using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    class Menu: System.Windows.Forms.Form
    {
        //ei tehtud
        List<string> listfilm;
        PictureBox pb;
        int schet = 0;

        public Menu()
        {
            this.Height = 770;
            this.Width = 750;
            this.BackgroundImage = Image.FromFile(@"../../img/fon.jpg");

            Button K_btn = new Button
            {
                Text = "Osta pilet",
                Location = new System.Drawing.Point(300, 630),//Point(x,y)
                Height = 60,
                Width = 150,
            };
            K_btn.Click += K_btn_Click;

            Button l_btn = new Button
            {
                Text = "=>",
                Location = new System.Drawing.Point(550, 375),
                Height = 36,
                Width = 60
            };
            l_btn.Click += L_btn_Click;

            listfilm = new List<string> {"spider.png" ,"elki.jpg", "doctor.jpg", "elki.jpg", "spider.png", "doctor.jpg",  };

            Button l_btn1 = new Button
            {
                Text = "<=",
                Location = new System.Drawing.Point(120, 375),
                Height = 36,
                Width = 60
            };
            l_btn1.Click += L_btn1_Click;

            Label lbl = new Label
            {
                Text = "Kinoteatr PEREC",
                Size = new System.Drawing.Size(250, 60),
                Location = new System.Drawing.Point(240, 25),
                Font = new Font("Oswald", 16, FontStyle.Bold)

            };

            pb = new PictureBox();
            pb.Size = new Size(300, 500);
            pb.Location = new Point(220, 90);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.ImageLocation = (@"..\..\img\valik.png");


            this.Controls.Add(K_btn);
            this.Controls.Add(pb);
            this.Controls.Add(l_btn);
            this.Controls.Add(l_btn1);
            this.Controls.Add(lbl);





        }

        private void L_btn1_Click(object sender, EventArgs e)
        {
            if (schet > 0)
            {
                pb.ImageLocation = ($"../../img/{listfilm[schet]}");
                schet -= 1;
            }
        }

        private void L_btn_Click(object sender, EventArgs e)
        {
            
            if(schet < 2)
            {
                pb.ImageLocation = ($"../../img/{listfilm[schet]}");
                schet++;
            }
        }

        private void K_btn_Click(object sender, EventArgs e)
        {
            cinema uus_aken = new cinema();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            this.Hide();
        }
    }
}
