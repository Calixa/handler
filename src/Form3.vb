Public Class Form3

    Private Sub ProgressBar1_Click(sender As System.Object, e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        abrunden(Me, 0, 0, Me.Width, Me.Height, 20)
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Style = ProgressBarStyle.Marquee

        Form1.Timer11.Enabled = True

        If ProgressBar1.Value < ProgressBar1.Maximum Then
            ProgressBar1.Value += 1
            If ProgressBar1.Value = ProgressBar1.Maximum Then
                Me.Visible = False
                Form1.Visible = True
                Form1.Timer11.Enabled = False
                Timer1.Enabled = False
                Form1.Timer26.Enabled = True
            End If
        End If
    End Sub
End Class