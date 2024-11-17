using System.Linq;
using System.Windows;

namespace LB7_LOBKOVA
{
    public partial class MainWindow : Window
    {
        private MunicipalDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new MunicipalDbContext();
            LoadData();
        }

        private void LoadData()
        {
            DataGridDivisions.ItemsSource = _context.Divisions.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditWindow(new Division());
            if (editWindow.ShowDialog() == true)
            {
                _context.Divisions.Add(editWindow.Division);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridDivisions.SelectedItem is Division selected)
            {
                var editWindow = new EditWindow(selected);
                if (editWindow.ShowDialog() == true)
                {
                    _context.Entry(selected).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Изменения не сохранены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridDivisions.SelectedItem is Division selected)
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Divisions.Remove(selected);
                    _context.SaveChanges();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void DataGridDivisions_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
