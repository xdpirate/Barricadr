<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.dirPicker = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnBlock = New System.Windows.Forms.Button()
        Me.btnAllow = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.lblPathText = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblExplanation = New System.Windows.Forms.Label()
        Me.lblCaution = New System.Windows.Forms.Label()
        Me.lblCautionText = New System.Windows.Forms.Label()
        Me.chkRecursiveScan = New System.Windows.Forms.CheckBox()
        Me.chkDarkMode = New System.Windows.Forms.CheckBox()
        Me.lnkGithub = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(12, 304)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(258, 20)
        Me.txtPath.TabIndex = 3
        '
        'dirPicker
        '
        Me.dirPicker.Description = "Select root directory to scan:"
        Me.dirPicker.ShowNewFolderButton = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(276, 302)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(123, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Br&owse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnBlock
        '
        Me.btnBlock.BackColor = System.Drawing.Color.Pink
        Me.btnBlock.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBlock.Location = New System.Drawing.Point(12, 330)
        Me.btnBlock.Name = "btnBlock"
        Me.btnBlock.Size = New System.Drawing.Size(126, 68)
        Me.btnBlock.TabIndex = 5
        Me.btnBlock.Tag = "block"
        Me.btnBlock.Text = "&Block"
        Me.btnBlock.UseVisualStyleBackColor = False
        '
        'btnAllow
        '
        Me.btnAllow.BackColor = System.Drawing.Color.PaleGreen
        Me.btnAllow.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllow.Location = New System.Drawing.Point(144, 330)
        Me.btnAllow.Name = "btnAllow"
        Me.btnAllow.Size = New System.Drawing.Size(126, 68)
        Me.btnAllow.TabIndex = 6
        Me.btnAllow.Tag = "allow"
        Me.btnAllow.Text = "&Allow"
        Me.btnAllow.UseVisualStyleBackColor = False
        '
        'btnRestore
        '
        Me.btnRestore.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnRestore.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestore.Location = New System.Drawing.Point(276, 331)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(126, 68)
        Me.btnRestore.TabIndex = 7
        Me.btnRestore.Tag = "restore"
        Me.btnRestore.Text = "&Restore"
        Me.btnRestore.UseVisualStyleBackColor = False
        '
        'lblPathText
        '
        Me.lblPathText.AutoSize = True
        Me.lblPathText.Location = New System.Drawing.Point(12, 288)
        Me.lblPathText.Name = "lblPathText"
        Me.lblPathText.Size = New System.Drawing.Size(29, 13)
        Me.lblPathText.TabIndex = 2
        Me.lblPathText.Text = "Path"
        '
        'lblHeader
        '
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(12, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(387, 50)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Barricadr"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblExplanation
        '
        Me.lblExplanation.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExplanation.Location = New System.Drawing.Point(12, 70)
        Me.lblExplanation.Name = "lblExplanation"
        Me.lblExplanation.Size = New System.Drawing.Size(387, 104)
        Me.lblExplanation.TabIndex = 1
        Me.lblExplanation.Text = resources.GetString("lblExplanation.Text")
        '
        'lblCaution
        '
        Me.lblCaution.AutoSize = True
        Me.lblCaution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCaution.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaution.ForeColor = System.Drawing.Color.Red
        Me.lblCaution.Location = New System.Drawing.Point(12, 174)
        Me.lblCaution.Name = "lblCaution"
        Me.lblCaution.Size = New System.Drawing.Size(64, 15)
        Me.lblCaution.TabIndex = 8
        Me.lblCaution.Text = "CAUTION: "
        '
        'lblCautionText
        '
        Me.lblCautionText.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCautionText.Location = New System.Drawing.Point(81, 174)
        Me.lblCautionText.Name = "lblCautionText"
        Me.lblCautionText.Size = New System.Drawing.Size(318, 101)
        Me.lblCautionText.TabIndex = 9
        Me.lblCautionText.Text = resources.GetString("lblCautionText.Text")
        '
        'chkRecursiveScan
        '
        Me.chkRecursiveScan.AutoSize = True
        Me.chkRecursiveScan.Checked = True
        Me.chkRecursiveScan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecursiveScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecursiveScan.Location = New System.Drawing.Point(287, 284)
        Me.chkRecursiveScan.Name = "chkRecursiveScan"
        Me.chkRecursiveScan.Size = New System.Drawing.Size(100, 17)
        Me.chkRecursiveScan.TabIndex = 10
        Me.chkRecursiveScan.Text = "Recursive scan"
        Me.chkRecursiveScan.UseVisualStyleBackColor = True
        '
        'chkDarkMode
        '
        Me.chkDarkMode.AutoSize = True
        Me.chkDarkMode.Checked = True
        Me.chkDarkMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDarkMode.Location = New System.Drawing.Point(12, 401)
        Me.chkDarkMode.Name = "chkDarkMode"
        Me.chkDarkMode.Size = New System.Drawing.Size(78, 17)
        Me.chkDarkMode.TabIndex = 11
        Me.chkDarkMode.Text = "Dark mode"
        Me.chkDarkMode.UseVisualStyleBackColor = True
        '
        'lnkGithub
        '
        Me.lnkGithub.AutoSize = True
        Me.lnkGithub.Location = New System.Drawing.Point(361, 402)
        Me.lnkGithub.Name = "lnkGithub"
        Me.lnkGithub.Size = New System.Drawing.Size(38, 13)
        Me.lnkGithub.TabIndex = 12
        Me.lnkGithub.TabStop = True
        Me.lnkGithub.Text = "Github"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 424)
        Me.Controls.Add(Me.lnkGithub)
        Me.Controls.Add(Me.chkDarkMode)
        Me.Controls.Add(Me.chkRecursiveScan)
        Me.Controls.Add(Me.lblCautionText)
        Me.Controls.Add(Me.lblCaution)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblExplanation)
        Me.Controls.Add(Me.lblPathText)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.btnAllow)
        Me.Controls.Add(Me.btnBlock)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barricadr"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPath As TextBox
    Friend WithEvents dirPicker As FolderBrowserDialog
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnBlock As Button
    Friend WithEvents btnAllow As Button
    Friend WithEvents btnRestore As Button
    Friend WithEvents lblPathText As Label
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblExplanation As Label
    Friend WithEvents lblCaution As Label
    Friend WithEvents lblCautionText As Label
    Friend WithEvents chkRecursiveScan As CheckBox
    Friend WithEvents chkDarkMode As CheckBox
    Friend WithEvents lnkGithub As LinkLabel
End Class
