using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp.OrdersManagement
{
    public partial class MainWindow : Window
    {
        private List<Order<string>> orders = new List<Order<string>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string payerAccount = txtPayerAccount.Text.Trim();
                string receiverAccount = txtReceiverAccount.Text.Trim();
                decimal amountInRubles = decimal.Parse(txtAmountInRubles.Text.Trim());

                Order<string> order = new Order<string>(payerAccount, receiverAccount, amountInRubles);
                orders.Add(order);

                DisplayMessage("Заказ добавлен.");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnSortOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orders.Sort();

                DisplayMessage("Заказы отсортированы по расчетному счету плательщика.");

                // Вывод отсортированного списка заказов
                DisplayMessage("Отсортированный список заказов:");
                foreach (var order in orders)
                {
                    DisplayMessage($"Плательщик: {order.PayerAccount}, Получатель: {order.ReceiverAccount}, Сумма: {order.AmountInRubles} руб.");
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void DisplayMessage(string message)
        {
            txtResult.Text += $"{message}\n";
        }

        private void DisplayError(string error)
        {
            txtResult.Text += $"Ошибка: {error}\n";
        }
    }
}
