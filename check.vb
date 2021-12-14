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
Public Class check
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetTRID, save, GetStockIDOnOrder1, GetOrderQTT, getcheck, GetqID, getd As String
    Dim a As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        a = TextBox4.Text
        If (TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "") Then
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
        ElseIf TextBox4.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        Else
            Try
                sql = "insert into RPrice values(N'" & TextBox2.Text & "',N'" & TextBox3.Text & "',N'" & a & "')"
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
            AutoID()
            ShowServiceData7()
        End If
        ' TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        a = TextBox4.Text
        Try
            sql = "update RPrice set name = N'" & TextBox3.Text & "',price = N'" & a & "' WHERE RID = N'" & TextBox2.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
        End Try
        ShowServiceData7()
        AutoID()
        ' TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()

        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ຫຼືບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    sql = "Delete from RPrice where RID = '" & (TextBox2.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With


                End Try
                ShowServiceData7()
                ' TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                AutoID()
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
            End If

        End With

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Dim o As Integer

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterData(TextBox1.Text)
    End Sub

    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            MsgBox("Can't Connect")
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If (TextBox4.Text.Length > 0) Then

            TextBox4.Text = Convert.ToDouble(TextBox4.Text).ToString("N0")
            TextBox4.SelectionStart = TextBox4.Text.Length
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub check_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        AutoID()
        ShowServiceData7()
        TextBox2.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub
    Dim charnum_ID As String
    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(RID) from RPrice"
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
                ' MessageBox.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                TextBox2.Text = ""
            End If
        Catch ex As Exception
            TextBox2.Text = "1"
        End Try
        ShowServiceData7()
        'ShowServiceData4()
    End Sub
    Private Sub ShowServiceData7()
        connect()
        sql = "select * from RPrice "
        da = New SqlClient.SqlDataAdapter(Sql, cn)
        ds = New DataSet
        da.Fill(ds, "RPrice")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "RPrice"
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
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM RPrice WHERE CONCAT(RID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        FormatDGVStyleStock7()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value
        TextBox3.Text = DataGridView1.Item(1, i).Value
        TextBox4.Text = DataGridView1.Item(2, i).Value
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub
End Class