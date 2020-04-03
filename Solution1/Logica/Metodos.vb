Public Class Metodos

    Public Function salir(op As String, texto As String, ms As Integer) As Boolean
        If (op = "!") Then
            Console.Write(vbNewLine)
            Console.ForegroundColor = ConsoleColor.Red
            Console.CursorVisible = False
            Console.Write(texto)
            Console.ForegroundColor = ConsoleColor.White
            Threading.Thread.Sleep(ms)
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

    Public Function modificarTel(emp As Empleado, i As Integer, aux As ArrayList, num As Byte, modTel As Byte, opTel As Byte) As Boolean
        If (modTel <> Nothing) Then
            If (modTel > num Or modTel = 0) Then
                Return False
            Else
                Dim indice As Integer
                For j As Integer = 0 To aux.Count - 1
                    indice = aux.Item(modTel - 1)
                Next
                Console.Write("Nuevo teléfono: ")
                Dim telString As String = Console.ReadLine
                If (sinDatos(telString) = False) Then
                    Return False
                Else
                    If IsNumeric(telString) Then
                        Dim nuevoTel As Integer = telString
                        emp._tel.SetValue(nuevoTel, indice, 1)
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Else
            Return False
        End If
        Return False
    End Function

    Public Function eliminarTel(emp As Empleado, i As Integer, aux As ArrayList, num As Byte, modTel As Byte, opTel As Byte) As Boolean
        If (modTel <> Nothing) Then
            If (modTel > num Or modTel = 0) Then
                Return False
            Else
                Dim indice As Integer
                For j As Integer = 0 To aux.Count - 1
                    indice = aux.Item(modTel - 1)
                Next
                emp._tel.SetValue(Nothing, indice, 1)
                Return True
            End If
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
                    Console.Write("Esta cédula ya fue ingresada")
                    Console.ForegroundColor = ConsoleColor.White
                    Threading.Thread.Sleep(1500)
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
            Console.Write("Debe ingresar una cédula de longitud válida")
            Console.CursorVisible = False
            Console.ForegroundColor = ConsoleColor.White
            Threading.Thread.Sleep(1500)
            Console.CursorVisible = True
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
                If (salir(string2, "Se borraron los datos ingresados", 1500) = False) Then
                    Return False
                End If
                If string2.IndexOfAny(numeros.ToArray) > -1 Then
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("No debe contener caracteres numéricos")
                    Console.ForegroundColor = ConsoleColor.White
                    Threading.Thread.Sleep(1500)
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
                    Console.Write("Error al ingresar el dato")
                    Console.ForegroundColor = ConsoleColor.White
                    Threading.Thread.Sleep(1500)
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
                    Return True
                Else
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("Error al ingresar el dato")
                    Console.ForegroundColor = ConsoleColor.White
                    Threading.Thread.Sleep(1500)
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
