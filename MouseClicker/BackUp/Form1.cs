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

    public enum RecordKeyType
    {
        MainKey,
        ShortCutKey
    }

    public class Randomize
    {
        static Random random = new Random();

        public static int GetRandomNum(int min, int max)
        {
            return random.Next(min, max);
        }
    }

    public struct SingleAction
    {
        public ActionType type;

        // click
        public Point pos;
        // typing
        public List<string> str;

        public double waitTime;

        public SingleAction(ActionType type, Point pos, List<string> str, double waitTime)
        {
            this.type = type;
            this.pos = pos;
            this.str = str;
            this.waitTime = waitTime;
        }

        internal string PickRandomString()
        {
            if (str.Count == 0)
                return "empty";
            return str[Randomize.GetRandomNum(0, str.Count)];
        }
    }

    public partial class Form1 : Form
    {
        private const int KEY_PRESSED = 0x80;

        private readonly string[] serials =
        {
            // Version 01 시리얼키 200 개 
            "920623","RKWF-OJXT-HKCE-TBRH","AFRB-RZAA-AEGI-XTOA","YDKA-ILIV-NWKU-DMKX","VFGA-RBWS-JVEK-DPVO","VCGQ-RQYO-XWOV-OGWO","UIMS-MOJX-GRRN-GYRX","AWYB-FUGE-GSCU-MADC","YQQU-CDBG-TJJZ-ZLIY","ERVR-HVIZ-CILU-LOKG","NPOQ-IXUX-VRHW-KGFV","JEQV-FLUD-HQSU-RGUF","YCLK-XSQH-WYWP-NMOV","DQKH-XPAB-UKIS-EAFO","XCYH-UVYR-NIYH-PEQV","BWRA-VMHI-CJPM-JYDW","SHSK-NGBI-RTUO-RTMQ","UNRH-JESK-VPFK-FLIP","FBOH-LFHU-VIIC-SSRI","XZRV-HVNN-PIPX-BQCG","KEJP-EFEP-FWMA-WQRC","XWNG-TMIK-OBSC-PJTE","GCRO-JCER-UCQK-JNRY","RMZE-DVMY-VYBC-NBZV","DHTT-YCSV-SVLR-WYBA","KTLC-JOBK-QTSK-ABET","DUGB-TYAO-TELH-KVCX","XAST-PWMO-FICF-KIVR","RSNC-RZGM-SWIF-CTAV","QUNA-IKDH-IRVL-VVEL","JUQS-HAFY-UGBT-NGLL","IHOP-UUIG-OGUZ-DVQX","SXWI-DINQ-OOGC-JKTB","FJCN-GORO-LJDB-GGUY","PDAQ-JDIA-TXAF-OGXE","MSUT-TDRE-GIWT-ELKI","UHNG-KDRC-BBTI-NLZF","MZPN-LBFM-MVKB-HOWI","NSLH-TQTJ-ARSR-JIRU","JQGE-WWWS-CATO-SQVM","FLVV-ZRMV-FFNU-IODD","EPRQ-IRLQ-VSFS-XFQJ","WFLX-NVVR-DKYQ-JCJN","XQJD-ZEEN-AEAG-MUYA","PDXD-CGPI-TAMX-SUHS","IRUG-VMKS-BXWJ-VPFJ","LYBF-FGKR-ABJY-SGUG","WHXU-ZRFC-TFBF-JGNE","UDMU-TCMC-GDGU-DLZV","CQNO-RKJT-TYLA-FFHT","NEEP-UANT-UVNV-LKZI","FGCT-TZNK-TSBU-RMWB","VMGY-HKAC-CUTW-WOII","YDUZ-COAO-RTWC-YSBH","YMZY-EAAU-FAQY-FQNF","JTVO-RXZH-LSHN-OYEK","SLXK-OJEX-CAUC-XBJA","FQSE-WNQB-MSMM-TMGG","WGGT-TDRZ-PYLR-DWKJ","IGIX-GZNE-VWXV-XRDP","TNFR-VPHB-ZSPY-BYYP","ICDN-EIAW-SBYX-GVCX","UWYP-RSOT-ZGXN-JPDW","XHNU-OQLK-NIZU-QJVE","PREF-AIYP-OJOY-LMND","YBZY-HIJD-LNCI-TUDP","KSYS-KXWO-IXFF-CMZB","VVVO-KXXH-IAUN-GQWU","GYNS-OUSB-FKQJ-CDBY","NBMX-YOFN-VRJK-CIIR","BLZD-ZHMA-DUIZ-HNEE","ZWZF-EYVR-TAWX-LIYW","CYHR-EXZG-OLUD-FFGH","MFKG-JCMC-PHKY-KPPU","VMXI-GNZC-XSRT-ESLO","UPKG-YSNZ-MEBW-NAWY","VAIT-IYBZ-FIIQ-LTYX","WWEV-FJWD-YYWB-LCPW","WSYE-KRFW-NLAP-KWNT","GEAR-VATL-DEUK-BANC","TLTT-UUNE-QIHU-IGTC","KDUH-CYAW-ZMAF-XVUN","XYWY-DUYL-RWAN-TZDX","LSZY-FGAV-KXUI-UHHU","OTXJ-JUYQ-EJPF-XNCZ","IDTE-VVIQ-YBNF-APRJ","OGZZ-CTNR-TJTW-QUXX","UUZQ-ODYS-LGLH-HTQP","RGQQ-OCXP-PCKM-BMZE","DPKF-PAUL-HGOV-HFJA","TEEK-DGJR-WKBM-SMRZ","HHES-IKZQ-LFJH-OCHJ","TJSW-HPAX-GTIE-ZISV","PPNA-BRSJ-ENYY-XCDU","DRTJ-TURS-GHLP-BURD","MNRY-OHIB-QJRT-QCZD","POBH-PJCU-XVTU-FDHK","WULJ-KEFV-JRSJ-CYBE","HIZN-SJOC-LWBT-NNWN","BHXV-QPTK-IGYX-RSSZ","TPMX-DURM-GJYN-DMHV","VFHU-AGNS-OPEM-LQLS","EBAY-AZJH-QLPH-QGGW","YCCM-KXYN-BUJO-QEAQ","XFIB-LIUV-VAEP-QGBH","IHNI-NZHH-DNXF-QVQL","KYJK-XFKP-HGQJ-SJWU","TBFI-QSCY-YBYY-LOFZ","KTFR-WQKD-XYAG-IYOT","RCMO-QIUS-WLMW-GMES","BRZZ-EEYC-RBLS-RVPZ","NEHI-CQJC-YMVK-EOWK","THFR-YOPN-EKXO-WBAA","WMIC-FWQK-HXBR-INYD","EAZJ-PXBZ-OUDS-TUFX","MUNR-FUFW-RVKA-NYEQ","LUJW-BQKZ-LINL-SYRM","SEFO-ZHXK-UCSU-NAMQ","PNGY-LIVV-JOFW-HUES","EXII-SQQE-XZCY-XQLK","WWVF-STBK-IKEL-BACZ","YAQP-SDYZ-WCAL-GWXT","CUAK-ZZAL-WYAI-LFCX","WCAX-AVSS-YVIP-SPDM","MLIG-ARAZ-ZFTT-DPNR","ZDPE-WZTH-BHMD-RKSG","UNVA-XVXE-BAXU-CZPJ","IQQP-ZZQM-RBFS-FXIP","MMYP-TNTD-GKCV-CYEC","RDVA-TDGV-XIIW-QEZE","SIHP-AZPU-WNIP-WVKT","WCAC-BHVJ-GDSK-EXMB","LXCT-QPCS-NADG-URYB","XPAO-DWDK-MYJW-HEQZ","BGDY-SRCG-ZIOB-EPOO","EQMP-XXYO-URGR-GGLJ","KEFO-NZJG-MTPV-IBGX","KURQ-RABD-IODA-KLZT","XFQZ-JAAE-HGDD-IDGT","LIHM-OURJ-CBFZ-VIWA","TVXC-LGNK-TMIL-XYUF","HKPB-ENFC-OGXI-UBJZ","KCJN-FEHE-UWSB-MFME","GARK-TUWG-QUOE-JFQS","DJBU-OHZD-DKGH-UEQI","USBT-KYFP-FDXK-PDVP","GAXC-ESPZ-ANHJ-NPLL","EFJQ-EWIF-DLPL-KONZ","ORBU-GNEC-DBTW-QWCP","RLGK-TFKJ-SRYT-CEOM","AIUW-ORFQ-BHNC-DMPH","JZTZ-IDFJ-HRCO-PLZY","NGWH-CFBA-FPIM-RHGG","CRJD-KPDW-DKOX-OQBQ","IOPW-PIFD-XSTS-VTRZ","KWMX-BVOX-DZER-RELP","ORDD-RKQT-LGGR-WLAJ","SOMS-DDPM-ASTP-DOMT","GEEE-POIA-FSLV-PWAS","ZUYC-STLK-CQDZ-QAPX","TNKS-GWUE-GLML-SUXD","RBQJ-QKBN-SUCZ-KIJF","COBC-LILC-ATVG-GASH","SZHP-JGHJ-LXZM-UVTX","BHIE-SVSJ-POJW-OUHS","CUGL-BUVW-GRQO-JZHF","ZXEY-RNPX-HXAV-WLVR","PGJA-OIWH-LLXB-EDAP","GEWR-QIBO-EIDD-UAAV","WZYC-PHQR-BXNG-QOSE","XKOS-ODBG-FVVG-FSNK","LCEF-EXAY-OFQS-VUXQ","PYGJ-LHGS-YRXT-LJLI","KCUN-JNZA-KPDI-NILK","XFQG-MDYD-VLHM-AGNE","UHIT-AKHC-ZGZW-EYFP","GNWG-TFWG-DRSX-FNZD","CYOF-ZSJN-XNHG-DCZX","GRGM-JGLO-LBPJ-RJWL","GVTF-JZQO-DIIF-XQCA","RUQO-HNTW-NZUX-CAVO","QVZH-JUNH-BRJB-XGRU","ZPRX-SIES-CXRK-ESLC","NUOB-QVQX-HJNP-ESYH","IAYN-IYVI-RHFM-CDDI","GGND-RPEE-YUPJ-VOOJ","YKBE-TYUP-YGKJ-PEVD","GEIX-FVPT-VUOO-IMMC","SWNR-BYOI-MYEL-FVOT","ZLCR-FRED-UIIZ-JFGL","THRS-QDCH-PALG-QENA","FUPW-KVWB-SKWT-PPYG","SSRX-EWCW-JUBF-FXMQ","UITO-QJBY-KQAG-GJRZ","CEOY-MQWJ-STNP-TRVU","YGYH-WKQI-RSMO-VWPA","CCDB-JNEE-MJWX-VMFT","UFHA-KKDR-NFHU-DHNV","DNMQ-OTLK-CUUM-NTNF","MTTQ-OPPS-YLNE-GJAE","VAUI-ZOFA-UXYQ-PREU"
        };

        bool authenticated = false;
        bool isAuthFileExist = false;

        public Mode curMode = Mode.Idle;
        TimeSpan delay = TimeSpan.FromSeconds(0.1f);

        RecordKeyType curRecordKeyType;
        RecordKeyType curActivatedKeyType;
        List<SingleAction> mainTrackKeys = new List<SingleAction>();
        Dictionary<string, List<SingleAction>> shortCutKeys = new Dictionary<string, List<SingleAction>>();
        List<SingleAction> curTrack;
        string desiredRecordShortCut;
        string desiredExeShortCut;
        int curIndex;
        double remainedTimeForNextClick;

        double recordIntervalTime;

        double curSpeedMutliplier;

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
            speedMultiplier.Value = 1;

            foreach (var item in shortCutKeySelections.Items)
            {
                shortCutKeys.Add(item.ToString(), new List<SingleAction>());
            }

            ApplySpeed();
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

            var intervalTime = recordIntervalTime;
            Point pos = new Point(x, y);

            /// 왼쪽 Shift 를 누른 상태서 왼쪽 클릭하면 더블 클릭으로 판정 
            if (IsKeyDown(Keys.LShiftKey))
            {
                AddMouseClickKey(pos, intervalTime);
            }

            AddMouseClickKey(pos, intervalTime);
        }

        void AddMouseClickKey(Point pos, double? desiredRecordIntervalTime = null)
        {
            List<SingleAction> targetTrack = null;

            if (curRecordKeyType == RecordKeyType.MainKey)
                targetTrack = mainTrackKeys;
            else if (curRecordKeyType == RecordKeyType.ShortCutKey)
                targetTrack = shortCutKeys[shortCutKeySelections.SelectedItem.ToString()];

            targetTrack.Add(new SingleAction()
            {
                type = ActionType.MouseClick,
                pos = new Point(pos.X, pos.Y),
                waitTime = desiredRecordIntervalTime != null && desiredRecordIntervalTime.HasValue ? desiredRecordIntervalTime.Value : recordIntervalTime
            });

            recordIntervalTime = 0;
        }

        void TryActivate(string shortCut = "")
        {
            if (curRecordKeyType == RecordKeyType.MainKey && mainTrackKeys != null && mainTrackKeys.Count > 0)
            {
                SetMode(Mode.Activated);
            }
            else if (curRecordKeyType == RecordKeyType.ShortCutKey && shortCutKeys[shortCut].Count > 0)
            {
                SetMode(Mode.Activated);
            }
            else
            {
                SetMode(Mode.Idle);
                MessageBox.Show("Nothing Recorded");
            }
        }

        private void OnRightMouseClicked(int x, int y)
        {
            if (isInsertTextInputBoxOpen)
                return;

            if (curMode == Mode.Recording)
            {
                if (curRecordKeyType == RecordKeyType.MainKey)
                {
                    TryActivate();
                }
                else if (curRecordKeyType == RecordKeyType.ShortCutKey)
                {
                    SetMode(Mode.Idle);
                }
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

            if (curMode == Mode.Recording)
            {
                isInsertTextInputBoxOpen = true;

                List<SingleAction> targetTrack = null;

                if (curRecordKeyType == RecordKeyType.MainKey)
                {
                    targetTrack = mainTrackKeys;
                }
                else if (curRecordKeyType == RecordKeyType.ShortCutKey)
                {
                    targetTrack = shortCutKeys[desiredRecordShortCut];
                }

                /// InputBox Form 할당 
                using (var form = new Form_InputBox())
                {
                    // form.WindowState = FormWindowState.Maximized;
                    ///   form.BringToFront();

                    /// Open 함과 동시에 블록
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        targetTrack.Add(new SingleAction() { type = ActionType.MouseClick, pos = new Point(x, y), waitTime = recordIntervalTime });
                        recordIntervalTime = 0;
                        targetTrack.Add(new SingleAction() { type = ActionType.Typing, str = form.Txts, waitTime = 0.05f });
                    }

                    isInsertTextInputBoxOpen = false;
                }
            }
            else if (curMode == Mode.Activated)
            {
                SetMode(Mode.Pause);
            }
            else if (curMode == Mode.Pause)
            {
                SetMode(Mode.Activated);
            }
        }

        void SetMode(Mode mode, string subInfo = "")
        {
            var prevMode = curMode;
            var prevActivateKeyMode = curActivatedKeyType;

            curMode = mode;

            label4.Text = "현재 모드 : " + mode.ToString();
            remainedTimeInfoTxt.Text = "남은 시간";

            btnPause.Visible = false;

            btnMainKeyFunction.Enabled = true;
            btnShortCutFunction.Enabled = true;

            curActivatedKeyType = RecordKeyType.MainKey;

            switch (mode)
            {
                case Mode.Idle:
                    {
                        desiredRecordShortCut = string.Empty;
                        desiredExeShortCut = string.Empty;

                        curRecordKeyType = RecordKeyType.MainKey;

                        btnMainKeyFunction.Text = "녹화시작";
                        btnShortCutFunction.Text = "녹화시작";

                        if (prevMode == Mode.Activated)
                        {
                            SystemSounds.Hand.Play();

                            if (prevActivateKeyMode == RecordKeyType.MainKey)
                            {
                                //     string txtStop = "Stop";

                                //     if (string.IsNullOrEmpty(subInfo) == false)
                                {
                                    //         txtStop += " : " + subInfo;
                                }

                                // MessageBox.Show(txtStop);
                            }
                        }
                    }
                    break;
                case Mode.Recording:
                    {
                        btnMainKeyFunction.Enabled = false;
                        btnShortCutFunction.Enabled = false;

                        if (subInfo.Equals(RecordKeyType.MainKey.ToString()))
                        {
                            btnMainKeyFunction.Enabled = true;
                            btnMainKeyFunction.Text = "매크로 시작";
                            curRecordKeyType = RecordKeyType.MainKey;
                            mainTrackKeys.Clear();
                        }
                        else if (subInfo.Equals(RecordKeyType.ShortCutKey.ToString()))
                        {
                            btnShortCutFunction.Enabled = true;
                            btnShortCutFunction.Text = "녹화 중단";
                            curRecordKeyType = RecordKeyType.ShortCutKey;
                            shortCutKeys[shortCutKeySelections.SelectedItem.ToString()].Clear();
                        }

                        SystemSounds.Hand.Play();
                        WindowState = FormWindowState.Minimized;
                    }
                    break;
                case Mode.Activated:
                    if (subInfo.Equals(string.Empty) ||
                        subInfo == RecordKeyType.MainKey.ToString())
                    {
                        btnPause.Visible = true;
                        curActivatedKeyType = RecordKeyType.MainKey;
                        curTrack = mainTrackKeys;
                        btnMainKeyFunction.Text = "중지";
                    }
                    else if (subInfo == RecordKeyType.ShortCutKey.ToString())
                    {
                        curActivatedKeyType = RecordKeyType.ShortCutKey;
                        curTrack = shortCutKeys[desiredExeShortCut];
                        btnShortCutFunction.Text = "중지";

                        if (currentPosAutoClickShortCutCheck.Checked)
                        {
                            var oriPos = Cursor.Position;
                            DoMouseClick(oriPos.X, oriPos.Y);
                        }
                    }

                    //  string str = "";

                    //     for (int i = 0; i < keys.Count; i++)
                    //    {
                    //        str += keys[i].waitTime + " ";
                    //     }

                    if (prevMode != Mode.Pause)
                    {
                        curIndex = 0;
                        remainedTimeForNextClick = curTrack[0].waitTime;
                    }

                    useAutoDisableTimer = false;
                    useAutoDisableRemainedCnt = false;

                    if (subInfo == string.Empty ||
                        subInfo == RecordKeyType.MainKey.ToString())
                    {
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
                    }

                    //                 MessageBox.Show("Start Play : " + keys.Count);
                    break;
                case Mode.Pause:
                    {
                        btnMainKeyFunction.Text = "다시 시작";
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
                        authenticated = true; 
                        //using (var form = new AuthForm())
                        //{
                        //    var result = form.ShowDialog();

                        //    if (result == DialogResult.OK)
                        //    {
                        //        if (serials.Contains(form.typedSerial))
                        //        {
                        //            using (var writer = new StreamWriter(fullPath))
                        //            {
                        //                writer.Write(form.typedSerial);
                        //            }

                        //            MessageBox.Show("인증에 성공하였습니다. 감사합니다.");

                        //            authenticated = true;
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("존재하지 않는 시리얼 키입니다");
                        //        }
                        //    }
                        //}
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

                            remainedTimeForNextClick -= delay.TotalSeconds * curSpeedMutliplier;
                            remainedTimerSeconds -= delay.TotalSeconds * curSpeedMutliplier;

                            if (remainedTimeForNextClick <= 0)
                            {
                                DoAction(curTrack[curIndex]);
                                curIndex++;

                                if (curIndex >= curTrack.Count)
                                {
                                    curIndex = 0;
                                    cycleDone = true;
                                }

                                remainedTimeForNextClick = curTrack[curIndex].waitTime;
                            }

                            if (useAutoDisableTimer)
                            {
                                if (remainedTimerSeconds <= 0)
                                {
                                    SetMode(Mode.Idle, "타이머에 의한 종료");
                                    remainedTimerSeconds = 0;
                                }
                            }

                            if (curActivatedKeyType == RecordKeyType.MainKey)
                            {
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
                            }
                            if (curActivatedKeyType == RecordKeyType.ShortCutKey)
                            {
                                if (cycleDone)
                                {
                                    SetMode(Mode.Idle);
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
            desiredExeShortCut = string.Empty;

            /// space 키 누르면 왼쪽 클릭 녹화 기능 추가 
            if (IsKeyDown(Keys.Space))
            {
                if (curMode == Mode.Recording)
                {
                    AddMouseClickKey(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
            }
            else if (IsKeyDown(Keys.LShiftKey) && IsKeyDown(Keys.F9))
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
            else if (curMode != Mode.Recording && curMode != Mode.Activated)
            {
                if (IsKeyDown(Keys.LShiftKey) && IsKeyDown(Keys.F1))
                {
                    string key = shortCutKeySelections.Items[0].ToString();

                    if (shortCutKeys[key].Count > 0)
                    {
                        desiredExeShortCut = key;
                        SetMode(Mode.Activated, RecordKeyType.ShortCutKey.ToString());
                    }
                }
                else if (IsKeyDown(Keys.LShiftKey) && IsKeyDown(Keys.F2))
                {
                    string key = shortCutKeySelections.Items[1].ToString();

                    if (shortCutKeys[key].Count > 0)
                    {
                        desiredExeShortCut = key;
                        SetMode(Mode.Activated, RecordKeyType.ShortCutKey.ToString());
                    }
                }
                else if (IsKeyDown(Keys.LShiftKey) && IsKeyDown(Keys.F3))
                {
                    string key = shortCutKeySelections.Items[2].ToString();

                    if (shortCutKeys[key].Count > 0)
                    {
                        desiredExeShortCut = key;
                        SetMode(Mode.Activated, RecordKeyType.ShortCutKey.ToString());
                    }
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

                if (resetCursorPosCheckBox.Checked)
                    Cursor.Position = oriPos;
            }
            else if (singleAction.type == ActionType.Typing)
            {
                SendKeys.SendWait(singleAction.PickRandomString());
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

        private void OnClickMainKeyFunctionButton(object sender, EventArgs e)
        {
            if (authenticated == false)
            {
                MessageBox.Show("인증 안됨");
                return;
            }

            if (curMode == Mode.Idle)
                SetMode(Mode.Recording, RecordKeyType.MainKey.ToString());
            else if (curMode == Mode.Recording)
                TryActivate();
            else if (curMode == Mode.Activated)
                SetMode(Mode.Idle);
            else if (curMode == Mode.Pause)
                SetMode(Mode.Activated);
        }

        private void btnShortCutFunction_Click(object sender, EventArgs e)
        {
            if (authenticated == false)
            {
                MessageBox.Show("인증 안됨");
                return;
            }

            desiredRecordShortCut = string.Empty;

            if (curMode == Mode.Idle)
            {
                if (shortCutKeySelections.SelectedIndex == -1)
                {
                    MessageBox.Show("녹화타겟 ShortCut 을 선택해주세요");
                }
                else
                {
                    desiredRecordShortCut = shortCutKeySelections.SelectedItem.ToString();
                    SetMode(Mode.Recording, RecordKeyType.ShortCutKey.ToString());
                }
            }
            else
                SetMode(Mode.Idle);
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

        private void ApplySpeed()
        {
            curSpeedMutliplier = (double)speedMultiplier.Value;
            txtCurrentSpeed.Text = "현재 스피드 : " + curSpeedMutliplier.ToString();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void speedMultiplier_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSpeedApply_Click(object sender, EventArgs e)
        {
            if (authenticated == false)
            {
                MessageBox.Show("인증 안됨");
                return;
            }

            SystemSounds.Hand.Play();
            ApplySpeed();
        }

        private void shortCutKeySelections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authenticated == false)
            {
                MessageBox.Show("인증 안됨");
                return;
            }

            txtShortCutKeyStatus.Text = shortCutKeySelections.SelectedItem.ToString() + " 녹화 준비 완료";
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
