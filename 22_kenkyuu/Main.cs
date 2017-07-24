using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//WindowsMediaPlayerを使用するため
using WMPLib;

namespace _22_kenkyuu
{
    public partial class Main : Form
    {
       //変数宣言(別フォムでも使用) cntで四則を判別する
        public int cnt, cnt2, cnt3, a, b, atai, hozon, kazu, time, miss, kioku, sc;
        public double score;

        //変数宣言
        int c, h, w,i=0,hp_w,hp_h;
        int time2=2;

        //乱数の使用を可能にする
        Random rnd = new Random();

        //WindowsMediaPlayerのplayerを宣言
        WindowsMediaPlayer player1,player2,player3;
        
        public Main()
        {
            InitializeComponent();
        }
        //読み込んだ時
        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowsMediaPlayerを使用可能にする
            player1 = new WindowsMediaPlayer();
            player2 = new WindowsMediaPlayer();
            player3 = new WindowsMediaPlayer();

            //サウンドを挿入
            player1.URL = (@"bomb.mp3");
            player2.URL = (@"game_battle.mp3");
            player3.URL = (@"monster.mp3");

            //戦闘曲が止まったら、また再生させる
            player2.settings.setMode("loop", true);

            //最初の自動再生を防ぐため、再生を停止させる
            player1.controls.stop();
            player3.controls.stop();

            //マウスカーソルの削除
            System.Windows.Forms.Cursor.Hide();

            //windowsの外枠を削除
            this.FormBorderStyle = FormBorderStyle.None;

            //最大化
            this.WindowState = FormWindowState.Maximized;

            //フォームの大きさ(ディスプレイ)を記録
            h = this.Height;
            w = this.Width;

            //敵画像表示はform2で表示させている
            //敵の大きさ 画面÷5の大きさ
            pictureBox1.Height = h / 5;
            pictureBox1.Width = w / 5;

            //敵の位置 幅÷3,高さ÷2の位置に配置
            pictureBox1.Location = new Point(w / 3, h / 2);

            //timer1を有効化
            timer1.Enabled = true;

            //文字数制限
            textBox1.MaxLength = 9;

            //HPゲージタイトル
            //HPゲージタイトルの位置 左上に配置
            pictureBox2.Location = new Point(0, 0);

            //HPゲージタイトルの画像表示
            pictureBox2.Image = Image.FromFile(@"HP.png");

            //HPゲージタイトルの大きさを記録
            hp_w = pictureBox2.Bounds.Width;
            hp_h = pictureBox2.Bounds.Height;

            //HPゲージ
            //HPゲージの大きさ 幅-HPゲージタイトル幅,HPゲージタイトルの高さの大きさ
            pictureBox3.Width = w - hp_w;
            pictureBox3.Height = hp_h;

            //HPゲージの位置 HPゲージタイトルのすぐ右隣に配置
            pictureBox3.Location = new Point(hp_w,0);

            //HPゲージの表示
            pictureBox3.Image = Image.FromFile(@"hp_max.png");

            //問題の回数を数える
            cnt2 = 1;

            label8.Text = cnt2.ToString()+"問目";

            //score配分
            sc = 100 - time;

            //自動調整
            if (w > h)
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label2.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label3.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label4.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label5.Font = new System.Drawing.Font("HGP明朝B", h / (int)18);
                label6.Font = new System.Drawing.Font("HGP明朝B", h / (int)13.5);
                label7.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label8.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                label9.Font = new System.Drawing.Font("HGP明朝B", h / 15);
                textBox1.Font = new System.Drawing.Font("HGP明朝B", h / 15);
            }
            else
            {
                label1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label2.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label3.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label4.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label5.Font = new System.Drawing.Font("HGP明朝B", w / (int)32);
                label6.Font = new System.Drawing.Font("HGP明朝B", w / 24);
                label7.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label8.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                label9.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
                textBox1.Font = new System.Drawing.Font("HGP明朝B", w / (int)26.6);
            }
            label7.Top = pictureBox2.Bottom + (pictureBox2.Bottom / 2);
            label7.Left = (w - pictureBox2.Width / 2)-label7.Width;
            label8.Top = pictureBox2.Bottom + (pictureBox2.Bottom / 2);
            label8.Left = pictureBox2.Width / 2;


            label2.Left = (w - label2.Width) / 2;
            label1.Left = label2.Left - label1.Width;
            label3.Left = label2.Right;
            label4.Left = label3.Right;
            label5.Left = 0;
            label5.Top=h-label5.Height*3;
            textBox1.Left = label4.Right;
            textBox1.Width = 0;
            textBox1.Height = label4.Height;
            label9.Height = textBox1.Height;
            label9.Width = textBox1.Width;
            pictureBox1.Top = label2.Bottom;
            pictureBox1.Left = (w - pictureBox1.Width) / 2;
            label9.Left = textBox1.Left;
            label9.Top = textBox1.Top;
            label6.Top = label5.Top;
            label6.Left = pictureBox1.Right+pictureBox1.Width;
        }
        //KeyPressイベント
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Enterキーが押されたとき
            if (e.KeyChar == '\r')
            {
                //さらに、textBox1に何も数字がないとき
                if (textBox1.Text == "")
                {
                }
                //数字があった時
                else
                {
                    //サウンドを連続して再生できるように1回停止させる
                    player1.controls.stop();
                    player3.controls.stop();

                    //時間不可視化
                    label7.ResetText();

                    //textBox1の中身をintに変換して変数cに格納
                    c = int.Parse(textBox1.Text);

                    //計算結果が正しければ
                    if (c == atai)
                    {
                        //スコアアップ
                        score =score+(sc*0.1);

                        //kaunt2のカウントを進める
                        cnt2 = cnt2 + 1;

                        label8.Text = cnt2.ToString()+"問目";

                        //timer1を無効化
                        timer1.Enabled = false;

                        //答えを変数hozonに格納
                        hozon = atai;

                        //正解だということを知らせる
                        label5.Text = "正解!!";

                        //HPを回復させる
                        //missのカウントが1回の時
                        if (miss == 1)
                        {
                            //HPを回復 3分の2からマックスに
                            pictureBox3.Image = Image.FromFile(@"hp_max.png");

                            //missのカウントを減らす 次間違った際にHPゲージが1つ飛ばされるのを防ぐ
                            miss = miss - 1;
                        }
                        //missのカウントが2回の時
                        if (miss == 2)
                        {
                            //HPを回復 3分の1から3分の2に
                            pictureBox3.Image = Image.FromFile(@"hp_3_2.png");

                            //missのカウントを減らす 次間違った際にHPゲージが1つ飛ばされるのを防ぐ
                            miss = miss - 1;
                        }
                        //カウントリフレッシュ
                        i = 0;

                        //timer3の有効化
                        timer3.Enabled = true;


                        //敵の画像から爆発のエフェクトに変更
                        pictureBox1.Image = Image.FromFile(@"bakuha.gif");

                        //爆発サウンドの再生
                        player1.controls.play();


                        //変数time2に2を格納
                        time2 = 2;

                        //timer2の有効化
                        timer2.Enabled = true;

                        //テキストクリア
                        textBox1.ResetText();

                        //難易度調整
                        //最初の桁 1桁
                        if ((cnt2 <= 1) || (cnt2 < kazu/3))
                        {
                            //乱数格納
                            a = rnd.Next(1, 10);
                            b = rnd.Next(1, 10);

                            //cntが2のとき
                            if (cnt == 2)
                            {
                                //変数bが変数aより大きい時はループさせる
                                while (b > a)
                                {
                                    //乱数格納
                                    a = rnd.Next(1, 10);
                                    b = rnd.Next(1, 10);
                                }
                            }
                            //cntが4のとき
                            if (cnt == 4)
                            {
                                //割ってあまりが出た時、変数a,bが同じの時はループさせる
                                //変数a,bが同じだと簡単すぎるのでループさせている
                                while (a % b != 0 || a == b)
                                {
                                    //乱数格納
                                    a = rnd.Next(1, 10);
                                    b = rnd.Next(1, 10);
                                }
                            }
                            //問題の値を表示
                            label1.Text = a.ToString();
                            label3.Text = b.ToString();
                            label1.Left = label2.Left - label1.Width;
                            label4.Left = label3.Right;
                            textBox1.Left = label4.Right;
                            label9.Left = textBox1.Left;
                            label9.Top = textBox1.Top;
                        }
                        //2桁にレベルアップ
                        else if ((cnt2 <= kazu/3) || (cnt2 < (kazu/3)*2))
                        {
                            //乱数格納
                            a = rnd.Next(10, 100);
                            b = rnd.Next(10, 100);

                            //cntが2のとき
                            if (cnt == 2)
                            {
                                //変数bが変数aより大きい時はループさせる
                                while (b > a)
                                {
                                    //乱数格納
                                    a = rnd.Next(10, 100);
                                    b = rnd.Next(10, 100);
                                }
                            }
                            //cntが4のとき
                            if (cnt == 4)
                            {
                                //割ってあまりが出た時、変数a,bが同じの時はループさせる
                                //変数a,bが同じだと簡単すぎるのでループさせている
                                while (a % b != 0 || a == b)
                                {
                                    //乱数格納
                                    a = rnd.Next(10, 100);
                                    b = rnd.Next(10, 100);
                                }
                            }
                            //問題の値を表示
                            label1.Text = a.ToString();
                            label3.Text = b.ToString();
                            label1.Left = label2.Left - label1.Width;
                            label4.Left = label3.Right;
                            textBox1.Left = label4.Right;
                            label9.Left = textBox1.Left;
                            label9.Top = textBox1.Top;
                        }
                        //3桁にレベルアップ
                        else if ((cnt2 <= (kazu/3)*2) || (cnt2 <= kazu))
                        {
                            //乱数格納
                            a = rnd.Next(100, 1000);
                            b = rnd.Next(100, 1000);

                            //cntが2のとき
                            if (cnt == 2)
                            {
                                //変数bが変数aより大きい時はループさせる
                                while (b > a)
                                {
                                    //乱数格納
                                    a = rnd.Next(100, 1000);
                                    b = rnd.Next(100, 1000);
                                }
                            }
                            //cntが4のとき
                            if (cnt == 4)
                            {
                                //割ってあまりが出た時、変数a,bが同じの時はループさせる
                                //変数a,bが同じだと簡単すぎるのでループさせている
                                while (a % b != 0 || a == b)
                                {
                                    //乱数格納
                                    a = rnd.Next(100, 1000);
                                    b = rnd.Next(100, 1000);
                                }
                            }
                            //問題の値を表示
                            label1.Text = a.ToString();
                            label3.Text = b.ToString();
                            label1.Left = label2.Left - label1.Width;
                            label4.Left = label3.Right;
                            textBox1.Left = label4.Right;
                            label9.Left = textBox1.Left;
                            label9.Top = textBox1.Top;
                        }
                        else
                        {
                            //サウンド停止
                            player1.controls.stop();
                            player2.controls.stop();
                            player3.controls.stop();

                            //timerをすべて無効
                            timer1.Enabled = false;
                            timer2.Enabled = false;
                            timer3.Enabled = false;

                            //f5を表示させる
                            Gameclear f5 = new Gameclear();
                            f5.score = score;
                            Program.app.MainForm = f5;

                            //f5を表示
                            f5.Show();

                            this.Dispose();

                            //f5が閉じたときにこのフォームも閉じる
                            this.Close();
                        }
                        //ここは計算 共通部分
                        //足し算
                        if (cnt == 1)
                        {
                            atai = a + b;
                        }
                        //引き算
                        if (cnt == 2)
                        {
                            atai = a - b;
                        }
                        //掛け算
                        if (cnt == 3)
                        {
                            atai = a * b;
                        }
                        //割り算
                        if (cnt == 4)
                        {
                            atai = a / b;
                        }
                    }
                    //計算結果が正しくない時
                    else
                    {
                        //timer1を無効化
                        timer1.Enabled = false;

                        //missのカウントを増やす
                        miss = miss + 1;

                        //答えを変数hozonに格納
                        hozon = atai;

                        //不解だということを知らせる
                        label5.Text = "不正解!!";

                        if (cnt == 1)
                        {
                            //敵をでかくする
                            //敵画像表示
                            pictureBox1.Image = Image.FromFile(@"mon1.png");
                        }
                        if (cnt == 2)
                        {
                            //敵をでかくする
                            //敵画像表示
                            pictureBox1.Image = Image.FromFile(@"mon2.png");
                        }
                        if (cnt == 3)
                        {
                            //敵をでかくする
                            //敵画像表示
                            pictureBox1.Image = Image.FromFile(@"mon3.png");
                        }
                        if (cnt == 4)
                        {
                            //敵をでかくする
                            //敵画像表示
                            pictureBox1.Image = Image.FromFile(@"mon4.png");
                        }

                        //敵を画面と同じ大きさに
                        pictureBox1.Width = w;
                        pictureBox1.Height = h;

                        //敵を左上からの配置に
                        pictureBox1.Location = new Point((w - pictureBox1.Width)/2, 0);

                        //再生
                        player3.controls.play();
                        
                        //HPを減らす
                        //missのカウントが1回の時
                        if (miss==1)
                        {
                            //HPを減らす マックスから3分の2に
                            pictureBox3.Image = Image.FromFile(@"hp_3_2.png");
                        }
                        //missのカウントが2回の時
                        if (miss==2)
                        {
                            //HPを減らす 3分の2から3分の1に
                            pictureBox3.Image = Image.FromFile(@"hp_3_1.png");
                        }
                        //正しい答えを表示させる
                        label6.Text = hozon.ToString();

                        //変数time2に2を格納
                        time2 = 2;

                        //timer2の有効化
                        timer2.Enabled = true;

                        //テキストクリア
                        textBox1.ResetText();

                        //文字数制限
                        textBox1.MaxLength = 9;
                        //missのカウントが3回の時
                        if (miss==3)
                        {
                            //サウンド停止
                            player1.controls.stop();
                            player2.controls.stop();
                            player3.controls.stop();

                            //timerをすべて無効
                            timer1.Enabled = false;
                            timer2.Enabled = false;
                            timer3.Enabled = false;

                            //f6を表示させる
                            Gameover f6 = new Gameover();
                            f6.score = score;
                            Program.app.MainForm = f6;
                            f6.Show();

                            //リソースの解放
                            this.Dispose();
                            //このフォームを閉じる
                            this.Close();
                        }
                        //難易度調整
                        //最初の桁 1桁
                        if ((cnt2 <= 1) || (cnt2 < kazu/3))
                        {
                            //乱数格納
                            a = rnd.Next(1, 10);
                            b = rnd.Next(1, 10);

                            //cntが2のとき
                            if (cnt == 2)
                            {
                                //変数bが変数aより大きい時はループさせる
                                while (b > a)
                                {
                                    //乱数格納
                                    a = rnd.Next(1, 10);
                                    b = rnd.Next(1, 10);
                                }
                            }
                            //cntが4のとき
                            if (cnt == 4)
                            {
                                //割ってあまりが出た時、変数a,bが同じの時はループさせる
                                //変数a,bが同じだと簡単すぎるのでループさせている
                                while (a % b != 0 || a == b)
                                {
                                    //乱数格納
                                    a = rnd.Next(1, 10);
                                    b = rnd.Next(1, 10);
                                }
                            }
                            //問題の値を表示
                            label1.Text = a.ToString();
                            label3.Text = b.ToString();
                            label1.Left = label2.Left - label1.Width;
                            label4.Left = label3.Right;
                            textBox1.Left = label4.Right;
                            label9.Left = textBox1.Left;
                            label9.Top = textBox1.Top;
                        }
                        //2桁
                        else if ((cnt2 < kazu/3) || (cnt2 < (kazu/3)*2))
                        {
                            //乱数格納
                            a = rnd.Next(10, 100);
                            b = rnd.Next(10, 100);

                            //cntが2のとき
                            if (cnt == 2)
                            {
                                //変数bが変数aより大きい時はループさせる
                                while (b > a)
                                {
                                    //乱数格納
                                    a = rnd.Next(10, 100);
                                    b = rnd.Next(10, 100);
                                }
                            }
                            //cntが4のとき
                            if (cnt == 4)
                            {
                                //割ってあまりが出た時、変数a,bが同じの時はループさせる
                                //変数a,bが同じだと簡単すぎるのでループさせている
                                while (a % b != 0 || a == b)
                                {
                                    //乱数格納
                                    a = rnd.Next(10, 100);
                                    b = rnd.Next(10, 100);
                                }
                            }
                            //問題の値を表示
                            label1.Text = a.ToString();
                            label3.Text = b.ToString();
                            label1.Left = label2.Left - label1.Width;
                            label4.Left = label3.Right;
                            textBox1.Left = label4.Right;
                            label9.Left = textBox1.Left;
                            label9.Top = textBox1.Top;
                        }
                        //3桁
                        else if ((cnt2 <= (kazu/3)*2) || (cnt2 <= kazu))
                        {
                            //乱数格納
                            a = rnd.Next(100, 1000);
                            b = rnd.Next(100, 1000);

                            //cntが2のとき
                            if (cnt == 2)
                            {
                                //変数bが変数aより大きい時はループさせる
                                while (b > a)
                                {
                                    //乱数格納
                                    a = rnd.Next(100, 1000);
                                    b = rnd.Next(100, 1000);
                                }
                            }
                            //cntが4のとき
                            if (cnt == 4)
                            {
                                //割ってあまりが出た時、変数a,bが同じの時はループさせる
                                //変数a,bが同じだと簡単すぎるのでループさせている
                                while (a % b != 0 || a == b)
                                {
                                    //乱数格納
                                    a = rnd.Next(100, 1000);
                                    b = rnd.Next(100, 1000);
                                }
                            }
                            //問題の値を表示
                            label1.Text = a.ToString();
                            label3.Text = b.ToString();
                            label1.Left = label2.Left - label1.Width;
                            label4.Left = label3.Right;
                            textBox1.Left = label4.Right;
                            label9.Left = textBox1.Left;
                            label9.Top = textBox1.Top;
                        }
                        //ここは計算 共通部分
                        //足し算
                        if (cnt == 1)
                        {
                            atai = a + b;
                        }
                        //引き算
                        if (cnt == 2)
                        {
                            atai = a - b;
                        }
                        //掛け算
                        if (cnt == 3)
                        {
                            atai = a * b;
                        }
                        //割り算
                        if (cnt == 4)
                        {
                            atai = a / b;
                        }
                    }
                } 
            }
            //Escapeキーが押されたとき
            if (e.KeyChar==(char)Keys.Escape)
            {
                //サウンド停止
                player1.controls.stop();
                player2.controls.stop();
                player3.controls.stop();
                Title f1 = new Title();
                Program.app.MainForm = f1;
                f1.Show();

                //リソースの解放
                this.Dispose();

                //このフォームを閉じる
                this.Close();
            }
            //0～9と、バックスペース以外の時は入力されないようにする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        //timer1が実行された時 制限時間
        private void timer1_Tick(object sender, EventArgs e)
        {
            //変数timeを減らす
            time = time - 1;

            //時間表示
            label7.Text = "あと" + time + "秒";
            
            //timeが0になった時
            if (time == 0)
            {
                //連続させるために停止させる
                player3.controls.stop();

                //時間不可視化
                label7.ResetText();

                //敵をでかくする
                //敵を画面と同じ大きさに
                pictureBox1.Width = w;
                pictureBox1.Height = h;

                //敵を左上からの配置に
                pictureBox1.Location = new Point(0, 0);

                //再生
                player3.controls.play();

                //missのカウントを増やす
                miss = miss + 1;

                //HPを減らす
                //missのカウントが1回の時
                if (miss == 1)
                {
                    //HPを減らす マックスから3分の2に
                    pictureBox3.Image = Image.FromFile(@"hp_3_2.png");
                }
                //missのカウントが2回の時
                if (miss == 2)
                {
                    //HPを減らす 3分の2から3分の1に
                    pictureBox3.Image = Image.FromFile(@"hp_3_1.png");
                }

                //変数time2に2を代入
                time2 = 2;

                //timer1を無効化
                timer1.Enabled = false;

                //timer2を有効化
                timer2.Enabled = true;
                //missのカウントが3回の時
                if (miss == 3)
                {
                    //サウンド停止
                    player1.controls.stop();
                    player2.controls.stop();
                    player3.controls.stop();

                    //timerをすべて無効
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;

                    //f6を表示させる
                    Gameover f6 = new Gameover();
                    f6.score = score;
                    Program.app.MainForm = f6;

                    //f6を表示
                    f6.Show();

                    //リソースの解放
                    this.Dispose();

                    //f6が閉じたときにこのフォームも閉じる
                    this.Close();
                }
            }
        }
        //timer2が実行された時 表示時間
        private void timer2_Tick(object sender, EventArgs e)
        {
            //変数time2が0でないとき
            if (time2!=0)
            {
                //変数time2を減らす
                time2 = time2 - 1;
            }
            //変数time2が0のとき
            if (time2==0)
            {
                //さらに、変数timeが0のとき
                if (time==0)
                {
                    //敵の大きさ、位置を元に戻す
                    pictureBox1.Height = h / 5;
                    pictureBox1.Width = w / 5;
                    pictureBox1.Location = new Point((w - pictureBox1.Width)/2, h / 2);
                }
                //さらに、変数cと変数hozonが同じ時
                if (c==hozon)
                {
                    //テキストクリア
                    label5.ResetText();

                }
                //また、変数cと変数hozonが同じでない時
                if (c!=hozon)
                {
                    //敵の大きさ、位置を元に戻す
                    pictureBox1.Height = h / 5;
                    pictureBox1.Width = w / 5;
                    pictureBox1.Location = new Point( (w - pictureBox1.Width) / 2, h / 2);

                    //テキストクリア
                    label5.ResetText();

                    //テキストクリア
                    label6.ResetText();
                }
                //変数timeに値を格納
                time = kioku;

                //時間表示
                label7.Text = "あと" + time + "秒";

                //timer1を有効化
                timer1.Enabled = true;

                //timer2を無効化
                timer2.Enabled = false;
            }
        }
        //timer3が実行された時 爆発のエフェクトを止める
        private void timer3_Tick(object sender, EventArgs e)
        {
            //変数iを増やす
            i = i + 1;

            //変数iが8ならば
            if (i==8)
            {
                if (cnt == 1)
                {
                    //敵画像表示
                    pictureBox1.Image = Image.FromFile(@"mon1.png");
                }
                if (cnt == 2)
                {
                    //敵画像表示
                    pictureBox1.Image = Image.FromFile(@"mon2.png");
                }
                if (cnt == 3)
                {
                    //敵画像表示
                    pictureBox1.Image = Image.FromFile(@"mon3.png");
                }
                if (cnt == 4)
                {
                    //敵画像表示
                    pictureBox1.Image = Image.FromFile(@"mon4.png");
                }
                //カウンタリセット
                i = 0;

                //timer3を無効化
                timer3.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label9.Text = textBox1.Text.ToString();
            string s = textBox1.Text;
            Size si = TextRenderer.MeasureText(s, textBox1.Font);
            textBox1.Width = si.Width;
            label9.Height = textBox1.Height;
            label9.Width = textBox1.Width;
        }
    }
}