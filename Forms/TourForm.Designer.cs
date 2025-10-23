namespace LastMinuteTours.Forms
{
    partial class TourForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelDirection = new Label();
            textBoxCostPerVacationer = new TextBox();
            comboBoxDirection = new ComboBox();
            labelDepartureDate = new Label();
            labelNumberNights = new Label();
            labelCostPerVacationer = new Label();
            labelNumberVacationers = new Label();
            labelSurcharges = new Label();
            numericUpDownNumberVacationers = new NumericUpDown();
            textBoxSurcharges = new TextBox();
            numericUpDownNumberNights = new NumericUpDown();
            dateTimePickerDepartureDate = new DateTimePicker();
            checkBoxAvailabilityWiFiYes = new CheckBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberVacationers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberNights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // labelDirection
            // 
            labelDirection.AutoSize = true;
            labelDirection.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelDirection.ForeColor = Color.White;
            labelDirection.Location = new Point(23, 66);
            labelDirection.Name = "labelDirection";
            labelDirection.Size = new Size(116, 21);
            labelDirection.TabIndex = 0;
            labelDirection.Text = "Направление:";
            // 
            // textBoxCostPerVacationer
            // 
            textBoxCostPerVacationer.Font = new Font("Segoe UI", 11.25F);
            textBoxCostPerVacationer.Location = new Point(206, 236);
            textBoxCostPerVacationer.Name = "textBoxCostPerVacationer";
            textBoxCostPerVacationer.Size = new Size(213, 27);
            textBoxCostPerVacationer.TabIndex = 1;
            textBoxCostPerVacationer.Validating += textBoxCostPerVacationer_Validating;
            // 
            // comboBoxDirection
            // 
            comboBoxDirection.Font = new Font("Segoe UI", 11.25F);
            comboBoxDirection.FormattingEnabled = true;
            comboBoxDirection.Location = new Point(206, 59);
            comboBoxDirection.Name = "comboBoxDirection";
            comboBoxDirection.Size = new Size(213, 28);
            comboBoxDirection.TabIndex = 2;
            comboBoxDirection.Validating += comboBoxDirection_Validating;
            // 
            // labelDepartureDate
            // 
            labelDepartureDate.AutoSize = true;
            labelDepartureDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelDepartureDate.ForeColor = Color.White;
            labelDepartureDate.Location = new Point(23, 126);
            labelDepartureDate.Name = "labelDepartureDate";
            labelDepartureDate.Size = new Size(107, 21);
            labelDepartureDate.TabIndex = 3;
            labelDepartureDate.Text = "Дата вылета:";
            // 
            // labelNumberNights
            // 
            labelNumberNights.AutoSize = true;
            labelNumberNights.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNumberNights.ForeColor = Color.White;
            labelNumberNights.Location = new Point(23, 175);
            labelNumberNights.Name = "labelNumberNights";
            labelNumberNights.Size = new Size(156, 21);
            labelNumberNights.TabIndex = 4;
            labelNumberNights.Text = "Количество ночей:";
            // 
            // labelCostPerVacationer
            // 
            labelCostPerVacationer.AutoSize = true;
            labelCostPerVacationer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelCostPerVacationer.ForeColor = Color.White;
            labelCostPerVacationer.Location = new Point(23, 221);
            labelCostPerVacationer.Name = "labelCostPerVacationer";
            labelCostPerVacationer.Size = new Size(162, 42);
            labelCostPerVacationer.TabIndex = 5;
            labelCostPerVacationer.Text = "Стоимость за\r\nотдыхающего (руб):";
            // 
            // labelNumberVacationers
            // 
            labelNumberVacationers.AutoSize = true;
            labelNumberVacationers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNumberVacationers.ForeColor = Color.White;
            labelNumberVacationers.Location = new Point(23, 289);
            labelNumberVacationers.Name = "labelNumberVacationers";
            labelNumberVacationers.Size = new Size(114, 42);
            labelNumberVacationers.TabIndex = 6;
            labelNumberVacationers.Text = "Количество \r\nотдыхающих:";
            // 
            // labelSurcharges
            // 
            labelSurcharges.AutoSize = true;
            labelSurcharges.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelSurcharges.ForeColor = Color.White;
            labelSurcharges.Location = new Point(23, 362);
            labelSurcharges.Name = "labelSurcharges";
            labelSurcharges.Size = new Size(122, 21);
            labelSurcharges.TabIndex = 8;
            labelSurcharges.Text = "Доплаты (руб):";
            // 
            // numericUpDownNumberVacationers
            // 
            numericUpDownNumberVacationers.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDownNumberVacationers.Location = new Point(206, 304);
            numericUpDownNumberVacationers.Name = "numericUpDownNumberVacationers";
            numericUpDownNumberVacationers.Size = new Size(213, 27);
            numericUpDownNumberVacationers.TabIndex = 9;
            numericUpDownNumberVacationers.Validating += numericUpDownNumberVacationers_Validating;
            // 
            // textBoxSurcharges
            // 
            textBoxSurcharges.Font = new Font("Segoe UI", 11.25F);
            textBoxSurcharges.Location = new Point(206, 356);
            textBoxSurcharges.Name = "textBoxSurcharges";
            textBoxSurcharges.Size = new Size(213, 27);
            textBoxSurcharges.TabIndex = 10;
            textBoxSurcharges.Validating += textBoxSurcharges_Validating;
            // 
            // numericUpDownNumberNights
            // 
            numericUpDownNumberNights.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDownNumberNights.Location = new Point(206, 169);
            numericUpDownNumberNights.Name = "numericUpDownNumberNights";
            numericUpDownNumberNights.Size = new Size(213, 27);
            numericUpDownNumberNights.TabIndex = 11;
            numericUpDownNumberNights.Validating += numericUpDownNumberNights_Validating;
            // 
            // dateTimePickerDepartureDate
            // 
            dateTimePickerDepartureDate.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePickerDepartureDate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePickerDepartureDate.Location = new Point(206, 120);
            dateTimePickerDepartureDate.Name = "dateTimePickerDepartureDate";
            dateTimePickerDepartureDate.Size = new Size(213, 27);
            dateTimePickerDepartureDate.TabIndex = 12;
            dateTimePickerDepartureDate.Validating += dateTimePickerDepartureDate_Validating;
            // 
            // checkBoxAvailabilityWiFiYes
            // 
            checkBoxAvailabilityWiFiYes.AutoSize = true;
            checkBoxAvailabilityWiFiYes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBoxAvailabilityWiFiYes.ForeColor = Color.White;
            checkBoxAvailabilityWiFiYes.Location = new Point(206, 405);
            checkBoxAvailabilityWiFiYes.Name = "checkBoxAvailabilityWiFiYes";
            checkBoxAvailabilityWiFiYes.Size = new Size(100, 25);
            checkBoxAvailabilityWiFiYes.TabIndex = 13;
            checkBoxAvailabilityWiFiYes.Text = "Есть Wi-Fi";
            checkBoxAvailabilityWiFiYes.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSave.Location = new Point(206, 460);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(213, 32);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Добавить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.Location = new Point(576, 12);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(117, 32);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // TourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(721, 686);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(checkBoxAvailabilityWiFiYes);
            Controls.Add(dateTimePickerDepartureDate);
            Controls.Add(numericUpDownNumberNights);
            Controls.Add(textBoxSurcharges);
            Controls.Add(numericUpDownNumberVacationers);
            Controls.Add(labelSurcharges);
            Controls.Add(labelNumberVacationers);
            Controls.Add(labelCostPerVacationer);
            Controls.Add(labelNumberNights);
            Controls.Add(labelDepartureDate);
            Controls.Add(comboBoxDirection);
            Controls.Add(textBoxCostPerVacationer);
            Controls.Add(labelDirection);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TourForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактор тура";
            Load += TourForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberVacationers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberNights).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDirection;
        private TextBox textBoxCostPerVacationer;
        private ComboBox comboBoxDirection;
        private Label labelDepartureDate;
        private Label labelNumberNights;
        private Label labelCostPerVacationer;
        private Label labelNumberVacationers;
        private Label labelSurcharges;
        private NumericUpDown numericUpDownNumberVacationers;
        private TextBox textBoxSurcharges;
        private NumericUpDown numericUpDownNumberNights;
        private DateTimePicker dateTimePickerDepartureDate;
        private CheckBox checkBoxAvailabilityWiFiYes;
        private Button buttonSave;
        private Button buttonCancel;
        private ErrorProvider errorProvider1;
    }
}