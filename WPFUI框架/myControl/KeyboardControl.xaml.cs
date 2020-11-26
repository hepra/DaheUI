using Microsoft.Ink;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI框架
{
    /// <summary>
    /// KeyboardControl.xaml 的交互逻辑
    /// </summary>
    public partial class KeyboardControl : UserControl
    {
        public string ReturnValue = "";//返回的值
        KeyBoardViewModel _viewModel = new KeyBoardViewModel();
        public KeyboardControl()
        {
            InitializeComponent();
            _viewModel.CurrentInput = InputHelper.设置输入法(); 
            _viewModel.OtherInput = "英文";
            this.DataContext = _viewModel;
           
            CurrentLanguage = GetCultureType();
            _viewModel.Is大写 = InputHelper.Is大写();
            //new Thread(() => { 
            //while(true)
            //    {
            //        _viewModel.Is大写 = InputHelper.Is大写();
            //        Thread.Sleep(200);
            //    }
            //}).Start();
        }

        #region 注册自定义事件和参数
        public delegate void KeyboardValueChangeEventHandler(string value);
        public event KeyboardValueChangeEventHandler KeyboardValueChangeEvent ;
        public event KeyboardValueChangeEventHandler HandWriteValueChangeEvent;
        #endregion

        public void KeyboardValueChange(string value)
        {
            KeyboardValueChangeEvent(value);
        }

        #region 点击事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button keybtn = sender as Button;
            #region//First Row
            if (keybtn.Name == "cmd1")
            {
                #region cmd1
                ReturnValue = "1";
                #endregion
            }
            if (keybtn.Name == "InputSwitch")
            {
                #region InputSwitch
                if(_viewModel.CurrentInput=="中文")
                {
                    _viewModel.OtherInput = "中文";
                    _viewModel.CurrentInput = "英文";
                    切换();
                }
                else
                {
                    _viewModel.OtherInput = "英文";
                    _viewModel.CurrentInput = "中文";
                    切换();
                }
                ReturnValue = "Shift";
                #endregion
            }
            


             if (keybtn.Name == "cmdEnter")
            {
                #region cmd1
                ReturnValue = "ENTER";
                #endregion
            }
            if (keybtn.Name == "CmdBack")
            {
                #region cmd1
                ReturnValue = "BACKSPACE";
                #endregion
            }
            if (keybtn.Name == "cmdDemical")
            {
                #region cmd1
                ReturnValue = ".";
                #endregion
            }
            if (keybtn.Name == "cmdSpace")
            {
                #region cmd1
                ReturnValue = "space";
                #endregion
            }
            if (keybtn.Name == "cmdup")
            {
                #region cmd1
                ReturnValue = "上";
                #endregion
            }
            if (keybtn.Name == "cmdleft")
            {
                #region cmd1
                ReturnValue = "左";
                #endregion
            }
            if (keybtn.Name == "cmdright")
            {
                #region cmd1
                ReturnValue = "右";
                #endregion
            }
            if (keybtn.Name == "cmddown")
            {
                #region cmd1
                ReturnValue = "下";
                #endregion
            }
            else if (keybtn.Name == "cmd2")
            {
                #region cmd2
                ReturnValue = "2";
                #endregion
            }
            else if (keybtn.Name == "cmd3")
            {
                #region cmd3
                ReturnValue = "3";
                #endregion
            }
            else if (keybtn.Name == "cmd4")
            {
                #region cmd4
                ReturnValue = "4";
                #endregion
            }
            else if (keybtn.Name == "cmd5")
            {
                #region cmd5
                ReturnValue = "5";
                #endregion
            }
            else if (keybtn.Name == "cmd6")
            {
                #region cmd6
                ReturnValue = "6";
                #endregion
            }
            else if (keybtn.Name == "cmd7")
            {
                #region cmd7
                ReturnValue = "7";
                #endregion
            }
            else if (keybtn.Name == "cmd8")
            {
                #region cmd8
                ReturnValue = "8";
                #endregion
            }
            else if (keybtn.Name == "cmd9")
            {
                #region cmd9
                ReturnValue = "9";
                #endregion
            }
            else if (keybtn.Name == "cmd0")
            {
                #region cmd0
                ReturnValue = "0";
                #endregion
            }
            else if (keybtn.Name == "cmdBackspace")//backspace
            {
                ReturnValue = "backspace";
            }
            #endregion
            #region//Second Row
            else if (keybtn.Name == "CmdQ")
            {
                #region CmdQ
                ReturnValue = "Q";
                #endregion
            }
            else if (keybtn.Name == "CmdW")
            {
                #region CmdW
                ReturnValue = "W";
                #endregion
            }
            else if (keybtn.Name == "CmdE")
            {
                #region CmdE
                ReturnValue = "E";
                #endregion
            }
            else if (keybtn.Name == "CmdR")
            {
                #region CmdR
                ReturnValue = "R";
                #endregion
            }
            else if (keybtn.Name == "CmdT")
            {
                #region CmdT
                ReturnValue = "T";
                #endregion
            }
            else if (keybtn.Name == "CmdY")
            {
                #region CmdY
                ReturnValue = "Y";
                #endregion
            }
            else if (keybtn.Name == "CmdU")
            {
                #region CmdU
                ReturnValue = "U";
                #endregion
            }
            else if (keybtn.Name == "CmdI")
            {
                #region CmdI
                ReturnValue = "I";
                #endregion
            }
            else if (keybtn.Name == "CmdO")
            {
                #region CmdO
                ReturnValue = "O";
                #endregion
            }
            else if (keybtn.Name == "CmdP")
            {
                #region CmdP
                ReturnValue = "P";
                #endregion
            }
            #endregion
            #region///Third ROw
            else if (keybtn.Name == "CmdA")
            {
                #region CmdA
                ReturnValue = "A";
                #endregion
            }
            else if (keybtn.Name == "CmdS")
            {
                #region CmdS
                ReturnValue = "S";
                #endregion
            }
            else if (keybtn.Name == "CmdD")
            {
                #region CmdD
                ReturnValue = "D";
                #endregion
            }
            else if (keybtn.Name == "CmdF")
            {
                #region CmdF
                ReturnValue = "F";
                #endregion
            }
            else if (keybtn.Name == "CmdG")
            {
                #region CmdG
                ReturnValue = "G";
                #endregion
            }
            else if (keybtn.Name == "CmdH")
            {
                #region CmdH
                ReturnValue = "H";
                #endregion
            }
            else if (keybtn.Name == "CmdJ")
            {
                #region CmdJ
                ReturnValue = "J";
                #endregion
            }
            else if (keybtn.Name == "CmdK")
            {
                #region CmdK
                ReturnValue = "K";
                #endregion
            }
            else if (keybtn.Name == "CmdL")
            {
                #region CmdL
                ReturnValue = "L";
                #endregion
            }
            #endregion
            #region//Fourth Row
            else if (keybtn.Name == "CmdZ")
            {
                #region CmdZ
                ReturnValue = "Z";
                #endregion
            }
            else if (keybtn.Name == "CmdX")
            {
                #region CmdX
                ReturnValue = "X";
                #endregion
            }
            else if (keybtn.Name == "CmdC")
            {
                #region CmdC
                ReturnValue = "C";
                #endregion
            }
            else if (keybtn.Name == "CmdV")
            {
                #region CmdV
                ReturnValue = "V";
                #endregion
            }
            else if (keybtn.Name == "CmdB")
            {
                #region CmdB
                ReturnValue = "B";
                #endregion
            }
            else if (keybtn.Name == "CmdN")
            {
                #region CmdN
                ReturnValue = "N";
                #endregion
            }
            else if (keybtn.Name == "CmdM")
            {
                #region CmdM
                ReturnValue = "M";
                #endregion
            }
            #endregion
            #region//Last row
            else if (keybtn.Name == "CmdClose")//关闭键盘
            {
                ReturnValue = "close";
            }
            else if (keybtn.Name == "cmdClear")//清空
            {
                ReturnValue = "clear";
            }
          KeyboardValueChange(ReturnValue);
            #endregion
        }

        #endregion


        private void 切换()
        {
            _viewModel.CurrentInput = InputHelper.设置输入法();
        }

        /// <summary>
        /// 获取当前输入法
        /// </summary>
        /// <returns></returns>
        private string GetCultureType()
        {
            var currentInputLanguage = System.Windows.Forms.InputLanguage.CurrentInputLanguage;
            var cultureInfo = currentInputLanguage.Culture;
            //同 cultureInfo.IetfLanguageTag;
            return cultureInfo.Name;
        }

        public static readonly DependencyProperty CurrentLanguageProperty = DependencyProperty.Register(
            "CurrentLanguage", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));

        public string CurrentLanguage
        {
            get { return (string)GetValue(CurrentLanguageProperty); }
            set { SetValue(CurrentLanguageProperty, value); }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
                 InputHelper.切换大小写();
        }
        private void myHandWrite_LostTouchCapture(object sender, TouchEventArgs e)
        {

        }

        bool GetInput = false;
        //2秒不输入 自动识别
        private void myHandWrite_LostMouseCapture(object sender, MouseEventArgs e)
        {
            GetInput = false;
            new Thread(() =>
            {
                int time = 0;
                while (time < 20)
                {
                    if (GetInput)
                    {
                        return;
                    }
                    Thread.Sleep(50);
                    time++;
                }
                this.Dispatcher.Invoke(() =>
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        myHandWrite.Strokes.Save(ms);
                        var myInkCollector = new InkCollector();
                        var ink = new Ink();
                        ink.Load(ms.ToArray());

                        using (RecognizerContext context = new RecognizerContext())
                        {
                            if (ink.Strokes.Count > 0)
                            {
                                context.Strokes = ink.Strokes;
                                RecognitionStatus status;

                                var result = context.Recognize(out status);

                                if (status == RecognitionStatus.NoError)
                                {
                                    HandWriteValueChangeEvent(result.TopString);
                                }
                                else
                                    MessageBox.Show("Recognition failed");
                            }
                            else
                            {
                                MessageBox.Show("No stroke detected");
                            }
                        }
                        myHandWrite.Strokes.Clear();
                    }
                });
            }).Start();
        }

        private void myHandWrite_GotMouseCapture(object sender, MouseEventArgs e)
        {
            GetInput = true;
        }
    }
    }

    public class InputHelper
    {
        #region bVk参数 常量定义

        public const byte vbKeyLButton = 0x1;    // 鼠标左键
        public const byte vbKeyRButton = 0x2;    // 鼠标右键
        public const byte vbKeyCancel = 0x3;     // CANCEL 键
        public const byte vbKeyMButton = 0x4;    // 鼠标中键
        public const byte vbKeyBack = 0x8;       // BACKSPACE 键
        public const byte vbKeyTab = 0x9;        // TAB 键
        public const byte vbKeyClear = 0xC;      // CLEAR 键
        public const byte vbKeyReturn = 0xD;     // ENTER 键
        public const byte vbKeyShift = 0x10;     // SHIFT 键
        public const byte vbKeyControl = 0x11;   // CTRL 键
        public const byte vbKeyAlt = 18;         // Alt 键  (键码18)
        public const byte vbKeyMenu = 0x12;      // MENU 键
        public const byte vbKeyPause = 0x13;     // PAUSE 键
        public const byte vbKeyCapital = 0x14;   // CAPS LOCK 键
        public const byte vbKeyEscape = 0x1B;    // ESC 键
        public const byte vbKeySpace = 0x20;     // SPACEBAR 键
        public const byte vbKeyPageUp = 0x21;    // PAGE UP 键
        public const byte vbKeyEnd = 0x23;       // End 键
        public const byte vbKeyHome = 0x24;      // HOME 键
        public const byte vbKeyLeft = 0x25;      // LEFT ARROW 键
        public const byte vbKeyUp = 0x26;        // UP ARROW 键
        public const byte vbKeyRight = 0x27;     // RIGHT ARROW 键
        public const byte vbKeyDown = 0x28;      // DOWN ARROW 键
        public const byte vbKeySelect = 0x29;    // Select 键
        public const byte vbKeyPrint = 0x2A;     // PRINT SCREEN 键
        public const byte vbKeyExecute = 0x2B;   // EXECUTE 键
        public const byte vbKeySnapshot = 0x2C;  // SNAPSHOT 键
        public const byte vbKeyDelete = 0x2E;    // Delete 键
        public const byte vbKeyHelp = 0x2F;      // HELP 键
        public const byte vbKeyNumlock = 0x90;   // NUM LOCK 键

        //常用键 字母键A到Z
        public const byte vbKeyA = 65;
        public const byte vbKeyB = 66;
        public const byte vbKeyC = 67;
        public const byte vbKeyD = 68;
        public const byte vbKeyE = 69;
        public const byte vbKeyF = 70;
        public const byte vbKeyG = 71;
        public const byte vbKeyH = 72;
        public const byte vbKeyI = 73;
        public const byte vbKeyJ = 74;
        public const byte vbKeyK = 75;
        public const byte vbKeyL = 76;
        public const byte vbKeyM = 77;
        public const byte vbKeyN = 78;
        public const byte vbKeyO = 79;
        public const byte vbKeyP = 80;
        public const byte vbKeyQ = 81;
        public const byte vbKeyR = 82;
        public const byte vbKeyS = 83;
        public const byte vbKeyT = 84;
        public const byte vbKeyU = 85;
        public const byte vbKeyV = 86;
        public const byte vbKeyW = 87;
        public const byte vbKeyX = 88;
        public const byte vbKeyY = 89;
        public const byte vbKeyZ = 90;

        //数字键盘0到9
        public const byte vbKey0 = 48;    // 0 键
        public const byte vbKey1 = 49;    // 1 键
        public const byte vbKey2 = 50;    // 2 键
        public const byte vbKey3 = 51;    // 3 键
        public const byte vbKey4 = 52;    // 4 键
        public const byte vbKey5 = 53;    // 5 键
        public const byte vbKey6 = 54;    // 6 键
        public const byte vbKey7 = 55;    // 7 键
        public const byte vbKey8 = 56;    // 8 键
        public const byte vbKey9 = 57;    // 9 键


        public const byte vbKeyNumpad0 = 0x60;    //0 键
        public const byte vbKeyNumpad1 = 0x61;    //1 键
        public const byte vbKeyNumpad2 = 0x62;    //2 键
        public const byte vbKeyNumpad3 = 0x63;    //3 键
        public const byte vbKeyNumpad4 = 0x64;    //4 键
        public const byte vbKeyNumpad5 = 0x65;    //5 键
        public const byte vbKeyNumpad6 = 0x66;    //6 键
        public const byte vbKeyNumpad7 = 0x67;    //7 键
        public const byte vbKeyNumpad8 = 0x68;    //8 键
        public const byte vbKeyNumpad9 = 0x69;    //9 键
        public const byte vbKeyMultiply = 0x6A;   // MULTIPLICATIONSIGN(*)键
        public const byte vbKeyAdd = 0x6B;        // PLUS SIGN(+) 键
        public const byte vbKeySeparator = 0x6C;  // ENTER 键
        public const byte vbKeySubtract = 0x6D;   // MINUS SIGN(-) 键
        public const byte vbKeyDecimal = 0x6E;    // DECIMAL POINT(.) 键
        public const byte vbKeyDivide = 0x6F;     // DIVISION SIGN(/) 键


        //F1到F12按键
        public const byte vbKeyF1 = 0x70;   //F1 键
        public const byte vbKeyF2 = 0x71;   //F2 键
        public const byte vbKeyF3 = 0x72;   //F3 键
        public const byte vbKeyF4 = 0x73;   //F4 键
        public const byte vbKeyF5 = 0x74;   //F5 键
        public const byte vbKeyF6 = 0x75;   //F6 键
        public const byte vbKeyF7 = 0x76;   //F7 键
        public const byte vbKeyF8 = 0x77;   //F8 键
        public const byte vbKeyF9 = 0x78;   //F9 键
        public const byte vbKeyF10 = 0x79;  //F10 键
        public const byte vbKeyF11 = 0x7A;  //F11 键
        public const byte vbKeyF12 = 0x7B;  //F12 键

        #endregion

        /// <summary>
        /// 导入模拟键盘的方法
        /// </summary>
        /// <param name="bVk" >按键的虚拟键值</param>
        /// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
        /// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
        /// <param name= "dwExtraInfo">一般设置为0</param>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void KeyDown(string key)
        {
            key = key.ToUpper();
            switch (key)
            {
                case "A":
                    keybd_event(vbKeyA, 0, 0, 0);
                    keybd_event(vbKeyA, 0, 2, 0);
                    break;
                case "B":
                    keybd_event(vbKeyB, 0, 0, 0);
                    keybd_event(vbKeyB, 0, 2, 0);
                    break;
                case "C":
                    keybd_event(vbKeyC, 0, 0, 0);
                    keybd_event(vbKeyC, 0, 2, 0);
                    break;
                case "D":
                    keybd_event(vbKeyD, 0, 0, 0);
                    keybd_event(vbKeyD, 0, 2, 0);
                    break;
                case "E":
                    keybd_event(vbKeyE, 0, 0, 0);
                    keybd_event(vbKeyE, 0, 2, 0);
                    break;
                case "F":
                    keybd_event(vbKeyF, 0, 0, 0);
                    keybd_event(vbKeyF, 0, 2, 0);
                    break;
                case "G":
                    keybd_event(vbKeyG, 0, 0, 0);
                    keybd_event(vbKeyG, 0, 2, 0);
                    break;
                case "H":
                    keybd_event(vbKeyH, 0, 0, 0);
                    keybd_event(vbKeyH, 0, 2, 0);
                    break;
                case "I":
                    keybd_event(vbKeyI, 0, 0, 0);
                    keybd_event(vbKeyI, 0, 2, 0);
                    break;
                case "J":
                    keybd_event(vbKeyJ, 0, 0, 0);
                    keybd_event(vbKeyJ, 0, 2, 0);
                    break;
                case "K":
                    keybd_event(vbKeyK, 0, 0, 0);
                    keybd_event(vbKeyK, 0, 2, 0);
                    break;
                case "L":
                    keybd_event(vbKeyL, 0, 0, 0);
                    keybd_event(vbKeyL, 0, 2, 0);
                    break;
                case "M":
                    keybd_event(vbKeyM, 0, 0, 0);
                    keybd_event(vbKeyM, 0, 2, 0);
                    break;
                case "N":
                    keybd_event(vbKeyN, 0, 0, 0);
                    keybd_event(vbKeyN, 0, 2, 0);
                    break;
                case "O":
                    keybd_event(vbKeyO, 0, 0, 0);
                    keybd_event(vbKeyO, 0, 2, 0);
                    break;
                case "P":
                    keybd_event(vbKeyP, 0, 0, 0);
                    keybd_event(vbKeyP, 0, 2, 0);
                    break;
                case "Q":
                    keybd_event(vbKeyQ, 0, 0, 0);
                    keybd_event(vbKeyQ, 0, 2, 0);
                    break;
                case "R":
                    keybd_event(vbKeyR, 0, 0, 0);
                    keybd_event(vbKeyR, 0, 2, 0);
                    break;
                case "S":
                    keybd_event(vbKeyS, 0, 0, 0);
                    keybd_event(vbKeyS, 0, 2, 0);
                    break;
                case "T":
                    keybd_event(vbKeyT, 0, 0, 0);
                    keybd_event(vbKeyT, 0, 2, 0);
                    break;
                case "U":
                    keybd_event(vbKeyU, 0, 0, 0);
                    keybd_event(vbKeyU, 0, 2, 0);
                    break;
                case "V":
                    keybd_event(vbKeyV, 0, 0, 0);
                    keybd_event(vbKeyV, 0, 2, 0);
                    break;
                case "W":
                    keybd_event(vbKeyW, 0, 0, 0);
                    keybd_event(vbKeyW, 0, 2, 0);
                    break;
                case "X":
                    keybd_event(vbKeyX, 0, 0, 0);
                    keybd_event(vbKeyX, 0, 2, 0);
                    break;
                case "Y":
                    keybd_event(vbKeyY, 0, 0, 0);
                    keybd_event(vbKeyY, 0, 2, 0);
                    break;
                case "Z":
                    keybd_event(vbKeyZ, 0, 0, 0);
                    keybd_event(vbKeyZ, 0, 2, 0);
                    break;
                case "BACKSPACE":
                    keybd_event(vbKeyBack, 0, 0, 0);
                    keybd_event(vbKeyBack, 0, 2, 0);
                    break;
                case "ENTER":
                    keybd_event(vbKeyReturn, 0, 0, 0);
                    keybd_event(vbKeyReturn, 0, 2, 0);
                    break;
                case "SPACE":
                    keybd_event(vbKeySpace, 0, 0, 0);
                    keybd_event(vbKeySpace, 0, 2, 0);
                    break;
                case ".":
                    keybd_event(vbKeyDecimal, 0, 0, 0);
                    keybd_event(vbKeyDecimal, 0, 2, 0);
                    break;
                case "上":
                    keybd_event(vbKeyUp, 0, 0, 0);
                    keybd_event(vbKeyUp, 0, 2, 0);
                    break;
                case "下":
                    keybd_event(vbKeyDown, 0, 0, 0);
                    keybd_event(vbKeyDown, 0, 2, 0);
                    break;
                case "左":
                    keybd_event(vbKeyLeft, 0, 0, 0);
                    keybd_event(vbKeyLeft, 0, 2, 0);
                    break;
                case "右":
                    keybd_event(vbKeyRight, 0, 0, 0);
                    keybd_event(vbKeyRight, 0, 2, 0);
                    break;

                case "0":
                    keybd_event(vbKey0, 0, 0, 0);
                    keybd_event(vbKey0, 0, 2, 0);
                    break;
                case "1":
                    keybd_event(vbKey1, 0, 0, 0);
                    keybd_event(vbKey1, 0, 2, 0);
                    break;
                case "2":
                    keybd_event(vbKey2, 0, 0, 0);
                    keybd_event(vbKey2, 0, 2, 0);
                    break;
                case "3":
                    keybd_event(vbKey3, 0, 0, 0);
                    keybd_event(vbKey3, 0, 2, 0);
                    break;
                case "4":
                    keybd_event(vbKey4, 0, 0, 0);
                    keybd_event(vbKey4, 0, 2, 0);
                    break;
                case "5":
                    keybd_event(vbKey5, 0, 0, 0);
                    keybd_event(vbKey5, 0, 2, 0);
                    break;
                case "6":
                    keybd_event(vbKey6, 0, 0, 0);
                    keybd_event(vbKey6, 0, 2, 0);
                    break;
                case "7":
                    keybd_event(vbKey7, 0, 0, 0);
                    keybd_event(vbKey7, 0, 2, 0);
                    break;
                case "8":
                    keybd_event(vbKey8, 0, 0, 0);
                    keybd_event(vbKey8, 0, 2, 0);
                    break;
                case "9":
                    keybd_event(vbKey9, 0, 0, 0);
                    keybd_event(vbKey9, 0, 2, 0);
                    break;
                case "Shift":
                    keybd_event(vbKeyShift, 0, 0, 0);
                    keybd_event(vbKeyShift, 0, 2, 0);
                    break;
            }
        }

        [DllImport("USER32", SetLastError = true)]
        static extern short GetKeyState(int nVirtKey);

        static public bool Is大写()
        {
            //大小写状态
            if (GetKeyState(20) == 1)
            {
                return true;
            }
            return false;
        }
        static public void 切换大小写()
        {
            keybd_event(vbKeyCapital, 0, 0, 0);

            keybd_event(vbKeyCapital, 0, 2, 0);
        }

        [DllImport("user32.dll", EntryPoint = "GetKeyboardLayout")]
        public static extern ulong GetKeyboardLayout(ulong dwLayout);

        [DllImport("imm32.dll", EntryPoint = "ImmSimulateHotKey")]
        public static extern Boolean immsimulatehotkey(
          IntPtr hwnd,
          IntPtr dwhotkeyid
        );

        [DllImport("imm32.dll", EntryPoint = "ImmIsIME")]
        public static extern Boolean ImmIsIME(
          ulong hklKeyboardLayout
        );

        [DllImport("user32.dll")] static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);
        [DllImport("user32.dll")] static extern IntPtr GetKeyboardLayout(uint thread);

        public static CultureInfo GetCurrentKeyboardLayout()
        {
            try
            {
                IntPtr foregroundWindow = GetForegroundWindow();
                uint foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);
                int keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;
                return new CultureInfo(keyboardLayout);
            }
            catch (Exception)
            {
                return new CultureInfo(1033); // Assume English if something went wrong.
            }
        }

        public static string 设置输入法()
        {
            string input = GetCurrentKeyboardLayout().DisplayName;
            keybd_event(0xA2, 0, 0, 0);

            keybd_event(0xA0, 0, 0, 0);

            keybd_event(0xA0, 0, 2, 0);

            keybd_event(0xA2, 0, 2, 0);

            return input;
            // //获取输入法信息
            // //获取系统中已经安装的文字输入法
            // InputLanguageCollection MyInputs = InputLanguage.InstalledInputLanguages;
            // //将输入法的名称添加组合框中
            // foreach (InputLanguage MyInput in MyInputs)
            // {
            //     //FileHelper.AppandLog(MyInput.LayoutName, "Info");
            //     if(MyInput.LayoutName.Contains("中文"))
            //     {
            //         //设置当前输入法
            //         InputLanguage.CurrentInputLanguage = MyInput;
            //         //获取当前输入法信息
            //         //InputLanguage CurrentInput = InputLanguage.CurrentInputLanguage;
            //         //InputLanguage DefaultInput = InputLanguage.DefaultInputLanguage;
            //     }
            //     FileHelper.Appand系统日志Info("获取输入法:" + MyInput.LayoutName);
            // }
            ////     this.comboBox1.Items.Add(MyInput.LayoutName);
            // //获取当前输入法信息


            // ////获取输入法的语言区域
            // //this.textBox3.Text = CurrentInput.Culture.DisplayName;
            // ////获取默认的输入法信息
            // //InputLanguage DefaultInput = InputLanguage.DefaultInputLanguage;
            // //this.textBox2.Text = DefaultInput.LayoutName;
        }
    }


    public class KeyBoardViewModel :DMSkin.Core.ViewModelBase
    {
        public KeyBoardViewModel()
        {

        }
        private string _CurrentInput;
        public string CurrentInput
        {
            get { return _CurrentInput; }
            set
            {
                _CurrentInput = value;
            OnPropertyChanged(nameof(CurrentInput));
        }
        }
        private string _OtherInput;
        public string OtherInput
        {
            get { return _OtherInput; }
            set
            {
                _OtherInput = value;
            OnPropertyChanged(nameof(OtherInput));
        }
        }

        private bool _Is大写;
        public bool Is大写
        {
            get { return _Is大写; }
            set
            {
                _Is大写 = value;
            OnPropertyChanged(nameof(Is大写));
        }
        }

    
}
