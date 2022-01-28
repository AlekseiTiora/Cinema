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
    class Menu : System.Windows.Forms.Form
    {
        List<string> listfilm;
        PictureBox pb;
        int schet = 0;

        public Menu()
        {

            this.Height = 770;
            this.Width = 540;
            this.BackgroundImage = Image.FromFile(@"../../img/fon.jpg");

            Button K_btn = new Button
            {
                Text = "Osta pilet",
                Location = new System.Drawing.Point(180, 630),//Point(x,y)
                Height = 60,
                Width = 150,
            };
            K_btn.Click += K_btn_Click;

            Button admin_b = new Button
            {
                Text = "admin",
                Location = new System.Drawing.Point(470, 0),//Point(x,y)
                Height = 30,
                Width = 60,
            };
            admin_b.Click += Admin_b_Click;

            Label lbl = new Label
            {
                Text = "Kinoteatr PEREC",
                Size = new System.Drawing.Size(200, 40),
                Location = new System.Drawing.Point(5, 10),
                Font = new Font("Oswald", 16, FontStyle.Bold)

            };

            Label lbl1 = new Label
            {
                Text = "mis läheb ",
                Size = new System.Drawing.Size(150, 30),
                Location = new System.Drawing.Point(170, 60),
                Font = new Font("Oswald", 16, FontStyle.Bold)

            };

            pb = new PictureBox();
            pb.Size = new Size(300, 500);
            pb.Location = new Point(110, 100);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.ImageLocation = (@"..\..\img\gif.gif");



            this.Controls.Add(K_btn);
            this.Controls.Add(pb);
            this.Controls.Add(admin_b);
            this.Controls.Add(lbl);
            this.Controls.Add(lbl1);


            listfilm = new List<string>() { "dzen.jpg", "spider.jpg", "elki.jpg", "doctor.jpg" };

        }

        private void Admin_b_Click(object sender, EventArgs e)
        {
            admin uus_aken = new admin ();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();

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
