﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MangaChecker.GUI.dependencies;
using PropertyChanged;

namespace MangaChecker.GUI.Viewmodels {
    [ImplementPropertyChanged]
    public class MangaViewerViewModel {
        private int _offset;


        public MangaViewerViewModel() {
            ImagesInternal = new ObservableCollection<Image>();
            Images = new ReadOnlyObservableCollection<Image>(ImagesInternal);
            show = new ActionCommand(FillImages);
            Canvas = Visibility.Collapsed;
            fetchvis = Visibility.Visible;
        }

        public static ObservableCollection<Image> ImagesInternal { get; set; }
        public string Link { get; set; }
        public Visibility ErrorVisibility { get; set; } = Visibility.Collapsed;
        public Visibility Canvas { get; set; }
        public Visibility fetchvis { get; set; }
        public Visibility PbarVisibility { get; set; } = Visibility.Collapsed;
        public ICommand show { get; }

        public ReadOnlyObservableCollection<Image> Images { get; }

        private void FillImages() {
            ImagesInternal.Clear();
            fetchvis = Visibility.Collapsed;
            PbarVisibility = Visibility.Visible;
            var childThread = new Thread(() => {
                var x = new List<string>();
                x = SiteSelector(Link);
                if (x == null) return;
                foreach (var link in x) {
                    if (link == "") continue;
                    try {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                            ImagesInternal.Add(new Image {
                                Source = new BitmapImage(new Uri(link, UriKind.RelativeOrAbsolute))
                            });
                        }));
                        Thread.Sleep(500);
                    } catch (Exception) {
                        //DebugText.Write($"[Error] failed to display img \"{link}\" ");
                        continue;
                    }
                    Canvas = Visibility.Visible;
                    PbarVisibility = Visibility.Collapsed;
                }
            }) {IsBackground = true};
            childThread.Start();
        }

        private void ShowError() {
            PbarVisibility = Visibility.Collapsed;
            ErrorVisibility = Visibility.Visible;
        }

        private List<string> SiteSelector(string link) {
            var site = new List<string>();
            //if (link.Equals("placeholder")) {
            //    ShowError();
            //    return null;
            //}
            //try {
            //    if (link.Contains("yomanga")) {
            //        site = ImageLinkCollecter.YomangaCollectLinks(Link);
            //    }
            //    if (link.Contains("mangastream") || link.Contains("readms")) {
            //        site = ImageLinkCollecter.MangastreamCollectLinks(Link);
            //    }
            //} catch (Exception) {
            //    ShowError();
            //    return null;
            //}
            return site;
        }
    }
}