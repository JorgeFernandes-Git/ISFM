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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pb_Xaxis = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btn_Homing = New System.Windows.Forms.Button()
        Me.pb_Yaxis = New System.Windows.Forms.PictureBox()
        Me.pb_Zaxis = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_coordX = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btn_ACC = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_deslocamento = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_coordY = New System.Windows.Forms.TextBox()
        Me.txt_coordZ = New System.Windows.Forms.TextBox()
        Me.btn_SendCoord = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.btn_Enable = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_SerialPorts = New System.Windows.Forms.ComboBox()
        Me.txt_DataReceived = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txt_XP8 = New System.Windows.Forms.TextBox()
        Me.txt_ZP8 = New System.Windows.Forms.TextBox()
        Me.txt_YP8 = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txt_XP7 = New System.Windows.Forms.TextBox()
        Me.txt_ZP7 = New System.Windows.Forms.TextBox()
        Me.txt_YP7 = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txt_XP6 = New System.Windows.Forms.TextBox()
        Me.txt_ZP6 = New System.Windows.Forms.TextBox()
        Me.txt_YP6 = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txt_XP5 = New System.Windows.Forms.TextBox()
        Me.txt_ZP5 = New System.Windows.Forms.TextBox()
        Me.txt_YP5 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txt_XP4 = New System.Windows.Forms.TextBox()
        Me.txt_ZP4 = New System.Windows.Forms.TextBox()
        Me.txt_YP4 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txt_XP3 = New System.Windows.Forms.TextBox()
        Me.txt_ZP3 = New System.Windows.Forms.TextBox()
        Me.txt_YP3 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_XP2 = New System.Windows.Forms.TextBox()
        Me.txt_ZP2 = New System.Windows.Forms.TextBox()
        Me.txt_YP2 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txt_XP1 = New System.Windows.Forms.TextBox()
        Me.txt_ZP1 = New System.Windows.Forms.TextBox()
        Me.txt_YP1 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btn_Simu = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txt_ACCmax = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btn_Settings = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_Vel = New System.Windows.Forms.TextBox()
        Me.txt_ACCmin = New System.Windows.Forms.TextBox()
        Me.cb_PulRev = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.CB_Encoding = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Encouding = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CB_StopBits = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CB_BaudRate = New System.Windows.Forms.ComboBox()
        Me.CB_DataBits = New System.Windows.Forms.ComboBox()
        Me.CB_Parity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Control = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.About = New System.Windows.Forms.GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pb_Xaxis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Yaxis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Zaxis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Control.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.About.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'SerialPort1
        '
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(714, 669)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btn_Connect)
        Me.TabPage1.Controls.Add(Me.btn_Enable)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cb_SerialPorts)
        Me.TabPage1.Controls.Add(Me.txt_DataReceived)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(706, 637)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Control"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label31)
        Me.GroupBox4.Controls.Add(Me.pb_Xaxis)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.btn_Homing)
        Me.GroupBox4.Controls.Add(Me.pb_Yaxis)
        Me.GroupBox4.Controls.Add(Me.pb_Zaxis)
        Me.GroupBox4.Location = New System.Drawing.Point(411, 112)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(249, 315)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Homing Rotine"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(90, 180)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(117, 19)
        Me.Label31.TabIndex = 25
        Me.Label31.Text = "X Home limit"
        '
        'pb_Xaxis
        '
        Me.pb_Xaxis.Image = Global.GUI_RRplano.My.Resources.Resources.oval
        Me.pb_Xaxis.Location = New System.Drawing.Point(41, 176)
        Me.pb_Xaxis.Name = "pb_Xaxis"
        Me.pb_Xaxis.Size = New System.Drawing.Size(24, 24)
        Me.pb_Xaxis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Xaxis.TabIndex = 24
        Me.pb_Xaxis.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(90, 114)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(117, 19)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Y Home limit"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(90, 147)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 19)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Z Home limit"
        '
        'btn_Homing
        '
        Me.btn_Homing.Enabled = False
        Me.btn_Homing.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Homing.Location = New System.Drawing.Point(41, 60)
        Me.btn_Homing.Name = "btn_Homing"
        Me.btn_Homing.Size = New System.Drawing.Size(131, 28)
        Me.btn_Homing.TabIndex = 9
        Me.btn_Homing.Text = "Auto Home"
        Me.btn_Homing.UseVisualStyleBackColor = True
        '
        'pb_Yaxis
        '
        Me.pb_Yaxis.Image = Global.GUI_RRplano.My.Resources.Resources.oval
        Me.pb_Yaxis.Location = New System.Drawing.Point(41, 114)
        Me.pb_Yaxis.Name = "pb_Yaxis"
        Me.pb_Yaxis.Size = New System.Drawing.Size(24, 24)
        Me.pb_Yaxis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Yaxis.TabIndex = 20
        Me.pb_Yaxis.TabStop = False
        '
        'pb_Zaxis
        '
        Me.pb_Zaxis.Image = Global.GUI_RRplano.My.Resources.Resources.oval
        Me.pb_Zaxis.Location = New System.Drawing.Point(41, 145)
        Me.pb_Zaxis.Name = "pb_Zaxis"
        Me.pb_Zaxis.Size = New System.Drawing.Size(24, 24)
        Me.pb_Zaxis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Zaxis.TabIndex = 19
        Me.pb_Zaxis.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Select COM"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txt_coordX)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.btn_ACC)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txt_deslocamento)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_coordY)
        Me.GroupBox1.Controls.Add(Me.txt_coordZ)
        Me.GroupBox1.Controls.Add(Me.btn_SendCoord)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(41, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 315)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Move to Position"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(269, 129)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(27, 19)
        Me.Label29.TabIndex = 22
        Me.Label29.Text = "mm"
        '
        'txt_coordX
        '
        Me.txt_coordX.Enabled = False
        Me.txt_coordX.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_coordX.Location = New System.Drawing.Point(171, 128)
        Me.txt_coordX.Name = "txt_coordX"
        Me.txt_coordX.Size = New System.Drawing.Size(91, 26)
        Me.txt_coordX.TabIndex = 20
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(39, 129)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(117, 19)
        Me.Label30.TabIndex = 21
        Me.Label30.Text = "X Coordinate"
        '
        'btn_ACC
        '
        Me.btn_ACC.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_ACC.Enabled = False
        Me.btn_ACC.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ACC.Location = New System.Drawing.Point(31, 237)
        Me.btn_ACC.Name = "btn_ACC"
        Me.btn_ACC.Size = New System.Drawing.Size(125, 28)
        Me.btn_ACC.TabIndex = 19
        Me.btn_ACC.Text = "Acceleration"
        Me.btn_ACC.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(269, 189)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 19)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "mm"
        '
        'txt_deslocamento
        '
        Me.txt_deslocamento.Enabled = False
        Me.txt_deslocamento.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_deslocamento.Location = New System.Drawing.Point(171, 186)
        Me.txt_deslocamento.Name = "txt_deslocamento"
        Me.txt_deslocamento.ReadOnly = True
        Me.txt_deslocamento.Size = New System.Drawing.Size(91, 26)
        Me.txt_deslocamento.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(39, 189)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 19)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Displacement"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(269, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 19)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "mm"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(269, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 19)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "mm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Y Coordinate"
        '
        'txt_coordY
        '
        Me.txt_coordY.Enabled = False
        Me.txt_coordY.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_coordY.Location = New System.Drawing.Point(171, 58)
        Me.txt_coordY.Name = "txt_coordY"
        Me.txt_coordY.Size = New System.Drawing.Size(91, 26)
        Me.txt_coordY.TabIndex = 2
        '
        'txt_coordZ
        '
        Me.txt_coordZ.Enabled = False
        Me.txt_coordZ.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_coordZ.Location = New System.Drawing.Point(171, 93)
        Me.txt_coordZ.Name = "txt_coordZ"
        Me.txt_coordZ.Size = New System.Drawing.Size(91, 26)
        Me.txt_coordZ.TabIndex = 3
        '
        'btn_SendCoord
        '
        Me.btn_SendCoord.Enabled = False
        Me.btn_SendCoord.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SendCoord.Location = New System.Drawing.Point(177, 237)
        Me.btn_SendCoord.Name = "btn_SendCoord"
        Me.btn_SendCoord.Size = New System.Drawing.Size(125, 28)
        Me.btn_SendCoord.TabIndex = 4
        Me.btn_SendCoord.Text = "Run"
        Me.btn_SendCoord.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Z Coordinate"
        '
        'btn_Connect
        '
        Me.btn_Connect.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Connect.Location = New System.Drawing.Point(128, 42)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(139, 28)
        Me.btn_Connect.TabIndex = 0
        Me.btn_Connect.Text = "Connect"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'btn_Enable
        '
        Me.btn_Enable.Enabled = False
        Me.btn_Enable.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Enable.Location = New System.Drawing.Point(497, 43)
        Me.btn_Enable.Name = "btn_Enable"
        Me.btn_Enable.Size = New System.Drawing.Size(160, 28)
        Me.btn_Enable.TabIndex = 10
        Me.btn_Enable.Text = "Enable Motors"
        Me.btn_Enable.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 464)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 19)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Data received"
        '
        'cb_SerialPorts
        '
        Me.cb_SerialPorts.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_SerialPorts.FormattingEnabled = True
        Me.cb_SerialPorts.Location = New System.Drawing.Point(38, 43)
        Me.cb_SerialPorts.Name = "cb_SerialPorts"
        Me.cb_SerialPorts.Size = New System.Drawing.Size(70, 27)
        Me.cb_SerialPorts.TabIndex = 1
        '
        'txt_DataReceived
        '
        Me.txt_DataReceived.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DataReceived.Location = New System.Drawing.Point(41, 486)
        Me.txt_DataReceived.Multiline = True
        Me.txt_DataReceived.Name = "txt_DataReceived"
        Me.txt_DataReceived.ReadOnly = True
        Me.txt_DataReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_DataReceived.Size = New System.Drawing.Size(619, 133)
        Me.txt_DataReceived.TabIndex = 8
        '
        'TabPage4
        '
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage4.Controls.Add(Me.btn_save)
        Me.TabPage4.Controls.Add(Me.Label39)
        Me.TabPage4.Controls.Add(Me.txt_XP8)
        Me.TabPage4.Controls.Add(Me.txt_ZP8)
        Me.TabPage4.Controls.Add(Me.txt_YP8)
        Me.TabPage4.Controls.Add(Me.Label38)
        Me.TabPage4.Controls.Add(Me.txt_XP7)
        Me.TabPage4.Controls.Add(Me.txt_ZP7)
        Me.TabPage4.Controls.Add(Me.txt_YP7)
        Me.TabPage4.Controls.Add(Me.Label37)
        Me.TabPage4.Controls.Add(Me.txt_XP6)
        Me.TabPage4.Controls.Add(Me.txt_ZP6)
        Me.TabPage4.Controls.Add(Me.txt_YP6)
        Me.TabPage4.Controls.Add(Me.Label36)
        Me.TabPage4.Controls.Add(Me.txt_XP5)
        Me.TabPage4.Controls.Add(Me.txt_ZP5)
        Me.TabPage4.Controls.Add(Me.txt_YP5)
        Me.TabPage4.Controls.Add(Me.Label35)
        Me.TabPage4.Controls.Add(Me.txt_XP4)
        Me.TabPage4.Controls.Add(Me.txt_ZP4)
        Me.TabPage4.Controls.Add(Me.txt_YP4)
        Me.TabPage4.Controls.Add(Me.Label34)
        Me.TabPage4.Controls.Add(Me.txt_XP3)
        Me.TabPage4.Controls.Add(Me.txt_ZP3)
        Me.TabPage4.Controls.Add(Me.txt_YP3)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.txt_XP2)
        Me.TabPage4.Controls.Add(Me.txt_ZP2)
        Me.TabPage4.Controls.Add(Me.txt_YP2)
        Me.TabPage4.Controls.Add(Me.Label33)
        Me.TabPage4.Controls.Add(Me.txt_XP1)
        Me.TabPage4.Controls.Add(Me.txt_ZP1)
        Me.TabPage4.Controls.Add(Me.txt_YP1)
        Me.TabPage4.Controls.Add(Me.Label32)
        Me.TabPage4.Controls.Add(Me.Label26)
        Me.TabPage4.Controls.Add(Me.Label25)
        Me.TabPage4.Controls.Add(Me.btn_Simu)
        Me.TabPage4.Location = New System.Drawing.Point(4, 28)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(706, 637)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Sequential"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Enabled = False
        Me.btn_save.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(297, 524)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(125, 28)
        Me.btn_save.TabIndex = 55
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(59, 444)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(99, 19)
        Me.Label39.TabIndex = 54
        Me.Label39.Text = "Position 8"
        '
        'txt_XP8
        '
        Me.txt_XP8.Enabled = False
        Me.txt_XP8.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP8.Location = New System.Drawing.Point(501, 437)
        Me.txt_XP8.Name = "txt_XP8"
        Me.txt_XP8.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP8.TabIndex = 53
        '
        'txt_ZP8
        '
        Me.txt_ZP8.Enabled = False
        Me.txt_ZP8.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP8.Location = New System.Drawing.Point(348, 437)
        Me.txt_ZP8.Name = "txt_ZP8"
        Me.txt_ZP8.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP8.TabIndex = 52
        '
        'txt_YP8
        '
        Me.txt_YP8.Enabled = False
        Me.txt_YP8.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP8.Location = New System.Drawing.Point(195, 437)
        Me.txt_YP8.Name = "txt_YP8"
        Me.txt_YP8.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP8.TabIndex = 51
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(59, 395)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(99, 19)
        Me.Label38.TabIndex = 50
        Me.Label38.Text = "Position 7"
        '
        'txt_XP7
        '
        Me.txt_XP7.Enabled = False
        Me.txt_XP7.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP7.Location = New System.Drawing.Point(501, 388)
        Me.txt_XP7.Name = "txt_XP7"
        Me.txt_XP7.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP7.TabIndex = 49
        '
        'txt_ZP7
        '
        Me.txt_ZP7.Enabled = False
        Me.txt_ZP7.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP7.Location = New System.Drawing.Point(348, 388)
        Me.txt_ZP7.Name = "txt_ZP7"
        Me.txt_ZP7.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP7.TabIndex = 48
        '
        'txt_YP7
        '
        Me.txt_YP7.Enabled = False
        Me.txt_YP7.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP7.Location = New System.Drawing.Point(195, 388)
        Me.txt_YP7.Name = "txt_YP7"
        Me.txt_YP7.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP7.TabIndex = 47
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(59, 346)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(99, 19)
        Me.Label37.TabIndex = 46
        Me.Label37.Text = "Position 6"
        '
        'txt_XP6
        '
        Me.txt_XP6.Enabled = False
        Me.txt_XP6.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP6.Location = New System.Drawing.Point(501, 339)
        Me.txt_XP6.Name = "txt_XP6"
        Me.txt_XP6.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP6.TabIndex = 45
        '
        'txt_ZP6
        '
        Me.txt_ZP6.Enabled = False
        Me.txt_ZP6.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP6.Location = New System.Drawing.Point(348, 339)
        Me.txt_ZP6.Name = "txt_ZP6"
        Me.txt_ZP6.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP6.TabIndex = 44
        '
        'txt_YP6
        '
        Me.txt_YP6.Enabled = False
        Me.txt_YP6.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP6.Location = New System.Drawing.Point(195, 339)
        Me.txt_YP6.Name = "txt_YP6"
        Me.txt_YP6.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP6.TabIndex = 43
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(59, 297)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(99, 19)
        Me.Label36.TabIndex = 42
        Me.Label36.Text = "Position 5"
        '
        'txt_XP5
        '
        Me.txt_XP5.Enabled = False
        Me.txt_XP5.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP5.Location = New System.Drawing.Point(501, 290)
        Me.txt_XP5.Name = "txt_XP5"
        Me.txt_XP5.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP5.TabIndex = 41
        '
        'txt_ZP5
        '
        Me.txt_ZP5.Enabled = False
        Me.txt_ZP5.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP5.Location = New System.Drawing.Point(348, 290)
        Me.txt_ZP5.Name = "txt_ZP5"
        Me.txt_ZP5.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP5.TabIndex = 40
        '
        'txt_YP5
        '
        Me.txt_YP5.Enabled = False
        Me.txt_YP5.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP5.Location = New System.Drawing.Point(195, 290)
        Me.txt_YP5.Name = "txt_YP5"
        Me.txt_YP5.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP5.TabIndex = 39
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(59, 248)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(99, 19)
        Me.Label35.TabIndex = 38
        Me.Label35.Text = "Position 4"
        '
        'txt_XP4
        '
        Me.txt_XP4.Enabled = False
        Me.txt_XP4.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP4.Location = New System.Drawing.Point(501, 241)
        Me.txt_XP4.Name = "txt_XP4"
        Me.txt_XP4.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP4.TabIndex = 37
        '
        'txt_ZP4
        '
        Me.txt_ZP4.Enabled = False
        Me.txt_ZP4.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP4.Location = New System.Drawing.Point(348, 241)
        Me.txt_ZP4.Name = "txt_ZP4"
        Me.txt_ZP4.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP4.TabIndex = 36
        '
        'txt_YP4
        '
        Me.txt_YP4.Enabled = False
        Me.txt_YP4.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP4.Location = New System.Drawing.Point(195, 241)
        Me.txt_YP4.Name = "txt_YP4"
        Me.txt_YP4.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP4.TabIndex = 35
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(59, 199)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(99, 19)
        Me.Label34.TabIndex = 34
        Me.Label34.Text = "Position 3"
        '
        'txt_XP3
        '
        Me.txt_XP3.Enabled = False
        Me.txt_XP3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP3.Location = New System.Drawing.Point(501, 192)
        Me.txt_XP3.Name = "txt_XP3"
        Me.txt_XP3.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP3.TabIndex = 33
        '
        'txt_ZP3
        '
        Me.txt_ZP3.Enabled = False
        Me.txt_ZP3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP3.Location = New System.Drawing.Point(348, 192)
        Me.txt_ZP3.Name = "txt_ZP3"
        Me.txt_ZP3.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP3.TabIndex = 32
        '
        'txt_YP3
        '
        Me.txt_YP3.Enabled = False
        Me.txt_YP3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP3.Location = New System.Drawing.Point(195, 192)
        Me.txt_YP3.Name = "txt_YP3"
        Me.txt_YP3.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP3.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(59, 150)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 19)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Position 2"
        '
        'txt_XP2
        '
        Me.txt_XP2.Enabled = False
        Me.txt_XP2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP2.Location = New System.Drawing.Point(501, 143)
        Me.txt_XP2.Name = "txt_XP2"
        Me.txt_XP2.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP2.TabIndex = 29
        '
        'txt_ZP2
        '
        Me.txt_ZP2.Enabled = False
        Me.txt_ZP2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP2.Location = New System.Drawing.Point(348, 143)
        Me.txt_ZP2.Name = "txt_ZP2"
        Me.txt_ZP2.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP2.TabIndex = 28
        '
        'txt_YP2
        '
        Me.txt_YP2.Enabled = False
        Me.txt_YP2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP2.Location = New System.Drawing.Point(195, 143)
        Me.txt_YP2.Name = "txt_YP2"
        Me.txt_YP2.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP2.TabIndex = 27
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(59, 101)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(99, 19)
        Me.Label33.TabIndex = 26
        Me.Label33.Text = "Position 1"
        '
        'txt_XP1
        '
        Me.txt_XP1.Enabled = False
        Me.txt_XP1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_XP1.Location = New System.Drawing.Point(501, 94)
        Me.txt_XP1.Name = "txt_XP1"
        Me.txt_XP1.Size = New System.Drawing.Size(91, 26)
        Me.txt_XP1.TabIndex = 25
        '
        'txt_ZP1
        '
        Me.txt_ZP1.Enabled = False
        Me.txt_ZP1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZP1.Location = New System.Drawing.Point(348, 94)
        Me.txt_ZP1.Name = "txt_ZP1"
        Me.txt_ZP1.Size = New System.Drawing.Size(91, 26)
        Me.txt_ZP1.TabIndex = 24
        '
        'txt_YP1
        '
        Me.txt_YP1.Enabled = False
        Me.txt_YP1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_YP1.Location = New System.Drawing.Point(195, 94)
        Me.txt_YP1.Name = "txt_YP1"
        Me.txt_YP1.Size = New System.Drawing.Size(91, 26)
        Me.txt_YP1.TabIndex = 23
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(487, 46)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(117, 19)
        Me.Label32.TabIndex = 22
        Me.Label32.Text = "X Coordinate"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(334, 46)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(117, 19)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Z Coordinate"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(181, 46)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(117, 19)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Y Coordinate"
        '
        'btn_Simu
        '
        Me.btn_Simu.Enabled = False
        Me.btn_Simu.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Simu.Location = New System.Drawing.Point(467, 524)
        Me.btn_Simu.Name = "btn_Simu"
        Me.btn_Simu.Size = New System.Drawing.Size(125, 28)
        Me.btn_Simu.TabIndex = 12
        Me.btn_Simu.Text = "Start"
        Me.btn_Simu.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(706, 637)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.txt_ACCmax)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.btn_Settings)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txt_Vel)
        Me.GroupBox3.Controls.Add(Me.txt_ACCmin)
        Me.GroupBox3.Controls.Add(Me.cb_PulRev)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(693, 366)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Machine settings"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(365, 144)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(171, 19)
        Me.Label27.TabIndex = 51
        Me.Label27.Text = "[min: 500; MAX:10]"
        '
        'txt_ACCmax
        '
        Me.txt_ACCmax.Location = New System.Drawing.Point(259, 143)
        Me.txt_ACCmax.Name = "txt_ACCmax"
        Me.txt_ACCmax.Size = New System.Drawing.Size(100, 26)
        Me.txt_ACCmax.TabIndex = 50
        Me.txt_ACCmax.Text = "20"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(72, 145)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(162, 19)
        Me.Label28.TabIndex = 49
        Me.Label28.Text = "Min. Accel. Delay"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(365, 258)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 19)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "mm"
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(259, 254)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 26)
        Me.TextBox3.TabIndex = 47
        Me.TextBox3.Text = "200"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(72, 256)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(27, 19)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "L2"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(365, 220)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(27, 19)
        Me.Label21.TabIndex = 45
        Me.Label21.Text = "mm"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(259, 217)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 26)
        Me.TextBox2.TabIndex = 44
        Me.TextBox2.Text = "120"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(72, 219)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 19)
        Me.Label22.TabIndex = 43
        Me.Label22.Text = "L1"
        '
        'btn_Settings
        '
        Me.btn_Settings.Location = New System.Drawing.Point(524, 316)
        Me.btn_Settings.Name = "btn_Settings"
        Me.btn_Settings.Size = New System.Drawing.Size(111, 28)
        Me.btn_Settings.TabIndex = 42
        Me.btn_Settings.Text = "Accept"
        Me.btn_Settings.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(365, 182)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 19)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "steps/s"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(365, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(207, 19)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "[min: 50000; MAX:5000]"
        '
        'txt_Vel
        '
        Me.txt_Vel.Location = New System.Drawing.Point(259, 180)
        Me.txt_Vel.Name = "txt_Vel"
        Me.txt_Vel.Size = New System.Drawing.Size(100, 26)
        Me.txt_Vel.TabIndex = 5
        Me.txt_Vel.Text = "500"
        '
        'txt_ACCmin
        '
        Me.txt_ACCmin.Location = New System.Drawing.Point(259, 106)
        Me.txt_ACCmin.Name = "txt_ACCmin"
        Me.txt_ACCmin.Size = New System.Drawing.Size(100, 26)
        Me.txt_ACCmin.TabIndex = 4
        Me.txt_ACCmin.Text = "50000"
        '
        'cb_PulRev
        '
        Me.cb_PulRev.Enabled = False
        Me.cb_PulRev.FormattingEnabled = True
        Me.cb_PulRev.Items.AddRange(New Object() {"200", "400", "800", "1600", "3200", "6400"})
        Me.cb_PulRev.Location = New System.Drawing.Point(259, 68)
        Me.cb_PulRev.Name = "cb_PulRev"
        Me.cb_PulRev.Size = New System.Drawing.Size(100, 27)
        Me.cb_PulRev.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(72, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 19)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Feed Rate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Init. Accel. Delay"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(72, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(171, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Steps / Revolution"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_OK)
        Me.GroupBox2.Controls.Add(Me.CB_Encoding)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Encouding)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.CB_StopBits)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.CB_BaudRate)
        Me.GroupBox2.Controls.Add(Me.CB_DataBits)
        Me.GroupBox2.Controls.Add(Me.CB_Parity)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 379)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(694, 252)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COM settings"
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(525, 186)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(111, 28)
        Me.btn_OK.TabIndex = 41
        Me.btn_OK.Text = "Accept"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'CB_Encoding
        '
        Me.CB_Encoding.FormattingEnabled = True
        Me.CB_Encoding.Location = New System.Drawing.Point(172, 184)
        Me.CB_Encoding.Name = "CB_Encoding"
        Me.CB_Encoding.Size = New System.Drawing.Size(121, 27)
        Me.CB_Encoding.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(73, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 19)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Baud Rate"
        '
        'Encouding
        '
        Me.Encouding.AutoSize = True
        Me.Encouding.Location = New System.Drawing.Point(73, 187)
        Me.Encouding.Name = "Encouding"
        Me.Encouding.Size = New System.Drawing.Size(81, 19)
        Me.Encouding.TabIndex = 38
        Me.Encouding.Text = "Encoding"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 19)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Parity"
        '
        'CB_StopBits
        '
        Me.CB_StopBits.FormattingEnabled = True
        Me.CB_StopBits.Location = New System.Drawing.Point(172, 150)
        Me.CB_StopBits.Name = "CB_StopBits"
        Me.CB_StopBits.Size = New System.Drawing.Size(121, 27)
        Me.CB_StopBits.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 19)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Stop Bits"
        '
        'CB_BaudRate
        '
        Me.CB_BaudRate.FormattingEnabled = True
        Me.CB_BaudRate.Location = New System.Drawing.Point(172, 48)
        Me.CB_BaudRate.Name = "CB_BaudRate"
        Me.CB_BaudRate.Size = New System.Drawing.Size(121, 27)
        Me.CB_BaudRate.TabIndex = 32
        '
        'CB_DataBits
        '
        Me.CB_DataBits.FormattingEnabled = True
        Me.CB_DataBits.Location = New System.Drawing.Point(172, 116)
        Me.CB_DataBits.Name = "CB_DataBits"
        Me.CB_DataBits.Size = New System.Drawing.Size(121, 27)
        Me.CB_DataBits.TabIndex = 35
        '
        'CB_Parity
        '
        Me.CB_Parity.FormattingEnabled = True
        Me.CB_Parity.Location = New System.Drawing.Point(172, 82)
        Me.CB_Parity.Name = "CB_Parity"
        Me.CB_Parity.Size = New System.Drawing.Size(121, 27)
        Me.CB_Parity.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(73, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 19)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Data Bits"
        '
        'TabPage3
        '
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage3.Controls.Add(Me.About)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.Control)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(706, 637)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Info"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(11, 110)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(531, 19)
        Me.Label42.TabIndex = 8
        Me.Label42.Text = "Use the Auto Home button to start the calibration routine."
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(11, 22)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(553, 91)
        Me.Label41.TabIndex = 7
        Me.Label41.Text = "Position the tool (end effector) in a chosen coordinate(X,Y,Z). Write the coordin" &
    "ates in the respective textbox and click Run. Acceleration button active or deac" &
    "tivate the acceleration."
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(11, 22)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(553, 51)
        Me.Label44.TabIndex = 10
        Me.Label44.Text = "Write the coordinates in the respective textbox and click the Save button. Click " &
    "Start to initiate the movements. "
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(11, 22)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(553, 51)
        Me.Label46.TabIndex = 12
        Me.Label46.Text = "Configure the machine parameters and the communication parameters."
        '
        'Control
        '
        Me.Control.Controls.Add(Me.Label41)
        Me.Control.Controls.Add(Me.Label42)
        Me.Control.Location = New System.Drawing.Point(69, 58)
        Me.Control.Name = "Control"
        Me.Control.Size = New System.Drawing.Size(564, 151)
        Me.Control.TabIndex = 13
        Me.Control.TabStop = False
        Me.Control.Text = "Control"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label44)
        Me.GroupBox5.Location = New System.Drawing.Point(69, 235)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(564, 100)
        Me.GroupBox5.TabIndex = 14
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Sequential"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label46)
        Me.GroupBox6.Location = New System.Drawing.Point(69, 361)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(564, 100)
        Me.GroupBox6.TabIndex = 15
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Settings"
        '
        'About
        '
        Me.About.Controls.Add(Me.Label40)
        Me.About.Location = New System.Drawing.Point(69, 487)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(564, 100)
        Me.About.TabIndex = 16
        Me.About.TabStop = False
        Me.About.Text = "About"
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(11, 22)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(553, 51)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "Developed by Jorge Fernandes, nº 104580, within the discipline of project in auto" &
    "mation engineer 2020/2021"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(720, 674)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ISFM control panel"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.pb_Xaxis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Yaxis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Zaxis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Control.ResumeLayout(False)
        Me.Control.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.About.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_Connect As Button
    Friend WithEvents cb_SerialPorts As ComboBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents txt_coordY As TextBox
    Friend WithEvents txt_coordZ As TextBox
    Friend WithEvents btn_SendCoord As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_DataReceived As TextBox
    Friend WithEvents btn_Homing As Button
    Friend WithEvents btn_Enable As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btn_ACC As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_OK As Button
    Friend WithEvents CB_Encoding As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Encouding As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CB_StopBits As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CB_BaudRate As ComboBox
    Friend WithEvents CB_DataBits As ComboBox
    Friend WithEvents CB_Parity As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cb_PulRev As ComboBox
    Friend WithEvents txt_Vel As TextBox
    Friend WithEvents txt_ACCmin As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents pb_Zaxis As PictureBox
    Friend WithEvents pb_Yaxis As PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btn_Settings As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents txt_deslocamento As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txt_ACCmax As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txt_coordX As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents pb_Xaxis As PictureBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label25 As Label
    Friend WithEvents btn_Simu As Button
    Friend WithEvents Label39 As Label
    Friend WithEvents txt_XP8 As TextBox
    Friend WithEvents txt_ZP8 As TextBox
    Friend WithEvents txt_YP8 As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txt_XP7 As TextBox
    Friend WithEvents txt_ZP7 As TextBox
    Friend WithEvents txt_YP7 As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents txt_XP6 As TextBox
    Friend WithEvents txt_ZP6 As TextBox
    Friend WithEvents txt_YP6 As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txt_XP5 As TextBox
    Friend WithEvents txt_ZP5 As TextBox
    Friend WithEvents txt_YP5 As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txt_XP4 As TextBox
    Friend WithEvents txt_ZP4 As TextBox
    Friend WithEvents txt_YP4 As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txt_XP3 As TextBox
    Friend WithEvents txt_ZP3 As TextBox
    Friend WithEvents txt_YP3 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_XP2 As TextBox
    Friend WithEvents txt_ZP2 As TextBox
    Friend WithEvents txt_YP2 As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txt_XP1 As TextBox
    Friend WithEvents txt_ZP1 As TextBox
    Friend WithEvents txt_YP1 As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents btn_save As Button
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label46 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Control As GroupBox
    Friend WithEvents About As GroupBox
    Friend WithEvents Label40 As Label
End Class
