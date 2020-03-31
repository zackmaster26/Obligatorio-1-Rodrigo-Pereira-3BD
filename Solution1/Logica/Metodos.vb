Public Class Metodos

    Public Function salir(op As String) As Boolean
        If (op = "!") Then
            Console.Write(vbNewLine)
            Console.ForegroundColor = ConsoleColor.Red
            Console.CursorVisible = False
            Console.Write("Se borraron los datos ingresados")
            Console.ForegroundColor = ConsoleColor.White
            Threading.Thread.Sleep(1500)
            Console.CursorVisible = True
            Return False
        End If
        Return True
    End Function

    Public Function sinDatos(op As String)
        If (op = "") Then
            Console.WriteLine("")
            Console.ForegroundColor = ConsoleColor.Red
            Console.CursorVisible = False
            Console.Write("No ingresó ningún dato")
            Console.ForegroundColor = ConsoleColor.White
            Threading.Thread.Sleep(1500)
            Return False
        End If
        Return True
    End Function

    Public Function modificar(o As String, contador As Integer, array As ArrayList) As Boolean
        If IsNumeric(o) Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write(vbNewLine)
            Console.CursorVisible = False
            Console.WriteLine("No debe contener números")
            Console.ForegroundColor = ConsoleColor.White
            Threading.Thread.Sleep(1500)
            Console.CursorVisible = True
            Return False
        Else
            array.Insert(contador, o.ToUpper)
            array.RemoveAt(contador + 1)
            Return True
        End If
        Return False
    End Function

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

    Public Function verificarString(string1 As String, array As ArrayList, texto As String) As Boolean
        Dim opcion As String
        Const numeros = "0123456789"

        If string1.IndexOfAny(numeros.ToArray) > -1 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine()
            If (opcion = "s") Then
                Console.Write(texto)
                Dim string2 As String = Console.ReadLine
                If (salir(string2) = False) Then
                    Return False
                End If
                If string2.IndexOfAny(numeros.ToArray) > -1 Then
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True
                    Return False
                Else
                    array.Add(string2.ToUpper)
                    Return True
                End If
            ElseIf (opcion = "n") Then
                Return False
            End If
        Else
            array.Add(string1.ToUpper)
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
                Console.Write("Sueldo base: ")
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
                Console.Write("Cargo del empleado (1.Gerente 2.Operario 3.Administrativo): ")
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

            If (emp._cedula.Count <> 0 Or emp._nombre.Count <> 0 Or emp._apellido.Count <> 0 Or emp._SegundoNombre.Count <> 0 Or emp._SegundoApellido.Count <> 0 Or emp._direccion.Count <> 0 Or emp._direccion.Count <> 0 Or emp._sueldo.Count <> 0 Or emp._tipoEmpleado.Count <> 0) Then

                If (emp._cedula.Item(i) = emp._cedula.Item(emp._cedula.Count - 1)) Then
                    emp._cedula.RemoveAt(i)
                    If (nom <> "!" And nom <> Nothing) Then
                        emp._nombre.RemoveAt(i)
                    End If
                    If (ape <> "!" And ape <> Nothing) Then
                        emp._apellido.RemoveAt(i)
                    End If
                    If (segNom <> "!" And segNom <> Nothing) Then
                        emp._SegundoNombre.RemoveAt(i)
                    End If
                    If (segApe <> "!" And segApe <> Nothing) Then
                        emp._SegundoApellido.RemoveAt(i)
                    End If
                    For k As Integer = 0 To emp._tel.GetLength(0) - 1
                        If (emp._tel.GetValue(k, 0) = ced) Then
                            emp._tel.SetValue(Nothing, k, 1)
                            emp._tel.SetValue(Nothing, k, 0)
                        End If
                    Next
                    If (dire <> "!" And dire <> Nothing) Then
                        emp._direccion.RemoveAt(i)
                    End If
                    If (sueldo <> "!" And sueldo <> Nothing) Then
                        emp._sueldo.RemoveAt(i)
                    End If
                    If (tipo <> "!" And tipo <> Nothing) Then
                        emp._tipoEmpleado.RemoveAt(i)
                    End If
                End If
            End If
        Next
        Return True
    End Function

End Class
