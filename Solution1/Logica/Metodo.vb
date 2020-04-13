Public Class Metodo

#Region "Verificaciones"

    Public Function verificarCedula(datos As Datos, ced As String, repCed As Boolean) As Boolean

        If (ced.Length = 7 Or ced.Length = 8) Then
            For i As Integer = 0 To datos._cedula.Count - 1
                If (datos._cedula.Item(i) = ced) Then
                    repCed = True
                    Return False
                End If
            Next
            If repCed = False Then
                Return True
            End If
        Else
            Return False
        End If

        Return False
    End Function

    Public Function digitoVerificador(ced As String) As Boolean

        Dim array As New ArrayList
        Dim numeros = New Integer() {2, 9, 8, 7, 6, 3, 4}
        Dim acumulador As Integer = 0
        Dim cuenta As Integer = 0


        If (ced.Length = 8) Then

            Dim digito As String = ced.Substring(7, 1)
            ced = ced.Substring(0, 7)

            For i As Integer = 0 To ced.Length - 1
                array.Add(ced.Substring(i, 1))
            Next
            For i As Integer = 0 To array.Count - 1
                acumulador = acumulador + array.Item(i) * numeros(i)
            Next

            cuenta = 10 - (acumulador Mod 10)

            If (cuenta = digito) Then
                Return True
            Else
                Return False
            End If

        ElseIf (ced.Length = 7) Then

            Dim digito As String = ced.Substring(6, 1)
            ced = ced.Substring(0, 6)
            numeros = {9, 8, 7, 6, 3, 4}

            For i As Integer = 0 To ced.Length - 1
                array.Add(ced.Substring(i, 1))
            Next
            For i As Integer = 0 To array.Count - 1
                acumulador = acumulador + array.Item(i) * numeros(i)
            Next

            cuenta = 10 - (acumulador Mod 10)

            If (cuenta = digito) Then
                Return True
            Else
                Return False
            End If

        End If

        Return False
    End Function

    Public Function verificarString(string1 As String) As Boolean

        Const numeros = "0123456789"

        If string1.IndexOfAny(numeros.ToArray) > -1 Then
            Return False
        Else
            Return True
        End If

        Return False
    End Function

    Public Function verificarSueldo(sueldo As String) As Boolean

        If IsNumeric(sueldo) Then
            Return True
        Else
            Return False
        End If

        Return False
    End Function

    Public Function verificarTipo(tipo As Char) As Boolean

        If (tipo = "1" Or tipo = "2" Or tipo = "3") Then
            Return True
        Else
            Return False
        End If

        Return False
    End Function

#End Region

#Region "Modificar"

    Public Function modificar(dato As String) As Boolean

        If IsNumeric(dato) Then
            Return False
        Else

            Return True
        End If

        Return False
    End Function

    Public Function modificarTel(datos As Datos, aux As ArrayList, num As Byte, modTel As Byte, opTel As Byte, tel As String) As Boolean

        Dim indice As Integer

        For j As Integer = 0 To aux.Count - 1
            indice = aux.Item(modTel - 1)
        Next

        If IsNumeric(tel) Then
            datos._tel.SetValue(Integer.Parse(tel), indice, 1)
            Return True
        Else
            Return False
        End If

        Return False
    End Function

    Public Function eliminarTel(datos As Datos, aux As ArrayList, num As Byte, modTel As Byte, opTel As Byte) As Boolean

        Dim indice As Integer

        For j As Integer = 0 To aux.Count - 1
            indice = aux.Item(modTel - 1)
        Next

        datos._tel.SetValue(Nothing, indice, 1)

        Return True
    End Function

#End Region

    Public Function borrarTelefono(datos As Datos, ced As String) As Boolean

        For k As Integer = 0 To datos._tel.GetLength(0) - 1
            If (datos._tel.GetValue(k, 0) = ced) Then
                datos._tel.SetValue(Nothing, k, 1)
                datos._tel.SetValue(Nothing, k, 0)
            End If
        Next

        Return True
    End Function

End Class
