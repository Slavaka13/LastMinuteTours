namespace LastMinuteToursWeb.Models
{
    /// <summary>
    /// Модель представления для отображения информации об ошибке.
    /// Используется на странице Error для вывода идентификатора запроса.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Идентификатор текущего HTTP-запроса.
        /// Используется для диагностики и отладки ошибок.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Определяет, требуется ли отображать идентификатор запроса на странице ошибки.
        /// Возвращает true, если идентификатор запроса задан.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
