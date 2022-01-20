using System;
using System.Collections.Generic;
using System.Drawing;
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
        PictureBox pb3;
        PictureBox pb4;
        
        public perec()
        {
            this.ClientSize = new System.Drawing.Size(700, 620);

            pb = new PictureBox();
            pb.Size = new Size(200, 460);
            pb.Location = new Point(200, 5);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.ImageLocation = (@"..\..\img\doctor.jpg");
            pb.Click += Pb_Click;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            
        }
    }
}
