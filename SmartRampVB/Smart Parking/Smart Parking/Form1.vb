Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Imports System.Data.OleDb
Imports System.Collections

Public Class Form1
    Dim comPORT As String
    Dim primeno As String = ""
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Private conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "/Database.mdb; Jet OLEDB:Database Password = Jovan123"
    ReadOnly con As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim adapter As OleDbDataAdapter
    ReadOnly dt As DataTable = New DataTable()
    Dim sortColumn As Integer = -1
    Private CtlArray As New ArrayList

    Dim intX, intY As Integer
    Dim Xratio, Yratio As Single

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If (Button1.Text = "Konektiraj") Then
            If (comPORT <> "") Then
                SerialPort1.Close()
                SerialPort1.PortName = comPORT
                SerialPort1.BaudRate = 9600
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.Encoding = System.Text.Encoding.Default
                SerialPort1.ReadTimeout = 10000

                crvencom.Visible = False
                zelencom.Visible = True
                SerialPort1.Open()
                Button1.Text = "Dis-konektiraj"
                Timer1.Enabled = True
            Else
                MsgBox("Select a COM port first")
            End If
        Else
            SerialPort1.Close()
            Button1.Text = "Konektiraj"
            Timer1.Enabled = False
            zelencom.Visible = False
            crvencom.Visible = True
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        comPORT = ""

        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(sp)
        Next

        Me.SetupListView()
        Retrieve()
        ListView1.Sorting = SortOrder.Ascending
        ListView1.BackColor = Color.LightYellow
        ListView1.ForeColor = Color.Blue


        intX = Screen.PrimaryScreen.Bounds.Width
        intY = Screen.PrimaryScreen.Bounds.Height
        'These are design screen resolutions, but should work with other resolutions too
        'You should design at low resolution, so components will grow and not shrink when taken
        'to other computers. I haven't check for font size, but by growing the components you won't have
        'a problem.

        Xratio = intX / 1920
        Yratio = intY / 1080
        'Get the controls on the form, including menus, but not the controls in other containers
        For Each Cnt As Control In Me.Controls

            CtlArray.Add(Cnt)

        Next
        'Get the children controls
        GetTheChildren()
        'Adjust New size and position
        ResizeThem()

        For Each control As Control In GroupBox1.Controls
            If TypeOf control Is Label Then
                Dim myLabel As Label = DirectCast(control, Label)

                Using newFont As New Font("Arial", Xratio * 12)
                    myLabel.Font = newFont

                End Using
            End If
        Next

        For Each control As Control In Me.Controls
            If TypeOf control Is Label Then
                Dim myLabel As Label = DirectCast(control, Label)

                Using newFont As New Font("Arial", Xratio * 12)
                    myLabel.Font = newFont

                End Using
            End If
        Next


        For Each control As Control In Me.Controls
            If TypeOf control Is Button Then
                Dim mybtn As Button = DirectCast(control, Button)

                Using btnfont As New Font("Arial", Xratio * 17)
                    mybtn.Font = btnfont
                    Button1.Font = New Font("Arial", Xratio * 10)
                End Using
            End If
        Next

    End Sub

    Private Sub GetTheChildren()
        'Gets the controls inside containes like panels or tabcontrols
        'For Each ctl As Control In GetAllControls(Me.Parent)
        For Each ctl As Control In GetAllControls(Me)
            If ctl.Parent IsNot Me Then
                If TypeOf ctl.Parent Is TabPage Then
                    If ctl.Name = "" Then
                        CtlArray.Add(ctl)
                    Else
                        CtlArray.Add(ctl)
                    End If
                Else
                    If Not TypeOf (ctl) Is TabPage Then
                        If ctl.Name = "" Then
                            CtlArray.Add(ctl)
                        Else
                            CtlArray.Add(ctl)
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Function GetAllControls(ByVal container As Control) As Control()
        Dim al As New ArrayList
        Dim ctl As Control
        For Each ctl In container.Controls
            GetControlsWithChildren(ctl, al)
        Next
        Return al.ToArray(GetType(Control))
    End Function

    Sub GetControlsWithChildren(ByVal container As Control, ByVal al As ArrayList)
        ' add this control to the ArrayList
        al.Add(container)
        ' add all its child controls, by calling this routine recursively
        Dim ctl As Control

        For Each ctl In container.Controls
            'A TabPage is a Panel; SplitContainer is a Panel
            GetControlsWithChildren(ctl, al)
        Next

    End Sub

    Private Sub ResizeThem()
        Dim i As Integer
        For i = 0 To CtlArray.Count - 1
            If TypeOf CtlArray.Item(i) Is MenuStrip Then
            Else
                If TypeOf CtlArray.Item(i) Is Panel And CtlArray.Item(i).parent IsNot Me Then
                    'SplitPanel for instance
                Else
                    CtlArray.Item(i).autosize = False
                    CtlArray.Item(i).dock = 0
                    CtlArray.Item(i).width = CtlArray.Item(i).width * Xratio
                    CtlArray.Item(i).left = CtlArray.Item(i).left * Xratio
                    CtlArray.Item(i).height = CtlArray.Item(i).height * Yratio
                    CtlArray.Item(i).top = CtlArray.Item(i).top * Yratio
                End If
            End If
        Next
    End Sub

    Public Sub SetupListView()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("ID", 40)
        ListView1.Columns.Add("IME", 150)
        ListView1.Columns.Add("VREME", 150)
        ListView1.Columns.Add("DATA", 150)
    End Sub

    Public Sub Add()

        Const SQL As String = "INSERT INTO Table1 ([IME],[VREME],[DATA]) VALUES(@ime,@data,@vreme)"
        cmd = New OleDbCommand(SQL, con)
        cmd.Parameters.AddWithValue("@ime", imetxt.Text)
        cmd.Parameters.AddWithValue("@data", vremetxt.Text)
        cmd.Parameters.AddWithValue("@vreme", datatxt.Text)

        Try

            con.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Successfully Inserted")
                CleartextBoxes()
            End If
            con.Close()
            Retrieve()

        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try


    End Sub

    Private Sub Populate(ByVal id As String, ByVal ime As String, ByVal data As String, ByVal vreme As String)

        Dim row As String() = New String() {id, ime, data, vreme}
        Dim items As ListViewItem = New ListViewItem(row)
        ListView1.Items.Add(items)

    End Sub

    Private Sub Retrieve()

        Dim sql As String = "SELECT * FROM Table1 "
        cmd = New OleDbCommand(sql, con)

        Try
            con.Open()
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt)

            For Each row In dt.Rows
                Populate(row(0), row(1), row(2), row(3))
            Next

            dt.Rows.Clear()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try


    End Sub

    Private Sub CleartextBoxes()

        imetxt.Text = ""
        datatxt.Text = ""
        vremetxt.Text = ""

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If (ComboBox1.SelectedItem <> "") Then
            comPORT = ComboBox1.SelectedItem
        End If
    End Sub

    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort1.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function

    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)

        If Me.ListBox1.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})

        Else
            imetxt.Text = [text]
            vremetxt.Text = "13:00:00"
            datatxt.Text = "13/13/2001"
            Add()
        End If

    End Sub



End Class
