using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MouseClicker
{
    /// <summary>
    /// 텍스트, 색상값 매칭 데이터 전용 편집용 Form 
    /// </summary>
    public partial class ColorDataEditorForm : Form
    {
        public ColorDataEditorForm()
        {
            InitializeComponent();
        }

        private void ColorDataEditorForm_Load(object sender, EventArgs e)
        {
            RefreshListBoxData();
            UpdateUI();
        }

        void RefreshListBoxData()
        {
            listBox_data.Items.Clear();

            foreach (var data in DataContainer.ScreenColorMatchingDataBuffer)
            {
                listBox_data.Items.Add(data.Key);
            }
        }

        void UpdateUI()
        {
            btnModify.Enabled = listBox_data.SelectedIndex != -1;
            btnRemove.Enabled = listBox_data.SelectedIndex != -1;
            btnClear.Enabled = DataContainer.ScreenColorMatchingDataBuffer.Count > 0;
            btnSave.Enabled = DataContainer.IsScreenColorDataBufferDirty;
        }

        /// <summary>
        /// 로드하기 
        /// </summary>
        //private void btnLoad_Click(object sender, EventArgs e)
        //{
        //    using (var openFileDialog1 = new OpenFileDialog())
        //    {
        //        /// 키자마자 어떤 path 를 열것인지 설정 
        //        openFileDialog1.InitialDirectory = CachePath;

        //        openFileDialog1.RestoreDirectory = true;

        //        /// txt File, all file 이렇게 보이게 설정 .
        //        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        //        /// 바로 txt 보이게 설정 
        //        openFileDialog1.FilterIndex = 0;
        //        openFileDialog1.DefaultExt = "txt";
        //        openFileDialog1.Title = "색상 파일 선택해주시오.";

        //        var result = openFileDialog1.ShowDialog();
        //        if (result == DialogResult.OK)
        //        {
        //            /// Full Path 전부 다 담김 ㅇㅇ 
        //            var fullPath = openFileDialog1.FileName;

        //            if (fullPath.EndsWith(".txt"))
        //            {
        //                using (var sr = new StreamReader(fullPath))
        //                {
        //                    if (sr != null)
        //                    {
        //                        OnFileLoad(sr, fullPath);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show(".txt 텍스트 파일만 가능");
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 저장하기
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataContainer.Instance.SaveScreenColorData();
            UpdateUI();

            //if (string.IsNullOrEmpty(curLoadedFullPath) == false)
            //{
            //    using (var sr = new StreamWriter(curLoadedFullPath))
            //    {
            //        if (sr != null)
            //        {
            //            OnFileSave(sr, curLoadedFullPath);
            //        }
            //    }
            //}
            //else
            //{
            //    using (var saveFileDialog1 = new SaveFileDialog())
            //    {
            //        /// 키자마자 어떤 path 를 열것인지 설정 
            //        saveFileDialog1.InitialDirectory = CachePath;
            //        saveFileDialog1.RestoreDirectory = true;
            //        saveFileDialog1.Title = "저장할 곳을 선택해주시오.";
            //        saveFileDialog1.DefaultExt = "txt";
            //        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //        saveFileDialog1.FilterIndex = 0;
            //        //   saveFileDialog1.CheckFileExists = true;
            //        saveFileDialog1.CheckPathExists = true;

            //        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //        {
            //            /// Full Path 전부 다 담김 ㅇㅇ 
            //            var fullPath = saveFileDialog1.FileName;

            //            if (fullPath.EndsWith(".txt"))
            //            {
            //                using (var sr = new StreamWriter(fullPath))
            //                {
            //                    if (sr != null)
            //                    {
            //                        OnFileSave(sr, fullPath);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(".txt 텍스트 파일만 가능");
            //            }
            //        }
            //    }
            //}
        }

        //void OnFileLoad(StreamReader sr, string path)
        //{
        //    string str = sr.ReadToEnd();

        //    var data = JsonConvert.DeserializeObject<List<DataContainer.ColorData>>(str);

        //    if (data != null)
        //    {
        //        this.DataBuffer = data;

        //        if (DataBuffer == null)
        //            DataBuffer = new List<DataContainer.ColorData>();

        //        curLoadedFullPath = path;
        //        txtLoadedFilePath.Text = path;
        //        btnSave.Enabled = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("파싱 실패");
        //    }
        //}

        private void btnOpenCacheFolder_Click(object sender, EventArgs e)
        {
            Process.Start(DataContainer.Instance.CachePath);
        }

        /// <summary>
        /// 비교 테스트 클릭 
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            var dataBuffer = DataContainer.ScreenColorMatchingDataBuffer;

            if (dataBuffer == null || dataBuffer.Count == 0)
            {
                MessageBox.Show("Source 데이터가없음. 로드 또는 생성하삼");
                return;
            }

            using (var form = new SelectArea())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    float similiarty;
                    string resultStr = ScreenColorHelper.Instance.IsTarget(dataBuffer.First().Value, form.Output_ColorInfo, form.Output_Width, form.Output_Height, 4, 0.3f, out similiarty) ? "매칭" : "비매칭";

                    MessageBox.Show($"{resultStr} , similarity : {(double)similiarty}");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenColorExtractor(null);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataContainer.ColorData selectedData = listBox_data.SelectedIndex == -1 ? null : DataContainer.Instance.GetScreenColorDataBufferByIndex(listBox_data.SelectedIndex);
            OpenColorExtractor(selectedData);
        }

        void OpenColorExtractor(DataContainer.ColorData firstData)
        {
            var dataBuffer = DataContainer.ScreenColorMatchingDataBuffer;

            using (var form = new ScreenColorInfoExtractor(firstData))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    /// 이 시점에서는 일단 무조건 set 은 하는데 , 
                    /// 덮어쓸지 안덮어쓸지 여부체크해서 안덮어쓰면 그냥 
                    /// => 취소 
                    bool set = true;
                    bool addNew = true;

                    foreach (var data in dataBuffer)
                    {
                        if (data.Value.key == form.OutputData.key)
                        {
                            addNew = false;

                            using (var prompt = new PromptForm())
                            {
                                prompt.Set($"경고 : 데이터 {data.Value.key} 가 이미 존재합니다. 덮어씌우겠습니까?");
                                prompt.StartPosition = FormStartPosition.CenterScreen;

                                var prompt_result = prompt.ShowDialog();
                                if (prompt_result != DialogResult.OK)
                                {
                                    set = false;
                                    break;
                                }
                            }
                        }
                    }

                    /// 데이터 세팅. 
                    if (set)
                    {
                        int index = DataContainer.Instance.SetData_ColorCompare(form.OutputData.key, form.OutputData);

                        if (index == -1)
                        {
                            MessageBox.Show("인덱스에 문제가있다. 타겟 key 를 못찾은듯함 . (ElementAt)");
                        }
                        else if (index > listBox_data.Items.Count)
                        {
                            index = listBox_data.Items.Count;
                        }

                        if (addNew)
                        {
                            listBox_data.Items.Insert(index, form.OutputData.key);
                        }

                        UpdateUI();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (var prompt = new PromptForm())
            {
                prompt.Set($"데이터 초기화 할 것인가 ?");
                prompt.StartPosition = FormStartPosition.CenterScreen;

                var prompt_result = prompt.ShowDialog();
                if (prompt_result == DialogResult.OK)
                {
                    DataContainer.Instance.ClearScreenDataBuffer();
                    RefreshListBoxData();
                    UpdateUI();
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listBox_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox_data.SelectedIndex == -1)
            {
                MessageBox.Show("에러. (cannot be clicked when the index is -1 which means non click state");
                return;
            }

            var key = listBox_data.Items[listBox_data.SelectedIndex];
            DataContainer.Instance.RemoveScreenColorData((string)key);
            RefreshListBoxData();
            UpdateUI();
        }
    }
}
