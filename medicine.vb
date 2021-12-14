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
Public Class medicine
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetSaleID, save As String
    Dim a As Integer

    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            'ງMsgBox("Can't Connect")
            With ms
                .Label2.Text = "ບໍ່ສາມາດເຊື່ອມຕໍ່ໄດ້"
                .ShowDialog()
            End With
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value
        TextBox3.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        ComboBox2.Text = DataGridView1.Item(3, i).Value
        TextBox6.Text = DataGridView1.Item(5, i).Value

        ComboBox3.Text = DataGridView1.Item(6, i).Value
        'ComboBox3.Text = DataGridView1.Item(7, i).Value
        TextBox5.Text = DataGridView1.Item(4, i).Value
        Button2.Enabled = True
        Button3.Enabled = True

        Button1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        a = TextBox5.Text
        If (TextBox2.Text = "" And TextBox3.Text = "" And TextBox5.Text = "" And ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text = "" And TextBox6.Text = "") Then
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
        ElseIf TextBox5.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        ElseIf ComboBox1.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        ElseIf ComboBox2.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        ElseIf ComboBox3.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With
        ElseIf TextBox6.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With

        Else

            Try
                sql = "insert into Medicine values(N'" & TextBox2.Text & "', N'" & TextBox3.Text & "',  
                        N'" & ComboBox1.SelectedValue & "', N'" & ComboBox2.SelectedValue & "',
             N'" & TextBox6.Text & "', N'" & a & "', N'" & ComboBox3.SelectedValue & "')"
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

                'messageboxss.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
            Catch ex As Exception
                With ms
                    .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                    .ShowDialog()
                End With
                ' messageboxss.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
            End Try
            AutoID()
            ShowServiceData()
        End If
        ' TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox6.Text = ""

        TextBox5.Text = ""
        ComboBox2.Text = "ເລືອກສາຂາ"
        ComboBox1.Text = "ເລືອກສາຂາ"
        ComboBox3.Text = "ເລືອກສາຂາ"
    End Sub
    Private Sub ShowServiceData()
        connect()
        sql = "select * from View_m"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_m")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_m"
        FormatDGVStyleStock()
    End Sub
    Private Sub FormatDGVStyleStock()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດຢາ"
            .Columns(1).HeaderText = "ຊື່ຢາ"
            .Columns(2).HeaderText = "ຊະນິດຢາ"
            .Columns(3).HeaderText = "ປະເພດຢາ"

            .Columns(4).HeaderText = "ລາຄາ"
            .Columns(5).HeaderText = "ຈຳນວນ"
            .Columns(6).HeaderText = "ຫົວໜ່ວຍ"
            .Columns(4).DefaultCellStyle.Format = "N2"

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

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        a = TextBox5.Text
        Try
            sql = "update Medicine set name = N'" & TextBox3.Text & "',MTID = N'" & ComboBox1.SelectedValue & "',MDID = N'" & ComboBox2.SelectedValue & "',unit = N'" & TextBox6.Text & "',PriceF = N'" & a & "',UID = N'" & ComboBox3.SelectedValue & "' WHERE MID = N'" & TextBox2.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            With ms
                .Label2.Text = "ບໍ່ສາມາດອັບເດດໄດ້"
                .ShowDialog()
            End With
            'messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        AutoID()
        ShowServiceData()
        'TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox6.Text = ""

        TextBox5.Text = ""
        ComboBox1.Text = "ເລືອກສາຂາ"
        ComboBox2.Text = "ເລືອກສາຂາ"
        ComboBox3.Text = "ເລືອກສາຂາ"
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບໜ້ານີ້ຫຼືບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    sql = "Delete from Medicine where MID = '" & (TextBox2.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ບໍ່ສາມາດລົບໄດ້"
                        .ShowDialog()
                    End With
                    '   messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                End Try
            End If

        End With
        AutoID()
        ShowServiceData()
        'TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox6.Text = ""
        Button2.Enabled = False
        Button3.Enabled = False

        TextBox5.Text = ""
        ComboBox1.Text = "ເລືອກ"
        ComboBox2.Text = "ເລືອກ"
        ComboBox3.Text = "ເລືອກ"
        Button1.Enabled = True
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

    Sub Msg_ok(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_m WHERE CONCAT(MID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
        FormatDGVStyleStock()
    End Sub
    'Public Sub load()
    '    connect()
    '    sql = "select * from Medicine  "
    '    da = New SqlDataAdapter(sql, cn)
    '    ds = New DataSet
    '    da.Fill(ds, "table")
    '    DataGridView1.DataSource = ds.Tables("table")
    'End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub
    Dim GetStockIDOnSale As String
    Dim charnum_ID As String
    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(MID) from Medicine"
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
    Private Sub medicine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        connect()
        AutoID()
        ShowServiceData()
        ' load()
        FilterData("")
        course_combo()
        ' ShowSatus()
        courses_combo()
        coursesss_combo()
        FormatDGVStyleStock()
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        End If
    End Sub

    'Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        TextBox5.Focus()
    '    End If
    'End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox3.Focus()
        End If
    End Sub

    'Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Button1.Focus()
    '    End If
    'End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox5.Focus()
        End If
    End Sub
    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub
    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub course_combo()
        Dim sql As String = "Select*from MD"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "MD")
        ComboBox2.DataSource = ds.Tables("MD")
        ComboBox2.DisplayMember = "name"
        ComboBox2.ValueMember = "MDID"
        ' ComboBox2.Text = "ເລືອກຊະນິດ"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If (TextBox5.Text.Length > 0) Then

            TextBox5.Text = Convert.ToDouble(TextBox5.Text).ToString("N0")
            TextBox5.SelectionStart = TextBox5.Text.Length
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub courses_combo()
        Dim sql As String = "Select*from Medicine_Type"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "Medicine_Type")
        ComboBox1.DataSource = ds.Tables("Medicine_Type")
        ComboBox1.DisplayMember = "name"
        ComboBox1.ValueMember = "MTID"
        ' ComboBox1.Text = "ເລືອກປະເພດ
        '"
    End Sub
    Private Sub coursesss_combo()
        Dim sql As String = "Select*from unit"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "unit")
        ComboBox3.DataSource = ds.Tables("unit")
        ComboBox3.DisplayMember = "name"
        ComboBox3.ValueMember = "UID"
        ComboBox3.Text = "ເລືອກຫົວໜ່ວຍ"
    End Sub
    'Public Sub FilterDatatyp(valueToSearch As String)
    '    Dim searchQuery As String = "SELECT * FROM Medicine_Type WHERE CONCAT(MTID,name) like N'%" & valueToSearch & "%' "
    '    Dim command As New SqlCommand(searchQuery, cn)
    '    Dim adapter As New SqlDataAdapter(command)
    '    Dim table As New DataTable()

    '    adapter.Fill(table)

    '    ComboBox1.DataSource = table
    '    FormatDGVStyleStock()
    'End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        'FilterDatatyp(ComboBox1.Text)
    End Sub
End Class