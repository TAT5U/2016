using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace _22_kenkyuu
{
    public partial class Selection : Form
    {
        //変数宣言
        int h, w,h2,w2;
        int i=1;
        
        //乱数の使用を可能にする
        Random rnd = new Random();

        public Selection()
        {
            InitializeComponent();  
        }
        //読み込んだ時
        private void Form2_Load(object sender, EventArgs e)
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

            //form2に背景画像の挿入
            BackgroundImage = Image.FromFile(@"sentaku_background.jpg");


            //足し算の部分のカーソル画像挿入
            this.pictureBox1.Image = Image.FromFile(@"arrow.png");
            this.pictureBox5.Image = Image.FromFile(@"arrow_1.png");

            //引き算の部分のカーソル画像挿入、不可視化
            this.pictureBox2.Image = Image.FromFile(@"arrow.png");
            this.pictureBox6.Image = Image.FromFile(@"arrow_1.png");
            this.pictureBox2.Visible = false;
            this.pictureBox6.Visible = false;

            //掛け算の部分のカーソル画像挿入、不可視化
            this.pictureBox3.Image = Image.FromFile(@"arrow.png");
            this.pictureBox7.Image = Image.FromFile(@"arrow_1.png");
            this.pictureBox3.Visible = false;
            this.pictureBox7.Visible = false;

            //割り算の部分のカーソル画像挿入、不可視化
            this.pictureBox4.Image = Image.FromFile(@"arrow.png");
            this.pictureBox8.Image = Image.FromFile(@"arrow_1.png");
            this.pictureBox4.Visible = false;
            this.pictureBox8.Visible = false;

            //スコアの部分のカーソル画像挿入、不可視化
            this.pictureBox9.Image = Image.FromFile(@"arrow.png");
            this.pictureBox10.Image = Image.FromFile(@"arrow_1.png");
            this.pictureBox9.Visible = false;
            this.pictureBox10.Visible = false;

            //大きさ自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label2.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label3.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label4.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label5.Font = new System.Drawing.Font("HGP明朝B", h / 15);

            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label2.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label3.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label4.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label5.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
            }
            pictureBox1.Width = label1.Height;
            pictureBox1.Height = label1.Height;
            pictureBox2.Width = label2.Height;
            pictureBox2.Height = label2.Height;
            pictureBox3.Width = label3.Height;
            pictureBox3.Height = label3.Height;
            pictureBox4.Width = label4.Height;
            pictureBox4.Height = label4.Height;
            pictureBox5.Width = label1.Height;
            pictureBox5.Height = label1.Height;
            pictureBox6.Width = label2.Height;
            pictureBox6.Height = label2.Height;
            pictureBox7.Width = label3.Height;
            pictureBox7.Height = label3.Height;
            pictureBox8.Width = label4.Height;
            pictureBox8.Height = label4.Height;
            pictureBox9.Width = label5.Height;
            pictureBox9.Height = label5.Height;
            pictureBox10.Width = label5.Height;
            pictureBox10.Height = label5.Height;

            //位置自動化
            label1.Left = (w - label1.Width) / 2;
            label2.Left = (w - label2.Width) / 2;
            label3.Left = (w - label3.Width) / 2;
            label4.Left = (w - label4.Width) / 2;
            label5.Left = (w - label5.Width) / 2;
            //label5.Left = label5.Left-(label5.Right - label1.Right);
            label3.Top = (h-label3.Height) / 2;
            label1.Top = ((label3.Top/2) - label1.Height)/2;
            label2.Top = ((label1.Top)+label2.Height*2);

            label4.Top = label3.Bottom + (label3.Top - label2.Bottom);
            label5.Top = (h - label1.Top)-label5.Height;
            pictureBox1.Left = label1.Left - pictureBox1.Width;
            pictureBox2.Left = label2.Left - pictureBox2.Width;
            pictureBox3.Left = label3.Left - pictureBox3.Width;
            pictureBox4.Left = label4.Left - pictureBox4.Width;
            pictureBox5.Left = label1.Right;
            pictureBox6.Left = label2.Right;
            pictureBox7.Left = label3.Right;
            pictureBox8.Left = label4.Right;
            pictureBox9.Left = label5.Left - pictureBox9.Width;
            pictureBox10.Left = label5.Right;
            pictureBox1.Top = label1.Top;
            pictureBox2.Top = label2.Top;
            pictureBox3.Top = label3.Top;
            pictureBox4.Top = label4.Top;
            pictureBox5.Top = label1.Top;
            pictureBox6.Top = label2.Top;
            pictureBox7.Top = label3.Top;
            pictureBox8.Top = label4.Top;
            pictureBox9.Top = label5.Top;
            pictureBox10.Top = label5.Top;

        }
        //KeyPressイベント
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escapeキーが押されたとき
            if (e.KeyChar == (char)Keys.Escape)
            {

                //タイトル画面を表示
                Title f3 = new Title();

                //メインフォームを変える
                Program.app.MainForm = f3;

                //f3の表示
                f3.Show();

                this.Dispose();

                //フォームを閉じる
                this.Close();
            }
            //Enterキーが押されたとき
            if (e.KeyChar == '\r')
            {
                //さらに、足し算のカーソルが可視化されていたとき
                if (pictureBox1.Visible== true)
                {
                    //問題数画面の表示
                    Question f6 = new Question();

                    //form6の変数iに1を格納
                    f6.i = 1;

                    //メインフォームを変える
                    Program.app.MainForm = f6;
                    
                    //f6の表示
                    f6.Show();

                    //リソースの解放
                    this.Dispose();

                    //フォームを閉じる
                    this.Close();
                }
                //また、引き算のカーソルが可視化されていたとき
                if (pictureBox2.Visible== true)
                {
                    //カーソルの位置を1番上の足し算にしておく
                    this.pictureBox1.Visible = true;
                    this.pictureBox2.Visible = false;
                    this.pictureBox3.Visible = false;
                    this.pictureBox4.Visible = false;
                    this.pictureBox5.Visible = true;
                    this.pictureBox6.Visible = false;
                    this.pictureBox7.Visible = false;
                    this.pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                    pictureBox10.Visible = false;

                    //変数iのカウントをリセット(1ならば足し算の位置にカーソルが変わる)
                    i = 1;

                    //問題数画面の表示
                    Question f6 = new Question();

                    //form6の変数iに2を格納
                    f6.i = 2;

                    //メインフォームを変える
                    Program.app.MainForm = f6;

                    //f6の表示
                    f6.Show();

                    //リソースの解放
                    this.Dispose();

                    //フォームを閉じる
                    this.Close();
                }
                //また、掛け算のカーソルが可視化されていたとき
                if (pictureBox3.Visible== true)
                {
                    //カーソルの位置を1番上の足し算にしておく
                    this.pictureBox1.Visible = true;
                    this.pictureBox2.Visible = false;
                    this.pictureBox3.Visible = false;
                    this.pictureBox4.Visible = false;
                    this.pictureBox5.Visible = true;
                    this.pictureBox6.Visible = false;
                    this.pictureBox7.Visible = false;
                    this.pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                    pictureBox10.Visible = false;

                    //変数iのカウントをリセット(1ならば足し算の位置にカーソルが変わる)
                    i = 1;

                    //問題数画面の表示
                    Question f6 = new Question();

                    //form6の変数iに3を格納
                    f6.i = 3;

                    //メインフォームを変える
                    Program.app.MainForm = f6;

                    //f6の表示
                    f6.Show();

                    //リソースの解放
                    this.Dispose();

                    //フォームを閉じる
                    this.Close();
                }
                //また、割り算のカーソルが可視化されていたとき
                if (pictureBox4.Visible== true)
                {
                    //カーソルの位置を1番上の足し算にしておく
                    this.pictureBox1.Visible = true;
                    this.pictureBox2.Visible = false;
                    this.pictureBox3.Visible = false;
                    this.pictureBox4.Visible = false;
                    this.pictureBox5.Visible = true;
                    this.pictureBox6.Visible = false;
                    this.pictureBox7.Visible = false;
                    this.pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                    pictureBox10.Visible = false;

                    //変数iのカウントをリセット(1ならば足し算の位置にカーソルが変わる)
                    i = 1;

                    //問題数画面の表示
                    Question f6 = new Question();

                    //form6の変数iに4を格納
                    f6.i = 4;

                    //メインフォームを変える
                    Program.app.MainForm = f6;

                    //f6の表示
                    f6.Show();

                    //リソースの解放
                    this.Dispose();

                    //フォームを閉じる
                    this.Close();
                }
                //また、scoreのカーソルが可視化されていたとき
                if (pictureBox9.Visible==true)
                {
                    //カーソルの位置を1番上の足し算にしておく
                    this.pictureBox1.Visible = true;
                    this.pictureBox2.Visible = false;
                    this.pictureBox3.Visible = false;
                    this.pictureBox4.Visible = false;
                    this.pictureBox5.Visible = true;
                    this.pictureBox6.Visible = false;
                    this.pictureBox7.Visible = false;
                    this.pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                    pictureBox10.Visible = false;

                    //変数iのカウントをリセット(1ならば足し算の位置にカーソルが変わる)
                    i = 1;

                    //ランキング画面の表示
                    Score f8 = new Score();

                    //form8の変数iに1を格納
                    f8.i = 1;

                    //メインフォームを変える
                    Program.app.MainForm = f8;

                    //f8の表示
                    f8.Show();

                    //リソースの解放
                    this.Dispose();

                    //フォームを閉じる
                    this.Close();
                }
            }
        }
        //KeyDownイベント
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            //↓が押されたとき
            if (e.KeyData == Keys.Down)
            {
                //変数iが4ならば
                if (i==5)
                {
                    //戻る
                    i = 1;
                }
                //それ以外ならば
                else
                {
                    //変数iを増やす
                    i += 1;
                }
            }
            //↑が押されたとき
            if (e.KeyData==Keys.Up)
            {
                //変数iが1ならば
                if (i==1)
                {
                    //戻る
                    i = 5;
                }
                //それ以外ならば
                else
                {
                    //変数iを減らす
                    i -= 1;
                }
            }
            //変数iが1ならば
            if (i==1)
            {
                //カーソルの位置を足し算にしておく
                this.pictureBox1.Visible = true;
                this.pictureBox2.Visible = false;
                this.pictureBox3.Visible = false;
                this.pictureBox4.Visible = false;
                this.pictureBox5.Visible = true;
                this.pictureBox6.Visible = false;
                this.pictureBox7.Visible = false;
                this.pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            }
            //変数iが2ならば
            if (i == 2)
            {
                //カーソルの位置を引き算にしておく
                this.pictureBox1.Visible = false;
                this.pictureBox2.Visible = true;
                this.pictureBox3.Visible = false;
                this.pictureBox4.Visible = false;
                this.pictureBox5.Visible = false;
                this.pictureBox6.Visible = true;
                this.pictureBox7.Visible = false;
                this.pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            }
            //変数iが3ならば
            if (i == 3)
            {
                //カーソルの位置を掛け算にしておく
                this.pictureBox1.Visible = false;
                this.pictureBox2.Visible = false;
                this.pictureBox3.Visible = true;
                this.pictureBox4.Visible = false;
                this.pictureBox5.Visible = false;
                this.pictureBox6.Visible = false;
                this.pictureBox7.Visible = true;
                this.pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            }
            //変数iが4ならば
            if (i == 4)
            {
                //カーソルの位置を割り算にしておく
                this.pictureBox1.Visible = false;
                this.pictureBox2.Visible = false;
                this.pictureBox3.Visible = false;
                this.pictureBox4.Visible = true;
                this.pictureBox5.Visible = false;
                this.pictureBox6.Visible = false;
                this.pictureBox7.Visible = false;
                this.pictureBox8.Visible = true;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            }
            //変数iが5ならば
            if (i==5)
            {
                //カーソルの位置をスコアにしておく
                this.pictureBox1.Visible = false;
                this.pictureBox2.Visible = false;
                this.pictureBox3.Visible = false;
                this.pictureBox4.Visible = false;
                this.pictureBox5.Visible = false;
                this.pictureBox6.Visible = false;
                this.pictureBox7.Visible = false;
                this.pictureBox8.Visible = false;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true; 
            }
        }
    }
}