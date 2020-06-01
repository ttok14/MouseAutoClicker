﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using System.IO;

namespace MouseClicker
{
    public enum Mode
    {
        Idle,
        Recording,
        Pause,
        Activated,
    }

    public enum ActionType
    {
        MouseClick,
        Typing
    }

    public struct SingleAction
    {
        public ActionType type;

        // click
        public Point pos;
        // typing
        public string str;

        public double waitTime;
    }

    public partial class Form1 : Form
    {
        private const int KEY_PRESSED = 0x80;

        private readonly string[] serials =
        {
            // Version 01 시리얼키 200 개 
            "RKWF-OJXT-HKCE-TBRH","AFRB-RZAA-AEGI-XTOA","YDKA-ILIV-NWKU-DMKX","VFGA-RBWS-JVEK-DPVO","VCGQ-RQYO-XWOV-OGWO","UIMS-MOJX-GRRN-GYRX","AWYB-FUGE-GSCU-MADC","YQQU-CDBG-TJJZ-ZLIY","ERVR-HVIZ-CILU-LOKG","NPOQ-IXUX-VRHW-KGFV","JEQV-FLUD-HQSU-RGUF","YCLK-XSQH-WYWP-NMOV","DQKH-XPAB-UKIS-EAFO","XCYH-UVYR-NIYH-PEQV","BWRA-VMHI-CJPM-JYDW","SHSK-NGBI-RTUO-RTMQ","UNRH-JESK-VPFK-FLIP","FBOH-LFHU-VIIC-SSRI","XZRV-HVNN-PIPX-BQCG","KEJP-EFEP-FWMA-WQRC","XWNG-TMIK-OBSC-PJTE","GCRO-JCER-UCQK-JNRY","RMZE-DVMY-VYBC-NBZV","DHTT-YCSV-SVLR-WYBA","KTLC-JOBK-QTSK-ABET","DUGB-TYAO-TELH-KVCX","XAST-PWMO-FICF-KIVR","RSNC-RZGM-SWIF-CTAV","QUNA-IKDH-IRVL-VVEL","JUQS-HAFY-UGBT-NGLL","IHOP-UUIG-OGUZ-DVQX","SXWI-DINQ-OOGC-JKTB","FJCN-GORO-LJDB-GGUY","PDAQ-JDIA-TXAF-OGXE","MSUT-TDRE-GIWT-ELKI","UHNG-KDRC-BBTI-NLZF","MZPN-LBFM-MVKB-HOWI","NSLH-TQTJ-ARSR-JIRU","JQGE-WWWS-CATO-SQVM","FLVV-ZRMV-FFNU-IODD","EPRQ-IRLQ-VSFS-XFQJ","WFLX-NVVR-DKYQ-JCJN","XQJD-ZEEN-AEAG-MUYA","PDXD-CGPI-TAMX-SUHS","IRUG-VMKS-BXWJ-VPFJ","LYBF-FGKR-ABJY-SGUG","WHXU-ZRFC-TFBF-JGNE","UDMU-TCMC-GDGU-DLZV","CQNO-RKJT-TYLA-FFHT","NEEP-UANT-UVNV-LKZI","FGCT-TZNK-TSBU-RMWB","VMGY-HKAC-CUTW-WOII","YDUZ-COAO-RTWC-YSBH","YMZY-EAAU-FAQY-FQNF","JTVO-RXZH-LSHN-OYEK","SLXK-OJEX-CAUC-XBJA","FQSE-WNQB-MSMM-TMGG","WGGT-TDRZ-PYLR-DWKJ","IGIX-GZNE-VWXV-XRDP","TNFR-VPHB-ZSPY-BYYP","ICDN-EIAW-SBYX-GVCX","UWYP-RSOT-ZGXN-JPDW","XHNU-OQLK-NIZU-QJVE","PREF-AIYP-OJOY-LMND","YBZY-HIJD-LNCI-TUDP","KSYS-KXWO-IXFF-CMZB","VVVO-KXXH-IAUN-GQWU","GYNS-OUSB-FKQJ-CDBY","NBMX-YOFN-VRJK-CIIR","BLZD-ZHMA-DUIZ-HNEE","ZWZF-EYVR-TAWX-LIYW","CYHR-EXZG-OLUD-FFGH","MFKG-JCMC-PHKY-KPPU","VMXI-GNZC-XSRT-ESLO","UPKG-YSNZ-MEBW-NAWY","VAIT-IYBZ-FIIQ-LTYX","WWEV-FJWD-YYWB-LCPW","WSYE-KRFW-NLAP-KWNT","GEAR-VATL-DEUK-BANC","TLTT-UUNE-QIHU-IGTC","KDUH-CYAW-ZMAF-XVUN","XYWY-DUYL-RWAN-TZDX","LSZY-FGAV-KXUI-UHHU","OTXJ-JUYQ-EJPF-XNCZ","IDTE-VVIQ-YBNF-APRJ","OGZZ-CTNR-TJTW-QUXX","UUZQ-ODYS-LGLH-HTQP","RGQQ-OCXP-PCKM-BMZE","DPKF-PAUL-HGOV-HFJA","TEEK-DGJR-WKBM-SMRZ","HHES-IKZQ-LFJH-OCHJ","TJSW-HPAX-GTIE-ZISV","PPNA-BRSJ-ENYY-XCDU","DRTJ-TURS-GHLP-BURD","MNRY-OHIB-QJRT-QCZD","POBH-PJCU-XVTU-FDHK","WULJ-KEFV-JRSJ-CYBE","HIZN-SJOC-LWBT-NNWN","BHXV-QPTK-IGYX-RSSZ","TPMX-DURM-GJYN-DMHV","VFHU-AGNS-OPEM-LQLS","EBAY-AZJH-QLPH-QGGW","YCCM-KXYN-BUJO-QEAQ","XFIB-LIUV-VAEP-QGBH","IHNI-NZHH-DNXF-QVQL","KYJK-XFKP-HGQJ-SJWU","TBFI-QSCY-YBYY-LOFZ","KTFR-WQKD-XYAG-IYOT","RCMO-QIUS-WLMW-GMES","BRZZ-EEYC-RBLS-RVPZ","NEHI-CQJC-YMVK-EOWK","THFR-YOPN-EKXO-WBAA","WMIC-FWQK-HXBR-INYD","EAZJ-PXBZ-OUDS-TUFX","MUNR-FUFW-RVKA-NYEQ","LUJW-BQKZ-LINL-SYRM","SEFO-ZHXK-UCSU-NAMQ","PNGY-LIVV-JOFW-HUES","EXII-SQQE-XZCY-XQLK","WWVF-STBK-IKEL-BACZ","YAQP-SDYZ-WCAL-GWXT","CUAK-ZZAL-WYAI-LFCX","WCAX-AVSS-YVIP-SPDM","MLIG-ARAZ-ZFTT-DPNR","ZDPE-WZTH-BHMD-RKSG","UNVA-XVXE-BAXU-CZPJ","IQQP-ZZQM-RBFS-FXIP","MMYP-TNTD-GKCV-CYEC","RDVA-TDGV-XIIW-QEZE","SIHP-AZPU-WNIP-WVKT","WCAC-BHVJ-GDSK-EXMB","LXCT-QPCS-NADG-URYB","XPAO-DWDK-MYJW-HEQZ","BGDY-SRCG-ZIOB-EPOO","EQMP-XXYO-URGR-GGLJ","KEFO-NZJG-MTPV-IBGX","KURQ-RABD-IODA-KLZT","XFQZ-JAAE-HGDD-IDGT","LIHM-OURJ-CBFZ-VIWA","TVXC-LGNK-TMIL-XYUF","HKPB-ENFC-OGXI-UBJZ","KCJN-FEHE-UWSB-MFME","GARK-TUWG-QUOE-JFQS","DJBU-OHZD-DKGH-UEQI","USBT-KYFP-FDXK-PDVP","GAXC-ESPZ-ANHJ-NPLL","EFJQ-EWIF-DLPL-KONZ","ORBU-GNEC-DBTW-QWCP","RLGK-TFKJ-SRYT-CEOM","AIUW-ORFQ-BHNC-DMPH","JZTZ-IDFJ-HRCO-PLZY","NGWH-CFBA-FPIM-RHGG","CRJD-KPDW-DKOX-OQBQ","IOPW-PIFD-XSTS-VTRZ","KWMX-BVOX-DZER-RELP","ORDD-RKQT-LGGR-WLAJ","SOMS-DDPM-ASTP-DOMT","GEEE-POIA-FSLV-PWAS","ZUYC-STLK-CQDZ-QAPX","TNKS-GWUE-GLML-SUXD","RBQJ-QKBN-SUCZ-KIJF","COBC-LILC-ATVG-GASH","SZHP-JGHJ-LXZM-UVTX","BHIE-SVSJ-POJW-OUHS","CUGL-BUVW-GRQO-JZHF","ZXEY-RNPX-HXAV-WLVR","PGJA-OIWH-LLXB-EDAP","GEWR-QIBO-EIDD-UAAV","WZYC-PHQR-BXNG-QOSE","XKOS-ODBG-FVVG-FSNK","LCEF-EXAY-OFQS-VUXQ","PYGJ-LHGS-YRXT-LJLI","KCUN-JNZA-KPDI-NILK","XFQG-MDYD-VLHM-AGNE","UHIT-AKHC-ZGZW-EYFP","GNWG-TFWG-DRSX-FNZD","CYOF-ZSJN-XNHG-DCZX","GRGM-JGLO-LBPJ-RJWL","GVTF-JZQO-DIIF-XQCA","RUQO-HNTW-NZUX-CAVO","QVZH-JUNH-BRJB-XGRU","ZPRX-SIES-CXRK-ESLC","NUOB-QVQX-HJNP-ESYH","IAYN-IYVI-RHFM-CDDI","GGND-RPEE-YUPJ-VOOJ","YKBE-TYUP-YGKJ-PEVD","GEIX-FVPT-VUOO-IMMC","SWNR-BYOI-MYEL-FVOT","ZLCR-FRED-UIIZ-JFGL","THRS-QDCH-PALG-QENA","FUPW-KVWB-SKWT-PPYG","SSRX-EWCW-JUBF-FXMQ","UITO-QJBY-KQAG-GJRZ","CEOY-MQWJ-STNP-TRVU","YGYH-WKQI-RSMO-VWPA","CCDB-JNEE-MJWX-VMFT","UFHA-KKDR-NFHU-DHNV","DNMQ-OTLK-CUUM-NTNF","MTTQ-OPPS-YLNE-GJAE","VAUI-ZOFA-UXYQ-PREU"
        };

        bool authenticated = false;
        bool isAuthFileExist = false;

        public Mode curMode = Mode.Idle;
        TimeSpan delay = TimeSpan.FromSeconds(0.1f);

        List<SingleAction> keys = new List<SingleAction>();
        int curIndex;
        double remainedTimeForNextClick;

        double recordIntervalTime;

        bool useAutoDisableTimer;
        double remainedTimerSeconds;

        bool useAutoDisableRemainedCnt;
        int remainedCnt;

        bool isInsertTextInputBoxOpen;

        public Form1()
        {
            MouseCallBack.onLeftMouseDown = OnLeftMouseClicked;
            MouseCallBack.onRightMouseDown = OnRightMouseClicked;
            MouseCallBack.onWheelDown = OnWheelDown;

            InitializeComponent();
            SetMode(Mode.Idle);
            Initialize_HandleOtherWindow();
            Loop();
        }

        private void OnLeftMouseClicked(int x, int y)
        {
            if (isInsertTextInputBoxOpen)
                return;

            if (curMode != Mode.Recording)
                return;

            keys.Add(new SingleAction() { type = ActionType.MouseClick, pos = new Point(x, y), waitTime = recordIntervalTime });
            recordIntervalTime = 0;
        }

        void TryActivate()
        {
            if (keys != null && keys.Count > 0)
            {
                SetMode(Mode.Activated);
            }
            else
            {
                MessageBox.Show("Nothing Recorded");
                SetMode(Mode.Idle);
            }
        }

        private void OnRightMouseClicked(int x, int y)
        {
            if (isInsertTextInputBoxOpen)
                return;

            if (curMode == Mode.Recording)
            {
                TryActivate();
            }
            else if (curMode == Mode.Activated || curMode == Mode.Pause)
            {
                SetMode(Mode.Idle);
            }
        }

        private void OnWheelDown(int x, int y)
        {
            if (isInsertTextInputBoxOpen)
                return;

            if (curMode != Mode.Recording)
                return;

            isInsertTextInputBoxOpen = true;

            using (var form = new Form_InputBox())
            {
                // form.WindowState = FormWindowState.Maximized;
                ///   form.BringToFront();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    keys.Add(new SingleAction() { type = ActionType.MouseClick, pos = new Point(x, y), waitTime = recordIntervalTime });
                    recordIntervalTime = 0;
                    keys.Add(new SingleAction() { type = ActionType.Typing, str = form.typedTxt, waitTime = 0.05f });
                }

                isInsertTextInputBoxOpen = false;
            }
        }

        void SetMode(Mode mode, string subInfo = "")
        {
            var prevMode = curMode;
            curMode = mode;

            label4.Text = "현재 모드 : " + mode.ToString();
            remainedTimeInfoTxt.Text = "남은 시간";

            btnPause.Visible = false;

            switch (mode)
            {
                case Mode.Idle:
                    btnFunction.Text = "녹화시작";

                    if (prevMode == Mode.Activated)
                    {
                        SystemSounds.Hand.Play();

                        string txtStop = "Stop";

                        if (string.IsNullOrEmpty(subInfo) == false)
                        {
                            txtStop += " : " + subInfo;
                        }

                        MessageBox.Show(txtStop);
                    }
                    break;
                case Mode.Recording:
                    btnFunction.Text = "매크로 시작";
                    keys.Clear();
                    SystemSounds.Hand.Play();
                    WindowState = FormWindowState.Minimized;
                    break;
                case Mode.Activated:
                    btnPause.Visible = true;
                    btnFunction.Text = "중지";
                    //  string str = "";

                    //     for (int i = 0; i < keys.Count; i++)
                    //    {
                    //        str += keys[i].waitTime + " ";
                    //     }

                    curIndex = 0;
                    remainedTimeForNextClick = keys[0].waitTime;
                    useAutoDisableTimer = false;
                    useAutoDisableRemainedCnt = false;

                    if (autoDisableTimerCheckBox.Checked)
                    {
                        if (double.TryParse(remainedTimeTextBox.Text, out remainedTimerSeconds))
                        {
                            useAutoDisableTimer = remainedTimerSeconds > 0;
                        }
                    }

                    if (autoDisableRemainedCntCheckBox.Checked)
                    {
                        if (int.TryParse(remainedCntTextBox.Text, out remainedCnt))
                        {
                            useAutoDisableRemainedCnt = remainedCnt > 0;
                        }
                    }

                    //                 MessageBox.Show("Start Play : " + keys.Count);
                    break;
                case Mode.Pause:
                    {
                        btnFunction.Text = "다시 시작";
                    }
                    break;
                default:
                    break;
            }
        }

        async void Loop()
        {
            while (true)
            {
                if (authenticated == false)
                {
                    string fileName = "JMouseAutoClickerAuthInfo";
                    string fullPath = Path.GetTempPath() + fileName;

                    if (isAuthFileExist == false && File.Exists(fullPath) == false)
                    {
                        isAuthFileExist = true;
                        File.Create(fullPath);

                        //using (var writer = new StreamWriter(fullPath))
                        //{
                        //    // writer.Write()
                        //}

                        // MessageBox.Show(Path.GetTempPath() + fileName + " 에 인증 파일을 생성하였습니다.");
                    }

                    using (var reader = new StreamReader(fullPath))
                    {
                        if (serials.Contains(reader.ReadLine()))
                        {
                            authenticated = true;
                        }
                    }

                    if (authenticated == false)
                    {
                        using (var form = new AuthForm())
                        {
                            var result = form.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                if (serials.Contains(form.typedSerial))
                                {
                                    using (var writer = new StreamWriter(fullPath))
                                    {
                                        writer.Write(form.typedSerial);
                                    }

                                    MessageBox.Show("인증에 성공하였습니다. 감사합니다.");

                                    authenticated = true;
                                }
                                else
                                {
                                    MessageBox.Show("존재하지 않는 시리얼 키입니다");
                                }
                            }
                        }
                    }

                    await Task.Delay(delay);
                    continue;
                }

                if (isInsertTextInputBoxOpen)
                {
                    await Task.Delay(delay);
                    continue;
                }

                ProcessKeyDown();
                Update_HandleOtherWindow(delay);

                switch (curMode)
                {
                    case Mode.Idle:
                        break;
                    case Mode.Recording:
                        recordIntervalTime += delay.TotalSeconds;
                        break;
                    case Mode.Activated:
                        {
                            bool cycleDone = false;

                            remainedTimeForNextClick -= delay.TotalSeconds;
                            remainedTimerSeconds -= delay.TotalSeconds;

                            if (remainedTimeForNextClick <= 0)
                            {
                                DoAction(keys[curIndex]);
                                curIndex++;

                                if (curIndex >= keys.Count)
                                {
                                    curIndex = 0;
                                    cycleDone = true;
                                }

                                remainedTimeForNextClick = keys[curIndex].waitTime;
                            }

                            if (useAutoDisableTimer)
                            {
                                if (remainedTimerSeconds <= 0)
                                {
                                    SetMode(Mode.Idle, "타이머에 의한 종료");
                                    remainedTimerSeconds = 0;
                                }
                            }

                            if (useAutoDisableRemainedCnt)
                            {
                                if (cycleDone)
                                {
                                    remainedCnt--;

                                    if (remainedCnt <= 0)
                                    {
                                        SetMode(Mode.Idle, "횟수에 의한 종료");
                                        remainedCnt = 0;
                                    }
                                }
                            }

                            remainedTimeInfoTxt.Text = useAutoDisableTimer ? "남은 시간 : " + remainedTimerSeconds.ToString() : "기능 꺼짐";
                            remainedCntInfoText.Text = useAutoDisableRemainedCnt ? "남은 횟수 : " + remainedCnt.ToString() : "기능 꺼짐";
                        }
                        break;
                    default:
                        break;
                }

                //   label1.Text = "";// "CursorPos : " + Cursor.Position.ToString();

                await Task.Delay(delay);
                this.Text = DateTime.Now.ToString();
            }
        }

        private void ProcessKeyDown()
        {
            if (IsKeyDown(Keys.LShiftKey) && IsKeyDown(Keys.F9))
            {
                if (curMode == Mode.Activated)
                {
                    SetMode(Mode.Pause);
                }
                else if (curMode == Mode.Pause)
                {
                    SetMode(Mode.Activated);
                }
            }
        }

        bool IsKeyDown(Keys key)
        {
            return (GetKeyState(key) & KEY_PRESSED) == KEY_PRESSED;
        }

        private void DoAction(SingleAction singleAction)
        {
            if (singleAction.type == ActionType.MouseClick)
            {
                var oriPos = Cursor.Position;
                DoMouseClick(singleAction.pos.X, singleAction.pos.Y);

                if(resetCursorPosCheckBox.Checked)
                    Cursor.Position = oriPos;
            }
            else if (singleAction.type == ActionType.Typing)
            {
                SendKeys.SendWait(singleAction.str);
                SendKeys.Send("{ENTER}");
            }
        }

        [DllImport("USER32.dll")]
        public static extern short GetKeyState(Keys nVirtKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnClickFunctionButton(object sender, EventArgs e)
        {
            if (authenticated == false)
            {
                MessageBox.Show("인증 안됨");
                return;
            }

            if (curMode == Mode.Idle)
                SetMode(Mode.Recording);
            else if (curMode == Mode.Recording)
                TryActivate();
            else if (curMode == Mode.Activated)
                SetMode(Mode.Idle);
            else if (curMode == Mode.Pause)
                SetMode(Mode.Activated);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick(int x, int y)
        {
            Cursor.Position = new Point() { X = x, Y = y };
            //Call the imported function with the cursor's current position
            uint X = (uint)x;
            uint Y = (uint)y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.Shift && e.KeyCode == Keys.F12)
                MessageBox.Show("My message");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (curMode == Mode.Activated)
            {
                SetMode(Mode.Pause);
            }
            else if (curMode == Mode.Pause)
            {
                SetMode(Mode.Activated);
            }
        }
    }
}
