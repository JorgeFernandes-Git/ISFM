Imports System
Imports System.IO.Ports
Public Class Form1

    Dim available_ports As Array = IO.Ports.SerialPort.GetPortNames
    Dim n As Integer

    Dim Data_Receive As String
    Dim TrueCoord As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPorts()
        Timer1.Interval = 1
        Timer1.Enabled = False
        cb_PulRev.SelectedIndex = 0
        TabPage1.BackgroundImage = System.Drawing.Image.FromFile("img\BG_IMAGE.jpg")
        TabPage2.BackgroundImage = System.Drawing.Image.FromFile("img\BG_IMAGE.jpg")
        TabPage3.BackgroundImage = System.Drawing.Image.FromFile("img\BG_IMAGE.jpg")
        TabPage4.BackgroundImage = System.Drawing.Image.FromFile("img\BG_IMAGE.jpg")

    End Sub

    Private Sub GetPorts() 'avaliar as portas disponíveis

        For n = 0 To UBound(available_ports)
            cb_SerialPorts.Items.Add(available_ports(n))
        Next
        cb_SerialPorts.SelectedIndex = 0

        'combobox parity
        With CB_Parity.Items
            .Clear()
            .Add(IO.Ports.Parity.None)
            .Add(IO.Ports.Parity.Odd)
            .Add(IO.Ports.Parity.Even)
        End With
        CB_Parity.SelectedIndex = 0 'defenir um valor selecionado por defeito

        'combobox baud rate
        With CB_BaudRate.Items
            .Clear()
            .Add("4800")
            .Add("9600")
            .Add("19200")
            .Add("38400")
            .Add("57600")
            .Add("74880")
            .Add("115200")
        End With
        CB_BaudRate.SelectedIndex = 1

        'combobox data bits
        With CB_DataBits.Items
            .Clear()
            .Add("5")
            .Add("6")
            .Add("7")
            .Add("8")
        End With
        CB_DataBits.SelectedIndex = 3

        'combobox stop bits
        With CB_StopBits.Items
            .Clear()
            .Add(IO.Ports.StopBits.One)
            .Add(IO.Ports.StopBits.Two)
        End With
        CB_StopBits.SelectedIndex = 0

        'combobox encoding
        With CB_Encoding.Items
            .Clear()
            .Add("Default")
            .Add("UTF8")
            .Add("UTF32")
        End With
        CB_Encoding.SelectedIndex = 0
    End Sub

    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click

        Dim port As String = cb_SerialPorts.Text

        'verificar se existe conecção
        If SerialPort1.IsOpen = False Then
            Try
                'definir os parametros de comunicação
                With SerialPort1
                    .PortName = port
                    .BaudRate = CB_BaudRate.Text '9600
                    .DataBits = CB_DataBits.Text '8 ARDUINO MEGA
                    'atribuir paridade .Parity = IO.Ports.Parity.None
                    Select Case CB_Parity.Text
                        Case "None"
                            .Parity = IO.Ports.Parity.None
                        Case "Even"
                            .Parity = IO.Ports.Parity.Even
                        Case "Odd"
                            .Parity = IO.Ports.Parity.Odd
                    End Select

                    'atribuir stop bits .StopBits = IO.Ports.StopBits.One
                    Select Case CB_StopBits.Text
                        Case "One"
                            .StopBits = IO.Ports.StopBits.One
                        Case "Two"
                            .StopBits = IO.Ports.StopBits.Two
                    End Select

                    .Handshake = Handshake.None

                    'atribuir encoding .Encoding = System.Text.Encoding.Default
                    Select Case CB_Encoding.Text
                        Case "Default"
                            .Encoding = System.Text.Encoding.Default
                        Case "UTF8"
                            .Encoding = System.Text.Encoding.UTF8
                        Case "UTF32"
                            .Encoding = System.Text.Encoding.UTF32
                    End Select

                    .ReadTimeout = 10000
                End With

                'estabelecer ligação
                SerialPort1.Open()
                btn_Connect.Text = "Disconnect"
                btn_Enable.Enabled = True
                Timer1.Enabled = True
            Catch ex As Exception
                MsgBox("Failed to establish connection", vbCritical, "Warning")
            End Try


        ElseIf SerialPort1.IsOpen = True Then

            'caso já exista conecção disconectar
            SerialPort1.Close()
            btn_Connect.Text = "Connect"
            cb_SerialPorts.Items.Clear()
            btn_Enable.Text = "Enable Motors"
            btn_ACC.Enabled = False
            txt_coordZ.Enabled = False
            txt_coordY.Enabled = False
            btn_SendCoord.Enabled = False
            btn_Enable.Enabled = False
            btn_Homing.Enabled = False
            GetPorts()

        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Data_Receive = Data_Receive + SerialPort1.ReadExisting
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Len(Data_Receive) > 0 Then
            txt_DataReceived.AppendText(Data_Receive)

            If Data_Receive = "Zhome" & vbCrLf Then
                pb_Zaxis.Image = System.Drawing.Image.FromFile("img\oval.png")
            End If

            If Data_Receive = "Yhome" & vbCrLf Then
                pb_Yaxis.Image = System.Drawing.Image.FromFile("img\oval.png")
            End If

            If Data_Receive = "Xhome" & vbCrLf Then
                pb_Xaxis.Image = System.Drawing.Image.FromFile("img\oval.png")
            End If

            If Data_Receive = "HOMING COMPLETE" & vbCrLf Then
                btn_Homing.BackColor = SystemColors.ControlLight
            End If

            If Data_Receive.StartsWith("PosY") Then
                txt_coordY.Text = Mid(Data_Receive, 5, 7)
            End If

            If Data_Receive.StartsWith("PosZ") Then
                txt_coordZ.Text = Mid(Data_Receive, 5, 7)
            End If

            If Data_Receive.StartsWith("PosX") Then
                txt_coordX.Text = Mid(Data_Receive, 5, 7)
            End If

            If Data_Receive.StartsWith("VET") Then
                txt_deslocamento.Text = Mid(Data_Receive, 4, Data_Receive.Length)
            End If

            If Data_Receive.StartsWith("VEL") Then
                txt_Vel.Text = Mid(Data_Receive, 4, Data_Receive.Length)
            End If

            If Data_Receive.StartsWith("ACC") Then
                txt_ACCmin.Text = Mid(Data_Receive, 4, Data_Receive.Length)
            End If

            If Data_Receive.StartsWith("MDL") Then
                txt_ACCmax.Text = Mid(Data_Receive, 4, Data_Receive.Length)
            End If

            If Data_Receive = "FAULT" & vbCrLf Then
                pb_Zaxis.Image = System.Drawing.Image.FromFile("img\full-moon.png")
                pb_Yaxis.Image = System.Drawing.Image.FromFile("img\full-moon.png")
                pb_Xaxis.Image = System.Drawing.Image.FromFile("img\full-moon.png")
                btn_Homing.BackColor = Color.Red
                btn_ACC.Enabled = False
                btn_ACC.BackColor = SystemColors.ControlLight
                btn_Enable.Enabled = False
                btn_Enable.Text = "Enable Motors"
            End If

            Data_Receive = ""
        End If
    End Sub

    Private Sub btn_SendCoord_Click(sender As Object, e As EventArgs) Handles btn_SendCoord.Click
        'verificar se as coordenadas são aceitaveis

        If IsNumeric(txt_coordY.Text) And IsNumeric(txt_coordZ.Text) And IsNumeric(txt_coordX.Text) Then
            'verificar se existe conecção na porta serial
            If SerialPort1.IsOpen = True Then
                'enviar a mensagem para ligar ou desligar o LED
                SerialPort1.Write(txt_coordY.Text & " " & txt_coordZ.Text & " " & txt_coordX.Text)
            Else
                MsgBox("Not connected", vbCritical, "Warning")
            End If
        Else
            MsgBox("Invalid command", vbCritical, "Warning")
        End If

    End Sub

    Private Sub btn_Homing_Click(sender As Object, e As EventArgs) Handles btn_Homing.Click
        'verificar se existe conecção na porta serial
        If SerialPort1.IsOpen = True Then
            'enviar a mensagem para ligar ou desligar o LED
            SerialPort1.Write("H")
            pb_Zaxis.Image = System.Drawing.Image.FromFile("img\full-moon.png")
            pb_Yaxis.Image = System.Drawing.Image.FromFile("img\full-moon.png")
            pb_Xaxis.Image = System.Drawing.Image.FromFile("img\full-moon.png")
            btn_Homing.BackColor = SystemColors.GrayText
        Else
            MsgBox("Not connected", vbCritical, "Warning")
        End If
    End Sub

    Private Sub btn_Enable_Click(sender As Object, e As EventArgs) Handles btn_Enable.Click

        If btn_Enable.Text = "Enable Motors" Then
            'verificar se existe conecção na porta serial
            If SerialPort1.IsOpen = True Then
                'enviar a mensagem para ligar ou desligar o LED
                SerialPort1.Write("ENA")
                btn_Enable.Text = "Disable Motors"
                btn_ACC.Enabled = True
                txt_coordZ.Enabled = True
                txt_coordY.Enabled = True
                txt_coordX.Enabled = True
                btn_SendCoord.Enabled = True
                btn_Homing.Enabled = True
                btn_Simu.Enabled = True
                txt_YP2.Enabled = True
                txt_YP3.Enabled = True
                txt_YP4.Enabled = True
                txt_YP5.Enabled = True
                txt_YP6.Enabled = True
                txt_YP7.Enabled = True
                txt_YP8.Enabled = True
                txt_ZP1.Enabled = True
                txt_ZP2.Enabled = True
                txt_ZP3.Enabled = True
                txt_ZP4.Enabled = True
                txt_ZP5.Enabled = True
                txt_ZP6.Enabled = True
                txt_ZP7.Enabled = True
                txt_ZP8.Enabled = True
                txt_XP1.Enabled = True
                txt_XP2.Enabled = True
                txt_XP3.Enabled = True
                txt_XP4.Enabled = True
                txt_XP5.Enabled = True
                txt_XP6.Enabled = True
                txt_XP7.Enabled = True
                txt_XP8.Enabled = True


            End If

        ElseIf btn_Enable.Text = "Disable Motors" Then
            'verificar se existe conecção na porta serial
            If SerialPort1.IsOpen = True Then
                'enviar a mensagem para ligar ou desligar o LED
                SerialPort1.Write("DIS")
                btn_Enable.Text = "Enable Motors"
                btn_ACC.Enabled = False
                txt_coordZ.Enabled = False
                txt_coordY.Enabled = False
                txt_coordX.Enabled = False
                btn_SendCoord.Enabled = False
                btn_Homing.Enabled = False
                btn_ACC.BackColor = SystemColors.ControlLight
            End If

        End If

    End Sub

    Private Sub btn_JogZplus_KeyDown(sender As Object, e As KeyEventArgs)
        'verificar se existe conecção na porta serial
        If SerialPort1.IsOpen = True Then
            'enviar a mensagem para ligar ou desligar o LED
            SerialPort1.Write("Z+")
        End If
    End Sub

    Private Sub btn_JogZplus_KeyUp(sender As Object, e As KeyEventArgs)
        'verificar se existe conecção na porta serial
        If SerialPort1.IsOpen = True Then
            'enviar a mensagem para ligar ou desligar o LED
            SerialPort1.Write("S")
        End If
    End Sub

    Private Sub btn_ACC_Click(sender As Object, e As EventArgs) Handles btn_ACC.Click
        If btn_ACC.BackColor = SystemColors.ControlLight Then
            'verificar se existe conecção na porta serial
            If SerialPort1.IsOpen = True Then
                'enviar a mensagem para ligar ou desligar o LED
                SerialPort1.Write("ACC+")
                btn_ACC.BackColor = SystemColors.GrayText
            End If
        ElseIf btn_ACC.BackColor = SystemColors.GrayText Then
            'verificar se existe conecção na porta serial
            If SerialPort1.IsOpen = True Then
                'enviar a mensagem para ligar ou desligar o LED
                SerialPort1.Write("ACC-")
                btn_ACC.BackColor = SystemColors.ControlLight
            End If
        End If
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        'definir os parametros de comunicação
        With SerialPort1
            .BaudRate = CB_BaudRate.Text '9600
            .DataBits = CB_DataBits.Text '8 ARDUINO MEGA
            'atribuir paridade .Parity = IO.Ports.Parity.None
            Select Case CB_Parity.Text
                Case "None"
                    .Parity = IO.Ports.Parity.None
                Case "Even"
                    .Parity = IO.Ports.Parity.Even
                Case "Odd"
                    .Parity = IO.Ports.Parity.Odd
            End Select

            'atribuir stop bits .StopBits = IO.Ports.StopBits.One
            Select Case CB_StopBits.Text
                Case "One"
                    .StopBits = IO.Ports.StopBits.One
                Case "Two"
                    .StopBits = IO.Ports.StopBits.Two
            End Select

            .Handshake = Handshake.None

            'atribuir encoding .Encoding = System.Text.Encoding.Default
            Select Case CB_Encoding.Text
                Case "Default"
                    .Encoding = System.Text.Encoding.Default
                Case "UTF8"
                    .Encoding = System.Text.Encoding.UTF8
                Case "UTF32"
                    .Encoding = System.Text.Encoding.UTF32
            End Select

            .ReadTimeout = 10000
        End With
    End Sub

    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        If SerialPort1.IsOpen = True Then
            'enviar a mensagem para ligar ou desligar o LED
            SerialPort1.Write("SET" + txt_Vel.Text + " " + txt_ACCmin.Text + " " + txt_ACCmax.Text)
        Else
            MsgBox("Not connected", vbCritical, "Warning")
        End If
    End Sub

    Private Sub btn_Simu_Click(sender As Object, e As EventArgs)
        If SerialPort1.IsOpen = True Then
            'enviar a mensagem para ligar ou desligar o LED
            SerialPort1.Write("MOV")
            btn_save.Enabled = False
            btn_Simu.Enabled = False
            btn_Simu.BackColor = Color.DimGray

            'falta mensagem de retorno
        Else
            MsgBox("Not connected", vbCritical, "Warning")
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If SerialPort1.IsOpen = True Then
            'enviar a mensagem para ligar ou desligar o LED
            SerialPort1.Write("SAV" + " " + txt_YP1.Text + " " + txt_YP2.Text + " " + txt_YP3.Text + " " + txt_YP4.Text + " " + txt_YP5.Text + " " + txt_YP6.Text + " " + txt_YP7.Text + " " + txt_YP8.Text + " " + txt_ZP1.Text + " " + txt_ZP2.Text + " " + txt_ZP3.Text + " " + txt_ZP4.Text + " " + txt_ZP5.Text + " " + txt_ZP6.Text + " " + txt_ZP7.Text + " " + txt_ZP8.Text + " " + txt_XP1.Text + " " + txt_XP2.Text + " " + txt_XP3.Text + " " + txt_XP4.Text + " " + txt_XP5.Text + " " + txt_XP6.Text + " " + txt_XP7.Text + " " + txt_XP8.Text)
        Else
            MsgBox("Not connected", vbCritical, "Warning")
        End If
    End Sub

End Class
