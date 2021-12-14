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
Public Class appoint
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT, GetqID As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showdatatoday()
    End Sub
    Sub showdatatoday()
        connect()
        'FilterDataph(TextBox2.Text)
        If (TextBox2.Text = "") Then

            sql = "select * from View_appoint where appoint='" & Date.Now.ToString("yyyy-MM-dd") & "' "
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appoint")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appoint"
            FormatDGVStyleStock()
        Else

            connect()
        sql = "select * from View_appoint where Expr1=N'" & TextBox2.Text & "'  AND appoint='" & Date.Now.ToString("yyyy-MM-dd") & "' "
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_appoint")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_appoint"
        FormatDGVStyleStock()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        showdatathismoth()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShowServiceData()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        showdatathismoth()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        showdatathisyear()
    End Sub

    Sub showdatathismoth()

        connect()
        If (TextBox2.Text = "") Then
            sql = "Select * from View_appoint where month(appoint)='" & Date.Now.Month & "'"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appoint")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appoint"
            FormatDGVStyleStock()
        Else
            sql = "Select * from View_appoint where Expr1=N'" & TextBox2.Text & "'  AND  month(appoint)='" & Date.Now.Month & "'"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_appoint")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_appoint"
        FormatDGVStyleStock()
        End If
    End Sub

    Private Sub c14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles c14.SelectedIndexChanged
        FilterData(c14.Text)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_appoint WHERE month  like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    Public Sub FilterDataph(valueToSearch As String)
        Dim searchQuery As String = "Select * 
                                  from View_appoint WHERE Expr1  like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub

    Sub showdatathisyear()

        connect()
        If (TextBox2.Text = "") Then
            sql = "select * from View_appoint where year(appoint)='" & Date.Now.Year & "'"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appoint")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appoint"
            FormatDGVStyleStock()
        Else
            sql = "select * from View_appoint where Expr1=N'" & TextBox2.Text & "'  AND year(appoint)='" & Date.Now.Year & "'"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appoint")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appoint"
            FormatDGVStyleStock()
        End If

    End Sub
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
    Private Sub ShowServiceData()
        connect()
        If (TextBox2.Text = "") Then
            sql = "select * from View_appoint"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appoint")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appoint"
            FormatDGVStyleStock()
        Else
            sql = "select * from View_appoint where Expr1=N'" & TextBox2.Text & "'"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appoint")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appoint"
            FormatDGVStyleStock()
        End If

    End Sub
    Private Sub FormatDGVStyleStock()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ຊື່ເຈົ້າຂອງ"
            .Columns(3).HeaderText = "ເບີໂທລະສັບ"
            .Columns(4).HeaderText = "WhatsApp"
            .Columns(5).HeaderText = "ວັນນັດໝາຍ"
            .Columns(6).HeaderText = "ຫມາຍເຫດ"
            .Columns(7).HeaderText = "ເດືອນ"
            .Columns(8).HeaderText = "ປີ"


            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Private Sub FormatDGVStyleStock1()

        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ຊື່ເຈົ້າຂອງ"
            .Columns(3).HeaderText = "ເບີໂທລະສັບ"
            .Columns(4).HeaderText = "WhatsApp"
            .Columns(5).HeaderText = "ວັນນັດໝາຍ"
            .Columns(6).HeaderText = "ຫມາຍເຫດ"



            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub b7_Click(sender As Object, e As EventArgs) Handles b7.Click
        connect()
        IDFly2()
        If TextBox1.Text = GetqID Then
            With ms
                .Label2.Text = "ບໍ່ສາມາດເພີ່ມຄິວຊ້ຳກັນໄດ້"
                .ShowDialog()
            End With
        Else
            addQ()
            ubsdateappoint()
            AutoID()
        End If
        b8.Enabled = False
        b7.Enabled = False
        ShowServiceData()

    End Sub

    Dim charnum_ID As String

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(QID) from q"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            t22.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                t22.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                t22.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                t22.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                ' messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                t22.Text = ""
            End If
        Catch ex As Exception
            t22.Text = "000001"
        End Try
        'ShowServiceData3()
    End Sub

    Private Sub b8_Click(sender As Object, e As EventArgs) Handles b8.Click
        connect()
        Try
            sql = "update TR2 set status=@status WHERE TRID1='" & GetStockID & "'"
            cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("status", "ບໍ່ມາຕາມນັດ")
            cmd.ExecuteNonQuery()
            'showdatathisyear()
            'ShowServiceData()
            'showdatathismoth()
            ShowServiceData()

            'showdatatoday()
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
            ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        b8.Enabled = False
        b7.Enabled = False
        AutoID()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If (TextBox2.Text = "") Then
            sql = "select * from View_appfale "
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appfale")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appfale"
            FormatDGVStyleStock1()
        Else
            sql = "select * from View_appfale where Expr1 = N'" & TextBox2.Text & "'"
            da = New SqlClient.SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "View_appfale")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "View_appfale"
            FormatDGVStyleStock1()
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ShowServiceData4()
        connect()
        sql = "select QID,name from View_q"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_q")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_q"
        FormatDGVStyleStock4()
    End Sub
    Private Sub FormatDGVStyleStock4()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView2
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ຄິວ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

    End Sub
    Private Sub appoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowServiceData()
        ShowServiceData4()
        AutoID()
        ubsdateappoint()
        c14.Text = "ເລືອກເດືອນທີ່ຕ້ອງການ"
        showdatathisyear()
        ShowServiceData()
        showdatathismoth()
        showdatatoday()
        t22.Enabled = False
        TextBox1.Enabled = False
        b8.Enabled = False
        b7.Enabled = False
    End Sub
    Private Sub addQ()
        connect()

        Try
            sql = "insert into q values(@QID,@PetID)"
            cmd.Parameters.Clear()
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("QID", (t22.Text))
            cmd.Parameters.AddWithValue("PetID", TextBox1.Text)
            cmd.ExecuteNonQuery()
            ShowServiceData4()
            ShowServiceData()
            AutoID()
        Catch ex As Exception
            ' MessageBox.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນ! ເນື່ອງ​ຈາກຂໍ້​ມູນ​ບໍ່​ຖືກ​ຕ້ອງກະ​ລຸ​ນາ​ກວດ​ສອບ​ຂໍ້​ມູນ")
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
        End Try
        With general_service
            'ShowServiceData2()
            'ShowServiceData3()

        End With
    End Sub
    Private Sub IDFly2()
        connect()
        sql = "Select * FROM q WHERE PetID='" & TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(sql, cn)
        da = New SqlClient.SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "q")
        If ds.Tables("q").Rows.Count = 0 Then
            Exit Sub
        Else
            With ds.Tables("q")
                GetqID = .Rows(currow)("PetID")

            End With
        End If
    End Sub
    Public Sub ubsdateappoint()
        connect()
        Try
            sql = "update TR2 set status=@status WHERE TRID1='" & GetStockID & "'"
            cmd = New SqlClient.SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("status", "ສຳເລັດການນັດໝາຍ")
            cmd.ExecuteNonQuery()
            'showdatathisyear()
            'ShowServiceData()
            'showdatathismoth()
            'showdatatoday()
            ShowServiceData()

        Catch ex As Exception
            'MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        'GetStockID = DataGridView1.Item(1, i).Value
        'GetTRID = DataGridView1.Item(0, i).Value

        If (e.RowIndex < 0) Then
            'PicID = ""
            Exit Sub
        Else
            With DataGridView1

                GetStockID = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
                'GetTRID = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
                'GetStockID = DataGridView1.Item(1, i).Value
                TextBox1.Text = DataGridView1.Item(9, i).Value
                b7.Enabled = True
                b8.Enabled = True
            End With
        End If
        'GetStockID = DataGridView1.Item(1, i).Value
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        'FilterDataph(TextBox2.Text)
    End Sub
End Class