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
            Button Start_btn = new Button
            {
                Text = "väike saal",
                Location = new System.Drawing.Point(180, 200),
                Size = new Size(100,50)
            };
            Start_btn.Click += Start_btn_Click;
            this.Controls.Add(Start_btn);
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            cinema uus_aken = new cinema(5, 5);
            uus_aken.Size = new Size(300, 300);
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }
    }
}
