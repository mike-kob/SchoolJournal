﻿using BD_oneLove.Models;
using BD_oneLove.Tools;
using BD_oneLove.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BD_oneLove.ViewModels.UsersViewModels
{
    class SubjectProgressViewModel: BaseViewModel
    {
        private string _selYear;
        private readonly Thickness _bigMargin;
        private readonly Thickness _smallMargin;

        #region Props

        public string Title { get; set; } = "";
        public string TabTitle { get { return "Предметы"; } }
        public  Thickness SmallMargin { get { return _smallMargin; } }
        public Thickness BigMargin { get { return _bigMargin; } }
        public Thickness Margin { get; set; }
        public List<ClassSubject> Subjects { get; set; }
        public List<string> Years { get; set; } = StationManager.DataStorage.GetYears();
        public List<Class> Classes { get; set; }
        public string[] Types { get; set; } = { "семестр1", "семестр2", "годовая" };
    

        public bool IsYearSel {
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
                Classes = StationManager.DataStorage.GetClasses(SelectedYear);
                OnPropertyChanged("SelectedYear");
                OnPropertyChanged("Classes");
            }
        }

        public Class SelectedClass { get; set; }
        public string SelectedType{ get; set; }

        #endregion

        private RelayCommand<object> _findCommand;


        public ICommand FindCommand
        {
            get
            {
                return _findCommand ?? (_findCommand = new RelayCommand<object>(
                         o => FindImplementation(), o => SelectedClass!=null && SelectedType != null));
            }
        }

        private void FindImplementation()
        {
            Subjects = StationManager.DataStorage.GetSubjectsStatistics(SelectedClass, SelectedType);
            OnPropertyChanged("Subjects");
            Margin = (Subjects!=null && Subjects.Any())?BigMargin:SmallMargin;
            OnPropertyChanged("Margin");
            Title = "Сводная ведомость успеваемости " + SelectedClass.NumberLetter + " класса за " +
                    SelectedYear + " " + SelectedType;
            OnPropertyChanged("Title");
        }

        public SubjectProgressViewModel()
        {
            Classes = StationManager.DataStorage.GetClasses(SelectedYear);
            SelectedYear = Years[0];
            _bigMargin = new Thickness(26, 0, 26, 0);
            _smallMargin = new Thickness(20, 0, 20, 0);
            Margin = SmallMargin;
            StationManager.RefreshYearListEvent += () =>
            {
                Years = StationManager.DataStorage.GetYears();
                OnPropertyChanged("StYears");
            };
        }

       
    }
}
