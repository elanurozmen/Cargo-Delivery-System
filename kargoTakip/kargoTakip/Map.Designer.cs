
namespace kargoTakip
{
    partial class Map
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
            this.MyMap = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // MyMap
            // 
            this.MyMap.Bearing = 0F;
            this.MyMap.CanDragMap = true;
            this.MyMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MyMap.GrayScaleMode = false;
            this.MyMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MyMap.LevelsKeepInMemory = 5;
            this.MyMap.Location = new System.Drawing.Point(1, 0);
            this.MyMap.MarkersEnabled = true;
            this.MyMap.MaxZoom = 2;
            this.MyMap.MinZoom = 2;
            this.MyMap.MouseWheelZoomEnabled = true;
            this.MyMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MyMap.Name = "MyMap";
            this.MyMap.NegativeMode = false;
            this.MyMap.PolygonsEnabled = true;
            this.MyMap.RetryLoadTile = 0;
            this.MyMap.RoutesEnabled = true;
            this.MyMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MyMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MyMap.ShowTileGridLines = false;
            this.MyMap.Size = new System.Drawing.Size(1642, 1082);
            this.MyMap.TabIndex = 3;
            this.MyMap.Zoom = 0D;
            this.MyMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyMap_MouseDoubleClick);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1645, 1084);
            this.Controls.Add(this.MyMap);
            this.Name = "Map";
            this.Text = "Harita";
            this.Load += new System.EventHandler(this.Map_Load_1);
            this.ResumeLayout(false);

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl MyMap;
    }
}