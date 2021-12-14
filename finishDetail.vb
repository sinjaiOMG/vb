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
Public Class finishDetail
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT As String

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        FilterData(TextBox3.Text)
        FilterData2(TextBox3.Text)
    End Sub

    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            MsgBox("Can't Connect")
        End Try
    End Sub

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        With home
            .st(general_service)
        End With
    End Sub

    Private Sub ShowServiceData5()
        connect()
        'where billID ='" & t9.Text & "'
        sql = "select * from View_billdetail  where billID='" & TextBox3.Text & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_billdetail")
        DataGridView3.DataSource = ds
        DataGridView3.DataMember = "View_billdetail"
        FormatDGVStyleStock5()
    End Sub
    Private Sub FormatDGVStyleStock5()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView3
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


            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub finishDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        ShowServiceData5()
        ShowServiceData7()
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_billdetail WHERE billID like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView3.DataSource = table

    End Sub
    Public Sub FilterData2(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_checkprices WHERE billID like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    Private Sub ShowServiceData7()
        connect()
        sql = "select * from View_checkprices where billID='" & TextBox3.Text & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_checkprices")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_checkprices"
        FormatDGVStyleStock7()
    End Sub
    Private Sub FormatDGVStyleStock7()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
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
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown

    End Sub
End Class