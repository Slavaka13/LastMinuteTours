using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LastMinuteTours.Entities;

namespace LastMinuteTours.Services
{
    /// <summary>
    /// Сервис для работы с турами. Поддерживает асинхронные реализации.
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Возвращает список всех туров.
        /// </summary>
        Task<IList<TourModel>> GetAllToursAsync(CancellationToken token);

        /// <summary>
        /// Добавляет новый тур.
        /// </summary>
        Task AddTourAsync(TourModel tour, CancellationToken token);

        /// <summary>
        /// Обновляет существующий тур.
        /// </summary>
        Task UpdateTourAsync(TourModel tour, CancellationToken token);

        /// <summary>
        /// Удаляет тур по Id.
        /// </summary>
        Task DeleteTourAsync(Guid id, CancellationToken token);

        /// <summary>
        /// Возвращает общее количество туров.
        /// </summary>
        Task<int> GetTotalToursAsync(CancellationToken token);

        /// <summary>
        /// Возвращает суммарную стоимость всех туров.
        /// </summary>
        Task<decimal> GetTotalCostAsync(CancellationToken token);

        /// <summary>
        /// Возвращает количество туров с доплатами.
        /// </summary>
        Task<int> GetToursWithSurchargesAsync(CancellationToken token);

        /// <summary>
        /// Возвращает суммарные доплаты по всем турам.
        /// </summary>
        Task<decimal> GetTotalSurchargesAsync(CancellationToken token);
    }
}
