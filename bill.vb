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

Public Class bill
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT As String

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            MsgBox("Can't Connect")
        End Try
    End Sub
    Private Sub ShowServiceData1()
        connect()
        sql = "select * from View_billnotpay"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billnotpay")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_billnotpay"
        FormatDGVStyleStock1()
    End Sub
    Private Sub FormatDGVStyleStock1()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
            .Columns(1).HeaderText = "ຊື່ສັດ"
            .Columns(2).HeaderText = "ຊື່ເຈົ້າຂອງ"
            .Columns(3).HeaderText = "ໝາຍເຫດ"
            .Columns(4).HeaderText = "ລວມລາຄາ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub ShowServiceData2()
        connect()
        sql = "select name,Expr1,Expr2,PriceF,unitS,Expr3,priceS,Expr4,unitM,Expr5,billID from View_billprint where billID='" & TextBox1.Text & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billprint")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_billprint"
        FormatDGVStyleStock2()
    End Sub
    Private Sub ShowServiceData3()
        connect()
        sql = "select * from View_checkprices where billID='" & TextBox1.Text & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_checkprices")
        DataGridView3.DataSource = ds
        DataGridView3.DataMember = "View_checkprices"
        FormatDGVStyleStock7()
    End Sub
    Private Sub FormatDGVStyleStock7()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView3
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        print()
        'addbill3()
        With home
            .st(confirm)
        End With
    End Sub
    Public Sub addbill3()
        'connect()
        'Try
        '    sql = "update Bill set statut=@statut  WHERE billID='" & Label5.Text.Trim & "'"
        '    cmd = New SqlClient.SqlCommand(sql, cn)
        '    cmd.Parameters.Clear()
        '    cmd.Parameters.AddWithValue("statut", "ຈ່າຍແລ້ວ")

        '    'cmd.ExecuteNonQuery()
        '    'sql = "update Bill set sum = '" & t16.Text & "',statut = N'ຍັງບໍ່ທັນຈ່າຍ' WHERE billID = '" & t9.Text & "'"
        '    'cmd = New SqlCommand(sql, cn)
        '    cmd.ExecuteNonQuery()

        'Catch ex As Exception
        '    ' MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        '    With ms
        '        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
        '        .ShowDialog()
        '    End With
        'End Try
        FormatDGVStyleStock7()
    End Sub
    Sub print()
        connect()
        Dim c As New CrystalReport2
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkprices where billID='" & TextBox1.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkprices")


            .CommandText = "select * from View_billprint where billID='" & TextBox1.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billprint")


            .CommandText = "select * from Bill where billID='" & TextBox1.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "Bill")

            c.SetDataSource(ds)

            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
        'With cmd
        '    ds.Clear()
        '    .Connection = cn
        '    .CommandText = "select * from View_checkprices where billID='" & TextBox1.Text & "'"
        '    .CommandType = CommandType.Text
        '    .Parameters.Clear()
        '    da.SelectCommand = cmd
        '    da.Fill(ds, "View_checkprices")
        '    c.SetDataSource(ds)
        '    report.CrystalReportViewer1.ReportSource = c
        '    report.CrystalReportViewer1.Refresh()
        '    report.Show()
        'End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub t10_TextChanged(sender As Object, e As EventArgs) Handles t10.TextChanged
        FilterData2(t10.Text)
    End Sub

    Private Sub FormatDGVStyleStock2()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView2
            .ColumnHeadersDefaultCellStyle = cs
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
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub bill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' View_billnotpay
        connect()
        ShowServiceData2()
        ShowServiceData1()
        ShowServiceData3()
        FormatDGVStyleStock2()
        FormatDGVStyleStock7()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterData(TextBox1.Text)
        FilterData3(TextBox1.Text)
        FormatDGVStyleStock2()
        FormatDGVStyleStock7()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If (TextBox3.Text.Length > 0) Then

            TextBox3.Text = Convert.ToDouble(TextBox3.Text).ToString("N0")
            TextBox3.SelectionStart = TextBox3.Text.Length
        End If
    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT name,Expr1,Expr2,PriceF,unitS,Expr3,priceS,Expr4,unitM,Expr5,billID FROM View_billprint WHERE billID like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        'where billID='" & Label5.Text & "'
        adapter.Fill(table)

        DataGridView2.DataSource = table
        'FormatDGVStyleStock2()
    End Sub
    Public Sub FilterData3(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_checkprices WHERE billID like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        'where billID='" & Label5.Text & "'
        adapter.Fill(table)

        DataGridView3.DataSource = table

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        Else
            With DataGridView1

                ' GetStockID = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
                Label4.Text = DataGridView1.Item(0, i).Value
                'Label5.Text = DataGridView1.Item(5, i).Value
                TextBox3.Text = DataGridView1.Item(4, i).Value
                'GetStockID = DataGridView1.Item(5, i).Value
                TextBox1.Text = DataGridView1.Item(5, i).Value
                With confirm
                    .TextBox3.Text = DataGridView1.Item(4, i).Value
                    .Label8.Text = DataGridView1.Item(5, i).Value
                End With
            End With
        End If
    End Sub
    Public Sub FilterData2(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_billnotpay WHERE TRID1 like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    Private Sub Label5_TextChanged(sender As Object, e As EventArgs) Handles Label5.TextChanged
        'FilterData(Label5.Text)
        'FilterData3(Label5.Text)
        ' FormatDGVStyleStock2()
        'FormatDGVStyleStock7()
    End Sub
End Class