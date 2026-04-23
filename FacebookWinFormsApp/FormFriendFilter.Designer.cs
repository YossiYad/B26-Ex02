namespace BasicFacebookFeatures
{
    partial class FormFriendFilter
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelFilterType = new System.Windows.Forms.Label();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearchName = new System.Windows.Forms.TextBox();
            this.labelCurrentSearchTitle = new System.Windows.Forms.Label();
            this.labelCurrentSearch = new System.Windows.Forms.Label();
            this.buttonClearSearch = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelResultsTitle = new System.Windows.Forms.Label();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(850, 56);
            this.panelHeader.TabIndex = 0;
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(16, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(209, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "\uD83D\uDC65 Friend Filter";
            //
            // labelFilterType
            //
            this.labelFilterType.AutoSize = true;
            this.labelFilterType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelFilterType.Location = new System.Drawing.Point(22, 80);
            this.labelFilterType.Name = "labelFilterType";
            this.labelFilterType.Size = new System.Drawing.Size(87, 23);
            this.labelFilterType.TabIndex = 1;
            this.labelFilterType.Text = "Filter Type:";
            //
            // comboBoxFilterType
            //
            this.comboBoxFilterType.BackColor = System.Drawing.Color.White;
            this.comboBoxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFilterType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Location = new System.Drawing.Point(22, 105);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(250, 31);
            this.comboBoxFilterType.TabIndex = 2;
            //
            // buttonApply
            //
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.buttonApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.ForeColor = System.Drawing.Color.White;
            this.buttonApply.Location = new System.Drawing.Point(22, 150);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(250, 45);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "\u2728 Apply Filter";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            //
            // labelSearch
            //
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelSearch.Location = new System.Drawing.Point(22, 230);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(121, 23);
            this.labelSearch.TabIndex = 4;
            this.labelSearch.Text = "Search by name:";
            //
            // textBoxSearchName
            //
            this.textBoxSearchName.BackColor = System.Drawing.Color.White;
            this.textBoxSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchName.Location = new System.Drawing.Point(22, 255);
            this.textBoxSearchName.Name = "textBoxSearchName";
            this.textBoxSearchName.Size = new System.Drawing.Size(250, 30);
            this.textBoxSearchName.TabIndex = 5;
            //
            // labelCurrentSearchTitle
            //
            this.labelCurrentSearchTitle.AutoSize = true;
            this.labelCurrentSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelCurrentSearchTitle.Location = new System.Drawing.Point(22, 295);
            this.labelCurrentSearchTitle.Name = "labelCurrentSearchTitle";
            this.labelCurrentSearchTitle.Size = new System.Drawing.Size(140, 20);
            this.labelCurrentSearchTitle.TabIndex = 6;
            this.labelCurrentSearchTitle.Text = "Currently searching:";
            //
            // labelCurrentSearch
            //
            this.labelCurrentSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.labelCurrentSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrentSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.labelCurrentSearch.Location = new System.Drawing.Point(22, 320);
            this.labelCurrentSearch.Name = "labelCurrentSearch";
            this.labelCurrentSearch.Size = new System.Drawing.Size(250, 30);
            this.labelCurrentSearch.TabIndex = 7;
            this.labelCurrentSearch.Text = "(none)";
            this.labelCurrentSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // buttonClearSearch
            //
            this.buttonClearSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.buttonClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearSearch.FlatAppearance.BorderSize = 0;
            this.buttonClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearSearch.ForeColor = System.Drawing.Color.White;
            this.buttonClearSearch.Location = new System.Drawing.Point(22, 360);
            this.buttonClearSearch.Name = "buttonClearSearch";
            this.buttonClearSearch.Size = new System.Drawing.Size(250, 40);
            this.buttonClearSearch.TabIndex = 8;
            this.buttonClearSearch.Text = "\uD83E\uDDF9 Clear Search";
            this.buttonClearSearch.UseVisualStyleBackColor = false;
            this.buttonClearSearch.Click += new System.EventHandler(this.buttonClearSearch_Click);
            //
            // buttonClose
            //
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(22, 490);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(250, 45);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "\uD83D\uDEAA Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            //
            // labelResultsTitle
            //
            this.labelResultsTitle.AutoSize = true;
            this.labelResultsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelResultsTitle.Location = new System.Drawing.Point(310, 80);
            this.labelResultsTitle.Name = "labelResultsTitle";
            this.labelResultsTitle.Size = new System.Drawing.Size(63, 20);
            this.labelResultsTitle.TabIndex = 10;
            this.labelResultsTitle.Text = "Results:";
            //
            // listBoxResults
            //
            this.listBoxResults.BackColor = System.Drawing.Color.White;
            this.listBoxResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 23;
            this.listBoxResults.Location = new System.Drawing.Point(310, 105);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(515, 396);
            this.listBoxResults.TabIndex = 11;
            //
            // labelStatus
            //
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelStatus.Location = new System.Drawing.Point(310, 510);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(515, 25);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Status: 0 results";
            //
            // FormFriendFilter
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(850, 560);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.labelResultsTitle);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonClearSearch);
            this.Controls.Add(this.labelCurrentSearch);
            this.Controls.Add(this.labelCurrentSearchTitle);
            this.Controls.Add(this.textBoxSearchName);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxFilterType);
            this.Controls.Add(this.labelFilterType);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(866, 599);
            this.Name = "FormFriendFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Friend Filter";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelFilterType;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearchName;
        private System.Windows.Forms.Label labelCurrentSearchTitle;
        private System.Windows.Forms.Label labelCurrentSearch;
        private System.Windows.Forms.Button buttonClearSearch;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelResultsTitle;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Label labelStatus;
    }
}
