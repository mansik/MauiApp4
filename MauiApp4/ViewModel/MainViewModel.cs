﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp4.ViewModel;

// Add ViewModel class and inherit from ObservableObject
public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();

        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string? text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "Ok");
            return;
        }

        Items.Add(Text);

        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        // do not send informations
        // await Shell.Current.GoToAsync(nameof(DetailPage));

        // [there's two ways to pass DetailPage information]
        //  1. query property: await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        //  2. URI
        // to send simple data type like strings and integers across
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}"); // [QueryProperty("Text", "Text")]
        // await Shell.Current.GoToAsync($"{nameof(DetailPage)}?id={s}"); // [QueryProperty("Text", "id")]

        // to send a complex data type, like a person or a car or some other data object
        // await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}",
        //        new Dictionary<string, object>
        //        {
        //            {nameof(DetailPage), new object()},
        //        });
    }
}
