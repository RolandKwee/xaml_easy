using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace Project1.Models
{
    /// <summary>
    /// This class provides us with an object to fill a ComboBox with
    /// that can be bound to numeric fields in the binding object
    /// while displaying string values in the list presented to user in the ComboBox.
    /// </summary>
    public class ComboboxItem
    {
        // { get; set; } is shorthand for creating a private var with almost the same name, etc

        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Return the list of items for the combobox
        /// </summary>
        /// <returns></returns>
        public static List<ComboboxItem> GetList()
        {
            // Set up the collection properties used to bind the ItemsSource 
            // properties to display the list of items in the dropdown lists.
            var L = new List<ComboboxItem>()
                {
                    new ComboboxItem(){ Id = 0, Name = "Buizen" },
                    new ComboboxItem(){ Id = 1, Name = "Pijpen" },
                    new ComboboxItem(){ Id = 2, Name = "Bochten" },
                };

            return L;
        }

        /// <summary>
        /// Return all items as an ObservableCollection
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ComboboxItem> GetObservableCollection()
        {
            ObservableCollection<ComboboxItem> OC = new ObservableCollection<ComboboxItem>();
            foreach(var item in GetList())
            {
                OC.Add(item);
            }
            return OC;
        }
    }//end class
}//end ns
