using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Cantor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Exchange exchange = new Exchange();
        CurrencyCollection currencyCollection;
        public MainWindow()
        {
            currencyCollection = CurrencyCollection.Instance();
            InitializeComponent();
        }

        private void ComboBox_Initialized(object sender, EventArgs e)
        {
            MockCurrenciesCollection collection = new MockCurrenciesCollection();
            ComboBox comboBox = (ComboBox)sender;
            foreach (var currencies in currencyCollection.Currencies)
            {
                comboBox.Items.Add(currencies);
            }
        }

        private decimal LiveCalculation(ComboBox comboBox1, ComboBox comboBox2, TextBox textBox)
        {
            Currency currency1 = comboBox1.SelectedItem as Currency;
            if (currency1 == null) 
            {
                throw new ArgumentException("Wybierz walutę początkową");
            }

            Currency currency2 = comboBox2.SelectedItem as Currency;
            if (currency2 == null)
            {
                throw new ArgumentException("Wybierz walutę końcową");
            }

            decimal amount;

            if (!decimal.TryParse(textBox.Text, out amount))
            {
                throw new ArgumentException("Podaj liczbę");
            }

            return exchange.Calculate(currency1, amount, currency2);

        }
        private void ValueChanged()
        {
            try
            {
                outputTextBlock.Text = (decimal.Floor(LiveCalculation(primaryComboBox, secondaryComboBox, inputField) * 100) / 100).ToString();
            }
            catch (ArgumentException)
            {
                outputTextBlock.Text = "";
            }
            catch (OverflowException)
            {
                outputTextBlock.Text = "Liczba zbyt długa";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValueChanged();
        }

        private void inputField_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\d+\,\d{1,2}$|^\d+\,$|^\d+$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text + e.Text);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValueChanged();
        }
    }
}
