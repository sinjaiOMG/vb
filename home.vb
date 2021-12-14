Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class home
    Dim DA As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim DS As DataSet
    Dim sql As String
    Dim cn As New SqlConnection("Data Source=DESKTOP-9M10AI4\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=True")
    Sub connect()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
        Catch ex As Exception
            ' MsgBox("Can't Connect")
            With ms
                .Label2.Text = "ບໍ່ສາມາດເຊື່ມຕໍ່ໄດ້"
                .ShowDialog()
            End With

        End Try
    End Sub
    Private Function cmd_excuteScatar()
        connect()
        cmd = New SqlCommand(sql, cn)
        Return cmd.ExecuteScalar
    End Function

    Function cmd_excuteDataTable()
        connect()
        DA = New SqlDataAdapter(sql, cn)
        DS = New DataSet
        DA.Fill(DS, "table")
        Return DS.Tables("table")
    End Function

    Function confirm(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function

    Sub Msg_error(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbCritical + vbOKOnly, title)
    End Sub

    Sub Msg_ok(text As String, Optional title As String = "ແຈ້ງເຕືອນ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub


    Private Sub DfToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton3_ButtonClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub ບນທກກມຊບສນToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        tv.Text = TimeOfDay
    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs)
        st(medicine)
    End Sub

    Private Sub ToolStripSplitButton2_ButtonClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs)

        st(mTime)

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)

        st(mCategoty)
    End Sub

    Private Sub RToolStripMenuItem_Click(sender As Object, e As EventArgs)

        st(mType)
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs)

        st(breed)
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs)

        st(color)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs)
        st(gender)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Sub st(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs)
        st(positionEMP)
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs)
        st(service)
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs)
        st(emp)
    End Sub

    Private Sub SadsadToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs)
        st(medicine)
    End Sub

    Private Sub ToolStripMenuItem32_Click(sender As Object, e As EventArgs)

        st(mTime)
    End Sub

    Private Sub ToolStripMenuItem33_Click(sender As Object, e As EventArgs)
        st(mCategoty)
    End Sub

    Private Sub ToolStripMenuItem34_Click(sender As Object, e As EventArgs)
        st(mType)
    End Sub

    Private Sub ToolStripMenuItem35_Click(sender As Object, e As EventArgs)
        st(emp)
    End Sub

    Private Sub ToolStripMenuItem36_Click(sender As Object, e As EventArgs)
        st(positionEMP)
    End Sub

    Private Sub ToolStripMenuItem37_Click(sender As Object, e As EventArgs)
        st(service)
    End Sub

    Private Sub ToolStripMenuItem30_Click(sender As Object, e As EventArgs)

        st(color)
    End Sub

    Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs)
        st(breed)
    End Sub

    Private Sub ToolStripMenuItem29_Click(sender As Object, e As EventArgs)
        st(gender)
    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem14_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem15_Click_1(sender As Object, e As EventArgs)
        st(medicine)
    End Sub

    Private Sub ToolStripMenuItem16_Click_1(sender As Object, e As EventArgs)
        st(mTime)
    End Sub

    Private Sub ToolStripMenuItem17_Click_1(sender As Object, e As EventArgs)

        st(mCategoty)
    End Sub

    Private Sub ToolStripMenuItem18_Click_1(sender As Object, e As EventArgs)
        st(mType)
    End Sub

    'Private Sub ToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem38.Click
    '    ''st(emp)
    'End Sub

    'Private Sub ToolStripMenuItem39_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem39.Click
    '    st(positionEMP)
    'End Sub

    'Private Sub ToolStripMenuItem40_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem40.Click
    '    st(service)
    'End Sub

    Private Sub ToolStripMenuItem41_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem41.Click

        st(color)
        With color
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດສີ"
                .Columns(1).HeaderText = "ສີ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem42_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem42.Click
        st(breed)
        With breed
            connect()
            sql = "select * from View_breed"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_breed")
            .DataGridView1.DataSource = DS
            .DataGridView1.DataMember = "View_breed"
        End With
        With breed
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດສາຍພັນ"
                .Columns(1).HeaderText = "ຊື່ສາຍພັນ"
                .Columns(2).HeaderText = "ປະເພດສັດ"
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem43_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem43.Click
        st(gender)
        With gender
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດປະເພດສັດ"
                .Columns(1).HeaderText = "ຊື່ປະເພດສັດ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem44_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem44.Click
        With YESorNO
            .Label2.Text = "ທ່ານຕ້ອງການອອກຈາກໜ້ານີ້ບໍ່"
            .ShowDialog()
            If .Label4.Text = "ຢືນຢັນ" Then
                Me.Close()
                Form1.Show()

                With Form1
                    .TextBox1.Focus()
                    .TextBox1.Text = ""
                    .TextBox2.Text = ""
                End With



            End If

        End With
        ' If confirm("ທ່ານຕ້ອງການອອກຈາກໂປຣແກຣມນີ້ຫຼືບໍ່?") = vbNo Then Return
        'Me.Close()


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        st(general_service)
        With general_service

            sql = "select * from View_checkprices where billID='" & .t9.Text & "'"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_checkprices")
            .DataGridView7.DataSource = DS
            .DataGridView7.DataMember = "View_checkprices"

        End With
        With general_service
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView7
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
        With general_service
            connect()
            sql = "select * from View_medicine"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_medicine")
            .DataGridView4.DataSource = DS
            .DataGridView4.DataMember = "View_medicine"
            '.ShowServiceData4()
        End With
        With general_service
            connect()
            sql = "select * from View_q"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_q")
            .DataGridView1.DataSource = DS
            .DataGridView1.DataMember = "View_q"
            ' FormatDGVStyleStock1()
        End With
        With general_service
            connect()
            sql = "select * from finished"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "finished")
            .DataGridView3.DataSource = DS
            .DataGridView3.DataMember = "finished"
            '  FormatDGVStyleStock3()
        End With
        With general_service
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView2
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດໃບຮັກສາ"
                .Columns(1).HeaderText = "ຊື່ສັດລ້ຽງ"
                .Columns(2).HeaderText = "ຜົນກວດ"
                .Columns(3).HeaderText = "ວັນເດືອນປີທີ່ມາຮັກສາ"
                .Columns(4).HeaderText = "ນັດໝາຍຄັ້ງຕໍ່ໄປ"
                .Columns(5).HeaderText = "ລະຫັດໃບບິນ"
                .Columns(6).HeaderText = "ໝໍທີ່ຮັກສາ"
                .Columns(7).HeaderText = "ປະເພດການຮັກສາ"
                .Columns(8).HeaderText = "ໝາຍເຫດ"
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click

    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel3.Click

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel6.Click

    End Sub

    Private Sub ToolStripStatusLabel5_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel5.Click

    End Sub

    Private Sub t_Click(sender As Object, e As EventArgs) Handles t.Click

    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click

    End Sub

    Private Sub tv_Click(sender As Object, e As EventArgs) Handles tv.Click

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        st(pet)
        With pet
            connect()
            sql = "select QID,name from View_q"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_q")
            .DataGridView4.DataSource = DS
            .DataGridView4.DataMember = "View_q"
            '  FormatDGVStyleStock4()
        End With
        With pet
            Dim charnum_ID As String
            ' Dim currow As Integer
            sql = "Select max(OWNID)from Owner"
            cmd = New SqlCommand(sql, cn)
            Try
                charnum_ID = cmd.ExecuteScalar + 1
                .t1.Text = charnum_ID
                If charnum_ID > 0 And charnum_ID < 10 Then
                    .t1.Text = "00000" & charnum_ID
                ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                    .t1.Text = "0000" & charnum_ID
                ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                    .t1.Text = "000" & charnum_ID
                ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                    'messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                    .t1.Text = ""
                End If
            Catch ex As Exception
                .t1.Text = "000001"
            End Try
            ' ShowServiceData()
        End With
        With pet
            connect()
            sql = "select * from View_pet"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_pet")
            .DataGridView3.DataSource = DS
            .DataGridView3.DataMember = "View_pet"
            ' FormatDGVStyleStock3()
        End With
        With pet
            Dim charnum_ID As String
            sql = "Select max(PetID) from Pet"
            cmd = New SqlCommand(sql, cn)
            Try
                charnum_ID = cmd.ExecuteScalar + 1
                .t8.Text = charnum_ID
                If charnum_ID > 0 And charnum_ID < 10 Then
                    .t8.Text = "00000" & charnum_ID
                ElseIf charnum_ID > 10 And charnum_ID < 100 Then
                    .t8.Text = "0000" & charnum_ID
                ElseIf charnum_ID > 100 And charnum_ID < 1000 Then
                    .t8.Text = "000" & charnum_ID
                ElseIf charnum_ID > 1000 And charnum_ID < 10000 Then
                    ' messageboxss.Show("ຂໍ້ມູນໃບບິນເຕັມຈຳນວນແລ້ວ", "ຜົນການດຳເນີນການ")
                    .t8.Text = ""
                End If
            Catch ex As Exception
                .t8.Text = "000001"
            End Try
        End With
        With pet
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView6
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
        End With
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        st(appoint
           )
        With appoint
            If (.TextBox2.Text = "") Then

                sql = "select * from View_appoint where appoint='" & Date.Now.ToString("yyyy-MM-dd") & "' "
                DA = New SqlClient.SqlDataAdapter(sql, cn)
                DS = New DataSet
                DA.Fill(DS, "View_appoint")
                .DataGridView1.DataSource = DS
                .DataGridView1.DataMember = "View_appoint"
                ' FormatDGVStyleStock()
            Else

                connect()
                sql = "select * from View_appoint where Expr1=N'" & .TextBox2.Text & "'  AND appoint='" & Date.Now.ToString("yyyy-MM-dd") & "' "
                DA = New SqlClient.SqlDataAdapter(sql, cn)
                DS = New DataSet
                DA.Fill(DS, "View_appoint")
                .DataGridView1.DataSource = DS
                .DataGridView1.DataMember = "View_appoint"
                '.FormatDGVStyleStock()
            End If

        End With
        With appoint
            connect()
            If (.TextBox2.Text = "") Then
                sql = "Select * from View_appoint where month(appoint)='" & Date.Now.Month & "'"
                DA = New SqlClient.SqlDataAdapter(sql, cn)
                DS = New DataSet
                DA.Fill(DS, "View_appoint")
                .DataGridView1.DataSource = DS
                .DataGridView1.DataMember = "View_appoint"
                ' FormatDGVStyleStock()
            Else
                sql = "Select * from View_appoint where Expr1=N'" & .TextBox2.Text & "'  AND  month(appoint)='" & Date.Now.Month & "'"
                DA = New SqlClient.SqlDataAdapter(sql, cn)
                DS = New DataSet
                DA.Fill(DS, "View_appoint")
                .DataGridView1.DataSource = DS
                .DataGridView1.DataMember = "View_appoint"
                ' FormatDGVStyleStock()
            End If
        End With
        With appoint
            connect()
            sql = "select QID,name from View_q"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_q")
            .DataGridView2.DataSource = DS
            .DataGridView2.DataMember = "View_q"
        End With
        With appoint
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView2
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
        End With
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        st(bill
           )
        With bill
            connect()
            sql = "select * from View_billnotpay"
            DA = New SqlClient.SqlDataAdapter(sql, cn)
            DS = New DataSet
            DA.Fill(DS, "View_billnotpay")
            .DataGridView1.DataSource = DS
            .DataGridView1.DataMember = "View_billnotpay"

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
        With bill
            'connect()
            'sql = "select name,Expr1,Expr2,PriceF,unitS,Expr3,priceS,Expr4,unitM,Expr5,billID from View_billprint where billID='" & .TextBox1.Text & "' "
            'DA = New SqlClient.SqlDataAdapter(sql, cn)
            'DS = New DataSet
            'DA.Fill(DS, "View_billprint")
            '.DataGridView2.DataSource = DS
            '.DataGridView2.DataMember = "View_billprint"
        End With
        With bill
            'connect()
            'sql = "select * from View_checkprices where billID='" & .TextBox1.Text & "'"
            'DA = New SqlClient.SqlDataAdapter(sql, cn)
            'DS = New DataSet
            'DA.Fill(DS, "View_checkprices")
            '.DataGridView3.DataSource = DS
            '.DataGridView3.DataMember = "View_checkprices"
        End With
    End Sub

    Private Sub ToolStripMenuItem9_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        st(tReport
                  )
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        st(unit
                  )
        With unit
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະ​ຫັດຫົວໜ່ວຍ"
                .Columns(1).HeaderText = "ຫົວໜ່ວຍ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
        With unit
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView2
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະ​ຫັດຫົວໜ່ວຍ"
                .Columns(1).HeaderText = "ຫົວໜ່ວຍ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        st(medicine)
        With medicine
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
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
        End With
        With medicine
            Dim sql As String = "Select*from MD"
            Dim cmd As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet
            cmd.Fill(ds, "MD")
            .ComboBox2.DataSource = ds.Tables("MD")
            .ComboBox2.DisplayMember = "name"
            .ComboBox2.ValueMember = "MDID"
            .ComboBox2.Text = "ເລືອກປະເພດ"
        End With
        With medicine
            Dim sql As String = "Select*from Medicine_Type"
            Dim cmd As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet
            cmd.Fill(ds, "Medicine_Type")
            .ComboBox1.DataSource = ds.Tables("Medicine_Type")
            .ComboBox1.DisplayMember = "name"
            .ComboBox1.ValueMember = "MTID"
            .ComboBox1.Text = "ເລືອກຊະນິດ"
        End With
        With medicine
            Dim sql As String = "Select*from unit"
            Dim cmd As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet
            cmd.Fill(ds, "unit")
            .ComboBox3.DataSource = ds.Tables("unit")
            .ComboBox3.DisplayMember = "name"
            .ComboBox3.ValueMember = "UID"
            .ComboBox3.Text = "ເລືອກຫົວໜ່ວຍ"
        End With
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        st(mTime
                 )
        With mTime
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດຊ່ວງເວລາ"
                .Columns(1).HeaderText = "ຊື່ເວລາ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        st(mCategoty
                 )
        With mCategoty
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດປະເພດຢາ"
                .Columns(1).HeaderText = "ຊື່ປະເພດຢາ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        st(mType
                 )
        With mType
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະຫັດປະເພດຢາ"
                .Columns(1).HeaderText = "ຊື່ປະເພດຢາ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem16_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem17_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem31_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem31.Click
        st(service)
        With service
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView1
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "ລະ​ຫັດບໍລິການ"
                .Columns(1).HeaderText = "ບໍລິການ"

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                .AutoSizeRowsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End With
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub ToolStripMenuItem15_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem12_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        st(reportbill)
        With reportbill
            Dim cs As New DataGridViewCellStyle
            cs.Font = New Font("phetsarath OT", 12, FontStyle.Regular)
            With .DataGridView2
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
        End With
    End Sub

    Private Sub ToolStripMenuItem14_Click_2(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        st(check)
    End Sub

    Private Sub ToolStripMenuItem13_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click

    End Sub

    Private Sub ToolStripMenuItem17_Click_3(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem18_Click_2(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        st(positionEMP)
    End Sub

    Private Sub ToolStripMenuItem17_Click_4(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        st(emp)
    End Sub
End Class