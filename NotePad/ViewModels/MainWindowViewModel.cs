using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Avalonia.Controls.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using NotePad.Models;
using NotePad.Serv;
namespace NotePad.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public UserControl1 List { get; set; }
        public UserControl2 Dirs { get; set; }
        public ObservableCollection<FileModel> QWE = new ObservableCollection<FileModel>();
        public ObservableCollection<DirModel> ZXC = new ObservableCollection<DirModel>();
        ViewModelBase content;
        public static string fullPath = System.IO.Path.GetFullPath(@"../../../");
        public string[] files = Directory.GetFiles(fullPath);
        public string[] Dir = Directory.GetDirectories(fullPath);
        public string ErrorFlag;
        public ViewModelBase Content
        {
            get => content;
            private set => SetProperty(ref content, value);
        }
        public void GoTop()
        {
            QWE.Clear();
            ZXC.Clear();
            int qwe=0;
            fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(fullPath, @"..\"));
            files = Directory.GetFiles(fullPath);
            Dir = Directory.GetDirectories(fullPath);
            for (int i = 0; i < files.Count(); i++)
            {
                QWE.Add(new FileModel { PATH = files[i] });
            }
            for (int i = 0; i < Dir.Count(); i++)
            {
                ZXC.Add(new DirModel { PATH = Dir[i] });
            }
            Content = new UserControl1(QWE,ZXC);
        }

        public void ReadFromFile()
        {
            if (SelectedFile == null) { }
            else { 
                string path = SelectedFile.PATH;
                using (StreamReader reader = new StreamReader(path))
                {
                    string text = reader.ReadToEnd();
                    Text = text;
                }
            }
            Content = new UserControl2(Text);
        }
        public void WriteToFile()
        {
            using (StreamWriter writer = new StreamWriter(SelectedFile.PATH, false))
            {
                 writer.WriteLine(Text);
            }
            Content = new UserControl2("");
        }

        public int GoDown()
        {
            QWE.Clear();
            ZXC.Clear();
            int qwe = 0;
            if(SelectedDir == null)
            {
                QWE.Add(new FileModel { PATH = "Не выбрана папка, нажмите ../" });
                Content = new UserControl1(QWE, ZXC);
            }
            else { 
            fullPath = System.IO.Path.GetFullPath(SelectedDir.PATH);
            files = Directory.GetFiles(fullPath);
            Dir = Directory.GetDirectories(fullPath);
            for(int i = 0; i < files.Count(); i++)
                {
                    QWE.Add(new FileModel { PATH = files[i] });
                }
                for (int i = 0; i < Dir.Count(); i++)
                {
                    ZXC.Add(new DirModel { PATH = Dir[i] });
                }
                Content = new UserControl1(QWE,ZXC);
            }
            return 1;
        }
        string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        DirModel selectedDir;
        public DirModel SelectedDir
        {
            get => selectedDir;
            set => SetProperty(ref selectedDir, value);
        }
        FileModel selectedFile;
        public FileModel SelectedFile
        {
            
            get => selectedFile;
            set => SetProperty(ref selectedFile, value);
        }




        public MainWindowViewModel(Database db)
        {
            for (int i = 0; i < files.Count(); i++)
            {
                QWE.Add(new FileModel { PATH = files[i] });
            }
            for (int i = 0; i < Dir.Count(); i++)
            {
                ZXC.Add(new DirModel { PATH = Dir[i] }) ;
            }
            Content = Dirs = new UserControl2("");
            List = new UserControl1(QWE,ZXC);
        }
        public void AddItem()
        {
            Content = new UserControl1(QWE,ZXC);
        }
        public void AddItem3()
        {
            Content = new UserControl3(QWE, ZXC);
        }
    }
}
