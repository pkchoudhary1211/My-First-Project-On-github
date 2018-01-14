Imports System.Data
Imports System.Data.SqlClient
Public Class Addaccount
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim ad As New SqlDataAdapter
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Addaccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If (TextBox1.Text = "" Or TextBox2.Text = "") Then
            MsgBox("Submit  All the details ")

        Else
            If (TextBox3.Text <> TextBox2.Text) Then
                MsgBox("Submit Same Password")
            Else


                Try
                    con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "INSERT INTO acc(uname,pass,email,squection,ans)VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')"
                    cmd.ExecuteNonQuery()
                    MsgBox("insert in sucessfuly")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    Me.Hide()
                    Form1.Show()
                    Form1.TopMost = True
                Catch ex As Exception
                    MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
                Finally
                    con.Close()
                End Try

        End If
        End If
    End Sub
End Class