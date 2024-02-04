using Project1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * https://stackoverflow.com/questions/15175546/wpf-custom-datagrid-column-header Cell template style
 * 
 * 
         <ComboBox Name="CbCategories"
            HorizontalAlignment="Left" VerticalAlignment="Top"                  
            Margin="8,41,0,0" 
            Width="120"
            ItemsSource="{Binding ComboboxItemList}"
            DisplayMemberPath="Name"
            SelectedValuePath="Id"
            SelectedValue="{Binding ComboboxSelection}"
        />
changed to (without ValuePath):
        <ComboBox Name="CbCategories"
            HorizontalAlignment="Left" VerticalAlignment="Top"                  
            Margin="8,41,0,0" 
            Width="120"
            ItemsSource="{Binding ComboboxItemList}"
            DisplayMemberPath="Name"
            SelectedItem="{Binding ComboboxSelection}"
        />

 */

namespace Project1.Views
{
    /// <summary>
    /// Interaction logic for Palette.xaml
    /// </summary>
    public partial class Palette : UserControl
    {
        //see: C:\code_dev\Solution1\ComboBoxDataBindingExamples\Example2Window.xaml.cs

        // Collection property used to fill the ComboBox with a list of items:
        // ItemsSource="{Binding ComboboxItemList}"
        //public List<ComboboxItem>? ComboboxItemList {  get; set; } //shorthand code; (horror)
        public List<ComboboxItem> ComboboxItemList { 
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
        public ComboboxItem ComboboxSelection {
            get {
                Debug.WriteLine("ComboboxSelection Get");
                return comboboxSelection; 
            }
            set
            {
                comboboxSelection = value;
                //RaisePropertyChanged("ComboboxSelection"); //this needs parent class INotifyPropertyChanged
                //NotifyPropertyChanged("");
                Debug.WriteLine($"ComboboxSelection Set: id={value.Id}, name={value.Name}");
                if (_contentLoaded)
                {
                    // before InitializeComponent() is called, txtSelected does not exist, and _contentLoaded is false
                    txtSelected.Text = value.Name;
                }
            }
        }

        /// <summary>
        /// Collection property to fill the Datagrid with rows with two columns
        /// </summary>
        public List<DatagridRow> DatagridRowsRK
        {
            get
            {
                return DatagridRow.GetRows();
            }
        }

        public Palette()
        {

            //ComboboxItemList = ComboboxItem.GetList(); //needed for shorthand property code

            // Set the property to be used for the data binding to and from
            // the ComboBox's: SelectedValue="{Binding ComboboxSelection}"
            //ComboboxSelection = comboboxSelection; //needed for shorthand property code

            // Start with the first item selected
            ComboboxSelection = ComboboxItemList[0];

            Debug.WriteLine("Initializing the component");
            InitializeComponent();

            // black magic
            // Connect the data context (the above variables) to the XAML bindings.
            // NB: CbCategories is the name of the combobox and is known after InitializeComponent ran.
            CbCategories.DataContext = this;

            // this did not work: d:ItemsSource="{Binding DatagridRowsRK}"
            //dgProperties.DataContext = this;
            dgProperties.ItemsSource = DatagridRow.GetRows(); //works OK

            txtSelected.Text = "Select a category";
            Debug.WriteLine($"Palette.xaml.cs Initialized");

            //https://stackoverflow.com/questions/66755572/c-sharp-wpf-add-style-object-to-cells-in-datagrid-using-trigger
            {                
                DataGridColumn c = this.dgProperties.Columns[0]; // first column: Name
                Style st = new Style(typeof(DataGridCell), c.CellStyle);
                st.Setters.Add(new Setter(DataGridCell.ForegroundProperty, new SolidColorBrush(Colors.White)));
                st.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Colors.Gray)));
                st.Setters.Add(new Setter(DataGridCell.BorderBrushProperty, new SolidColorBrush(Colors.Gray)));
                c.CellStyle = st;
            }
            {                
                DataGridColumn c = this.dgProperties.Columns[1]; // second column: Value
                Style st = new Style(typeof(DataGridCell), c.CellStyle);
                st.Setters.Add(new Setter(DataGridCell.ForegroundProperty, new SolidColorBrush(Colors.White)));
                st.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Colors.Gray)));
                st.Setters.Add(new Setter(DataGridCell.BorderBrushProperty, new SolidColorBrush(Colors.Gray)));
                c.CellStyle = st;
            }
            return;
        }

    }//end class
}//end ns
