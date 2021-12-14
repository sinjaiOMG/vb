Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim a As Double
        'TextBox1.Text = String.Format("{0:n2}", a)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If (TextBox1.Text.Length > 0) Then

            TextBox1.Text = Convert.ToDouble(TextBox1.Text).ToString("N0")
            TextBox1.SelectionStart = TextBox1.Text.Length
        End If

    End Sub
End Class