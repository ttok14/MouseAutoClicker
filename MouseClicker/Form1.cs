using System;
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

/// <summary>
/// 이슈 정리
/// - 알고리즘 보강  (자세한건 해당 함수 주석 ㄱㄱ)
///     => <see cref="MouseClicker.ScreenColorHelper.IsTarget(MouseClicker.DataContainer.ColorData, System.Drawing.Color[,], int, int, int, float, out float) "/>
/// </summary>
namespace MouseClicker
{
    public enum Mode
    {
        Idle,
        Recording,
        Pause,
        Activated,
    }

    /// <summary>
    /// Action 의 조건 타입 
    /// </summary>
    [Flags]
    public enum ActionConditionFlag
    {
        None = 0,
        ColorEquality = 0x1, // 특정 스크린 위치에 특정 Color RGB 값인 경우에만 Action 을 취함 
        Possibility = 0x1 << 1, // 확률로 Action 을 취함
        ScreenColorMatching = 0x1 << 2, // 스크린 색상 비교로 선택  
        FallBackClick = 0x1 << 3, // 모든 조건 다 실패시 마지막에 fallback 으로 클릭 시전용 
    }

    /// <summary>
    /// 기능 타입들 
    /// </summary>
    public enum ActionType
    {
        SingleMouseClick, // 단순 단일 마우스 클릭
        ConditionalClick, // 조건부 단일 마우스 클릭
        Typing, // 텍스트 타이핑 
        Esc // Esc 키 누름
    }

    /// <summary>
    /// 녹화 키 타입 
    /// </summary>
    public enum RecordKeyType
    {
        MainKey, // 주 타입
        ShortCutKey, // 쇼컷 타입 
        IdleConvenient, // idle 상태 편의기능
        WriteFile, // 파일 Write 용 
    }

    /// <summary>
    /// 클릭 Action 일때 부가 기능 타입 
    /// </summary>
    public enum ClickDecoType
    {
        None = 0,
        SingleClick,
        SingleWithVariousCondition
    }

    public partial class Form1 : Form
    {
        /// <summary>
        /// 하나의 액션 정의 
        /// </summary>
        [Serializable]
        public class SingleAction
        {
            public ActionType type;

            // click
            public Point pos;
            // typing
            public List<string> typingTexts;

            public ActionConditionFlag conditionFlags;
            public Form1.ConditionChecker.ConditionEvaluateParam conditionParam;

            public double waitTime;

            public SingleAction() { }
            /// <summary>
            /// 클릭 데이터 생성자 - 조건 X 
            /// </summary>
            public SingleAction(ActionType type, Point pos, double waitTime)
            {
                this.type = type;
                this.pos = pos;
                this.waitTime = waitTime;

                this.typingTexts = null;
                conditionFlags = ActionConditionFlag.None;
                conditionParam = default(Form1.ConditionChecker.ConditionEvaluateParam);
            }

            /// <summary>
            /// 클릭 데이터 생성자 - 조건 O
            /// </summary>
            public SingleAction(
                ActionType type
                , Point pos
                , double waitTime
                , ActionConditionFlag conditionFlag
                , Form1.ConditionChecker.ConditionEvaluateParam conditionParam)
            {
                this.type = type;
                this.pos = pos;
                this.waitTime = waitTime;
                this.conditionFlags = conditionFlag;
                this.conditionParam = conditionParam;

                this.typingTexts = null;
            }

            /// <summary>
            /// 타이핑 데이터 생성자
            /// </summary>
            public SingleAction(ActionType type, List<string> str, double waitTime)
            {
                this.type = type;
                this.typingTexts = str;
                this.waitTime = waitTime;

                pos = default(Point);
                conditionFlags = ActionConditionFlag.None;
                conditionParam = default(Form1.ConditionChecker.ConditionEvaluateParam);
            }

            /// <summary>
            /// 모든 데이터 생성자 
            /// </summary>
            public SingleAction(ActionType type, Point pos, List<string> str, ActionConditionFlag conditionFlags, Form1.ConditionChecker.ConditionEvaluateParam conditionParam, double waitTime)
            {
                this.type = type;
                this.pos = pos;
                this.typingTexts = str;
                this.conditionFlags = conditionFlags;
                this.conditionParam = conditionParam;
                this.waitTime = waitTime;
            }

            internal string PickRandomString()
            {
                if (typingTexts.Count == 0)
                    return "empty";
                return typingTexts[Form1.Randomize.GetRandomNum(0, typingTexts.Count)];
            }

            public double GetWaitTime()
            {
                return this.waitTime + Form1.Randomize.GetRandomNum_Double(GlobalSettingManager.RandomDelayBetweenActionMin, GlobalSettingManager.RandomDelayBetweenActionMax);
            }
        }

        private const int KEY_PRESSED = 0x80;

        private readonly string[] serials =
        {
            // Version 01 시리얼키 200 개 
            "920623","RKWF-OJXT-HKCE-TBRH","AFRB-RZAA-AEGI-XTOA","YDKA-ILIV-NWKU-DMKX","VFGA-RBWS-JVEK-DPVO","VCGQ-RQYO-XWOV-OGWO","UIMS-MOJX-GRRN-GYRX","AWYB-FUGE-GSCU-MADC","YQQU-CDBG-TJJZ-ZLIY","ERVR-HVIZ-CILU-LOKG","NPOQ-IXUX-VRHW-KGFV","JEQV-FLUD-HQSU-RGUF","YCLK-XSQH-WYWP-NMOV","DQKH-XPAB-UKIS-EAFO","XCYH-UVYR-NIYH-PEQV","BWRA-VMHI-CJPM-JYDW","SHSK-NGBI-RTUO-RTMQ","UNRH-JESK-VPFK-FLIP","FBOH-LFHU-VIIC-SSRI","XZRV-HVNN-PIPX-BQCG","KEJP-EFEP-FWMA-WQRC","XWNG-TMIK-OBSC-PJTE","GCRO-JCER-UCQK-JNRY","RMZE-DVMY-VYBC-NBZV","DHTT-YCSV-SVLR-WYBA","KTLC-JOBK-QTSK-ABET","DUGB-TYAO-TELH-KVCX","XAST-PWMO-FICF-KIVR","RSNC-RZGM-SWIF-CTAV","QUNA-IKDH-IRVL-VVEL","JUQS-HAFY-UGBT-NGLL","IHOP-UUIG-OGUZ-DVQX","SXWI-DINQ-OOGC-JKTB","FJCN-GORO-LJDB-GGUY","PDAQ-JDIA-TXAF-OGXE","MSUT-TDRE-GIWT-ELKI","UHNG-KDRC-BBTI-NLZF","MZPN-LBFM-MVKB-HOWI","NSLH-TQTJ-ARSR-JIRU","JQGE-WWWS-CATO-SQVM","FLVV-ZRMV-FFNU-IODD","EPRQ-IRLQ-VSFS-XFQJ","WFLX-NVVR-DKYQ-JCJN","XQJD-ZEEN-AEAG-MUYA","PDXD-CGPI-TAMX-SUHS","IRUG-VMKS-BXWJ-VPFJ","LYBF-FGKR-ABJY-SGUG","WHXU-ZRFC-TFBF-JGNE","UDMU-TCMC-GDGU-DLZV","CQNO-RKJT-TYLA-FFHT","NEEP-UANT-UVNV-LKZI","FGCT-TZNK-TSBU-RMWB","VMGY-HKAC-CUTW-WOII","YDUZ-COAO-RTWC-YSBH","YMZY-EAAU-FAQY-FQNF","JTVO-RXZH-LSHN-OYEK","SLXK-OJEX-CAUC-XBJA","FQSE-WNQB-MSMM-TMGG","WGGT-TDRZ-PYLR-DWKJ","IGIX-GZNE-VWXV-XRDP","TNFR-VPHB-ZSPY-BYYP","ICDN-EIAW-SBYX-GVCX","UWYP-RSOT-ZGXN-JPDW","XHNU-OQLK-NIZU-QJVE","PREF-AIYP-OJOY-LMND","YBZY-HIJD-LNCI-TUDP","KSYS-KXWO-IXFF-CMZB","VVVO-KXXH-IAUN-GQWU","GYNS-OUSB-FKQJ-CDBY","NBMX-YOFN-VRJK-CIIR","BLZD-ZHMA-DUIZ-HNEE","ZWZF-EYVR-TAWX-LIYW","CYHR-EXZG-OLUD-FFGH","MFKG-JCMC-PHKY-KPPU","VMXI-GNZC-XSRT-ESLO","UPKG-YSNZ-MEBW-NAWY","VAIT-IYBZ-FIIQ-LTYX","WWEV-FJWD-YYWB-LCPW","WSYE-KRFW-NLAP-KWNT","GEAR-VATL-DEUK-BANC","TLTT-UUNE-QIHU-IGTC","KDUH-CYAW-ZMAF-XVUN","XYWY-DUYL-RWAN-TZDX","LSZY-FGAV-KXUI-UHHU","OTXJ-JUYQ-EJPF-XNCZ","IDTE-VVIQ-YBNF-APRJ","OGZZ-CTNR-TJTW-QUXX","UUZQ-ODYS-LGLH-HTQP","RGQQ-OCXP-PCKM-BMZE","DPKF-PAUL-HGOV-HFJA","TEEK-DGJR-WKBM-SMRZ","HHES-IKZQ-LFJH-OCHJ","TJSW-HPAX-GTIE-ZISV","PPNA-BRSJ-ENYY-XCDU","DRTJ-TURS-GHLP-BURD","MNRY-OHIB-QJRT-QCZD","POBH-PJCU-XVTU-FDHK","WULJ-KEFV-JRSJ-CYBE","HIZN-SJOC-LWBT-NNWN","BHXV-QPTK-IGYX-RSSZ","TPMX-DURM-GJYN-DMHV","VFHU-AGNS-OPEM-LQLS","EBAY-AZJH-QLPH-QGGW","YCCM-KXYN-BUJO-QEAQ","XFIB-LIUV-VAEP-QGBH","IHNI-NZHH-DNXF-QVQL","KYJK-XFKP-HGQJ-SJWU","TBFI-QSCY-YBYY-LOFZ","KTFR-WQKD-XYAG-IYOT","RCMO-QIUS-WLMW-GMES","BRZZ-EEYC-RBLS-RVPZ","NEHI-CQJC-YMVK-EOWK","THFR-YOPN-EKXO-WBAA","WMIC-FWQK-HXBR-INYD","EAZJ-PXBZ-OUDS-TUFX","MUNR-FUFW-RVKA-NYEQ","LUJW-BQKZ-LINL-SYRM","SEFO-ZHXK-UCSU-NAMQ","PNGY-LIVV-JOFW-HUES","EXII-SQQE-XZCY-XQLK","WWVF-STBK-IKEL-BACZ","YAQP-SDYZ-WCAL-GWXT","CUAK-ZZAL-WYAI-LFCX","WCAX-AVSS-YVIP-SPDM","MLIG-ARAZ-ZFTT-DPNR","ZDPE-WZTH-BHMD-RKSG","UNVA-XVXE-BAXU-CZPJ","IQQP-ZZQM-RBFS-FXIP","MMYP-TNTD-GKCV-CYEC","RDVA-TDGV-XIIW-QEZE","SIHP-AZPU-WNIP-WVKT","WCAC-BHVJ-GDSK-EXMB","LXCT-QPCS-NADG-URYB","XPAO-DWDK-MYJW-HEQZ","BGDY-SRCG-ZIOB-EPOO","EQMP-XXYO-URGR-GGLJ","KEFO-NZJG-MTPV-IBGX","KURQ-RABD-IODA-KLZT","XFQZ-JAAE-HGDD-IDGT","LIHM-OURJ-CBFZ-VIWA","TVXC-LGNK-TMIL-XYUF","HKPB-ENFC-OGXI-UBJZ","KCJN-FEHE-UWSB-MFME","GARK-TUWG-QUOE-JFQS","DJBU-OHZD-DKGH-UEQI","USBT-KYFP-FDXK-PDVP","GAXC-ESPZ-ANHJ-NPLL","EFJQ-EWIF-DLPL-KONZ","ORBU-GNEC-DBTW-QWCP","RLGK-TFKJ-SRYT-CEOM","AIUW-ORFQ-BHNC-DMPH","JZTZ-IDFJ-HRCO-PLZY","NGWH-CFBA-FPIM-RHGG","CRJD-KPDW-DKOX-OQBQ","IOPW-PIFD-XSTS-VTRZ","KWMX-BVOX-DZER-RELP","ORDD-RKQT-LGGR-WLAJ","SOMS-DDPM-ASTP-DOMT","GEEE-POIA-FSLV-PWAS","ZUYC-STLK-CQDZ-QAPX","TNKS-GWUE-GLML-SUXD","RBQJ-QKBN-SUCZ-KIJF","COBC-LILC-ATVG-GASH","SZHP-JGHJ-LXZM-UVTX","BHIE-SVSJ-POJW-OUHS","CUGL-BUVW-GRQO-JZHF","ZXEY-RNPX-HXAV-WLVR","PGJA-OIWH-LLXB-EDAP","GEWR-QIBO-EIDD-UAAV","WZYC-PHQR-BXNG-QOSE","XKOS-ODBG-FVVG-FSNK","LCEF-EXAY-OFQS-VUXQ","PYGJ-LHGS-YRXT-LJLI","KCUN-JNZA-KPDI-NILK","XFQG-MDYD-VLHM-AGNE","UHIT-AKHC-ZGZW-EYFP","GNWG-TFWG-DRSX-FNZD","CYOF-ZSJN-XNHG-DCZX","GRGM-JGLO-LBPJ-RJWL","GVTF-JZQO-DIIF-XQCA","RUQO-HNTW-NZUX-CAVO","QVZH-JUNH-BRJB-XGRU","ZPRX-SIES-CXRK-ESLC","NUOB-QVQX-HJNP-ESYH","IAYN-IYVI-RHFM-CDDI","GGND-RPEE-YUPJ-VOOJ","YKBE-TYUP-YGKJ-PEVD","GEIX-FVPT-VUOO-IMMC","SWNR-BYOI-MYEL-FVOT","ZLCR-FRED-UIIZ-JFGL","THRS-QDCH-PALG-QENA","FUPW-KVWB-SKWT-PPYG","SSRX-EWCW-JUBF-FXMQ","UITO-QJBY-KQAG-GJRZ","CEOY-MQWJ-STNP-TRVU","YGYH-WKQI-RSMO-VWPA","CCDB-JNEE-MJWX-VMFT","UFHA-KKDR-NFHU-DHNV","DNMQ-OTLK-CUUM-NTNF","MTTQ-OPPS-YLNE-GJAE","VAUI-ZOFA-UXYQ-PREU"
        };

        bool authenticated = false;
        bool isAuthFileExist = false;

        public Mode curMode = Mode.Idle;
        TimeSpan delay = TimeSpan.FromMilliseconds(1000 / 60);

        RecordKeyType curRecordKeyType;
        RecordKeyType curActivatedKeyType;
        RecordKeyType curIdleConvenientKeyType;

        ConditionChecker conditionChecker;

        /// <summary>
        /// 주 action 
        /// </summary>
        List<SingleAction> mainTrackKeys = new List<SingleAction>();

        /// <summary>
        /// ShotCut Action 
        /// </summary>
        Dictionary<string, List<SingleAction>> shortCutKeys = new Dictionary<string, List<SingleAction>>();
        /// <summary>
        /// Idle 편의 기능용 action 
        /// </summary>
        List<SingleAction> idleConvenientKeys = new List<SingleAction>();
        /// <summary>
        /// File Write 용 action 
        /// </summary>
        List<SingleAction> fileWriteKeys = new List<SingleAction>();

        DataContainer.ActionGroup curActionGroup;

        List<SingleAction> curTrack;
        string desiredRecordShortCut;
        string desiredExeShortCut;
        int curIndex;
        double remainedTimeForNextAction;

        double recordIntervalTime;

        bool useAutoDisableTimer;
        double remainedTimerSeconds;

        bool useAutoDisableRemainedCnt;
        int remainedCnt;

        bool lockState;

        public Form1()
        {
            MouseCallBack.onLeftMouseDown = OnLeftMouseClicked;
            MouseCallBack.onRightMouseDown = OnRightMouseClicked;
            MouseCallBack.onWheelDown = OnWheelDown;

            InitializeComponent();
            DataContainer.Instance.Initialize();

            foreach (var item in shortCutKeySelections.Items)
            {
                shortCutKeys.Add(item.ToString(), new List<SingleAction>());
            }

            this.conditionChecker = new ConditionChecker(GetColorAt);

            SetMode(Mode.Idle);
            Initialize_HandleOtherWindow();

            Task.Run(() => UpdateLoop());
        }

        /// <summary>
        /// float 형 point
        /// </summary>
        [Serializable]
        public class PointFloat
        {
            public float x;
            public float y;

            public PointFloat(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// 랜덤값 생성기
        /// </summary>
        public class Randomize
        {
            static Random random = new Random();

            public static int GetRandomNum(int min, int max)
            {
                return random.Next(min, max);
            }

            public static double GetRandomNum_Double(double min, double max)
            {
                var zeroToOne = random.NextDouble();
                return min + ((max - min) * zeroToOne);
            }
        }

        /// <summary>
        /// 조건 검사 담당 클래스 
        /// </summary>
        [Serializable]
        public class ConditionChecker
        {
            [Serializable]
            public class ConditionEvaluateParam
            {
                /// <summary>
                /// 색상 체크용 
                /// </summary>
                public Point pixelCheckTargetCursorPos;
                public Color pixelCheckTargetColor;

                /// <summary>
                /// fall back 용 위치 
                /// </summary>
                public Point fallBackClickPos;
                /// <summary>
                /// 타겟 색상용 위치 
                /// </summary>
                public Point colorMatchingClickPos;
                /// <summary>
                /// 랜덤 확률용 위치 
                /// </summary>
                public Point randomPossibilityClickPos;
                /// <summary>
                /// 스크린 영역 매칭용 위치
                /// </summary>
                public Point screenColorMatchingClickPos;

                /// <summary>
                /// 랜덤 확률용 
                /// </summary>
                public int percentage;

                /// <summary>
                /// 조건분기따라 클릭하는용 
                /// </summary>
                // public List<PositionBySelection> posBySelection;
                public List<Rectangle> screenColorMatchingAreas = new List<Rectangle>();
                public string screenColorMatchingStringKey;
                /// <summary>
                /// 조건 성공 기준 값 0~1
                /// </summary>
                public float screenColorMatchingSimilarityThreshold;

                public ConditionEvaluateParam() { }
                public ConditionEvaluateParam(Point targetCursorPos, Color targetColor, Point fallBackPos, int percentage, string screenColorMatchingStringKey, List<Rectangle> areaColorMatching, float screenColorMatchingSimilarityThreshold)
                {
                    this.pixelCheckTargetCursorPos = targetCursorPos;
                    this.pixelCheckTargetColor = targetColor;
                    this.fallBackClickPos = fallBackPos;
                    this.percentage = percentage;
                    this.screenColorMatchingStringKey = screenColorMatchingStringKey;
                    this.screenColorMatchingAreas = areaColorMatching;
                    this.screenColorMatchingSimilarityThreshold = screenColorMatchingSimilarityThreshold;
                }

                public void SetAllPos(Point pos)
                {
                    this.fallBackClickPos = pos;
                    this.colorMatchingClickPos = pos;
                    this.pixelCheckTargetCursorPos = pos;
                    this.randomPossibilityClickPos = pos;
                }
            }

            /// <summary>
            /// 조건평과 결과 데이터 
            /// </summary>
            public class ConditionEvaluateResultInfo
            {
                public bool success;
                public Point resultPoint;

                public ConditionEvaluateResultInfo(bool success)
                {
                    this.success = success;
                }
                public ConditionEvaluateResultInfo(bool success, Point resultPoint)
                {
                    this.success = success;
                    this.resultPoint = resultPoint;
                }
            }

            public ConditionChecker(Func<Point, Color> colorGetter)
            {
                this.colorGetter = colorGetter;
            }

            Func<Point, Color> colorGetter;
            Dictionary<ActionConditionFlag, Predicate<ConditionEvaluateParam>> checkers = new Dictionary<ActionConditionFlag, Predicate<ConditionEvaluateParam>>();

            /// <summary>
            /// 각종 조건 변수들을 체크해서 맞는 Result 정보를 리턴.
            /// </summary>
            public ConditionEvaluateResultInfo Evaluate(ActionConditionFlag flags, ConditionEvaluateParam param)
            {
                /// 색상 일치 체커
                if ((flags & ActionConditionFlag.ColorEquality) != 0)
                {
                    if (colorGetter(param.pixelCheckTargetCursorPos) == param.pixelCheckTargetColor)
                    {
                        return new ConditionEvaluateResultInfo(true, param.colorMatchingClickPos);
                    }
                }

                /// 확률 체킹
                if ((flags & ActionConditionFlag.Possibility) != 0)
                {
                    if (Randomize.GetRandomNum(0, 101) <= param.percentage)
                    {
                        return new ConditionEvaluateResultInfo(true, param.randomPossibilityClickPos);
                    }
                }

                /// 컬러매칭 
                if ((flags & ActionConditionFlag.ScreenColorMatching) != 0)
                {
                    for (int i = 0; i < param.screenColorMatchingAreas.Count; i++)
                    {
                        var targetColors = ScreenColorHelper.Instance.GetScreenColors(param.screenColorMatchingAreas[i]);
                        float resultSimilarity;

                        var targetColorData = DataContainer.Instance.GetScreenMatchingColorDataByKey(param.screenColorMatchingStringKey);

                        if (targetColorData != null)
                        {
                            bool screenColorMatchingResult =
                                ScreenColorHelper.Instance.IsTarget(
                                targetColorData
                                , targetColors
                                , param.screenColorMatchingAreas[i].Width
                                , param.screenColorMatchingAreas[i].Height
                                , 10
                                , param.screenColorMatchingSimilarityThreshold
                                , out resultSimilarity);

                            if (screenColorMatchingResult)
                            {
                                //  SystemSounds.Hand.Play();
                                return new ConditionEvaluateResultInfo(true, param.screenColorMatchingClickPos);
                            }
                        }
                        else
                        {
                            MessageBox.Show("미리 로드해놓던지 하시오. 이 메시지는 보이면 안됨.");
                        }
                    }
                }

                /// FallBack 처리 
                if ((flags & ActionConditionFlag.FallBackClick) != 0)
                    return new ConditionEvaluateResultInfo(true, param.fallBackClickPos);

                return new ConditionEvaluateResultInfo(success: false);
            }
        }

        private void OnLeftMouseClicked(int x, int y)
        {
            if (lockState)
                return;

            if (curMode != Mode.Recording)
                return;

            var intervalTime = recordIntervalTime;
            Point pos = new Point(x, y);

            /// RShift 클릭
            /// => 조건부 마우스 클릭 기능 발동 
            if (IsKeyDown(Keys.RShiftKey))
            {
                using (var form = new ClickConditionSelection(GetColorAt))
                {
                    lockState = true;
                    form.TopMost = true;

                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        AddMouseClickAction(new Point(x, y), form.OutputFlags, form.OutputEvaluateParam);
                    }
                    /// OK 가 아님 
                    /// => 그냥 일반 클릭으로 판정하자 .
                    else
                    {
                        AddMouseClickAction(new Point(x, y), ActionConditionFlag.None, new ConditionChecker.ConditionEvaluateParam());
                    }

                    lockState = false;
                }

                //using (var form = new ConditionSelectionForm(GetColorAt))
                //{
                //    lockState = true;
                //    form.TopMost = true;

                //    form.Update();

                //    /// Open 함과 동시에 블록
                //    if (form.ShowDialog() == DialogResult.OK)
                //    {
                //        AddMouseClickAction(new Point(x, y), form.Flags, form.Param);
                //    }

                //    /// 이 시점에는 꺼진거 
                //    lockState = false;
                //}
            }
            else
            {
                /// 왼쪽 Shift 를 누른 상태서 왼쪽 클릭하면 더블 클릭으로 판정 
                if (IsKeyDown(Keys.LShiftKey))
                {
                    AddMouseClickAction(pos: pos, desiredRecordIntervalTime: intervalTime);
                }

                AddMouseClickAction(pos: pos, desiredRecordIntervalTime: intervalTime);
            }
        }

        /// <summary>
        /// 하나의 마우스 클릭 액션 추가 
        /// </summary>
        void AddMouseClickAction(
            Point pos
            , ActionConditionFlag conditionFlags = ActionConditionFlag.None
            , ConditionChecker.ConditionEvaluateParam conditionParam = default(ConditionChecker.ConditionEvaluateParam)
            , double? desiredRecordIntervalTime = null)
        {
            List<SingleAction> targetTrack = null;

            if (curRecordKeyType == RecordKeyType.MainKey)
                targetTrack = mainTrackKeys;
            else if (curRecordKeyType == RecordKeyType.ShortCutKey)
                targetTrack = shortCutKeys[shortCutKeySelections.SelectedItem.ToString()];
            else if (curRecordKeyType == RecordKeyType.IdleConvenient)
                targetTrack = idleConvenientKeys;
            else if (curRecordKeyType == RecordKeyType.WriteFile)
                targetTrack = fileWriteKeys;
            else
            {
                MessageBox.Show($"Handle this type. {curRecordKeyType}");
            }

            targetTrack.Add(new SingleAction(
                conditionFlags == ActionConditionFlag.None ? ActionType.SingleMouseClick : ActionType.ConditionalClick,
                new Point(pos.X, pos.Y),
                desiredRecordIntervalTime != null && desiredRecordIntervalTime.HasValue ? desiredRecordIntervalTime.Value : recordIntervalTime,
                conditionFlags,
                conditionParam));

            recordIntervalTime = 0;
        }

        /// 현재 상태에서 Activate 상태로 전환 시도 . 
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
            else if (curRecordKeyType == RecordKeyType.IdleConvenient && idleConvenientKeys != null && idleConvenientKeys.Count > 0)
            {
                SetMode(Mode.Activated);
            }
            else if (curRecordKeyType == RecordKeyType.WriteFile && fileWriteKeys != null && fileWriteKeys.Count > 0)
            {
                /// 지금까지 record 된거 List 를 넘겨줌 . 
                OpenActionEditor(this.fileWriteKeys);
                /// writeFIle 같은 경우는 바로 idle 로 . 
                SetMode(Mode.Idle);
            }
            else
            {
                SetMode(Mode.Idle);
                MessageBox.Show("Nothing Recorded");
            }
        }

        private void OnRightMouseClicked(int x, int y)
        {
            if (lockState)
                return;

            if (curMode == Mode.Idle)
            {
                if (useIdleConvenientFeature.Checked && idleConvenientKeys.Count > 0)
                {
                    SetMode(Mode.Activated, RecordKeyType.IdleConvenient.ToString());
                }
            }
            else if (curMode == Mode.Recording)
            {
                if (curRecordKeyType == RecordKeyType.MainKey)
                {
                    TryActivate();
                }
                else if (curRecordKeyType == RecordKeyType.ShortCutKey)
                {
                    SetMode(Mode.Idle);
                }
                else if (curRecordKeyType == RecordKeyType.IdleConvenient)
                {
                    SetMode(Mode.Idle);
                }
                else if (curRecordKeyType == RecordKeyType.WriteFile)
                {
                    TryActivate();
                }
            }
            else if (curMode == Mode.Activated || curMode == Mode.Pause)
            {
                SetMode(Mode.Idle);
            }
        }

        private void OnWheelDown(int x, int y)
        {
            if (lockState)
                return;

            if (curMode == Mode.Idle)
            {
                if (useIdleConvenientFeature.Checked)
                {
                    SendKeys.Send("{ESC}");
                }
            }
            else if (curMode == Mode.Recording)
            {
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
                    lockState = true;
                    form.TopMost = true;

                    // form.WindowState = FormWindowState.Maximized;
                    ///   form.BringToFront();

                    /// Open 함과 동시에 블록
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        targetTrack.Add(new SingleAction(ActionType.SingleMouseClick, new Point(x, y), recordIntervalTime));
                        recordIntervalTime = 0;
                        targetTrack.Add(new SingleAction(ActionType.Typing, form.Txts, 0.05f));
                    }

                    lockState = false;
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
            btnRecordIdle.Enabled = true;
            btnRecord_writeFile.Enabled = true;

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
                        btnRecordIdle.Text = "녹화시작";
                        // btnRecord_writeFile.Text = "Action 녹화하기";

                        if (prevMode == Mode.Activated)
                        {
                            SystemSounds.Hand.Play();
                        }
                    }
                    break;
                case Mode.Recording:
                    {
                        btnMainKeyFunction.Enabled = false;
                        btnShortCutFunction.Enabled = false;
                        btnRecordIdle.Enabled = false;
                        btnRecord_writeFile.Enabled = false;

                        /// subInfo 에 어떤 모드로 녹화하는지 식별 타입이 있음 
                        if (subInfo.Equals(RecordKeyType.MainKey.ToString()))
                        {
                            btnMainKeyFunction.Enabled = true;
                            btnMainKeyFunction.Text = "매크로 시작";
                            curRecordKeyType = RecordKeyType.MainKey;
                            /// 참조관계땜에 new 로 새로할당함 .
                            mainTrackKeys = new List<SingleAction>();
                        }
                        else if (subInfo.Equals(RecordKeyType.ShortCutKey.ToString()))
                        {
                            btnShortCutFunction.Enabled = true;
                            btnShortCutFunction.Text = "녹화 중단";
                            curRecordKeyType = RecordKeyType.ShortCutKey;
                            shortCutKeys[shortCutKeySelections.SelectedItem.ToString()].Clear();
                        }
                        else if (subInfo.Equals(RecordKeyType.IdleConvenient.ToString()))
                        {
                            btnRecordIdle.Enabled = true;
                            btnRecordIdle.Text = "녹화 중단";
                            curRecordKeyType = RecordKeyType.IdleConvenient;
                            idleConvenientKeys.Clear();
                        }
                        else if (subInfo.Equals(RecordKeyType.WriteFile.ToString()))
                        {
                            btnRecord_writeFile.Enabled = true;
                            // btnRecord_writeFile.Text = "녹화 중단";
                            curRecordKeyType = RecordKeyType.WriteFile;
                            fileWriteKeys.Clear();
                        }

                        SystemSounds.Hand.Play();
                        WindowState = FormWindowState.Minimized;
                    }
                    break;
                case Mode.Activated:
                    {
                        /// Activated 상태로 전환됐을때 
                        /// 타입별 처리 
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

                            /// 시작시 클릭 효과 기능 사용
                            if (currentPosAutoClickShortCutCheck.Checked)
                            {
                                var oriPos = Cursor.Position;
                                DoMouseClick(oriPos.X, oriPos.Y);
                            }
                        }
                        else if (subInfo == RecordKeyType.IdleConvenient.ToString())
                        {
                            btnRecordIdle.Enabled = true;
                            btnRecordIdle.Text = "중지";
                            curActivatedKeyType = RecordKeyType.IdleConvenient;
                            curTrack = idleConvenientKeys;

                            /// 시작시 클릭 효과 기능 사용
                            if (idleConv_clickAtFirst.Checked)
                            {
                                DoMouseClick(Cursor.Position.X, Cursor.Position.Y);
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
                            remainedTimeForNextAction = curTrack[0].GetWaitTime();
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
                    }
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

        /// <summary>
        /// 업데이트 루프 
        /// </summary>
        async Task UpdateLoop()
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

                /// Form open 체크 및 
                /// 업데이트 루프 막음. 
                if (lockState)
                {
                    await Task.Delay(delay);
                    continue;
                }

                ProcessKeyDown();
                Update_HandleOtherWindow(delay);
                Update_SubInfo();

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

                            /// 다음 Action 을 위해 시간 차감 업데이트 
                            remainedTimeForNextAction -= delay.TotalSeconds * GlobalSettingManager.SpeedMultiplier;
                            /// 기능 자동 종료 시간 차감 업데이트 
                            remainedTimerSeconds -= delay.TotalSeconds * GlobalSettingManager.SpeedMultiplier;

                            if (remainedTimeForNextAction <= 0)
                            {
                                DoAction(curTrack[curIndex]);
                                curIndex++;

                                if (curIndex >= curTrack.Count)
                                {
                                    curIndex = 0;
                                    cycleDone = true;
                                }

                                remainedTimeForNextAction = curTrack[curIndex].GetWaitTime();
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
                            else if (curActivatedKeyType == RecordKeyType.ShortCutKey)
                            {
                                if (cycleDone)
                                {
                                    SetMode(Mode.Idle);
                                }
                            }
                            else if (curActivatedKeyType == RecordKeyType.IdleConvenient)
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

        /// <summary>
        /// 부가정보 업데이트
        /// </summary>
        public void Update_SubInfo()
        {
            var col = GetColorAt(Cursor.Position);
            /// 알파값 출력 안함 
            /// => e.g A=n 값 제거 처리
            string strColor = col.ToString();
            int alphaIndex = strColor.IndexOf("A=");

            if (alphaIndex != -1)
            {
                int commaIndex = strColor.IndexOf(",");
                if (commaIndex != -1)
                {
                    /// 뒤에 공백까지 전부 제거 . 
                    strColor = strColor.Remove(alphaIndex, commaIndex - alphaIndex + 2);
                }
            }

            txtCursorColor.Text = strColor;
            txt_cursorPos.Text = Cursor.Position.ToString();
        }

        /// <summary>
        /// 실시간 키 누름 감지 
        /// </summary>
        private void ProcessKeyDown()
        {
            desiredExeShortCut = string.Empty;

            /// 마우스 스크롤
            /// => 안드로이드 에뮬레이터에선 작동안함 
            //if(IsKeyDown(Keys.O))
            //{
            //    mouse_event(0x0800, 100, 10, -1000, 0);
            //}

            //if (IsKeyDown(Keys.P))
            //{
            //    MessageBox.Show("Test");

            //    using (var form = new SelectArea())
            //    {
            //        var result = form.ShowDialog();
            //        if (result == DialogResult.OK)
            //        {

            //        }
            //    }
            //}
            //if (IsKeyDown(Keys.O))
            //{
            //    MessageBox.Show("Test");

            //    using (var form = new NumberColorSetForm())
            //    {
            //        var result = form.ShowDialog();
            //    }
            //}
            //if (IsKeyDown(Keys.I))
            //{
            //    MessageBox.Show("Test");

            //    using (var form = new ScreenColorInfoExtractor())
            //    {
            //        var result = form.ShowDialog();
            //    }
            //}
            //if (IsKeyDown(Keys.U))
            //{
            //    MessageBox.Show("Test");

            //    using (var form = new ColorDataEditorForm())
            //    {
            //        var result = form.ShowDialog();
            //    }
            //}

            /// space 키 누르면 왼쪽 클릭 녹화 기능 추가 
            if (IsKeyDown(Keys.Space))
            {
                if (curMode == Mode.Recording)
                {
                    AddMouseClickAction(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
            }
            /// ESC && Shift 
            /// => ESC 키 send 
            else if (IsKeyDown(Keys.Escape) && IsKeyDown(Keys.LShiftKey))
            {
                if (curMode == Mode.Recording)
                {
                    List<SingleAction> targetTrack = null;

                    if (curRecordKeyType == RecordKeyType.MainKey)
                        targetTrack = mainTrackKeys;
                    else if (curRecordKeyType == RecordKeyType.ShortCutKey)
                        targetTrack = shortCutKeys[shortCutKeySelections.SelectedItem.ToString()];
                    else if (curRecordKeyType == RecordKeyType.IdleConvenient)
                        targetTrack = idleConvenientKeys;
                    else if (curRecordKeyType == RecordKeyType.WriteFile)
                        targetTrack = fileWriteKeys;

                    if (targetTrack.Count > 0)
                    {
                        var last = targetTrack[targetTrack.Count - 1];

                        /// 이 경우에는 의도치않게 더블로 들어온걸로 간주하고 abort 함. 
                        /// => 원래는 getKeyUp 체크해야하는데 귀찮음 
                        if (last.type == ActionType.Esc
                            && last.waitTime <= 0.2f)
                        {
                            return;
                        }
                    }

                    SystemSounds.Hand.Play();
                    targetTrack.Add(new SingleAction()
                    {
                        type = ActionType.Esc,
                        waitTime = recordIntervalTime
                    });

                    recordIntervalTime = 0;
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

        /// <summary>
        /// 액션
        /// </summary>
        private void DoAction(SingleAction singleAction)
        {
            ///// 조건 체크 
            //if (this.conditionChecker.Check(singleAction.conditionFlags, singleAction.conditionParam) == false)
            //    return;

            /// 단일 클릭 
            /// => 걍 한번 클릭. 끝 
            if (singleAction.type == ActionType.SingleMouseClick)
            {
                var oriPos = Cursor.Position;
                DoMouseClick(singleAction.pos.X, singleAction.pos.Y);

                if (resetCursorPosCheckBox.Checked)
                    Cursor.Position = oriPos;
            }
            /// 조건부 단일 클릭
            /// => 각종 조건 체크후 적절한 위치 클릭. 또는 클릭안될수도. 
            else if (singleAction.type == ActionType.ConditionalClick)
            {
                var resultInfo = this.conditionChecker.Evaluate(singleAction.conditionFlags, singleAction.conditionParam);

                /// success 가 True 일때만 
                /// 액션을 취함.
                if (resultInfo.success)
                {
                    DoMouseClick(resultInfo.resultPoint.X, resultInfo.resultPoint.Y);
                }
            }
            else if (singleAction.type == ActionType.Typing)
            {
                SendKeys.SendWait(singleAction.PickRandomString());
                SendKeys.Send("{ENTER}");
            }
            else if (singleAction.type == ActionType.Esc)
            {
                SendKeys.Send("{ESC}");
            }
        }

        private void OpenActionEditor(List<SingleAction> fileWriteKeys)
        {
            lockState = true;
            using (var form = new ActionEditor(fileWriteKeys))
            {
                form.TopMost = true;
                var result = form.ShowDialog();
                WindowState = FormWindowState.Normal;
                lockState = false;

                if (result == DialogResult.OK)
                {
                    txtCurActionGroupKey.Text = form.ResultActionGroup.key;
                    curActionGroup = form.ResultActionGroup;
                }
                else
                {
                    /// 만약 지금 세팅돼있는 ActionGroup 이 삭제됐거나 하면 그에따른 필요한 처리
                    if (curActionGroup != null && string.IsNullOrEmpty(curActionGroup.key) == false)
                    {
                        if (DataContainer.Instance.IsTargetActionGroupExist(curActionGroup.key) == false)
                        {
                            txtCurActionGroupKey.Text = "없음";
                            curActionGroup = null;
                        }
                    }
                }

                btnActivateActionGroup.Enabled = this.curActionGroup != null && this.curActionGroup.actions.Count > 0;
            }
        }

        [DllImport("USER32.dll")]
        public static extern short GetKeyState(Keys nVirtKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, int cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnActivateActionGroup.Enabled = false;
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

        private void btnRecordIdle_Click(object sender, EventArgs e)
        {
            if (authenticated == false)
            {
                MessageBox.Show("인증 안됨");
                return;
            }

            if (curMode == Mode.Idle)
            {
                SetMode(Mode.Recording, RecordKeyType.IdleConvenient.ToString());
            }
            else
            {
                SetMode(Mode.Idle);
            }
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void speedMultiplier_ValueChanged(object sender, EventArgs e)
        {

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

        /// <summary>
        /// 사용법 form 오픈 
        /// </summary>
        private void btnShowInstruction_Click(object sender, EventArgs e)
        {
            using (var form = new Usage())
            {
                lockState = true;
                form.ShowDialog();
                lockState = false;
            }
        }

        private void useIdleConvenientFeature_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 색상 매칭 관련 편집기 오픈 
        /// </summary>
        private void btnColorExtractor_Click(object sender, EventArgs e)
        {
            using (var form = new ColorDataEditorForm())
            {
                var result = form.ShowDialog();
            }
        }

        private void btnGlobalSetting_Click(object sender, EventArgs e)
        {
            using (var form = new GlobalSettingForm())
            {
                var result = form.ShowDialog();
            }
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            OpenActionEditor(null);
        }

        private void btnRecord_writeFile_Click(object sender, EventArgs e)
        {
            if (curMode == Mode.Idle)
            {
                SetMode(Mode.Recording, RecordKeyType.WriteFile.ToString());
            }
            else
            {
                SetMode(Mode.Idle);
            }
        }

        private void btnActivateActionGroup_Click(object sender, EventArgs e)
        {
            if (curMode != Mode.Idle || curActionGroup == null || curActionGroup.actions.Count == 0)
                return;

            /// MainKey Track 으로 Play 
            mainTrackKeys = curActionGroup.actions;
            curRecordKeyType = RecordKeyType.MainKey;
            WindowState = FormWindowState.Minimized;

            TryActivate();
        }
    }
}
