using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    class start : System.Windows.Forms.Form
    {
        public start()
        {
            this.Size = new System.Drawing.Size(500, 500);
            this.BackgroundImage = Image.FromFile(@"../../img/fon.jpg");
            Text = "Vali saal";
            Button Start_btn = new Button
            {
                Text = "väike saal",
                Location = new System.Drawing.Point(30, 200),
                Size = new Size(100,50)
            };
            Start_btn.Click += Start_btn_Click1;
            this.Controls.Add(Start_btn);



            Button Start_btn1 = new Button
            {
                Text = "keskmine saal",
                Location = new System.Drawing.Point(180, 200),
                Size = new Size(100, 50)
            };
            Start_btn1.Click += Start_btn1_Click;
            this.Controls.Add(Start_btn1);


            Button Start_btn2 = new Button
            {
                Text = "suur saal",
                Location = new System.Drawing.Point(350, 200),
                Size = new Size(100, 50)
            };
            Start_btn2.Click += Start_btn2_Click;
            this.Controls.Add(Start_btn2);


        }

        private void Start_btn0_Click(object sender, EventArgs e)
        {
            cinema uus_aken = new cinema();
            uus_aken.Size = new Size(600, 600);
            uus_aken.ShowDialog();
        }

        private void Start_btn2_Click(object sender, EventArgs e)
        {
            cinema uus_aken = new cinema(14, 14);
            uus_aken.Size = new Size(750, 700);
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Start_btn1_Click(object sender, EventArgs e)
        {
            cinema uus_aken = new cinema(8, 8);
            uus_aken.Size = new Size(500, 500);
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Start_btn_Click1(object sender, EventArgs e)
        {
            cinema uus_aken = new cinema(5, 5);
            uus_aken.Size = new Size(340, 340);
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();

        }
    }
}
