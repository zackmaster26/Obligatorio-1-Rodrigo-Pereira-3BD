Public Class Calculo

    Public Function montoTotal(datos As Datos)

        Dim sueldo As Double
        Dim total As Integer
        Dim diferencia As Double

        For i As Integer = 0 To datos._tipoEmpleado.Count - 1
            For k As Integer = 0 To datos._bajaLogica.GetLength(0) - 1
                If datos._bajaLogica.GetValue(k, 0) = datos._cedula.Item(i) Then
                    If datos._bajaLogica.GetValue(k, 1) = 1 Then

                        If (datos._tipoEmpleado.Item(i) = 1) Then
                            diferencia = datos._sueldo.Item(i) * 0.97
                            sueldo = diferencia + datos._sueldo.Item(i)
                            total = sueldo + total
                        ElseIf (datos._tipoEmpleado.Item(i) = 2) Then
                            diferencia = datos._sueldo.Item(i) * 0.38
                            sueldo = diferencia + datos._sueldo.Item(i)
                            total = sueldo + total
                        ElseIf (datos._tipoEmpleado.Item(i) = 3) Then
                            diferencia = datos._sueldo.Item(i) * 0.27
                            sueldo = diferencia + datos._sueldo.Item(i)
                            total = sueldo + total
                        End If

                    End If
                End If
            Next
        Next

        Return total
    End Function

    Public Function sueldoNeto(datos As Datos, i As Integer)

        Dim diferencia As Double
        Dim sueldo As Integer
        Dim total As Double

        If (datos._tipoEmpleado.Item(i) = 1) Then
            total = datos._sueldo.Item(i)
            diferencia = total * 0.97
            sueldo = diferencia + total
            Return sueldo
        ElseIf (datos._tipoEmpleado.Item(i) = 2) Then
            total = datos._sueldo.Item(i)
            diferencia = total * 0.38
            sueldo = diferencia + total
            Return sueldo
        ElseIf (datos._tipoEmpleado.Item(i) = 3) Then
            total = datos._sueldo.Item(i)
            diferencia = total * 0.27
            sueldo = diferencia + total
            Return sueldo
        End If

        Return 0
    End Function

End Class