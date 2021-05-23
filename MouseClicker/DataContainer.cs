using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static MouseClicker.Form1;
using Newtonsoft.Json;

namespace MouseClicker
{
    public class DataContainer
    {
        [Serializable]
        public class ActionGroup
        {
            public string key;
            public List<SingleAction> actions;

            public ActionGroup(string key, List<SingleAction> actions)
            {
                this.key = key;
                this.actions = actions;
            }
        }

        /// <summary>
        /// IO 용 색상 데이터 
        /// </summary>
        [Serializable]
        public class ColorData
        {
            public string key;

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

            public void CopyTo(ColorData outputData)
            {
                outputData.key = key;
                outputData.colorKey = colorKey;
                outputData.discardKey = discardKey;
                outputData.acceptRange = acceptRange;
                outputData.width = width;
                outputData.height = height;
                outputData.matchingColorNormalizedPos = new List<PointFloat>(matchingColorNormalizedPos.Count);
                for (int i = 0; i < matchingColorNormalizedPos.Count; i++)
                {
                    outputData.matchingColorNormalizedPos.Add(new PointFloat(matchingColorNormalizedPos[i].x, matchingColorNormalizedPos[i].y));
                }
                outputData.colorKeyMatchingCount = colorKeyMatchingCount;

                outputData.colorInfo = new Color[width, height];
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        outputData.colorInfo[i, j] = colorInfo[i, j];
                    }
                }
            }
        }

        [Serializable]
        public class ScreenTargetColorCheckData
        {
            /// <summary>
            /// 한개의 area 
            /// </summary>
            [Serializable]
            public class Area
            {
                public Color[,] colors;
                public int width;
                public int height;
            }

            public string key;
            public List<Area> areaList = new List<Area>();

            public void CopyTo(ScreenTargetColorCheckData dest)
            {
                dest.areaList.Clear();

                dest.key = key;
                for (int i = 0; i < areaList.Count; i++)
                {
                    var area = new Area();
                    area.width = areaList[i].width;
                    area.height = areaList[i].height;

                    GlobalUtil.CopyColor(areaList[i].colors, areaList[i].width, areaList[i].height, ref area.colors);
                    dest.areaList.Add(area);
                }
            }
        }

        static DataContainer instance;
        public static DataContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataContainer();
                }
                return instance;
            }
        }

        #region ActionGroup Data 관련
        public readonly static string CurActionGroupFileName = "ActionGroup.txt";
        public static string ActionGroupFilePath;

        public static Dictionary<string, ActionGroup> ActionGroupDataBuffer = new Dictionary<string, ActionGroup>();
        public static bool IsActionGroupDataBufferDirty { get; private set; }
        #endregion

        #region Screen Color Matching 데이터 관련 
        public readonly static string CurScreenColorMatchingFileName = "ScreenColorMatchingData.txt";
        public static string ColorDataBufferFilePath;

        public static Dictionary<string, ColorData> ScreenColorMatchingDataBuffer = new Dictionary<string, ColorData>();
        public static bool IsScreenColorDataBufferDirty { get; private set; }
        #endregion

        #region Screen Target Color Check 데이터 관련 
        public readonly static string CurScreenTargetCheckColorFileName = "ScreenColorTargetAreaData.txt";
        public static string CurScreenTargetCheckColorFilePath;

        public static Dictionary<string, ScreenTargetColorCheckData> ScreenTargetCheckColorDataBuffer = new Dictionary<string, ScreenTargetColorCheckData>();
        public static bool IsScreenTargetCheckColorDataBufferDirty { get; private set; }
        #endregion

        public string CachePath { get; private set; }
        public void Initialize()
        {
            CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\MouseClicker";

            ActionGroupFilePath = Path.Combine(CachePath, CurActionGroupFileName);
            ColorDataBufferFilePath = Path.Combine(CachePath, CurScreenColorMatchingFileName);
            CurScreenTargetCheckColorFilePath = Path.Combine(CachePath, CurScreenTargetCheckColorFileName);

            if (Directory.Exists(CachePath) == false)
            {
                Directory.CreateDirectory(CachePath);
            }

            if (File.Exists(ActionGroupFilePath) == false)
            {
                File.CreateText(ActionGroupFilePath);
            }

            if (File.Exists(ColorDataBufferFilePath) == false)
            {
                File.CreateText(ColorDataBufferFilePath);
            }

            if (File.Exists(CurScreenTargetCheckColorFilePath) == false)
            {
                File.CreateText(CurScreenTargetCheckColorFilePath);
            }

            ActionGroupDataBuffer.Clear();
            ScreenColorMatchingDataBuffer.Clear();
            ScreenTargetCheckColorDataBuffer.Clear();

            if (File.Exists(ActionGroupFilePath))
            {
                using (var sr = new StreamReader(ActionGroupFilePath))
                {
                    string str = sr.ReadToEnd();

                    var data = JsonConvert.DeserializeObject<List<ActionGroup>>(str);

                    if (data != null)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            SetData_ActionGroup(data[i].key, data[i].actions);
                        }
                    }
                }
            }

            /// 파일읽어서 screenColor 데이터 파싱해서 캐싱 
            if (File.Exists(ColorDataBufferFilePath))
            {
                using (var sr = new StreamReader(ColorDataBufferFilePath))
                {
                    string str = sr.ReadToEnd();

                    var data = JsonConvert.DeserializeObject<List<ColorData>>(str);

                    if (data != null)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            SetData_ColorCompare(data[i].key, data[i]);
                        }
                    }
                }
            }

            /// 파일 읽은후 데이터 파싱 및 캐싱
            if (File.Exists(CurScreenTargetCheckColorFilePath))
            {
                using (var sr = new StreamReader(CurScreenTargetCheckColorFilePath))
                {
                    string str = sr.ReadToEnd();

                    var data = JsonConvert.DeserializeObject<List<ScreenTargetColorCheckData>>(str);

                    if (data != null)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            SetData_TargetCheckColor(data[i].key, data[i]);
                        }
                    }
                }
            }

            IsScreenColorDataBufferDirty = false;
            IsScreenTargetCheckColorDataBufferDirty = false;
        }

        #region ====================== ActionGroup 관련 ==========================
        public void SaveActionGroupData()
        {
            using (var sr = new StreamWriter(ActionGroupFilePath))
            {
                var dataBuffer = ActionGroupDataBuffer.Values.ToList();
                string output = JsonConvert.SerializeObject(dataBuffer);
                sr.Write(output);
                IsActionGroupDataBufferDirty = false;
            }
        }

        public int SetData_ActionGroup(string key, List<SingleAction> data)
        {
            if (ActionGroupDataBuffer.ContainsKey(key) == false)
            {
                ActionGroupDataBuffer.Add(key, new ActionGroup(key, data));
            }
            else
            {
                ActionGroupDataBuffer[key] = new ActionGroup(key, data);
            }

            IsActionGroupDataBufferDirty = true;

            int index = -1;

            for (int i = 0; i < ActionGroupDataBuffer.Count; i++)
            {
                /// i 번쨰에 있는 dictionary 의 key 가 str 이랑 같은지 체크 . 같으면
                /// 해당 index 임 . 
                if (ActionGroupDataBuffer.ElementAt(i).Key == key)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void ClearActionGroupDataBuffer()
        {
            if (ActionGroupDataBuffer.Count > 0)
                IsActionGroupDataBufferDirty = true;
            ActionGroupDataBuffer.Clear();
        }

        public bool RemoveActionGroupData(string key)
        {
            bool removed = ActionGroupDataBuffer.Remove(key);
            if (removed)
                IsActionGroupDataBufferDirty = true;
            return removed;
        }

        public bool ChangeActionGroupKey(string from, string to)
        {
            if (ActionGroupDataBuffer.ContainsKey(from) == false)
                return false;

            if (ActionGroupDataBuffer.ContainsKey(to))
                return false;

            var actionData = ActionGroupDataBuffer[from].actions;
            ActionGroupDataBuffer.Remove(from);
            ActionGroupDataBuffer.Add(to, new ActionGroup(to, actionData));
            return true;
        }

        public ActionGroup GetActionGroupDataBufferByIndex(int selectedIndex)
        {
            if (selectedIndex >= ActionGroupDataBuffer.Count)
            {
                return null;
            }

            return ActionGroupDataBuffer.ElementAt(selectedIndex).Value;
        }

        public int GetActionGroupDataIndexByKey(string key)
        {
            int index = -1;

            foreach (var data in ActionGroupDataBuffer)
            {
                index++;

                if (data.Key == key)
                {
                    break;
                }
            }

            return index;
        }

        public bool IsTargetActionGroupExist(string key)
        {
            return ActionGroupDataBuffer.ContainsKey(key);
        }

        #endregion

        #region ================= Screen Color Matching 관련 ================

        public void SaveScreenColorData()
        {
            using (var sr = new StreamWriter(ColorDataBufferFilePath))
            {
                var dataBuffer = ScreenColorMatchingDataBuffer.Values.ToList();
                string output = JsonConvert.SerializeObject(dataBuffer);
                sr.Write(output);
                IsScreenColorDataBufferDirty = false;
            }
        }

        public int SetData_ColorCompare(string key, ColorData colorData)
        {
            if (ScreenColorMatchingDataBuffer.ContainsKey(key) == false)
            {
                ScreenColorMatchingDataBuffer.Add(key, colorData);
            }
            else
            {
                ScreenColorMatchingDataBuffer[key] = colorData;
            }

            IsScreenColorDataBufferDirty = true;

            int index = -1;

            for (int i = 0; i < ScreenColorMatchingDataBuffer.Count; i++)
            {
                /// i 번쨰에 있는 dictionary 의 key 가 str 이랑 같은지 체크 . 같으면
                /// 해당 index 임 . 
                if (ScreenColorMatchingDataBuffer.ElementAt(i).Key == key)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public bool IsNumberColorDataReady()
        {
            for (int i = 0; i < 10; i++)
            {
                if (ScreenColorMatchingDataBuffer.ContainsKey(i.ToString()) == false)
                {
                    return false;
                }
            }

            return true;
        }

        //public ColorData GetColorData(string key)
        //{
        //    if (ScreenColorMatchingDataBuffer.ContainsKey(key) == false)
        //    {
        //        MessageBox.Show($"데이터가 존재하지 않습니다. key : {key}");
        //        return null;
        //    }

        //    return ScreenColorMatchingDataBuffer[key];
        //}

        public ColorData GetScreenMatchingColorDataByKey(string screenColorMatchingStringKey)
        {
            if (ScreenColorMatchingDataBuffer.ContainsKey(screenColorMatchingStringKey) == false)
            {
                return null;
            }

            return ScreenColorMatchingDataBuffer[screenColorMatchingStringKey];
        }

        public void ClearScreenDataBuffer()
        {
            if (ScreenColorMatchingDataBuffer.Count > 0)
                IsScreenColorDataBufferDirty = true;
            ScreenColorMatchingDataBuffer.Clear();
        }

        public bool RemoveScreenColorData(string key)
        {
            bool removed = ScreenColorMatchingDataBuffer.Remove(key);
            if (removed)
                IsScreenColorDataBufferDirty = true;
            return removed;
        }

        public ColorData GetScreenColorDataBufferByIndex(int selectedIndex)
        {
            if (selectedIndex >= ScreenColorMatchingDataBuffer.Count)
            {
                return null;
            }

            return ScreenColorMatchingDataBuffer.ElementAt(selectedIndex).Value;
        }

        public int GetScreenColorDataIndexByKey(string key)
        {
            int index = -1;

            foreach (var data in ScreenColorMatchingDataBuffer)
            {
                index++;

                if (data.Key == key)
                {
                    break;
                }
            }

            return index;
        }
        #endregion

        #region Screen Target Check Color 관련 

        public void SaveScreenTargetCheckColorData()
        {
            using (var sr = new StreamWriter(CurScreenTargetCheckColorFileName))
            {
                var dataBuffer = ScreenTargetCheckColorDataBuffer.Values.ToList();
                string output = JsonConvert.SerializeObject(dataBuffer);
                sr.Write(output);
                IsScreenTargetCheckColorDataBufferDirty = false;
            }
        }

        public int SetData_TargetCheckColor(string key, ScreenTargetColorCheckData data)
        {
            if (ScreenTargetCheckColorDataBuffer.ContainsKey(key) == false)
            {
                ScreenTargetCheckColorDataBuffer.Add(key, data);
            }
            else
            {
                ScreenTargetCheckColorDataBuffer[key] = data;
            }

            IsScreenTargetCheckColorDataBufferDirty = true;

            int index = -1;

            for (int i = 0; i < ScreenTargetCheckColorDataBuffer.Count; i++)
            {
                if (ScreenTargetCheckColorDataBuffer.ElementAt(i).Key == key)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public ScreenTargetColorCheckData GetTargetScreenTargetCheckColorDataByKey(string key)
        {
            if (ScreenTargetCheckColorDataBuffer.ContainsKey(key) == false)
            {
                return null;
            }

            return ScreenTargetCheckColorDataBuffer[key];
        }

        public void ClearScreenTargetCheckDataBuffer()
        {
            if (ScreenTargetCheckColorDataBuffer.Count > 0)
                IsScreenTargetCheckColorDataBufferDirty = true;
            ScreenTargetCheckColorDataBuffer.Clear();
        }

        public bool RemoveScreenTargetCheckColorData(string key)
        {
            bool removed = ScreenTargetCheckColorDataBuffer.Remove(key);
            if (removed)
                IsScreenTargetCheckColorDataBufferDirty = true;
            return removed;
        }

        public ScreenTargetColorCheckData GetScreenTargetCheckColorDataBufferByIndex(int index)
        {
            if (index >= ScreenTargetCheckColorDataBuffer.Count)
            {
                return null;
            }

            return ScreenTargetCheckColorDataBuffer.ElementAt(index).Value;
        }

        public int GetScreenTargetCheckAreaCountByIndex(int index)
        {
            var data = GetScreenTargetCheckColorDataBufferByIndex(index);

            if (data == null)
                return 0;

            return data.areaList.Count;
        }

        #endregion
        /// IO API ㄱㄱ 
    }
}
