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
Public Class pet
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Dim GetSupplierID, GetStockID, GetqID, save As String

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        'Dim i As Integer = DataGridView1.CurrentRow.Index
        'With DataGridView1
        '    t1.Text = DataGridView1.Item(0, i).Value
        '    t2.Text = DataGridView1.Item(1, i).Value
        '    t3.Text = DataGridView1.Item(2, i).Value
        '    t4.Text = DataGridView1.Item(3, i).Value
        '    t5.Text = DataGridView1.Item(4, i).Value
        '    t6.Text = DataGridView1.Item(5, i).Value
        '    t18.Text = DataGridView1.Item(0, i).Value
        'End With
    End Sub
    Private Sub DataGridView2_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        'Dim i As Integer = DataGridView2.CurrentRow.Index
        't8.Text = DataGridView2.Item(0, i).Value
        't9.Text = DataGridView2.Item(1, i).Value
        'c10.Text = DataGridView2.Item(2, i).Value
        'c11.Text = DataGridView2.Item(3, i).Value
        'ComboBox1.Text = DataGridView2.Item(4, i).Value
        't12.Text = DataGridView2.Item(5, i).Value
        'c13.Text = DataGridView2.Item(6, i).Value
        't14.Text = DataGridView2.Item(7, i).Value

        't15.Text = DataGridView2.Item(8, i).Value
        't16.Text = DataGridView2.Item(9, i).Value
        't17.Text = DataGridView2.Item(10, i).Value
        't18.Text = DataGridView2.Item(11, i).Value
    End Sub
    'Private Sub DataGridView3_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView3.CellMouseClick
    '    Dim i As Integer = DataGridView3.CurrentRow.Index
    '    't8.Text = DataGridView3.Item(0, i).Value
    '    't9.Text = DataGridView3.Item(1, i).Value
    '    'c10.Text = DataGridView3.Item(2, i).Value
    '    'c11.Text = DataGridView3.Item(3, i).Value
    '    'ComboBox1.Text = DataGridView3.Item(4, i).Value
    '    't12.Text = DataGridView3.Item(5, i).Value
    '    'c13.Text = DataGridView3.Item(6, i).Value
    '    't14.Text = DataGridView3.Item(7, i).Value

    '    't15.Text = DataGridView3.Item(8, i).Value
    '    't16.Text = DataGridView3.Item(9, i).Value
    '    't17.Text = DataGridView3.Item(10, i).Value
    '    't18.Text = DataGridView3.Item(11, i).Value
    'End Sub
    Private Sub DataGridView4_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView4.CellMouseClick
        Dim i As Integer = DataGridView4.CurrentRow.Index
        't8.Text = DataGridView3.Item(0, i).Value
        't9.Text = DataGridView3.Item(1, i).Value
        'c10.Text = DataGridView3.Item(2, i).Value
        'c11.Text = DataGridView3.Item(3, i).Value
        'ComboBox1.Text = DataGridView3.Item(4, i).Value
        't12.Text = DataGridView3.Item(5, i).Value
        'c13.Text = DataGridView3.Item(6, i).Value
        't14.Text = DataGridView3.Item(7, i).Value

        't15.Text = DataGridView3.Item(8, i).Value
        't16.Text = DataGridView3.Item(9, i).Value
        't17.Text = DataGridView3.Item(10, i).Value
        't18.Text = DataGridView3.Item(11, i).Value
        b8.Enabled = True
    End Sub
    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        connect()
        If (t1.Text = "" And t2.Text = "" And t3.Text = "" And t4.Text = "") Then
            'Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")
            'With ms
            '    .Label2.Text = "ກະລຸນາປ້ອນຂໍ້ມູນ"
            '    .ShowDialog()
            'End With
        ElseIf t2.Text = "" Then
            With ms
                .Label2.Text = "ກະລຸນາຊື່ເຈົ້າຂອງ"
                .ShowDialog()
            End With
        ElseIf t4.Text = "" Then
            't4.Text = "Null"
            'With ms
            '    .Label2.Text = "ກະລຸນາເບີໂທຕິດຕໍ່"
            '    .ShowDialog()
            'End With
        ElseIf t3.Text = "" Then
            't3.Text = "Null"
        ElseIf t5.Text = "" Then
            't5.Text = "Null"
        ElseIf t6.Text = "" Then
            't6.Text = "Null"
        Else
            'Try
            sql = "insert into Owner values(N'" & t1.Text & "', N'" & t2.Text & "',  
                         N'" & t3.Text & "', N'" & t4.Text & "', N'" & t5.Text & "', N'" & t6.Text & "')"
            cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()


            'With ms
            '.Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
            '        .ShowDialog()
            '    End With
            'End Try

            ' ShowServiceData()
            AutoID5()
            ShowServiceData()
        End If
        't1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""

    End Sub
    Private Sub b4_Click(sender As Object, e As EventArgs) Handles b4.Click
        connect()
        If (t8.Text = "" And t9.Text = "" And c10.Text = "" And c11.Text = "" And t12.Text = "" And c13.Text = "" And t14.Text = "" And t15.Text = "" And t16.Text = "" And t17.Text = "" And t18.Text = "") Then
            Msg_error("ກະລຸນາປ້ອນຂໍ້ມູນ")

        Else
            Try
                sql = "insert into Pet values(N'" & t8.Text & "', N'" & t9.Text & "',  
                         N'" & c10.SelectedValue & "', N'" & c11.SelectedValue & "', N'" & ComboBox1.Text & "',
                         N'" & t12.Text & "', N'" & c13.Text & "', N'" & t14.Text & "', N'" & t15.Text & "', N'" & t16.Text & "',
                         N'" & t17.Text & "', N'" & t18.Text & "')"
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

                '    MessageBox.Show("ບັນທຶກຂໍ້ມູນສຳເລັດ")
            Catch ex As Exception
                'MessageBox.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ")
                With ms
                    .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນຈາກລະຫັດທີ່ຊ້ຳກັນ"
                    .ShowDialog()
                End With
            End Try
            AutoID3()
            ShowServiceData2()
            ShowServiceData3()
        End If
        'ງt8.Text = ""
        t9.Text = ""
        c10.Text = ""
        c11.Text = ""
        t12.Text = ""
        c13.Text = ""
        t14.Text = ""
        t15.Text = ""
        t16.Text = ""
        t17.Text = ""
        t18.Text = ""
        ComboBox1.Text = ""
    End Sub
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            'ງMsgBox("Can't Connect")
            With ms
                .Label2.Text = "ບໍ່ສາມາດເຊື່ອມຕໍ່ຖານຂໍ້ມູນ"
                .ShowDialog()
            End With
        End Try
    End Sub
    Private Sub ShowServiceData()
        connect()
        sql = "select * from Owner"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "Owner")
        DataGridView6.DataSource = ds
        DataGridView6.DataMember = "Owner"
        FormatDGVStyleStock6()
    End Sub
    Private Sub ShowServiceData2()
        connect()
        sql = "select * from View_pet"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_pet")
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "View_pet"
        FormatDGVStyleStock1()
    End Sub

    Private Sub ShowServiceData3()
        connect()
        sql = "select * from View_pet"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_pet")
        DataGridView3.DataSource = ds
        DataGridView3.DataMember = "View_pet"
        FormatDGVStyleStock3()
        Refresh()

        With DataGridView3

        End With
    End Sub
    Private Sub ShowServiceData4()
        connect()
        sql = "select QID,name from View_q"
        da = New SqlClient.SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "View_q")
        DataGridView4.DataSource = ds
        DataGridView4.DataMember = "View_q"
        FormatDGVStyleStock4()
    End Sub
    Private Sub b3_Click(sender As Object, e As EventArgs) Handles b3.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    sql = "Delete from Owner where OWNID = '" & (t1.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                    ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                End Try
                '   messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")

            End If

        End With

        connect()

        ShowServiceData()
        AutoID5()
        '  t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        b3.Enabled = False
        b2.Enabled = False
        b1.Enabled = True
    End Sub
    Private Sub b6_Click(sender As Object, e As EventArgs) Handles b6.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    sql = "Delete from Pet where PetID = '" & (t8.Text) & "'"
                    cmd = New SqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                        .ShowDialog()
                    End With
                    ' messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
                End Try

            End If

        End With

        connect()

        ShowServiceData2()
        AutoID3()
        ' t8.Text = ""
        t9.Text = ""
        c10.Text = ""
        c11.Text = ""
        t12.Text = ""
        c13.Text = ""
        t14.Text = ""
        t15.Text = ""
        t16.Text = ""
        t17.Text = ""
        t18.Text = ""
        ComboBox1.Text = ""
        b4.Enabled = True
        b5.Enabled = False
        b6.Enabled = False
    End Sub
    Function confirm(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function

    Sub Msg_error(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbCritical + vbOKOnly, title)
    End Sub

    Private Sub t7_TextChanged(sender As Object, e As EventArgs) Handles t7.TextChanged
        'FilterData(t7.Text)
    End Sub
    Private Sub t19_TextChanged(sender As Object, e As EventArgs) Handles t19.TextChanged
        'FilterData2(t19.Text)
        FilterData2(t19.Text)
        FormatDGVStyleStock1()
    End Sub
    Private Sub t20_TextChanged(sender As Object, e As EventArgs) Handles t20.TextChanged
        'FilterData3(t20.Text)
        FilterData3(t20.Text)
        FormatDGVStyleStock3()
    End Sub
    Private Sub t22_TextChanged(sender As Object, e As EventArgs) Handles t22.TextChanged
        'FilterData4(t22.Text)
        FilterData4(t22.Text)
        FormatDGVStyleStock4()
    End Sub
    Sub Msg_ok(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM Owner WHERE CONCAT(name,tel) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView6.DataSource = table

    End Sub
    Public Sub FilterData2(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_pet WHERE CONCAT(PetID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView2.DataSource = table
    End Sub

    Public Sub FilterData3(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM View_pet WHERE CONCAT(PetID,name,owner) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView3.DataSource = table

    End Sub
    Public Sub FilterData4(valueToSearch As String)
        Dim searchQuery As String = "SELECT QID,name FROM View_q WHERE CONCAT(QID,name) like N'%" & valueToSearch & "%' "
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView4.DataSource = table

    End Sub

    'Private Sub FormatDGVStyleStock()
    '    Dim cs As New DataGridViewCellStyle
    '    cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
    '    With DataGridView6
    '        .ColumnHeadersDefaultCellStyle = cs
    '        .Columns(0).HeaderText = "ລະ​ຫັດ"
    '        .Columns(1).HeaderText = "ຊື່"
    '        .Columns(2).HeaderText = "ທີ່ຢູ່"
    '        .Columns(3).HeaderText = "ເບີໂທ"
    '        .Columns(4).HeaderText = "ອີເມວ"
    '        .Columns(5).HeaderText = "ວອດແອັບ"
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
    '        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
    '        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
    '        .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    End With

    'End Sub
    Private Sub FormatDGVStyleStock6()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView6
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະ​ຫັດ"
            .Columns(1).HeaderText = "ຊື່"
            .Columns(2).HeaderText = "ທີ່ຢູ່"
            .Columns(3).HeaderText = "ເບີໂທ"
            .Columns(4).HeaderText = "ອີເມວ"
            .Columns(5).HeaderText = "ວອດແອັບ"
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

    End Sub
    Private Sub FormatDGVStyleStock1()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView2
            .ColumnHeadersDefaultCellStyle = cs
            .Columns(0).HeaderText = "ລະ​ຫັດສັດລ້ຽງ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ປະເພດສັດ"
            .Columns(3).HeaderText = "ສາຍພັນ"
            .Columns(4).HeaderText = "ສີຂົນ"
            .Columns(5).HeaderText = "ອາຍຸ"
            .Columns(6).HeaderText = "ການເຮັດໝັນ"
            .Columns(7).HeaderText = "​ໄລຍະເຈັບ"
            .Columns(8).HeaderText = "ນ້ຳໜັກ"
            .Columns(9).HeaderText = "ປະຫວັດພະຍາດທີ່ເຄີຍເປັນ"
            .Columns(10).HeaderText = "​ອາການເບື້ອງຕົ້ນ"
            .Columns(11).HeaderText = "ເຈົ້າຂອງ"
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
            .Columns(0).HeaderText = "ລະ​ຫັດສັດລ້ຽງ"
            .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
            .Columns(2).HeaderText = "ປະເພດສັດ"
            .Columns(3).HeaderText = "ສາຍພັນ"
            .Columns(4).HeaderText = "ສີຂົນ"
            .Columns(5).HeaderText = "ອາຍຸ"
            .Columns(6).HeaderText = "ການເຮັດໝັນ"
            .Columns(7).HeaderText = "​ໄລຍະເຈັບ"
            .Columns(8).HeaderText = "ນ້ຳໜັກ"
            .Columns(9).HeaderText = "ປະຫວັດພະຍາດທີ່ເຄີຍເປັນ"
            .Columns(10).HeaderText = "​ອາການເບື້ອງຕົ້ນ"
            .Columns(11).HeaderText = "ເຈົ້າຂອງ"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

    End Sub
    Private Sub FormatDGVStyleStock4()
        Dim cs As New DataGridViewCellStyle
        cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
        With DataGridView4
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
    Private Sub pet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t1.Enabled = False
        t8.Enabled = False
        t21.Enabled = False
        t18.Enabled = False
        b2.Enabled = False
        b3.Enabled = False
        b7.Enabled = False
        b8.Enabled = False

        b5.Enabled = False
        b6.Enabled = False
        AutoID5()
        AutoID3()
        'FormatDGVStyleStock()
        connect()
        AutoID()
        ShowServiceData()
        ShowServiceData2()
        ShowServiceData3()
        ShowServiceData4()
        'load()
        'load2()
        FilterData("")
        'FilterData2("")
        'FilterData3("")
        'FilterData4("")
        course_combo()
        courses_combo()
        Course_Combook()
        t21.Enabled = False
    End Sub

    Private Sub t1_KeyDown(sender As Object, e As KeyEventArgs) Handles t1.KeyDown
        If e.KeyCode = Keys.Enter Then
            t2.Focus()
        End If
    End Sub

    Private Sub t2_TextChanged(sender As Object, e As EventArgs) Handles t2.TextChanged

    End Sub

    Private Sub t2_KeyDown(sender As Object, e As KeyEventArgs) Handles t2.KeyDown
        If e.KeyCode = Keys.Enter Then
            t3.Focus()
        End If
    End Sub

    Private Sub t3_KeyDown(sender As Object, e As KeyEventArgs) Handles t3.KeyDown
        If e.KeyCode = Keys.Enter Then
            t4.Focus()
        End If
    End Sub

    Private Sub t4_KeyDown(sender As Object, e As KeyEventArgs) Handles t4.KeyDown
        If e.KeyCode = Keys.Enter Then
            t5.Focus()
        End If
    End Sub

    Private Sub t5_KeyDown(sender As Object, e As KeyEventArgs) Handles t5.KeyDown
        If e.KeyCode = Keys.Enter Then
            t6.Focus()
        End If
    End Sub

    Private Sub t6_KeyDown(sender As Object, e As KeyEventArgs) Handles t6.KeyDown
        If e.KeyCode = Keys.Enter Then
            b1.Focus()
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles t9.TextChanged

    End Sub
    'Public Sub load()
    '    connect()
    '    sql = "select * from Owner"
    '    da = New SqlDataAdapter(sql, cn)
    '    ds = New DataSet
    '    da.Fill(ds, "table")
    '    DataGridView1.DataSource = ds.Tables("table")
    'End Sub
    '    Public Sub load2()
    '        connect()
    '        sql = "select * from Pet"
    '        da = New SqlDataAdapter(sql, cn)
    '        ds = New DataSet
    '        da.Fill(ds, "table")
    '        DataGridView2.DataSource = ds.Tables("table
    '")
    ' End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles b2.Click
        connect()
        Try
            sql = "update Owner set name = N'" & t2.Text & "',address = N'" & t3.Text & "',tel = N'" & t4.Text & "',email = N'" & t5.Text & "',whatsapp = N'" & t6.Text & "' WHERE OWNID = N'" & t1.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
            'messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        ShowServiceData()
        ' t1.Text = ""
        AutoID5()
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        b3.Enabled = False
        b2.Enabled = False
        b1.Enabled = True
    End Sub

    Private Sub t8_KeyDown(sender As Object, e As KeyEventArgs) Handles t8.KeyDown
        If e.KeyCode = Keys.Enter Then
            t9.Focus()
        End If
    End Sub
    Private Sub t9_KeyDown(sender As Object, e As KeyEventArgs) Handles t9.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub
    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            c10.Focus()
        End If
    End Sub
    Private Sub c10_KeyDown(sender As Object, e As KeyEventArgs) Handles c10.KeyDown
        If e.KeyCode = Keys.Enter Then
            c11.Focus()
        End If
    End Sub
    Private Sub c11_KeyDown(sender As Object, e As KeyEventArgs) Handles c11.KeyDown
        If e.KeyCode = Keys.Enter Then
            t12.Focus()
        End If
    End Sub
    Private Sub t12_KeyDown(sender As Object, e As KeyEventArgs) Handles t12.KeyDown
        If e.KeyCode = Keys.Enter Then
            c13.Focus()
        End If
    End Sub
    Private Sub c13_KeyDown(sender As Object, e As KeyEventArgs) Handles c13.KeyDown
        If e.KeyCode = Keys.Enter Then
            t14.Focus()
        End If
    End Sub
    Private Sub t14_KeyDown(sender As Object, e As KeyEventArgs) Handles t14.KeyDown
        If e.KeyCode = Keys.Enter Then
            t15.Focus()
        End If
    End Sub
    Private Sub t15_KeyDown(sender As Object, e As KeyEventArgs) Handles t15.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        End If
    End Sub
    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            t16.Focus()
        End If
    End Sub
    Private Sub t16_KeyDown(sender As Object, e As KeyEventArgs) Handles t16.KeyDown
        If e.KeyCode = Keys.Enter Then
            t17.Focus()
        End If
    End Sub
    Private Sub t17_KeyDown(sender As Object, e As KeyEventArgs) Handles t17.KeyDown
        If e.KeyCode = Keys.Enter Then
            t18.Focus()
        End If
    End Sub
    Private Sub t18_KeyDown(sender As Object, e As KeyEventArgs) Handles t18.KeyDown
        If e.KeyCode = Keys.Enter Then
            b4.Focus()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i As Integer = DataGridView2.CurrentRow.Index
        t8.Text = DataGridView2.Item(0, i).Value
        t9.Text = DataGridView2.Item(1, i).Value
        ComboBox2.Text = DataGridView2.Item(2, i).Value
        c10.Text = DataGridView2.Item(3, i).Value
        c11.Text = DataGridView2.Item(4, i).Value
        ComboBox1.Text = DataGridView2.Item(5, i).Value
        t12.Text = DataGridView2.Item(6, i).Value
        c13.Text = DataGridView2.Item(7, i).Value
        t14.Text = DataGridView2.Item(8, i).Value

        t15.Text = DataGridView2.Item(9, i).Value
        t16.Text = DataGridView2.Item(10, i).Value
        t17.Text = DataGridView2.Item(11, i).Value
        t18.Text = DataGridView2.Item(12, i).Value
        b4.Enabled = False
        b5.Enabled = True
        b6.Enabled = True
    End Sub

    Private Sub b5_Click(sender As Object, e As EventArgs) Handles b5.Click
        connect()
        'PetID, Name, Bid, CID, age, Desexing, Disease_duration, Raising_time, medical_history, symptom, OWNID
        Try
            sql = "update Pet set name = N'" & t9.Text & "',Bid = N'" & c10.SelectedValue & "',CID = N'" & c11.SelectedValue & "',gender = N'" & ComboBox1.Text & "',age = N'" & t12.Text & "',Desexing = N'" & c13.Text & "',Disease_duration = N'" & t14.Text &
                    "',Raising_time = N'" & t15.Text & "',medical_history = N'" & t16.Text & "', symptom = N'" & t17.Text & "' WHERE PetID = N'" & t8.Text & "'"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ"
                .ShowDialog()
            End With
            messageboxss.Show("ເກີດຄວາມບໍ່ຖືກຕ້ອງລະຫວ່າງດຳເນີນການ")
        End Try
        ShowServiceData2()
        ' t8.Text = ""
        AutoID3()
        t9.Text = ""
        c10.Text = ""
        c11.Text = ""
        t12.Text = ""
        c13.Text = ""
        t14.Text = ""
        t15.Text = ""
        t16.Text = ""
        t17.Text = ""
        t18.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        b4.Enabled = True
        b5.Enabled = False
        b6.Enabled = False
    End Sub
    Private Sub course_combo()
        Dim sql As String = "Select*from Breed where GID = '" & ComboBox2.SelectedValue & "'"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "Breed")
        c10.DataSource = ds.Tables("Breed")
        c10.DisplayMember = "name"
        c10.ValueMember = "BID"
        c10.Text = "ເລືອກສາຍພັນ"

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub courses_combo()
        Dim sql As String = "Select*from Color"
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "Color")
        c11.DataSource = ds.Tables("Color")
        c11.DisplayMember = "name"
        c11.ValueMember = "CID"
        c11.Text = "ເລືອກສີຂົນ"
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
        course_combo()
    End Sub

    Private Sub b7_Click(sender As Object, e As EventArgs) Handles b7.Click
        connect()
        IDFly2()

        If GetStockID = GetqID Then
            With ms
                .Label2.Text = "ບໍ່ສາມາດເພີ່ມຄິວຈາກສັດລ້ຽງທີ່ຊ້ຳກັນ"
                .ShowDialog()
            End With

            ' messageboxss.Show("ບໍ່ສາມາດເພີ່ມຄິວຈາກສັດລ້ຽງທີ່ຊ້ຳກັນ")

        Else
            Try
                sql = "insert into q values(@QID,@PetID)"
                cmd.Parameters.Clear()
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("QID", (t21.Text))
                cmd.Parameters.AddWithValue("PetID", GetStockID)
                cmd.ExecuteNonQuery()
                ShowServiceData4()
                AutoID()
            Catch ex As Exception
                With ms
                    .Label2.Text = "ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນ"
                    .ShowDialog()
                End With
                '   messageboxss.Show("ທ່ານບໍ່ສາມາດບັນທຶກຂໍ້ມູນ! ເນື່ອງ​ຈາກຂໍ້​ມູນ​ບໍ່​ຖືກ​ຕ້ອງກະ​ລຸ​ນາ​ກວດ​ສອບ​ຂໍ້​ມູນ")
            End Try
        End If
        With general_service
            ShowServiceData2()
            ShowServiceData3()
            AutoID()
            b7.Enabled = False
        End With
    End Sub
    Private Sub DataGridView3_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView3.CellMouseClick


        Dim i As Integer = DataGridView3.CurrentRow.Index
        GetStockID = DataGridView3.Item(0, i).Value
        'GetqID = DataGridView3.Item(0, i).Value
        'If (e.RowIndex < 0) Then
        '    Exit Sub
        'Else
        '    With DataGridView3
        '        GetStockID = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
        '    End With

        '    StockIDForCompare()
        'End If
        b7.Enabled = True

    End Sub
    Private Sub StockIDForCompare()
        connect()
        sql = "Select * FROM q WHERE QID='" & t21.Text &
            "' and PetID='" & GetStockID & "'"
        cmd = New SqlClient.SqlCommand(sql, cn)
        da = New SqlClient.SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "q")
        If ds.Tables("q").Rows.Count = 0 Then
            Exit Sub
        Else
            With ds.Tables("q")
                GetStockIDOnSale = .Rows(currow)("PetID")
            End With
        End If
    End Sub
    Dim GetStockIDOnSale As String
    Dim charnum_ID As String
    Dim currow As Integer
    Private Sub AutoID()
        sql = "Select max(QID) from q"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            t21.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                t21.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                t21.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                t21.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                ' messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                t21.Text = ""
            End If
        Catch ex As Exception
            t21.Text = "000001"
        End Try
        ShowServiceData4()
    End Sub

    'Private Sub AutoID2()
    '    sql = "Select max(OWNID)from Owner"
    '    cmd = New SqlCommand(sql, cn)
    '    Try
    '        charnum_ID = cmd.ExecuteScalar + 1
    '        t1.Text = charnum_ID
    '        If charnum_ID > 0 And charnum_ID < 10 Then
    '            t1.Text = "00000" & charnum_ID
    '        ElseIf charnum_ID > 10 And charnum_ID < 100 Then
    '            t1.Text = "0000" & charnum_ID
    '        ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
    '            t1.Text = "000" & charnum_ID
    '        ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
    '            MessageBox.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
    '            t1.Text = ""
    '        End If
    '    Catch ex As Exception
    '        t1.Text = "000001"
    '    End Try
    '    ShowServiceData()
    'End Sub
    Private Sub AutoID5()
        sql = "Select max(OWNID) from Owner"
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
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                '  messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                t1.Text = ""
            End If
        Catch ex As Exception
            t1.Text = "000001"
        End Try
        ShowServiceData()
    End Sub
    Private Sub AutoID3()
        sql = "Select max(PetID) from Pet"
        cmd = New SqlCommand(sql, cn)
        Try
            charnum_ID = cmd.ExecuteScalar + 1
            t8.Text = charnum_ID
            If charnum_ID > 0 And charnum_ID < 10 Then
                t8.Text = "00000" & charnum_ID
            ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                t8.Text = "0000" & charnum_ID
            ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                t8.Text = "000" & charnum_ID
            ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                With ms
                    .Label2.Text = "ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ"
                    .ShowDialog()
                End With
                '  messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                t8.Text = ""
            End If
        Catch ex As Exception
            t8.Text = "000001"
        End Try
        ShowServiceData2()
    End Sub
    Private Sub Course_Combook()
        Dim sql As String = "Select * from pettype "
        Dim cmd As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        cmd.Fill(ds, "pettype")
        ComboBox2.DataSource = ds.Tables("pettype")
        ComboBox2.DisplayMember = "name"
        ComboBox2.ValueMember = "GID"
        'ComboBox1.Text = "==== ເລືອກ ====="
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub b8_Click(sender As Object, e As EventArgs) Handles b8.Click
        Try
            Dim i As Integer = DataGridView4.CurrentRow.Index
            Dim u As String
            With YESorNO
                .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການນີ້ບໍ່"
                .ShowDialog()
                If .Label4.Text = "ຢືນຢັນ" Then

                    u = DataGridView4.Item(0, i).Value

                    connect()
                    Try
                        cmd = New SqlCommand("delete from q where QID =  '" & u & "'", cn)
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        With ms
                            .Label2.Text = "ເກີດຂໍ້ຜິດພາດໃນການດຳເນີນວຽກ"
                            .ShowDialog()
                        End With
                    End Try
                End If
                b8.Enabled = False
            End With
        Catch ex As Exception
            With ms
                .Label2.Text = "ເກີດຂໍ້ຜິດພາດໃນການດຳເນີນວຽກ"
                .ShowDialog()
            End With
        End Try

        connect()

        ' UpdateData3()
        ShowServiceData4()
        AutoID()
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        Dim i As Integer = DataGridView4.CurrentRow.Index
        ' GetqID = DataGridView4.Item(1, i).Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການລົບລາຍການທັງໝົດຫຼືນີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Try
                    cmd = New SqlCommand("delete from q ", cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    With ms
                        .Label2.Text = "ເກີດຂໍ້ຜິດພາດໃນການດຳເນີນວຽກ"
                        .ShowDialog()
                    End With
                End Try
            End If

        End With
        connect()

        'UpdateData4()
        ShowServiceData4()
        AutoID()
    End Sub
    Private Sub IDFly2()
        connect()
        sql = "Select * FROM q WHERE PetID='" & GetStockID & "'"
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
    Private Sub t20_KeyDown(sender As Object, e As KeyEventArgs) Handles t20.KeyDown
        'FilterData3(t20.Text)
        'FormatDGVStyleStock6()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView6_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick

    End Sub


    Private Sub t22_KeyDown(sender As Object, e As KeyEventArgs) Handles t22.KeyDown
        'FilterData4(t22.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterData(TextBox1.Text)
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub t19_KeyDown(sender As Object, e As KeyEventArgs) Handles t19.KeyDown
        'FilterData2(t19.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        With DataGridView1
            t1.Text = DataGridView1.Item(0, i).Value
            t2.Text = DataGridView1.Item(1, i).Value
            t3.Text = DataGridView1.Item(2, i).Value
            t4.Text = DataGridView1.Item(3, i).Value
            t5.Text = DataGridView1.Item(4, i).Value
            t6.Text = DataGridView1.Item(5, i).Value
            t18.Text = DataGridView1.Item(0, i).Value
        End With
    End Sub

    Private Sub DataGridView6_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellClick
        Dim i As Integer = DataGridView6.CurrentRow.Index
        With DataGridView6
            t1.Text = DataGridView6.Item(0, i).Value
            t2.Text = DataGridView6.Item(1, i).Value
            t3.Text = DataGridView6.Item(2, i).Value
            t4.Text = DataGridView6.Item(3, i).Value
            t5.Text = DataGridView6.Item(4, i).Value
            t6.Text = DataGridView6.Item(5, i).Value
            t18.Text = DataGridView6.Item(0, i).Value
            b1.Enabled = False
            b2.Enabled = True
            b3.Enabled = True
        End With
    End Sub

    Private Sub t19_ReadOnlyChanged(sender As Object, e As EventArgs) Handles t19.ReadOnlyChanged

    End Sub

    Private Sub DataGridView3_BindingContextChanged(sender As Object, e As EventArgs) Handles DataGridView3.BindingContextChanged

    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick

    End Sub
End Class