Imports Logica

Module Module1

    Sub Main()

        Dim emp As New Empleado
        Dim cal As New Calculo
        Dim met As New Metodos
        Dim op As Integer
        Dim ced As Integer
        Dim repCed As Boolean = False
        Dim nom As String
        Dim ape As String
        Dim tel As Double
        Dim sueldo1 As String
        Dim tipo As String
        Dim dire As String
        Dim contador As Integer = 0

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
                        If met.verificarCedula(ced, emp, repCed) = False Then
                            Exit Select
                        End If


                        Console.Write("Nombre del empleado: ")
                        nom = Console.ReadLine()
                        If (met.verificarNombre(nom, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, dire, sueldo1, tipo)
                            Exit Select
                        End If


                        Console.Write("Apellido del empleado: ")
                        ape = Console.ReadLine()
                        If (met.verificarApellido(ape, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, dire, sueldo1, tipo)
                            Exit Select
                        End If


                        Console.Write("¿Cuántos telefonos desea ingresar?: ")
                        Dim ing As Integer = Integer.Parse(Console.ReadLine)
                        For i As Integer = 0 To ing - 1
                            Console.Write("Teléfono " & i + 1 & ": ")
                            tel = Integer.Parse(Console.ReadLine)
                            emp.tel(contador, 0) = ced
                            emp.tel(contador, 1) = tel
                            contador = contador + 1
                        Next


                        Console.Write("Dirección del empleado: ")
                        dire = Console.ReadLine
                        emp._direccion.Add(dire.ToUpper)


                        Console.Write("Sueldo base del empleado: ")
                        sueldo1 = Console.ReadLine()
                        If (met.verificarSueldo(sueldo1, emp) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, dire, sueldo1, tipo)
                            Exit Select
                        End If


                        Console.Write("Tipo de empleado (1.Gerente 2.Operario 3.Administrativo): ")
                        tipo = Console.ReadLine
                        If (met.verificarTipo(tipo, emp, cal) = False) Then
                            met.borrarDatos(emp, nom, ced, ape, dire, sueldo1, tipo)
                            Exit Select
                        End If


                    Catch ex As Exception
                        Console.Write("Ocurrió un error inesperado")
                        Console.ReadLine()
                        Exit Do
                    End Try

                Case 2
                    Console.Clear()
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
                        Console.WriteLine("Nombre: " + emp._nombre.Item(i))
                        Console.WriteLine("Apellido: " + emp._apellido.Item(i))

                        Console.WriteLine("Dirección: " + emp._direccion.Item(i))
                        Console.Write("Teléfonos: ")

                        For j As Integer = 0 To emp.tel.GetLength(0) - 1
                            If (emp.tel.GetValue(j, 0) = emp._cedula.Item(i)) Then
                                Console.Write(emp.tel.GetValue(j, 1))
                                Console.Write(" - ")
                            End If
                        Next
                        Console.Write(vbNewLine)
                        Console.WriteLine("Funcionario: " + mostrarTipo)
                        Console.WriteLine("Sueldo base: " + "$" & emp._sueldo.Item(i))
                        Console.WriteLine("Sueldo total: " + "$" & emp._sueldoTotal.Item(i))

                        If (emp._cedula.Count > 1) Then
                            Console.WriteLine("--------------------------------------------------------------------------------------------- ")
                        End If
                    Next

                    If (emp._cedula.Count <> 0) Then
                        Console.WriteLine("")
                        Console.WriteLine("")
                        Console.WriteLine("El monto total a pagarle a todos los funcionarios es: " + "$" & cal.MontoTotal(emp))
                        Console.WriteLine("")
                    Else
                        Console.WriteLine("")
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
