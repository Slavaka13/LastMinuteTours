using System.Diagnostics;
using LastMinuteTours.Entities;
namespace LastMinuteToursManger.Contracts
{
 

        /// <summary>
        /// Менеджер туров. 
        /// Отвечает за управление данными туров и предоставляет методы 
        /// для получения, добавления, обновления, удаления и анализа туров.
        /// </summary>
        public interface ITourManager
        {
            /// <summary>
            /// Возвращает все туры, доступные в хранилище.
            /// </summary>
            Task<IList<TourModel>> GetAllToursAsync(CancellationToken cancellationToken = default);

            /// <summary>
            /// Добавляет новый тур в хранилище.
            /// </summary>
            Task AddTourAsync(TourModel tour, CancellationToken cancellationToken = default);

            /// <summary>
            /// Обновляет существующий тур.
            /// Если тур с указанным идентификатором не найден — операция безопасно игнорируется.
            /// </summary>
            Task UpdateTourAsync(TourModel tour, CancellationToken cancellationToken = default);

            /// <summary>
            /// Удаляет тур по идентификатору.
            /// Операция безопасна: если тур отсутствует — ничего не происходит.
            /// </summary>
            Task DeleteTourAsync(Guid id, CancellationToken cancellationToken = default);

            /// <summary>
            /// Возвращает агрегированную статистику по всем турам.
            /// </summary>
            Task<TourStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default);
        }

    }

