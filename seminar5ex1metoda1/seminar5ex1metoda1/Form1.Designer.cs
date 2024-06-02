namespace seminar5ex1metoda1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.xInput = new System.Windows.Forms.TextBox();
            this.yInput = new System.Windows.Forms.TextBox();
            this.addPointButton = new System.Windows.Forms.Button();
            this.clearPointsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(400, 300);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(12, 330);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(100, 20);
            this.xInput.TabIndex = 1;
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(118, 330);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(100, 20);
            this.yInput.TabIndex = 2;
            // 
            // addPointButton
            // 
            this.addPointButton.Location = new System.Drawing.Point(224, 328);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(75, 23);
            this.addPointButton.TabIndex = 3;
            this.addPointButton.Text = "Add Point";
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // clearPointsButton
            // 
            this.clearPointsButton.Location = new System.Drawing.Point(305, 328);
            this.clearPointsButton.Name = "clearPointsButton";
            this.clearPointsButton.Size = new System.Drawing.Size(107, 23);
            this.clearPointsButton.TabIndex = 4;
            this.clearPointsButton.Text = "Clear All Points";
            this.clearPointsButton.UseVisualStyleBackColor = true;
            this.clearPointsButton.Click += new System.EventHandler(this.clearPointsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 362);
            this.Controls.Add(this.clearPointsButton);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Convex Hull Jarvis Algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.Button clearPointsButton;
    }
}