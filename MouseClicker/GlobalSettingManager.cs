using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClicker
{
    class GlobalSettingManager
    {
        /// <summary>
        /// 스피드 곱셉 값 
        /// </summary>
        public static double SpeedMultiplier = 1;

        /// <summary>
        /// Action 간의 딜레이 추가 랜덤값 Min/Max
        /// </summary>
        public static double RandomDelayBetweenActionMin = 0;
        public static double RandomDelayBetweenActionMax = 0;

        public static void SetSpeedMultiplier(double speedMultiplier)
        {
            SpeedMultiplier = speedMultiplier;
        }

        public static void SetRandomDelayMinMax(double min, double max)
        {
            RandomDelayBetweenActionMin = min;
            RandomDelayBetweenActionMax = max;
        }
    }
}
