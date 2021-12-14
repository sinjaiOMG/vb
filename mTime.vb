Imports System.Text
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.String
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class mTime
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetSaleID, save As String
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            ' MsgBox("Can't Connect")
            With ms
                .Label2.Text = "ບໍ່ສາມາດເຊື່ອມຕໍ່ດ່າຕ້າເບດ"
                .ShowDialog()
            End With
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        If (TextBox2.Text = "" And TextBox3.Text = "") Then
            'Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        ElseIf TextBox2.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        ElseIf TextBox3.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With

        Else
            Try
                sql = "insert into Mtime values(N'" & TextBox2.Text & "',N'" & TextBox3.Text & "')"
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

                'MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
            Catch ex As Exception
                ' messageboxss.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
            End Try
            AutoID()
            ShowServiceData()
        End If
        'TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        Try
            sql = "update Mtime set name = N'" & TextBox3.Text & "' WHERE Mtime_ID = N'" & TextBox2.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
            ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        ShowServiceData()
        AutoID()
        ' TextBox2.Text = ""
        TextBox3.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    sql = "Delete from Mtime where Mtime_ID = '" & (TextBox2.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                    ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                End Try
                '   messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")

            End If

        End With

        connect()

        ShowServiceData()
        ' TextBox2.Text = ""
        AutoID()
        TextBox3.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub
    Private Sub ShowServiceData()
        connect()
        sql = "select Mtime_ID,name from Mtime"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "Mtime")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Mtime"
        FormatDGVStyleStock()
    End Sub
    Private Sub FormatDGVStyleStock()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດຊ່ວງເວລາ"
            .Columns(1).HeaderText = "ຊື່ເວລາ"

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBox2.Enabled = False
        connect()
        AutoID()
        ShowServiceData()
        'load()
        FilterData("")
        TextBox2.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub
    Function confirm(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function

    Sub Msg_error(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbCritical + vbOKOnly, title)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FormatDGVStyleStock()
        FilterData(TextBox1.Text)
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value
        TextBox3.Text = DataGridView1.Item(1, i).Value
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True

    End Sub

    Sub Msg_ok(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM Mtime WHERE CONCAT(Mtime_ID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    Dim GetStockIDOnSale As String

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Dim charnum_ID As String
    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(Mtime_ID) from Mtime"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            TextBox2.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                TextBox2.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                TextBox2.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                TextBox2.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                ' messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                TextBox2.Text = ""
            End If
        Catch ex As Exception
            TextBox2.Text = "000001"
        End Try
        ShowServiceData()
    End Sub
    'Public Sub load()
    '    connect()
    '    sql = "select * from Mtime  "
    '    da = New SqlDataAdapter(sql, cn)
    '    ds = New DataSet
    '    da.Fill(ds, "table")
    '    DataGridView1.DataSource = ds.Tables("table")
    'End Sub
End Class