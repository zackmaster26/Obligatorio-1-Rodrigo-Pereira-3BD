Imports Logica

Module Module1

    Sub Main()

        Dim op As Integer
        Dim emp As New Empleado
        Dim cal As New Calculo

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
                        Dim ced As String = Console.ReadLine()
                        Dim rep As Boolean = False
                        If (ced.Length = 7 Or ced.Length = 8) Then
                            emp._cedula.Add(ced)
                        Else
                            Console.Write("Debe ingresar una cédula válida(pulse cualquier tecla)")
                            Console.ReadLine()
                            Exit Select
                        End If
                        Console.Write("Nombre del empleado: ")
                        emp._nombre.Add(Console.ReadLine.ToUpper)
                        Console.Write("Apellido del empleado: ")
                        emp._apellido.Add(Console.ReadLine.ToUpper)
                        Console.Write("Dirección del empleado: ")
                        emp._direccion.Add(Console.ReadLine.ToUpper)
                        Console.Write("Teléfono del empleado: ")
                        emp._telefono.Add(Console.ReadLine.ToUpper)
                        Console.Write("Sueldo base del empleado: ")
                        emp._sueldo.Add(Console.ReadLine)
                        Console.Write("Tipo de empleado(1.Gerente 2.Operario 3.Administrativo): ")
                        emp._tipoEmpleado.Add(Console.ReadLine)
                        cal.MontoIndividual(emp)
                    Catch ex As Exception

                    End Try

                Case 2
                    Console.Clear()
                    For i As Integer = 0 To emp._cedula.Count - 1

                        Console.WriteLine(emp._cedula.Item(i) & " | " & emp._nombre.Item(i) & " | " & emp._apellido.Item(i) & " | " & emp._sueldo.Item(i) & " | " & emp._tipoEmpleado.Item(i) & " | " & "Sueldo total: " & emp._sueldoTotal.Item(i))

                    Next
                    If (emp._cedula.Count <> 0) Then
                        Console.WriteLine("")
                        Console.WriteLine("El monto total a pagar es: " & cal.MontoTotal(emp))
                    Else
                        Console.Write("No hay datos para mostrar")
                    End If
                    Console.WriteLine("")
                    Console.WriteLine("Pulse cualquier tecla para volver")
                    Console.ReadLine()

                Case Else
                    Console.Write("Ingresó una opción incorrecta")
                    Console.ReadLine()

            End Select

        Loop

    End Sub

End Module
