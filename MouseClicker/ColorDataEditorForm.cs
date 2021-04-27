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

        List<DataContainer.ColorData> DataBuffer = new List<DataContainer.ColorData>();
        string curLoadedFullPath;

        public string CachePath
        {
            get
            {
                var cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\MouseClicker";

                if (Directory.Exists(cacheDir) == false)
                {
                    Directory.CreateDirectory(cacheDir);
                }

                return cacheDir;
            }
        }

        private void ColorDataEditorForm_Load(object sender, EventArgs e)
        {
            var cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\MouseClicker";

            if (Directory.Exists(cacheDir) == false)
            {
                Directory.CreateDirectory(cacheDir);
            }

            txtSave.Enabled = false;
            curLoadedFullPath = "";
        }

        /// <summary>
        /// 로드하기 
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var openFileDialog1 = new OpenFileDialog())
            {
                /// 키자마자 어떤 path 를 열것인지 설정 
                openFileDialog1.InitialDirectory = CachePath;

                openFileDialog1.RestoreDirectory = true;

                /// txt File, all file 이렇게 보이게 설정 .
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                /// 바로 txt 보이게 설정 
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Title = "색상 파일 선택해주시오.";

                var result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    /// Full Path 전부 다 담김 ㅇㅇ 
                    var fullPath = openFileDialog1.FileName;

                    if (fullPath.EndsWith(".txt"))
                    {
                        using (var sr = new StreamReader(fullPath))
                        {
                            if (sr != null)
                            {
                                OnFileLoad(sr, fullPath);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(".txt 텍스트 파일만 가능");
                    }
                }
            }
        }

        /// <summary>
        /// 저장하기
        /// </summary>
        private void txtSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(curLoadedFullPath) == false)
            {
                using (var sr = new StreamWriter(curLoadedFullPath))
                {
                    if (sr != null)
                    {
                        OnFileSave(sr, curLoadedFullPath);
                    }
                }
            }
            else
            {
                using (var saveFileDialog1 = new SaveFileDialog())
                {
                    /// 키자마자 어떤 path 를 열것인지 설정 
                    saveFileDialog1.InitialDirectory = CachePath;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.Title = "저장할 곳을 선택해주시오.";
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 0;
                    //   saveFileDialog1.CheckFileExists = true;
                    saveFileDialog1.CheckPathExists = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        /// Full Path 전부 다 담김 ㅇㅇ 
                        var fullPath = saveFileDialog1.FileName;

                        if (fullPath.EndsWith(".txt"))
                        {
                            using (var sr = new StreamWriter(fullPath))
                            {
                                if (sr != null)
                                {
                                    OnFileSave(sr, fullPath);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(".txt 텍스트 파일만 가능");
                        }
                    }
                }
            }
        }

        void OnFileLoad(StreamReader sr, string path)
        {
            string str = sr.ReadToEnd();

            var data = JsonConvert.DeserializeObject<List<DataContainer.ColorData>>(str);

            if (data != null)
            {
                this.DataBuffer = data;

                if (DataBuffer == null)
                    DataBuffer = new List<DataContainer.ColorData>();

                curLoadedFullPath = path;
                txtLoadedFilePath.Text = path;
                txtSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("파싱 실패");
            }
        }

        void OnFileSave(StreamWriter sr, string path)
        {
            string output = JsonConvert.SerializeObject(DataBuffer);
            sr.Write(output);

            curLoadedFullPath = path;
            txtLoadedFilePath.Text = path;
            txtSave.Enabled = false;
        }

        private void btnOpenCacheFolder_Click(object sender, EventArgs e)
        {
            Process.Start(CachePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataBuffer == null || DataBuffer.Count == 0)
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
                    string resultStr = ScreenColorStringExtractHelper.Instance.IsTarget(this.DataBuffer[0], form.Output_ColorInfo, form.Output_Width, form.Output_Height, 4, 0.3f, out similiarty) ? "매칭" : "비매칭";

                    MessageBox.Show($"{resultStr} , similarity : {(double)similiarty}");
                }
            }
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            using (var form = new ScreenColorInfoExtractor())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < DataBuffer.Count; i++)
                    {
                        if (DataBuffer[i].str == form.OutputData.str)
                        {
                            using (var prompt = new PromptForm())
                            {
                                prompt.Set($"경고 : 데이터 {DataBuffer[i].str} 가 이미 존재합니다. 덮어씌우겠습니까?");

                                var prompt_result = prompt.ShowDialog();
                                if (prompt_result != DialogResult.OK)
                                {
                                    return;
                                }
                                else
                                {
                                    DataBuffer[i] = form.OutputData;
                                    txtSave.Enabled = true;
                                    return;
                                }
                            }
                        }
                    }

                    DataBuffer.Add(form.OutputData);
                    txtSave.Enabled = true;
                }
            }
        }

        private void btnNew_click(object sender, EventArgs e)
        {
            bool reset = true;

            if (txtSave.Enabled)
            {
                using (var prompt = new PromptForm())
                {
                    prompt.Set($"작업중인 데이터가 있습니다. 새 작업으로 진행하시겠습니까 ?");

                    var prompt_result = prompt.ShowDialog();
                    if (prompt_result != DialogResult.OK)
                    {
                        reset = false;
                    }
                }
            }

            if (reset)
            {
                DataBuffer.Clear();
                this.curLoadedFullPath = "";
                txtLoadedFilePath.Text = curLoadedFullPath;
                txtSave.Enabled = false;
            }
        }
    }
}
