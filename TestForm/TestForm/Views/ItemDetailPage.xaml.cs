using System.ComponentModel;
using TestForm.ViewModels;
using Xamarin.Forms;

namespace TestForm.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}