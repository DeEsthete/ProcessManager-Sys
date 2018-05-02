using System;
using System.Collections.Generic;
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

namespace ProcessManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process[] _processes;
        public MainWindow()
        {
            InitializeComponent();

            _processes = Process.GetProcesses(".");

            foreach (var process in _processes)
            {
                ProcessItem tmp = new ProcessItem(process.Id.ToString(), process.ProcessName);
                processesListBox.Items.Add(tmp);
            }
        }

        private void KillButtonClick(object sender, RoutedEventArgs e)
        {
            ProcessItem temp = processesListBox.SelectedItem as ProcessItem;
            foreach (var process in _processes)
            {
                if (process.Id == int.Parse(temp.idTextBlock.Text))
                {
                    process.Kill();
                    //processesListBox.Items.Remove(temp);
                }
            }
            

            for (int i = 0; i < processesListBox.Items.Count; i++)
            {
                processesListBox.Items.RemoveAt(i);
            }
            foreach (var process in _processes)
            {
                ProcessItem tmp = new ProcessItem(process.Id.ToString(), process.ProcessName);
                processesListBox.Items.Add(tmp);
            }
        }
    }
}
