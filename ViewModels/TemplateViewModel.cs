
﻿using BD_oneLove.Tools.Managers;
using BD_oneLove.Tools.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace BD_oneLove.ViewModels
{
    class TemplateViewModel
    {
        private string _name = StationManager.CurrentUser.Username; // change and get from station manager
        private string _position = StationManager.CurrentUser.AccessType;
        private string _photo = "Resources/dailyplanner.jpg";

        private KeyValuePair<string, ViewType> _selectedView;


        public TemplateViewModel()
        {

            //  Tabs = new ObservableCollection<TabItem>();
            //  Tabs.Add(new TabItem { Header = "One", Content = "One's content" });
            //  Tabs.Add(new TabItem { Header = "Two", Content = "Two's content" });
            //switch for items

            Items = new Dictionary<string, ViewType>();
            addItems();
           
           

        }

        private void addItems()
        {
            switch (_position)
            {
                case "Директор":
                    Items.Add("Учителя",ViewType.TeachersView);
                    Items.Add("Табель", ViewType.MarkGrid);
                   // Items.Add("Классы");
                    break;
                case "Классный руководитель":
                   // Items.Add("Мой класс");
                   // Items.Add("Выставление оценок");
                   // Items.Add("Социальный паспорт");
                   // Items.Add("Родители");
                   // Items.Add("Выбывшие/прибывшие");
                    break;
                case "Заместитель директора":
                   // Items.Add("Ученики");
                   // Items.Add("Классы");
                   // Items.Add("Выбывшие/прибывшие");
                   // Items.Add("Учебный план");
                   // Items.Add("Успеваемость");
                   // Items.Add("Отчет по ученикам");
                   // Items.Add("Выставление оценок");
                    break;
            }

        }

        public string Caption
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public KeyValuePair<string, ViewType> SelectedView
        {
            get { return _selectedView;}
            set
            {
                _selectedView = value;
                ViewNavigationManager.Instance.Navigate(value.Value);
            }
        }


        public ObservableCollection<TabItem> Tabs { get; set; }
        public Dictionary<string, ViewType> Items { get; set; }

        public class TabItem
        {
            public string Header { get; set; }
            public string Content { get; set; }
        }

    }
}
