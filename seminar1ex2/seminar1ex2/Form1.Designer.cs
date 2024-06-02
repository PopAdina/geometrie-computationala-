namespace seminar1ex2
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
            this.xInput = new System.Windows.Forms.TextBox();
            this.yInput = new System.Windows.Forms.TextBox();
            this.addPointSet1Button = new System.Windows.Forms.Button();
            this.addPointSet2Button = new System.Windows.Forms.Button();
            this.findClosestPointsButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(30, 10);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(50, 20);
            this.xInput.TabIndex = 0;
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(30, 40);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(50, 20);
            this.yInput.TabIndex = 1;
            // 
            // addPointSet1Button
            // 
            this.addPointSet1Button.Location = new System.Drawing.Point(90, 10);
            this.addPointSet1Button.Name = "addPointSet1Button";
            this.addPointSet1Button.Size = new System.Drawing.Size(100, 23);
            this.addPointSet1Button.TabIndex = 2;
            this.addPointSet1Button.Text = "Add Point to Set 1";
            this.addPointSet1Button.UseVisualStyleBackColor = true;
            this.addPointSet1Button.Click += new System.EventHandler(this.addPointSet1Button_Click);
            // 
            // addPointSet2Button
            // 
            this.addPointSet2Button.Location = new System.Drawing.Point(90, 40);
            this.addPointSet2Button.Name = "addPointSet2Button";
            this.addPointSet2Button.Size = new System.Drawing.Size(100, 23);
            this.addPointSet2Button.TabIndex = 3;
            this.addPointSet2Button.Text = "Add Point to Set 2";
            this.addPointSet2Button.UseVisualStyleBackColor = true;
            this.addPointSet2Button.Click += new System.EventHandler(this.addPointSet2Button_Click);
            // 
            // findClosestPointsButton
            // 
            this.findClosestPointsButton.Location = new System.Drawing.Point(200, 25);
            this.findClosestPointsButton.Name = "findClosestPointsButton";
            this.findClosestPointsButton.Size = new System.Drawing.Size(120, 23);
            this.findClosestPointsButton.TabIndex = 4;
            this.findClosestPointsButton.Text = "Find Closest Points";
            this.findClosestPointsButton.UseVisualStyleBackColor = true;
            this.findClosestPointsButton.Click += new System.EventHandler(this.findClosestPointsButton_Click);
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(10, 70);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(760, 480);
            this.canvas.TabIndex = 5;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.findClosestPointsButton);
            this.Controls.Add(this.addPointSet2Button);
            this.Controls.Add(this.addPointSet1Button);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Name = "Form1";
            this.Text = "Find Closest Points";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.Button addPointSet1Button;
        private System.Windows.Forms.Button addPointSet2Button;
        private System.Windows.Forms.Button findClosestPointsButton;
        private System.Windows.Forms.PictureBox canvas;
    }
}