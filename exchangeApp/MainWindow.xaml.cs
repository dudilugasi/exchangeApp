using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace exchangeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrenciesModel model = new CurrenciesModel();
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Currency> listOfValues = new ObservableCollection<Currency>(model.Currencies);
            ObservableCollection<string> listOfKeys = new ObservableCollection<string>(model.Codes);
            currenciesList.DataContext = listOfValues;
            codesComboBox.ItemsSource = listOfKeys;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fromCoode = codesComboBox.Text;
            double amount = Double.Parse(amountTextBox.Text);
            Currency fromCurrency = model.GetCurrencyByCode(fromCoode);
            resultTextBox.Text = System.Convert.ToString(model.Convert(fromCurrency, model.Shekel, amount));       
        }

        


        

        

        
    }
}
