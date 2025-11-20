using System.ComponentModel;
using System.Windows.Forms;

namespace LastMinuteTours.App
{
    partial class TourForm
    {
        private IContainer components = null;

        private ComboBox comboBoxDirection;
        private DateTimePicker dateTimePickerDepartureDate;
        private NumericUpDown numericUpDownNumberNights;
        private TextBox textBoxCostPerVacationer;
        private NumericUpDown numericUpDownNumberVacationers;
        private TextBox textBoxSurcharges;
        private CheckBox checkBoxAvailabilityWiFiYes;
        private Button buttonSave;
        private Button buttonCancel;
        private ErrorProvider errorProvider1;

        private Label labelDirection;
        private Label labelDepartureDate;
        private Label labelNights;
        private Label labelCostPerVacationer;
        private Label labelVacationers;
        private Label labelSurcharges;
        private Label labelWifi;

        /// <summary>
        /// Освобождение ресурсов.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Инициализация визуальных компонентов.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            comboBoxDirection = new ComboBox();
            dateTimePickerDepartureDate = new DateTimePicker();
            numericUpDownNumberNights = new NumericUpDown();
            textBoxCostPerVacationer = new TextBox();
            numericUpDownNumberVacationers = new NumericUpDown();
            textBoxSurcharges = new TextBox();
            checkBoxAvailabilityWiFiYes = new CheckBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            labelDirection = new Label();
            labelDepartureDate = new Label();
            labelNights = new Label();
            labelCostPerVacationer = new Label();
            labelVacationers = new Label();
            labelSurcharges = new Label();
            labelWifi = new Label();
            ((ISupportInitialize)numericUpDownNumberNights).BeginInit();
            ((ISupportInitialize)numericUpDownNumberVacationers).BeginInit();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxDirection
            // 
            comboBoxDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirection.Location = new System.Drawing.Point(180, 15);
            comboBoxDirection.Name = "comboBoxDirection";
            comboBoxDirection.Size = new System.Drawing.Size(250, 23);
            // 
            // dateTimePickerDepartureDate
            // 
            dateTimePickerDepartureDate.Location = new System.Drawing.Point(180, 50);
            dateTimePickerDepartureDate.Name = "dateTimePickerDepartureDate";
            dateTimePickerDepartureDate.Size = new System.Drawing.Size(250, 23);
            // 
            // numericUpDownNumberNights
            // 
            numericUpDownNumberNights.Location = new System.Drawing.Point(180, 85);
            numericUpDownNumberNights.Minimum = 1;
            numericUpDownNumberNights.Maximum = 365;
            numericUpDownNumberNights.Name = "numericUpDownNumberNights";
            numericUpDownNumberNights.Size = new System.Drawing.Size(120, 23);
            // 
            // textBoxCostPerVacationer
            // 
            textBoxCostPerVacationer.Location = new System.Drawing.Point(180, 120);
            textBoxCostPerVacationer.Name = "textBoxCostPerVacationer";
            textBoxCostPerVacationer.Size = new System.Drawing.Size(120, 23);
            // 
            // numericUpDownNumberVacationers
            // 
            numericUpDownNumberVacationers.Location = new System.Drawing.Point(180, 155);
            numericUpDownNumberVacationers.Minimum = 1;
            numericUpDownNumberVacationers.Maximum = 1000;
            numericUpDownNumberVacationers.Name = "numericUpDownNumberVacationers";
            numericUpDownNumberVacationers.Size = new System.Drawing.Size(120, 23);
            // 
            // textBoxSurcharges
            // 
            textBoxSurcharges.Location = new System.Drawing.Point(180, 190);
            textBoxSurcharges.Name = "textBoxSurcharges";
            textBoxSurcharges.Size = new System.Drawing.Size(120, 23);
            // 
            // checkBoxAvailabilityWiFiYes
            // 
            checkBoxAvailabilityWiFiYes.Location = new System.Drawing.Point(180, 225);
            checkBoxAvailabilityWiFiYes.Name = "checkBoxAvailabilityWiFiYes";
            checkBoxAvailabilityWiFiYes.Size = new System.Drawing.Size(50, 24);
            checkBoxAvailabilityWiFiYes.Text = "Да";
            checkBoxAvailabilityWiFiYes.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(180, 270);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(110, 30);
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(320, 270);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(110, 30);
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // labels
            // 
            labelDirection.AutoSize = true;
            labelDirection.Location = new System.Drawing.Point(20, 18);
            labelDirection.Text = "Направление:";

            labelDepartureDate.AutoSize = true;
            labelDepartureDate.Location = new System.Drawing.Point(20, 54);
            labelDepartureDate.Text = "Дата вылета:";

            labelNights.AutoSize = true;
            labelNights.Location = new System.Drawing.Point(20, 89);
            labelNights.Text = "Кол-во ночей:";

            labelCostPerVacationer.AutoSize = true;
            labelCostPerVacationer.Location = new System.Drawing.Point(20, 124);
            labelCostPerVacationer.Text = "Цена за отдыхающего:";

            labelVacationers.AutoSize = true;
            labelVacationers.Location = new System.Drawing.Point(20, 159);
            labelVacationers.Text = "Кол-во отдыхающих:";

            labelSurcharges.AutoSize = true;
            labelSurcharges.Location = new System.Drawing.Point(20, 194);
            labelSurcharges.Text = "Доплаты (руб):";

            labelWifi.AutoSize = true;
            labelWifi.Location = new System.Drawing.Point(20, 229);
            labelWifi.Text = "Wi-Fi:";
            // 
            // TourForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(460, 320);
            Controls.Add(labelDirection);
            Controls.Add(labelDepartureDate);
            Controls.Add(labelNights);
            Controls.Add(labelCostPerVacationer);
            Controls.Add(labelVacationers);
            Controls.Add(labelSurcharges);
            Controls.Add(labelWifi);
            Controls.Add(comboBoxDirection);
            Controls.Add(dateTimePickerDepartureDate);
            Controls.Add(numericUpDownNumberNights);
            Controls.Add(textBoxCostPerVacationer);
            Controls.Add(numericUpDownNumberVacationers);
            Controls.Add(textBoxSurcharges);
            Controls.Add(checkBoxAvailabilityWiFiYes);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TourForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Тур";
            ((ISupportInitialize)numericUpDownNumberNights).EndInit();
            ((ISupportInitialize)numericUpDownNumberVacationers).EndInit();
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
