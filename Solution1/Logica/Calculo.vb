Public Class Calculo

    Dim total As Integer

    Public Function MontoTotal(emp As Empleado)

        For i As Integer = 0 To emp._sueldo.Count - 1
            total = emp._sueldo.Item(i) + total
        Next

        Return total
    End Function

End Class
