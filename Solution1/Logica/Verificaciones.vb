Public Class Verificaciones


    Public Function verificarCedula(ced As String, emp As Empleado, repCed As Boolean) As Boolean

        If (ced.Length = 7 Or ced.Length = 8) Then
            For i As Integer = 0 To emp._cedula.Count - 1
                If (emp._cedula.Item(i) = ced) Then
                    repCed = True
                    Console.WriteLine("")
                    Console.Write("Esta cédula ya fue ingresada (pulse cualquier tecla para volver al menú)")
                    Console.ReadLine()
                    Return False
                End If
            Next
            If repCed = False Then
                emp._cedula.Add(ced)
                Return True
            End If
        Else
            Console.WriteLine("")
            Console.Write("Debe ingresar una cédula válida (pulse cualquier tecla)")
            Console.ReadLine()
            Return False
        End If
        Return False
    End Function

    Public Function borrarDatos(emp As Empleado, nom As String, ced As String, ape As String, dire As String, tel As Integer, sueldo As Double, tipo As Integer) As Boolean

        For i As Integer = 0 To emp._cedula.Count - 1
            If (emp._cedula.Item(i) = ced) Then
                emp._cedula.RemoveAt(i)
            End If
        Next
        For i As Integer = 0 To emp._nombre.Count - 1
            If (emp._nombre.Item(i) = nom.ToUpper) Then
                emp._nombre.RemoveAt(i)
            End If
        Next
        For i As Integer = 0 To emp._apellido.Count - 1
            If (emp._apellido.Item(i) = ape.ToUpper) Then
                emp._apellido.RemoveAt(i)
            End If
        Next
        For i As Integer = 0 To emp._direccion.Count - 1
            If (emp._direccion.Item(i) = dire.ToUpper) Then
                emp._direccion.RemoveAt(i)
            End If
        Next
        For i As Integer = 0 To emp._telefono.Count - 1
            If (emp._telefono.Item(i) = tel) Then
                emp._telefono.RemoveAt(i)
            End If
        Next
        For i As Integer = 0 To emp._sueldo.Count - 1
            If (emp._sueldo.Item(i) = sueldo) Then
                emp._sueldo.RemoveAt(i)
            End If
        Next
        For i As Integer = 0 To emp._tipoEmpleado.Count - 1
            If (emp._tipoEmpleado.Item(i) = tipo) Then
                emp._tipoEmpleado.RemoveAt(i)
            End If
        Next
        Return True
    End Function

End Class
