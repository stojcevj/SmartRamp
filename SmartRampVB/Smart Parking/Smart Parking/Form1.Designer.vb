<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.crvencom = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.zelencom = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.imetxt = New System.Windows.Forms.TextBox()
        Me.datatxt = New System.Windows.Forms.TextBox()
        Me.vremetxt = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(6, 19)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(555, 166)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(288, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 196)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vlez"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(8, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Text = "Selektiraj Porta"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(154, 58)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Konektiraj"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(8, 75)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 368)
        Me.ListBox1.TabIndex = 4
        '
        'crvencom
        '
        Me.crvencom.BackColor = System.Drawing.Color.Red
        Me.crvencom.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.crvencom.Location = New System.Drawing.Point(8, 6)
        Me.crvencom.Name = "crvencom"
        Me.crvencom.Size = New System.Drawing.Size(21, 20)
        '
        'zelencom
        '
        Me.zelencom.BackColor = System.Drawing.Color.Lime
        Me.zelencom.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.zelencom.Location = New System.Drawing.Point(8, 6)
        Me.zelencom.Name = "zelencom"
        Me.zelencom.Size = New System.Drawing.Size(21, 20)
        Me.zelencom.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.ShapeContainer2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(136, 452)
        Me.Panel1.TabIndex = 9
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.zelencom, Me.crvencom})
        Me.ShapeContainer2.Size = New System.Drawing.Size(136, 452)
        Me.ShapeContainer2.TabIndex = 5
        Me.ShapeContainer2.TabStop = False
        '
        'imetxt
        '
        Me.imetxt.Location = New System.Drawing.Point(20, 468)
        Me.imetxt.Name = "imetxt"
        Me.imetxt.Size = New System.Drawing.Size(100, 20)
        Me.imetxt.TabIndex = 10
        '
        'datatxt
        '
        Me.datatxt.Location = New System.Drawing.Point(20, 507)
        Me.datatxt.Name = "datatxt"
        Me.datatxt.Size = New System.Drawing.Size(100, 20)
        Me.datatxt.TabIndex = 11
        '
        'vremetxt
        '
        Me.vremetxt.Location = New System.Drawing.Point(20, 543)
        Me.vremetxt.Name = "vremetxt"
        Me.vremetxt.Size = New System.Drawing.Size(100, 20)
        Me.vremetxt.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 670)
        Me.Controls.Add(Me.vremetxt)
        Me.Controls.Add(Me.datatxt)
        Me.Controls.Add(Me.imetxt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Smart Parking"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents crvencom As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents zelencom As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents imetxt As System.Windows.Forms.TextBox
    Friend WithEvents datatxt As System.Windows.Forms.TextBox
    Friend WithEvents vremetxt As System.Windows.Forms.TextBox

End Class
