using System.Windows.Forms;
using LastMinuteTours.Infrastructure;
using LastMinuteTours.Models;

namespace LastMinuteTours.Forms
{
    /// <summary>Форма создания/редактирования тура.</summary>
    public partial class TourForm : Form
    {
        private readonly TourModel targetTour = null!;

        public TourForm(TourModel? sourceTour = null)
        {
            InitializeComponent();

            // Если передали тур — клонируем; если нет — создаём новый
            targetTour = sourceTour?.Clone() ?? new TourModel();

            Text = sourceTour is null ? "Добавление тура" : "Редактирование тура";
            buttonSave.Text = sourceTour is null ? "Добавить" : "Сохранить";

            // Настройка ComboBox
            comboBoxDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirection.DataSource = Enum.GetValues(typeof(Direction));

            // Если создаём новый тур — оставляем пустой выбор
            if (sourceTour is null)
                comboBoxDirection.SelectedIndex = -1;

            // Привязки с поддержкой ErrorProvider и автообновлением кнопки
            comboBoxDirection.AddBinding(x => x.SelectedItem, targetTour, x => x.Direction, errorProvider1, UpdateSaveButtonState);
            dateTimePickerDepartureDate.AddBinding(x => x.Value, targetTour, x => x.DepartureDate, errorProvider1, UpdateSaveButtonState);
            numericUpDownNumberNights.AddBinding(x => x.Value, targetTour, x => x.NumberNights, errorProvider1, UpdateSaveButtonState);
            textBoxCostPerVacationer.AddBinding(x => x.Text, targetTour, x => x.CostPerVacationer, errorProvider1, UpdateSaveButtonState);
            numericUpDownNumberVacationers.AddBinding(x => x.Value, targetTour, x => x.NumberVacationers, errorProvider1, UpdateSaveButtonState);
            textBoxSurcharges.AddBinding(x => x.Text, targetTour, x => x.Surcharges, errorProvider1, UpdateSaveButtonState);
            checkBoxAvailabilityWiFiYes.AddBinding(x => x.Checked, targetTour, x => x.AvailabilityWiFi, null, UpdateSaveButtonState);

            UpdateSaveButtonState();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Запуск валидации всех контролов
            ValidateChildren(ValidationConstraints.Enabled);

            // Проверка модели
            if (!targetTour.IsValid())
            {
                MessageBox.Show("Исправьте ошибки в форме перед сохранением.",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>Активирует кнопку, если все поля валидны.</summary>
        private void UpdateSaveButtonState()
        {
            buttonSave.Enabled = targetTour.IsValid();
        }

        /// <summary>Текущее состояние редактируемого тура.</summary>
        public TourModel CurrentTour => targetTour;
    }
}
