using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using XamApp.Models;
using Xamarin.Forms.Xaml;


namespace XamApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        bool isEditing;
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainPage()
        {
            InitializeComponent();
            contactsList.ItemsSource = ContactRepository.Contacts;            
        }

        protected async override void OnAppearing()
        {
            await App.ContactRepo.AddAllContactsAsync();
            contactsList.ItemsSource = ContactRepository.Contacts;
            base.OnAppearing();
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!isEditing)
            {
                var contactSelected = (Contact)e.Item;
                
            }
        }

        void OnEdit(object sender, EventArgs e)
        {
            isEditing = !isEditing;
            ((ToolbarItem)sender).Text = isEditing ? "End Edit" : "Edit";
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            var contact = (Contact)e.SelectedItem;
            await DeleteContactAsync(contact);       
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var contact = (Contact)item.BindingContext;
            await DeleteContactAsync(contact);
        }


        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "New contact";

            await App.ContactRepo.AddNewContactAsync(newName.Text, newPhoneNumber.Text);
            statusMessage.Text = App.ContactRepo.StatusMessage;
        }

        async Task<bool> DeleteContactAsync(Contact contact)
        {
            if (contact != null)
            {
                if (await this.DisplayAlert("Confirm", $"Are you sure you want to delete {contact.Name}?", "Yes", "No") == true)
                {
                    await App.ContactRepo.DeleteItemAsync(contact);
                    ContactRepository.Contacts.Remove(contact);
                    return true;
                }
            }
            return false;
        }
    }
}
