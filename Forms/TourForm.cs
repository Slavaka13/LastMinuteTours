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

            targetTour = sourceTour?.Clone() ?? new TourModel();

            Text = sourceTour is null ? "Добавление тура" : "Редактирование тура";
            buttonSave.Text = sourceTour is null ? "Добавить" : "Сохранить";

            // UI init
            comboBoxDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirection.DataSource = Enum.GetValues(typeof(Direction));

            // биндинги + ErrorProvider + реактивная кнопка
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
            ValidateChildren(ValidationConstraints.Enabled);

            if (!targetTour.IsValid() || targetTour.Direction == Direction.Unknown)
            {
                if (targetTour.Direction == Direction.Unknown)
                    errorProvider1.SetError(comboBoxDirection, "Выберите направление тура");

                MessageBox.Show("Исправьте ошибки в форме перед сохранением.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void UpdateSaveButtonState()
        {
            var isValid = targetTour.IsValid() && targetTour.Direction != Direction.Unknown;
            buttonSave.Enabled = isValid;

            if (targetTour.Direction == Direction.Unknown)
                errorProvider1.SetError(comboBoxDirection, "Выберите направление тура");
            else
                errorProvider1.SetError(comboBoxDirection, string.Empty);
        }

        /// <summary>Текущее состояние редактируемого тура.</summary>
        public TourModel CurrentTour => targetTour;
    }
}
