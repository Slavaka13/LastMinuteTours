using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LastMinuteTours.Entities;
using LastMinuteTours.Services;
using LastMinuteTours.App.Infrastructure;

namespace LastMinuteTours.App
{
    /// <summary>
    /// Главная форма — список туров + статистика.
    /// </summary>
    public partial class MainForm : Form
    {
        // Сервис работы с турами
        private readonly ITourService tourService;

        // Источник данных для DataGridView
        private readonly BindingSource bindingSource = new BindingSource();

        public MainForm(ITourService tourService)
        {
            InitializeComponent();

            this.tourService = tourService ?? throw new ArgumentNullException(nameof(tourService));

            // Колонки задаём вручную, поэтому авто-генерацию отключаем
            dataGridViewTours.AutoGenerateColumns = false;

            // Формат для колонки даты
            if (dataGridViewTours.Columns.Contains("DGDepartureDate"))
                dataGridViewTours.Columns["DGDepartureDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            // Пока источник данных — пустой список
            bindingSource.DataSource = new List<TourModel>();
            dataGridViewTours.DataSource = bindingSource;

            // При загрузке формы подгружаем данные асинхронно
            this.Load += MainForm_Load;
        }

        /// <summary>
        /// Асинхронная загрузка туров и статистики при старте формы.
        /// </summary>
        private async void MainForm_Load(object? sender, EventArgs e)
        {
            try
            {
                await LoadToursAndStatsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Ошибка при загрузке туров: " + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Общий метод: подгрузить туры и пересчитать статистику.
        /// </summary>
        private async Task LoadToursAndStatsAsync()
        {
            var tours = await tourService.GetAllToursAsync(CancellationToken.None);
            bindingSource.DataSource = tours;
            bindingSource.ResetBindings(false);

            await SetStatisticsAsync();
        }

        /// <summary>
        /// Кастомное форматирование ячеек:
        /// - Direction → русские названия стран
        /// - AvailabilityWiFi → Да/Нет
        /// - TotalCost → вычисляемая общая стоимость
        /// </summary>
        private void CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var column = dataGridViewTours.Columns[e.ColumnIndex];
            var row = dataGridViewTours.Rows[e.RowIndex];

            if (row.DataBoundItem is not TourModel tour)
                return;

            // Направление
            if (column.DataPropertyName == nameof(TourModel.Direction))
            {
                e.Value = tour.Direction switch
                {
                    Direction.Turkey => "Турция",
                    Direction.Spain => "Испания",
                    Direction.Italy => "Италия",
                    Direction.France => "Франция",
                    Direction.Shushary => "Шушары",
                    _ => "Не указано"
                };
            }

            // Наличие Wi-Fi
            if (column.DataPropertyName == nameof(TourModel.AvailabilityWiFi))
            {
                e.Value = tour.AvailabilityWiFi ? "Да" : "Нет";
            }

            // Общая стоимость
            if (column.DataPropertyName == "TotalCost")
            {
                e.Value = (tour.CostPerVacationer * tour.NumberVacationers + tour.Surcharges)
                          .ToString("N2");
            }
        }

        /// <summary>Добавить новый тур.</summary>
        private async void tlStrpBtnAdd_Click(object sender, EventArgs e)
        {
            using var form = new TourForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    await tourService.AddTourAsync(form.CurrentTour, CancellationToken.None);
                    await LoadToursAndStatsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        "Ошибка при добавлении тура: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>Отредактировать выделенный тур.</summary>
        private async void tlStrpBtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTours.SelectedRows.Count == 0)
                return;

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem;

            using var form = new TourForm(tour);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    await tourService.UpdateTourAsync(form.CurrentTour, CancellationToken.None);
                    await LoadToursAndStatsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        "Ошибка при обновлении тура: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>Удалить выделенный тур.</summary>
        private async void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTours.SelectedRows.Count == 0)
                return;

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show(
                    $"Удалить тур '{tour.Direction}'?",
                    "Удаление",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await tourService.DeleteTourAsync(tour.Id, CancellationToken.None);
                await LoadToursAndStatsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Ошибка при удалении тура: " + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>Пересчёт статистики в статус-баре.</summary>
        private async Task SetStatisticsAsync()
        {
            var stats = await tourService.GetStatisticsAsync(CancellationToken.None);

            toolStrpLblTotalTours.Text =
                "Общее кол-во туров: " + stats.TotalTours;

            toolStrpLblTotalCost.Text =
                $"Общая сумма за все туры: {stats.TotalCost:N2} руб.";

            toolStrpLblToursWithSurcharges.Text =
                "Кол-во туров с доплатами: " + stats.ToursWithSurcharges;

            toolStrpLblTotalSurcharges.Text =
                $"Общая сумма доплат: {stats.TotalSurcharges:N2} руб.";
        }
    }
}
