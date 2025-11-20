namespace LastMinuteTours.App

{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewTours;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnAdd;
        private System.Windows.Forms.ToolStripButton tlStrpBtnEdit;
        private System.Windows.Forms.ToolStripButton tlStrpBtnDelete;
        private System.Windows.Forms.StatusStrip statusStripRegistry;
        private System.Windows.Forms.ToolStripStatusLabel toolStrpLblTotalTours;
        private System.Windows.Forms.ToolStripStatusLabel toolStrpLblTotalCost;
        private System.Windows.Forms.ToolStripStatusLabel toolStrpLblToursWithSurcharges;
        private System.Windows.Forms.ToolStripStatusLabel toolStrpLblTotalSurcharges;

        private System.Windows.Forms.DataGridViewTextBoxColumn DGDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDepartureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNumberNights;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCostPerVacationer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNumberVacationers;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGAvailabilityWiFi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSurcharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTotalCost;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            dataGridViewTours = new DataGridView();
            DGDirection = new DataGridViewTextBoxColumn();
            DGDepartureDate = new DataGridViewTextBoxColumn();
            DGNumberNights = new DataGridViewTextBoxColumn();
            DGCostPerVacationer = new DataGridViewTextBoxColumn();
            DGNumberVacationers = new DataGridViewTextBoxColumn();
            DGAvailabilityWiFi = new DataGridViewTextBoxColumn();
            DGSurcharges = new DataGridViewTextBoxColumn();
            DGTotalCost = new DataGridViewTextBoxColumn();

            toolStrip1 = new ToolStrip();
            tlStrpBtnAdd = new ToolStripButton();
            tlStrpBtnEdit = new ToolStripButton();
            tlStrpBtnDelete = new ToolStripButton();

            statusStripRegistry = new StatusStrip();
            toolStrpLblTotalTours = new ToolStripStatusLabel();
            toolStrpLblTotalCost = new ToolStripStatusLabel();
            toolStrpLblToursWithSurcharges = new ToolStripStatusLabel();
            toolStrpLblTotalSurcharges = new ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).BeginInit();
            toolStrip1.SuspendLayout();
            statusStripRegistry.SuspendLayout();
            SuspendLayout();

          
            toolStrip1.BackColor = Color.SteelBlue;
            toolStrip1.Dock = DockStyle.Top;
            toolStrip1.Items.AddRange(new ToolStripItem[]
            {
        tlStrpBtnAdd,
        tlStrpBtnEdit,
        tlStrpBtnDelete
            });
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1050, 25);

            // Кнопка "Добавить"
            tlStrpBtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlStrpBtnAdd.Name = "tlStrpBtnAdd";
            tlStrpBtnAdd.Text = "Добавить";
            tlStrpBtnAdd.Click += tlStrpBtnAdd_Click;

            // Кнопка "Редактировать"
            tlStrpBtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlStrpBtnEdit.Name = "tlStrpBtnEdit";
            tlStrpBtnEdit.Text = "Редактировать";
            tlStrpBtnEdit.Click += tlStrpBtnEdit_Click;

            // Кнопка "Удалить"
            tlStrpBtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Text = "Удалить";
            tlStrpBtnDelete.Click += tlStrpBtnDelete_Click;

            // (таблица туров)
            dataGridViewTours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTours.BackgroundColor = Color.SteelBlue;
            dataGridViewTours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTours.Columns.AddRange(new DataGridViewColumn[]
            {
        DGDirection,
        DGDepartureDate,
        DGNumberNights,
        DGCostPerVacationer,
        DGNumberVacationers,
        DGAvailabilityWiFi,
        DGSurcharges,
        DGTotalCost
            });
            dataGridViewTours.Dock = DockStyle.Fill;
            dataGridViewTours.Location = new Point(0, 25);  // ниже ToolStrip
            dataGridViewTours.Name = "dataGridViewTours";
            dataGridViewTours.TabIndex = 0;
            dataGridViewTours.CellFormatting += CellFormatting;

            // Колонки
            // Направление
            DGDirection.DataPropertyName = "Direction";
            DGDirection.HeaderText = "Направление";
            DGDirection.Name = "DGDirection";

            // Дата вылета
            DGDepartureDate.DataPropertyName = "DepartureDate";
            DGDepartureDate.HeaderText = "Дата вылета";
            DGDepartureDate.Name = "DGDepartureDate";
            DGDepartureDate.DefaultCellStyle.Format = "dd.MM.yyyy";

            // Кол-во ночей
            DGNumberNights.DataPropertyName = "NumberNights";
            DGNumberNights.HeaderText = "Количество ночей";
            DGNumberNights.Name = "DGNumberNights";

            // Стоимость за отдыхающего
            DGCostPerVacationer.DataPropertyName = "CostPerVacationer";
            DGCostPerVacationer.HeaderText = "Стоимость за отдыхающего (руб)";
            DGCostPerVacationer.Name = "DGCostPerVacationer";

            // Кол-во отдыхающих
            DGNumberVacationers.DataPropertyName = "NumberVacationers";
            DGNumberVacationers.HeaderText = "Количество отдыхающих";
            DGNumberVacationers.Name = "DGNumberVacationers";

            // Наличие Wi-Fi
            DGAvailabilityWiFi.DataPropertyName = "AvailabilityWiFi";
            DGAvailabilityWiFi.HeaderText = "Наличие Wi-Fi";
            DGAvailabilityWiFi.Name = "DGAvailabilityWiFi";

            // Доплаты
            DGSurcharges.DataPropertyName = "Surcharges";
            DGSurcharges.HeaderText = "Доплаты (руб)";
            DGSurcharges.Name = "DGSurcharges";

            // Общая стоимость
            DGTotalCost.DataPropertyName = "TotalCost";   // Переиспользуем в CellFormatting
            DGTotalCost.HeaderText = "Общая стоимость";
            DGTotalCost.Name = "DGTotalCost";
            
            statusStripRegistry.BackColor = Color.SteelBlue;
            statusStripRegistry.Dock = DockStyle.Bottom;
            statusStripRegistry.Items.AddRange(new ToolStripItem[]
            {
        toolStrpLblTotalTours,
        toolStrpLblTotalCost,
        toolStrpLblToursWithSurcharges,
        toolStrpLblTotalSurcharges
            });
            statusStripRegistry.Name = "statusStripRegistry";
            statusStripRegistry.Size = new Size(1050, 25);

            var statusFont = new Font("Segoe UI", 11.25F);
            var statusColor = Color.White;

            // Общее кол-во туров
            toolStrpLblTotalTours.Font = statusFont;
            toolStrpLblTotalTours.ForeColor = statusColor;
            toolStrpLblTotalTours.Name = "toolStrpLblTotalTours";
            toolStrpLblTotalTours.Text = "Общее кол-во туров: 0";

            // Общая сумма за все туры
            toolStrpLblTotalCost.Font = statusFont;
            toolStrpLblTotalCost.ForeColor = statusColor;
            toolStrpLblTotalCost.Name = "toolStrpLblTotalCost";
            toolStrpLblTotalCost.Text = "Общая сумма за все туры: 0,00 руб.";

            // Кол-во туров с доплатами
            toolStrpLblToursWithSurcharges.Font = statusFont;
            toolStrpLblToursWithSurcharges.ForeColor = statusColor;
            toolStrpLblToursWithSurcharges.Name = "toolStrpLblToursWithSurcharges";
            toolStrpLblToursWithSurcharges.Text = "Кол-во туров с доплатами: 0";

            // Общая сумма доплат
            toolStrpLblTotalSurcharges.Font = statusFont;
            toolStrpLblTotalSurcharges.ForeColor = statusColor;
            toolStrpLblTotalSurcharges.Name = "toolStrpLblTotalSurcharges";
            toolStrpLblTotalSurcharges.Text = "Общая сумма доплат: 0,00 руб.";

          
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1050, 400);
            Controls.Add(dataGridViewTours);
            Controls.Add(statusStripRegistry);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Общая статистика";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;

            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStripRegistry.ResumeLayout(false);
            statusStripRegistry.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
