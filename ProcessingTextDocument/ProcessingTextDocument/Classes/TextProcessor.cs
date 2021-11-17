namespace ProcessingTextDocument
{
    /// <summary>
    /// Класс обработчика текста
    /// </summary>
    public class TextProcessor : ITextProcessor
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="oldValue"> Новое значение </param>
        /// <param name="newValue"> Старое значение </param>
        public TextProcessor(string oldValue, string newValue)
        {
            OldStringValue = oldValue;
            NewStringValue = newValue;
        }

        /// <summary>
        /// Старое значение для замены
        /// </summary>
        public string OldStringValue { get; }

        /// <summary>
        /// Новое значение для вставки
        /// </summary>
        public string NewStringValue { get; }

        /// <summary>
        /// Метод замены входной строки на выходную
        /// </summary>
        /// <param name="fileStringContent"> Строка, требующая изменения </param>
        /// <returns> Выходная строка </returns>
        public string ReplaceSymbolsInCurrentString(string fileStringContent) =>
            fileStringContent.Replace(OldStringValue, NewStringValue);
    }
}
