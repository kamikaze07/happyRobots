Module GlobalClass
#Region "variables"
    Dim portname As String
    Dim jugador1 As String, jugador2 As String
#End Region

#Region "Metodos"
    Public Function getPortName() As String
        Return portname
    End Function

    Public Sub setPortName(ByVal port As String)
        portname = port
    End Sub

    Public Function gejugador1() As String
        Return jugador1
    End Function

    Public Sub setjugador1(ByVal jugador As String)
        jugador1 = jugador
    End Sub

    Public Function getjugador2() As String
        Return jugador2
    End Function

    Public Sub setjugador2(ByVal jugador As String)
        jugador2 = jugador
    End Sub
#End Region

End Module
