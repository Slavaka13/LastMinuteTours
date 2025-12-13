using LastMinuteTours.Entities;
using LastMinuteToursManager;
using LastMinuteToursManger.Contracts;
using LastMinuteToursWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LastMinuteToursWeb.Controllers
{
    /// <summary>
    /// Контроллер главной страницы веб-приложения.
    /// Отвечает за отображение списка туров, агрегированной статистики,
    /// а также за операции создания, редактирования и удаления туров.
    /// </summary>
    public class HomeController(ITourManager tourManager) : Controller
    {
        /// <summary>
        /// Менеджер туров, инкапсулирующий бизнес-логику работы с турами
        /// и взаимодействие с хранилищем данных.
        /// </summary>
        private ITourManager TourManager { get; } = tourManager;

        /// <summary>
        /// Отображает главную страницу со списком всех туров
        /// и общей статистикой по ним.
        /// </summary>
        /// <returns>Представление Index со списком туров и статистикой.</returns>
        public async Task<IActionResult> Index()
        {
            var tours = await TourManager.GetAllToursAsync();
            var statistics = await TourManager.GetStatisticsAsync();

            var vm = new TourIndexViewModel
            {
                Tours = tours,
                Statistics = statistics
            };

            return View(vm);
        }

        /// <summary>
        /// Отображает форму добавления нового тура.
        /// </summary>
        /// <returns>Представление Create с пустой моделью тура.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View(new TourEditViewModel());
        }

        /// <summary>
        /// Обрабатывает отправку формы добавления нового тура.
        /// </summary>
        /// <param name="model">Модель данных тура, введённых пользователем.</param>
        /// <returns>
        /// Перенаправление на главную страницу при успешном добавлении
        /// или повторное отображение формы при ошибках валидации.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create(TourEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var tour = new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = model.Direction!.Value,
                DepartureDate = model.DepartureDate,
                NumberNights = model.NumberNights,
                CostPerVacationer = model.CostPerVacationer,
                NumberVacationers = model.NumberVacationers,
                AvailabilityWiFi = model.AvailabilityWiFi,
                Surcharges = model.Surcharges
            };

            await TourManager.AddTourAsync(tour);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму редактирования существующего тура.
        /// </summary>
        /// <param name="id">Идентификатор редактируемого тура.</param>
        /// <returns>
        /// Представление Edit с данными тура
        /// или результат NotFound, если тур не найден.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tours = await TourManager.GetAllToursAsync();
            var tour = tours.FirstOrDefault(t => t.Id == id);

            if (tour == null)
                return NotFound();

            var model = new TourEditViewModel
            {
                Id = tour.Id,
                Direction = tour.Direction,
                DepartureDate = tour.DepartureDate,
                NumberNights = tour.NumberNights,
                CostPerVacationer = tour.CostPerVacationer,
                NumberVacationers = tour.NumberVacationers,
                AvailabilityWiFi = tour.AvailabilityWiFi,
                Surcharges = tour.Surcharges
            };

            return View(model);
        }

        /// <summary>
        /// Обрабатывает отправку формы редактирования тура.
        /// </summary>
        /// <param name="model">Обновлённые данные тура.</param>
        /// <returns>
        /// Перенаправление на главную страницу при успешном сохранении
        /// или повторное отображение формы при ошибках валидации.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Edit(TourEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var tours = await TourManager.GetAllToursAsync();
            var tour = tours.FirstOrDefault(t => t.Id == model.Id);

            if (tour == null)
                return NotFound();

            tour.Direction = model.Direction!.Value;
            tour.DepartureDate = model.DepartureDate;
            tour.NumberNights = model.NumberNights;
            tour.CostPerVacationer = model.CostPerVacationer;
            tour.NumberVacationers = model.NumberVacationers;
            tour.AvailabilityWiFi = model.AvailabilityWiFi;
            tour.Surcharges = model.Surcharges;

            await TourManager.UpdateTourAsync(tour);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу подтверждения удаления тура.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого тура.</param>
        /// <returns>
        /// Представление подтверждения удаления
        /// или результат NotFound, если тур не найден.
        /// </returns>
        public async Task<IActionResult> Delete(Guid id)
        {
            var tours = await TourManager.GetAllToursAsync();
            var tour = tours.FirstOrDefault(t => t.Id == id);

            if (tour == null)
                return NotFound();

            return View(tour);
        }

        /// <summary>
        /// Выполняет удаление тура после подтверждения пользователем.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого тура.</param>
        /// <returns>Перенаправление на главную страницу.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await TourManager.DeleteTourAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу политики конфиденциальности.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки приложения.
        /// </summary>
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
