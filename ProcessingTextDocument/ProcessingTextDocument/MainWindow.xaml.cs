using System.Windows;
using Microsoft.Win32;

namespace ProcessingTextDocument
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для обработки нажатия на кнопку "Указать путь к папке и запустить обработку файлов"
        /// </summary>
        /// <param name="sender"> Button </param>
        /// <param name="e"> Данные о событии RoutedEventArgs </param>
        private async void ButtonBaseOnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Text|*.txt"
            };
            if (openFileDialog.ShowDialog() != true)
            {
                LabelForResult.Content = string.Empty;
                TextBlockWithFilePath.Text = string.Empty;
                return;
            }
            //УСТАНОВКА МАКСИМУМА ПРОГРЕСС БАРА
            ProgressBarProcessingDocumentStatus.Maximum = openFileDialog.FileNames.Length;
            ProgressBarProcessingDocumentStatus.Minimum = 0;

            foreach (var fileName in openFileDialog.FileNames)
            {
                if (string.IsNullOrEmpty(fileName)) return;
                TextBlockWithFilePath.Text += fileName;
                //ВОЗВРАТ NULL - ИСКЛЮЧЕНИЯ НЕ ВОЗНИКЛО
                var thrownException = await FileProcessor.ParseInputTextFile(fileName);
                if (thrownException != null) {
                    TextBlockWithFilePath.Text += $" Ошибка обработки файла - { thrownException.Message} \n";
                    continue;
                }
                TextBlockWithFilePath.Text += " - Успешно \n";
                ProgressBarProcessingDocumentStatus.Value++;
            }
        }
    }
}
