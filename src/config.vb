Public Class config

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "mangosd (.conf)|*.conf|RTF-Format (.rtf)|*.rtf"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, System.Text.Encoding.Default)
        End If

        SaveFileDialog2.Filter = "realmd (.conf)|*.conf|RTF-Format (.rtf)|*.rtf"
        If SaveFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog2.FileName, RichTextBox2.Text, System.Text.Encoding.Default)
        End If

        SaveFileDialog3.Filter = "ahbot (.conf)|*.conf|RTF-Format (.rtf)|*.rtf"
        If SaveFileDialog3.ShowDialog = Windows.Forms.DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog3.FileName, RichTextBox3.Text, System.Text.Encoding.Default)
        End If

        SaveFileDialog4.Filter = "scriptdev2 (.conf)|*.conf|RTF-Format (.rtf)|*.rtf"
        If SaveFileDialog4.ShowDialog = Windows.Forms.DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog4.FileName, RichTextBox4.Text, System.Text.Encoding.Default)
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        main.Visible = True
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        RichTextBox1.Visible = False
        RichTextBox3.Visible = True
        Button6.Enabled = True
        Button3.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        RichTextBox1.Visible = True
        RichTextBox3.Visible = False
        Button6.Enabled = False
        Button3.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        RichTextBox2.Visible = False
        RichTextBox4.Visible = True
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        RichTextBox2.Visible = True
        RichTextBox4.Visible = False
        Button4.Enabled = True
        Button5.Enabled = False
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        main.Visible = True
    End Sub

    Private Sub config_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        round_off(Me, 0, 0, Me.Width, Me.Height, 40)
    End Sub
End Class