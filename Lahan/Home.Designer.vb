<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TestingBtn = New System.Windows.Forms.Button()
        Me.KlasifikasiBtn = New System.Windows.Forms.Button()
        Me.TrainingBtn = New System.Windows.Forms.Button()
        Me.TtgAppBtn = New System.Windows.Forms.Button()
        Me.TtgAuBtn = New System.Windows.Forms.Button()
        Me.PerubahanBtn = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Maroon
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 213)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(925, 58)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PROGRAM KLASIFIKASI PEMETAAN LAHAN TINGKAT KECAMATAN " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DI WILAYAH DEPOK, TANGERAN" &
    "G SELATAN, DAN BOGOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(386, 140)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'TestingBtn
        '
        Me.TestingBtn.BackColor = System.Drawing.Color.White
        Me.TestingBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.TestingBtn.FlatAppearance.BorderSize = 2
        Me.TestingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TestingBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TestingBtn.Location = New System.Drawing.Point(48, 326)
        Me.TestingBtn.Name = "TestingBtn"
        Me.TestingBtn.Size = New System.Drawing.Size(171, 71)
        Me.TestingBtn.TabIndex = 2
        Me.TestingBtn.Text = "Testing"
        Me.TestingBtn.UseVisualStyleBackColor = False
        '
        'KlasifikasiBtn
        '
        Me.KlasifikasiBtn.BackColor = System.Drawing.Color.White
        Me.KlasifikasiBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.KlasifikasiBtn.FlatAppearance.BorderSize = 2
        Me.KlasifikasiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.KlasifikasiBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KlasifikasiBtn.Location = New System.Drawing.Point(707, 326)
        Me.KlasifikasiBtn.Name = "KlasifikasiBtn"
        Me.KlasifikasiBtn.Size = New System.Drawing.Size(171, 71)
        Me.KlasifikasiBtn.TabIndex = 3
        Me.KlasifikasiBtn.Text = "Hasil Klasifikasi"
        Me.KlasifikasiBtn.UseVisualStyleBackColor = False
        '
        'TrainingBtn
        '
        Me.TrainingBtn.BackColor = System.Drawing.Color.White
        Me.TrainingBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.TrainingBtn.FlatAppearance.BorderSize = 2
        Me.TrainingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TrainingBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrainingBtn.Location = New System.Drawing.Point(378, 326)
        Me.TrainingBtn.Name = "TrainingBtn"
        Me.TrainingBtn.Size = New System.Drawing.Size(171, 71)
        Me.TrainingBtn.TabIndex = 4
        Me.TrainingBtn.Text = "Training"
        Me.TrainingBtn.UseVisualStyleBackColor = False
        '
        'TtgAppBtn
        '
        Me.TtgAppBtn.BackColor = System.Drawing.Color.White
        Me.TtgAppBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.TtgAppBtn.FlatAppearance.BorderSize = 2
        Me.TtgAppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TtgAppBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TtgAppBtn.Location = New System.Drawing.Point(378, 443)
        Me.TtgAppBtn.Name = "TtgAppBtn"
        Me.TtgAppBtn.Size = New System.Drawing.Size(171, 71)
        Me.TtgAppBtn.TabIndex = 7
        Me.TtgAppBtn.Text = "Tentang Aplikasi"
        Me.TtgAppBtn.UseVisualStyleBackColor = False
        '
        'TtgAuBtn
        '
        Me.TtgAuBtn.BackColor = System.Drawing.Color.White
        Me.TtgAuBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.TtgAuBtn.FlatAppearance.BorderSize = 2
        Me.TtgAuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TtgAuBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TtgAuBtn.Location = New System.Drawing.Point(707, 443)
        Me.TtgAuBtn.Name = "TtgAuBtn"
        Me.TtgAuBtn.Size = New System.Drawing.Size(171, 71)
        Me.TtgAuBtn.TabIndex = 6
        Me.TtgAuBtn.Text = "Tentang Pembuat"
        Me.TtgAuBtn.UseVisualStyleBackColor = False
        '
        'PerubahanBtn
        '
        Me.PerubahanBtn.BackColor = System.Drawing.Color.White
        Me.PerubahanBtn.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.PerubahanBtn.FlatAppearance.BorderSize = 2
        Me.PerubahanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PerubahanBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerubahanBtn.Location = New System.Drawing.Point(48, 443)
        Me.PerubahanBtn.Name = "PerubahanBtn"
        Me.PerubahanBtn.Size = New System.Drawing.Size(171, 71)
        Me.PerubahanBtn.TabIndex = 5
        Me.PerubahanBtn.Text = "Perubahan Lahan"
        Me.PerubahanBtn.UseVisualStyleBackColor = False
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Maroon
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(917, 561)
        Me.Controls.Add(Me.TtgAppBtn)
        Me.Controls.Add(Me.TtgAuBtn)
        Me.Controls.Add(Me.PerubahanBtn)
        Me.Controls.Add(Me.TrainingBtn)
        Me.Controls.Add(Me.KlasifikasiBtn)
        Me.Controls.Add(Me.TestingBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TestingBtn As Button
    Friend WithEvents KlasifikasiBtn As Button
    Friend WithEvents TrainingBtn As Button
    Friend WithEvents TtgAppBtn As Button
    Friend WithEvents TtgAuBtn As Button
    Friend WithEvents PerubahanBtn As Button
End Class
