Public Class Configuracion
    Dim cont As Integer = 0, cont1 As Integer = 0

    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(sp)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If cont <> 0 Then
            PictureBox1.Image = My.Resources.verdeizquierda
            GlobalClass.setPortName(ComboBox1.SelectedItem.ToString)
            cont1 = 1
            PictureBox1.Image = My.Resources.verdeizquierda
            MsgBox("Puerto cambiado a " + ComboBox1.SelectedItem.ToString)
        Else
            MsgBox("Seleccciona un puerto serial")
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If cont1 = 0 Then
            MsgBox("No haz cambiado el puerto serial")
            Opciones.Show()
            Me.Close()
        Else
            Opciones.Show()
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cont = 1
    End Sub
End Class