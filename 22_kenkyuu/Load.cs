using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _22_kenkyuu
{
    public partial class Load : Form
    {
        //変数宣言
        public Question form6;
        public int a = 0,cnt=0,h,w;

        public Load()
        {
            InitializeComponent();

        }

        private void Load_Load(object sender, EventArgs e)
        {
            //マウスカーソルの削除
            System.Windows.Forms.Cursor.Hide();

            //windowsの外枠を削除
            this.FormBorderStyle = FormBorderStyle.None;

            //最大化
            this.WindowState = FormWindowState.Maximized;

            //フォームの大きさ(ディスプレイ)を記録
            h = this.Height;
            w = this.Width;

            //ロード中のgifを挿入
            pictureBox1.Image = Image.FromFile(@"Load.gif");

            //自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
            }
            pictureBox1.Width = label1.Height;
            pictureBox1.Height = label1.Height;
            label1.Top = h - (label1.Height+label1.Height/2);
            label1.Left = w - (label1.Width + pictureBox1.Width);
            pictureBox1.Left = label1.Right;
            pictureBox1.Top = label1.Top;


            if (cnt==0)
            {   
                //タイマーをON
                timer1.Enabled = true;
            }
            if (cnt==1)
            {
                //タイマーをON
                timer2.Enabled = true;
            }
        }
        //KeyPressイベント
        private void Load_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escapeキーが押されたとき
            if (e.KeyChar == (char)Keys.Escape)
            {
                //リソースの解放
                this.Dispose();

                //フォームを閉じる
                this.Close();
            }
        }
        //ロード中の表示の切り替え
        private void timer1_Tick(object sender, EventArgs e)
        {
                if (a <= 3)
                {
                    //cntに0を格納
                    cnt = 0;

                    //リソースの解放
                    this.Dispose();

                    //閉じる
                    this.Close();

                    //タイマーを止める
                    timer1.Enabled = false;
                }
                else
                {
                    //カウント
                    a++;
                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (a <= 1)
            {
                //cntに0を格納
                cnt = 0;

                //リソースの解放
                this.Dispose();

                //閉じる
                this.Close();

                //タイマーを止める
                timer1.Enabled = false;
            }
            else
            {
                //カウント
                a++;
            }
        }
    }
}