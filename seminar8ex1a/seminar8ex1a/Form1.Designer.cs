namespace seminar8ex1a
{
partial class Form1
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
        this.panelDraw = new System.Windows.Forms.Panel();
        this.btnTriangulate = new System.Windows.Forms.Button();
        this.listBoxTriangles = new System.Windows.Forms.ListBox();
        this.SuspendLayout();
        // 
        // panelDraw
        // 
        this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.panelDraw.Location = new System.Drawing.Point(12, 12);
        this.panelDraw.Name = "panelDraw";
        this.panelDraw.Size = new System.Drawing.Size(400, 400);
        this.panelDraw.TabIndex = 0;
        this.panelDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDraw_Paint);
        this.panelDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseClick);
        // 
        // btnTriangulate
        // 
        this.btnTriangulate.Location = new System.Drawing.Point(430, 12);
        this.btnTriangulate.Name = "btnTriangulate";
        this.btnTriangulate.Size = new System.Drawing.Size(100, 23);
        this.btnTriangulate.TabIndex = 1;
        this.btnTriangulate.Text = "Triangulate";
        this.btnTriangulate.UseVisualStyleBackColor = true;
        this.btnTriangulate.Click += new System.EventHandler(this.btnTriangulate_Click);
        // 
        // listBoxTriangles
        // 
        this.listBoxTriangles.FormattingEnabled = true;
        this.listBoxTriangles.Location = new System.Drawing.Point(430, 50);
        this.listBoxTriangles.Name = "listBoxTriangles";
        this.listBoxTriangles.Size = new System.Drawing.Size(150, 355);
        this.listBoxTriangles.TabIndex = 2;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 450);
        this.Controls.Add(this.listBoxTriangles);
        this.Controls.Add(this.btnTriangulate);
        this.Controls.Add(this.panelDraw);
        this.Name = "Form1";
        this.Text = "Polygon Triangulation";
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panelDraw;
    private System.Windows.Forms.Button btnTriangulate;
    private System.Windows.Forms.ListBox listBoxTriangles;

}

}

