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
Public Class reportbill
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT As String
    Dim y As String
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
    Sub showdatatoday()
        sql = "select * from View_billreport where date='" & Date.Now.ToString("yyyy-MM-dd") & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billreport")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_billreport"
        FormatDGVStyleStock()
    End Sub
    Sub showdatatodaych()
        sql = "select * from View_checkpay where date='" & Date.Now.ToString("yyyy-MM-dd") & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_checkpay")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_checkpay"
        Formatcheack()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Label3.Text = "day"
        showdatatoday()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        Label3.Text = "thismonth"

        showdatathismoth()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        Label3.Text = Date.Now.Year
        showdatathisyear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        connect()
        Label3.Text = "tt"
        ShowServiceData()
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_billreport WHERE month like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        FormatDGVStyleStock()

    End Sub
    Public Sub FilterDatach(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_checkpay WHERE month like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView2.DataSource = table
        Formatcheack()

    End Sub
    Public Sub FilterData2(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_billreport WHERE year like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        FormatDGVStyleStock()

    End Sub
    Public Sub FilterDatach2(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_checkpay WHERE year like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView2.DataSource = table
        Formatcheack()

    End Sub
    Private Sub t22_TextChanged(sender As Object, e As EventArgs) Handles t22.TextChanged
        FilterData2(t22.Text)

    End Sub

    Private Sub c14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles c14.SelectedIndexChanged
        FilterData(c14.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()
        Try
            If Label3.Text = "ok" Then
                printmonth()
            ElseIf Label3.Text = "day" Then
                printday()
            ElseIf Label3.Text = "thismonth" Then
                printthismonth()
            ElseIf Label3.Text = "okk" Then
                printyear()

            ElseIf Label3.Text = Label3.text Then
                printthisyear()
            End If
            c14.Text = ""
            Label3.Text = ""
            t22.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Sub printday()
        connect()
        Dim c As New CrystalReport10

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_billreport where date='" & Date.Now.ToString("yyyy-MM-dd") & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printdaych()
        connect()
        Dim c As New CrystalReport15

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where date='" & Date.Now.ToString("yyyy-MM-dd") & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printthismonth()
        connect()
        Dim c As New CrystalReport11

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_billreport where month(date)='" & Date.Now.Month & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printthismonthch()
        connect()
        Dim c As New CrystalReport16

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where month(date)='" & Date.Now.Month & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub print()
        connect()
        Dim c As New CrystalReport13

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_billreport where year='" & Label5.Text & "' "
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printch()
        connect()
        Dim c As New CrystalReport18

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where year='" & Label7.Text & "' "
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printthisyear()
        connect()
        Dim c As New CrystalReport12
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_billreport where year='" & Label3.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printthisyearch()
        connect()
        Dim c As New CrystalReport17
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where year='" & Label9.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printyear()
        connect()
        Dim c As New CrystalReport12
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_billreport where year='" & t22.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printyearch()
        connect()
        Dim c As New CrystalReport17
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where year='" & TextBox1.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printmonth()
        connect()
        Dim c As New CrystalReport11

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_billreport where month='" & c14.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub
    Sub printmonthch()
        connect()
        Dim c As New CrystalReport16

        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where month='" & ComboBox1.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")
            c.SetDataSource(ds)
            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With

    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        Try
            Label5.Text = Date.Now.Year

            print()
        Catch ex As Exception
        End Try
    End Sub

    Sub showdatathismoth()
        sql = "Select * from View_billreport where month(date)='" & Date.Now.Month & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billreport")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_billreport"
        FormatDGVStyleStock()
    End Sub
    Sub showdatathismothch()
        sql = "Select * from View_checkpay where month(date)='" & Date.Now.Month & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_checkpay")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_checkpay"
        Formatcheack()
    End Sub
    Sub showdatathisyear()
        sql = "select * from View_billreport where year(date)='" & Date.Now.Year & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billreport")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_billreport"
        FormatDGVStyleStock()
    End Sub
    Sub showdatathisyearch()
        sql = "select * from View_checkpay where year(date)='" & Date.Now.Year & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_checkpay")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_checkpay"
        Formatcheack()
    End Sub
    Private Sub ShowServiceData()
        sql = "select * from View_billreport"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billreport")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_billreport"
        FormatDGVStyleStock()
    End Sub
    Private Sub FormatDGVStyleStock()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດໃບບິນ"
            .Columns(1).HeaderText = "ຊື່ບິນຢາ"
            .Columns(2).HeaderText = "ຈຳນວນ"
            .Columns(3).HeaderText = "ຫົວໜ່ວຍ"
            .Columns(4).HeaderText = "ລາຄາ"
            .Columns(5).HeaderText = "ລວມລາຄາ"
            .Columns(6).HeaderText = "ປະເພດ"
            .Columns(7).HeaderText = "ວັນເດືອນປີ"
            .Columns(8).HeaderText = "ເດືອນ"
            .Columns(9).HeaderText = "ປີ"
            .Columns(10).HeaderText = "ລະຫັດຢາ"
            '.Columns(11).HeaderText = "ປີ"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(5).DefaultCellStyle.Format = "N2"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        connect()
        Label9.Text = "day"
        showdatatodaych()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        connect()
        Label9.Text = "thismonth"

        showdatathismothch()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        connect()
        Label9.Text = Date.Now.Year
        showdatathisyearch()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        connect()
        Try
            If Label9.Text = "ok" Then
                printmonthch()
            ElseIf Label9.Text = "day" Then
                printdaych()
            ElseIf Label9.Text = "thismonth" Then
                printthismonthch()
            ElseIf Label9.Text = "okk" Then
                printyearch()

            ElseIf Label9.Text = Label9.Text Then
                printthisyearch()
            End If
        Catch ex As Exception
        End Try
        ComboBox1.Text = ""
        Label9.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        FilterDatach(ComboBox1.Text)
    End Sub

    Private Sub Formatcheack()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView2
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດບິນ"
            .Columns(1).HeaderText = "ຊື່ກວດ"
            .Columns(2).HeaderText = "ຊື່ລາຄາ"
            .Columns(3).HeaderText = "ວັນເດືອນປີ"
            .Columns(4).HeaderText = "ເດືອນ"
            .Columns(5).HeaderText = "ປີ"
            .Columns(6).HeaderText = "ລະຫັດການກວດ"
            .Columns(2).DefaultCellStyle.Format = "N2"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterDatach2(TextBox1.Text)

    End Sub

    Private Sub reportbill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        showdatatoday()
        showdatatodaych()
        ShowServiceData()
        showdatathisyear()
        showdatathismoth()
        showdatathismothch()
        showdatathisyearch()
        Formatcheack()
        FormatDGVStyleStock()
        'AddHandler Button1.Click, AddressOf MyClickHandler
        'AddHandler Button2.Click, AddressOf MyClickHandler
        'AddHandler Button6.Click, AddressOf MyClickHandler
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        Try
            Label7.Text = Date.Now.Year

            printch()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        connect()
        Try
            printtodaysum()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub c14_ParentChanged(sender As Object, e As EventArgs) Handles c14.ParentChanged

    End Sub

    Private Sub c14_MouseClick(sender As Object, e As MouseEventArgs) Handles c14.MouseClick
        Label3.Text = "ok"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        connect()
        Try
            printthismonthsum()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub t22_MouseClick(sender As Object, e As MouseEventArgs) Handles t22.MouseClick
        Label3.Text = "okk"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        connect()
        Try
            printmonthsum()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        Label9.Text = "ok"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        connect()
        Try
            printthisyearsum()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        Label9.Text = "okk"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        connect()
        Try
            printyearsum()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub MyClickHandler(sender As Object, e As EventArgs)
    '    ' Throw New NotImplementedException()
    '    Dim frm As Form = CType(sender, Button).Parent

    '    Select Case CType(sender, Button).Name
    '        Case "Button1"

    '            If frm.Name = "Button6" Then

    '                printday()

    '            End If

    '        Case "Button2"

    '            If frm.Name = "Button6" Then

    '                printthismonth()

    '            End If

    '    End Select
    'End Sub
    Sub printtodaysum()
        connect()
        Dim c As New CrystalReport19
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where date='" & Date.Now.ToString("yyyy-MM-dd") & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")


            .CommandText = "select * from View_billreport where date='" & Date.Now.ToString("yyyy-MM-dd") & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")


            .CommandText = "select * from View_billsum where date='" & Date.Now.ToString("yyyy-MM-dd") & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billsum")

            c.SetDataSource(ds)

            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
    End Sub
    Sub printthismonthsum()
        connect()
        Dim c As New CrystalReport20
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where month(date)='" & Date.Now.Month & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")


            .CommandText = "select * from View_billreport where month(date)='" & Date.Now.Month & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")


            .CommandText = "select * from View_billsum where month(date)='" & Date.Now.Month & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billsum")

            c.SetDataSource(ds)

            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
    End Sub
    Sub printmonthsum()
        connect()
        Dim c As New CrystalReport20
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where month='" & ComboBox2.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")


            .CommandText = "select * from View_billreport where month='" & ComboBox2.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")


            .CommandText = "select * from View_billsum where month='" & ComboBox2.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billsum")

            c.SetDataSource(ds)

            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
    End Sub
    Sub printthisyearsum()
        connect()
        Dim c As New CrystalReport21
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where year(date)='" & Date.Now.Year & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")


            .CommandText = "select * from View_billreport where year(date)='" & Date.Now.Year & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")


            .CommandText = "select * from View_billsum where year(date)='" & Date.Now.Year & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billsum")

            c.SetDataSource(ds)

            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
    End Sub
    Sub printyearsum()
        connect()
        Dim c As New CrystalReport21
        Dim r As New report
        cmd = New SqlCommand
        da = New SqlDataAdapter
        ds = New DataSet
        With cmd
            ds.Clear()
            .Connection = cn
            .CommandText = "select * from View_checkpay where year='" & TextBox2.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_checkpay")


            .CommandText = "select * from View_billreport where year='" & TextBox2.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billreport")


            .CommandText = "select * from View_billsum where year='" & TextBox2.Text & "'"
            .CommandType = CommandType.Text
            .Parameters.Clear()
            da.SelectCommand = cmd
            da.Fill(ds, "View_billsum")

            c.SetDataSource(ds)

            report.CrystalReportViewer1.ReportSource = c
            report.CrystalReportViewer1.Refresh()
            report.Show()
        End With
    End Sub
End Class