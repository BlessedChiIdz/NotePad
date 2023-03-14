using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Avalonia.Controls.Shapes;
using DynamicData;
using NotePad.Models;
using NotePad.Serv;
namespace NotePad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public UserControl1 List { get; set; }
        public UserControl2 Dirs { get; set; }
        public ObservableCollection<fileModel> QWE = new ObservableCollection<fileModel>();
        ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            private set => SetProperty(ref content, value);
        }
        public void GoTop()
        {
            QWE.Clear();
            int qwe=0;
            fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(fullPath, @"..\"));
            files = Directory.GetFiles(fullPath);
            Dir = Directory.GetDirectories(fullPath);
            for (int i = 0; i < files.Count(); i++)
            {
                QWE.Add(new fileModel { PATH = files[i]});
            }
            if (QWE.Count() < Dir.Count())
            {
                 qwe = Dir.Count() - QWE.Count();
            }
            for(int i = 0; i < qwe; i++)
            {
                QWE.Add(new fileModel { });
            }
            for (int i = 0; i < Dir.Count(); i++)
            {
                
                QWE[i].DIR = Dir[i];
            }
            Content = new UserControl1(QWE);
        }

        public void GoDown()
        {
            QWE.Clear();
            int qwe = 0;
            
            if(SelectedItem.DIR == null) { }
            else { 
            fullPath = System.IO.Path.GetFullPath(SelectedItem.DIR);
            files = Directory.GetFiles(fullPath);
            Dir = Directory.GetDirectories(fullPath);
            for (int i = 0; i < files.Count(); i++)
            {
                QWE.Add(new fileModel { PATH = files[i] });
            }
            if (QWE.Count() < Dir.Count())
            {
                qwe = Dir.Count() - QWE.Count();
            }
            for (int i = 0; i < qwe; i++)
            {
                QWE.Add(new fileModel { });
            }
            for (int i = 0; i < Dir.Count(); i++)
            {

                QWE[i].DIR = Dir[i];
            }
            Content = new UserControl1(QWE);
            }
        }
        fileModel selectedItem;
        string QWEpath;
        public fileModel SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }
        

        public static string fullPath = System.IO.Path.GetFullPath(@"../../../");
        public string[] files = Directory.GetFiles(fullPath);
        public string[] Dir = Directory.GetDirectories(fullPath);

        public string PATH { get ; set; }
        public string FILES { get; set; }
        public string DIRS { get; set; }


        public MainWindowViewModel(Database db)
        {
            for (int i = 0; i < files.Count(); i++)
            {
                QWE.Add(new fileModel { PATH =  files[i],DIR = Dir[i]  });
            }
            Content = Dirs = new UserControl2();
            List = new UserControl1(QWE);
        }
        public void AddItem()
        {
            Content = new UserControl1(QWE);
        }
    }
}
