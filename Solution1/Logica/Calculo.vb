Public Class Calculo

    Public Function montoTotal(emp As Empleado)

        Dim sueldo As Double
        Dim total As Integer
        Dim diferencia As Double

        For i As Integer = 0 To emp._tipoEmpleado.Count - 1
            For k As Integer = 0 To emp._bajaLogica.GetLength(0) - 1
                If emp._bajaLogica.GetValue(k, 0) = emp._cedula.Item(i) Then
                    If emp._bajaLogica.GetValue(k, 1) = 1 Then

                        If (emp._tipoEmpleado.Item(i) = 1) Then
                            diferencia = emp._sueldo.Item(i) * 0.97
                            sueldo = diferencia + emp._sueldo.Item(i)
                            total = sueldo + total
                        ElseIf (emp._tipoEmpleado.Item(i) = 2) Then
                            diferencia = emp._sueldo.Item(i) * 0.38
                            sueldo = diferencia + emp._sueldo.Item(i)
                            total = sueldo + total
                        ElseIf (emp._tipoEmpleado.Item(i) = 3) Then
                            diferencia = emp._sueldo.Item(i) * 0.27
                            sueldo = diferencia + emp._sueldo.Item(i)
                            total = sueldo + total
                        End If

                    End If
                End If
            Next
        Next

        Return total
    End Function

    Public Function sueldoNeto(emp As Empleado, i As Integer)
        Dim diferencia As Double
        Dim sueldo As Integer
        Dim total As Double

        If (emp._tipoEmpleado.Item(i) = 1) Then
            total = emp._sueldo.Item(i)
            diferencia = total * 0.97
            sueldo = diferencia + total
            Return sueldo
        ElseIf (emp._tipoEmpleado.Item(i) = 2) Then
            total = emp._sueldo.Item(i)
            diferencia = total * 0.38
            sueldo = diferencia + total
            Return sueldo
        ElseIf (emp._tipoEmpleado.Item(i) = 3) Then
            total = emp._sueldo.Item(i)
            diferencia = total * 0.27
            sueldo = diferencia + total
            Return sueldo
        End If
        Return 0
    End Function

End Class
