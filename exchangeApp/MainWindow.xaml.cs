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
        /// <summary>
        /// this is the model that conatins the data
        /// </summary>
        CurrenciesModel model = new CurrenciesModel();

        /// <summary>
        /// this delegate is for loading the data from the xml asynchronously
        /// </summary>
        delegate void LoadData();

        public MainWindow()
        {
            try
            {
                LoadData dele = model.LoadCurrencies;
                IAsyncResult asyncCall = dele.BeginInvoke(null, null);
                InitializeComponent();
                dele.EndInvoke(asyncCall);
                ObservableCollection<Currency> listOfValues = new ObservableCollection<Currency>(model.Currencies);
                ObservableCollection<string> listOfKeys = new ObservableCollection<string>(model.Codes);
                currenciesList.DataContext = listOfValues;
                codesComboBox.ItemsSource = listOfKeys;
            }
            catch (ExchangeAppException e)
            {
                InitializeComponent();
                //if the data is not available the buttons get disabled
                convertButton.IsEnabled = false;
                codesComboBox.IsEnabled = false;
                MessageBox.Show("Problem Loading The Currencies");
            }
        }

        /// <summary>
        /// this method handles the conversion click
        /// it takes the text from the amount and the text from the combobox
        /// and activates the convert method in the model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string fromCoode = codesComboBox.Text;
            double amount;
            if (Double.TryParse(amountTextBox.Text,out amount))
            {
                Currency fromCurrency = model.GetCurrencyByCode(fromCoode);
                resultTextBox.Text = System.Convert.ToString(model.Convert(fromCurrency, model.Shekel, amount));   
            }
            else
            {
                MessageBox.Show("please enter a valid amount");
            }
                
        }


        /// <summary>
        /// this method reload the data from the model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadData dele = model.LoadCurrencies;
                IAsyncResult asyncCall = dele.BeginInvoke(null, null);
                dele.EndInvoke(asyncCall);
                ObservableCollection<Currency> listOfValues = new ObservableCollection<Currency>(model.Currencies);
                ObservableCollection<string> listOfKeys = new ObservableCollection<string>(model.Codes);
                currenciesList.DataContext = listOfValues;
                codesComboBox.ItemsSource = listOfKeys;
                convertButton.IsEnabled = true;
                codesComboBox.IsEnabled = true;
            }
            catch (ExchangeAppException e1)
            {
                convertButton.IsEnabled = false;
                codesComboBox.IsEnabled = false;
                MessageBox.Show("Problem Loading The Currencies");
            }
        }     
    }
}
