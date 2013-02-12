Module Module1
    Sub abrunden(ByVal was As Object, _
      ByVal x As Integer, ByVal y As Integer, _
      ByVal width As Integer, ByVal height As Integer, _
      ByVal radius As Integer)


        Dim gp As System.Drawing.Drawing2D.GraphicsPath = _
          New System.Drawing.Drawing2D.GraphicsPath()

        gp.AddLine(x + radius, y, x + width - radius, y)
        gp.AddArc(x + width - radius, y, radius, radius, 270, 90)
        gp.AddLine(x + width, y + radius, x + width, y + height - radius)
        gp.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90)
        gp.AddLine(x + width - radius, y + height, x + radius, y + height)
        gp.AddArc(x, y + height - radius, radius, radius, 90, 90)
        gp.AddLine(x, y + height - radius, x, y + radius)
        gp.AddArc(x, y, radius, radius, 180, 90)
        gp.CloseFigure()

        was.region = New System.Drawing.Region(gp)
        gp.Dispose()
    End Sub
End Module
