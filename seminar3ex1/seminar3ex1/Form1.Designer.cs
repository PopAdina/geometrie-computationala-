namespace seminar3ex1
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
            this.addPointButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
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
            // addPointButton
            // 
            this.addPointButton.Location = new System.Drawing.Point(90, 25);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(75, 23);
            this.addPointButton.TabIndex = 2;
            this.addPointButton.Text = "Add Point";
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(190, 25);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 23);
            this.solveButton.TabIndex = 3;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(10, 70);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(760, 480);
            this.canvas.TabIndex = 4;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Name = "Form1";
            this.Text = "Minimum Sum of Segment Lengths";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.PictureBox canvas;
    }
}
