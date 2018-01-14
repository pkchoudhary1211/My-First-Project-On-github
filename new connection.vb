Imports System.Data
Imports System.Data.SqlClient

Public Class new_connection

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub new_connection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click, Label7.Click, Label6.Click

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim opd As New OpenFileDialog()

        If (opd.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox2.Load(opd.FileName)
            MsgBox("sucessful uploade your photo")
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
        Form2.TopMost = True
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim opd As New OpenFileDialog()

        If (opd.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
            PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox5.Load(opd.FileName)
            MsgBox("sucessful uploade your Sign")
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form2.Show()
        Form2.TopMost = True
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ad As New SqlDataAdapter
        If (TextBox1.Text = "" Or TextBox2.Text = "") Then
            MsgBox("Submit  All the details ")

       
        Else
            Dim vb As String

            vb = ComboBox1.SelectedItem + "/" + ComboBox2.SelectedItem + "/" + ComboBox3.SelectedItem


            Try
                con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

                cmd.Connection = con
                con.Open()
                cmd.CommandText = "INSERT INTO custmerac(name,fname,categery,cast,dob,address,state,dist,pincode,email,diaryno,mobile,village,addhar,bankno,conntype,wrk)VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + ComboBox4.SelectedItem + "','" + TextBox3.Text + "','" + vb + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + Label24.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + TextBox13.Text + "','" + ComboBox5.SelectedItem + "','" + TextBox14.Text + "')"
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

    End Sub
End Class