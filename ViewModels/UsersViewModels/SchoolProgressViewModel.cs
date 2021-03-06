﻿using BD_oneLove.Models;
using BD_oneLove.Tools;
using BD_oneLove.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BD_oneLove.ViewModels.UsersViewModels
{
    class SchoolProgressViewModel:BaseViewModel
    {
        private string _selYear;
        private readonly System.Windows.Thickness _bigMargin;
        private readonly Thickness _smallMargin;


        #region Props

        public string Title { get; set; } = "Уровень учебных достижений \"Cтахановская специализованная школа №10\"";
        public string TabTitle { get { return "Школа"; } }
        public Thickness SmallMargin { get { return _smallMargin; } }
        public Thickness BigMargin { get { return _bigMargin; } }
        public Thickness Margin { get; set; }
        public School School { get; set; } = new School();
        public List<string> Years { get; set; } = StationManager.DataStorage.GetYears();
        public string[] Types { get; set; } = { "семестр1", "семестр2", "годовая" };
        public List<School> Schools { get; set; } = new List<School>();

        public CollectionViewSource ViewSource {
            get;
        }

        public bool IsYearSel
        {
            get
            {
                return SelectedYear != null;
            }
        }


        public string SelectedYear
        {
            get { return _selYear; }
            set
            {
                _selYear = value;
                OnPropertyChanged("SelectedYear");
            }
        }

        public string SelectedType { get; set; }

        #endregion

        private RelayCommand<object> _findCommand;


        public ICommand FindCommand
        {
            get
            {
                return _findCommand ?? (_findCommand = new RelayCommand<object>(
                         o => FindImplementation(), o =>  !String.IsNullOrEmpty(SelectedType)));
            }
        }

        private void FindImplementation()
        {
            School.Classes = StationManager.DataStorage.GetClassesStatistics(SelectedYear, SelectedType);
            School.Update();
            OnPropertyChanged("School");
            ViewSource.View.Refresh();
           
            Margin = (School.Classes != null && School.Classes.Any()) ? BigMargin : SmallMargin;
            OnPropertyChanged("Margin");

        }

        public SchoolProgressViewModel()
        {
            ViewSource = new CollectionViewSource();
            ViewSource.Source = Schools;

            SelectedYear = Years[0];
            _bigMargin = new Thickness(26, 0, 26, 0);
            _smallMargin = new Thickness(20, 0, 20, 0);
            Margin = SmallMargin;
            Schools.Add(School);

            StationManager.RefreshYearListEvent += () =>
            {
                Years = StationManager.DataStorage.GetYears();
                OnPropertyChanged("StYears");
            };
        }

    }
}
