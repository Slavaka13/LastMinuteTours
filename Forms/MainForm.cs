using LastMinuteTours.Forms;
using LastMinuteTours.Models;
using System.Windows.Forms;

namespace LastMinuteTours
{
    /// <summary>
    /// Главная форма приложения: список туров, операции добавления/редактирования/удаления и сводная статистика.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Коллекция туров, выступающая источником данных для таблицы.
        /// </summary>
        private readonly List<TourModel> items;

        /// <summary>
        /// Промежуточный источник данных для связки коллекции с DataGridView.
        /// </summary>
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Создаёт главную форму, инициализирует тестовые данные и настраивает привязки.
        /// </summary>
        public MainForm()
        {
            // Подготовка коллекции
            items = new List<TourModel>();

            // Примеры туров (демо-данные)
            items.Add(new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = Models.Direction.Turkey,
                DepartureDate = DateOnly.Parse("11.11.2025"),
                NumberNights = 1,
                CostPerVacationer = 34000.00m,
                NumberVacationers = 1,
                AvailabilityWiFi = true,
                Surcharges = 0.00m,
            });

            items.Add(new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = Models.Direction.Spain,
                DepartureDate = DateOnly.Parse("11.10.2025"),
                NumberNights = 5,
                CostPerVacationer = 96000.00m,
                NumberVacationers = 2,
                AvailabilityWiFi = true,
                Surcharges = 3200.00m,
            });

            items.Add(new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = Models.Direction.Italy,
                DepartureDate = DateOnly.Parse("10.11.2025"),
                NumberNights = 3,
                CostPerVacationer = 57000.00m,
                NumberVacationers = 3,
                AvailabilityWiFi = true,
                Surcharges = 4100.50m,
            });

            items.Add(new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = Models.Direction.France,
                DepartureDate = DateOnly.Parse("12.11.2025"),
                NumberNights = 4,
                CostPerVacationer = 51000.00m,
                NumberVacationers = 4,
                AvailabilityWiFi = false,
                Surcharges = 0.00m,
            });

            items.Add(new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = Models.Direction.Shushary,
                DepartureDate = DateOnly.Parse("13.05.2025"),
                NumberNights = 12,
                CostPerVacationer = 100.00m,
                NumberVacationers = 0,
                AvailabilityWiFi = true,
                Surcharges = 500.00m,
            });

            InitializeComponent();

            dataGridViewTours.AutoGenerateColumns = false; // Колонки описаны в дизайнере, автогенерацию отключаем.

            bindingSource.DataSource = items;    // Источник привязки — наша коллекция
            dataGridViewTours.DataSource = bindingSource; // Привязываем таблицу к BindingSource

            SetStatistics(); // Рассчитать и отобразить сводные показатели
        }

        /// <summary>
        /// Кастомное форматирование ячеек таблицы (читаемые подписи для enum и bool).
        /// </summary>
        private void dataGridViewTours_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Игнорируем заголовки и невалидные индексы
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Ссылки на текущие колонку и строку
            var col = dataGridViewTours.Columns[e.ColumnIndex];
            var row = dataGridViewTours.Rows[e.RowIndex];

            // Если строка не привязана к объекту — форматировать нечего
            if (row.DataBoundItem == null)
                return;

            var tour = (TourModel)dataGridViewTours.Rows[e.RowIndex].DataBoundItem; // Объект тура текущей строки

            // Для Direction выводим локализованное название вместо значения enum
            if (col.DataPropertyName == nameof(TourModel.Direction))
            {
                switch (tour.Direction)
                {
                    case Direction.Turkey:
                        e.Value = "Турция";
                        break;
                    case Direction.Spain:
                        e.Value = "Испания";
                        break;
                    case Direction.Italy:
                        e.Value = "Италия";
                        break;
                    case Direction.France:
                        e.Value = "Франция";
                        break;
                    case Direction.Shushary:
                        e.Value = "Шушары";
                        break;
                    default:
                        e.Value = string.Empty;
                        break;
                }
            }

            // Для AvailabilityWiFi показываем "Да"/"Нет" вместо true/false
            if (col.DataPropertyName == nameof(TourModel.AvailabilityWiFi))
            {
                e.Value = tour.AvailabilityWiFi ? "Да" : "Нет";
            }
        }

        /// <summary>
        /// Пересчитывает и показывает сводную статистику по всем турам.
        /// </summary>
        private void SetStatistics()
        {
            toolStrpLblTotalTours.Text = $"Общее кол-во туров: {items.Count}";
            toolStrpLblTotalCost.Text = $"Общая сумма за все туры: {items.Sum(t => t.TotalCost)} руб.";
            toolStrpLblToursWithSurcharges.Text = $"Кол-во туров с доплатами: {items.Count(t => t.Surcharges > 0)}";
            toolStrpLblTotalSurcharges.Text = $"Общая сумма доплат: {items.Sum(t => t.Surcharges)}";
        }

        /// <summary>
        /// Добавление нового тура (кнопка «Добавить»): открытие формы, сохранение и обновление списка/статистики.
        /// </summary>
        private void tlStrpBtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new TourForm(); // Форма в режиме добавления

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(addForm.CurrentTour);        // Сохраняем новый тур
                bindingSource.ResetBindings(false);    // Обновляем таблицу
                SetStatistics();                       // Обновляем сводные данные
            }
        }

        /// <summary>
        /// Редактирование выбранного тура (кнопка «Редактировать»).
        /// </summary>
        private void tlStrpBtnEdit_Click(object sender, EventArgs e)
        {
            // Нечего редактировать, если ничего не выделено
            if (dataGridViewTours.SelectedRows.Count == 0)
            {
                return;
            }

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem; // Выбранный тур
            var editForm = new TourForm(tour); 

            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                // Находим исходный объект в коллекции и переносим изменения
                var selectedTour = items.FirstOrDefault(x => x.Id == editForm.CurrentTour.Id);
                if (selectedTour != null)
                {
                    selectedTour.Direction = editForm.CurrentTour.Direction;
                    selectedTour.DepartureDate = editForm.CurrentTour.DepartureDate;
                    selectedTour.NumberNights = editForm.CurrentTour.NumberNights;
                    selectedTour.CostPerVacationer = editForm.CurrentTour.CostPerVacationer;
                    selectedTour.NumberVacationers = editForm.CurrentTour.NumberVacationers;
                    selectedTour.AvailabilityWiFi = editForm.CurrentTour.AvailabilityWiFi;
                    selectedTour.Surcharges = editForm.CurrentTour.Surcharges;

                    bindingSource.ResetBindings(false); 
                    SetStatistics();                 
                }
            }
        }

        /// <summary>
        /// Удаление выбранного тура (кнопка «Удалить») с подтверждением.
        /// </summary>
        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewTours.SelectedRows.Count == 0)
            {
                return;
            }

            var tour = (TourModel)dataGridViewTours.SelectedRows[0].DataBoundItem; // Выбранный тур
            var selectedTour = items.FirstOrDefault(x => x.Id == tour.Id);        // Поиск в коллекции

            // Если нашли и пользователь подтвердил — удаляем
            if (selectedTour != null &&
                MessageBox.Show($"Удалить тур '{tour.Direction}'?",
                "Удаление тура",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                items.Remove(selectedTour);
                bindingSource.ResetBindings(false); 
                SetStatistics();                    
            }
        }

        private void dataGridViewTours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
