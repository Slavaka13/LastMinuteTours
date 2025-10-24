using System.Globalization;
using System.Windows.Forms;
using LastMinuteTours.Forms;
using LastMinuteTours.Models;

namespace LastMinuteTours
{
    /// <summary>
    /// Главная форма приложения: список туров, операции добавления/редактирования/удаления и сводная статистика.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>Коллекция туров, выступающая источником данных для таблицы.</summary>
        private readonly List<TourModel> items = new();

        /// <summary>Промежуточный источник данных для связки коллекции с DataGridView.</summary>
        private readonly BindingSource bindingSource = new();

        public MainForm()
        {
            InitializeComponent();

            // Таблица описана в дизайнере — автогенерацию колонок отключаем.
            dataGridViewTours.AutoGenerateColumns = false;

            // Если есть колонка даты с DataPropertyName = "DepartureDate" — зададим формат отображения.
            if (dataGridViewTours.Columns.Contains("DepartureDate"))
                dataGridViewTours.Columns["DepartureDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            // Демо-данные
            var fmt = "dd.MM.yyyy";
            items.Add(new TourModel
            {
                Direction = Direction.Turkey,
                DepartureDate = DateTime.ParseExact("11.11.2025", fmt, CultureInfo.InvariantCulture),
                NumberNights = 1,
                CostPerVacationer = 34000.00m,
                NumberVacationers = 1,
                AvailabilityWiFi = true,
                Surcharges = 0.00m,
            });

            items.Add(new TourModel
            {
                Direction = Direction.Spain,
                DepartureDate = DateTime.ParseExact("11.10.2025", fmt, CultureInfo.InvariantCulture),
                NumberNights = 5,
                CostPerVacationer = 96000.00m,
                NumberVacationers = 2,
                AvailabilityWiFi = true,
                Surcharges = 3200.00m,
            });

            items.Add(new TourModel
            {
                Direction = Direction.Italy,
                DepartureDate = DateTime.ParseExact("10.11.2025", fmt, CultureInfo.InvariantCulture),
                NumberNights = 3,
                CostPerVacationer = 57000.00m,
                NumberVacationers = 3,
                AvailabilityWiFi = true,
                Surcharges = 4100.50m,
            });

            items.Add(new TourModel
            {
                Direction = Direction.France,
                DepartureDate = DateTime.ParseExact("12.11.2025", fmt, CultureInfo.InvariantCulture),
                NumberNights = 4,
                CostPerVacationer = 51000.00m,
                NumberVacationers = 4,
                AvailabilityWiFi = false,
                Surcharges = 0.00m,
            });

            items.Add(new TourModel
            {
                Direction = Direction.Shushary,
                DepartureDate = DateTime.ParseExact("13.05.2025", fmt, CultureInfo.InvariantCulture),
                NumberNights = 12,
                CostPerVacationer = 100.00m,
                NumberVacationers = 1,
                AvailabilityWiFi = true,
                Surcharges = 500.00m,
            });

            // Привязка источника
            bindingSource.DataSource = items;
            dataGridViewTours.DataSource = bindingSource;

            RefreshGridAndStats();
        }

        /// <summary>Кастомное форматирование ячеек таблицы (читаемые подписи для enum и bool).</summary>
        private void dataGridViewTours_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridViewTours.Columns[e.ColumnIndex];
            var row = dataGridViewTours.Rows[e.RowIndex];
            if (row.DataBoundItem is not TourModel tour) return;

            if (col.DataPropertyName == nameof(TourModel.Direction))
            {
                e.Value = tour.Direction switch
                {
                    Direction.Turkey => "Турция",
                    Direction.Spain => "Испания",
                    Direction.Italy => "Италия",
                    Direction.France => "Франция",
                    Direction.Shushary => "Шушары",
                    _ => string.Empty
                };
            }

            if (col.DataPropertyName == nameof(TourModel.AvailabilityWiFi))
                e.Value = tour.AvailabilityWiFi ? "Да" : "Нет";
        }

        /// <summary>Добавление нового тура (кнопка «Добавить»).</summary>
        private void tlStrpBtnAdd_Click(object sender, EventArgs e)
        {
            using var addForm = new TourForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(addForm.CurrentTour);
                RefreshGridAndStats();
            }
        }

        /// <summary>Редактирование выбранного тура (кнопка «Редактировать»).</summary>
        private void tlStrpBtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTours.SelectedRows.Count == 0) return;

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem!;
            using var editForm = new TourForm(tour);

            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                var updated = editForm.CurrentTour;
                var selectedTour = items.FirstOrDefault(x => x.Id == updated.Id);
                if (selectedTour != null)
                {
                    selectedTour.Direction = updated.Direction;
                    selectedTour.DepartureDate = updated.DepartureDate;
                    selectedTour.NumberNights = updated.NumberNights;
                    selectedTour.CostPerVacationer = updated.CostPerVacationer;
                    selectedTour.NumberVacationers = updated.NumberVacationers;
                    selectedTour.AvailabilityWiFi = updated.AvailabilityWiFi;
                    selectedTour.Surcharges = updated.Surcharges;

                    RefreshGridAndStats();
                }
            }
        }

        /// <summary>Удаление выбранного тура (кнопка «Удалить») с подтверждением.</summary>
        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTours.SelectedRows.Count == 0) return;

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem!;
            var selectedTour = items.FirstOrDefault(x => x.Id == tour.Id);

            if (selectedTour != null &&
                MessageBox.Show($"Удалить тур '{tour.Direction}'?",
                    "Удаление тура", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                items.Remove(selectedTour);
                RefreshGridAndStats();
            }
        }

        /// <summary>Пересчитывает и показывает сводную статистику по всем турам.</summary>
        private void SetStatistics()
        {
            toolStrpLblTotalTours.Text = $"Общее кол-во туров: {items.Count}";
            toolStrpLblTotalCost.Text = $"Общая сумма за все туры: {items.Sum(t => t.TotalCost)} руб.";
            toolStrpLblToursWithSurcharges.Text = $"Кол-во туров с доплатами: {items.Count(t => t.Surcharges > 0)}";
            toolStrpLblTotalSurcharges.Text = $"Общая сумма доплат: {items.Sum(t => t.Surcharges)}";
        }

        /// <summary>Единая точка обновления таблицы и статистики.</summary>
        private void RefreshGridAndStats()
        {
            bindingSource.ResetBindings(false);
            SetStatistics();
        }
    }
}
