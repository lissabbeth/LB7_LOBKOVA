using System.Windows;

namespace LB7_LOBKOVA
{
    public partial class EditWindow : Window
    {
        public Division Division { get; private set; }

        public EditWindow(Division division)
        {
            InitializeComponent();
            Division = division;
            DataContext = Division;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем поле "Отдел" (обязательное)
            if (string.IsNullOrWhiteSpace(Division.Name))
            {
                MessageBox.Show("Поле 'Отдел' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем поле "Бюджет" (должно быть числом или пустым)
            if (!string.IsNullOrWhiteSpace(BudgetTextBox.Text) && !double.TryParse(BudgetTextBox.Text, out _))
            {
                MessageBox.Show("Некорректное значение в поле 'Бюджет'. Введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем поле "Сотрудники" (должно быть целым числом или пустым)
            if (!string.IsNullOrWhiteSpace(EmployeesTextBox.Text) && !int.TryParse(EmployeesTextBox.Text, out _))
            {
                MessageBox.Show("Некорректное значение в поле 'Сотрудники'. Введите целое число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем поле "Менеджер" (необязательное)
            if (!string.IsNullOrWhiteSpace(Division.Manager) && Division.Manager.Length > 100)
            {
                MessageBox.Show("Имя менеджера не должно превышать 100 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
