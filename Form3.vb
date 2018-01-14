Imports System.Data
Imports System.Data.SqlClient
Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cmd As New SqlCommand()
            Dim con As New SqlConnection()
            con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

            cmd.Connection = con
            'Dim cmd As New SqlCommand("SELECT uname, pass FROM (acc) WHERE (uname = '" & T1.Text & "') AND (pass = '" & T2.Text & "')", con)


            cmd.CommandText = "select uname,pass from adminac where uname='" + TextBox1.Text + "'and pass='" + TextBox2.Text + "'"
            con.Open()
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                MsgBox("Vailed User Id and Password")
                form4.Show()
                Me.Hide()
            Else
                MsgBox("inviled user id and password")


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
       
    End Sub
End Class