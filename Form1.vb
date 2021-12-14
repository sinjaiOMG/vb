Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Form1
    Dim DA As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim DS As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            ' MsgBox("Can't Connect")With ms
            With ms
                .Label2.Text = "ບໍ່ສາມາດລຶບໄດ້"
                .ShowDialog()
            End With

        End Try
    End Sub
    Private Function cmd_excuteScatar()
        connect()
        cmd = New SqlCommand(sql, cn)
        Return cmd.ExecuteScalar
    End Function

    Sub Msg_error(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbCritical + vbOKOnly, title)
    End Sub

    Sub Msg_ok(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub

    Function confirm(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function

    Function cmd_excuteDataTable()
        connect()
        DA = New SqlDataAdapter(sql, cn)
        DS = New DataSet
        DA.Fill(DS, "table")
        Return DS.Tables("table")
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
    End Sub

    'Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click


    ' End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        '  If confirm("ທ່ານຕ້ອງການອອກຈາກໂປຣແກຣມນີ້ຫຼືບໍ່?") = vbYes Then End
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການອອກຈາກໜ້ານີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Me.Close()

            End If

        End With

    End Sub



    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
            ms.Close()
        End If
    End Sub
    Private Sub Login()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            ' Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ"
                .ShowDialog()
            End With

            Return
        End If

        sql = "select count(*) from status1 where username = '" & TextBox1.Text & "' and password ='" & TextBox2.Text & "'"
        Dim count_user As Integer = cmd_excuteScatar()

        If count_user <= 0 Then
            ' Msg_error("Username ຫຼື Password ຜິດພາດ")
            With ms
                .Label2.Text = "Username ຫຼື Password ຜິດພາດ"
                .ShowDialog()
            End With
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            home.Show()
            Me.Hide()

            sql = "select * from status1 where username = '" & TextBox1.Text & "' and password ='" & TextBox2.Text & "'"
            Dim dts As DataTable = cmd_excuteDataTable()
            With home
                .ToolStripStatusLabel5.Text = dts.Rows(0)("username")
                .t.Text = Date.Now
                .ToolStripStatusLabel6.Text = dts.Rows(0)("EMPID")
            End With

            sql = "Select * from status1 where username = '" & dts.Rows(0)("username") & "'"
            DA = New SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "table")
            Dim dts_permissions As DataTable = DS.Tables("table")

            With home
                .ToolStripMenuItem1.Enabled = dts_permissions.Rows(0)("doctor")
                .ToolStripMenuItem3.Enabled = dts_permissions.Rows(0)("customer")
                .ToolStripMenuItem4.Enabled = dts_permissions.Rows(0)("appoint")
                .ToolStripMenuItem8.Enabled = dts_permissions.Rows(0)("bill")
                .ToolStripMenuItem7.Enabled = dts_permissions.Rows(0)("report")
                .ToolStripMenuItem13.Enabled = dts_permissions.Rows(0)("databace")
            End With

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Enter) Then
            ' MessageBox.Show("ສາມາດປ້ອນພຽງຕົວເລກເທົ່ານັ້ນ", "ການແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With ms
                .Label2.Text = "ສາມາດປ້ອນພຽງຕົວເລກເທົ່ານັ້ນ"
                .ShowDialog()
            End With
            e.Handled = True
        End If

    End Sub
End Class