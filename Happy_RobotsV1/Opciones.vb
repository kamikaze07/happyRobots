Public Class Opciones

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MainMenu.Show()
        Me.Close()
        My.Computer.Audio.Play(My.Resources.Dumb_Ways_to_Die_IJNR2EpS0jw, _
        AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        AdministracionPreguntas.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Hide()
        Configuracion.Show()
    End Sub
End Class