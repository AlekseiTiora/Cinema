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
                Location = new System.Drawing.Point(90, 230),//Point(x,y)
                Height = 60,
                Width = 150,
            };
            K_btn.Click += K_btn_Click;

            Button l_btn = new Button
            {
                Text = "=>",
                Location = new System.Drawing.Point(660, 375),
                Height = 30,
                Width = 60
            };
            l_btn.Click += L_btn_Click;


            Label lbl = new Label
            {
                Text = "Kinoteatr PEREC",
                Size = new System.Drawing.Size(250, 30),
                Location = new System.Drawing.Point(50, 25),
                Font = new Font("Oswald", 16, FontStyle.Bold)

            };

            Label lbl1 = new Label
            {
                Text = "mis läheb kinno",
                Size = new System.Drawing.Size(250, 30),
                Location = new System.Drawing.Point(370, 50),
                Font = new Font("Oswald", 16, FontStyle.Bold)

            };

            pb = new PictureBox();
            pb.Size = new Size(300, 500);
            pb.Location = new Point(320, 90);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.ImageLocation = (@"..\..\img\doctor.jpg");


            this.Controls.Add(K_btn);
            this.Controls.Add(pb);
            this.Controls.Add(l_btn);
            this.Controls.Add(lbl);
            this.Controls.Add(lbl1);




        }



        private void L_btn_Click(object sender, EventArgs e)
        {
            schet++;
            if (schet == 1)
            {

                pb.ImageLocation = (@"..\..\img\elki.jpg");

            }
            else if (schet == 2)
            {

                pb.ImageLocation = (@"..\..\img\dzen.jpg");
            }
            else if (schet == 3)
            {
                schet = 0;
                pb.ImageLocation = (@"..\..\img\spider.jpg");
            }
        }

        private void K_btn_Click(object sender, EventArgs e)
        {
            //
            perec uus_aken = new perec();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            this.Hide();
        }
    }
}
