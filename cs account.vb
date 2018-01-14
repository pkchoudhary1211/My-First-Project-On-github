Imports System.Data
Imports System.Data.OleDb
Public Class cs_account
    Dim conn As String = System.Configuration.ConfigurationSettings.AppSettings("dsn")
    Dim com As OleDbCommand

    Dim ada As OleDbDataAdapter
    Dim dt As DataTable
    Dim ds As DataSet
    Dim str As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As OpenFileDialog = New OpenFileDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        new_connection.Show()
    End Sub
   
    Private Sub cs_account_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       


    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub FillBy1ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub FillBy2ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FillByToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByToolStripButton.Click
        Try
            Me.CustmeracTableAdapter.FillBy(Me.VipDataSet1.custmerac)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim con As OleDbConnection = New OleDbConnection(conn)
        If (TextBox1.Text = "") Then
            MsgBox("please Enter Diary No Ya Name")
        Else
            Try
                con.ConnectionString = "Provider=SQLOLEDB;Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"
                con.Open()
                str = "select * from custmerac where id like'" & TextBox1.Text & "%"
                com = New OleDbCommand(str, con)
                ada = New OleDbDataAdapter(com)
                ds = New DataSet

                ada.Fill(ds, "custmerac")
                con.Close()
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "custmerac"

            Catch ex As Exception
                MsgBox(ex.Message.ToString)



            End Try
        End If
        TextBox1.Clear()
        DataGridView1.Visible = True

    End Sub
End Class