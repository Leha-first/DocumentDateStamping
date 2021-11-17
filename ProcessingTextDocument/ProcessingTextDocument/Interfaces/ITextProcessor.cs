namespace ProcessingTextDocument
{
    /// <summary>
    /// Интерфейс для обработчиков текста
    /// </summary>
    interface ITextProcessor
    {
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
        public string ReplaceSymbolsInCurrentString(string fileStringContent);
    }
}
