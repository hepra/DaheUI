using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UIFrameworkCore.Settings;
using WK.Libraries.BetterFolderBrowserNS;

namespace UIFrameworkCore.Helper
{
    public class FileHelper
    {
        static public string OpenFileDialog(bool 多选)
        {
            OpenFileDialog openData = new OpenFileDialog();
            openData.Multiselect = true;
            openData.Filter = "*|*";
            openData.ShowDialog();
            if (openData.FileName != "")
            {
                return openData.FileName;
            }
            else
            {
                return "";
            }
        }
        static public string[] OpenFileDialog()
        {
            OpenFileDialog openData = new OpenFileDialog();
            openData.Multiselect = true;
            openData.Filter = "*|*";
            openData.ShowDialog();
            return openData.FileNames;
        }
        static public string[] OpenDirectory( bool 多选)
        {
            string directoryName = System.AppDomain.CurrentDomain.BaseDirectory + "资源文件";
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            var openFolder = new BetterFolderBrowser();
            openFolder.Title = "选择文件夹(可多选)";
            if (SettingManager.GetSettingSingleton().LastestImportPath!= "")
            {
                openFolder.RootFolder = SettingManager.GetSettingSingleton().LastestImportPath;
            }


            // Allow multi-selection of folders.
            openFolder.Multiselect = 多选;

            if (openFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] ALL = openFolder.SelectedPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                string rootPath = "";
                for (int i = 0; i < ALL.Length - 1; i++)
                {
                    rootPath += ALL[i] + "\\";
                }
                SettingManager.GetSettingSingleton().LastestImportPath = rootPath;

                string[] selectedFolders = openFolder.SelectedFolders;
                return selectedFolders;
            }
            else
            {
                return null;
            }
        }

        static public void SaveFile_Create(string file_name, string data)
        {
            using (FileStream fsWrite = new FileStream(file_name, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var buffer = Encoding.UTF8.GetBytes(data);
                fsWrite.Write(buffer, 0, buffer.Length);
            }
        }

        static public string readFile(string fileName, Encoding textEncodeing = null)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StringBuilder sb = new StringBuilder();
            StreamReader m_streamReader = new StreamReader(fs, textEncodeing ?? Encoding.UTF8);//中文乱码加上System.Text.Encoding.UTF8,或则 System.Text.Encoding.GetEncoding("GB2312")
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容


            string strLine = m_streamReader.ReadLine();
            while (strLine != null)
            {
                sb.AppendLine(strLine);
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();
            return sb.ToString();
        }
        static public long getLength(string file_path)
        {
            using (FileStream fsRead = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                try
                {
                    long len = fsRead.Seek(0, SeekOrigin.End);
                    fsRead.Seek(0, SeekOrigin.Begin);
                    return len;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    fsRead.Close();
                }
            }
            return 0;
        }
        /// <summary>
        /// Show SaveFileDialog 方式
        /// </summary>
        /// <param name="Event"></param>
        static public void SaveFile(CancelEventHandler Event)
        {
            SaveFileDialog openfile = new SaveFileDialog();
            openfile.Title = "选择保存的文件路径";
            string[] buffer_path = System.AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.RemoveEmptyEntries);
            openfile.InitialDirectory = buffer_path[0];
            openfile.Filter = "Excel文件|*.xlsx |TXT文件|*.txt";
            //添加保存按钮触发事件
            openfile.FileOk += Event;

            openfile.ShowDialog();
        }
        static public void SaveFile(string file_name, FileMode mode, FileAccess access, string data, int size)
        {
            using (FileStream fsWrite = new FileStream(file_name, mode, access, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[size + 10];
                buffer = Encoding.UTF8.GetBytes(data + "\r\n");
                fsWrite.Write(buffer, 0, buffer.Length);
            }
        }
        static public void SaveFile_Append(string file_name, string data)
        {
            using (FileStream fsWrite = new FileStream(file_name, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                try
                {
                    fsWrite.Write(buffer, 0, buffer.Length);
                }
                catch (Exception e)
                {
                    MessageBox.Show("写入文件出错:" + e.Message);
                }
                finally
                {
                    fsWrite.Flush();
                    fsWrite.Close();
                }
            }
        }

        static public void SaveFile_Create(string file_name, string data, int size)
        {
            using (FileStream fsWrite = new FileStream(file_name, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[size + 100];
                buffer = Encoding.UTF8.GetBytes(data);
                fsWrite.Write(buffer, 0, buffer.Length);
            }
        }

        static public string OpenFileImage_getPath(string initial_directory)
        {

            OpenFileDialog openData = new OpenFileDialog();
            openData.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
            openData.InitialDirectory = initial_directory;
            openData.ShowDialog();
            if (openData.FileName != "")
            {
                return openData.FileName;
            }
            else
            {
                return "";
            }
        }

        static public string OpenFileVideo_getPath(string initial_directory)
        {
            OpenFileDialog openData = new OpenFileDialog();
            openData.Filter = "视频|*.mp4;*.avi;*.flv;*.wmv;*.mov;*.mkv;*.rmvb;*.rm;*.mpeg;*.mpg";
            openData.InitialDirectory = initial_directory;
            openData.ShowDialog();
            if (openData.FileName != "")
            {
                return openData.FileName;
            }
            else
            {
                return "";
            }
        }


        static public List<string> readFileToList(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<string> list = new List<string>();
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.UTF8);//中文乱码加上System.Text.Encoding.UTF8,或则 System.Text.Encoding.GetEncoding("GB2312")
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容


            string strLine = m_streamReader.ReadLine();
            while (strLine != null)
            {
                list.Add(strLine);
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();
            return list;

        }
        static public void Delete(string path)
        {
            File.Delete(path);
        }

        #region 生产
        static public void Appand生产Info(int 合格数, int 废品, string 合格率, string Level = "Info")
        {
            string BackName = "Logs\\生产记录Back.txt";
            string FileName = "Logs\\生产记录.txt";
            FileInfo fi = new FileInfo(FileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"###{Level}-{System.DateTime.Now.ToString("F")}###");
            sb.AppendLine("#" + $"{合格数}-{废品}-{合格率}-{(合格数 + 废品)}" + "#");
            sb.AppendLine("###END###");
            SaveFile_Append(fi.FullName, sb.ToString());
            if (fi.Length > 1024 * 256)
            {
                if (File.Exists(BackName))
                {
                    File.Delete(BackName);
                }
                fi.CopyTo(BackName);
                fi.Delete();
            }
        }

        #endregion

        #region 操作
        static public void Appand操作日志Info(string info, string Level = "Info")
        {
            string BackName = "Logs\\操作日志Back.txt";
            string FileName = "Logs\\操作日志.txt";
          
            FileInfo fi = new FileInfo(FileName);
           
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"###{Level}-{System.DateTime.Now.ToString("F")}###");
            sb.AppendLine("#" + $"{info}" + "#");
            sb.AppendLine("###END###");
            SaveFile_Append(fi.FullName, sb.ToString());
            if (fi.Length > 1024 * 256)
            {
                if (File.Exists(BackName))
                {
                    File.Delete(BackName);
                }
                fi.CopyTo(BackName);
                fi.Delete();
            }
        }


        #endregion

        #region 系统
        static public void Appand系统日志Info(string info, string Level = "Info")
        {
            string BackName = "Logs\\系统日志Back.txt";
            string FileName = "Logs\\系统日志.txt";
            FileInfo fi = new FileInfo(FileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"###{Level}-{System.DateTime.Now.ToString("F")}###");
            sb.AppendLine("#" + $"{info}" + "#");
            sb.AppendLine("###END###");
            SaveFile_Append(fi.FullName, sb.ToString());

            if (fi.Length > 1024 * 256)
            {
                if (File.Exists(BackName))
                {
                    File.Delete(BackName);
                }
                fi.CopyTo(BackName);
                fi.Delete();
            }

        }

        #endregion



    }
}
