﻿using System.Windows;
using BD_oneLove.ViewModels.UserDialogViewModels;

namespace BD_oneLove.Views.UserDialogs
{
    /// <summary>
    /// Interaction logic for ParentCardView.xaml
    /// </summary>
    public partial class ParentCardView : Window
    {
        public ParentCardView()
        {
            InitializeComponent();
            DataContext = new ParentCardViewModel();
        }
    }
}
