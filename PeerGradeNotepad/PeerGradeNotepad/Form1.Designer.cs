namespace PeerGradeNotepad
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_as_txt = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_as_rtf = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFile2 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFile3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SavingCurrentDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.SavingAllDocuments1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ClosingApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.undoingPreviousActions = new System.Windows.Forms.ToolStripMenuItem();
            this.returningPreviousActions = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Customization = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorChange = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorChange1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorChange2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorChange3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTime = new System.Windows.Forms.ToolStripMenuItem();
            this.min1 = new System.Windows.Forms.ToolStripMenuItem();
            this.min5 = new System.Windows.Forms.ToolStripMenuItem();
            this.min15 = new System.Windows.Forms.ToolStripMenuItem();
            this.min30 = new System.Windows.Forms.ToolStripMenuItem();
            this.Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.format4 = new System.Windows.Forms.ToolStripMenuItem();
            this.format3 = new System.Windows.Forms.ToolStripMenuItem();
            this.format2 = new System.Windows.Forms.ToolStripMenuItem();
            this.format1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonUp = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Edit,
            this.FormatButton,
            this.Customization});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1152, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.Save_as_txt,
            this.Save_as_rtf,
            this.NewFile2,
            this.NewFile3,
            this.SavingCurrentDocument,
            this.SavingAllDocuments1,
            this.ClosingApplication});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(54, 29);
            this.File.Text = "File";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(560, 34);
            this.Open.Text = "Открыть";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(560, 34);
            this.Save.Text = "Сохранить";
            // 
            // Save_as_txt
            // 
            this.Save_as_txt.Name = "Save_as_txt";
            this.Save_as_txt.Size = new System.Drawing.Size(560, 34);
            this.Save_as_txt.Text = "Сохранить как (txt)";
            // 
            // Save_as_rtf
            // 
            this.Save_as_rtf.Name = "Save_as_rtf";
            this.Save_as_rtf.Size = new System.Drawing.Size(560, 34);
            this.Save_as_rtf.Text = "Сохранить как (rtf)";
            // 
            // NewFile2
            // 
            this.NewFile2.Name = "NewFile2";
            this.NewFile2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewFile2.Size = new System.Drawing.Size(560, 34);
            this.NewFile2.Text = "Создание документа в новом окне";
            // 
            // NewFile3
            // 
            this.NewFile3.Name = "NewFile3";
            this.NewFile3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.NewFile3.Size = new System.Drawing.Size(560, 34);
            this.NewFile3.Text = "Создание документа в новой вкладке";
            // 
            // SavingCurrentDocument
            // 
            this.SavingCurrentDocument.Name = "SavingCurrentDocument";
            this.SavingCurrentDocument.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.SavingCurrentDocument.Size = new System.Drawing.Size(560, 34);
            this.SavingCurrentDocument.Text = "Сохранение текущего документа";
            // 
            // SavingAllDocuments1
            // 
            this.SavingAllDocuments1.Name = "SavingAllDocuments1";
            this.SavingAllDocuments1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SavingAllDocuments1.Size = new System.Drawing.Size(560, 34);
            this.SavingAllDocuments1.Text = "Сохранение всех открытых в окне документов";
            // 
            // ClosingApplication
            // 
            this.ClosingApplication.Name = "ClosingApplication";
            this.ClosingApplication.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ClosingApplication.Size = new System.Drawing.Size(560, 34);
            this.ClosingApplication.Text = "Закрытие приложения";
            // 
            // Edit
            // 
            this.Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoingPreviousActions,
            this.returningPreviousActions});
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(89, 29);
            this.Edit.Text = "Правка";
            // 
            // undoingPreviousActions
            // 
            this.undoingPreviousActions.Name = "undoingPreviousActions";
            this.undoingPreviousActions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoingPreviousActions.Size = new System.Drawing.Size(496, 34);
            this.undoingPreviousActions.Text = "Отмена предыдущего действия";
            // 
            // returningPreviousActions
            // 
            this.returningPreviousActions.Name = "returningPreviousActions";
            this.returningPreviousActions.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.returningPreviousActions.Size = new System.Drawing.Size(496, 34);
            this.returningPreviousActions.Text = "Возврат предыдущего действия";
            // 
            // FormatButton
            // 
            this.FormatButton.Name = "FormatButton";
            this.FormatButton.Size = new System.Drawing.Size(92, 29);
            this.FormatButton.Text = "Формат";
            // 
            // Customization
            // 
            this.Customization.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorChange,
            this.SaveTime});
            this.Customization.Name = "Customization";
            this.Customization.Size = new System.Drawing.Size(116, 29);
            this.Customization.Text = "Настройки";
            // 
            // ColorChange
            // 
            this.ColorChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorChange1,
            this.ColorChange2,
            this.ColorChange3});
            this.ColorChange.Name = "ColorChange";
            this.ColorChange.Size = new System.Drawing.Size(345, 34);
            this.ColorChange.Text = "Изменения цветовой схемы";
            // 
            // ColorChange1
            // 
            this.ColorChange1.Name = "ColorChange1";
            this.ColorChange1.Size = new System.Drawing.Size(259, 34);
            this.ColorChange1.Text = "Цветовая схема 1";
            // 
            // ColorChange2
            // 
            this.ColorChange2.Name = "ColorChange2";
            this.ColorChange2.Size = new System.Drawing.Size(259, 34);
            this.ColorChange2.Text = "Цветовая схема 2";
            // 
            // ColorChange3
            // 
            this.ColorChange3.Name = "ColorChange3";
            this.ColorChange3.Size = new System.Drawing.Size(259, 34);
            this.ColorChange3.Text = "Цветовая схема 3";
            // 
            // SaveTime
            // 
            this.SaveTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.min1,
            this.min5,
            this.min15,
            this.min30,
            this.Stop});
            this.SaveTime.Name = "SaveTime";
            this.SaveTime.Size = new System.Drawing.Size(345, 34);
            this.SaveTime.Text = "Частота";
            // 
            // min1
            // 
            this.min1.Name = "min1";
            this.min1.Size = new System.Drawing.Size(353, 34);
            this.min1.Text = "1 минута";
            // 
            // min5
            // 
            this.min5.Name = "min5";
            this.min5.Size = new System.Drawing.Size(353, 34);
            this.min5.Text = "5 минут";
            // 
            // min15
            // 
            this.min15.Name = "min15";
            this.min15.Size = new System.Drawing.Size(353, 34);
            this.min15.Text = "15 минут";
            // 
            // min30
            // 
            this.min30.Name = "min30";
            this.min30.Size = new System.Drawing.Size(353, 34);
            this.min30.Text = "30 минут";
            // 
            // Stop
            // 
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(353, 34);
            this.Stop.Text = "Отключение автосохранения";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAdd.Location = new System.Drawing.Point(12, 104);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(190, 55);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(297, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(830, 455);
            this.tabControl1.TabIndex = 3;
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRemove.Location = new System.Drawing.Point(12, 165);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(190, 54);
            this.buttonRemove.TabIndex = 0;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // format4
            // 
            this.format4.CheckOnClick = true;
            this.format4.Name = "format4";
            this.format4.Size = new System.Drawing.Size(236, 34);
            this.format4.Text = "Зачёркнутый";
            // 
            // format3
            // 
            this.format3.CheckOnClick = true;
            this.format3.Name = "format3";
            this.format3.Size = new System.Drawing.Size(236, 34);
            this.format3.Text = "Подчёркнутый";
            // 
            // format2
            // 
            this.format2.CheckOnClick = true;
            this.format2.Name = "format2";
            this.format2.Size = new System.Drawing.Size(236, 34);
            this.format2.Text = "Жирный";
            // 
            // format1
            // 
            this.format1.CheckOnClick = true;
            this.format1.Name = "format1";
            this.format1.Size = new System.Drawing.Size(236, 34);
            this.format1.Text = "Курсив";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem7.Text = "toolStripMenuItem7";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.OnTimedEvent);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(23, 48);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(77, 50);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(106, 48);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(73, 50);
            this.Down.TabIndex = 5;
            this.Down.Text = "Down";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1152, 521);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Note";
            this.TransparencyKey = System.Drawing.SystemColors.InactiveBorder;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem Save_as_txt;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem Save_as_rtf;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem FormatButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem Customization;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem format4;
        private System.Windows.Forms.ToolStripMenuItem format3;
        private System.Windows.Forms.ToolStripMenuItem format2;
        private System.Windows.Forms.ToolStripMenuItem format1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem ColorChange;
        private System.Windows.Forms.ToolStripMenuItem ColorChange1;
        private System.Windows.Forms.ToolStripMenuItem ColorChange2;
        private System.Windows.Forms.ToolStripMenuItem ColorChange3;
        private System.Windows.Forms.ToolStripMenuItem SaveTime;
        private System.Windows.Forms.ToolStripMenuItem min1;
        private System.Windows.Forms.ToolStripMenuItem min5;
        private System.Windows.Forms.ToolStripMenuItem min15;
        private System.Windows.Forms.ToolStripMenuItem min30;
        private System.Windows.Forms.ToolStripMenuItem Stop;
        private System.Windows.Forms.ToolStripMenuItem NewFile2;
        private System.Windows.Forms.ToolStripMenuItem NewFile3;
        private System.Windows.Forms.ToolStripMenuItem SavingCurrentDocument;
        private System.Windows.Forms.ToolStripMenuItem SavingAllDocuments1;
        private System.Windows.Forms.ToolStripMenuItem ClosingApplication;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
        private System.Windows.Forms.ToolStripMenuItem undoingPreviousActions;
        private System.Windows.Forms.ToolStripMenuItem returningPreviousActions;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

