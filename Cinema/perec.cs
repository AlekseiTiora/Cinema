using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class perec : Form
    {
        PictureBox pb;
        PictureBox pb1;
        PictureBox pb2;
        PictureBox pb3;
        
        public perec()
        {
            this.ClientSize = new System.Drawing.Size(800, 760);

            pb = new PictureBox();
            pb.Size = new Size(250, 360);
            pb.Location = new Point(10, 5);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.ImageLocation = (@"..\..\img\doctor.jpg");
            pb.Click += Pb_Click;


            pb1 = new PictureBox();
            pb1.Size = new Size(250, 360);
            pb1.Location = new Point(270, 5);
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.ImageLocation = (@"..\..\img\elki.jpg");
            pb1.Click += Pb1_Click;

            pb2 = new PictureBox();
            pb2.Size = new Size(250, 360);
            pb2.Location = new Point(540, 5);
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.ImageLocation = (@"..\..\img\spider.jpg");
            pb2.Click += Pb2_Click;

            pb3 = new PictureBox();
            pb3.Size = new Size(250, 360);
            pb3.Location = new Point(270, 380);
            pb3.SizeMode = PictureBoxSizeMode.StretchImage;
            pb3.ImageLocation = (@"..\..\img\dzen.jpg");
            pb3.Click += Pb3_Click;



            this.BackgroundImage = Image.FromFile(@"../../img/kino.jpg");
            this.Controls.Add(pb);
            this.Controls.Add(pb1);
            this.Controls.Add(pb2);
            this.Controls.Add(pb3);
        }

        private void Pb3_Click(object sender, EventArgs e)
        {
            zalf uus_aken = new zalf();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            string dzen = "dzentelmeni";
            using (StreamWriter srb = new StreamWriter(@"..\..\zapisf.txt", true))
            {
                srb.WriteLine(dzen);
            }
            this.Hide();
        }

        private void Pb2_Click(object sender, EventArgs e)
        {
            zalf uus_aken = new zalf();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            string spider = "spider man no way home";
            using (StreamWriter srb = new StreamWriter(@"..\..\zapisf.txt", true))
            {
                srb.WriteLine(spider);
            }
            this.Hide();

        }

        private void Pb1_Click(object sender, EventArgs e)
        {
            zalf uus_aken = new zalf();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            string elki = "elki 8";
            using (StreamWriter srb = new StreamWriter(@"..\..\zapisf.txt", true))
            {
                srb.WriteLine(elki);
            }
            this.Hide();

        }


        private void Pb_Click(object sender, EventArgs e)
        {
            zalf uus_aken = new zalf();
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            string doctor = "doctor strange";
            using (StreamWriter srb = new StreamWriter(@"..\..\zapisf.txt", true))
            {
                srb.WriteLine(doctor);
            }
            this.Hide();

        }
    }
}
