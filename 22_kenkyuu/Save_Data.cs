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
using System.Security.Permissions;

namespace _22_kenkyuu
{
    public partial class Save_Data : Form
    {
        //変数宣言
        string s1;
        public double score;

        int h, w;

        //Listの宣言(重複防止)
        List<string> name = new List<string>();

        public Save_Data ()
        {
            InitializeComponent();
        }
        //読み込んだ時
        private void Form7_Load(object sender, EventArgs e)
        {
            //文字入力数を制限
            textBox1.MaxLength = 9;


            textBox1.Width = 0;

            //背景画像の挿入
            this.BackgroundImage = Image.FromFile(@"scorehoge.png");

            //スコアの計算
            score = score * 10;

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

            //マウスカーソルの削除
            System.Windows.Forms.Cursor.Hide();

            //Tabキーの無効化
            textBox1.TabStop = false;
            button1.TabStop = false;
            button2.TabStop = false;

            //カーソル設定
            pictureBox1.Image = Image.FromFile(@"arrow.png");
            pictureBox2.Image = Image.FromFile(@"arrow_1.png");
            pictureBox3.Image = Image.FromFile(@"arrow.png");
            pictureBox4.Image = Image.FromFile(@"arrow_1.png");
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;


            //スコアの表示
            label2.Text = "あなたのスコアは" + (int)score + "点です!";

            //名前の重複防止
            System.IO.StreamReader read = (new System.IO.StreamReader("score_name.csv", System.Text.Encoding.Default));

            //行ごとに読み込む
            while (read.Peek() >= 0 )
            {
                name.Add(read.ReadLine());
            }
            read.Close();

            //自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label2.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label3.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                textBox1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                button1.Font = new System.Drawing.Font("HGP明朝B", h / (int)41.53);
                button2.Font = new System.Drawing.Font("HGP明朝B", h / (int)41.53);
                button1.Width = h / (int)5.02;
                button1.Height = h / (int)14.21;
                button2.Width = h / (int)5.02;
                button2.Height = h / (int)14.21;

            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label2.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label3.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                textBox1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                button1.Font = new System.Drawing.Font("HGP明朝B", w / (int)73.84);
                button2.Font = new System.Drawing.Font("HGP明朝B", w / (int)73.84);
                button1.Width = w / (int)8.93;
                button1.Height = w / (int)25.26;
                button2.Width = w / (int)8.93;
                button2.Height = w / (int)25.26;
            }
            pictureBox1.Width = button1.Height;
            pictureBox1.Height = button1.Height;
            pictureBox2.Width = button1.Height;
            pictureBox2.Height = button1.Height;
            pictureBox3.Width = button2.Height;
            pictureBox3.Height = button2.Height;
            pictureBox4.Width = button2.Height;
            pictureBox4.Height = button2.Height;

            label2.Top = (h-(h - (label1.Height / 2)))+label2.Height*2;
            label2.Left = (w - label2.Width) / 2;
            label1.Top = label2.Bottom+(label2.Bottom/2);
            label1.Left = label2.Left;
            textBox1.Top = label1.Top;
            textBox1.Left = label1.Right;
            // button1.Left = ((w / 2) - button1.Width)/2;
            button1.Left = label2.Left;
            button1.Top = (button1.Height + ((h - button1.Height) / 2)) + label2.Height * 2;
            // button2.Left = (w/2)+(((w / 2) - button1.Width) / 2);
            button2.Left = label2.Right - button2.Width;
            button2.Top = (button2.Height + ((h - button2.Height) / 2)) + label2.Height * 2;

            pictureBox1.Left = button1.Left - pictureBox1.Width;
            pictureBox1.Top = button1.Top;
            pictureBox2.Left = button1.Right;
            pictureBox2.Top = button1.Top;
            pictureBox3.Left = button2.Left - pictureBox3.Width;
            pictureBox3.Top = button2.Top;
            pictureBox4.Left = button2.Right;
            pictureBox4.Top = button2.Top;
           
            label3.Height = textBox1.Height;
            label3.Width = textBox1.Width;
            label3.Left = textBox1.Left;
            label3.Top = textBox1.Top;

            //ロード画面を表示
            Load f9 = new Load();

            //ロード画面のcntに1を格納
            f9.cnt = 1;

            //f9を表示(上から表示)
            f9.Show(this);
        }
        //button2クリックイベント
        public void button2_Click(object sender, EventArgs e)
        {
            //ランキング画面を表示
            Score f8 = new Score();
            //ランキング画面のiに2を格納
            f8.i = 2;

            //ランキング画面のscにスコアを格納
            f8.sc = score;

            //メインフォームを変える
            Program.app.MainForm = f8;

            //f8を表示
            f8.Show();

            //リソースを解放
            this.Dispose();

            //閉じる
            this.Close();
        }
        //KeyPressイベント
        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar=='\r')
            {
                //何もなければ何もしない
                if (textBox1.Text=="")
                {
                    
                }
                else
                {
                    //ニックネーム重複防止
                    if (name.Contains(textBox1.Text)==true)
                    {
                        MessageBox.Show("このニックネームは既に使用されています。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //自動でフォーカス移動
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = true;
                        button1.Focus();
                    }
                } 
            }
        }
        //KeyPressイベント
        private void Form7_KeyPress(object sender, KeyPressEventArgs e)
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
        }
        //button1クリックイベント
        private void button1_Click(object sender, EventArgs e)
        {
            //名前を変数に格納
            s1 = textBox1.Text;

            //保存
            File.AppendAllText("score.csv", score.ToString() + "\n", Encoding.Default);
            File.AppendAllText("score_name.csv", s1.ToString() + "\n", Encoding.Default);

            //タイトル画面を表示
            Title f1 = new Title();

            //メインフォームを変える
            Program.app.MainForm = f1;

            //f1を表示
            f1.Show();

            //リソースを解放
            this.Dispose();

            //閉じる
            this.Close();
        }
        //KeyPressイベント
        private void button1_KeyPress(object sender, KeyPressEventArgs e)
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

                //閉じる
                this.Close();
            }
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
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

                //閉じる
                this.Close();
            }
        }
        //KeyDownイベント
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            //↑キーと↓キーを無効化
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.Handled = true;
            }
            else
            {
                //→キーの処理
                if (e.KeyData == Keys.Right)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    button2.Focus();

                }
                //←キーの処理
                if (e.KeyData == Keys.Left)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    textBox1.Focus();
                }

            }
        }
        //KeyDownイベント
        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            //↑キーと↓キーを無効化
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.Handled = true;
            }
            //→キーの処理
            if (e.KeyData == Keys.Right)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                textBox1.Focus();

            }
            //←キーの処理
            if (e.KeyData == Keys.Left)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                button1.Focus();
            }
        }
        //PreviewKeyDownイベント
        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //特殊キーを通常キーにする
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Left || e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
            string s = textBox1.Text;
            Size si = TextRenderer.MeasureText(s, textBox1.Font);
            textBox1.Width = si.Width;
            label3.Width = textBox1.Width; ;
            label3.Height = textBox1.Height;
        }

        //PreviewKeyDownイベント
        private void button2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //特殊キーを通常キーにする
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Left || e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }
    }
}