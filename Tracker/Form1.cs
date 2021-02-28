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
            var point = this.PointToClient(Cursor.Position);
            int x = point.X;
            int y = point.Y;
            if((x >= lowx) && (x <= highx))
            {
                if ((y >= lowy) && (y <= highy))
                {
                    if(collected.Contains(name) == false)
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

        private void redrawimage()
        {

            Bitmap bg = new Bitmap(Tracker.Properties.Resources.items,new Size(669,377));
            Graphics background = Graphics.FromImage(bg);
            foreach (string a in collected)
            {
                if (items.Contains(a) == true)
                {
                    background.DrawImage(mappedItems[a], 0, 0, 669, 377);
                }
            }
            foreach(string b in bosses)
            {

                if(collected.Contains(b) == true)
                {
                    background.DrawImage(mappedBosses[b].Key, 0, 0, 669, 377);
                }
                else
                {
                    background.DrawImage(mappedBosses[b].Value, 0, 0, 669, 377);
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
            inbox(13, 388, 77, 285, "ridley");
            inbox(16, 117, 131, 14, "dray");
            inbox(431, 151, 522, 15, "phan");
            inbox(591, 386, 676, 233, "kraid");
            inbox(157, 384, 178, 363, "speed");
            inbox(327, 386, 346, 367, "jump");
            inbox(354, 386, 370, 368, "spring");
            inbox(48, 141, 64, 124, "ice");
            inbox(16, 174, 39, 155, "plaz");
            inbox(47, 208, 68, 192, "wave");
            inbox(20, 244, 36, 226, "spaz");
            inbox(48, 274, 69, 257, "charge");
            inbox(450, 185, 468, 170, "vaira");
            inbox(478, 188, 492, 168, "grav");
            inbox(451, 227, 470, 210, "space");
            inbox(477, 226, 494, 209, "s-attack");
            inbox(451, 265, 468, 251, "ball");
            inbox(479, 268, 496, 250, "bomb");
            redrawimage();
        }

    }
}
