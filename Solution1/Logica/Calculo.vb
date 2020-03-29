Public Class Calculo

    Public Function MontoTotal(emp As Empleado)

        Dim sueldo As Double
        Dim total As Integer
        Dim diferencia As Double

        For i As Integer = 0 To emp._tipoEmpleado.Count - 1
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

        Next

        Return total
    End Function

    Public Function MontoIndividual(emp As Empleado)

        Dim diferencia As Double
        Dim sueldo As Integer
        Dim total As Double

        For i As Integer = 0 To emp._sueldo.Count - 1
            If (emp._tipoEmpleado.Item(i) = 1) Then
                total = emp._sueldo.Item(i)
                diferencia = total * 0.97
                sueldo = diferencia + total

            ElseIf (emp._tipoEmpleado.Item(i) = 2) Then
                total = emp._sueldo.Item(i)
                diferencia = total * 0.38
                sueldo = diferencia + total
            ElseIf (emp._tipoEmpleado.Item(i) = 3) Then
                total = emp._sueldo.Item(i)
                diferencia = total * 0.27
                sueldo = diferencia + total
            End If

        Next

        emp._sueldoTotal.Add(sueldo)

        Return sueldo
    End Function

End Class
