using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LastMinuteTours.Entities;
using LastMinuteTours.Services.Contracts;

namespace LastMinuteTours.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с туристическими турами.
    /// Определяет операции для получения списка туров, изменения данных
    /// и вычисления агрегированной статистики.
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Возвращает список всех туров.
        /// Метод должен возвращать копию набора данных, чтобы внешние изменения
        /// не могли повлиять на состояние хранилища.
        /// </summary>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Список всех туров.</returns>
        Task<IList<TourModel>> GetAllToursAsync(CancellationToken token);

        /// <summary>
        /// Добавляет новый тур в хранилище.
        /// </summary>
        /// <param name="tour">Экземпляр тура, который необходимо добавить.</param>
        /// <param name="token">Токен отмены операции.</param>
        Task AddTourAsync(TourModel tour, CancellationToken token);

        /// <summary>
        /// Обновляет данные существующего тура.
        /// Если тур с указанным идентификатором не найден, реализация может 
        /// либо проигнорировать обновление, либо выбросить исключение.
        /// </summary>
        /// <param name="tour">Обновлённый экземпляр туров.</param>
        /// <param name="token">Токен отмены операции.</param>
        Task UpdateTourAsync(TourModel tour, CancellationToken token);

        /// <summary>
        /// Удаляет тур с указанным идентификатором.
        /// Если тур отсутствует — операция должна быть безопасной и не приводить к ошибкам.
        /// </summary>
        /// <param name="id">Идентификатор тура, который необходимо удалить.</param>
        /// <param name="token">Токен отмены операции.</param>
        Task DeleteTourAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Возвращает агрегированную статистику по всем турам.
        /// Статистика включает общее количество туров, их суммарную стоимость,
        /// количество туров с доплатами и общий объём доплат.
        /// </summary>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Объект <see cref="TourStatistics"/> со всеми вычисленными значениями.</returns>
        Task<TourStatistics> GetStatisticsAsync(CancellationToken token);
    }
}
