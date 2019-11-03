namespace AlivieskaGpsClient
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.zoomSlider = new System.Windows.Forms.TrackBar();
            this.connectionUrlText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpsConnectionBox = new System.Windows.Forms.GroupBox();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpsDataSpeed = new System.Windows.Forms.TextBox();
            this.gpsConnectButton = new System.Windows.Forms.Button();
            this.zoomMultLabel = new System.Windows.Forms.Label();
            this.viewSettingsBox = new System.Windows.Forms.GroupBox();
            this.Car = new System.Windows.Forms.CheckBox();
            this.Player = new System.Windows.Forms.CheckBox();
            this.displayHazardsCheck = new System.Windows.Forms.CheckBox();
            this.displayRoadHazardsCheck = new System.Windows.Forms.CheckBox();
            this.displayRailwayHazardsCheck = new System.Windows.Forms.CheckBox();
            this.displayTrafficHazardsCheck = new System.Windows.Forms.CheckBox();
            this.displayLocationsCheck = new System.Windows.Forms.CheckBox();
            this.displayShopsCheck = new System.Windows.Forms.CheckBox();
            this.displayJobsCheck = new System.Windows.Forms.CheckBox();
            this.displayTownsCheck = new System.Windows.Forms.CheckBox();
            this.gpsUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.resetMapButton = new System.Windows.Forms.Button();
            this.followCheck = new System.Windows.Forms.CheckBox();
            this.showRecordButton = new System.Windows.Forms.Button();
            this.mapImage = new System.Windows.Forms.PictureBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.MapC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).BeginInit();
            this.gpsConnectionBox.SuspendLayout();
            this.viewSettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomSlider
            // 
            this.zoomSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomSlider.LargeChange = 50;
            this.zoomSlider.Location = new System.Drawing.Point(488, 94);
            this.zoomSlider.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zoomSlider.Maximum = 400;
            this.zoomSlider.Minimum = 100;
            this.zoomSlider.Name = "zoomSlider";
            this.zoomSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomSlider.Size = new System.Drawing.Size(45, 464);
            this.zoomSlider.SmallChange = 25;
            this.zoomSlider.TabIndex = 1;
            this.zoomSlider.TickFrequency = 10;
            this.zoomSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.zoomSlider.Value = 100;
            this.zoomSlider.Scroll += new System.EventHandler(this.zoomSlider_Scroll);
            // 
            // connectionUrlText
            // 
            this.connectionUrlText.Location = new System.Drawing.Point(7, 60);
            this.connectionUrlText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectionUrlText.Name = "connectionUrlText";
            this.connectionUrlText.Size = new System.Drawing.Size(184, 27);
            this.connectionUrlText.TabIndex = 1;
            this.connectionUrlText.Text = "http://localhost:8080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server address:";
            // 
            // gpsConnectionBox
            // 
            this.gpsConnectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsConnectionBox.Controls.Add(this.connectionStatusLabel);
            this.gpsConnectionBox.Controls.Add(this.label6);
            this.gpsConnectionBox.Controls.Add(this.gpsDataSpeed);
            this.gpsConnectionBox.Controls.Add(this.gpsConnectButton);
            this.gpsConnectionBox.Controls.Add(this.label1);
            this.gpsConnectionBox.Controls.Add(this.connectionUrlText);
            this.gpsConnectionBox.Location = new System.Drawing.Point(547, 18);
            this.gpsConnectionBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpsConnectionBox.Name = "gpsConnectionBox";
            this.gpsConnectionBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpsConnectionBox.Size = new System.Drawing.Size(198, 174);
            this.gpsConnectionBox.TabIndex = 4;
            this.gpsConnectionBox.TabStop = false;
            this.gpsConnectionBox.Text = "Server connection";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.connectionStatusLabel.Location = new System.Drawing.Point(169, 102);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(19, 17);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.Text = "n";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Speed";
            // 
            // gpsDataSpeed
            // 
            this.gpsDataSpeed.Location = new System.Drawing.Point(60, 137);
            this.gpsDataSpeed.Name = "gpsDataSpeed";
            this.gpsDataSpeed.Size = new System.Drawing.Size(100, 27);
            this.gpsDataSpeed.TabIndex = 20;
            // 
            // gpsConnectButton
            // 
            this.gpsConnectButton.Location = new System.Drawing.Point(7, 98);
            this.gpsConnectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpsConnectButton.Name = "gpsConnectButton";
            this.gpsConnectButton.Size = new System.Drawing.Size(155, 34);
            this.gpsConnectButton.TabIndex = 2;
            this.gpsConnectButton.Text = "Connect";
            this.gpsConnectButton.UseVisualStyleBackColor = true;
            this.gpsConnectButton.Click += new System.EventHandler(this.gpsConnectButton_Click);
            // 
            // zoomMultLabel
            // 
            this.zoomMultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomMultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zoomMultLabel.Location = new System.Drawing.Point(488, 54);
            this.zoomMultLabel.Name = "zoomMultLabel";
            this.zoomMultLabel.Size = new System.Drawing.Size(52, 35);
            this.zoomMultLabel.TabIndex = 6;
            this.zoomMultLabel.Text = "100%";
            this.zoomMultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewSettingsBox
            // 
            this.viewSettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewSettingsBox.Controls.Add(this.Car);
            this.viewSettingsBox.Controls.Add(this.Player);
            this.viewSettingsBox.Controls.Add(this.displayHazardsCheck);
            this.viewSettingsBox.Controls.Add(this.displayRoadHazardsCheck);
            this.viewSettingsBox.Controls.Add(this.displayRailwayHazardsCheck);
            this.viewSettingsBox.Controls.Add(this.displayTrafficHazardsCheck);
            this.viewSettingsBox.Controls.Add(this.displayLocationsCheck);
            this.viewSettingsBox.Controls.Add(this.displayShopsCheck);
            this.viewSettingsBox.Controls.Add(this.displayJobsCheck);
            this.viewSettingsBox.Controls.Add(this.displayTownsCheck);
            this.viewSettingsBox.Location = new System.Drawing.Point(547, 196);
            this.viewSettingsBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewSettingsBox.Name = "viewSettingsBox";
            this.viewSettingsBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewSettingsBox.Size = new System.Drawing.Size(198, 216);
            this.viewSettingsBox.TabIndex = 5;
            this.viewSettingsBox.TabStop = false;
            this.viewSettingsBox.Text = "View settings";
            this.viewSettingsBox.Enter += new System.EventHandler(this.viewSettingsBox_Enter);
            // 
            // Car
            // 
            this.Car.AutoSize = true;
            this.Car.Checked = true;
            this.Car.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Car.Location = new System.Drawing.Point(105, 183);
            this.Car.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Car.Name = "Car";
            this.Car.Size = new System.Drawing.Size(48, 23);
            this.Car.TabIndex = 10;
            this.Car.Text = "Car";
            this.Car.UseVisualStyleBackColor = true;
            this.Car.CheckedChanged += new System.EventHandler(this.Car_CheckedChanged);
            // 
            // Player
            // 
            this.Player.AutoSize = true;
            this.Player.Checked = true;
            this.Player.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Player.Location = new System.Drawing.Point(10, 183);
            this.Player.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(63, 23);
            this.Player.TabIndex = 9;
            this.Player.Text = "Player";
            this.Player.UseVisualStyleBackColor = true;
            this.Player.CheckedChanged += new System.EventHandler(this.Player_CheckedChanged);
            // 
            // displayHazardsCheck
            // 
            this.displayHazardsCheck.AutoSize = true;
            this.displayHazardsCheck.Checked = true;
            this.displayHazardsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayHazardsCheck.Location = new System.Drawing.Point(10, 110);
            this.displayHazardsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayHazardsCheck.Name = "displayHazardsCheck";
            this.displayHazardsCheck.Size = new System.Drawing.Size(73, 23);
            this.displayHazardsCheck.TabIndex = 5;
            this.displayHazardsCheck.Text = "Hazards";
            this.displayHazardsCheck.UseVisualStyleBackColor = true;
            this.displayHazardsCheck.CheckedChanged += new System.EventHandler(this.displayHazardsCheck_CheckedChanged);
            // 
            // displayRoadHazardsCheck
            // 
            this.displayRoadHazardsCheck.AutoSize = true;
            this.displayRoadHazardsCheck.Checked = true;
            this.displayRoadHazardsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayRoadHazardsCheck.Location = new System.Drawing.Point(105, 110);
            this.displayRoadHazardsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayRoadHazardsCheck.Name = "displayRoadHazardsCheck";
            this.displayRoadHazardsCheck.Size = new System.Drawing.Size(55, 23);
            this.displayRoadHazardsCheck.TabIndex = 6;
            this.displayRoadHazardsCheck.Text = "Road";
            this.displayRoadHazardsCheck.UseVisualStyleBackColor = true;
            this.displayRoadHazardsCheck.CheckedChanged += new System.EventHandler(this.poiDisplayCheck_CheckedChanged);
            // 
            // displayRailwayHazardsCheck
            // 
            this.displayRailwayHazardsCheck.AutoSize = true;
            this.displayRailwayHazardsCheck.Checked = true;
            this.displayRailwayHazardsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayRailwayHazardsCheck.Location = new System.Drawing.Point(105, 144);
            this.displayRailwayHazardsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayRailwayHazardsCheck.Name = "displayRailwayHazardsCheck";
            this.displayRailwayHazardsCheck.Size = new System.Drawing.Size(70, 23);
            this.displayRailwayHazardsCheck.TabIndex = 8;
            this.displayRailwayHazardsCheck.Text = "Railway";
            this.displayRailwayHazardsCheck.UseVisualStyleBackColor = true;
            this.displayRailwayHazardsCheck.CheckedChanged += new System.EventHandler(this.poiDisplayCheck_CheckedChanged);
            // 
            // displayTrafficHazardsCheck
            // 
            this.displayTrafficHazardsCheck.AutoSize = true;
            this.displayTrafficHazardsCheck.Checked = true;
            this.displayTrafficHazardsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayTrafficHazardsCheck.Location = new System.Drawing.Point(10, 144);
            this.displayTrafficHazardsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayTrafficHazardsCheck.Name = "displayTrafficHazardsCheck";
            this.displayTrafficHazardsCheck.Size = new System.Drawing.Size(64, 23);
            this.displayTrafficHazardsCheck.TabIndex = 7;
            this.displayTrafficHazardsCheck.Text = "Traffic";
            this.displayTrafficHazardsCheck.UseVisualStyleBackColor = true;
            this.displayTrafficHazardsCheck.CheckedChanged += new System.EventHandler(this.poiDisplayCheck_CheckedChanged);
            // 
            // displayLocationsCheck
            // 
            this.displayLocationsCheck.AutoSize = true;
            this.displayLocationsCheck.Checked = true;
            this.displayLocationsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayLocationsCheck.Location = new System.Drawing.Point(10, 27);
            this.displayLocationsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayLocationsCheck.Name = "displayLocationsCheck";
            this.displayLocationsCheck.Size = new System.Drawing.Size(79, 23);
            this.displayLocationsCheck.TabIndex = 1;
            this.displayLocationsCheck.Text = "Locations";
            this.displayLocationsCheck.UseVisualStyleBackColor = true;
            this.displayLocationsCheck.CheckedChanged += new System.EventHandler(this.displayLocationsCheck_CheckedChanged);
            // 
            // displayShopsCheck
            // 
            this.displayShopsCheck.AutoSize = true;
            this.displayShopsCheck.Checked = true;
            this.displayShopsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayShopsCheck.Location = new System.Drawing.Point(105, 27);
            this.displayShopsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayShopsCheck.Name = "displayShopsCheck";
            this.displayShopsCheck.Size = new System.Drawing.Size(60, 23);
            this.displayShopsCheck.TabIndex = 2;
            this.displayShopsCheck.Text = "Shops";
            this.displayShopsCheck.UseVisualStyleBackColor = true;
            this.displayShopsCheck.CheckedChanged += new System.EventHandler(this.poiDisplayCheck_CheckedChanged);
            // 
            // displayJobsCheck
            // 
            this.displayJobsCheck.AutoSize = true;
            this.displayJobsCheck.Checked = true;
            this.displayJobsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayJobsCheck.Location = new System.Drawing.Point(105, 61);
            this.displayJobsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayJobsCheck.Name = "displayJobsCheck";
            this.displayJobsCheck.Size = new System.Drawing.Size(52, 23);
            this.displayJobsCheck.TabIndex = 4;
            this.displayJobsCheck.Text = "Jobs";
            this.displayJobsCheck.UseVisualStyleBackColor = true;
            this.displayJobsCheck.CheckedChanged += new System.EventHandler(this.poiDisplayCheck_CheckedChanged);
            // 
            // displayTownsCheck
            // 
            this.displayTownsCheck.AutoSize = true;
            this.displayTownsCheck.Checked = true;
            this.displayTownsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayTownsCheck.Location = new System.Drawing.Point(10, 61);
            this.displayTownsCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayTownsCheck.Name = "displayTownsCheck";
            this.displayTownsCheck.Size = new System.Drawing.Size(63, 23);
            this.displayTownsCheck.TabIndex = 3;
            this.displayTownsCheck.Text = "Towns";
            this.displayTownsCheck.UseVisualStyleBackColor = true;
            this.displayTownsCheck.CheckedChanged += new System.EventHandler(this.poiDisplayCheck_CheckedChanged);
            // 
            // gpsUpdateTimer
            // 
            this.gpsUpdateTimer.Interval = 1000;
            this.gpsUpdateTimer.Tick += new System.EventHandler(this.gpsUpdateTimer_Tick);
            // 
            // resetMapButton
            // 
            this.resetMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetMapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resetMapButton.Location = new System.Drawing.Point(488, 567);
            this.resetMapButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetMapButton.Name = "resetMapButton";
            this.resetMapButton.Size = new System.Drawing.Size(52, 35);
            this.resetMapButton.TabIndex = 3;
            this.resetMapButton.Text = "Reset";
            this.resetMapButton.Click += new System.EventHandler(this.resetMapButton_Click);
            // 
            // followCheck
            // 
            this.followCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.followCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.followCheck.BackColor = System.Drawing.Color.AliceBlue;
            this.followCheck.Location = new System.Drawing.Point(488, 18);
            this.followCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.followCheck.Name = "followCheck";
            this.followCheck.Size = new System.Drawing.Size(52, 33);
            this.followCheck.TabIndex = 2;
            this.followCheck.Text = "Follow";
            this.followCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.followCheck.UseVisualStyleBackColor = false;
            // 
            // showRecordButton
            // 
            this.showRecordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showRecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showRecordButton.Location = new System.Drawing.Point(548, 420);
            this.showRecordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showRecordButton.Name = "showRecordButton";
            this.showRecordButton.Size = new System.Drawing.Size(190, 64);
            this.showRecordButton.TabIndex = 6;
            this.showRecordButton.Text = "Waypoint...";
            this.showRecordButton.UseVisualStyleBackColor = true;
            this.showRecordButton.Click += new System.EventHandler(this.showRecordButton_Click);
            // 
            // mapImage
            // 
            this.mapImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapImage.BackColor = System.Drawing.Color.AliceBlue;
            this.mapImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapImage.Location = new System.Drawing.Point(14, 18);
            this.mapImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mapImage.Name = "mapImage";
            this.mapImage.Size = new System.Drawing.Size(466, 584);
            this.mapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mapImage.TabIndex = 5;
            this.mapImage.TabStop = false;
            this.mapImage.Click += new System.EventHandler(this.mapImage_Click);
            this.mapImage.Paint += new System.Windows.Forms.PaintEventHandler(this.mapImage_Paint);
            this.mapImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapImage_MouseDown);
            this.mapImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapImage_MouseMove);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aboutButton.Location = new System.Drawing.Point(686, 1);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(59, 22);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "about";
            this.aboutButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // checkBox1
            // 
            this.MapC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MapC.AutoSize = true;
            this.MapC.Location = new System.Drawing.Point(679, 593);
            this.MapC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MapC.Name = "checkBox1";
            this.MapC.Size = new System.Drawing.Size(77, 23);
            this.MapC.TabIndex = 10;
            this.MapC.Text = "Map 1/2";
            this.MapC.UseVisualStyleBackColor = true;
            this.MapC.CheckedChanged += new System.EventHandler(this.MapC_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(759, 620);
            this.Controls.Add(this.MapC);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.showRecordButton);
            this.Controls.Add(this.followCheck);
            this.Controls.Add(this.resetMapButton);
            this.Controls.Add(this.viewSettingsBox);
            this.Controls.Add(this.zoomMultLabel);
            this.Controls.Add(this.mapImage);
            this.Controls.Add(this.gpsConnectionBox);
            this.Controls.Add(this.zoomSlider);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(775, 658);
            this.Name = "MainForm";
            this.Text = "Alivieska GPS client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).EndInit();
            this.gpsConnectionBox.ResumeLayout(false);
            this.gpsConnectionBox.PerformLayout();
            this.viewSettingsBox.ResumeLayout(false);
            this.viewSettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TrackBar zoomSlider;
		private System.Windows.Forms.TextBox connectionUrlText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gpsConnectionBox;
		private System.Windows.Forms.Button gpsConnectButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox mapImage;
		private System.Windows.Forms.Label zoomMultLabel;
		private System.Windows.Forms.GroupBox viewSettingsBox;
		private System.Windows.Forms.Timer gpsUpdateTimer;
		private System.Windows.Forms.Button resetMapButton;
		private System.Windows.Forms.CheckBox followCheck;
		private System.Windows.Forms.CheckBox displayTownsCheck;
		private System.Windows.Forms.CheckBox displayJobsCheck;
		private System.Windows.Forms.CheckBox displayShopsCheck;
		private System.Windows.Forms.CheckBox displayLocationsCheck;
		private System.Windows.Forms.CheckBox displayHazardsCheck;
		private System.Windows.Forms.CheckBox displayRoadHazardsCheck;
		private System.Windows.Forms.CheckBox displayRailwayHazardsCheck;
		private System.Windows.Forms.CheckBox displayTrafficHazardsCheck;
		private System.Windows.Forms.Button showRecordButton;
		private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.TextBox gpsDataSpeed;
        private System.Windows.Forms.CheckBox Player;
        private System.Windows.Forms.CheckBox Car;
        private System.Windows.Forms.CheckBox MapC;
    }
}

