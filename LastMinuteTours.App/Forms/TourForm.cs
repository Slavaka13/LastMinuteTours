using System;
using System.Windows.Forms;
using LastMinuteTours.Entities;
using LastMinuteTours.App.Infrastructure;

namespace LastMinuteTours.App
{
    /// <summary>Форма создания/редактирования тура.</summary>
    public partial class TourForm : Form
    {
        private readonly TourModel targetTour;

        /// <summary>
        /// Если sourceTour == null → создаём новый тур.
        /// Если не null → редактируем копию существующего.
        /// </summary>
        public TourForm(TourModel? sourceTour = null)
        {
            InitializeComponent();

            if (sourceTour == null)
            {
                targetTour = new TourModel();
            }
            else
            {
                // Ручное "клонирование"
                targetTour = new TourModel
                {
                    Id = sourceTour.Id,
                    Direction = sourceTour.Direction,
                    DepartureDate = sourceTour.DepartureDate,
                    NumberNights = sourceTour.NumberNights,
                    CostPerVacationer = sourceTour.CostPerVacationer,
                    NumberVacationers = sourceTour.NumberVacationers,
                    AvailabilityWiFi = sourceTour.AvailabilityWiFi,
                    Surcharges = sourceTour.Surcharges
                };
            }

            Text = sourceTour == null ? "Добавление тура" : "Редактирование тура";
            buttonSave.Text = sourceTour == null ? "Добавить" : "Сохранить";

            comboBoxDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirection.DataSource = Enum.GetValues(typeof(Direction));

            if (sourceTour == null)
                comboBoxDirection.SelectedIndex = -1;


            // Привязка + валидация
            comboBoxDirection.AddBinding(x => x.SelectedItem!, targetTour, x => x.Direction, errorProvider1, UpdateSaveButtonState);
            dateTimePickerDepartureDate.AddBinding(x => x.Value, targetTour, x => x.DepartureDate, errorProvider1, UpdateSaveButtonState);
            numericUpDownNumberNights.AddBinding(x => x.Value, targetTour, x => x.NumberNights, errorProvider1, UpdateSaveButtonState);
            textBoxCostPerVacationer.AddBinding(x => x.Text, targetTour, x => x.CostPerVacationer, errorProvider1, UpdateSaveButtonState);
            numericUpDownNumberVacationers.AddBinding(x => x.Value, targetTour, x => x.NumberVacationers, errorProvider1, UpdateSaveButtonState);
            textBoxSurcharges.AddBinding(x => x.Text, targetTour, x => x.Surcharges, errorProvider1, UpdateSaveButtonState);
            checkBoxAvailabilityWiFiYes.AddBinding(x => x.Checked, targetTour, x => x.AvailabilityWiFi, null!, UpdateSaveButtonState);

            UpdateSaveButtonState();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);

            if (!targetTour.IsValid())
            {
                MessageBox.Show(
                    "Исправьте ошибки в форме перед сохранением.",
                    "Ошибка валидации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
            buttonSave.Enabled = targetTour.IsValid();
        }

        public TourModel CurrentTour => targetTour;
    }
}
