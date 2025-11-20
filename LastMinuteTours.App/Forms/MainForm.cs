using System;
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

            this.tourService = tourService;

            // Колонки задаём вручную, поэтому авто-генерацию отключаем
            dataGridViewTours.AutoGenerateColumns = false;

            // Формат для колонки даты
            if (dataGridViewTours.Columns.Contains("DGDepartureDate"))
                dataGridViewTours.Columns["DGDepartureDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            // Привязка списка туров к гриду
            bindingSource.DataSource = tourService.GetAllTours();
            dataGridViewTours.DataSource = bindingSource;

            RefreshGridAndStats();
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
        private void tlStrpBtnAdd_Click(object sender, EventArgs e)
        {
            using var form = new TourForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                tourService.AddTour(form.CurrentTour);
                RefreshGridAndStats();
            }
        }

        /// <summary>Отредактировать выделенный тур.</summary>
        private void tlStrpBtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTours.SelectedRows.Count == 0)
                return;

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem;

            using var form = new TourForm(tour);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                tourService.UpdateTour(form.CurrentTour);
                RefreshGridAndStats();
            }
        }

        /// <summary>Удалить выделенный тур.</summary>
        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTours.SelectedRows.Count == 0)
                return;

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show(
                    $"Удалить тур '{tour.Direction}'?",
                    "Удаление",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tourService.DeleteTour(tour.Id);
                RefreshGridAndStats();
            }
        }

        /// <summary>Пересчёт статистики в статус-баре.</summary>
        private void SetStatistics()
        {
            toolStrpLblTotalTours.Text =
                "Общее кол-во туров: " + tourService.GetTotalTours();

            toolStrpLblTotalCost.Text =
                $"Общая сумма за все туры: {tourService.GetTotalCost():N2} руб.";

            toolStrpLblToursWithSurcharges.Text =
                "Кол-во туров с доплатами: " + tourService.GetToursWithSurcharges();

            toolStrpLblTotalSurcharges.Text =
                $"Общая сумма доплат: {tourService.GetTotalSurcharges():N2} руб.";
        }

        /// <summary>Обновить грид и статистику.</summary>
        private void RefreshGridAndStats()
        {
            bindingSource.ResetBindings(false);
            SetStatistics();
        }
    }
}
