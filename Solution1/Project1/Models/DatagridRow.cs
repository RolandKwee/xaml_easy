using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
    /// <summary>
    /// Data content for the Datagrid Usercontrol
    /// </summary>
    public class DatagridRow
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// Return the list of items for the combobox
        /// </summary>
        /// <returns></returns>
        public static List<DatagridRow> GetRows()
        {
            // Set up the collection properties used to bind the ItemsSource 
            // properties to display the list of items in the dropdown lists.
            var L = new List<DatagridRow>()
                {
                    new DatagridRow(){ RowNum= 0, Name = "Materiaal", Value="PVC" },
                    new DatagridRow(){ RowNum= 1, Name = "Grondstof", Value="Teer" },
                    new DatagridRow(){ RowNum= 2, Name = "Adres", Value="Hoofdweg" },
                    new DatagridRow(){ RowNum= 3, Name = "Lengte", Value="26,3 m" },
                    new DatagridRow(){ RowNum= 4, Name = "Breedte", Value="0.15 m" },
                    new DatagridRow(){ RowNum= 5, Name = "Gewicht", Value="16.2 kg" },
                    new DatagridRow(){ RowNum= 6, Name = "Soort", Value="Afval" },
                    new DatagridRow(){ RowNum= 7, Name = "Richting", Value="Noordwest" },
                    new DatagridRow(){ RowNum= 8, Name = "Buigzaam", Value="Ja" },
                    new DatagridRow(){ RowNum= 9, Name = "Status", Value="Half" },
                };
            return L;
        }

    }//end class
}//end ns
