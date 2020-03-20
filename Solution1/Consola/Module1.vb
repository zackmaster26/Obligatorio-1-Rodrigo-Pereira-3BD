Imports Logica

Module Module1

    Sub Main()

        Dim emp As New Empleado
        Dim cal As New Calculo
        Dim ver As New Verificaciones
        Dim op As Integer
        Dim ced As String
        Dim repCed As Boolean = False
        Dim nom As String
        Dim ape As String
        Dim tel As Integer
        Dim dire As String
        Dim sueldo As Double
        Dim opcion As String
        Dim tipo As Integer
        Const numeros = "0123456789"

        Do While op <> 3

            Console.Clear()
            Console.WriteLine("1) Registro de Empleados")
            Console.WriteLine("2) Importe total a pagar por concepto de sueldo")
            Console.WriteLine("3) Salir")
            Console.Write("Opción: ")
            op = Integer.Parse(Console.ReadLine())

            Select Case op

                Case 1
                    Console.Clear()

                    Try
                        Console.Write("Cédula del empleado: ")
                        ced = Console.ReadLine()
                        If ver.verificarCedula(ced, emp, repCed) = False Then
                            Exit Select
                        End If


                        Console.Write("Nombre del empleado: ")
                        nom = Console.ReadLine()
                        If nom.IndexOfAny(numeros.ToArray) > -1 Then
                            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            opcion = Console.ReadLine()
                            If (opcion = "s") Then
                                Console.Write("Nombre del empleado: ")
                                Dim nom2 As String = Console.ReadLine()
                                If nom2.IndexOfAny(numeros.ToArray) > -1 Then
                                    ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                    Console.WriteLine("")
                                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                                    Console.ReadLine()
                                    Exit Select
                                Else
                                    emp._nombre.Add(nom2.ToUpper)
                                End If
                            ElseIf (opcion = "n") Then
                                ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                Exit Select
                            End If
                        Else
                            emp._nombre.Add(nom.ToUpper)
                        End If


                        Console.Write("Apellido del empleado: ")
                        ape = Console.ReadLine()
                        If ape.IndexOfAny(numeros.ToArray) > -1 Then
                            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            opcion = Console.ReadLine()
                            If (opcion = "s") Then
                                Console.Write("Apellido del empleado: ")
                                Dim ape2 As String = Console.ReadLine()
                                If ape2.IndexOfAny(numeros.ToArray) > -1 Then
                                    ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                    Console.WriteLine("")
                                    Console.Write("No debe contener caracteres numéricos (pulse cualquier tecla para volver al menú)")
                                    Console.ReadLine()
                                    Exit Select
                                Else
                                    emp._apellido.Add(ape2.ToUpper)
                                End If
                            ElseIf (opcion = "n") Then
                                ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                Exit Select
                            End If
                        Else
                            emp._apellido.Add(ape.ToUpper)
                        End If


                        Console.Write("Teléfono del empleado: ")
                        tel = Val(Console.ReadLine)
                        If (IsNumeric(tel)) Then
                            emp._telefono.Add(tel)
                        Else
                            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            opcion = Console.ReadLine()
                            If (opcion = "s") Then
                                Console.Write("Teléfono del empleado: ")
                                Dim tel2 As Integer = Console.ReadLine()
                                If IsNumeric(tel2) Then
                                    emp._telefono.Add(tel2)
                                Else
                                    ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                    Console.WriteLine("")
                                    Console.Write("Error al ingresar el dato (pulse cualquier tecla para volver al menú)")
                                    Console.ReadLine()
                                    Exit Select
                                End If
                            ElseIf (opcion = "n") Then
                                ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                Exit Select
                            End If
                        End If


                        Console.Write("Dirección del empleado: ")
                        emp._direccion.Add(Console.ReadLine.ToUpper)


                        Console.Write("Sueldo base del empleado: ")
                        sueldo = Val(Console.ReadLine)
                        If IsNumeric(sueldo) Then
                            emp._sueldo.Add(sueldo)
                        Else
                            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            opcion = Console.ReadLine
                            If (opcion = "s") Then
                                Console.Write("Sueldo base del empleado: ")
                                Dim sueldo2 As Double = Double.Parse(Console.ReadLine())
                                If IsNumeric(sueldo2) Then
                                    emp._sueldo.Add(sueldo2)
                                Else
                                    ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                    Console.WriteLine("")
                                    Console.Write("Error al ingresar el dato (pulse cualquier tecla para volver al menú)")
                                    Console.ReadLine()
                                    Exit Select
                                End If
                            ElseIf (opcion = "n") Then
                                ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                Exit Select
                            End If
                        End If


                        Console.Write("Tipo de empleado(1.Gerente 2.Operario 3.Administrativo): ")
                        tipo = Console.ReadLine
                        If (tipo = 1 Or tipo = 2 Or tipo = 3) Then
                            emp._tipoEmpleado.Add(tipo)
                            cal.MontoIndividual(emp)
                        Else
                            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            opcion = Console.ReadLine
                            If (opcion = "s") Then
                                Console.Write("Tipo de empleado(1.Gerente 2.Operario 3.Administrativo): ")
                                Dim tipo2 As Integer = Console.ReadLine
                                If (tipo2 = 1 Or tipo2 = 2 Or tipo2 = 3) Then
                                    emp._tipoEmpleado.Add(tipo)
                                    cal.MontoIndividual(emp)
                                Else
                                    ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                    Console.WriteLine("")
                                    Console.Write("Error al ingresar el dato (pulse cualquier tecla para volver al menú)")
                                    Console.ReadLine()
                                    Exit Select
                                End If
                            ElseIf (opcion = "n") Then
                                ver.borrarDatos(emp, nom, ced, ape, dire, tel, sueldo, tipo)
                                Exit Select
                            End If
                        End If

                    Catch ex As Exception
                        Console.Write("Ocurrió un error inesperado")
                        Console.ReadLine()
                        Exit Select
                    End Try

                Case 2
                    Console.Clear()
                    Dim mostrarTipo As String = ""
                    Console.WriteLine("Cédula | Nombre | Apellido | Teléfono | Dirección | Sueldo base | Tipo de funcionario | Sueldo total")
                    For i As Integer = 0 To emp._cedula.Count - 1
                        If (emp._tipoEmpleado.Item(i) = 1) Then
                            mostrarTipo = "Gerente"
                        ElseIf (emp._tipoEmpleado.Item(i) = 2) Then
                            mostrarTipo = "Operario"
                        ElseIf (emp._tipoEmpleado.Item(i) = 3) Then
                            mostrarTipo = "Administrativo"
                        End If
                        Console.WriteLine("")
                        Console.Write(emp._cedula.Item(i) + " | ")
                        Console.Write(emp._nombre.Item(i) + " | ")
                        Console.Write(emp._apellido.Item(i) + " | ")
                        Console.Write(emp._telefono.Item(i) & " | ")
                        Console.Write(emp._direccion.Item(i) + " | ")
                        Console.Write(emp._sueldo.Item(i) & " | ")
                        Console.Write(mostrarTipo + " | ")
                        Console.Write(emp._sueldoTotal.Item(i))

                    Next
                    If (emp._cedula.Count <> 0) Then
                        Console.WriteLine("")
                        Console.WriteLine("El monto total a pagarle a todos los funcionarios es: " & cal.MontoTotal(emp))
                    Else
                        Console.Write("No hay datos para mostrar")
                        Console.WriteLine("")
                    End If
                    Console.WriteLine("")
                    Console.WriteLine("Pulse cualquier tecla para volver")
                    Console.ReadLine()

                Case 3
                    Exit Do

                Case Else
                    Console.Write("Ingresó una opción incorrecta")
                    Console.ReadLine()

            End Select

        Loop

    End Sub

End Module
