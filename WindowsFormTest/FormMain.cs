using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Width = 200;
            this.Height = 200;
            buttonJiandao = new Button();
            buttonJiandao.Location = new Point(25, 25);
            buttonJiandao.Text = "剪刀";
            
            buttonShitou = new Button();
            buttonShitou.Location = new Point(25, 50);
            buttonShitou.Text = "石头";

            buttonbu = new Button();
            buttonbu.Location = new Point(25, 75);
            buttonbu.Text = "布";

            player = new Label();
            player.Location = new Point(100, 30);
            pc = new Label();
            pc.Location = new Point(100, 60);

            result = new Label();
            result.Location = new Point(100, 80);
            this.Controls.Add(buttonJiandao);
            this.Controls.Add(buttonShitou);
            this.Controls.Add(buttonbu);
            this.Controls.Add(player);
            this.Controls.Add(pc);
            this.Controls.Add(result);

            this.buttonJiandao.Click += (s, e) => { onButtonJiandao(); };
            this.buttonShitou.Click += (s, e) => { onButtonShitou(); };
            this.buttonbu.Click += (s, e) => { onButtonBu(); };
        }


        private Button buttonJiandao;
        private Button buttonShitou;
        private Button buttonbu;
        private Label player;
        private Label pc;
        private Label result;

        private string playerText;
        private string pcText;
        private string resultText;

        private int str2num(string str)
        {
            if (str == "剪刀")
            {
                return 0;
            }

            if (str == "石头")
            {
                return 1;
            }

            if (str == "布")
            {
                return 2;
            }
            return -1;
        }

        private void pcSet()
        {
            Random ran = new Random();
            int ret = ran.Next(0, 3);

            switch (ret)
            {
                case 0: pcText = "剪刀";
                    break;
                case 1: pcText = "石头";
                    break;
                case 2: pcText = "布";
                    break;
                default: throw new Exception("unknown guessing");
            }
            pc.Text = pcText;
        }
        private string judgeResult(string playerText)
        {
            pcSet();
            pcText = pc.Text;

            int playerValue = str2num(playerText);
            int pcValue = str2num(pcText);

            if (playerValue == pcValue)
            {
                resultText = "even";
            }else if (playerValue - pcValue == 1 || (playerValue == 0 && pcValue == 2))
            {
                resultText = "You win!";
            }
            else
            {
                resultText = "PC win!";
            }
            result.Text = resultText;
            return resultText;
        }

        public void onButtonJiandao()
        {
            player.Text = buttonJiandao.Text;
            playerText = buttonJiandao.Text;
            resultText = judgeResult(playerText);
        }
        public void onButtonShitou()
        {
            player.Text = buttonShitou.Text;
            playerText = buttonShitou.Text;
            resultText = judgeResult(playerText);
        }
        public void onButtonBu()
        {
            player.Text = buttonbu.Text;
            playerText = buttonbu.Text;
            resultText = judgeResult(playerText);
        }

    }
}
