Imports Logica

Module Module1

    Private emp As New Empleado
    Private cal As New Calculo
    Private met As New Metodos
    Private op As Byte
    Private ced As Integer
    Private repCed As Boolean = False
    Private nom As String
    Private nom2 As String
    Private ape As String
    Private ape2 As String
    Private tel As Double
    Private sueldo1 As String
    Private tipo As String
    Private dire As String
    Private contador As Integer = 0

    Private Function salir(op As String) As Boolean
        If (op = "!") Then
            Console.Write(vbNewLine)
            Console.ForegroundColor = ConsoleColor.Red
            Console.CursorVisible = False
            Console.Write("Se borraron los datos ingresados")
            Console.ForegroundColor = ConsoleColor.White
            Threading.Thread.Sleep(2500)
            Console.CursorVisible = True
            Return False
        End If
        Return True
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
                        Console.Write("Cédula del empleado: ")
                        Dim ced1 As String = Console.ReadLine()
                        If (salir(ced1) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        ced = ced1
                        If met.verificarCedula(ced, emp, repCed) = False Then
                            Exit Select
                        End If


                        Console.Write("Nombre del empleado: ")
                        nom = Console.ReadLine()
                        If (salir(nom) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        If (met.verificarNombre(nom, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If


                        Console.Write("Segundo nombre del empleado (si no posee digite 0): ")
                        nom2 = Console.ReadLine()
                        If (salir(nom2) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        If (nom2 <> "0") Then
                            If (met.verificarSegNombre(nom2, emp) = False) Then
                                met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                                Exit Select
                            End If
                        Else
                            emp._SegundoNombre.Add("no")
                        End If


                        Console.Write("Apellido del empleado: ")
                        ape = Console.ReadLine()
                        If (salir(ape) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        If (met.verificarApellido(ape, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                        End If


                        Console.Write("Segundo apellido del empleado: ")
                        ape2 = Console.ReadLine()
                        If (salir(ape2) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        If (met.verificarSegApellido(ape2, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If


                        Console.Write("¿Cuántos telefonos desea ingresar?: ")
                        Dim ing As Byte = Byte.Parse(Console.ReadLine)
                        For i As Integer = 0 To ing - 1
                            Console.Write("Teléfono " & i + 1 & ": ")
                            Dim tel1 As String = Console.ReadLine
                            If (salir(tel1) = False) Then
                                met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                                Exit Select
                            End If
                            tel = tel1
                            emp._tel(contador, 0) = ced
                            emp._tel(contador, 1) = tel
                            contador = contador + 1
                        Next


                        Console.Write("Dirección del empleado: ")
                        dire = Console.ReadLine
                        If (salir(dire) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        emp._direccion.Add(dire.ToUpper)


                        Console.Write("Sueldo base del empleado: ")
                        sueldo1 = Console.ReadLine()
                        If (salir(sueldo1) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        If (met.verificarSueldo(sueldo1, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If


                        Console.Write("Tipo de empleado (1.Gerente 2.Operario 3.Administrativo): ")
                        tipo = Console.ReadLine
                        If (salir(tipo) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
                        End If
                        If (met.verificarTipo(tipo, emp, cal) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, nom2, ape2, dire, sueldo1, tipo)
                            Exit Select
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
                        Console.Write("Nombres: " + emp._nombre.Item(i) + " ")

                        If (emp._SegundoNombre.Item(i) = "no") Then
                            Console.Write(vbNewLine)
                        Else
                            Console.WriteLine(emp._SegundoNombre.Item(i))
                        End If

                        Console.Write("Apellidos: " + emp._apellido.Item(i) + " ")
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

                Case Else
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write(vbNewLine)
                    Console.CursorVisible = False
                    Console.Write("Ingresó una opción incorrecta")
                    Console.ForegroundColor = ConsoleColor.White
                    Threading.Thread.Sleep(2000)
                    Console.CursorVisible = True

            End Select

        Loop

    End Sub

End Module
