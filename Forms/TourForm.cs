using System.Windows.Forms;
using LastMinuteTours.Infrostructure;
using LastMinuteTours.Models;

namespace LastMinuteTours.Forms
{
    /// <summary>
    /// Форма создания или редактирования данных тура.
    /// </summary>
    public partial class TourForm : Form
    {
        /// <summary>
        /// Текущая модель тура, с которой работает форма.
        /// </summary>
        private readonly TourModel targetTour;

        /// <summary>
        /// Инициализирует форму. 
        /// Если передан <paramref name="sourceTour"/>, запускается режим редактирования, иначе — добавления.
        /// </summary>
        public TourForm(TourModel? sourceTour = null)
        {
            InitializeComponent();

            if (sourceTour != null) // Режим редактирования
            {
                targetTour = new TourModel
                {
                    Id = sourceTour.Id,
                    Direction = sourceTour.Direction,
                    DepartureDate = sourceTour.DepartureDate,
                    NumberNights = sourceTour.NumberNights,
                    CostPerVacationer = sourceTour.CostPerVacationer,
                    NumberVacationers = sourceTour.NumberVacationers,
                    AvailabilityWiFi = sourceTour.AvailabilityWiFi,
                    Surcharges = sourceTour.Surcharges,
                };
                this.Text = "Редактирование тура";
                buttonSave.Text = "Сохранить";
            }
            else // Режим добавления
            {
                targetTour = new TourModel
                {
                    Id = Guid.NewGuid(),
                    Direction = Direction.Unknown,
                    DepartureDate = DateOnly.FromDateTime(DateTime.Now),
                    NumberNights = 0,
                    CostPerVacationer = 0.00m,
                    NumberVacationers = 0,
                    AvailabilityWiFi = false,
                    Surcharges = 0.00m,
                };
                this.Text = "Добавление тура";
                buttonSave.Text = "Добавить";
            }

            // Привязки и подготовка контролов
            comboBoxDirection.DataSource = Enum.GetValues(typeof(Direction));
            var dateTimePickerBinding = new Binding("Value", targetTour, "DepartureDate");
            dateTimePickerBinding.Format += new ConvertEventHandler(DateOnlyToDateTime!);
            dateTimePickerBinding.Parse += new ConvertEventHandler(DateTimeTodateOnly!);
            dateTimePickerDepartureDate.DataBindings.Add(dateTimePickerBinding);

            // Привязки с поддержкой ErrorProvider
            comboBoxDirection.AddBinding(x => x.SelectedItem, targetTour, x => x.Direction);
            numericUpDownNumberNights.AddBinding(x => x.Value, targetTour, x => x.NumberNights, errorProvider1);
            textBoxCostPerVacationer.AddBinding(x => x.Text, targetTour, x => x.CostPerVacationer, errorProvider1);
            numericUpDownNumberVacationers.AddBinding(x => x.Value, targetTour, x => x.NumberVacationers, errorProvider1);
            textBoxSurcharges.AddBinding(x => x.Text, targetTour, x => x.Surcharges, errorProvider1);
            checkBoxAvailabilityWiFiYes.AddBinding(x => x.Checked, targetTour, x => x.AvailabilityWiFi);

            // Валидация при смене направления
            comboBoxDirection.SelectedIndexChanged += (s, e) => ValidateForm();

            // Начальное состояние кнопки сохранения
            UpdateSaveButtonState();
        }

        /// <summary>
        /// Преобразует DateOnly в DateTime для корректного отображения в DateTimePicker.
        /// </summary>
        private void DateOnlyToDateTime(object sender, ConvertEventArgs e)
        {
            // Только если целевой тип DateTime и исходное значение — DateOnly
            if (e.DesiredType == typeof(DateTime) && e.Value is DateOnly)
            {
                var dateOnly = (DateOnly)e.Value;
                e.Value = new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day); // Время обнуляем
            }
        }

        /// <summary>
        /// Преобразует DateTime в DateOnly для сохранения в модели.
        /// </summary>
        private void DateTimeTodateOnly(object sender, ConvertEventArgs e)
        {
            // Только если целевой тип DateOnly и исходное значение — DateTime
            if (e.DesiredType == typeof(DateOnly) && e.Value is DateTime)
            {
                e.Value = DateOnly.FromDateTime((DateTime)e.Value); // Отбрасываем время
            }
        }

        /// <summary>
        /// Обработчик кнопки "Сохранить/Добавить".
        /// Выполняет валидацию и закрывает форму с результатом OK при успехе.
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Явно запускаем валидацию дочерних контролов
            ValidateChildren(ValidationConstraints.Enabled);

            // Проверяем модель целиком
            if (!targetTour.IsValid())
            {
                MessageBox.Show("Исправьте ошибки в форме перед сохранением.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Всё ок — возвращаем OK и закрываем форму
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Обработчик кнопки "Отмена".
        /// Закрывает форму с результатом Cancel.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Проверка выбора направления тура.
        /// </summary>
        private void comboBoxDirection_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateForm();
        }

        /// <summary>
        /// Проверка корректности даты вылета.
        /// </summary>
        private void dateTimePickerDepartureDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateForm();
        }

        /// <summary>
        /// Проверка количества ночей.
        /// </summary>
        private void numericUpDownNumberNights_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateForm();
        }

        /// <summary>
        /// Проверка стоимости на одного отдыхающего.
        /// </summary>
        private void textBoxCostPerVacationer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateForm();
        }

        /// <summary>
        /// Проверка количества отдыхающих.
        /// </summary>
        private void numericUpDownNumberVacationers_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateForm();
        }

        /// <summary>
        /// Проверка суммы доплат.
        /// </summary>
        private void textBoxSurcharges_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateForm();
        }

        /// <summary>
        /// Комплексная проверка валидности формы и связанных полей.
        /// </summary>
        private void ValidateForm()
        {
            UpdateSaveButtonState();
        }

        /// <summary>
        /// Включает/отключает кнопку сохранения в зависимости от валидности данных.
        /// </summary>
        private void UpdateSaveButtonState()
        {
            // Все поля должны быть валидны, а направление — выбрано
            bool isValid = targetTour.IsValid() &&
                          targetTour.Direction != Direction.Unknown;

            buttonSave.Enabled = isValid;

            if (!isValid)
            {
                // Отдельно подсвечиваем незаполненное направление
                if (targetTour.Direction == Direction.Unknown)
                {
                    errorProvider1.SetError(comboBoxDirection, "Выберите направление тура");
                }
                else
                {
                    errorProvider1.SetError(comboBoxDirection, string.Empty);
                }
            }
        }

        private void TourForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Возвращает текущее состояние редактируемого тура.
        /// </summary>
        public TourModel CurrentTour => targetTour;
    }
}
