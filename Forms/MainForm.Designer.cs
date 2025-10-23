namespace LastMinuteTours
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
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
            statusStripRegistry = new StatusStrip();
            toolStrpLblTotalTours = new ToolStripStatusLabel();
            toolStrpLblTotalCost = new ToolStripStatusLabel();
            toolStrpLblToursWithSurcharges = new ToolStripStatusLabel();
            toolStrpLblTotalSurcharges = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            tlStrpBtnAdd = new ToolStripButton();
            tlStrpBtnEdit = new ToolStripButton();
            tlStrpBtnDelete = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).BeginInit();
            statusStripRegistry.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTours
            // 
            dataGridViewTours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTours.BackgroundColor = Color.SteelBlue;
            dataGridViewTours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTours.Columns.AddRange(new DataGridViewColumn[] { DGDirection, DGDepartureDate, DGNumberNights, DGCostPerVacationer, DGNumberVacationers, DGAvailabilityWiFi, DGSurcharges, DGTotalCost });
            dataGridViewTours.Location = new Point(0, 28);
            dataGridViewTours.Name = "dataGridViewTours";
            dataGridViewTours.Size = new Size(1224, 397);
            dataGridViewTours.TabIndex = 0;
            dataGridViewTours.CellContentClick += dataGridViewTours_CellContentClick;
            dataGridViewTours.CellFormatting += dataGridViewTours_CellFormatting;
            // 
            // DGDirection
            // 
            DGDirection.DataPropertyName = "Direction";
            DGDirection.HeaderText = "Направление ";
            DGDirection.Name = "DGDirection";
            // 
            // DGDepartureDate
            // 
            DGDepartureDate.DataPropertyName = "DepartureDate";
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
            // statusStripRegistry
            // 
            statusStripRegistry.BackColor = Color.SteelBlue;
            statusStripRegistry.Items.AddRange(new ToolStripItem[] { toolStrpLblTotalTours, toolStrpLblTotalCost, toolStrpLblToursWithSurcharges, toolStrpLblTotalSurcharges });
            statusStripRegistry.Location = new Point(0, 425);
            statusStripRegistry.Name = "statusStripRegistry";
            statusStripRegistry.Size = new Size(1224, 25);
            statusStripRegistry.TabIndex = 1;
            statusStripRegistry.Text = "statusStrip1";
            // 
            // toolStrpLblTotalTours
            // 
            toolStrpLblTotalTours.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblTotalTours.ForeColor = Color.White;
            toolStrpLblTotalTours.Name = "toolStrpLblTotalTours";
            toolStrpLblTotalTours.Size = new Size(154, 20);
            toolStrpLblTotalTours.Text = "Общее кол-во туров:";
            // 
            // toolStrpLblTotalCost
            // 
            toolStrpLblTotalCost.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblTotalCost.ForeColor = Color.White;
            toolStrpLblTotalCost.Name = "toolStrpLblTotalCost";
            toolStrpLblTotalCost.Size = new Size(198, 20);
            toolStrpLblTotalCost.Text = "Общая сумма за вссе туры:";
            // 
            // toolStrpLblToursWithSurcharges
            // 
            toolStrpLblToursWithSurcharges.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblToursWithSurcharges.ForeColor = Color.White;
            toolStrpLblToursWithSurcharges.Name = "toolStrpLblToursWithSurcharges";
            toolStrpLblToursWithSurcharges.Size = new Size(195, 20);
            toolStrpLblToursWithSurcharges.Text = "Кол-во туров с доплатами:";
            // 
            // toolStrpLblTotalSurcharges
            // 
            toolStrpLblTotalSurcharges.Font = new Font("Segoe UI", 11.25F);
            toolStrpLblTotalSurcharges.ForeColor = Color.White;
            toolStrpLblTotalSurcharges.Name = "toolStrpLblTotalSurcharges";
            toolStrpLblTotalSurcharges.Size = new Size(160, 20);
            toolStrpLblTotalSurcharges.Text = "Общая сумма доплат:";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.SteelBlue;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlStrpBtnAdd, tlStrpBtnEdit, tlStrpBtnDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1224, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnAdd
            // 
            tlStrpBtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlStrpBtnAdd.Image = Properties.Resources.Add;
            tlStrpBtnAdd.ImageTransparentColor = Color.Magenta;
            tlStrpBtnAdd.Name = "tlStrpBtnAdd";
            tlStrpBtnAdd.Size = new Size(23, 22);
            tlStrpBtnAdd.Text = "Добавить ";
            tlStrpBtnAdd.Click += tlStrpBtnAdd_Click;
            // 
            // tlStrpBtnEdit
            // 
            tlStrpBtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlStrpBtnEdit.Image = Properties.Resources.Edit;
            tlStrpBtnEdit.ImageTransparentColor = Color.Magenta;
            tlStrpBtnEdit.Name = "tlStrpBtnEdit";
            tlStrpBtnEdit.Size = new Size(23, 22);
            tlStrpBtnEdit.Text = "Редактировать";
            tlStrpBtnEdit.Click += tlStrpBtnEdit_Click;
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlStrpBtnDelete.Image = Properties.Resources.Delete;
            tlStrpBtnDelete.ImageTransparentColor = Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new Size(23, 22);
            tlStrpBtnDelete.Text = "Удалить";
            tlStrpBtnDelete.Click += tlStrpBtnDelete_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1224, 450);
            Controls.Add(toolStrip1);
            Controls.Add(statusStripRegistry);
            Controls.Add(dataGridViewTours);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Общая статистика";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).EndInit();
            statusStripRegistry.ResumeLayout(false);
            statusStripRegistry.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTours;
        private StatusStrip statusStripRegistry;
        private ToolStrip toolStrip1;
        private ToolStripButton tlStrpBtnAdd;
        private ToolStripButton tlStrpBtnEdit;
        private ToolStripButton tlStrpBtnDelete;
        private DataGridViewTextBoxColumn DGDirection;
        private DataGridViewTextBoxColumn DGDepartureDate;
        private DataGridViewTextBoxColumn DGNumberNights;
        private DataGridViewTextBoxColumn DGCostPerVacationer;
        private DataGridViewTextBoxColumn DGNumberVacationers;
        private DataGridViewTextBoxColumn DGAvailabilityWiFi;
        private DataGridViewTextBoxColumn DGSurcharges;
        private DataGridViewTextBoxColumn DGTotalCost;
        private ToolStripStatusLabel toolStrpLblTotalTours;
        private ToolStripStatusLabel toolStrpLblTotalCost;
        private ToolStripStatusLabel toolStrpLblToursWithSurcharges;
        private ToolStripStatusLabel toolStrpLblTotalSurcharges;
    }
}
