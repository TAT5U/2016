using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//追加項目
using System.Runtime.InteropServices;
using System.Reflection;

namespace _22_kenkyuu
{
    public partial class Title : Form
    {
        //変数宣言
        int h, w;

        public Title()
        {
            InitializeComponent();

        }
        //読み込んだ時
        private void Form3_Load(object sender, EventArgs e)
        {
             
            //windowsの外枠を削除
            this.FormBorderStyle = FormBorderStyle.None;

            //最大化
            this.WindowState = FormWindowState.Maximized;

            //マウスカーソルの削除
            System.Windows.Forms.Cursor.Hide();

            //フォームの大きさ(ディスプレイ)を記録
            h = this.Height;
            w = this.Width;
            if (w*9==h*16)
            {
                //背景画像の大きさ
                this.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                //背景画像の大きさ
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }


            //背景画像の挿入
            this.BackgroundImage = Image.FromFile(@"start_background.jpg");

            //startのgifの挿入
            pictureBox1.Image = Image.FromFile(@"start.gif");

            //位置自動
            pictureBox1.Left = (this.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.Height - pictureBox1.Height) / 2;
        }
        //KeyPressイベント
        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Enterキーが押されたとき
            if (e.KeyChar == '\r')
            {
                //四則の選択画面を表示
                Selection f2 = new Selection();

                //メインフォームを変える
                Program.app.MainForm = f2;

                //form2の表示
                f2.Show();

                //リソースの解放
                this.Dispose();

                //閉じる
                this.Close();
            }
            //Escapeキーが押されたとき
            if (e.KeyChar==(char)Keys.Escape)
            {
                //終了
                Application.Exit();
            }
        }
    }
}