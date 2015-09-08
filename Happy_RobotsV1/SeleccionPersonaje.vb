Imports System.IO.Ports

Public Class SeleccionPersonaje

    Dim actual As Integer
    Dim list As New ArrayList
    Dim serial As New SerialPort()
    Dim cont As Integer = 0

    Protected Sub retrocedeImagen()

    End Sub


    Private Sub Avanza(sender As Object, e As EventArgs) Handles Label1.Click
        siguiente()
        cargaImagen()

    End Sub

    Private Sub SeleccionPersonaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
        list.Add("Alvarez")
        list.Add("Byte")
        list.Add("Estifler")
        list.Add("Mitzu")
        actual = 0

        Try
            serial.PortName = GlobalClass.getPortName
            serial.BaudRate = 9600
            serial.StopBits = StopBits.One
            serial.Parity = Parity.None
            serial.DataBits = 8
            serial.Open()
            MsgBox("Puerto " + GlobalClass.getPortName + " conectado")
        Catch ex As Exception
            MsgBox("Error en la apertura del puerto serial")
        End Try
    End Sub

    Private Sub Jugar(sender As Object, e As EventArgs) Handles Label3.Click
        PictureBox1.Visible = True
        asignaJugador()
        list.RemoveAt(actual)
        If actual > list.Count - 1 Then
            actual = 0
        End If
        cargaImagen()
    End Sub

    Public Sub siguiente()
        If actual >= list.Count - 1 Then
            actual = 0
        Else
            actual = actual + 1
        End If
    End Sub

    Public Sub cargaImagen()
        Select Case list.Item(actual)
            Case "Alvarez"
                Me.BackgroundImage = My.Resources.Alvarez
            Case "Byte"
                Me.BackgroundImage = My.Resources._Byte
            Case "Estifler"
                Me.BackgroundImage = My.Resources.Estifler
            Case "Mitzu"
                Me.BackgroundImage = My.Resources.Mitzu
        End Select

    End Sub

    Private Sub Atras(sender As Object, e As EventArgs) Handles Label2.Click
        anterior()
        cargaImagen()
    End Sub

    Public Sub anterior()
        If actual <= 0 Then
            actual = list.Count - 1
        Else
            actual = actual - 1
        End If
    End Sub

    Public Sub asignaJugador()
        If cont = 0 Then
            MsgBox("Robot " + list.Item(actual) + " asignado al Jugador 1")
            GlobalClass.setjugador1(list.Item(actual))
            cont = cont + 1
        Else
            MsgBox("Robot " + list.Item(actual) + " asignado al Jugador 2")
            GlobalClass.setjugador2(list.Item(actual))
            cont = cont + 1
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cadenajugador As String = GlobalClass.getjugador2

        If String.IsNullOrEmpty(cadenajugador) Then
            MsgBox("Numero de Jugadores = 1")
        Else
            MsgBox("Numero de Jugadores = 2")
        End If
    End Sub
End Class