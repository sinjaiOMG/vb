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
Public Class tReport
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT As String
    'Dim y As New Date
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            With ms
                .Label2.Text = "ບໍ່ສາມາດເຊື່ອມຕໍ່"
                .ShowDialog()
            End With
        End Try
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_rpTR WHERE month  like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        Label3.Text = "thismonth"
        showdatathismoth()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Label3.Text = "day"

        showdatatoday()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        connect()
        Label3.Text = Date.Now.Year
        showdatathisyear()
    End Sub

    Private Sub tReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        FilterData("")
        showdatatoday()
        showdatathisyear()
        ShowServiceData()
        showdatathismoth()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        Label3.Text = "tt"
        ShowServiceData()

    End Sub

    Private Sub c14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles c14.SelectedIndexChanged
        FilterData(c14.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()
        If Label3.Text = "ok" Then
            printmonth()
        ElseIf Label3.Text = "day" Then
            printday()
        ElseIf Label3.Text = "thismonth" Then
            printthismonth()
        ElseIf Label3.Text = "tt" Then
            print()

        ElseIf Label3.Text = Label3.Text Then
            printthisyear()

        Else
            printmonth()
        End If
        c14.Text = "=="
        Label3.Text = ""
        'Label4.Text = ""
        Label5.Text = ""
    End Sub
    Sub printday()
        connect()
        Dim c As New CrystalReport5

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_rpTR where date='" & Date.Now.ToString("yyyy-MM-dd") & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_rpTR")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printthismonth()
        connect()
        Dim c As New CrystalReport6

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_rpTR where month(date)='" & Date.Now.Month & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_rpTR")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub print()
        connect()
        Dim c As New CrystalReport8

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_rpTR "
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_rpTR")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printthisyear()
        connect()
        Dim c As New CrystalReport7
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_rpTR where year='" & Label3.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_rpTR")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
        '  Label3.Text = ""

    End Sub
    Sub printmonth()
        connect()
        Dim c As New CrystalReport6

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_rpTR where month='" & c14.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_rpTR")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub showdatatoday()
        sql = "select * from View_rpTR where date='" & Date.Now.ToString("yyyy-MM-dd") & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_rpTR")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_rpTR"
        FormatDGVStyleStock()
    End Sub
    Sub showdatathismoth()
        sql = "Select * from View_rpTR where month(date)='" & Date.Now.Month & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_rpTR")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_rpTR"
        FormatDGVStyleStock()
    End Sub
    Sub showdatathisyear()
        sql = "select * from View_rpTR where year(date)='" & Date.Now.Year & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_rpTR")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_rpTR"
        FormatDGVStyleStock()
    End Sub
    Private Sub ShowServiceData()
        sql = "select * from View_rpTR"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_rpTR")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_rpTR"
        FormatDGVStyleStock()
    End Sub

    Private Sub FormatDGVStyleStock()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ຊື່ເຈົ້າຂອງ"
            .Columns(3).HeaderText = "ວັນເດືອນປີ"
            .Columns(4).HeaderText = "ປະເພດຮັກສາ"
            .Columns(5).HeaderText = "ຜູ້ເຂົ້າລະບົບ"
            .Columns(6).HeaderText = "ຕຳແຫນ່ງ"
            .Columns(7).HeaderText = "ລະຫັດບິນຢາ"
            .Columns(8).HeaderText = "ສະຖານະບິນຢາ"
            .Columns(9).HeaderText = "ໝາຍເຫດ"
            .Columns(10).HeaderText = "ເດືອນ"
            .Columns(11).HeaderText = "ປີ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub c14_MouseClick(sender As Object, e As MouseEventArgs) Handles c14.MouseClick
        Label3.Text = "ok"
    End Sub
End Class