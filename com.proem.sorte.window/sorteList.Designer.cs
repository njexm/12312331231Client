namespace sorteSystem.com.proem.sorte.window
{
    partial class sorteList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sorteListPanel = new System.Windows.Forms.Panel();
            this.listGroupBox = new System.Windows.Forms.GroupBox();
            this.sorteTablePanel = new System.Windows.Forms.Panel();
            this.sorteListTableDataGridView = new System.Windows.Forms.DataGridView();
            this.branch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobilephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewButtonColumn();
            this.street = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableTopPanel = new System.Windows.Forms.Panel();
            this.leaveButton = new System.Windows.Forms.Button();
            this.typoButton = new System.Windows.Forms.Button();
            this.titleGroupBox = new System.Windows.Forms.GroupBox();
            this.makeDateTextBox = new System.Windows.Forms.TextBox();
            this.examineDateTextBox = new System.Windows.Forms.TextBox();
            this.examineStateTextBox = new System.Windows.Forms.TextBox();
            this.examineDateLabel = new System.Windows.Forms.Label();
            this.examineStateLabel = new System.Windows.Forms.Label();
            this.examineManTextBox = new System.Windows.Forms.TextBox();
            this.examineManLabel = new System.Windows.Forms.Label();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.remarkLabel = new System.Windows.Forms.Label();
            this.makerTextBox = new System.Windows.Forms.TextBox();
            this.makerLabel = new System.Windows.Forms.Label();
            this.makeDatelabel = new System.Windows.Forms.Label();
            this.idComboBox = new System.Windows.Forms.ComboBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timePanel = new System.Windows.Forms.Panel();
            this.sorteListPanel.SuspendLayout();
            this.listGroupBox.SuspendLayout();
            this.sorteTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sorteListTableDataGridView)).BeginInit();
            this.tableTopPanel.SuspendLayout();
            this.titleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sorteListPanel
            // 
            this.sorteListPanel.Controls.Add(this.listGroupBox);
            this.sorteListPanel.Controls.Add(this.titleGroupBox);
            this.sorteListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorteListPanel.Location = new System.Drawing.Point(0, 0);
            this.sorteListPanel.Name = "sorteListPanel";
            this.sorteListPanel.Size = new System.Drawing.Size(1000, 700);
            this.sorteListPanel.TabIndex = 0;
            // 
            // listGroupBox
            // 
            this.listGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGroupBox.Controls.Add(this.sorteTablePanel);
            this.listGroupBox.Controls.Add(this.tableTopPanel);
            this.listGroupBox.Location = new System.Drawing.Point(10, 160);
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.Size = new System.Drawing.Size(980, 530);
            this.listGroupBox.TabIndex = 1;
            this.listGroupBox.TabStop = false;
            this.listGroupBox.Text = "单据列表";
            // 
            // sorteTablePanel
            // 
            this.sorteTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sorteTablePanel.Controls.Add(this.sorteListTableDataGridView);
            this.sorteTablePanel.Location = new System.Drawing.Point(5, 70);
            this.sorteTablePanel.Name = "sorteTablePanel";
            this.sorteTablePanel.Size = new System.Drawing.Size(970, 455);
            this.sorteTablePanel.TabIndex = 1;
            // 
            // sorteListTableDataGridView
            // 
            this.sorteListTableDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.sorteListTableDataGridView.AllowUserToAddRows = false;
            this.sorteListTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sorteListTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.branch_code,
            this.branch_name,
            this.userName,
            this.mobilephone,
            this.detailButton,
            this.id,
            this.street});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sorteListTableDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.sorteListTableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorteListTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sorteListTableDataGridView.Name = "sorteListTableDataGridView";
            this.sorteListTableDataGridView.RowTemplate.Height = 35;
            this.sorteListTableDataGridView.Size = new System.Drawing.Size(970, 455);
            this.sorteListTableDataGridView.TabIndex = 0;
            this.sorteListTableDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sorteListTableDataGridView_CellContentClick);
            // 
            // branch_code
            // 
            this.branch_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.branch_code.DataPropertyName = "branch_code";
            this.branch_code.HeaderText = "分店编码";
            this.branch_code.Name = "branch_code";
            // 
            // branch_name
            // 
            this.branch_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.branch_name.DataPropertyName = "branch_name";
            this.branch_name.FillWeight = 300F;
            this.branch_name.HeaderText = "分店名称";
            this.branch_name.Name = "branch_name";
            // 
            // userName
            // 
            this.userName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userName.DataPropertyName = "username";
            this.userName.HeaderText = "分店负责人";
            this.userName.Name = "userName";
            // 
            // mobilephone
            // 
            this.mobilephone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mobilephone.DataPropertyName = "mobilephone";
            this.mobilephone.HeaderText = "联系方式";
            this.mobilephone.Name = "mobilephone";
            // 
            // detailButton
            // 
            this.detailButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.detailButton.DataPropertyName = "buttonText";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.detailButton.DefaultCellStyle = dataGridViewCellStyle1;
            this.detailButton.HeaderText = "操作";
            this.detailButton.Name = "detailButton";
            this.detailButton.Text = "商品详情";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // street
            // 
            this.street.DataPropertyName = "street";
            this.street.HeaderText = "street";
            this.street.Name = "street";
            this.street.Visible = false;
            // 
            // tableTopPanel
            // 
            this.tableTopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableTopPanel.Controls.Add(this.leaveButton);
            this.tableTopPanel.Controls.Add(this.typoButton);
            this.tableTopPanel.Location = new System.Drawing.Point(5, 15);
            this.tableTopPanel.Name = "tableTopPanel";
            this.tableTopPanel.Size = new System.Drawing.Size(970, 50);
            this.tableTopPanel.TabIndex = 0;
            // 
            // leaveButton
            // 
            this.leaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leaveButton.Location = new System.Drawing.Point(893, 12);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(65, 26);
            this.leaveButton.TabIndex = 1;
            this.leaveButton.Text = "退出";
            this.leaveButton.UseVisualStyleBackColor = true;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // typoButton
            // 
            this.typoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.typoButton.Location = new System.Drawing.Point(30, 12);
            this.typoButton.Name = "typoButton";
            this.typoButton.Size = new System.Drawing.Size(80, 26);
            this.typoButton.TabIndex = 0;
            this.typoButton.Text = "打印预览";
            this.typoButton.UseVisualStyleBackColor = true;
            this.typoButton.Click += new System.EventHandler(this.typoButton_Click);
            // 
            // titleGroupBox
            // 
            this.titleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleGroupBox.Controls.Add(this.label1);
            this.titleGroupBox.Controls.Add(this.timePanel);
            this.titleGroupBox.Controls.Add(this.makeDateTextBox);
            this.titleGroupBox.Controls.Add(this.examineDateTextBox);
            this.titleGroupBox.Controls.Add(this.examineStateTextBox);
            this.titleGroupBox.Controls.Add(this.examineDateLabel);
            this.titleGroupBox.Controls.Add(this.examineStateLabel);
            this.titleGroupBox.Controls.Add(this.examineManTextBox);
            this.titleGroupBox.Controls.Add(this.examineManLabel);
            this.titleGroupBox.Controls.Add(this.remarkTextBox);
            this.titleGroupBox.Controls.Add(this.remarkLabel);
            this.titleGroupBox.Controls.Add(this.makerTextBox);
            this.titleGroupBox.Controls.Add(this.makerLabel);
            this.titleGroupBox.Controls.Add(this.makeDatelabel);
            this.titleGroupBox.Controls.Add(this.idComboBox);
            this.titleGroupBox.Controls.Add(this.idLabel);
            this.titleGroupBox.Location = new System.Drawing.Point(10, 10);
            this.titleGroupBox.Name = "titleGroupBox";
            this.titleGroupBox.Size = new System.Drawing.Size(980, 150);
            this.titleGroupBox.TabIndex = 0;
            this.titleGroupBox.TabStop = false;
            this.titleGroupBox.Text = "单据详情";
            // 
            // makeDateTextBox
            // 
            this.makeDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.makeDateTextBox.Location = new System.Drawing.Point(115, 70);
            this.makeDateTextBox.Name = "makeDateTextBox";
            this.makeDateTextBox.Size = new System.Drawing.Size(185, 21);
            this.makeDateTextBox.TabIndex = 14;
            // 
            // examineDateTextBox
            // 
            this.examineDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.examineDateTextBox.Location = new System.Drawing.Point(710, 105);
            this.examineDateTextBox.Name = "examineDateTextBox";
            this.examineDateTextBox.Size = new System.Drawing.Size(195, 21);
            this.examineDateTextBox.TabIndex = 13;
            // 
            // examineStateTextBox
            // 
            this.examineStateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.examineStateTextBox.Location = new System.Drawing.Point(710, 70);
            this.examineStateTextBox.Name = "examineStateTextBox";
            this.examineStateTextBox.Size = new System.Drawing.Size(195, 21);
            this.examineStateTextBox.TabIndex = 12;
            // 
            // examineDateLabel
            // 
            this.examineDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.examineDateLabel.AutoSize = true;
            this.examineDateLabel.Location = new System.Drawing.Point(630, 109);
            this.examineDateLabel.Name = "examineDateLabel";
            this.examineDateLabel.Size = new System.Drawing.Size(65, 12);
            this.examineDateLabel.TabIndex = 11;
            this.examineDateLabel.Text = "审核日期：";
            // 
            // examineStateLabel
            // 
            this.examineStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.examineStateLabel.AutoSize = true;
            this.examineStateLabel.Location = new System.Drawing.Point(630, 74);
            this.examineStateLabel.Name = "examineStateLabel";
            this.examineStateLabel.Size = new System.Drawing.Size(65, 12);
            this.examineStateLabel.TabIndex = 10;
            this.examineStateLabel.Text = "审核状态：";
            // 
            // examineManTextBox
            // 
            this.examineManTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.examineManTextBox.Location = new System.Drawing.Point(710, 35);
            this.examineManTextBox.Name = "examineManTextBox";
            this.examineManTextBox.Size = new System.Drawing.Size(195, 21);
            this.examineManTextBox.TabIndex = 9;
            // 
            // examineManLabel
            // 
            this.examineManLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.examineManLabel.AutoSize = true;
            this.examineManLabel.Location = new System.Drawing.Point(630, 39);
            this.examineManLabel.Name = "examineManLabel";
            this.examineManLabel.Size = new System.Drawing.Size(53, 12);
            this.examineManLabel.TabIndex = 8;
            this.examineManLabel.Text = "审核人：";
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.remarkTextBox.Location = new System.Drawing.Point(115, 105);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(450, 21);
            this.remarkTextBox.TabIndex = 7;
            // 
            // remarkLabel
            // 
            this.remarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.remarkLabel.AutoSize = true;
            this.remarkLabel.Location = new System.Drawing.Point(35, 109);
            this.remarkLabel.Name = "remarkLabel";
            this.remarkLabel.Size = new System.Drawing.Size(65, 12);
            this.remarkLabel.TabIndex = 6;
            this.remarkLabel.Text = "备注信息：";
            // 
            // makerTextBox
            // 
            this.makerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.makerTextBox.Location = new System.Drawing.Point(380, 70);
            this.makerTextBox.Name = "makerTextBox";
            this.makerTextBox.Size = new System.Drawing.Size(185, 21);
            this.makerTextBox.TabIndex = 5;
            // 
            // makerLabel
            // 
            this.makerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.makerLabel.AutoSize = true;
            this.makerLabel.Location = new System.Drawing.Point(314, 74);
            this.makerLabel.Name = "makerLabel";
            this.makerLabel.Size = new System.Drawing.Size(53, 12);
            this.makerLabel.TabIndex = 4;
            this.makerLabel.Text = "制单人：";
            // 
            // makeDatelabel
            // 
            this.makeDatelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.makeDatelabel.AutoSize = true;
            this.makeDatelabel.Location = new System.Drawing.Point(35, 74);
            this.makeDatelabel.Name = "makeDatelabel";
            this.makeDatelabel.Size = new System.Drawing.Size(65, 12);
            this.makeDatelabel.TabIndex = 2;
            this.makeDatelabel.Text = "制单日期：";
            // 
            // idComboBox
            // 
            this.idComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.idComboBox.FormattingEnabled = true;
            this.idComboBox.Location = new System.Drawing.Point(115, 35);
            this.idComboBox.Name = "idComboBox";
            this.idComboBox.Size = new System.Drawing.Size(450, 20);
            this.idComboBox.TabIndex = 1;
            this.idComboBox.SelectedIndexChanged += new System.EventHandler(this.idComboBox_SelectedIndexChanged);
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(35, 39);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(53, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "单据号：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(779, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "当前时间：";
            // 
            // timePanel
            // 
            this.timePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePanel.Location = new System.Drawing.Point(844, 19);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(119, 32);
            this.timePanel.TabIndex = 55;
            // 
            // sorteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.sorteListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sorteList";
            this.RightToLeftLayout = true;
            this.Text = "供应商结算单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.sorteList_Load);
            this.sorteListPanel.ResumeLayout(false);
            this.listGroupBox.ResumeLayout(false);
            this.sorteTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sorteListTableDataGridView)).EndInit();
            this.tableTopPanel.ResumeLayout(false);
            this.titleGroupBox.ResumeLayout(false);
            this.titleGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sorteListPanel;
        private System.Windows.Forms.GroupBox titleGroupBox;
        private System.Windows.Forms.GroupBox listGroupBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label makeDatelabel;
        private System.Windows.Forms.ComboBox idComboBox;
        private System.Windows.Forms.Label makerLabel;
        private System.Windows.Forms.TextBox makerTextBox;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.Label remarkLabel;
        private System.Windows.Forms.Label examineManLabel;
        private System.Windows.Forms.TextBox examineManTextBox;
        private System.Windows.Forms.TextBox examineDateTextBox;
        private System.Windows.Forms.TextBox examineStateTextBox;
        private System.Windows.Forms.Label examineDateLabel;
        private System.Windows.Forms.Label examineStateLabel;
        private System.Windows.Forms.TextBox makeDateTextBox;
        private System.Windows.Forms.Panel tableTopPanel;
        private System.Windows.Forms.Button typoButton;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Panel sorteTablePanel;
        private System.Windows.Forms.DataGridView sorteListTableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobilephone;
        private System.Windows.Forms.DataGridViewButtonColumn detailButton;
        private System.Windows.Forms.DataGridViewButtonColumn id;
        private System.Windows.Forms.DataGridViewButtonColumn street;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel timePanel;
    }
}