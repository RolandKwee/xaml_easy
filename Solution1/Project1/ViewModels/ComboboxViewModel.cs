using Project1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;

namespace Project1.ViewModels
{
    /// <summary>
    /// Intermediary between the (data) Model and the UI/XAML.
    /// Handles update events.
    /// </summary>
    public class ComboboxViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor. Needed???
        /// </summary>
        //public ComboboxViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// For the item list of the combobox.
        /// This is probably overdone, because the user will not edit those items in the combobox.
        /// </summary>
        public ObservableCollection<ComboboxItem> ObservableComboboxItemList
        { 
            get
            {
                return ComboboxItem.GetObservableCollection();
            }
            //set { }
        }

        // Collection property used used to fill the ComboBox with a list of items:
        // ItemsSource="{Binding ComboboxItemList}"
        //public List<ComboboxItem>? ComboboxItemList {  get; set; } //shorthand code; (horror)
        public List<ComboboxItem> ComboboxItemList
        {
            get
            {
                return ComboboxItem.GetList(); //non-shorthand, but not much code either, easier to understand (for me)
            }
            //set { }
        }

        // Object to bind the combobox selections to:
        // SelectedValue="{Binding ComboboxSelection}"
        // shorthand code:
        //public ComboboxItem? ComboboxSelection { get; set; }
        //private ComboboxItem comboboxSelection = new ComboboxItem();
        // full code:
        private ComboboxItem comboboxSelection;
        public ComboboxItem ComboboxSelection
        {
            get
            {
                Debug.WriteLine("ComboboxSelection Get");
                return comboboxSelection;
            }
            set
            {
                comboboxSelection = value;
                NotifyPropertyChanged();
                //RaisePropertyChanged("ComboboxSelection"); //this needs parent class INotifyPropertyChanged
                Debug.WriteLine($"ComboboxSelection Set: id={value.Id}, name={value.Name}");
            }
        }

        /// <summary>
        /// Needed???
        /// </summary>
        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                Debug.WriteLine($"INotifyPropertyChanged Add");
                //throw new NotImplementedException();
            }

            remove
            {
                Debug.WriteLine($"INotifyPropertyChanged Remove");
                //throw new NotImplementedException();
            }
        }
    }//end class
}//end ns
