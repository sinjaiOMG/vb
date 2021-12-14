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
Public Class confirm
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT As String

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'Dim i As Integer = (TextBox3.Text)
        'Dim u As Integer = (TextBox1.Text)
        'Dim k As Integer

        'k = u - i
        'TextBox2.Text = k
        If TextBox1.Text <> "" And TextBox3.Text <> "" Then
            TextBox2.Text = (CDbl(TextBox1.Text) - CDbl(TextBox3.Text)).ToString
        ElseIf TextBox1.Text = "" Then
            TextBox2.Text = ""

        End If
        If (TextBox1.Text.Length > 0) Then

            TextBox1.Text = Convert.ToDouble(TextBox1.Text).ToString("N0")
            TextBox1.SelectionStart = TextBox1.Text.Length
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text.Length > 0) Then

            TextBox2.Text = Convert.ToDouble(TextBox2.Text).ToString("N0")
            TextBox2.SelectionStart = TextBox2.Text.Length
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If (TextBox3.Text.Length > 0) Then

            TextBox3.Text = Convert.ToDouble(TextBox3.Text).ToString("N0")
            TextBox3.SelectionStart = TextBox3.Text.Length
        End If
    End Sub

    Private Sub confirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Enabled = False
    End Sub

    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            MsgBox("Can't Connect")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Try
            sql = "update Bill set statut=@statut  WHERE billID='" & Label8.Text.Trim & "'"
            cmd = New SqlClient.SqlCommand(Sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("statut", "ຈ່າຍແລ້ວ")

            'cmd.ExecuteNonQuery()
            'sql = "update Bill set sum = '" & t16.Text & "',statut = N'ຍັງບໍ່ທັນຈ່າຍ' WHERE billID = '" & t9.Text & "'"
            'cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            With ms
                .Label2.Text = "ສຳເລັດການຈ່າຍເງິນ"
                .ShowDialog()
            End With
        Catch ex As Exception
            ' MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
        End Try
        With home
            .st(bill)
        End With
        With bill
            .TextBox3.Text = ""
            .TextBox1.Text = ""
        End With
        With bill
            connect()
            sql = "select * from View_billnotpay"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_billnotpay")
            .DataGridView1.DataSource = ds
            .DataGridView1.DataMember = "View_billnotpay"

        End With
        With bill
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
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
        End With
        With bill
            connect()
            sql = "select name,Expr1,Expr2,PriceF,unitS,Expr3,priceS,Expr4,unitM,Expr5,billID from View_billprint where billID='" & .TextBox1.Text & "' "
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_billprint")
            .DataGridView2.DataSource = ds
            .DataGridView2.DataMember = "View_billprint"
        End With
        With bill
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView2
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
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With

        End With
        With bill
            connect()
            sql = "select * from View_checkprices where billID='" & .TextBox1.Text & "'"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_checkprices")
            .DataGridView3.DataSource = ds
            .DataGridView3.DataMember = "View_checkprices"
        End With
        With bill
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView3
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
        End With
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter

    End Sub

    Private Sub TextBox1_TabStopChanged(sender As Object, e As EventArgs) Handles TextBox1.TabStopChanged

    End Sub
End Class