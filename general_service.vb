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
Public Class general_service
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT, getcheck, GetqID, getd As String
    Dim o As Integer
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            MsgBox("Can't Connect")
        End Try
    End Sub
    Private Sub ShowServiceData1()
        connect()
        sql = "select * from View_q"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_q")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_q"
        FormatDGVStyleStock1()
    End Sub
    Private Sub ShowServiceData2()
        connect()
        sql = "select * from View_history"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_history")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_history"
        FormatDGVStyleStock2()
    End Sub
    Private Sub ShowServiceData7()
        connect()
        sql = "select * from View_checkprices where billID='" & t9.Text & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_checkprices")
        DataGridView7.DataSource = ds
        DataGridView7.DataMember = "View_checkprices"
        FormatDGVStyleStock7()
    End Sub
    Private Sub ShowServiceData6()
        connect()
        sql = "select * from RPrice"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "RPrice")
        DataGridView6.DataSource = ds
        DataGridView6.DataMember = "RPrice"
        FormatDGVStyleStock6()
    End Sub
    Private Sub ShowServiceData3()
        connect()
        sql = "select * from finished where date ='" & Date.Now & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "finished")
        DataGridView3.DataSource = ds
        DataGridView3.DataMember = "finished"
        FormatDGVStyleStock3()
    End Sub
    Private Sub ShowServiceData4()
        connect()
        sql = "select * from View_medicine"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_medicine")
        DataGridView4.DataSource = ds
        DataGridView4.DataMember = "View_medicine"
        FormatDGVStyleStock4()
    End Sub
    Private Sub ShowServiceData5()
        connect()
        'where billID ='" & t9.Text & "'
        sql = "select * from View_billdetail  where billID='" & t9.Text & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billdetail")
        DataGridView5.DataSource = ds
        DataGridView5.DataMember = "View_billdetail"
        FormatDGVStyleStock5()
    End Sub
    Private Sub FormatDGVStyleStock4()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView4
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດຢາ"
            .Columns(1).HeaderText = "ຊື່ຢາ"
            .Columns(2).HeaderText = "ຊະນິດ"
            .Columns(3).HeaderText = "ປະເພດ"
            .Columns(4).HeaderText = "ລາຄາ"
            .Columns(5).HeaderText = "ຈຳນວນ"
            .Columns(6).HeaderText = "ຫົວໜ່ວຍ"

            .Columns(4).DefaultCellStyle.Format = "N2"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub FormatDGVStyleStock1()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດຄິວ"
            .Columns(1).HeaderText = "ລະຫັດສັດລ້ຽງ"
            .Columns(2).HeaderText = "ຊື່"
            .Columns(3).HeaderText = "ປະເພດ"
            .Columns(4).HeaderText = "ສາຍພັນ"
            .Columns(5).HeaderText = "ສີ"
            .Columns(6).HeaderText = "ເພດ"
            .Columns(7).HeaderText = "ອາຍຸ"
            .Columns(8).HeaderText = "ເຮັດໝັນ"
            .Columns(9).HeaderText = "ໄລຍະເຈັບ"
            .Columns(10).HeaderText = "ນ້ຳໜັກ"
            .Columns(11).HeaderText = "ປະຫວັດການແພດ"
            .Columns(12).HeaderText = "ອາການ"
            .Columns(13).HeaderText = "ຊື່ເຈົ້າຂອງ"

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter


            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub FormatDGVStyleStock3()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView3
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ຜົນກວດ"
            .Columns(3).HeaderText = "ວັນເດືອນປີທີ່ມາຮັກສາ"
            .Columns(4).HeaderText = "ນັດໝາຍຄັ້ງຕໍ່ໄປ"
            .Columns(5).HeaderText = "ລະຫັດໃບບິນ"
            .Columns(6).HeaderText = "ໝໍທີ່ຮັກສາ"
            .Columns(7).HeaderText = "ປະເພດການຮັກສາ"
            .Columns(8).HeaderText = "ໝາຍເຫດ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
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
            .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ຜົນກວດ"
            .Columns(3).HeaderText = "ວັນເດືອນປີທີ່ມາຮັກສາ"
            .Columns(4).HeaderText = "ນັດໝາຍຄັ້ງຕໍ່ໄປ"
            .Columns(5).HeaderText = "ລະຫັດໃບບິນ"
            .Columns(6).HeaderText = "ໝໍທີ່ຮັກສາ"
            .Columns(7).HeaderText = "ປະເພດການຮັກສາ"
            .Columns(8).HeaderText = "ໝາຍເຫດ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub FormatDGVStyleStock5()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView5
            .ColumnHeadersDefaultCellStyle = cs
            '.Columns(0).HeaderText = "ລະຫັດໃບສັ່ງຢາ"
            .Columns(0).HeaderText = "ຊື່"
            .Columns(1).HeaderText = "ຊະນິດ"
            .Columns(2).HeaderText = "ປະເພດ"
            .Columns(3).HeaderText = "ລາຄາ"
            .Columns(4).HeaderText = "ຈຳນວນ"
            .Columns(5).HeaderText = "ຫົວໜ່ວຍ"
            .Columns(6).HeaderText = "ລວມ"
            .Columns(7).HeaderText = "ໂມງໃຊ້ຢາ"
            .Columns(8).HeaderText = "ຈຳນວນ/ຄັ້ງ"
            .Columns(9).HeaderText = "ຫົວໜ່ວຍກິນ"
            .Columns(10).HeaderText = "ລະຫັດບິນ"
            .Columns(11).HeaderText = "ລະຫັດຢາ"
            .Columns(12).HeaderText = "ໝາຍເຫດ"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub FormatDGVStyleStock6()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView6
            .ColumnHeadersDefaultCellStyle = cs
            '.Columns(0).HeaderText = "ລະຫັດໃບສັ່ງຢາ"
            .Columns(0).HeaderText = "ລະຫັດ"
            .Columns(1).HeaderText = "ຊື່ການກວດ"
            .Columns(2).HeaderText = "ລາຄາ"
            .Columns(2).DefaultCellStyle.Format = "N2"
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub FormatDGVStyleStock7()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView7
            .ColumnHeadersDefaultCellStyle = cs
            '.Columns(0).HeaderText = "ລະຫັດໃບສັ່ງຢາ"
            .Columns(0).HeaderText = "ລະຫັດບິນ"
            .Columns(1).HeaderText = "ຊື່ການກວດ"
            .Columns(2).HeaderText = "ລາຄາ"
            .Columns(3).HeaderText = "ລະຫັດກວດ"
            .Columns(2).DefaultCellStyle.Format = "N2"
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles t3.TextChanged

    End Sub
    Dim charnum_ID As String
    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(billID) from Bill"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            t9.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                t9.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                t9.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                t9.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                ' MessageBox.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                t9.Text = ""
            End If
        Catch ex As Exception
            t9.Text = "1"
        End Try
        ShowServiceData5()
        'ShowServiceData4()
    End Sub
    Dim GetStockIDOnSale As String
    Dim currows As Integer
    'Private Sub StockIDForCompare()
    '    connect()
    '    sql = "Select * FROM View_sale WHERE saleID_full='" & t9.Text &
    '        "' and StockID_full='" & GetStockID & "'"
    '    cmd = New SqlClient.SqlCommand(sql, cn)
    '    da = New SqlClient.SqlDataAdapter(cmd)
    '    ds = New DataSet
    '    da.Fill(ds, "View_sale")
    '    If ds.Tables("View_sale").Rows.Count = 0 Then
    '        Exit Sub
    '    Else
    '        With ds.Tables("View_sale")
    '            GetStockIDOnSale = .Rows(currows)("StockID_full")
    '        End With
    '    End If
    'End Sub
    Private Sub b3_Click(sender As Object, e As EventArgs) Handles b3.Click
        connect()
        'If GetStockID = "" Then
        '    MessageBox.Show("ກະ​ລຸ​ນາ​ລະ​ບຸລາຍ​ການ​ສິນ​ຄ້າ")
        'ElseIf t9.Text = "" Then
        '    MessageBox.Show("ກະ​ລຸ​ນາ​ລະ​ບຸຈຳ​ນວນ")
        'ElseIf GetStockID = GetStockIDOnSale Then
        '    MessageBox.Show("ສິນ​ຄ້າ​ນີ້​ມີ​ໃນລາຍ​ການ​ສັ່ງ​ຊື້​ບິນ​ນີ້​ແລ້ວບໍ່​ສາ​ມາດ​ເພີ່ມໃໝ່​ອີກ ແຕ່​ສາ​ມາດ​ອັບ​ເດດ​ຈຳ​ນວນ​ໄດ້")
        'Else
        ' Try
        'sql = "insert into MP values(@billID,@MID,@unitS ,@priceS ,@Mtime_ID,@unitM)"
        'cmd.Parameters.Clear()
        'cmd.CommandText = sql
        'cmd.Parameters.AddWithValue("billID", t9.Text)
        'cmd.Parameters.AddWithValue("MID", GetStockID)
        'cmd.Parameters.AddWithValue("unitS", t12.Text)
        'cmd.Parameters.AddWithValue("priceS", t13.Text)
        'cmd.Parameters.AddWithValue("Mtime_ID", c14.SelectedValue)
        'cmd.Parameters.AddWithValue("unitM", t15.Text)
        'cmd.ExecuteNonQuery()
        'ShowServiceData5()
        'addbill()
        ' Catch ex As Exception
        ' MessageBox.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນ! ເນື່ອງ​ຈາກຂໍ້​ມູນ​ບໍ່​ຖືກ​ຕ້ອງກະ​ລຸ​ນາ​ກວດ​ສອບ​ຂໍ້​ມູນ")
        'End Try
        'End If
        Dim o As Integer
        o = DataGridView4.CurrentRow.Cells(5).Value

        IDFly2()
        If (t12.Text = "" And c14.Text = "" And t15.Text = "" And ComboBox2.Text = "") Then
            ' messageboxss.Show("ກະລຸນາເຕີມຂໍ້ມູນໃຫ້ຄົບ")
            'IDFly2()
            With ms
                .Label2.Text = "ກະລຸນາເຕີມຂໍ້ມູນໃຫ້ຄົບ"
                .ShowDialog()
            End With
        ElseIf (t12.Text = "") Then
            ' messageboxss.Show("ກະລຸນາເຕີມຈຳນວນຢາ")
            'IDFly2()
            With ms
                .Label2.Text = "ກະລຸນາເຕີມຈຳນວນຢາ"
                .ShowDialog()
            End With
        ElseIf (c14.Text = "") Then
            ' messageboxss.Show("ກະລຸນາເລືອກເວລາກິນ")
            'IDFly2()
            With ms
                .Label2.Text = "ກະລຸນາເລືອກເວລາກິນ"
                .ShowDialog()
            End With
        ElseIf (t15.Text = "") Then
            ' messageboxss.Show("ກະລຸນາເຕີມຈຳນວນຢາທີ່ຄວນກິນ")
            With ms
                .Label2.Text = "ກະລຸນາເຕີມຈຳນວນຢາທີ່ຄວນກິນ"
                .ShowDialog()
            End With
        ElseIf (ComboBox2.Text = "") Then
            ' messageboxss.Show("ກະລຸນາເລືອກຫົວໜ່ວຍ")
            With ms
                .Label2.Text = "ກະລຸນາເລືອກຫົວໜ່ວຍ"
                .ShowDialog()
            End With


        ElseIf o <= 0 Then
                With ms
                    .Label2.Text = "ຈຳນວນຢາໝົດແລ້ວ"
                    .ShowDialog()
                End With
            ElseIf o < t12.Text Then
                With ms
                    .Label2.Text = "ຈຳນວນຢາໃນຄັງບໍ່ພຽງພໍ"
                    .ShowDialog()
                End With
            ElseIf GetStockID = GetStockIDOnOrder1 Then
                'MessageBox.Show("ບໍ່ສາມາດເພີ່ມລາຍການທີ່ຊ້ຳກັນໄດ້ ກະລຸນາອັບເດດລາຍການ")
                'Exit Sub
                UpdateData()

            Else
                InsertData()
            ShowServiceData5()
        End If
        'UpdateData1()
        ShowServiceData4()
        ShowServiceData5()
        't11.Text = ""
        't12.Text = ""
        'c14.Text = "=="
        't15.Text = ""
        'ComboBox2.Text = "=="
    End Sub
    'Public Sub addbill()
    '    connect()
    '    '   Try
    '    sql = "update Bill set sum = '" & t16.Text & "',statut = N'ຍັງບໍ່ທັນຈ່າຍ' WHERE billID = '" & t9.Text & "'"
    '    cmd = New SqlCommand(sql, cn)
    '    cmd.ExecuteNonQuery()
    '    ShowServiceData5()
    '    '   Catch ex As Exception
    '    '  MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
    '    '   End Try
    'End Sub
    Public Sub addbill3()
        connect()
        Dim i As Integer
        Dim u As Integer
        Dim love As Integer
        i = TextBox4.Text
        u = t16.Text
        love = i + u
        Try
            sql = "update Bill set sum=@sum, statut=@statut  WHERE billID='" & t9.Text.Trim & "'"
            cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("sum", love)
            cmd.Parameters.AddWithValue("statut", "ຍັງບໍ່ທັນຈ່າຍ")

            cmd.ExecuteNonQuery()
            'sql = "update Bill set sum = '" & t16.Text & "',statut = N'ຍັງບໍ່ທັນຈ່າຍ' WHERE billID = '" & t9.Text & "'"
            'cmd = New SqlCommand(sql, cn)

            ShowServiceData5()

        Catch ex As Exception
            '  MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
        End Try
    End Sub
    Public Sub addbillcheck()
        connect()

        Try
            sql = "update Bill set sum=@sum, statut=@statut  WHERE billID='" & t9.Text.Trim & "'"
            cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("sum", TextBox4.Text)
            cmd.Parameters.AddWithValue("statut", "ຍັງບໍ່ທັນຈ່າຍ")

            cmd.ExecuteNonQuery()
            'sql = "update Bill set sum = '" & t16.Text & "',statut = N'ຍັງບໍ່ທັນຈ່າຍ' WHERE billID = '" & t9.Text & "'"
            'cmd = New SqlCommand(sql, cn)

            ShowServiceData7()

        Catch ex As Exception
            '  MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
            'With ms
            '    .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
            '    .ShowDialog()
            'End With
        End Try
    End Sub
    Public Sub addbill2()
        connect()
        Try
            sql = "insert into Bill values('" & t9.Text & "','0', '-')"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            ' MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
        Catch ex As Exception
            With ms
                .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                .ShowDialog()
            End With
            ' MessageBox.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
        End Try
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_medicine WHERE CONCAT(name,paphet) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView4.DataSource = table
        FormatDGVStyleStock4()
    End Sub

    'Public Sub FilterData(valueToSearch As String)
    '    Dim searchQuery As String = "SELECT * FROM Medicine WHERE CONCAT(MID,name) like N'%" & valueToSearch & "%' "
    '    Dim command As New SqlCommand(searchQuery, cn)
    '    Dim adapter As New SqlDataAdapter(command)
    '    Dim table As New DataTable()

    '    adapter.Fill(table)
    '    'DataGridView4.DataSource = table

    'End Sub
    'Private Sub t10_TextChanged(sender As Object, e As EventArgs) Handles t10.TextChanged
    '    FilterData(t10.Text)
    'End Sub
    Private Sub DataGridView4_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView4.CellMouseClick

        'Dim i As Integer = DataGridView1.CurrentRow.Index
        'GetStockID = DataGridView4.Item(0, i).Value
        't11.Text = DataGridView4.Item(4, i).Value
        't12.Focus()


    End Sub

    Private Sub t12_TextChanged(sender As Object, e As EventArgs) Handles t12.TextChanged
        'Dim i As Integer
        'Dim u As Integer
        'Dim love As Integer
        'i = t11.Text
        'u = t12.Text
        'love = i * u
        't13.Text = love

    End Sub
    Public Sub FilterDatacheck(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM RPrice WHERE CONCAT(RID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView6.DataSource = table

    End Sub
    Private Sub general_service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowServiceData7()
        ShowServiceData2()
        ShowServiceData3()
        courses_combo1()
        courses_combo3()
        ShowServiceData6()
        ShowServiceData1()
        ShowServiceData4()
        connect()
        'num()
        unable()
        AutoID()
        ShowServiceData5()
        'FilterData("")
        courses_combo()
        AutoID2()
        FilterData4("")
        unnanut()
        t9.Enabled = False
        t2.Enabled = False
        t1.Enabled = False
        t6.Enabled = False
        t16.Enabled = False
        b8.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox3.Enabled = False
        Button6.Enabled = False
        TextBox4.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button2.Enabled = False
        TextBox1.Text = t9.Text
    End Sub

    Private Sub DataGridView4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellClick
        Dim i As Integer = DataGridView4.CurrentRow.Index
        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        Else
            With DataGridView4

                GetStockID = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
                t11.Text = DataGridView4.Item(4, i).Value

                o = DataGridView4.CurrentRow.Cells(5).Value

            End With
        End If
        IDFly2()
        't11.Text = DataGridView4.Item(4, i).Value
        t12.Focus()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        If (e.RowIndex < 0) Then

        Else
            Label8.Text = DataGridView1.Item(0, i).Value
            t2.Text = DataGridView1.Item(1, i).Value
            Dim u As String
            u = DataGridView1.Item(2, i).Value
            FilterData4(u)
            t3.Focus()
            Button2.Enabled = True
        End If
    End Sub

    Private Sub b8_Click(sender As Object, e As EventArgs) Handles b8.Click

        connect()
        ' addbill3()
        ' t6.Text = t9.Text

        Try
            addbill3()
            'addbill()
            'num()
            DataGridView5.Refresh()
            'messageboxss.Show("ການສັ່ງຢາສຳເລັດ")
            With ms
                .Label2.Text = "ການສັ່ງຢາສຳເລັດ"
                .ShowDialog()
            End With
        Catch ex As Exception
            ' messageboxss.Show("ການສັ່ງຢາເກີດບັນຫາບາງຢ່າງ ກະລຸນາກວດສອບຄືນ")
            With ms
                .Label2.Text = "ການສັ່ງຢາເກີດບັນຫາບາງຢ່າງ ກະລຸນາກວດສອບຄືນ"
                .ShowDialog()
            End With
        End Try
        unable()
        t11.Text = ""
        t12.Text = ""
        c14.Text = "=="
        t15.Text = ""
        ComboBox2.Text = "=="
        t16.Text = ""
        Button11.Enabled = True
        ' AutoID()
    End Sub

    Private Sub t10_TextChanged(sender As Object, e As EventArgs) Handles t10.TextChanged

    End Sub

    Private Sub courses_combo()
        Dim sql As String = "Select*from Mtime"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "Mtime")
        c14.DataSource = ds.Tables("Mtime")
        c14.DisplayMember = "name"
        c14.ValueMember = "Mtime_ID"
        c14.Text = "ເລືອກສີຂົນ"
    End Sub
    Private Sub courses_combo1()
        Dim sql As String = "Select*from Service"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "Service")
        c8.DataSource = ds.Tables("Service")
        c8.DisplayMember = "name"
        c8.ValueMember = "SID"
        c8.Text = "=="
    End Sub
    Private Sub courses_combo3()
        Dim sql As String = "Select*from unit2"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "unit2")
        ComboBox2.DataSource = ds.Tables("unit2")
        ComboBox2.DisplayMember = "name"
        ComboBox2.ValueMember = "nitID"
        ComboBox2.Text = "=="
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        b8.Enabled = True
        Dim Sum As Decimal = 0
        For i = 0 To DataGridView5.Rows.Count - 1
            Sum += DataGridView5.Rows(i).Cells(6).Value
        Next
        t16.Text = Sum
    End Sub

    Private Sub b7_Click(sender As Object, e As EventArgs)
        'Dim i As Integer
        'Dim u As Integer
        'Dim love As Integer
        'i = t11.Text
        'u = t12.Text
        'love = i * u
        't13.Text = love
    End Sub

    'Private Sub num()
    'Dim num As Integer
    '    cmd = New SqlCommand("select count(QID) from q", cn)
    '    num = Convert.ToInt16(cmd.ExecuteScalar()) + 1
    '    t9.Text = "000" + num
    '    cn.Close()

    'End Sub
    Private Sub t10_KeyDown(sender As Object, e As KeyEventArgs) Handles t10.KeyDown
        FilterData(t10.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AutoID()
        TextBox1.Text = t9.Text
        addbill2()
        'unable()
        un()
        ''t11.Enabled = True
        ShowServiceData7()

        Button6.Enabled = True

        Button6.Enabled = True
        Button7.Enabled = True

        Button9.Enabled = True
        Button10.Enabled = True
        Button2.Enabled = False
    End Sub

    Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick

    End Sub

    'Private Sub t12_KeyDown(sender As Object, e As KeyEventArgs) Handles t12.KeyDown
    '    'Dim i As Integer
    '    'Dim u As Integer
    '    'Dim love As Integer
    '    'i = t11.Text
    '    'u = t12.Text
    '    'love = i * u
    '    't13.Text = love
    'End Sub
    Private Sub AutoID2()
        sql = "Select max(TRID1) from TR2"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            t1.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                t1.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                t1.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                t1.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                'MessageBox.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                t1.Text = ""
            End If
        Catch ex As Exception
            t1.Text = "1"
        End Try
        ShowServiceData1()
    End Sub

    Private Sub t9_TextChanged(sender As Object, e As EventArgs) Handles t9.TextChanged
        'FilterData7(t9.Text)
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        'Dim f As String
        'f = DataGridView1.CurrentRow.Cells(0).Value.ToString
        'With petdetail
        '    .Label9.Text = DataGridView1.CurrentRow.Cells(1).Value
        '    .t1.Text = DataGridView1.CurrentRow.Cells(2).Value
        '    .Label10.Text = DataGridView1.CurrentRow.Cells(3).Value
        '    .Label11.Text = DataGridView1.CurrentRow.Cells(4).Value
        '    .Label12.Text = DataGridView1.CurrentRow.Cells(5).Value
        '    .Label13.Text = DataGridView1.CurrentRow.Cells(10).Value
        '    .TextBox1.Text = DataGridView1.CurrentRow.Cells(7).Value
        '    .TextBox2.Text = DataGridView1.CurrentRow.Cells(8).Value
        '    .TextBox3.Text = DataGridView1.CurrentRow.Cells(9).Value
        '    .TextBox4.Text = DataGridView1.CurrentRow.Cells(6).Value
        '    .TextBox5.Text = DataGridView1.CurrentRow.Cells(11).Value
        '    .TextBox6.Text = DataGridView1.CurrentRow.Cells(12).Value
        '    .Show()
        'End With
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs)
    '    '
    'End Sub

    Private Sub DataGridView5_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellDoubleClick

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim f As String
        f = DataGridView1.CurrentRow.Cells(0).Value.ToString
        With home
            .st(petdetail)
        End With
        With petdetail
            .Label9.Text = DataGridView1.CurrentRow.Cells(1).Value
            .t1.Text = DataGridView1.CurrentRow.Cells(2).Value
            .Label10.Text = DataGridView1.CurrentRow.Cells(3).Value
            .Label11.Text = DataGridView1.CurrentRow.Cells(4).Value
            .Label12.Text = DataGridView1.CurrentRow.Cells(5).Value
            .TextBox7.Text = DataGridView1.CurrentRow.Cells(10).Value
            .TextBox1.Text = DataGridView1.CurrentRow.Cells(7).Value
            .TextBox2.Text = DataGridView1.CurrentRow.Cells(8).Value
            .TextBox3.Text = DataGridView1.CurrentRow.Cells(9).Value
            .TextBox4.Text = DataGridView1.CurrentRow.Cells(6).Value
            .TextBox5.Text = DataGridView1.CurrentRow.Cells(11).Value
            .TextBox6.Text = DataGridView1.CurrentRow.Cells(12).Value
            .Show()
        End With

    End Sub

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        connect()
        If (t2.Text = "" And t3.Text = "" And t6.Text = "" And c8.Text = "") Then

            With ms

                .Label2.Text = "ກະລຸນາເຕີມຂໍ້ມູນໃຫ້ຄົບ"
                .ShowDialog()
            End With
        ElseIf (t2.Text = "") Then
            With ms
                .Label2.Text = "ກະລຸນາເລືອກສັດລ້ຽງ"
                .ShowDialog()
            End With

        ElseIf (t3.Text = "") Then

            With ms

                .Label2.Text = "ກະລຸນາເພີ່ມຜົນການຮັກສາ"
                .ShowDialog()
            End With
        ElseIf (t6.Text = "") Then

            With ms

                .Label2.Text = "ກະລຸນາເພີ່ມເລກໃບບິນ"
                .ShowDialog()
            End With
        ElseIf (c8.Text = "==") Then
            ' messageboxss.Show("ກະລຸນາເລືອກການບໍລິການ")
            With ms

                .Label2.Text = "ກະລຸນາເລືອກການບໍລິການ"
                .ShowDialog()
            End With
        ElseIf (d5.Enabled = True) Then
            sql = "insert into TR2 values(@TRID1,@PetID,@results ,@date ,@appoint,@billID,@EMPID,@SID,@status)"
            cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("TRID1", t1.Text)
            cmd.Parameters.AddWithValue("PetID", t2.Text)
            cmd.Parameters.AddWithValue("results", t3.Text)
            cmd.Parameters.AddWithValue("date", Date.Now)
            cmd.Parameters.AddWithValue("appoint", d5.Value.Date)
            cmd.Parameters.AddWithValue("billID", t6.Text)
            With home
                cmd.Parameters.AddWithValue("EMPID", .ToolStripStatusLabel6.Text)
            End With
            cmd.Parameters.AddWithValue("SID", c8.SelectedValue)
            cmd.Parameters.AddWithValue("status", "ມີນັດໝາຍ")
            cmd.ExecuteNonQuery()
            print()
            deleteQ()
            'print()
            ShowServiceData3()
            AutoID2()
            ShowServiceData1()
            t2.Text = ""
            t3.Text = ""
            d5.Enabled = False
            t6.Text = ""
            c8.Text = "=="
            TextBox4.Text = ""
        ElseIf (d5.Enabled = False) Then
            sql = "insert into TR2 values(@TRID1,@PetID,@results,@date,@appoint,@billID,@EMPID,@SID,@status)"
            cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("TRID1", t1.Text)
            cmd.Parameters.AddWithValue("PetID", t2.Text)
            cmd.Parameters.AddWithValue("results", t3.Text)
            cmd.Parameters.AddWithValue("date", DateTime.Now)
            cmd.Parameters.AddWithValue("appoint", DateTime.Now)
            cmd.Parameters.AddWithValue("billID", t6.Text)
            With home
                cmd.Parameters.AddWithValue("EMPID", .ToolStripStatusLabel6.Text)
            End With
            cmd.Parameters.AddWithValue("SID", c8.SelectedValue)
            cmd.Parameters.AddWithValue("status", "ບໍ່ມີນັດໝາຍ")
            cmd.ExecuteNonQuery()
            print()
            deleteQ()
            'print()
            ShowServiceData3()
            AutoID2()
            ShowServiceData1()
            t2.Text = ""
            t3.Text = ""
            d5.Enabled = False
            t6.Text = ""
            TextBox4.Text = ""
            c8.Text = "=="
        End If
        'print()
        'ShowServiceData3()
        'deleteQ()
        'AutoID2()
        ''ShowServiceData2()
        'ShowServiceData1()
        'print()

        't2.Text = ""
        't3.Text = ""
        d5.Enabled = False
        Button2.Enabled = True
        't6.Text = ""
        'c8.Text = "=="

    End Sub
    Private Sub print()
        connect()
        Dim c As New CrystalReport4
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_reportresult where TRID1='" & t1.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_reportresult")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    'Private Sub b5_Click(sender As Object, e As EventArgs)
    '    t11.Text = ""
    '    t12.Text = ""
    '    c14.Text = "=="
    '    t15.Text = ""

    'End Sub

    Private Sub DataGridView5_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView5.CellMouseDoubleClick
        '  My.Computer.Audio.Play(My.Resources.Mouse_Click_1, AudioPlayMode.Background)
        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        End If
        If GetSupplierID = "" Then
            'error_message("ກະລຸນາລະບຸຜູ້ສະໜອງສິນຄ້າກ່ອນ")
        Else
            With DataGridView5
                ' PicID = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
                'Stockid = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
            End With
            'IDFly2()
            'If GetStockID = GetStockIDOnOrder1 Then
            '    'MessageBox.Show("Don't need new")
            '    'Exit Sub
            '    UpdateData()
            'Else
            '    InsertData()
            'End If
        End If
        'Calculate_Total()
    End Sub
    Private Sub InsertData()
        connect()
        ' If GetSupplierID = "" Then
        '   error_message("ກະລຸນາລະບຸຜູ້ສະໜອງສິນຄ້າກ່ອນ")
        'Else
        Dim i As Integer
        i = t11.Text

        Dim u As Integer
        u = t12.Text
        Dim love As Integer
        love = i * u

        Try

                sql = "insert into MP1 values(@billID,@MID,@unitS ,@priceS ,@Mtime_ID,@unitM,@nitID)"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("billID", t9.Text)
                cmd.Parameters.AddWithValue("MID", GetStockID)
                cmd.Parameters.AddWithValue("unitS", t12.Text)
                cmd.Parameters.AddWithValue("priceS", love)
                cmd.Parameters.AddWithValue("Mtime_ID", c14.SelectedValue)
                cmd.Parameters.AddWithValue("unitM", t15.Text)
                cmd.Parameters.AddWithValue("nitID", ComboBox2.SelectedValue)
                cmd.ExecuteNonQuery()
                If t12.Text <> "" Then
                    cmd.Parameters.AddWithValue("unitS", t12.Text)
                Else
                    ' cmd.Parameters.AddWithValue("unitS", 1)
                End If
                'If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດບັນທຸກຂໍ້ມູນ")
                'Else
                UpdateData1()
                ShowServiceData5()
                ' ShowOrder()
                'MarkDuplicates()
                '  Calculate_Total()
                '    End If
            Catch ex As Exception
                With ms
                    .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ມີແລ້ວ"
                    .ShowDialog()
                End With
                'error_message("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ມີແລ້ວ")
            End Try


        ' End If

    End Sub
    Private Sub InsertDatacheak()
        connect()
        ' If GetSupplierID = "" Then
        '   error_message("ກະລຸນາລະບຸຜູ້ສະໜອງສິນຄ້າກ່ອນ")
        'Else

        'Try
        sql = "insert into checkprice values(@billID,@RID)"
        cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("billID", t9.Text)
        cmd.Parameters.AddWithValue("RID", getcheck)
        cmd.ExecuteNonQuery()

        'Catch ex As Exception
        '    With ms
        '        .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ມີແລ້ວ"
        '        .ShowDialog()
        '    End With

        ' End Try

        ShowServiceData7()
    End Sub
    Private Sub UpdateData()
        connect()
        If GetStockID = "" Then
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
        Else
            Dim i As Integer
            Dim u As Integer
            Dim love As Integer
            i = t11.Text
            u = t12.Text
            love = i * u
            Try
                sql = "update MP1 set unitS=@unitS, priceS=@priceS, Mtime_ID=@Mtime_ID, unitM=@unitM, nitID=@nitID WHERE billID='" & t9.Text.Trim &
                "' and MID='" & GetStockID & "'"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("unitS", t12.Text)
                cmd.Parameters.AddWithValue("priceS", love)
                cmd.Parameters.AddWithValue("Mtime_ID", c14.SelectedValue)
                cmd.Parameters.AddWithValue("unitM", t15.Text)
                cmd.Parameters.AddWithValue("nitID", ComboBox2.SelectedValue)
                cmd.ExecuteNonQuery()
                ' If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                'Else
                'ShowOrder()
                UpdateData2()
                ShowServiceData5()
                ' Calculate_Total()
                '    End If
            Catch ex As Exception
                ' MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                With ms
                    .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                    .ShowDialog()
                End With
            End Try
        End If
    End Sub
    Private Sub IDFly2()
        connect()
        sql = "Select * FROM View_billdetail WHERE billID='" & t9.Text.Trim &
            "' and MID='" & GetStockID & "'"
        cmd = New SqlClient.SqlCommand(sql, cn)
        da = New SqlClient.SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_billdetail")
        If ds.Tables("View_billdetail").Rows.Count = 0 Then
            Exit Sub
        Else
            With ds.Tables("View_billdetail")
                GetStockIDOnOrder1 = .Rows(currow)("MID")
                GetOrderQTT = .Rows(currow)("unitS")
            End With
        End If
    End Sub

    Private Sub b4_Click(sender As Object, e As EventArgs) Handles b4.Click
        'Dim i As Integer = DataGridView5.CurrentRow.Index
        'Dim n As String
        'n = DataGridView5.Item(11, i).Value
        'With ms
        '    .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
        '    .ShowDialog()
        'End With
        connect()

        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ຫຼືບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                ' connect()
                Try
                    cmd = New SqlCommand("delete from MP1 where MID =  '" & Label3.Text & "' And billID ='" & t9.Text.Trim &
            "'", cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                End Try
                UpdateData3()
                ShowServiceData5()
                'YESorNO.Close()
                'ElseIf .bno.Text = "ຍົກເລີກ" Then
                'YESorNO.Close()

            End If
            'Return


        End With
        'connect()
        'cmd = New SqlCommand("delete from MP1 where MID =  '" & Label3.Text & "'", cn)
        'cmd.ExecuteNonQuery()
        'UpdateData3()
        'ShowServiceData5()
    End Sub

    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        'Dim i As Integer = DataGridView5.CurrentRow.Index

        'Dim n As String
        'n = DataGridView5.Item(11, i).Value

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    'Private Sub b6_Click(sender As Object, e As EventArgs) Handles b6.Click
    '    connect()
    '    cmd = New SqlCommand("delete from MP1 where billID = '" & t9.Text & "'", cn)
    '    cmd.ExecuteNonQuery()
    '    UpdateData4()
    '    ShowServiceData5()
    'End Sub

    Private Sub DataGridView5_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView5.CellMouseClick
        Dim i As Integer = DataGridView5.CurrentRow.Index
        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        Else
            With DataGridView5

                ' GetStockIDOnOrder1 = .Rows.Item(e.RowIndex).Cells(9).Value.ToString()
                t11.Text = DataGridView5.Item(3, i).Value
                t12.Text = DataGridView5.Item(4, i).Value
                c14.Text = DataGridView5.Item(7, i).Value
                t15.Text = DataGridView5.Item(8, i).Value
                ComboBox2.Text = DataGridView5.Item(9, i).Value
                Label3.Text = DataGridView5.Item(11, i).Value
            End With
        End If
        ' IDFly2()
        't11.Text = DataGridView4.Item(4, i).Value
        't12.Focus()
    End Sub
    'Private Sub IDFly()
    '    connect()
    '    sql = "Select * FROM View_medicine WHERE MID='" & PicID & "'"
    '    cmd = New SqlClient.SqlCommand(sql, cn)
    '    da = New SqlClient.SqlDataAdapter(cmd)
    '    ds = New DataSet
    '    da.Fill(ds, "TB_Stock")
    '    With ds.Tables("TB_Stock")
    '        GetStockID = .Rows(currow)("StockID")
    '    End With
    'End Sub
    Public Sub FilterData4(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_history WHERE name like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView2.DataSource = table

    End Sub
    'Public Sub FilterData7(valueToSearch As String)
    '    Dim searchQuery As String = "SELECT * FROM View_checkprices WHERE billID like N'%" & valueToSearch & "%' "
    '    Dim command As New SqlCommand(searchQuery, cn)
    '    Dim adapter As New SqlDataAdapter(command)
    '    Dim table As New DataTable()

    '    adapter.Fill(table)

    '    DataGridView7.DataSource = table

    'End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Public Sub deleteQ()
        sql = "Delete from q where QID = '" & (Label8.Text) & "'"
        cmd = New SqlCommand(sql, cn)
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub DataGridView1_ColumnSortModeChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnSortModeChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DataGridView1_ColumnHeadersHeightChanged(sender As Object, e As EventArgs) Handles DataGridView1.ColumnHeadersHeightChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        unnanut()
        d5.Enabled = True
    End Sub

    Private Sub unable()
        t11.Enabled = False
        t12.Enabled = False
        c14.Enabled = False
        t15.Enabled = False
        ComboBox2.Enabled = False
        b3.Enabled = False
        b4.Enabled = False
        ' b6.Enabled = False
        Button1.Enabled = False
        't16.Enabled = False
        b8.Enabled = False
        Button4.Enabled = False

    End Sub
    Sub un()
        TextBox3.Enabled = False
        Button6.Enabled = False
        TextBox4.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
    End Sub
    Private Sub unnanut()
        d5.Enabled = False
    End Sub
    Private Sub UpdateData1()
        connect()
        If GetStockID = "" Then
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
        Else
            Dim i As Integer
            i = DataGridView4.CurrentRow.Cells(5).Value
            'Dim her As Integer
            'her = DataGridView5.CurrentRow.Cells(4).Value
            Dim u As Integer
            u = t12.Text
            Dim love As Integer




            'Else
            love = i - u
                ' End If

                Try
                sql = "update Medicine set unit=@unit WHERE MID='" & GetStockID & "'"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("unit", love)
                cmd.ExecuteNonQuery()
                'cmd.Parameters.AddWithValue("priceS", love)
                ' If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                'Else
                'ShowOrder()
                ShowServiceData5()
                ' Calculate_Total()
                '    End If
            Catch ex As Exception
                ' error_message("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                With ms
                    .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                    .ShowDialog()
                End With
            End Try
        End If
    End Sub

    Private Sub b2_Click(sender As Object, e As EventArgs)
        t2.Text = ""
        t3.Text = ""
        d5.Enabled = False
        t6.Text = ""
        c8.Text = "=="

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        t11.Text = ""
        t12.Text = ""
        c14.Text = "=="
        t15.Text = ""
        t16.Text = ""
        ComboBox2.Text = "=="

        'UpdateData()
        'UpdateData2()
        'ShowServiceData5()
        'UpdateData()
    End Sub

    Private Sub UpdateData2()
        connect()
        If GetStockID = "" Then
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
        Else
            Dim i As Integer
            i = DataGridView4.CurrentRow.Cells(5).Value
            Dim her As Integer
            her = DataGridView5.CurrentRow.Cells(4).Value
            Dim u As Integer
            u = t12.Text
            Dim love As Integer
            love = (i + her) - u
            Try
                sql = "update Medicine set unit=@unit WHERE MID='" & GetStockID & "'"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("unit", love)
                cmd.ExecuteNonQuery()
                'cmd.Parameters.AddWithValue("priceS", love)
                ' If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                'Else
                'ShowOrder()
                ShowServiceData5()
                ShowServiceData4()
                ' Calculate_Total()
                '    End If
            Catch ex As Exception
                ' error_message("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                With ms
                    .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                    .ShowDialog()
                End With
            End Try
        End If
    End Sub
    Private Sub UpdateData3()
        connect()
        If GetStockID = "" Then
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
        Else
            Dim i As Integer
            i = DataGridView4.CurrentRow.Cells(5).Value
            Dim her As Integer
            her = DataGridView5.CurrentRow.Cells(4).Value
            'Dim u As Integer
            'u = t12.Text
            Dim love As Integer
            love = (i + her)
            Try
                sql = "update Medicine set unit=@unit WHERE MID='" & Label3.Text & "'"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("unit", love)
                cmd.ExecuteNonQuery()
                'cmd.Parameters.AddWithValue("priceS", love)
                ' If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                'Else
                'ShowOrder()
                ShowServiceData5()
                ShowServiceData4()
                ' Calculate_Total()
                '    End If
            Catch ex As Exception
                ' error_message("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                With ms
                    .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                    .ShowDialog()
                End With
            End Try
        End If
    End Sub

    Private Sub t2_TextChanged(sender As Object, e As EventArgs) Handles t2.TextChanged

    End Sub

    Private Sub UpdateData4()
        connect()
        If GetStockID = "" Then
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
        Else
            Dim i As Integer
            i = DataGridView4.CurrentRow.Cells(5).Value
            Dim her As Integer
            her = DataGridView5.CurrentRow.Cells(4).Value
            Dim love As Decimal = 0
            For p = 0 To DataGridView5.Rows.Count - 1
                love = love = (i + her)

                'Dim i As Integer
                'i = DataGridView4.CurrentRow.Cells(5).Value
                'Dim her As Integer
                'her = DataGridView5.CurrentRow.Cells(4).Value

                'Dim love As Integer
                'love = (i + her)
                Try
                    sql = "update Medicine set unit=@unit WHERE MID='" & GetStockID & "'"
                    cmd = New SqlClient.SqlCommand(sql, cn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("unit", love)
                    cmd.ExecuteNonQuery()
                    'cmd.Parameters.AddWithValue("priceS", love)
                    ' If cmd.ExecuteNonQuery = 0 Then
                    ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                    'Else
                    'ShowOrder()
                    ShowServiceData5()
                    ShowServiceData4()
                    ' Calculate_Total()
                    '    End If
                Catch ex As Exception
                    ' error_message("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                    With ms
                        .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                        .ShowDialog()
                    End With
                End Try
            Next
        End If

    End Sub
    Private Sub UpdateData6()
        connect()
        If GetStockID = "" Then
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
        Else
            Dim i As Integer
            i = DataGridView4.CurrentRow.Cells(5).Value
            Dim her As Integer
            her = DataGridView5.CurrentRow.Cells(4).Value
            Dim u As Integer
            u = t12.Text
            Dim love As Integer
            love = (i + her) - u
            Try
                sql = "update Medicine set unit=@unit WHERE MID='" & GetStockID & "'"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("unit", love)
                cmd.ExecuteNonQuery()
                'cmd.Parameters.AddWithValue("priceS", love)
                ' If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                'Else
                'ShowOrder()
                ShowServiceData5()
                ' Calculate_Total()
                '    End If
            Catch ex As Exception
                ' error_message("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                With ms
                    .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                    .ShowDialog()
                End With
            End Try
        End If
    End Sub
    Private Sub Updateb()
        connect()

        If GetStockID = "" Then
            With ms
                .Label2.Text = "ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ"
                .ShowDialog()
            End With
            '  error_message("ກະລຸນາເລື້ອກຂໍ້ມູນທີ່ຕ້ອງການເພີ່ມຈຳນວນ")
        Else

            Try
                Dim i As Integer
                Dim u As Integer
                Dim love As Integer
                i = t11.Text
                u = t12.Text
                love = i * u

                sql = "update MP1 set unitS=@unitS, priceS=@priceS,Mtime_ID=@Mtime_ID,unitM=@unitM,nitID=@nitID  WHERE billID='" & t9.Text.Trim &
                    "' and MID='" & GetStockID & "'"
                cmd = New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("unitS", t12.Text)
                cmd.Parameters.AddWithValue("priceS", love)
                cmd.Parameters.AddWithValue("Mtime_ID", c14.SelectedValue)
                cmd.Parameters.AddWithValue("unitS", t15.Text)
                cmd.Parameters.AddWithValue("nitID", ComboBox2.SelectedValue)
                cmd.ExecuteNonQuery()
                ' If cmd.ExecuteNonQuery = 0 Then
                ' error_message("ບໍ່ສາມາດແກ້ໄຂຂໍ້ມູນນີ້")
                'Else
                'ShowOrder()
                UpdateData6()
                ShowServiceData5()
                ' Calculate_Total()
                '    End If
            Catch ex As Exception
                ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                With ms
                    .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                    .ShowDialog()
                End With
            End Try
        End If
    End Sub
    'Private Sub IDFly2()
    '    connect()
    '    sql = "Select * FROM View_billdetail WHERE billID='" & t9.Text.Trim &
    '        "' and MID='" & GetStockID & "'"
    '    cmd = New SqlClient.SqlCommand(sql, cn)
    '    da = New SqlClient.SqlDataAdapter(cmd)
    '    ds = New DataSet
    '    da.Fill(ds, "View_billdetail")
    '    If ds.Tables("View_billdetail").Rows.Count = 0 Then
    '        Exit Sub
    '    Else
    '        With ds.Tables("View_billdetail")
    '            GetStockIDOnOrder1 = .Rows(currow)("MID")
    '            GetOrderQTT = .Rows(currow)("unitS")
    '        End With
    '    End If
    'End Sub
    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick

    End Sub

    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Dim f As String
        f = DataGridView2.CurrentRow.Cells(0).Value.ToString
        With home
            .st(finishDetail)
        End With
        With finishDetail
            .t1.Text = DataGridView2.CurrentRow.Cells(1).Value
            .TextBox1.Text = DataGridView2.CurrentRow.Cells(2).Value
            .TextBox2.Text = DataGridView2.CurrentRow.Cells(3).Value
            .Label11.Text = DataGridView2.CurrentRow.Cells(4).Value
            .TextBox3.Text = DataGridView2.CurrentRow.Cells(5).Value

            .TextBox5.Text = DataGridView2.CurrentRow.Cells(7).Value

            .TextBox4.Text = DataGridView2.CurrentRow.Cells(6).Value

            .Show()
        End With
    End Sub

    Private Sub t2_RightToLeftChanged(sender As Object, e As EventArgs) Handles t2.RightToLeftChanged


    End Sub

    Private Sub t2_KeyDown(sender As Object, e As KeyEventArgs) Handles t2.KeyDown
        If e.KeyCode = Keys.Enter Then
            t3.Focus()
        End If
    End Sub
    Private Sub t6_KeyDown(sender As Object, e As KeyEventArgs) Handles t6.KeyDown
        If e.KeyCode = Keys.Enter Then
            c8.Focus()
        End If
    End Sub
    Private Sub c8_KeyDown(sender As Object, e As KeyEventArgs) Handles c8.KeyDown
        If e.KeyCode = Keys.Enter Then
            b1.Focus()
        End If
    End Sub
    Private Sub t12_KeyDown(sender As Object, e As KeyEventArgs) Handles t12.KeyDown

        If e.KeyCode = Keys.Enter Then
            c14.Focus()
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If (TextBox3.Text.Length > 0) Then

            TextBox3.Text = Convert.ToDouble(TextBox3.Text).ToString("N0")
            TextBox3.SelectionStart = TextBox3.Text.Length
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        FilterDatacheck(TextBox2.Text)
        FormatDGVStyleStock6()

    End Sub

    Private Sub DataGridView6_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        connect()
        IDFly3()
        If (TextBox3.Text = "") Then

            With ms
                .Label2.Text = "ກະລຸນາເລືອກການກວດ"
                .ShowDialog()
            End With
        ElseIf getcheck = GetqID Then
            With ms
                .Label2.Text = "ທ່ານໄດ້ເລືອກການກວດນີ້ແລ້ວ"
                .ShowDialog()
            End With
        Else
            InsertDatacheak()
            ShowServiceData7()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()
        b8.Enabled = True
        Dim Sum As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            Sum += DataGridView7.Rows(i).Cells(2).Value
        Next
        TextBox4.Text = Sum
        Button8.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        connect()
        'addbillcheck()
        t6.Text = t9.Text

        Try
            addbillcheck()

            DataGridView7.Refresh()

            With ms
                .Label2.Text = "ການເພີ່ມການກວດພະຍາດສຳເຫຼັດ"
                .ShowDialog()
            End With
        Catch ex As Exception

            With ms
                .Label2.Text = "ການເພີ່ມການກວດພະຍາດເກີດບັນຫາບາງຢ່າງ ກະລຸນາກວດສອບຄືນ"
                .ShowDialog()
            End With
        End Try
        ShowServiceData7()
        un()
        t11.Text = ""
        t12.Text = ""
        c14.Text = "=="
        t15.Text = ""
        TextBox3.Text = ""

        ComboBox2.Text = "=="
        t16.Text = ""
        t12.Enabled = True
        c14.Enabled = True
        t15.Enabled = True
        ComboBox2.Enabled = True
        b3.Enabled = True
        b4.Enabled = True
        ' b6.Enabled = True
        Button1.Enabled = True
        't16.Enabled = True
        Button4.Enabled = True
        b8.Enabled = False
        Button12.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        connect()

        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ຫຼືບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                ' connect()
                Try
                    cmd = New SqlCommand("delete from checkprice where RID =  '" & getd & "'  And billID ='" & t9.Text.Trim &
            "'", cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                End Try

                ShowServiceData7()
                'YESorNO.Close()
                'ElseIf .bno.Text = "ຍົກເລີກ" Then
                'YESorNO.Close()

            End If
            'Return
            ShowServiceData7()

        End With
    End Sub

    Private Sub DataGridView7_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView7.CellContentClick

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        Button8.Enabled = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Button7.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button6.Enabled = True
        Button12.Enabled = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        t11.Enabled = True
        t12.Enabled = True
        c14.Enabled = True
        t15.Enabled = True
        ComboBox2.Enabled = True
        b3.Enabled = True
        b4.Enabled = True
        ' b6.Enabled = False
        Button1.Enabled = True
        't16.Enabled = False

        Button4.Enabled = True
        Button11.Enabled = False
    End Sub

    Private Sub c14_KeyDown(sender As Object, e As KeyEventArgs) Handles c14.KeyDown
        If e.KeyCode = Keys.Enter Then
            t15.Focus()
        End If

    End Sub
    Private Sub t15_KeyDown(sender As Object, e As KeyEventArgs) Handles t15.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub t11_TextChanged(sender As Object, e As EventArgs) Handles t11.TextChanged
        If (t11.Text.Length > 0) Then

            t11.Text = Convert.ToDouble(t11.Text).ToString("N0")
            t11.SelectionStart = t11.Text.Length
        End If
    End Sub

    Private Sub t16_TextChanged(sender As Object, e As EventArgs) Handles t16.TextChanged
        If (t16.Text.Length > 0) Then

            t16.Text = Convert.ToDouble(t16.Text).ToString("N0")
            t16.SelectionStart = t16.Text.Length
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If (TextBox4.Text.Length > 0) Then

            TextBox4.Text = Convert.ToDouble(TextBox4.Text).ToString("N0")
            TextBox4.SelectionStart = TextBox4.Text.Length
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            b3.Focus()
        End If
    End Sub
    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Enter Then
            b8.Focus()
        End If
    End Sub

    Private Sub t15_TextChanged(sender As Object, e As EventArgs) Handles t15.TextChanged

    End Sub

    Private Sub DataGridView1_ControlAdded(sender As Object, e As ControlEventArgs) Handles DataGridView1.ControlAdded

    End Sub

    Private Sub DataGridView6_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellClick
        Dim i As Integer = DataGridView6.CurrentRow.Index
        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        Else
            With DataGridView6
                getcheck = DataGridView6.Item(0, i).Value
                TextBox3.Text = DataGridView6.Item(2, i).Value
            End With
        End If
        ' IDFly2()
        IDFly3()
        't11.Text = DataGridView4.Item(4, i).Value
        Button7.Focus()
    End Sub
    Private Sub IDFly3()
        connect()
        sql = "Select * FROM checkprice WHERE RID='" & getcheck & "' and billID='" & t9.Text.Trim &
            "'"
        cmd = New SqlClient.SqlCommand(sql, cn)
        da = New SqlClient.SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "checkprice")
        If ds.Tables("checkprice").Rows.Count = 0 Then
            Exit Sub
        Else
            With ds.Tables("checkprice")
                GetqID = .Rows(currow)("RID")

            End With
        End If
    End Sub

    Private Sub DataGridView7_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView7.CellClick
        Dim i As Integer = DataGridView7.CurrentRow.Index
        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        Else
            With DataGridView7
                getd = DataGridView7.Item(3, i).Value

            End With
        End If
    End Sub

    Private Sub t12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t12.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Enter) Then
            ' MessageBox.Show("ສາມາດປ້ອນພຽງຕົວເລກເທົ່ານັ້ນ", "ການແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With ms
                .Label2.Text = "ສາມາດປ້ອນພຽງຕົວເລກເທົ່ານັ້ນ"
                .ShowDialog()
            End With
            e.Handled = True
        End If

    End Sub

    Private Sub DataGridView4_CausesValidationChanged(sender As Object, e As EventArgs) Handles DataGridView4.CausesValidationChanged

    End Sub

    Private Sub t12_Move(sender As Object, e As EventArgs) Handles t12.Move

    End Sub

    Private Sub t12_MouseMove(sender As Object, e As MouseEventArgs) Handles t12.MouseMove

    End Sub

    Private Sub t15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t15.KeyPress
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