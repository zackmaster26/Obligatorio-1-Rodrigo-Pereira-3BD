Imports Logica

Module Module1

    Private emp As New Empleado
    Private cal As New Calculo
    Private met As New Metodos

    Private op As Byte

    Private ced As Integer
    Private ced1 As String
    Private repCed As Boolean = False
    Private nom As String
    Private nom2 As String
    Private ape As String
    Private ape2 As String
    Private tel As Double
    Private tel1 As String
    Private sueldo1 As String
    Private tipo As String
    Private dire As String
    Private contador As Integer = 0

    Private Sub vaciar()
        ced = Nothing
        ced1 = Nothing
        repCed = Nothing
        nom = Nothing
        nom2 = Nothing
        ape = Nothing
        ape2 = Nothing
        tel = Nothing
        tel1 = Nothing
        sueldo1 = Nothing
        tipo = Nothing
        dire = Nothing
    End Sub

    Private Function modificar(o As String, contador As Integer, array As ArrayList) As Boolean
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
            array.Insert(contador, o)
            array.RemoveAt(contador + 1)
            Return True
        End If
        Return False
    End Function

    Sub Main()

        Console.Title = "Sistema de Registro"
        Console.ForegroundColor = ConsoleColor.White

        Do While op <> 3

            Console.Clear()
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.Write("----------------------------------------------------------MENÚ----------------------------------------------------------")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine(vbNewLine)
            Console.WriteLine("1) Registro de Empleados")
            Console.WriteLine("2) Importe total a pagar por concepto de sueldo")
            Console.WriteLine("3) Salir")
            Console.Write(vbNewLine)
            Console.Write("Opción: ")
            Try
                op = Integer.Parse(Console.ReadLine())
            Catch ex As Exception

            End Try

            Select Case op

                Case 1

                    Console.Clear()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("-------------------------------------------------REGISTRO DE EMPLEADOS-------------------------------------------------")
                    Console.SetCursorPosition(47.5, 1)
                    Console.Write(" (Ingrese ! para salir)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine(vbNewLine)

                    Try

                        Console.Write("Cédula (sin puntos ni guión): ")
                        ced1 = Console.ReadLine()
                        If (met.sinDatos(ced1) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(ced1) = False) Then
                                vaciar()
                                Exit Select
                            End If
                            ced = ced1
                            If met.verificarCedula(ced1, emp, repCed) = False Then
                                vaciar()
                                Exit Select
                            End If
                        End If


                        Console.Write("Nombre: ")
                        nom = Console.ReadLine()
                        If (met.sinDatos(nom) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(nom) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If (met.verificarNombre(nom, emp) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        End If


                        Console.Write("Segundo nombre (si no posee digite 0): ")
                        nom2 = Console.ReadLine()
                        If (met.sinDatos(nom2) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(nom2) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If (nom2 <> "0") Then
                                If (met.verificarSegNombre(nom2, emp) = False) Then
                                    met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                    vaciar()
                                    Exit Select
                                End If
                            Else
                                emp._SegundoNombre.Add("no")
                            End If
                        End If


                        Console.Write("Apellido: ")
                        ape = Console.ReadLine()
                        If (met.sinDatos(ape) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(ape) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If (met.verificarApellido(ape, emp) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        End If


                        Console.Write("Segundo apellido: ")
                        ape2 = Console.ReadLine()
                        If (met.sinDatos(ape2) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(ape2) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If (met.verificarSegApellido(ape2, emp) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        End If


                        Console.Write("¿Cuántos telefonos desea ingresar?: ")
                        Dim ing As Byte = Byte.Parse(Console.ReadLine)
                        For i As Integer = 0 To ing - 1
                            Console.Write("Teléfono " & i + 1 & ": ")
                            tel1 = Console.ReadLine
                            If (met.salir(tel1) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If IsNumeric(tel1) Then
                                tel = tel1
                                emp._tel(contador, 0) = ced
                                emp._tel(contador, 1) = tel
                                contador = contador + 1
                            Else
                                Console.WriteLine("")
                                Console.ForegroundColor = ConsoleColor.Red
                                Console.CursorVisible = False
                                Console.Write("Error al ingresar el dato (pulse cualquier tecla para volver al menú)")
                                Console.ForegroundColor = ConsoleColor.White
                                Console.ReadLine()
                                Console.CursorVisible = True
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        Next


                        Console.Write("Dirección: ")
                        dire = Console.ReadLine
                        If met.sinDatos(dire) = False Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(dire) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            emp._direccion.Add(dire.ToUpper)
                        End If


                        Console.Write("Sueldo base: ")
                        sueldo1 = Console.ReadLine()
                        If (met.sinDatos(sueldo1) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(sueldo1) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If (met.verificarSueldo(sueldo1, emp) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        End If


                        Console.Write("Cargo del empleado (1.Gerente 2.Operario 3.Administrativo): ")
                        tipo = Console.ReadLine
                        If (met.sinDatos(tipo) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        Else
                            If (met.salir(tipo) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                            If (met.verificarTipo(tipo, emp, cal) = False) Then
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        End If


                        Console.Write(vbNewLine)
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.CursorVisible = False
                        Console.Write("Datos ingresados correctamente")
                        Console.ForegroundColor = ConsoleColor.White
                        Threading.Thread.Sleep(1500)
                        Console.CursorVisible = True

                    Catch ex As Exception
                        Console.Write(vbNewLine)
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.CursorVisible = False
                        Console.Write("Ocurrió un error inesperado")
                        Console.ForegroundColor = ConsoleColor.White
                        Threading.Thread.Sleep(1500)
                        Console.CursorVisible = True
                        Exit Do
                    End Try

                Case 2

                    Console.Clear()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("-------------------------------------------------EMPLEADOS REGISTRADOS-------------------------------------------------")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine(vbNewLine)

                    Dim mostrarTipo As String = ""

                    For i As Integer = 0 To emp._cedula.Count - 1

                        If (emp._tipoEmpleado.Item(i) = 1) Then
                            mostrarTipo = "Gerente"
                        ElseIf (emp._tipoEmpleado.Item(i) = 2) Then
                            mostrarTipo = "Operario"
                        ElseIf (emp._tipoEmpleado.Item(i) = 3) Then
                            mostrarTipo = "Administrativo"
                        End If

                        Console.WriteLine("Cédula: " + emp._cedula.Item(i))
                        Console.Write("Nombre: " + emp._nombre.Item(i) + " ")

                        If (emp._SegundoNombre.Item(i) = "no") Then
                            Console.Write(vbNewLine)
                        Else
                            Console.WriteLine(emp._SegundoNombre.Item(i))
                        End If

                        Console.Write("Apellido: " + emp._apellido.Item(i) + " ")
                        Console.WriteLine(emp._SegundoApellido.Item(i))
                        Console.WriteLine("Dirección: " + emp._direccion.Item(i))
                        Console.Write("Teléfonos: ")

                        For j As Integer = 0 To emp._tel.GetLength(0) - 1
                            If (emp._tel.GetValue(j, 0) = emp._cedula.Item(i)) Then
                                Console.Write(emp._tel.GetValue(j, 1) & "  ")
                            End If
                        Next

                        Console.Write(vbNewLine)
                        Console.WriteLine("Cargo: " + mostrarTipo)
                        Console.WriteLine("Sueldo base: " + "$" & emp._sueldo.Item(i))
                        Console.WriteLine("Sueldo neto: " + "$" & emp._sueldoTotal.Item(i))

                        If (emp._cedula.Count > 1) Then
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------")
                        End If

                    Next

                    If (emp._cedula.Count <> 0) Then
                        Console.WriteLine("")
                        Console.WriteLine("")
                        Console.Write("El monto total a pagarle a todos los funcionarios es: ")
                        Console.ForegroundColor = ConsoleColor.Blue
                        Console.WriteLine("$" & cal.MontoTotal(emp))
                        Console.ForegroundColor = ConsoleColor.White
                        Console.WriteLine("")
                    Else
                        Console.Write("No hay datos para mostrar")
                        Console.WriteLine("")
                    End If

                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.CursorVisible = False
                    Console.Write("Pulse cualquier tecla para volver")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.ReadLine()
                    Console.CursorVisible = True

                Case 3

                    Exit Do

                Case 4
                    Dim o As Byte = 10
                    If (emp._cedula.Count <> 0) Then
                        Console.Clear()
                        Console.Write("Cedula del empleado: ")
                        Dim busCed As Integer = Console.ReadLine()

                        For i As Integer = 0 To emp._cedula.Count - 1
                            If (emp._cedula.Item(i) = busCed) Then

                                Console.Clear()

                                Do While o <> 0

                                    Console.Clear()
                                    Console.WriteLine("Empleado " + emp._cedula.Item(i))
                                    Console.Write(vbNewLine)
                                    Console.WriteLine("1) Nombre")
                                    Console.WriteLine("2) Segundo nombre")
                                    Console.WriteLine("3) Apellido")
                                    Console.WriteLine("4) Segundo apellido")
                                    Console.WriteLine("5) Teléfonos")
                                    Console.WriteLine("6) Dirección")
                                    Console.WriteLine("7) Sueldo")
                                    Console.WriteLine("8) Cargo")
                                    Console.Write("Opción: ")
                                    o = Byte.Parse(Console.ReadLine())

                                    Select Case o
                                        Case 1
                                            Console.Clear()
                                            Console.ForegroundColor = ConsoleColor.Blue
                                            Console.WriteLine("Empleado " + emp._cedula.Item(i))
                                            Console.ForegroundColor = ConsoleColor.White
                                            Console.Write(vbNewLine)
                                            Console.WriteLine("Nombre antiguo " + emp._nombre.Item(i))
                                            Console.Write("Nombre nuevo: ")
                                            Dim nuevoNombre As String = Console.ReadLine
                                            If (modificar(nuevoNombre, i, emp._nombre) = False) Then
                                                Exit Select
                                            End If

                                    End Select

                                Loop

                                'Console.WriteLine("Nuevo nombre: ")
                                'Dim nuevoNombre As String = Console.ReadLine
                                ' emp._nombre.Insert(i, nuevoNombre)
                                'emp._nombre.RemoveAt(i + 1)

                            End If


                        Next
                    Else
                        Exit Select
                    End If

                Case Else

                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write(vbNewLine)
                    Console.CursorVisible = False
                    Console.Write("Ingresó una opción incorrecta")
                    Console.ForegroundColor = ConsoleColor.White
                    Threading.Thread.Sleep(1500)
                    Console.CursorVisible = True

            End Select

        Loop

    End Sub

End Module
