Public Class YESorNO
    Private Sub byes_Click(sender As Object, e As EventArgs) Handles byes.Click
        Label4.Text = "ຢືນຢັນ"
        Me.Close()
    End Sub

    Private Sub bno_Click(sender As Object, e As EventArgs) Handles bno.Click
        Label4.Text = ""
        Me.Close()

    End Sub
End Class