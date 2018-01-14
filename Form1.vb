Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Label7.Text = DateTime.Now.ToString
        Label3.Cursor = Cursors.Hand

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Dim i As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label7.Text = DateTime.Now.ToString
        i = i + 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Addaccount.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cmd As New SqlCommand()
            Dim con As New SqlConnection()
            con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

            cmd.Connection = con
            'Dim cmd As New SqlCommand("SELECT uname, pass FROM (acc) WHERE (uname = '" & T1.Text & "') AND (pass = '" & T2.Text & "')", con)


            cmd.CommandText = "select uname,pass from acc where uname='" + T1.Text + "'and pass='" + T2.Text + "'"
            con.Open()
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                MsgBox("Vailed User Id and Password")
                Form2.Show()
                Me.Hide()
            Else
                MsgBox("inviled user id and password")


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class
