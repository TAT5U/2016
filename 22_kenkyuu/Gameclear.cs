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
    public partial class Gameclear : Form
    {
        //変数宣言
        public double score = 0.0;
        int h, w;
        public Gameclear()
        {
            InitializeComponent();
        }
        //読み込んだ時
        private void Form5_Load(object sender, EventArgs e)
        {
            //背景画像挿入
            this.BackgroundImage = Image.FromFile(@"gameclear.png");

            //マウスカーソルの削除
            System.Windows.Forms.Cursor.Hide();

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
            //自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
            }
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;

            //ロード画面を表示
            Load f9 = new Load();

            //ロード画面のcntに1を格納
            f9.cnt = 1;
            //f9を表示(上から表示)
            f9.Show(this);
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //score画面の表示
                Save_Data f7 = new Save_Data();

                //f7のscoreにscoreを格納
                f7.score = score;

                //メインフォームを変える
                Program.app.MainForm = f7;

                //f7を表示
                f7.Show();

                //リソースの解放
                this.Dispose();

                //閉じる
                this.Close();
            }
            //Escapeキーが押されたとき
            if (e.KeyChar == (char)Keys.Escape)
            {
                //タイトル画面を表示
                Title f1 = new Title();

                //メインフォームを変える
                Program.app.MainForm = f1;

                //f1を表示
                f1.Show();

                //リソースの解放
                this.Dispose();

                //フォームを閉じる
                this.Close();
            }
        }
    }
}