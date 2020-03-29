Public Class Metodos


    Public Function verificarCedula(ced As String, emp As Empleado, repCed As Boolean) As Boolean

        If (ced.Length = 7 Or ced.Length = 8) Then
            For i As Integer = 0 To emp._cedula.Count - 1
                If (emp._cedula.Item(i) = ced) Then
                    repCed = True
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("Esta cédula ya fue ingresada (pulse cualquier tecla para volver al menú")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                End If
            Next
            If repCed = False Then
                emp._cedula.Add(ced)
                Return True
            End If
        Else
            Console.WriteLine("")
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Debe ingresar una cédula válida (pulse cualquier tecla)")
            Console.CursorVisible = False
            Console.ForegroundColor = ConsoleColor.White
            Console.ReadLine()
            Console.CursorVisible = True
            Return False
        End If
        Return False

    End Function

    Public Function verificarNombre(nom As String, emp As Empleado) As Boolean
        Dim opcion As String
        Const numeros = "0123456789"

        If nom.IndexOfAny(numeros.ToArray) > -1 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine()
            If (opcion = "s") Then
                Console.Write("Nombre del empleado: ")
                Dim nom2 As String = Console.ReadLine()
                If nom2.IndexOfAny(numeros.ToArray) > -1 Then
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                Else
                    emp._nombre.Add(nom2.ToUpper)
                    Return True
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        Else
            emp._nombre.Add(nom.ToUpper)
            Return True
        End If
        Return False

    End Function

    Public Function verificarApellido(ape As String, emp As Empleado) As Boolean
        Dim opcion As String
        Const numeros = "0123456789"

        If ape.IndexOfAny(numeros.ToArray) > -1 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine()
            If (opcion = "s") Then
                Console.Write("Apellido del empleado: ")
                Dim ape2 As String = Console.ReadLine()
                If ape2.IndexOfAny(numeros.ToArray) > -1 Then
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                Else
                    emp._apellido.Add(ape2.ToUpper)
                    Return True
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        Else
            emp._apellido.Add(ape.ToUpper)
            Return True
        End If
        Return False

    End Function

    Public Function verificarSegNombre(nom As String, emp As Empleado) As Boolean
        Dim opcion As String
        Const numeros = "0123456789"

        If nom.IndexOfAny(numeros.ToArray) > -1 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine()
            If (opcion = "s") Then
                Console.Write("Segundo nombre del empleado (si no posee digite 0): ")
                Dim nom2 As String = Console.ReadLine()
                If nom2.IndexOfAny(numeros.ToArray) > -1 Then
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                Else
                    emp._SegundoNombre.Add(nom2.ToUpper)
                    Return True
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        Else
            emp._SegundoNombre.Add(nom.ToUpper)
            Return True
        End If
        Return False

    End Function

    Public Function verificarSegApellido(ape As String, emp As Empleado) As Boolean
        Dim opcion As String
        Const numeros = "0123456789"

        If ape.IndexOfAny(numeros.ToArray) > -1 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine()
            If (opcion = "s") Then
                Console.Write("Apellido del empleado: ")
                Dim ape2 As String = Console.ReadLine()
                If ape2.IndexOfAny(numeros.ToArray) > -1 Then
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                Else
                    emp._SegundoApellido.Add(ape2.ToUpper)
                    Return True
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        Else
            emp._SegundoApellido.Add(ape.ToUpper)
            Return True
        End If
        Return False

    End Function

    Public Function verificarSueldo(sueldo1 As String, emp As Empleado) As Boolean
        Dim opcion As String
        Dim sueldo As Double
        Dim sueldo3 As Double

        If IsNumeric(sueldo1) Then
            sueldo = sueldo1
            emp._sueldo.Add(sueldo)
            Return True
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine
            If (opcion = "s") Then
                Console.Write("Sueldo base del empleado: ")
                Dim sueldo2 As String = Console.ReadLine()
                If IsNumeric(sueldo2) Then
                    sueldo3 = sueldo2
                    emp._sueldo.Add(sueldo3)
                    Return True
                Else
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("Error al ingresar el dato (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        End If
        Return False
    End Function

    Public Function verificarTipo(tipo1 As String, emp As Empleado, cal As Calculo) As Boolean
        Dim opcion As String
        Dim tipo As Integer
        Dim tipo3 As Integer

        If (tipo1 = "1" Or tipo1 = "2" Or tipo1 = "3") Then
            tipo = tipo1
            emp._tipoEmpleado.Add(tipo)
            cal.MontoIndividual(emp)
            Return True
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine
            If (opcion = "s") Then
                Console.Write("Tipo de empleado(1.Gerente 2.Operario 3.Administrativo): ")
                Dim tipo2 As String = Console.ReadLine
                If (tipo2 = "1" Or tipo2 = "2" Or tipo2 = "3") Then
                    tipo3 = tipo2
                    emp._tipoEmpleado.Add(tipo3)
                    cal.MontoIndividual(emp)
                    Return True
                Else
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("Error al ingresar el dato (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        End If
        Return False
    End Function



    Public Function borrarDatos(emp As Empleado, nom As String, ced As String, ape As String, segNom As String, segApe As String, dire As String, sueldo As String, tipo As String) As Boolean

        For i As Integer = 0 To emp._cedula.Count - 1
            If (emp._cedula.Item(i) = ced) Then
                emp._cedula.RemoveAt(i)
            Else
                Return False
            End If
        Next
        For i As Integer = 0 To emp._nombre.Count - 1
            If (emp._nombre.Item(i) = nom.ToUpper) Then
                emp._nombre.RemoveAt(i)
            Else
                Return False
            End If
        Next

        For i As Integer = 0 To emp._apellido.Count - 1
            If (emp._apellido.Item(i) = ape.ToUpper) Then
                emp._apellido.RemoveAt(i)
            Else
                Return False
            End If
        Next

        For i As Integer = 0 To emp._SegundoNombre.Count - 1
            If (emp._SegundoNombre.Item(i) <> Nothing) Then
                If (emp._SegundoNombre(i) = segNom.ToUpper) Then
                    emp._SegundoNombre.RemoveAt(i)
                Else
                    Return False
                End If
            End If
        Next

        For i As Integer = 0 To emp._SegundoApellido.Count - 1
            If (emp._SegundoApellido.Item(i) = segApe.ToUpper) Then
                emp._SegundoApellido.RemoveAt(i)
            Else
                Return False
            End If
        Next

        For i As Integer = 0 To emp._direccion.Count - 1
            If (emp._direccion.Item(i) = dire.ToUpper) Then
                emp._direccion.RemoveAt(i)
            Else
                Return False
            End If
        Next

        For i As Integer = 0 To emp._tel.GetLength(0) - 1
            If (emp._tel.GetValue(i, 0) = ced) Then
                emp._tel.SetValue(Nothing, i, 1)
                emp._tel.SetValue(Nothing, i, 0)
            Else
                Return False
            End If
        Next

        For i As Integer = 0 To emp._sueldo.Count - 1
            If (emp._sueldo.Item(i) = sueldo) Then
                emp._sueldo.RemoveAt(i)
            Else
                Return False
            End If
        Next

        For i As Integer = 0 To emp._tipoEmpleado.Count - 1
            If (emp._tipoEmpleado.Item(i) = tipo) Then
                emp._tipoEmpleado.RemoveAt(i)
            Else
                Return False
            End If
        Next
        Return True

    End Function



End Class
