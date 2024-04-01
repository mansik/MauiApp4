using MauiApp4.ViewModel;

namespace MauiApp4;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        // set the BindingContext for ViewModel in DetailPage(data binding)
        BindingContext = vm;
    }
}

