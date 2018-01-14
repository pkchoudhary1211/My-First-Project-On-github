Imports System.Data
Imports System.Data.SqlClient
Public Class distbuter

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Show()
        Form2.TopMost = True
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Dim a As New Decimal()
    Private Sub distbuter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VipDataSet5.dist' table. You can move, or remove it, as needed.
        Me.DistTableAdapter1.Fill(Me.VipDataSet5.dist)
        'TODO: This line of code loads data into the 'VipDataSet4.dist' table. You can move, or remove it, as needed.
        Me.DistTableAdapter.Fill(Me.VipDataSet4.dist)
        TextBox1.Text = Date.Now.ToString()
    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        TextBox1.Text = MonthCalendar1.SelectionRange.Start.Date.ToString()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ad As New SqlDataAdapter
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox1.Text = "") Then
            MsgBox("Submit  All the details ")

        Else

            Try

                Dim a As Decimal
                a = TextBox2.Text
                Dim b As Decimal
                b = TextBox3.Text
                Dim c As Decimal
                c = a * b
                Label11.Text = c

                con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

                cmd.Connection = con
                con.Open()
                cmd.CommandText = "INSERT INTO dist(date,nos,rat,village,tot)VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + Label11.Text + "')"
                cmd.ExecuteNonQuery()
                MsgBox("insert in sucessfuly")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                Label11.Text = ""

            Catch ex As Exception

                MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")

            Finally
                con.Close()
            End Try

        End If

    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByToolStripButton.Click
        Try
            Me.DistTableAdapter.FillBy(Me.VipDataSet4.dist)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FillBy1ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.DistTableAdapter.FillBy1(Me.VipDataSet4.dist)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class