using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClicker
{
    class ScreenColorParser
    {
        /// <summary>
        /// Key : 숫자 
        /// Value : 스크린상 특정 영역의 행렬 색상 값
        /// </summary>
        public Dictionary<uint, Color[,]> numberIdentifier = new Dictionary<uint, Color[,]>();

        public void SetNumberRef(
            Color[,] colorInfo_zero
            , Color[,] colorInfo_one
            , Color[,] colorInfo_two
            , Color[,] colorInfo_three
            , Color[,] colorInfo_four
            , Color[,] colorInfo_five
            , Color[,] colorInfo_six
            , Color[,] colorInfo_seven
            , Color[,] colorInfo_eight
            , Color[,] colorInfo_nine)
        {
            numberIdentifier.Add(0, colorInfo_zero);
            numberIdentifier.Add(1, colorInfo_one);
            numberIdentifier.Add(2, colorInfo_two);
            numberIdentifier.Add(3, colorInfo_three);
            numberIdentifier.Add(4, colorInfo_four);
            numberIdentifier.Add(5, colorInfo_five);
            numberIdentifier.Add(6, colorInfo_six);
            numberIdentifier.Add(7, colorInfo_seven);
            numberIdentifier.Add(8, colorInfo_eight);
            numberIdentifier.Add(9, colorInfo_nine);
        }

        public void SetNumber(uint number, Color[,] colorInfo)
        {
            if (numberIdentifier.ContainsKey(number) == false)
            {
                numberIdentifier.Add(number, default(Color[,]));
            }

            numberIdentifier[number] = colorInfo;
        }

        public void SetNumber_SelectArea()
        {

        }
    }
}
