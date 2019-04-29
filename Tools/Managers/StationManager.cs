﻿using System.Windows;
using System.Windows.Controls;
using BD_oneLove.Tools.DataStorage;

namespace BD_oneLove.Tools.Managers
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage = new DataStorage.DataStorage();
        
        public static Window MyMain { get; set; }
        public static Window MySettings { get; set; }

        public static PasswordBox MainPassword { get; set; }
        public static PasswordBox DbPassword { get; set; }

        public static string ConnectionString { get; set; }

        public static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

    }
}