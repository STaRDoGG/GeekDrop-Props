<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.llJSE = New System.Windows.Forms.LinkLabel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.rtbDescription = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picDonate = New System.Windows.Forms.PictureBox()
        Me.picAngel = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblGodWare = New System.Windows.Forms.Label()
        Me.picGDLogo = New System.Windows.Forms.PictureBox()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picDonate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAngel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.picGDLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'llJSE
        '
        Me.llJSE.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.llJSE.AutoSize = True
        Me.llJSE.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.llJSE.LinkColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.llJSE.Location = New System.Drawing.Point(456, 373)
        Me.llJSE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.llJSE.Name = "llJSE"
        Me.llJSE.Size = New System.Drawing.Size(227, 13)
        Me.llJSE.TabIndex = 4
        Me.llJSE.TabStop = True
        Me.llJSE.Text = "GeekDrop Props created by J. Scott Elblein"
        Me.llJSE.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(658, 0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(32, 23)
        Me.btnExit.TabIndex = 26
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'picLogo
        '
        Me.picLogo.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(12, 9)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(32, 32)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLogo.TabIndex = 23
        Me.picLogo.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkGray
        Me.lblTitle.Location = New System.Drawing.Point(50, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(144, 25)
        Me.lblTitle.TabIndex = 22
        Me.lblTitle.Text = "GeekDrop Props"
        '
        'rtbDescription
        '
        Me.rtbDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbDescription.ForeColor = System.Drawing.Color.White
        Me.rtbDescription.Location = New System.Drawing.Point(3, 3)
        Me.rtbDescription.Name = "rtbDescription"
        Me.rtbDescription.ReadOnly = True
        Me.rtbDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbDescription.ShortcutsEnabled = False
        Me.rtbDescription.Size = New System.Drawing.Size(659, 288)
        Me.rtbDescription.TabIndex = 27
        Me.rtbDescription.TabStop = False
        Me.rtbDescription.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.rtbDescription)
        Me.Panel1.Location = New System.Drawing.Point(12, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 294)
        Me.Panel1.TabIndex = 28
        '
        'picDonate
        '
        Me.picDonate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picDonate.Image = CType(resources.GetObject("picDonate.Image"), System.Drawing.Image)
        Me.picDonate.Location = New System.Drawing.Point(291, 538)
        Me.picDonate.Name = "picDonate"
        Me.picDonate.Size = New System.Drawing.Size(92, 30)
        Me.picDonate.TabIndex = 29
        Me.picDonate.TabStop = False
        '
        'picAngel
        '
        Me.picAngel.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.picAngel.Image = CType(resources.GetObject("picAngel.Image"), System.Drawing.Image)
        Me.picAngel.Location = New System.Drawing.Point(344, 52)
        Me.picAngel.Name = "picAngel"
        Me.picAngel.Size = New System.Drawing.Size(28, 26)
        Me.picAngel.TabIndex = 31
        Me.picAngel.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.picAngel)
        Me.Panel2.Controls.Add(Me.lblGodWare)
        Me.Panel2.Location = New System.Drawing.Point(12, 400)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 131)
        Me.Panel2.TabIndex = 32
        '
        'lblGodWare
        '
        Me.lblGodWare.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblGodWare.Font = New System.Drawing.Font("Segoe UI", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGodWare.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lblGodWare.Location = New System.Drawing.Point(3, 4)
        Me.lblGodWare.Name = "lblGodWare"
        Me.lblGodWare.Padding = New System.Windows.Forms.Padding(5)
        Me.lblGodWare.Size = New System.Drawing.Size(659, 124)
        Me.lblGodWare.TabIndex = 32
        Me.lblGodWare.Text = "[ Placeholder ]"
        '
        'picGDLogo
        '
        Me.picGDLogo.Image = Global.GeekDropProps.My.Resources.Resources.GeekDrop_Watermark__New_Cyan_
        Me.picGDLogo.Location = New System.Drawing.Point(12, 357)
        Me.picGDLogo.Name = "picGDLogo"
        Me.picGDLogo.Size = New System.Drawing.Size(245, 29)
        Me.picGDLogo.TabIndex = 33
        Me.picGDLogo.TabStop = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(690, 575)
        Me.Controls.Add(Me.picGDLogo)
        Me.Controls.Add(Me.picDonate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.llJSE)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About GeekDrop Props"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picDonate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAngel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.picGDLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents llJSE As System.Windows.Forms.LinkLabel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents rtbDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picDonate As System.Windows.Forms.PictureBox
    Friend WithEvents picAngel As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblGodWare As System.Windows.Forms.Label
    Friend WithEvents picGDLogo As System.Windows.Forms.PictureBox
End Class
