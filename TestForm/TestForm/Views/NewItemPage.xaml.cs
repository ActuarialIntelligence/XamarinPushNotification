using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestForm.Models;
using TestForm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestForm.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}