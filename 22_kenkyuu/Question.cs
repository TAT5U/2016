using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//追加項目
using System.Threading;

namespace _22_kenkyuu
{
    public partial class Question : Form
    {
        //乱数の使用を可能にする
        Random rnd = new Random();

        //変数宣言(別フォムでも使用)
        public int i=0,time=0,kazu=0;
        public string rcnt;
        int h, w;

        public Question()
        {
            InitializeComponent();
        }
        //読み込んだ時
        private void Form6_Load(object sender, EventArgs e)
        {
            //windowsの外枠を削除
            FormBorderStyle = FormBorderStyle.None;

            //最大化
            WindowState = FormWindowState.Maximized;

            //フォームの大きさ(ディスプレイ)を記録
            h = this.Height;
            w = this.Width;

            //背景画像の挿入
            BackgroundImage = Image.FromFile(@"sub.jpg");
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
            //文字数制限
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 2;

            //カーソル画像挿入
            pictureBox1.Image = Image.FromFile(@"arrow.png");
            pictureBox2.Image = Image.FromFile(@"arrow.png");

            //2番目のカーソルを非表示にしておく
            pictureBox2.Visible = false;

            //自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label2.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label3.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label4.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label5.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label6.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label7.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                textBox1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                textBox2.Font = new System.Drawing.Font("HGP明朝B", h / 15);
            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label2.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label3.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label4.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label5.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label6.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label7.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                textBox1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                textBox2.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
            }
            pictureBox1.Width = label7.Height;
            pictureBox1.Height = label7.Height;
            pictureBox2.Height = label3.Height;
            pictureBox2.Width = label3.Height;

            label1.Left = (w - label1.Width) / 2;
            label1.Top = (h-label1.Height)/3;
            pictureBox1.Left = label1.Left;
            pictureBox1.Top = label1.Bottom + (label1.Bottom / 10);
            label7.Left = pictureBox1.Right;
            label7.Top = pictureBox1.Top;
            label5.Left = label7.Right;
            label5.Top = label7.Top;
            label5.Width = 0;
            textBox1.Left = label7.Right;
            textBox1.Top = label7.Top;
            label2.Left = label5.Right;
            label2.Top = label5.Top;

            pictureBox2.Left = label1.Left;
            pictureBox2.Top = pictureBox1.Bottom + (pictureBox1.Bottom / 10);
            label3.Left = pictureBox2.Right;
            label3.Top = pictureBox2.Top;
            textBox2.Left = label3.Right;
            textBox2.Top = label3.Top;
            textBox2.Width = 0;
            textBox2.Height = label6.Height;
            textBox1.Width = 0;
            textBox1.Height = label5.Height;
            label6.Left = label3.Right;
            label6.Top = label3.Top;
            label6.Width = 0;
            label4.Left = textBox2.Right;
            label4.Top = label6.Top;
            //ロード画面の表示
            Load f9 = new Load();

            //ロード画面のcntに0を格納
            f9.cnt = 0;

            //f9の表示
            f9.Show(this);
        }
        //textBox1に入力されたとき
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escapeキーが押されたとき
            if (e.KeyChar == (char)Keys.Escape)
            {
                //タイトル画面を表示
                Title f1 = new Title();

                //メインフォームを変える
                Program.app.MainForm = f1;

                //f1を表示
                f1.Show();

                //リソースを解放
                this.Dispose();

                //フォームを閉じる
                this.Close();
            }
            //Enterキーが押されたとき
            if (e.KeyChar == '\r')
            {
                //さらに、textBox1に何も数字がないとき
                if (textBox1.Text == "")
                {
                }
                //0,00,000のときクリアする
                else if ((textBox1.Text=="0")||(textBox1.Text=="00")||(textBox1.Text=="000"))
                {
                    textBox1.Clear();
                }
                //そうでなければ 制限時間のほうに移動する
                else
                {
                    //変数にtext1の文字を入れる
                    kazu = int.Parse(textBox1.Text);

                    //text2に移動して入力できるようにする
                    textBox2.Focus();

                    //1番目のカーソルを非表示にする
                    this.pictureBox1.Visible = false;

                    //2番目のカーソルを表示させる
                    this.pictureBox2.Visible = true;
                }
            }
            //0～9と、バックスペース以外の時は入力されないようにする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        //textBox2に入力されたとき
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Escapeキーが押されたとき
            if (e.KeyChar == (char)Keys.Escape)
            {
                //タイトル画面を表示
                Title f1 = new Title();

                //メインフォームを変える
                Program.app.MainForm = f1;

                //f1を表示
                f1.Show();

                //リソースを解放
                this.Dispose();

                //フォームを閉じる
                this.Close();
            }
            //Enterキーが押されたとき
            if (e.KeyChar == '\r')
            {
                //さらに、textBox1に何も数字がないとき
                if (textBox2.Text == "")
                {
                }
                //0,00のときクリアする
                else if ((textBox2.Text=="0")||(textBox2.Text=="00"))
                {
                    textBox2.Clear();
                }
                //そうでなければ 計算問題を出す
                else
                {
                    //足し算を表示する
                    if (i==1)
                    {
                        //足し算
                        Main f1 = new Main();

                        if (w * 9 == h * 16)
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        else
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        //f1に背景画像の挿入
                        f1.BackgroundImage = Image.FromFile(@"addition_background.png");

                        //乱数格納
                        f1.a = rnd.Next(1, 10);
                        f1.b = rnd.Next(1, 10);

                        //問題の値を表示
                        f1.label1.Text = f1.a.ToString();
                        f1.label3.Text = f1.b.ToString();

                        //四則の記号の表示
                        f1.label2.Text = "＋";

                        //計算
                        f1.atai = f1.a + f1.b;

                        //敵画像表示
                        f1.pictureBox1.Image = Image.FromFile(@"mon1.png");

                        //f1の変数に問題数と制限時間の値を格納する
                        f1.kazu = int.Parse(textBox1.Text);
                        f1.time = int.Parse(textBox2.Text);

                        //2問目以降のために保存する
                        f1.kioku = int.Parse(textBox2.Text);

                        //時間表示
                        f1.label7.Text = "あと" + int.Parse(textBox2.Text) + "秒";

                        //文字型rcntに1を格納
                        rcnt = "1".ToString();

                        //f1の変数cntに文字数rcntをintに変換して格納
                        f1.cnt = int.Parse(rcnt);

                        //メインフォームを変える
                        Program.app.MainForm = f1;

                        //f1を表示
                        f1.Show();

                        //リソースの解放
                        this.Dispose();

                        //閉じる
                        this.Close();
                    }
                    //引き算を表示する
                    if (i==2)
                    {
                        //引き算
                        Main f1 = new Main();

                        if (w * 9 == h * 16)
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        else
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        //f1に背景画像の挿入
                        f1.BackgroundImage = Image.FromFile(@"subtraction_background.png");

                        //乱数格納
                        f1.a = rnd.Next(1, 10);
                        f1.b = rnd.Next(1, 10);

                        //変数bが変数aより大きい時はループさせる
                        while (f1.b > f1.a)
                        {
                            //乱数格納
                            f1.a = rnd.Next(1, 10);
                            f1.b = rnd.Next(1, 10);
                        }
                        //問題の値を表示
                        f1.label1.Text = f1.a.ToString();
                        f1.label3.Text = f1.b.ToString();

                        //四則の記号の表示
                        f1.label2.Text = "－";

                        //計算
                        f1.atai = f1.a - f1.b;

                        //敵画像表示
                        f1.pictureBox1.Image = Image.FromFile(@"mon2.png");

                        //f1の変数に問題数と制限時間の値を格納する
                        f1.kazu = int.Parse(textBox1.Text);
                        f1.time = int.Parse(textBox2.Text);

                        //2問目以降のために保存する
                        f1.kioku = int.Parse(textBox2.Text);

                        //時間表示
                        f1.label7.Text = "あと" + int.Parse(textBox2.Text) + "秒";

                        //文字型rcntに2を格納
                        rcnt = "2".ToString();

                        //f1の変数cntに文字数rcntをintに変換して格納
                        f1.cnt = int.Parse(rcnt);

                        //メインフォームを変える
                        Program.app.MainForm = f1;

                        //f1を表示
                        f1.Show();

                        //リソースの解放
                        this.Dispose();

                        //閉じる
                        this.Close();
                    }
                    //掛け算を表示する
                    if (i==3)
                    {
                        //掛け算
                        Main f1 = new Main();

                        if (w * 9 == h * 16)
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        else
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        //f1に背景画像の挿入
                        f1.BackgroundImage = Image.FromFile(@"Multiplication_background.png");

                        //乱数格納
                        f1.a = rnd.Next(1, 10);
                        f1.b = rnd.Next(1, 10);

                        //問題の値を表示
                        f1.label1.Text = f1.a.ToString();
                        f1.label3.Text = f1.b.ToString();
 

                        //四則の記号の表示
                        f1.label2.Text = "×";

                        //計算
                        f1.atai = f1.a * f1.b;

                        //敵画像表示
                        f1.pictureBox1.Image = Image.FromFile(@"mon3.png");

                        //f1の変数に問題数と制限時間の値を格納する
                        f1.kazu = int.Parse(textBox1.Text);
                        f1.time = int.Parse(textBox2.Text);

                        //2問目以降のために保存する
                        f1.kioku = int.Parse(textBox2.Text);

                        //時間表示
                        f1.label7.Text = "あと" + int.Parse(textBox2.Text) + "秒";

                        //文字型rcntに3を格納
                        rcnt = "3".ToString();

                        //f1の変数cntに文字数rcntをintに変換して格納
                        f1.cnt = int.Parse(rcnt);

                        //メインフォームを変える
                        Program.app.MainForm = f1;

                        //f1を表示
                        f1.Show();

                        //リソースの解放
                        this.Dispose();

                        //閉じる
                        this.Close();
                    }
                    //割り算を表示する
                    if (i==4)
                    {
                        //割り算
                        Main f1 = new Main();

                        if (w * 9 == h * 16)
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        else
                        {
                            //背景画像の大きさ
                            f1.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        //f1に背景画像の挿入
                        f1.BackgroundImage = Image.FromFile(@"division_background.png");

                        //乱数格納
                        f1.a = rnd.Next(1, 10);
                        f1.b = rnd.Next(1, 10);

                        //割ってあまりが出た時、変数a,bが同じの時はループさせる
                        //変数a,bが同じだと簡単すぎるのでループさせている
                        while (f1.a % f1.b != 0 || f1.a == f1.b)
                        {
                            //乱数格納
                            f1.a = rnd.Next(1, 10);
                            f1.b = rnd.Next(1, 10);
                        }
                        //問題の値を表示
                        f1.label1.Text = f1.a.ToString();
                        f1.label3.Text = f1.b.ToString();
;

                        //四則の記号の表示
                        f1.label2.Text = "÷";

                        //計算
                        f1.atai = f1.a / f1.b;

                        //敵画像表示
                        f1.pictureBox1.Image = Image.FromFile(@"mon4.png");

                        //f1の変数に問題数と制限時間の値を格納する
                        f1.kazu = int.Parse(textBox1.Text);
                        f1.time = int.Parse(textBox2.Text);

                        //2問目以降のために保存する
                        f1.kioku = int.Parse(textBox2.Text);

                        //時間表示
                        f1.label7.Text = "あと" + int.Parse(textBox2.Text) + "秒";
                        //文字型rcntに4を格納
                        rcnt = "4".ToString();

                        //f1の変数cntに文字数rcntをintに変換して格納
                        f1.cnt = int.Parse(rcnt);

                        //メインフォームを変える
                        Program.app.MainForm = f1;

                        //f1を表示
                        f1.Show();

                        //リソースの解放
                        this.Dispose();

                        //閉じる
                        this.Close();
                    }
                }
            }
            //バックスペースを押したとき
            if (e.KeyChar=='\b')
            {
                //textBox2が何もなくてフォーカスされているとき
                if (textBox2.Text=="")
                {
                    //初期化
                    textBox2.Clear();

                    //text2に移動して入力できるようにする
                    textBox1.Focus();

                    //1番目のカーソルを表示にする
                    this.pictureBox1.Visible = true;

                    //2番目のカーソルを非表示させる
                    this.pictureBox2.Visible = false;    
                }
            }
            //0～9と、バックスペース以外の時は入力されないようにする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /*以下のプログラムは入力された値を表示するためで、テキストボックスのままだと背景画像が適用されないため
          ラベルに表示させている*/

        //textBox1に入力されたとき
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //ラベルに表示
            label5.Text = textBox1.Text.ToString();
        }
        //textBox2に入力されたとき
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //ラベルに表示
            label6.Text = textBox2.Text.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            Size si = TextRenderer.MeasureText(s, textBox1.Font);
            textBox1.Width = si.Width;
            label5.Height = textBox1.Height;
            label5.Width = textBox1.Width;
            label2.Left = textBox1.Right;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string s = textBox2.Text;
            Size si = TextRenderer.MeasureText(s, textBox2.Font);
            textBox2.Width = si.Width;
            label6.Height = textBox2.Height;
            label6.Width = textBox2.Width;
            label4.Left = textBox2.Right;
        }
    }
}