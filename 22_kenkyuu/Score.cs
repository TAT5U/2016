using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//追加項目
using System.IO;
using System.Collections;

namespace _22_kenkyuu
{
    public partial class Score : Form
    {
        //変数宣言
        public int i = 0,i_s=0,v=0,w=0,h=0;
        public double sc = 0;

        public Score()
        {
            InitializeComponent();
        }

        //自作するリストの型
        public struct data
        {
            public double score;
            public string name;
        }
        //読み込んだ時
        private void Form8_Load(object sender, EventArgs e)
        {
            

            //背景画像の挿入
            this.BackgroundImage = Image.FromFile(@"rank.png");

            //変数宣言
            int cnt = 0, cnt2 = 0;

            //windowsの外枠を削除
            this.FormBorderStyle = FormBorderStyle.None;

            //最大化
            this.WindowState = FormWindowState.Maximized;

            //フォームの大きさ(ディスプレイ)を記録
            h = this.Height;
            w = this.Width;

            if (w * 9 == h * 16)
            {
                //背景画像の大きさ
                this.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                //背景画像の大きさ
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            //自作リストの宣言
            List<data> dict = new List<data>();

            //型が2つあるためここで宣言する
            data d;

            //CSVデータを読み込む
            System.IO.StreamReader reader = (new System.IO.StreamReader("score.csv", System.Text.Encoding.Default));
            System.IO.StreamReader readername = (new System.IO.StreamReader("score_name.csv", System.Text.Encoding.Default));

            //行ごとに読む
            while (reader.Peek() >= 0 || readername.Peek() >= 0)
            {
                //得点をdのscoreに格納
                d.score = double.Parse(reader.ReadLine());

                //名前をdのnameに格納
                d.name = readername.ReadLine();

                //得点と名前を格納
                dict.Add(d);
            }
            //CSVデータの読み込みをやめる
            reader.Close();
            readername.Close();

            //ソートしたdictをrankに格納して表示する
            foreach (data rank in dict.OrderByDescending(n=>n.score))
            {
                //10位まで表示する
                if (cnt < 10)
                {
                    cnt2 = 10 - cnt2;

                    if (cnt+1==10)
                    {
                        label1.Text += (string.Format("{0}位　{1}\n",cnt+1,rank.name));
                        label2.Text += (string.Format("{0}点\n",(int)rank.score));
                    }
                    else
                    {
                        label1.Text += (string.Format("  {0}位　{1}\n", cnt+1,rank.name));
                        label2.Text += (string.Format("{0}点\n",(int)rank.score));
                    }
                    cnt++;
                }
                else
                {
                    //抜け出す
                    break;
                }
            }
            //自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 18);
                label2.Font = new System.Drawing.Font("HGP明朝B", h / 18);

            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)32);
                label2.Font = new System.Drawing.Font("HGP明朝B", w / (int)32);
            }
            label1.Top = (h - label1.Height) / 2;
            label1.Left = w - ((w + (label1.Width + label2.Width)) / 2);
            label2.Top = label1.Top;
            label2.Left = label1.Right;


            //ロード画面の表示
            Load f9 = new Load();

            //ロード画面のcntに0を格納
            f9.cnt = 0;

            //f9の表示
            f9.Show(this);
        }
        //KeyPressイベント
        private void Form8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escapeキーが押されたとき
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (i==1)
                {
                    //四則の選択画面を表示
                    Selection f2 = new Selection();

                    //メインフォームを変える
                    Program.app.MainForm = f2;

                    //f2の表示
                    f2.Show();

                    //リソースの解放
                    this.Dispose();

                    //閉じる
                    this.Close();
                }
                if (i==2)
                {
                    //score画面の表示
                    Save_Data f7 = new Save_Data();

                    //プレイしたスコアを格納
                    f7.score = sc/10;

                    //メインフォームを変える
                    Program.app.MainForm = f7;
                    
                    //f7の表示
                    f7.Show();
                    //リソースの解放
                    this.Dispose();

                    //閉じる
                    this.Close();
                }
            }
        }
    }
}
