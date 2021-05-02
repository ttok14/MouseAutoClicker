using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MouseClicker.Form1;

namespace MouseClicker
{
    public class ScreenColorHelper
    {
        static ScreenColorHelper instance;
        public static ScreenColorHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenColorHelper();
                return instance;
            }
        }

        int Clamp(int v, int min, int max)
        {
            if (v < min)
                v = min;
            else if (v > max)
                v = max;
            return v;
        }

        /// <summary>
        /// 색상이 범위내에 있는지 체크 
        /// </summary>
        /// <param name="acceptRange"> 오차 허용 범위 </param>
        public bool IsColorInRange(Color color, Color checkColorKey, int acceptRange)
        {
            int min_r = checkColorKey.R - acceptRange;
            int min_g = checkColorKey.G - acceptRange;
            int min_b = checkColorKey.B - acceptRange;
            int max_r = checkColorKey.R + acceptRange;
            int max_g = checkColorKey.G + acceptRange;
            int max_b = checkColorKey.B + acceptRange;

            min_r = Clamp(min_r, 0, 255);
            min_g = Clamp(min_g, 0, 255);
            min_b = Clamp(min_b, 0, 255);
            max_r = Clamp(max_r, 0, 255);
            max_g = Clamp(max_g, 0, 255);
            max_b = Clamp(max_b, 0, 255);

            return ((color.R >= min_r && color.R <= max_r)
                     && (color.G >= min_g && color.G <= max_g)
                     && (color.B >= min_b && color.B <= max_b));
        }

        /// <summary>
        /// 매칭되는 색상들 가져오기 
        /// => return : 매칭 색상 갯수 
        /// </summary>
        public int GetMatchingColorInfo(Color[,] colorInfo, int width, int height, Color colorKey, int acceptRange, out List<PointFloat> resultNormalizedPos)
        {
            resultNormalizedPos = new List<PointFloat>();

            int min_r = colorKey.R - acceptRange;
            int min_g = colorKey.G - acceptRange;
            int min_b = colorKey.B - acceptRange;
            int max_r = colorKey.R + acceptRange;
            int max_g = colorKey.G + acceptRange;
            int max_b = colorKey.B + acceptRange;

            min_r = Clamp(min_r, 0, 255);
            min_g = Clamp(min_g, 0, 255);
            min_b = Clamp(min_b, 0, 255);
            max_r = Clamp(max_r, 0, 255);
            max_g = Clamp(max_g, 0, 255);
            max_b = Clamp(max_b, 0, 255);

            int matchingCnt = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var color = colorInfo[i, j];

                    /// 매칭하는 컬러로 판정 . 
                    if ((color.R >= min_r && color.R <= max_r)
                        && (color.G >= min_g && color.G <= max_g)
                        && (color.B >= min_b && color.B <= max_b))
                    {
                        matchingCnt++;

                        float normalizedX = i / (float)width;
                        float normalizedY = j / (float)height;

                        resultNormalizedPos.Add(new PointFloat(normalizedX, normalizedY));
                    }
                }
            }

            return matchingCnt;
        }

        /// <summary>
        /// 두 파라미터 전부 0~1 정규화된 값이어야함 .
        /// </summary>
        public float CalculateSimilarityNormalized(float sour, float dest)
        {
            return 1 - Math.Abs(dest - sour) / 1;
        }

        public float CalculateSimilarityNormalized_Color(Color sour, Color dest)
        {
            float r = CalculateSimilarityNormalized(sour.R / (float)255, dest.R / (float)255);
            float g = CalculateSimilarityNormalized(sour.G / (float)255, dest.G / (float)255);
            float b = CalculateSimilarityNormalized(sour.B / (float)255, dest.B / (float)255);
            return r * g * b;
        }

        /// <summary>
        /// source, dest 의 유사성을 0~1 값으로 리턴.
        /// </summary>
        public float GetSimilarityNormalizedPos(List<PointFloat> source, List<PointFloat> dest)
        {
            float resultSimilarity = 1f;

            for (int i = 0; i < source.Count; i++)
            {
                PointFloat s = source[i];

                /// 초기는 최대값. 
                /// => 가장 멀리 있다 가정 
                float nearestDistX = 1f;
                float nearestDistY = 1f;
                float nearestX = 0f;
                float nearestY = 0f;

                for (int j = 0; j < dest.Count; j++)
                {
                    PointFloat d = dest[j];

                    float abs_x = Math.Abs(s.x - d.x);
                    float abs_y = Math.Abs(s.y - d.y);

                    if (abs_x < nearestDistX)
                    {
                        nearestDistX = abs_x;
                        nearestX = d.x;
                    }
                    if (abs_y < nearestDistY)
                    {
                        nearestDistY = abs_y;
                        nearestY = d.y;
                    }
                }

                /// nearestX/Y 가 source point 에 가까우면 가까울수록 1 
                float similarity = (CalculateSimilarityNormalized(s.x, nearestX)) * (CalculateSimilarityNormalized(s.y, nearestY));

                resultSimilarity *= similarity;
            }

            return resultSimilarity;
        }


        /// <summary>
        /// 이미 color Key 의 position 이 세팅된 <paramref name="normalizedSourceColorBuffer"/> 를 
        /// 체킹 대상인 <paramref name="destColor"/> 의 전체 색상에 대해서 
        /// 유사값 0~1 을 계산함. 
        /// </summary>
        /// <param name="normalizedSourceColorBuffer"> 체킹할 원본의 색상 0~1 정규화된 위치 값 </param>
        /// <param name="destColor"> 체킹 대상 전체 색상 가로/세로 2차원 배열 </param>
        /// <param name="destWid"> 대상 색상 배열의 가로 픽셀 개수 Width </param>
        /// <param name="destHei"> 대상 색상 배열의 세로 픽셀 개수 Height </param>
        /// <param name="colorKey"> 유사성 검사 기준 색상 </param>
        /// <returns></returns>
        public float GetSimilarityToDestColor(List<PointFloat> normalizedSourceColorBuffer, Color[,] destColor, int destWid, int destHei, Color colorKey)
        {
            float resultSimilarity = 0f;
            float oneScore = 1 / (float)normalizedSourceColorBuffer.Count;

            for (int i = 0; i < normalizedSourceColorBuffer.Count; i++)
            {
                PointFloat s = normalizedSourceColorBuffer[i];

                int xIdx = (int)(destWid * s.x);
                int yIdx = (int)(destHei * s.y);

                if (xIdx >= destWid)
                    xIdx = destWid - 1;
                if (xIdx < 0)
                    xIdx = 0;

                if (yIdx >= destHei)
                    yIdx = destHei - 1;
                if (yIdx < 0)
                    yIdx = 0;

                Color c = destColor[xIdx, yIdx];

                /// nearestX/Y 가 source point 에 가까우면 가까울수록 1 
                float similarity = CalculateSimilarityNormalized_Color(colorKey, c); // (CalculateSimilarityNormalized(s.x, nearestX)) * (CalculateSimilarityNormalized(s.y, nearestY));

                resultSimilarity += oneScore * similarity;
            }

            return resultSimilarity;
        }

        /// <summary>
        /// 색상 매칭 여부 체크 함수
        /// </summary>
        /// <param name="source"> 체크 원본 색상 데이터 </param>
        /// <param name="destColorInfo"> 체크 타겟 색상 가로/세로 데이터 배열 </param>
        /// <param name="destWidth"> 체크 타겟 배열 가로 </param>
        /// <param name="destHeight"> 체크 타겟 배열 세로 </param>
        /// <param name="acceptCountRange"> 매칭 카운트 비교 체크시 허용 범위 (Source 의 매칭 개수가 더 많을수 있는 상황에 사용가능) </param>
        /// <param name="similarityThreshold"></param>
        /// <param name="resultSimilarity"></param>
        /// <returns></returns>
        public bool IsTarget(
            DataContainer.ColorData source
            , Color[,] destColorInfo
            , int destWidth
            , int destHeight
            , int acceptCountRange
            , float similarityThreshold
            , out float resultSimilarity)
        {
            resultSimilarity = -1f;

            List<PointFloat> matchingNormalizedPos;
            int destMatchingCount = GetMatchingColorInfo(destColorInfo, destWidth, destHeight, source.colorKey, source.acceptRange, out matchingNormalizedPos);

            /// Source 를 Dest 에 빗대어 봤을때 
            /// 매칭되는 픽셀의 개수가 Source 의 
            /// 오리지널 매칭 카운트보다 작다면 
            /// 바로 빠꾸 . 
            if (source.colorKeyMatchingCount > destMatchingCount + acceptCountRange)
            {
                //   return false;
            }
            //if ((source.colorKeyMatchingCount >= min_destCnt
            //    && source.colorKeyMatchingCount <= max_destCnt) == false)
            //{
            //    return false;
            //}

            /// 두 normalize pos 의 similiarty 측정 
            // float similarity = GetSimilarityNormalizedPos(source.matchingColorNormalizedPos, matchingNormalizedPos);
            float similarity = GetSimilarityToDestColor(source.matchingColorNormalizedPos, destColorInfo, destWidth, destHeight, source.colorKey);

            resultSimilarity = similarity;

            if (similarity < similarityThreshold)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 스크린상에 Color 정보들을 가져옴 
        /// </summary>
        public Color[,] GetScreenColors(Rectangle area)
        {
            var colors = new Color[area.Width, area.Height];

            using (var bm = new Bitmap(area.Width, area.Height))
            {
                using (var gp = Graphics.FromImage(bm))
                {
                    /// 여기서 비트맵에 카피됨. 
                    gp.CopyFromScreen(area.X, area.Y, 0, 0, bm.Size);

                    for (int i = 0; i < area.Width; i++)
                    {
                        for (int j = 0; j < area.Height; j++)
                        {
                            colors[i, j] = bm.GetPixel(i, j);
                        }
                    }
                }
            }

            return colors;
        }

        //    public bool 
    }
}
