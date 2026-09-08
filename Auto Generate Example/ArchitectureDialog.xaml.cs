// UI/ArchitectureDialog.xaml.cs
using System.Windows;
using System.Windows.Controls;
using ArchitectureScaffolder.Core;

namespace ArchitectureScaffolder.UI
{
    public partial class ArchitectureDialog : Window
    {
        public IArchitectureGenerator SelectedGenerator { get; private set; }
        public string RootNamespace => TxtNamespace.Text;

        public ArchitectureDialog(string defaultNamespace)
        {
            InitializeComponent();
            TxtNamespace.Text = defaultNamespace;

            var architectures = ArchitectureFactory.GetAvailableArchitectures();
            ListArchitectures.ItemsSource = architectures;
            if (architectures.Count > 0)
                ListArchitectures.SelectedIndex = 0;
        }

        private void ListArchitectures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListArchitectures.SelectedItem is IArchitectureGenerator selected)
            {
                TxtDescription.Text = selected.Description;
            }
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (ListArchitectures.SelectedItem is IArchitectureGenerator selected)
            {
                SelectedGenerator = selected;
                DialogResult = true;
                Close();
            }
        }
    }
}
