using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class zal_form : Form
    {


        public zal_form()
        {

            this.ClientSize = new System.Drawing.Size(400, 350);
            this.BackgroundImage = Image.FromFile(@"../../img/fon.jpg");

            Button mal_btn = new Button
            {
                Text = "Väike saal",
                Location = new System.Drawing.Point(130, 100),//Point(x,y)
                Height = 50,
                Width = 150,
            };
            mal_btn.Click += Mal_btn_Click;

            Button sred_btn = new Button
            {
                Text = "Keskmine saal",
                Location = new System.Drawing.Point(130, 170),//Point(x,y)
                Height = 50,
                Width = 150,

            };
            sred_btn.Click += Sred_btn_Click;

            Button bol_btn = new Button
            {
                Text = "Suur saal",
                Location = new System.Drawing.Point(130, 240),//Point(x,y)
                Height = 50,
                Width = 150,

            };
            bol_btn.Click += Bol_btn_Click;

            Label lbl_zal = new Label
            {
                Text = "Valige saal",
                Size = new System.Drawing.Size(180, 50),
                Location = new System.Drawing.Point(135, 25),
                Font = new Font("Oswald", 16, FontStyle.Bold)
            };

            this.Controls.Add(lbl_zal);
            this.Controls.Add(mal_btn);
            this.Controls.Add(sred_btn);
            this.Controls.Add(bol_btn);

        }

        private void Bol_btn_Click(object sender, EventArgs e)
        {
            setting uus_aken = new setting(9, 9);//запускает пустую форму
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Sred_btn_Click(object sender, EventArgs e)
        {
            setting uus_aken = new setting(7, 7);//запускает пустую форму
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Mal_btn_Click(object sender, EventArgs e)
        {
            setting uus_aken = new setting(5, 5);//запускает пустую форму
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

    }
}

