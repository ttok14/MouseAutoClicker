using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /// <summary>
            /// 해당 문자의 컬러키.
            /// </summary>
            public Color colorKey;
            /// <summary>
            /// 버리는 색상
            /// </summary>
            public Color discardKey;

            public ColorData()
            {
            }
            public ColorData(string str, Color[,] colorInfo, Color colorKey)
            {
                this.str = str;
                this.colorInfo = colorInfo;
                this.colorKey = colorKey;
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
