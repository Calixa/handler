Imports System.IO

Public Class main

    Dim mouseOffset As Point

    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Me_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        If e.Button = MouseButtons.Left Then
            Dim mousePos = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Location = mousePos
        End If
    End Sub


    Private Sub main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer26.Interval = 100
        Timer26.Enabled = False
        round_off(Me, 0, 0, Me.Width, Me.Height, 40)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        Timer7.Enabled = True
        Timer9.Enabled = True
    End Sub

    Private Delegate Sub LogDelegate(ByVal message As String)

    Private Sub AppendLogLine1(ByVal message As String)
        With RichTextBox1
            If .InvokeRequired Then
                .Invoke(New LogDelegate(AddressOf Me.AppendLogLine1), message)
            Else
                .AppendText(message & vbNewLine)
            End If
        End With
    End Sub

    Private Sub AppendLogLine2(ByVal message As String)
        With RichTextBox2
            If .InvokeRequired Then
                .Invoke(New LogDelegate(AddressOf Me.AppendLogLine2), message)
            Else
                .AppendText(message & vbNewLine)
            End If
        End With
    End Sub

    Private Sub Process_OutputDataReceived1(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs)
        Me.AppendLogLine1(e.Data)
    End Sub

    Private Sub Process_OutputDataReceived2(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs)
        Me.AppendLogLine2(e.Data)
    End Sub

    Private Sub RichTextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles RichTextBox3.TextChanged
        RichTextBox3.ReadOnly = True

        If RichTextBox3.Text.Length > 0 Then
            RichTextBox3.Focus()
            RichTextBox3.Select(RichTextBox3.Text.Length, 0)
        End If
    End Sub

    Private Sub RichTextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles RichTextBox2.TextChanged
        RichTextBox2.ReadOnly = True

        If RichTextBox2.Text.Length > 0 Then
            RichTextBox2.Focus()
            RichTextBox2.Select(RichTextBox2.Text.Length, 0)
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.ReadOnly = True

        If RichTextBox1.Text.Length > 0 Then
            RichTextBox1.Focus()
            RichTextBox1.Select(RichTextBox1.Text.Length, 0)
        End If
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Timer4.Enabled = True
        Timer8.Enabled = True
        Timer10.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Visible = False
        config.Visible = True

        config.OpenFileDialog1.Filter = "mangosd (.conf)|*.conf|RTF-Format (.rtf)|*.rtf" 'open mangosd.conf
        If config.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            config.RichTextBox1.Text = System.IO.File.ReadAllText(config.OpenFileDialog1.FileName)

            config.OpenFileDialog2.Filter = "realmd (.conf)|*.conf|RTF-Format (.rtf)|*.rtf" 'open realmd.conf
            If config.OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
                config.RichTextBox2.Text = System.IO.File.ReadAllText(config.OpenFileDialog2.FileName)

                config.OpenFileDialog3.Filter = "ahbot (.conf)|*.conf|RTF-Format (.rtf)|*.rtf" 'open ahbot.conf
                If config.OpenFileDialog3.ShowDialog = Windows.Forms.DialogResult.OK Then
                    config.RichTextBox3.Text = System.IO.File.ReadAllText(config.OpenFileDialog3.FileName)

                    config.OpenFileDialog4.Filter = "scriptdev2 (.conf)|*.conf|RTF-Format (.rtf)|*.rtf" 'open scriptdev2.conf
                    If config.OpenFileDialog4.ShowDialog = Windows.Forms.DialogResult.OK Then
                        config.RichTextBox4.Text = System.IO.File.ReadAllText(config.OpenFileDialog4.FileName)
                    End If
                End If
            End If
        Else
            config.Close() 'Close all wehn not Config file loaded
            Me.Visible = True
        End If
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        For Each Process In System.Diagnostics.Process.GetProcessesByName("mangosd") 'Kill mangosd.exe
            Process.Kill()
            Timer4.Enabled = False
        Next
        For Each Process In System.Diagnostics.Process.GetProcessesByName("realmd") 'Kill realmd.exe
            Process.Kill()
            Timer4.Enabled = False
        Next
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If WebBrowser1.DocumentText = "alt" Then
            WebBrowser2.Navigate("http://project-zero.eu/updates/1.0.2/Starter_v1.0.2.rar") 'Check for new Updates
            Label3.Text = "New Updates Available"
            Label3.ForeColor = Color.LimeGreen
        Else
            Label3.Text = "No Updates Available"
            Label3.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Dim p As New Process
        AddHandler p.OutputDataReceived, AddressOf Me.Process_OutputDataReceived1
        With p.StartInfo
            .FileName = "mangosd"
            .Arguments = ""
            .CreateNoWindow = True
            .UseShellExecute = False
            .RedirectStandardInput = True
            .RedirectStandardOutput = True
        End With
        Label1.Visible = False
        PictureBox1.Visible = False
        p.Start()
        p.BeginOutputReadLine()
        Timer2.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Using p As New Process
            AddHandler p.OutputDataReceived, AddressOf Me.Process_OutputDataReceived2
            With p.StartInfo
                .FileName = "realmd"
                .CreateNoWindow = True
                .UseShellExecute = False
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
            End With
            p.Start()
            p.BeginOutputReadLine()
            Timer3.Enabled = False
        End Using
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Process.Start("MySqlStarter.exe", vbHide)
        Timer5.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        For Each Process In System.Diagnostics.Process.GetProcessesByName("mysqld")
            Process.Kill()
        Next
        Timer6.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Me.Close()
        config.Close()
        load_starter.Close()
    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3307)
        Dim client As New System.Net.Sockets.TcpClient
        Try
            client.Connect(ep1)
            Timer5.Enabled = False
        Catch ex As Exception
            Timer5.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = True
            Button1.Enabled = True
            Label5.Text = "MySQL Online"
            Label5.ForeColor = Color.LimeGreen
        End Try
    End Sub

    Private Sub Timer6_Tick(sender As System.Object, e As System.EventArgs) Handles Timer6.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3307)
        Dim client As New System.Net.Sockets.TcpClient
        Try
            client.Connect(ep1)
            Timer6.Enabled = False
        Catch ex As Exception
            Timer6.Enabled = False
            Button5.Enabled = True
            Button6.Enabled = False
            Button1.Enabled = False
            Label5.Text = "MySQL Offline"
            Label5.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub Timer7_Tick(sender As System.Object, e As System.EventArgs) Handles Timer7.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3724)
        Dim client As New System.Net.Sockets.TcpClient
        Try
            client.Connect(ep1)
            Timer7.Enabled = False
            Button2.Enabled = True
            Button6.Enabled = False
            Button1.Enabled = False
            Label2.Text = "Realmd Online"
            Label2.ForeColor = Color.LimeGreen
        Catch ex As Exception
            Timer7.Enabled = False
        End Try
    End Sub

    Private Sub Timer8_Tick(sender As System.Object, e As System.EventArgs) Handles Timer8.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3724)
        Dim client As New System.Net.Sockets.TcpClient
        Try
            client.Connect(ep1)
            Timer8.Enabled = False
        Catch ex As Exception
            Timer8.Enabled = False
            RichTextBox1.Clear()
            RichTextBox2.Clear()
            Label1.Visible = True
            PictureBox1.Visible = True
            Button2.Enabled = False
            Button6.Enabled = True
            Button1.Enabled = True
            Label2.Text = "Realmd Offline"
            Label2.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub Timer9_Tick(sender As System.Object, e As System.EventArgs) Handles Timer9.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 8085)
        Dim client As New System.Net.Sockets.TcpClient
        Try
            client.Connect(ep1)
            Timer9.Enabled = False
            Label4.Text = "World Online"
            Label4.ForeColor = Color.LimeGreen
            Button12.Enabled = True
        Catch ex As Exception
            Timer9.Enabled = True
        End Try
    End Sub

    Private Sub Timer10_Tick(sender As System.Object, e As System.EventArgs) Handles Timer10.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 8085)
        Dim client As New System.Net.Sockets.TcpClient
        Try
            client.Connect(ep1)
            Timer10.Enabled = False
        Catch ex As Exception
            Timer10.Enabled = False
            Label4.Text = "World Offline"
            Label4.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub Timer11_Tick(sender As System.Object, e As System.EventArgs) Handles Timer11.Tick

        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3307) 'MySQL Port
        Dim ep2 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 8085) 'World Server Port
        Dim ep3 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3724) 'Realmd Port

        If My.Computer.FileSystem.FileExists("ms.conf") Then
            Button11.Visible = False
            Button12.Enabled = False
            Timer11.Enabled = False
        Else
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            Button8.Visible = False
            Button9.Visible = False
            Button10.Visible = False
            Button11.Visible = True
            Button12.Visible = False
            Timer29.Enabled = True
            Timer11.Enabled = False
        End If

        Dim client1 As New System.Net.Sockets.TcpClient
        Try
            client1.Connect(ep1)
            Button1.Enabled = True
            Button6.Enabled = True
            Button5.Enabled = False
            Button12.Enabled = False
            Timer11.Enabled = False
            Label5.Text = "MySQl Online"
            Label5.ForeColor = Color.LimeGreen
        Catch ex As Exception
            Timer11.Enabled = False
        End Try

        Dim client2 As New System.Net.Sockets.TcpClient
        Try
            client2.Connect(ep2)
            Label4.Text = "World Online"
            Label4.ForeColor = Color.LimeGreen
            Timer11.Enabled = False
            Button12.Enabled = False
        Catch ex As Exception
            Timer11.Enabled = False
        End Try

        Dim client3 As New System.Net.Sockets.TcpClient
        Try
            client3.Connect(ep3)
            Label2.Text = "Realmd Online"
            Label2.ForeColor = Color.LimeGreen
            Timer11.Enabled = False
            Button12.Enabled = False
        Catch ex As Exception
            Timer11.Enabled = False
        End Try

        Dim p As Process

        For Each p In Diagnostics.Process.GetProcesses()
            If p.ProcessName = "mangosd" Then
                Button2.Enabled = True
                Button1.Enabled = False
                Button6.Enabled = False
                Timer11.Enabled = False
            End If
        Next

        For Each p In Diagnostics.Process.GetProcesses()
            If p.ProcessName = "realmd" Then
                Button2.Enabled = True
                Button1.Enabled = False
                Button6.Enabled = False
                Timer11.Enabled = False
            End If
        Next
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        PictureBox1.Visible = False
        Label1.Visible = False
        RichTextBox3.Visible = True
        RichTextBox3.Clear()
        RichTextBox3.Text = "--------------------------------------" & vbNewLine
        RichTextBox3.Text = RichTextBox3.Text & "Checking for Config files" & vbNewLine
        RichTextBox3.Text = RichTextBox3.Text & "--------------------------------------" & vbNewLine & vbNewLine
        Timer12.Enabled = True
    End Sub

    Private Sub Timer12_Tick(sender As System.Object, e As System.EventArgs) Handles Timer12.Tick
        If My.Computer.FileSystem.FileExists("realmd.conf") Then
            RichTextBox3.Text = RichTextBox3.Text & "realmd.conf (FOUND)" & vbNewLine
            Timer12.Enabled = False
            Timer13.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "realmd.conf (NOT FOUND)" & vbNewLine
            Timer12.Enabled = False
            Timer13.Enabled = True
        End If
    End Sub

    Private Sub Timer13_Tick(sender As System.Object, e As System.EventArgs) Handles Timer13.Tick
        If My.Computer.FileSystem.FileExists("mangosd.conf") Then
            RichTextBox3.Text = RichTextBox3.Text & "mangosd.conf (FOUND)" & vbNewLine
            Timer13.Enabled = False
            Timer14.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "mangosd.conf (NOT FOUND)" & vbNewLine
            Timer14.Enabled = True
            Timer13.Enabled = False
        End If
    End Sub

    Private Sub Timer14_Tick(sender As System.Object, e As System.EventArgs) Handles Timer14.Tick
        If My.Computer.FileSystem.FileExists("scriptdev2.conf") Then
            RichTextBox3.Text = RichTextBox3.Text & "scriptdev2.conf (FOUND)" & vbNewLine
            Timer14.Enabled = False
            Timer15.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "scriptdev2.conf (NOT FOUND)" & vbNewLine
            Timer14.Enabled = False
            Timer15.Enabled = True
        End If
    End Sub

    Private Sub Timer15_Tick(sender As System.Object, e As System.EventArgs) Handles Timer15.Tick
        If My.Computer.FileSystem.FileExists("ahbot.conf") Then
            RichTextBox3.Text = RichTextBox3.Text & "ahbot.conf (FOUND)" & vbNewLine & vbNewLine
            RichTextBox3.Text = RichTextBox3.Text & "----------------------------------------------------------------------------" & vbNewLine
            RichTextBox3.Text = RichTextBox3.Text & "Checking for dbc/maps/vmaps/mmaps" & vbNewLine
            RichTextBox3.Text = RichTextBox3.Text & "----------------------------------------------------------------------------" & vbNewLine & vbNewLine
            Timer15.Enabled = False
            Timer16.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "ahbot.conf (NOT FOUND)" & vbNewLine & vbNewLine
            RichTextBox3.Text = RichTextBox3.Text & "Some config files not found pls check!" & vbNewLine
            Timer15.Enabled = False
        End If
    End Sub

    Private Sub Timer16_Tick(sender As System.Object, e As System.EventArgs) Handles Timer16.Tick
        If My.Computer.FileSystem.FileExists("data/maps/0002035.map") Then
            RichTextBox3.Text = RichTextBox3.Text & "maps (FOUND)" & vbNewLine
            Timer16.Enabled = False
            Timer17.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "maps (NOT FOUND)" & vbNewLine
            RichTextBox3.Text = RichTextBox3.Text & "maps not found pls extract new" & vbNewLine
            Timer16.Enabled = False
        End If
    End Sub

    Private Sub Timer17_Tick(sender As System.Object, e As System.EventArgs) Handles Timer17.Tick
        If My.Computer.FileSystem.FileExists("data/dbc/Map.dbc") Then
            RichTextBox3.Text = RichTextBox3.Text & "dbc (FOUND)" & vbNewLine
            Timer17.Enabled = False
            Timer18.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "dbc (NOT FOUND)" & vbNewLine & vbNewLine
            Timer17.Enabled = False
        End If
    End Sub

    Private Sub Timer18_Tick(sender As System.Object, e As System.EventArgs) Handles Timer18.Tick
        If My.Computer.FileSystem.FileExists("data/vmaps/000.vmtree") Then
            RichTextBox3.Text = RichTextBox3.Text & "vmaps (FOUND) (Enabled)" & vbNewLine

            Dim lines1() As String = IO.File.ReadAllLines("mangosd.conf")
            lines1(214) = "vmap.enableLOS = 1"
            IO.File.WriteAllLines("mangosd.conf", lines1)

            Dim lines2() As String = IO.File.ReadAllLines("mangosd.conf")
            lines2(215) = "vmap.enableHeight = 1"
            IO.File.WriteAllLines("mangosd.conf", lines2)

            Timer18.Enabled = False
            Timer19.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "vmaps (NOT FOUND) (Disabled)" & vbNewLine

            Dim lines1() As String = IO.File.ReadAllLines("mangosd.conf")
            lines1(214) = "vmap.enableLOS = 0"
            IO.File.WriteAllLines("mangosd.conf", lines1)

            Dim lines2() As String = IO.File.ReadAllLines("mangosd.conf")
            lines2(215) = "vmap.enableHeight = 0"
            IO.File.WriteAllLines("mangosd.conf", lines2)

            Timer18.Enabled = False
            Timer19.Enabled = True
        End If
    End Sub

    Private Sub Timer19_Tick(sender As System.Object, e As System.EventArgs) Handles Timer19.Tick
        If My.Computer.FileSystem.FileExists("data/mmaps/000.mmap") Then
            RichTextBox3.Text = RichTextBox3.Text & "mmaps (FOUND) (Enabled)" & vbNewLine & vbNewLine

            Dim lines2() As String = IO.File.ReadAllLines("mangosd.conf")
            lines2(220) = "mmap.enabled = 1"
            IO.File.WriteAllLines("mangosd.conf", lines2)

            Timer19.Enabled = False
            Timer20.Enabled = True
        Else
            RichTextBox3.Text = RichTextBox3.Text & "mmaps (NOT FOUND) (Disabled)" & vbNewLine & vbNewLine

            Dim lines2() As String = IO.File.ReadAllLines("mangosd.conf")
            lines2(220) = "mmap.enabled = 0"
            IO.File.WriteAllLines("mangosd.conf", lines2)

            Timer19.Enabled = False
            Timer20.Enabled = True
        End If
    End Sub

    Private Sub Timer20_Tick(sender As System.Object, e As System.EventArgs) Handles Timer20.Tick
        Timer20.Enabled = False
        RichTextBox3.Text = RichTextBox3.Text & "----------------------------------------------------------------------------" & vbNewLine
        RichTextBox3.Text = RichTextBox3.Text & "checks ports" & vbNewLine
        RichTextBox3.Text = RichTextBox3.Text & "----------------------------------------------------------------------------" & vbNewLine & vbNewLine
        Timer21.Enabled = True
    End Sub

    Private Sub Timer21_Tick(sender As System.Object, e As System.EventArgs) Handles Timer21.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3307)
        Dim client1 As New System.Net.Sockets.TcpClient
        Try
            client1.Connect(ep1)
            RichTextBox3.Text = RichTextBox3.Text & "port 3307 is not free killing" & vbNewLine
            For Each Process In System.Diagnostics.Process.GetProcessesByName("mysqld")
                Process.Kill()
            Next
            Timer21.Enabled = False
            Timer22.Enabled = True
            Label5.Text = "MySQL Offline"
            Label5.ForeColor = Color.Red
        Catch ex As Exception
            RichTextBox3.Text = RichTextBox3.Text & "port 3307 is free" & vbNewLine
            Timer21.Enabled = False
            Timer22.Enabled = True
        End Try
    End Sub

    Private Sub Timer22_Tick(sender As System.Object, e As System.EventArgs) Handles Timer22.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3307)
        Dim client1 As New System.Net.Sockets.TcpClient
        Try
            client1.Connect(ep1)
            RichTextBox3.Text = RichTextBox3.Text & "port 8085 is not free killing" & vbNewLine
            For Each Process In System.Diagnostics.Process.GetProcessesByName("mangosd")
                Process.Kill()
            Next
            Timer22.Enabled = False
            Timer23.Enabled = True
            Label4.Text = "World Offline"
            Label4.ForeColor = Color.Red
        Catch ex As Exception
            RichTextBox3.Text = RichTextBox3.Text & "port 8085 is free" & vbNewLine
            Timer22.Enabled = False
            Timer23.Enabled = True
        End Try
    End Sub

    Private Sub Timer23_Tick(sender As System.Object, e As System.EventArgs) Handles Timer23.Tick
        Dim ep1 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 3307)
        Dim client1 As New System.Net.Sockets.TcpClient
        Try
            client1.Connect(ep1)
            RichTextBox3.Text = RichTextBox3.Text & "port 3724 is not free killing" & vbNewLine & vbNewLine
            For Each Process In System.Diagnostics.Process.GetProcessesByName("realmd")
                Process.Kill()
            Next
            Timer23.Enabled = False
            Timer24.Enabled = True
            Label2.Text = "Realmd Offline"
            Label2.ForeColor = Color.Red
        Catch ex As Exception
            RichTextBox3.Text = RichTextBox3.Text & "port 3724 is free" & vbNewLine & vbNewLine
            Timer23.Enabled = False
            Timer24.Enabled = True
        End Try
    End Sub

    Private Sub Timer24_Tick(sender As System.Object, e As System.EventArgs) Handles Timer24.Tick
        Timer24.Enabled = False
        RichTextBox3.Text = RichTextBox3.Text & "----------------------------------------------------------------------------" & vbNewLine
        RichTextBox3.Text = RichTextBox3.Text & "All checks done saving" & vbNewLine
        RichTextBox3.Text = RichTextBox3.Text & "----------------------------------------------------------------------------" & vbNewLine & vbNewLine
        IO.File.AppendAllText("ms.conf", "STARTER CONFIG")
        IO.File.AppendAllText("ms_log.log", RichTextBox3.Text)
        Timer25.Enabled = True
    End Sub

    Private Sub Timer25_Tick(sender As System.Object, e As System.EventArgs) Handles Timer25.Tick
        Timer25.Enabled = False
        Application.Restart()
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Button12.Enabled = False
        RichTextBox1.Clear()
        RichTextBox2.Clear()
        Timer1.Enabled = True
        Timer4.Enabled = True
        Timer7.Enabled = True
        Timer8.Enabled = True
        Timer9.Enabled = True
        Timer10.Enabled = True
    End Sub

    Dim cpuCounter = New PerformanceCounter("Processor", "% Processor Time", "_Total")

    Private Sub Timer26_Tick(sender As System.Object, e As System.EventArgs) Handles Timer26.Tick
        ProgressBar1.Value = CInt(cpuCounter.NextValue())
    End Sub

    Private Sub Timer29_Tick(sender As System.Object, e As System.EventArgs) Handles Timer29.Tick
        Dim inhalt As String
        Dim objDateiLeser As StreamReader
        objDateiLeser = New StreamReader("README.txt")
        inhalt = objDateiLeser.ReadToEnd()
        objDateiLeser.Close()
        objDateiLeser = Nothing
        RichTextBox4.Text = inhalt
        RichTextBox4.Visible = True
        Timer29.Enabled = False
    End Sub
End Class