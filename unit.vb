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
Public Class unit
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetSaleID, save As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        Try
            sql = "update unit set name = N'" & TextBox3.Text & "' WHERE UID = N'" & TextBox2.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
            '  messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        ShowServiceData()
        AutoID()
        ' TextBox2.Text = ""
        TextBox3.Text = ""
        Button1.Enabled = True

        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then

                Try
                    sql = "Delete from unit where UID = '" & (TextBox2.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                    ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                End Try
            End If

        End With

        connect()

        ShowServiceData()
        AutoID()
        'TextBox2.Text = ""
        TextBox3.Text = ""
        Button1.Enabled = True

        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        If (TextBox2.Text = "" And TextBox3.Text = "") Then
            ' Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")
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
                sql = "insert into unit values(N'" & TextBox2.Text & "',N'" & TextBox3.Text & "')"
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

                'MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
            Catch ex As Exception
                With ms
                    .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                    .ShowDialog()
                End With
                ' messageboxss.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
            End Try
            AutoID()
            ShowServiceData()
        End If
        ' TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            ' MsgBox("Can't Connect")

            With ms
                .Label2.Text = "Can't Connect"
                .ShowDialog()
            End With
        End Try
    End Sub
    Private Sub ShowServiceData2()
        connect()
        sql = "select * from unit2"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "unit2")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "unit2"
        'FormatDGVStyleStock()
        FormatDGVStyleStock2()
    End Sub
    Private Sub ShowServiceData()
        connect()
        sql = "select UID,name from unit"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "unit")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "unit"
        FormatDGVStyleStock()
    End Sub
    Private Sub FormatDGVStyleStock()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະ​ຫັດຫົວໜ່ວຍ"
            .Columns(1).HeaderText = "ຫົວໜ່ວຍ"

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub FormatDGVStyleStock2()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView2
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະ​ຫັດຫົວໜ່ວຍ"
            .Columns(1).HeaderText = "ຫົວໜ່ວຍ"

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub unit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        TextBox6.Enabled = False

        Button4.Enabled = False
        Button5.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        connect()
        AutoID()
        ShowServiceData()
        'Load()
        FilterData("")
        ShowServiceData2()
        FilterData2("")
        AutoID2()
    End Sub
    Function confirm(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function

    Sub Msg_error(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbCritical + vbOKOnly, title)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterData(TextBox1.Text)
        FormatDGVStyleStock()
    End Sub
    'Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    '    FilterData2(TextBox5.Text)
    'End Sub

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()
        If (TextBox6.Text = "" And TextBox4.Text = "") Then
            Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")

        Else
            Try
                sql = "insert into unit2 values(N'" & TextBox6.Text & "',N'" & TextBox4.Text & "')"
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

                'MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
            Catch ex As Exception
                With ms
                    .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                    .ShowDialog()
                End With
                '  messageboxss.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
            End Try
            AutoID2()
            ShowServiceData2()
        End If
        ' TextBox6.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        Try
            sql = "update unit2 set name = N'" & TextBox4.Text & "' WHERE nitID = N'" & TextBox6.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
            '  messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        ShowServiceData2()
        AutoID2()
        ' TextBox6.Text = ""
        TextBox4.Text = ""
        Button6.Enabled = True

        Button5.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    sql = "Delete from unit2 where nitID = '" & (TextBox6.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                    '  messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                End Try
            End If

        End With

        connect()

        ShowServiceData2()
        AutoID2()
        'TextBox6.Text = ""
        TextBox4.Text = ""
        Button6.Enabled = True

        Button5.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        FormatDGVStyleStock2()
        FilterData2(TextBox5.Text)

    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM unit WHERE CONCAT(UID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    Dim charnum_ID As String
    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(UID) from unit"
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
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                ' messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                TextBox2.Text = ""
            End If
        Catch ex As Exception
            TextBox2.Text = "000001"
        End Try
        ShowServiceData()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub AutoID2()
        sql = "Select max(nitID) from unit2"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            TextBox6.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                TextBox6.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                TextBox6.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                TextBox6.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                '  messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                TextBox6.Text = ""
            End If
        Catch ex As Exception
            TextBox6.Text = "000001"
        End Try
        ShowServiceData2()
    End Sub
    Public Sub FilterData2(valueToSearch As String)
        'Dim searchQuery As String = "SELECT * FROM unit2 WHERE CONCAT(nitID,name) like N'%" & valueToSearch & "%' "
        'Dim command As New SqlCommand(searchQuery, cn)
        'Dim adapter As New SqlDataAdapter(command)
        'Dim table As New DataTable()

        'adapter.Fill(table)

        'DataGridView2.DataSource = table

    End Sub
    'Public Sub load()
    '    connect()
    '    sql = "select * from unit  "
    '    da = New SqlDataAdapter(sql, cn)
    '    ds = New DataSet
    '    da.Fill(ds, "table")
    '    DataGridView1.DataSource = ds.Tables("table")
    'End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i As Integer = DataGridView2.CurrentRow.Index
        TextBox6.Text = DataGridView2.Item(0, i).Value
        TextBox4.Text = DataGridView2.Item(1, i).Value
        Button6.Enabled = False

        Button4.Enabled = True
        Button5.Enabled = True
    End Sub
End Class