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
                    Console.Write("Cédula del empleado: ")
                    emp._cedula.Add(Console.ReadLine)
                    Console.Write("Nombre del empleado: ")
                    emp._nombre.Add(Console.ReadLine.ToUpper)
                    Console.Write("Apellido del empleado: ")
                    emp._apellido.Add(Console.ReadLine.ToUpper)
                    Console.Write("Sueldo del empleado: ")
                    emp._sueldo.Add(Console.ReadLine)
                    Console.Write("Tipo de empleado: ")
                    emp._tipoEmpleado.Add(Console.ReadLine)

                Case 2
                    For i As Integer = 0 To emp._cedula.Count - 1

                        Console.WriteLine(emp._cedula.Item(i) & " | " & emp._nombre.Item(i) & " | " & emp._apellido.Item(i) & " | " & emp._sueldo.Item(i) & " | " & emp._tipoEmpleado.Item(i))

                    Next
                    Console.WriteLine(cal.MontoTotal(emp))
                    Console.WriteLine("Pulse cualquier tecla para volver")
                    Console.ReadLine()

                Case Else
                    Exit Select

            End Select

        Loop

    End Sub

End Module
