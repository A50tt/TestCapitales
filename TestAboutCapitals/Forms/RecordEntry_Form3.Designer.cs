namespace TestAboutCapitals
{
    partial class RecordEntry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.muteVolumeButton = new System.Windows.Forms.Button();
            this.plusVolumeBut = new System.Windows.Forms.Button();
            this.minusVolumeBut = new System.Windows.Forms.Button();
            this.volumeLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your alias for eternal glory:";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.textBox1.Location = new System.Drawing.Point(148, 86);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 83);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(148, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "LET\'S GO!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "VolumeOff.png");
            this.imageList1.Images.SetKeyName(1, "VolumeOn.png");
            this.imageList1.Images.SetKeyName(2, "PlusImage.png");
            this.imageList1.Images.SetKeyName(3, "MinusImage.png");
            // 
            // muteVolumeButton
            // 
            this.muteVolumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.muteVolumeButton.ImageIndex = 0;
            this.muteVolumeButton.ImageList = this.imageList1;
            this.muteVolumeButton.Location = new System.Drawing.Point(402, 188);
            this.muteVolumeButton.Name = "muteVolumeButton";
            this.muteVolumeButton.Size = new System.Drawing.Size(26, 26);
            this.muteVolumeButton.TabIndex = 102;
            this.muteVolumeButton.UseVisualStyleBackColor = true;
            this.muteVolumeButton.Click += new System.EventHandler(this.muteVolumeButton_Click);
            // 
            // plusVolumeBut
            // 
            this.plusVolumeBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.plusVolumeBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.plusVolumeBut.ImageIndex = 2;
            this.plusVolumeBut.ImageList = this.imageList1;
            this.plusVolumeBut.Location = new System.Drawing.Point(434, 188);
            this.plusVolumeBut.Name = "plusVolumeBut";
            this.plusVolumeBut.Size = new System.Drawing.Size(26, 26);
            this.plusVolumeBut.TabIndex = 106;
            this.plusVolumeBut.UseVisualStyleBackColor = true;
            this.plusVolumeBut.Click += new System.EventHandler(this.plusVolumeBut_Click);
            // 
            // minusVolumeBut
            // 
            this.minusVolumeBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minusVolumeBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.minusVolumeBut.ImageIndex = 3;
            this.minusVolumeBut.ImageList = this.imageList1;
            this.minusVolumeBut.Location = new System.Drawing.Point(370, 188);
            this.minusVolumeBut.Name = "minusVolumeBut";
            this.minusVolumeBut.Size = new System.Drawing.Size(26, 26);
            this.minusVolumeBut.TabIndex = 107;
            this.minusVolumeBut.UseVisualStyleBackColor = true;
            this.minusVolumeBut.Click += new System.EventHandler(this.minusVolumeBut_Click);
            // 
            // volumeLevel
            // 
            this.volumeLevel.AutoSize = true;
            this.volumeLevel.Location = new System.Drawing.Point(337, 194);
            this.volumeLevel.Name = "volumeLevel";
            this.volumeLevel.Size = new System.Drawing.Size(33, 13);
            this.volumeLevel.TabIndex = 108;
            this.volumeLevel.Text = "100%";
            // 
            // RecordEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 226);
            this.Controls.Add(this.volumeLevel);
            this.Controls.Add(this.minusVolumeBut);
            this.Controls.Add(this.plusVolumeBut);
            this.Controls.Add(this.muteVolumeButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecordEntry";
            this.Text = "The capital\'s test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecordEntry_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button muteVolumeButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button plusVolumeBut;
        private System.Windows.Forms.Button minusVolumeBut;
        private System.Windows.Forms.Label volumeLevel;
    }
}