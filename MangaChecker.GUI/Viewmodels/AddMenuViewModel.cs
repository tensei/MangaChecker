﻿using System;
using System.Windows.Input;
using MangaChecker.GUI.dependencies;
using MaterialDesignThemes.Wpf;
using PropertyChanged;

namespace MangaChecker.GUI.Viewmodels {
    [ImplementPropertyChanged]
    public class AddMenuViewModel  {
        public AddMenuViewModel() {
            AddBacklogCommand = new ActionCommand(AddToBacklog);
            AddNormalCommand = new ActionCommand(NormalClick);
            AddAdvancedCommand = new ActionCommand(AdvancedClick);
        }

        public string Name { get; set; }

        public string Chapter { get; set; }

        public ICommand AddBacklogCommand { get; }
        public ICommand AddNormalCommand { get; }
        public ICommand AddAdvancedCommand { get; }
        //public ICommand AddAdvancedCommand { get; }

        private static async void NormalClick() {
            //var d = new NormalAddDialog {DataContext = new NormalAddViewModel()};
            //await DialogHost.Show(d);
        }

        private static async void AdvancedClick() {
            //var d = new AdvancedAddDialog {DataContext = new AdvancedAddViewModel()};
            //await DialogHost.Show(d);
        }

        private void AddToBacklog() {
            //if (Sqlite.GetMangaNameList("backlog").Contains(Name)) {
            //    var m = new MangaModel {
            //        Name = Name,
            //        Chapter = Chapter,
            //        Site = "backlog",
            //        RssLink = "placeholder",
            //        Date = DateTime.Now
            //    };
            //    Sqlite.UpdateManga(m);
            //} else {
            //    Sqlite.AddManga("backlog", Name, Chapter, "placeholder", DateTime.Now);
            //}

            Name = string.Empty;
            Chapter = string.Empty;
        }
    }
}