using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracker
{
    public partial class Form1 : Form
    {
        List<string> collected = new List<string>();
        Dictionary<string, KeyValuePair<Bitmap,Bitmap>> mappedBosses = new Dictionary<string, KeyValuePair<Bitmap, Bitmap>>();
        Dictionary<string, Bitmap> mappedItems = new Dictionary<string, Bitmap>();
        List<string> bosses = new List<string>();
        List<string> items = new List<string>();
        private void reset()
        {
            collected = new List<string>();
            redrawimage();
        }

        private void inbox(int lowx,int highy, int highx, int lowy, string name)
        {
            if (has_draw_inbox == false)
            {
                var point = this.PointToClient(Cursor.Position);
                int x = point.X;
                int y = point.Y;
                if ((x >= lowx) && (x <= highx))
                {
                    if ((y >= lowy) && (y <= highy))
                    {
                        has_draw_inbox = true;
                        if (collected.Contains(name) == false)
                        {
                            collected.Add(name);
                        }
                        else
                        {
                            collected.Remove(name);
                        }
                    }
                }
            }
        }


        private void redrawimage()
        {

            Bitmap bg = new Bitmap(Tracker.Properties.Resources.items,new Size(960,540));
            Graphics background = Graphics.FromImage(bg);
            foreach (string a in collected)
            {
                if (items.Contains(a) == true)
                {
                    background.DrawImage(mappedItems[a], 0, 0, 960, 540);
                }
            }
            foreach(string b in bosses)
            {

                if(collected.Contains(b) == true)
                {
                    background.DrawImage(mappedBosses[b].Key, 0, 0, 960, 540);
                }
                else
                {
                    background.DrawImage(mappedBosses[b].Value, 0, 0, 960, 540);
                }
            }
            pictureBox1.BackgroundImage = bg;

        }
        public Form1()
        {
            InitializeComponent();
            mappedBosses.Add("ridley", new KeyValuePair<Bitmap, Bitmap>(Tracker.Properties.Resources.rid_0, Tracker.Properties.Resources.rid_1));
            mappedBosses.Add("dray", new KeyValuePair<Bitmap, Bitmap>(Tracker.Properties.Resources.dray_0, Tracker.Properties.Resources.dray_1));
            mappedBosses.Add("phan", new KeyValuePair<Bitmap, Bitmap>(Tracker.Properties.Resources.phan_0, Tracker.Properties.Resources.phan_1));
            mappedBosses.Add("kraid", new KeyValuePair<Bitmap, Bitmap>(Tracker.Properties.Resources.kraid_0, Tracker.Properties.Resources.kraid_1));
            mappedItems.Add("speed", Tracker.Properties.Resources.speed);
            mappedItems.Add("jump", Tracker.Properties.Resources.jump);
            mappedItems.Add("spring", Tracker.Properties.Resources.spring);
            mappedItems.Add("ice", Tracker.Properties.Resources.ice);
            mappedItems.Add("plaz", Tracker.Properties.Resources.plaz);
            mappedItems.Add("wave", Tracker.Properties.Resources.wave);
            mappedItems.Add("spaz", Tracker.Properties.Resources.spaz);
            mappedItems.Add("charge", Tracker.Properties.Resources.charge);
            mappedItems.Add("vaira", Tracker.Properties.Resources.varia);
            mappedItems.Add("grav", Tracker.Properties.Resources.grav);
            mappedItems.Add("space", Tracker.Properties.Resources.space);
            mappedItems.Add("s-attack", Tracker.Properties.Resources.s_attack);
            mappedItems.Add("ball", Tracker.Properties.Resources.ball);
            mappedItems.Add("bomb", Tracker.Properties.Resources.bomb);
            bosses = mappedBosses.Keys.ToList();
            items = mappedItems.Keys.ToList();
            redrawimage();
        }
        bool has_draw_inbox = false;

        //bool flip = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*
            var point = this.PointToClient(Cursor.Position);
            int x = point.X;
            int y = point.Y;
            if (flip == false)
            {
                textBox1.Text = string.Format("{0},{1}", x, y);
            }
            else
            {
                textBox1.Text = textBox1.Text+","+string.Format("{0},{1}", x, y);
            }
            flip = !flip;
            */
            has_draw_inbox = false;
            inbox(13, 388, 82, 282, "ridley");
            inbox(14, 125, 130, 13, "dray");
            inbox(616, 110, 679, 13, "phan");
            inbox(584, 387, 678, 230, "kraid");
            inbox(59, 261, 154, 253, "speed");
            inbox(59, 239, 155, 230, "jump");
            inbox(552, 211, 648, 206, "spring");
            inbox(103, 152, 155, 145, "ice");
            inbox(103, 185, 154, 177, "plaz");
            inbox(103, 162, 155, 155, "wave");
            inbox(103, 173, 154, 166, "spaz");
            inbox(104, 142, 154, 132, "charge");
            inbox(552, 140, 648, 133, "vaira");
            inbox(551, 152, 649, 144, "grav");
            inbox(59, 251, 156, 242, "space");
            inbox(552, 223, 648, 214, "s-attack");
            inbox(553, 188, 648, 181, "ball");
            inbox(552, 200, 648, 195, "bomb");
            if(has_draw_inbox == true) redrawimage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
