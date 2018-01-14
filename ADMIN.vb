Imports System.Data
Imports System.Data.SqlClient
Public Class ADMIN
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim ad As New SqlDataAdapter


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("This Funcation Is Not Avialable")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (TextBox6.Text = "" Or TextBox8.Text = "") Then

            MsgBox("Submit  All the details ")


        Else



            Try
                con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

                cmd.Connection = con
                con.Open()
                cmd.CommandText = "INSERT INTO adminac(uname,pass)VALUES('" + TextBox6.Text + "','" + TextBox8.Text + "')"
                cmd.ExecuteNonQuery()
                MsgBox("insert in sucessfuly")
                TextBox1.Clear()
                TextBox2.Clear()
                Form3.Show()
                Form3.TopLevel = True

                Me.Hide()


            Catch ex As Exception
                MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
            Finally
                con.Close()
            End Try

        End If


    End Sub
End Class