using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseClicker.Form1;

namespace MouseClicker
{
    public class DataContainer
    {
        /// <summary>
        /// IO 용 색상 데이터 
        /// </summary>
        [Serializable]
        public class ColorData
        {
            public string str;
            /// <summary>
            /// 영역에 대한 색상배열 
            /// </summary>
            public Color[,] colorInfo;
            public int width;
            public int height;

            /// <summary>
            /// 해당 문자의 컬러키.
            /// </summary>
            public Color colorKey;
            /// <summary>
            /// 버리는 색상
            /// </summary>
            public Color discardKey;

            /// <summary>
            /// 컬러키에 매칭되는 픽셀들의 0~1 로 정규화된 위치들
            /// </summary>
            public List<PointFloat> matchingColorNormalizedPos;

            /// <summary>
            /// 컬러키에 매칭되는 픽셀이 몇개나 있는가 ? 
            /// => 오차 허용 
            /// </summary>
            public int colorKeyMatchingCount;

            /// <summary>
            /// 컬러 매칭 개수 계산에 사용된 오차 범위 
            /// </summary>
            public int acceptRange;

            public ColorData()
            {
            }
        }

        static DataContainer instance;
        public static DataContainer Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataContainer();
                return instance;
            }
        }

        public static Dictionary<string, ColorData> ColorCompareBuffer = new Dictionary<string, ColorData>();

        public void SetData_ColorCompare(string str, ColorData colorData)
        {
            if (ColorCompareBuffer.ContainsKey(str) == false)
            {
                ColorCompareBuffer.Add(str, colorData);
            }
            else
            {
                ColorCompareBuffer[str] = colorData;
            }
        }

        public bool IsNumberColorDataReady()
        {
            for (int i = 0; i < 10; i++)
            {
                if (ColorCompareBuffer.ContainsKey(i.ToString()) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public ColorData GetColorData(string str)
        {
            if (IsNumberColorDataReady() == false)
            {
                MessageBox.Show("ColorCompareData 가 존재하지 않습니다.");
                return null;
            }

            return ColorCompareBuffer[str];
        }

        /// IO API ㄱㄱ 
    }
}
