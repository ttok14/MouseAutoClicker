using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClicker
{
    public class ScreenTxtConverter
    {
        static ScreenTxtConverter instance;
        public static ScreenTxtConverter Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenTxtConverter();
                return instance;
            }
        }

        //public bool GetNumber(Color[,] queryArea, out int number)
        //{
        //    number = 0;

        //    if (DataContainer.Instance.IsNumberColorDataReady() == false)
        //    {
        //        MessageBox.Show("먼저 숫자 색상 데이터를  전부 세팅해주세요.");
        //        return false;
        //    }


        //}
    }
}
