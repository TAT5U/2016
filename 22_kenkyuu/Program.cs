using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//追加項目
using System.Runtime.InteropServices;
using System.Reflection;

namespace _22_kenkyuu
{
        static class Program
    {
        

        //キーフック
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        //dllをインポート windows管理関数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //dllをインポート windows管理関数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        //dllをインポート windows管理関数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        //キー取出し
        private const int WH_KEYBOARD_LL = 0x0D;

        private struct KeyBoardLLHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        private static int hHook = 0;
        public static Title f1;
        public static Selection f2;
        public static Question f3;
        public static Main f4;
        public static Gameclear f5;
        public static Gameover f6;
        public static Save_Data f7;
        public static Score f8;
        public static Load f9;
        public static ApplicationContext app;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            // キーフック開始
            IntPtr handle = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
            hHook = SetWindowsHookEx(WH_KEYBOARD_LL, new HookProc(Program.KeyHookProc), handle, 0);
            if (hHook == 0)
            {
                // キーフック失敗;
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //appの宣言
            app = new ApplicationContext();

            //タイトル画面を表示
            Title f1 = new Title();

            //メインフォームを変える
            app.MainForm = f1;

            //アプリケーションを走らせる(実行)
            Application.Run(app);
        }
        //KeyHookProcイベント
        private static int KeyHookProc(int nCode, IntPtr wParam, IntPtr lParam)
       {
            //フォームがアクティブor非アクティブだったら
            if (Title.ActiveForm != null||Title.ActiveForm==null)
            {
               KeyBoardLLHookStruct MyHookStruct = (KeyBoardLLHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardLLHookStruct));
               if (nCode == 0)
               {
                   // 91 : 左Windowsキー  92 : 右Windowsキー  16 : Shiftキー  17 : Ctrlキー  27 : ESCキー
                   if ((MyHookStruct.vkCode == 91) || (MyHookStruct.vkCode == 92))
                   {
                       // 0以外を返すと無効
                       return 1;
                   }
               }            
           }
           // 対象のキー以外
           return CallNextHookEx(hHook, nCode, wParam, lParam);
       }
    }
}