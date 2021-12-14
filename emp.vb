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
Public Class emp
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetSaleID, save As String
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            'MsgBox("Can't Connect")
            With ms
                .Label2.Text = "ບໍ່ສາມາດເຊື່ອມຕໍ່"
                .ShowDialog()
            End With
        End Try
    End Sub
    'Private Sub service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    connect()
    '    AutoID()
    'End Sub
    Dim charnum_ID As String
    'Private Sub AutoID()
    '    sql = "Select max(EMPID) from EMP"
    '    cmd = New SqlCommand(sql, cn)
    '    Try
    '        charnum_ID = cmd.ExecuteScalar + 1
    '        TextBox2.Text = charnum_ID
    '        If charnum_ID > 0 And charnum_ID < 10 Then
    '            TextBox2.Text = "00000" & charnum_ID
    '        ElseIf charnum_ID > 10 And charnum_ID < 100 Then
    '            TextBox2.Text = "0000" & charnum_ID
    '        ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
    '            TextBox2.Text = "000" & charnum_ID
    '        ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
    '            MessageBox.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
    '            TextBox2.Text = ""
    '        End If
    '    Catch ex As Exception
    '        TextBox2.Text = "000001"
    '    End Try
    '    ShowServiceData()
    'End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value
        TextBox3.Text = DataGridView1.Item(1, i).Value
        TextBox4.Text = DataGridView1.Item(2, i).Value
        TextBox5.Text = DataGridView1.Item(3, i).Value
        TextBox7.Text = DataGridView1.Item(4, i).Value
        TextBox8.Text = DataGridView1.Item(5, i).Value
        ComboBox2.Text = DataGridView1.Item(6, i).Value
        TextBox9.Text = DataGridView1.Item(0, i).Value
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button8.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        If (TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" And TextBox7.Text = "" And ComboBox2.Text = "") Then
            'Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
                AutoID()
            End With

        ElseIf TextBox2.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
                AutoID()
            End With

        ElseIf TextBox3.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
                AutoID()
            End With

        ElseIf TextBox4.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
                AutoID()
            End With

        ElseIf TextBox5.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
                AutoID()
            End With

        ElseIf ComboBox2.Text = "ເລືອກ" Then
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
                AutoID()
            End With

        Else
            Try
                sql = "insert into EMP values(N'" & TextBox2.Text & "', N'" & TextBox3.Text & "',  
                        N'" & TextBox4.Text & "', N'" & TextBox5.Text & "',
            N'" & TextBox7.Text & "', N'" & TextBox8.Text & "', N'" & ComboBox2.SelectedValue & "')"
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

                'MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
            Catch ex As Exception
                ' messageboxss.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
                With ms
                    .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                    .ShowDialog()
                End With
            End Try
            AutoID()
            ShowServiceData()
            FormatDGVStyleStock()
            'TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            ComboBox2.Text = "ເລືອກ"
        End If

    End Sub
    Private Sub ShowServiceData()
        connect()
        sql = "select * from View_EMP"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_EMP")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "View_EMP"
        FormatDGVStyleStock()
    End Sub
    Private Sub FormatDGVStyleStock()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView1
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະຫັດພະນັກງານ"
            .Columns(1).HeaderText = "ຊື່"
            .Columns(2).HeaderText = "ທີ່ຢູ່"
            .Columns(3).HeaderText = "ເບີໂທ"
            .Columns(4).HeaderText = "ອີເມວ"
            .Columns(5).HeaderText = "ວອດແອ໋ບ"
            .Columns(6).HeaderText = "ຕຳແໜ່ງ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    ' AutoID()
    '    TextBox3.Text = ""
    '    TextBox4.Text = ""
    '    TextBox5.Text = ""
    '    TextBox8.Text = ""
    '    TextBox7.Text = ""
    '    TextBox1.Text = ""
    '    ComboBox2.Text = "ເລືອກສາຂາ"
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        Try
            sql = "update EMP set name = N'" & TextBox3.Text & "',Address = N'" & TextBox4.Text & "',tel = N'" & TextBox5.Text & "',email = N'" & TextBox7.Text & "',whatsapp = N'" & TextBox8.Text & "',PID = N'" & ComboBox2.SelectedValue & "' WHERE EMPID = N'" & TextBox2.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
            With ms
                .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                .ShowDialog()
            End With
        End Try
        ShowServiceData()
        FormatDGVStyleStock()
        'TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = "ເລືອກ"
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
                    sql = "Delete from EMP where EMPID = '" & (TextBox2.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    'MessageBox.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                    With ms
                        .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                        .ShowDialog()
                    End With
                End Try
                ShowServiceData()
                FormatDGVStyleStock()
                ' TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                ComboBox2.Text = "ເລືອກສາຂາ"
                Button1.Enabled = True
                Button3.Enabled = False
                Button2.Enabled = False
            End If

        End With


    End Sub




    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterData(TextBox1.Text)
        FormatDGVStyleStock()
    End Sub


    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_EMP WHERE CONCAT(EMPID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub
    'Public Sub load()
    '    connect()
    '    sql = "select * from EMP  "
    '    da = New SqlDataAdapter(sql, cn)
    '    ds = New DataSet
    '    da.Fill(ds, "table")
    '    DataGridView1.DataSource = ds.Tables("table")
    'End Sub
    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox7.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox11.Focus()
        End If
    End Sub

    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckBox12.Focus()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (TextBox9.Text = "" And TextBox11.Text = "" And TextBox6.Text = "") Then
            ' Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
                .ShowDialog()
            End With

        ElseIf (TextBox9.Text = "") Then
            'Msg_error("ກະລຸນາປ້ອນລະຫັດພະນັກງານ ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນລະຫັດພະນັກງານ"
                .ShowDialog()
            End With
        ElseIf (TextBox11.Text = "") Then
            'Msg_error("ກະລຸນາປ້ອນຊື່ພະນັກງານ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນຊື່ພະນັກງານ"
                .ShowDialog()
            End With
        ElseIf (TextBox6.Text = "") Then
            ' Msg_error("ກະລຸນາປ້ອນລະຫັດຜູ້ໃຊ້ງານ")
            With ms
                .Label2.Text = "ກະລຸນາປ້ອນລະຫັດຜູ້ໃຊ້ງານ"
                .ShowDialog()
            End With
        ElseIf (CheckBox12.Checked = False And CheckBox11.Checked = False And CheckBox10.Checked = False And CheckBox9.Checked = False And CheckBox8.Checked = False And CheckBox7.Checked = False) Then
            ' Msg_error("ກະລຸນາເລືອກສິດຜູ້ໃຊ້")
            With ms
                .Label2.Text = "ກະລຸນາເລືອກສິດຜູ້ໃຊ້"
                .ShowDialog()
            End With
        Else
            connect()
            sql = "Insert into status1 values (@doctor, @customer, @appoint,@bill, @report, @databace,@username, @password, @EMPID)"
            cmd = New SqlCommand(sql, cn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("doctor", CheckBox12.Checked)
            cmd.Parameters.AddWithValue("customer", CheckBox11.Checked)
            cmd.Parameters.AddWithValue("appoint", CheckBox10.Checked)
            cmd.Parameters.AddWithValue("bill", CheckBox9.Checked)
            cmd.Parameters.AddWithValue("report", CheckBox8.Checked)
            cmd.Parameters.AddWithValue("databace", CheckBox7.Checked)

            cmd.Parameters.AddWithValue("username", TextBox11.Text)
            cmd.Parameters.AddWithValue("password", TextBox6.Text)
            cmd.Parameters.AddWithValue("EMPID", TextBox9.Text)
            If cmd.ExecuteNonQuery >= 1 Then


            Else
                With ms
                    .Label2.Text = "ບັນທຶກຂໍ້ມູນບໍ່ສໍາເລັດ"
                    .ShowDialog()
                End With
                ' Msg_error("ບັນທຶກຂໍ້ມູນບໍ່ສໍາເລັດ")
            End If
        End If
        ShowSatus()
    End Sub

    'Private Sub CheckBox12_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox12.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        CheckBox11.Focus()
    '    End If
    'End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub
    Dim GetStockIDOnSale As String

    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(EMPID) from EMP"
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
                'messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
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
    Private Sub emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        connect()
        AutoID()
        ShowServiceData()
        'Load()
        FilterData("")
        course_combo()
        ShowSatus()
        Button2.Enabled = False
        Button3.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button8.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        sql = "Update status1 set  doctor = @doctor,customer= @customer, appoint=@appoint,bill=@bill, report=@report, databace=@databace,username=@username, password=@password where EMPID = '" & TextBox9.Text & "' "
        cmd = New SqlCommand(sql, cn)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("doctor", CheckBox12.Checked)
        cmd.Parameters.AddWithValue("customer", CheckBox11.Checked)
        cmd.Parameters.AddWithValue("appoint", CheckBox10.Checked)
        cmd.Parameters.AddWithValue("bill", CheckBox9.Checked)
        cmd.Parameters.AddWithValue("report", CheckBox8.Checked)
        cmd.Parameters.AddWithValue("databace", CheckBox7.Checked)

        cmd.Parameters.AddWithValue("username", TextBox11.Text)
        cmd.Parameters.AddWithValue("password", TextBox6.Text)
        cmd.Parameters.AddWithValue("EMPID", TextBox9.Text)
        Button8.Enabled = True
        If cmd.ExecuteNonQuery >= 1 Then
            ' Msg_ok("ແກ້ໄຂຂໍ້ມູນພະນັກງານສໍາເລັດ")
        Else
            'Msg_error("ແກ້ໄຂຂໍ້ມູນບໍ່ສໍາເລັດ")
            With ms
                .Label2.Text = "ແກ້ໄຂຂໍ້ມູນບໍ່ສໍາເລັດ"
                .ShowDialog()
            End With
        End If
        TextBox9.Text = ""
        TextBox11.Text = ""
        TextBox6.Text = ""
        CheckBox12.Checked = False
        CheckBox11.Checked = False
        CheckBox10.Checked = False
        CheckBox9.Checked = False
        CheckBox8.Checked = False
        CheckBox7.Checked = False
        ShowSatus()
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub DataGridView2_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        Dim i As Integer = DataGridView2.CurrentRow.Index
        CheckBox12.Checked = DataGridView2.Item(3, i).Value
        CheckBox11.Checked = DataGridView2.Item(4, i).Value
        CheckBox10.Checked = DataGridView2.Item(5, i).Value
        CheckBox9.Checked = DataGridView2.Item(6, i).Value
        CheckBox8.Checked = DataGridView2.Item(7, i).Value
        CheckBox7.Checked = DataGridView2.Item(8, i).Value

        TextBox11.Text = DataGridView2.Item(0, i).Value
        TextBox6.Text = DataGridView2.Item(1, i).Value
        TextBox9.Text = DataGridView2.Item(9, i).Value
        Button8.Enabled = False
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        connect()

        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ຫຼືບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then

                Dim i As Integer = DataGridView2.CurrentRow.Index
                Dim Key As String = DataGridView2.Item(1, i).Value

                sql = "Delete from  status1 where EMPID = '" & TextBox9.Text & "' "
                cmd = New SqlCommand(sql, cn)
                If cmd.ExecuteNonQuery >= 1 Then

                Else
                    'Msg_error("ບໍ່ສາມາດລຶບໄດ້")
                    With ms
                        .Label2.Text = "ບໍ່ສາມາດລຶບໄດ້"
                        .ShowDialog()
                    End With
                End If

                TextBox9.Text = ""
                TextBox11.Text = ""
                TextBox6.Text = ""
                CheckBox12.Checked = False
                CheckBox11.Checked = False
                CheckBox10.Checked = False
                CheckBox9.Checked = False
                CheckBox8.Checked = False
                CheckBox7.Checked = False

                ShowSatus()
                Button8.Enabled = False
                Button6.Enabled = False
                Button5.Enabled = False
            End If

        End With


    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TextBox6_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
    'Private Function com_DataTable()
    '    save = "SELECT * FROM Position"
    '    da = New SqlDataAdapter(save, cn)
    '    ds = New DataSet
    '    da.Fill(ds, "Position")
    '    Return ds.Tables("Position")
    'End Function

    'Private Sub refresh_edit_user()
    '    save = "SELECT * FROM Position"
    '    DataGridView1.DataSource = com_DataTable()
    'End Sub
    Private Sub course_combo()
        Dim sql As String = "Select*from Position"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "Position")
        ComboBox2.DataSource = ds.Tables("Position")
        ComboBox2.DisplayMember = "name"
        ComboBox2.ValueMember = "PID"
        ComboBox2.Text = "ເລືອກ"
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub ShowSatus()
        connect()
        sql = "select * from View_sts"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_sts")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_sts"
        Formatstatus()
    End Sub
    Private Sub Formatstatus()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView2
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ຊື່ຜູ້ໃຊ້"
            .Columns(1).HeaderText = "ລະຫັດ"
            .Columns(2).HeaderText = "ຜູ້ໃຊ້"
            .Columns(3).HeaderText = "ໝໍ"
            .Columns(4).HeaderText = "ຈັດການລູກຄ້າ"
            .Columns(5).HeaderText = "ນັດໝາຍ"
            .Columns(6).HeaderText = "ຈັດການຂໍ້ມູນ"
            .Columns(7).HeaderText = "ໃບບິນ"
            .Columns(8).HeaderText = "ລາຍງານ"
            .Columns(9).HeaderText = "ລະຫັດພະນັກງານ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            ' MessageBox.Show("ສາມາດປ້ອນພຽງຕົວເລກເທົ່ານັ້ນ", "ການແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With ms
                .Label2.Text = "ສາມາດປ້ອນພຽງຕົວເລກເທົ່ານັ້ນ"
                .ShowDialog()
            End With
            e.Handled = True
        End If
    End Sub
End Class