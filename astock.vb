Imports System.Data
Imports System.Data.SqlClient


Public Class astock
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim ad As New SqlDataAdapter
    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q As String
        q = TextBox3.Text
        Dim p As String
        p = TextBox4.Text
        Dim tol As String
        tol = p * q
        TextBox5.Text = tol
        If (TextBox3.Text = "" Or TextBox2.Text = "") Then
            MsgBox("Submit  All the details ")

        Else
           



            Try
                con.ConnectionString = "Data Source=REKS-PC\SQLEXPRESS;Initial Catalog=vip;Integrated Security=True"

                cmd.Connection = con
                con.Open()
                cmd.CommandText = "INSERT INTO stock(date,cname,stype,quentity,price,tot)VALUES('" + TextBox2.Text + "','" + ComboBox1.SelectedItem + "','" + ComboBox2.SelectedItem + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')"
                cmd.ExecuteNonQuery()
                MsgBox("insert in sucessfuly")

                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()



                Form1.TopMost = True
            Catch ex As Exception
                MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
            Finally
                con.Close()
            End Try

        End If

       
    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        TextBox2.Text = MonthCalendar1.SelectionRange.Start.ToString()
    End Sub

    Private Sub astock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VipDataSet2.stock' table. You can move, or remove it, as needed.
        Me.StockTableAdapter.Fill(Me.VipDataSet2.stock)

    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByToolStripButton.Click
        Try
            Me.StockTableAdapter.FillBy(Me.VipDataSet2.stock)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Show()
        Form2.TopMost = True
    End Sub
End Class