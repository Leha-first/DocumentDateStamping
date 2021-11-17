using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTextDocument
{
    /// <summary>
    /// Класс обработчика файлов
    /// </summary>
    internal class FileProcessor
    {
        /// <summary>
        /// Метод парсинга текстового файла
        /// </summary>
        /// <param name="filePath"> Путь к файлу </param>
        /// <returns> Task </returns>
        internal static async Task<Exception> ParseInputTextFile(string filePath)
        {
            try
            {
                await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                var byteArray = new byte[fileStream.Length];
                //АСИНХРОННОЕ ЧТЕНИЕ ИЗ ПОТОКА
                await fileStream.ReadAsync(byteArray, 0, byteArray.Length);
                //ОЧИСТКА ПОТОКА
                fileStream.SetLength(0);
                var fileStringContent = Encoding.Default.GetString(byteArray);
                //СОЗДАНИЕ ЭКЗЕМПЛЯРА ПРОЦЕССОРА
                var textProcessor = new TextProcessor("$$18",
                    $"\n\tдата ввода изменений -{ClassDateTimeHelper.GetNextWorkingDay().ToShortDateString()}\n\t");
                fileStringContent = textProcessor.ReplaceSymbolsInCurrentString(fileStringContent);
                await using var streamWriter = new StreamWriter(fileStream);
                //АСИНХРОННАЯ ЗАПИСЬ В ФАЙЛ
                await streamWriter.WriteAsync(fileStringContent);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
