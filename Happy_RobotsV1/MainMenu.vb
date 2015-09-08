Public Class MainMenu
    Dim cont As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        My.Computer.Audio.Play(My.Resources.Dumb_Ways_to_Die_IJNR2EpS0jw, _
        AudioPlayMode.BackgroundLoop)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If cont = 0 Then
            PictureBox1.Image = My.Resources.Menu1
            cont = 1
        Else
            PictureBox1.Image = My.Resources.Menu2
            cont = 0
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        My.Computer.Audio.Stop()
        Me.Hide()
        Opciones.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        SeleccionPersonaje.Show()
        Me.Hide()

    End Sub
End Class
