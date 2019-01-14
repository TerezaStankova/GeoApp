using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamApp.Models;


namespace XamApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.ContactRepo.AddNewContactAsync(newName.Text);
            statusMessage.Text = App.ContactRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Contact> contacts = await App.ContactRepo.GetAllContactsAsync();
            contactsList.ItemsSource = contacts;
        }
    }
}
