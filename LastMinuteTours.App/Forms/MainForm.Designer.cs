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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            toolStripButton1 = new ToolStripButton();
            statusStripRegistry = new StatusStrip();
            toolStrpLblTotalTours = new ToolStripStatusLabel();
            toolStrpLblTotalCost = new ToolStripStatusLabel();
            toolStrpLblToursWithSurcharges = new ToolStripStatusLabel();
            toolStrpLblTotalSurcharges = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).BeginInit();
            toolStrip1.SuspendLayout();
            statusStripRegistry.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTours
            // 
            dataGridViewTours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTours.BackgroundColor = Color.SteelBlue;
            dataGridViewTours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTours.Columns.AddRange(new DataGridViewColumn[] { DGDirection, DGDepartureDate, DGNumberNights, DGCostPerVacationer, DGNumberVacationers, DGAvailabilityWiFi, DGSurcharges, DGTotalCost });
            dataGridViewTours.Dock = DockStyle.Fill;
            dataGridViewTours.Location = new Point(0, 25);
            dataGridViewTours.Name = "dataGridViewTours";
            dataGridViewTours.Size = new Size(1050, 350);
            dataGridViewTours.TabIndex = 0;
            dataGridViewTours.CellFormatting += CellFormatting;
            // 
            // DGDirection
            // 
            DGDirection.DataPropertyName = "Direction";
            DGDirection.HeaderText = "Направление";
            DGDirection.Name = "DGDirection";
            // 
            // DGDepartureDate
            // 
            DGDepartureDate.DataPropertyName = "DepartureDate";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            DGDepartureDate.DefaultCellStyle = dataGridViewCellStyle1;
            DGDepartureDate.HeaderText = "Дата вылета";
            DGDepartureDate.Name = "DGDepartureDate";
            // 
            // DGNumberNights
            // 
            DGNumberNights.DataPropertyName = "NumberNights";
            DGNumberNights.HeaderText = "Количество ночей";
            DGNumberNights.Name = "DGNumberNights";
            // 
            // DGCostPerVacationer
            // 
            DGCostPerVacationer.DataPropertyName = "CostPerVacationer";
            DGCostPerVacationer.HeaderText = "Стоимость за отдыхающего (руб)";
            DGCostPerVacationer.Name = "DGCostPerVacationer";
            // 
            // DGNumberVacationers
            // 
            DGNumberVacationers.DataPropertyName = "NumberVacationers";
            DGNumberVacationers.HeaderText = "Количество отдыхающих";
            DGNumberVacationers.Name = "DGNumberVacationers";
            // 
            // DGAvailabilityWiFi
            // 
            DGAvailabilityWiFi.DataPropertyName = "AvailabilityWiFi";
            DGAvailabilityWiFi.HeaderText = "Наличие Wi-Fi";
            DGAvailabilityWiFi.Name = "DGAvailabilityWiFi";
            // 
            // DGSurcharges
            // 
            DGSurcharges.DataPropertyName = "Surcharges";
            DGSurcharges.HeaderText = "Доплаты (руб)";
            DGSurcharges.Name = "DGSurcharges";
            // 
            // DGTotalCost
            // 
            DGTotalCost.DataPropertyName = "TotalCost";
            DGTotalCost.HeaderText = "Общая стоимость";
            DGTotalCost.Name = "DGTotalCost";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.SteelBlue;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlStrpBtnAdd, tlStrpBtnEdit, tlStrpBtnDelete, toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1050, 25);
            toolStrip1.TabIndex = 2;
            // 
            // tlStrpBtnAdd
            // 
            tlStrpBtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlStrpBtnAdd.Name = "tlStrpBtnAdd";
            tlStrpBtnAdd.Size = new Size(63, 22);
            tlStrpBtnAdd.Text = "Добавить";
            tlStrpBtnAdd.Click += tlStrpBtnAdd_Click;
            // 
            // tlStrpBtnEdit
            // 
            tlStrpBtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlStrpBtnEdit.Name = "tlStrpBtnEdit";
            tlStrpBtnEdit.Size = new Size(91, 22);
            tlStrpBtnEdit.Text = "Редактировать";
            tlStrpBtnEdit.Click += tlStrpBtnEdit_Click;
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new Size(55, 22);
            tlStrpBtnDelete.Text = "Удалить";
            tlStrpBtnDelete.Click += tlStrpBtnDelete_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(65, 22);
            toolStripButton1.Text = "Обновить";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // statusStripRegistry
            // 
            statusStripRegistry.BackColor = Color.SteelBlue;
            statusStripRegistry.Items.AddRange(new ToolStripItem[] { toolStrpLblTotalTours, toolStrpLblTotalCost, toolStrpLblToursWithSurcharges, toolStrpLblTotalSurcharges });
            statusStripRegistry.Location = new Point(0, 375);
            statusStripRegistry.Name = "statusStripRegistry";
            statusStripRegistry.Size = new Size(1050, 25);
            statusStripRegistry.TabIndex = 1;
            // 
            // toolStrpLblTotalTours
            // 
            toolStrpLblTotalTours.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblTotalTours.ForeColor = Color.White;
            toolStrpLblTotalTours.Name = "toolStrpLblTotalTours";
            toolStrpLblTotalTours.Size = new Size(166, 20);
            toolStrpLblTotalTours.Text = "Общее кол-во туров: 0";
            // 
            // toolStrpLblTotalCost
            // 
            toolStrpLblTotalCost.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblTotalCost.ForeColor = Color.White;
            toolStrpLblTotalCost.Name = "toolStrpLblTotalCost";
            toolStrpLblTotalCost.Size = new Size(254, 20);
            toolStrpLblTotalCost.Text = "Общая сумма за все туры: 0,00 руб.";
            // 
            // toolStrpLblToursWithSurcharges
            // 
            toolStrpLblToursWithSurcharges.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblToursWithSurcharges.ForeColor = Color.White;
            toolStrpLblToursWithSurcharges.Name = "toolStrpLblToursWithSurcharges";
            toolStrpLblToursWithSurcharges.Size = new Size(207, 20);
            toolStrpLblToursWithSurcharges.Text = "Кол-во туров с доплатами: 0";
            // 
            // toolStrpLblTotalSurcharges
            // 
            toolStrpLblTotalSurcharges.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblTotalSurcharges.ForeColor = Color.White;
            toolStrpLblTotalSurcharges.Name = "toolStrpLblTotalSurcharges";
            toolStrpLblTotalSurcharges.Size = new Size(223, 20);
            toolStrpLblTotalSurcharges.Text = "Общая сумма доплат: 0,00 руб.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1050, 400);
            Controls.Add(dataGridViewTours);
            Controls.Add(statusStripRegistry);
            Controls.Add(toolStrip1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Общая статистика";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStripRegistry.ResumeLayout(false);
            statusStripRegistry.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripButton toolStripButton1;
    }
}
