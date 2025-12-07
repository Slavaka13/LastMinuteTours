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
        Task<IList<TourModel>> GetAllToursAsync(CancellationToken token);

        /// <summary>
        /// Добавляет новый тур в хранилище.
        /// </summary>
        Task AddTourAsync(TourModel tour, CancellationToken token);

        /// <summary>
        /// Обновляет данные существующего тура.
        /// Если тур с указанным идентификатором не найден, реализация может 
        /// либо проигнорировать обновление, либо выбросить исключение.
        /// </summary>
        Task UpdateTourAsync(TourModel tour, CancellationToken token);

        /// <summary>
        /// Удаляет тур с указанным идентификатором.
        /// Если тур отсутствует — операция должна быть безопасной и не приводить к ошибкам.
        /// </summary>
        Task DeleteTourAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Возвращает агрегированную статистику по всем турам.
        /// Статистика включает общее количество туров, их суммарную стоимость,
        /// количество туров с доплатами и общий объём доплат.
        /// </summary>
        Task<TourStatistics> GetStatisticsAsync(CancellationToken token);
    }
}
