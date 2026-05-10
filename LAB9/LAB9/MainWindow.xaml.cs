using System.Windows;

namespace LAB9
{
    public partial class MainWindow : Window
    {
        private Money money;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            txtError.Text = string.Empty;

            if (!uint.TryParse(txtRubles.Text, out uint rubles))
            {
                txtError.Text = "Ошибка: рубли должны быть неотрицательным целым числом";
                return;
            }

            if (!byte.TryParse(txtKopeks.Text, out byte kopeks))
            {
                txtError.Text = "Ошибка: копейки должны быть числом от 0 до 255";
                return;
            }

            money = new Money(rubles, kopeks);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMoney()) return;

            if (!uint.TryParse(txtAddKop.Text, out uint kops))
            {
                txtError.Text = "Ошибка: введите неотрицательное число";
                return;
            }

            Money result = money.AddKopeks(kops);
            txtAddResult.Text = $"Результат: {result}";
        }

        private void btnInc_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMoney()) return;
            money = ++money;
            UpdateDisplay();
        }

        private void btnDec_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMoney()) return;
            money = --money;
            UpdateDisplay();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMoney()) return;

            if (!uint.TryParse(txtOperValue.Text, out uint value))
            {
                txtError.Text = "Ошибка: введите неотрицательное число";
                return;
            }

            Money result1 = money + value;
            Money result2 = value + money;
            txtOperResult.Text = $"m + {value} = {result1}\n{value} + m = {result2}";
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMoney()) return;

            if (!uint.TryParse(txtOperValue.Text, out uint value))
            {
                txtError.Text = "Ошибка: введите неотрицательное число";
                return;
            }

            Money result1 = money - value;
            Money result2 = value - money;
            txtOperResult.Text = $"m - {value} = {result1}\n{value} - m = {result2}";
        }

        private void btnCast_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMoney()) return;

            uint rub = (uint)money;
            double kop = money;

            txtCast.Text = $"uint (только рубли): {rub}\ndouble (только копейки): {kop:F2}";
        }

        private bool CheckMoney()
        {
            if (money == null)
            {
                txtError.Text = "Ошибка: сначала создайте объект";
                return false;
            }
            return true;
        }

        private void UpdateDisplay()
        {
            txtCurrent.Text = money.ToString();
            txtCopy.Text = $"Копия: {new Money(money)}";
            txtError.Text = string.Empty;
        }
    }
}