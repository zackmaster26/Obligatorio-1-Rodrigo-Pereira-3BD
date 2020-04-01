Imports Logica

Module Module1

    Private emp As New Empleado
    Private cal As New Calculo
    Private met As New Metodos

    Private op As Byte = 10

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

    Private Sub mostrar(array As ArrayList, i As Integer, texto1 As String, texto2 As String)
        Console.WriteLine(texto1 & array.Item(i))
        Console.Write(vbNewLine)
        Console.Write(texto2)
    End Sub

    Private Sub opIncorrecta(texto As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(vbNewLine)
        Console.CursorVisible = False
        Console.Write(texto)
        Console.ForegroundColor = ConsoleColor.White
        Threading.Thread.Sleep(1500)
        Console.CursorVisible = True
    End Sub

    Sub Main()

        Console.Title = "Sistema de Registro"
        Console.ForegroundColor = ConsoleColor.White

        Do While op <> 0

            Console.Clear()
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.Write("----------------------------------------------------------MENÚ----------------------------------------------------------")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine(vbNewLine)
            Console.WriteLine("1) Registro de Empleados")
            Console.WriteLine("2) Importe total a pagar por concepto de sueldo")
            Console.WriteLine("3) Modificación de empleados")
            Console.WriteLine("0) Salir")
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

                    'Try

                    Console.Write("Cédula (sin puntos ni guión): ")
                    ced1 = Console.ReadLine()
                    If (met.sinDatos(ced1) = False) Then
                        met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                        vaciar()
                        Exit Select
                    Else
                        If (met.salir(ced1, "Se borraron los datos ingresados", 1500) = False) Then
                            vaciar()
                            Exit Select
                        End If
                        If IsNumeric(ced1) Then
                            ced = ced1
                        Else
                            opIncorrecta("La cédula no debe contener caracteres")
                            Exit Select
                        End If
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
                        If (met.salir(nom, "Se borraron los datos ingresados", 1500) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        End If
                        If (met.verificarString(nom, emp._nombre, "Nombre: ") = False) Then
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
                        If (met.salir(nom2, "Se borraron los datos ingresados", 1500) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        End If
                        If (nom2 <> "0") Then
                            If (met.verificarString(nom2, emp._SegundoNombre, "Segundo nombre (si no posee digite 0): ") = False) Then
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
                        If (met.salir(ape, "Se borraron los datos ingresados", 1500) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        End If
                        If (met.verificarString(ape, emp._apellido, "Apellido: ") = False) Then
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
                        If (met.salir(ape2, "Se borraron los datos ingresados", 1500) = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        End If
                        If (met.verificarString(ape2, emp._SegundoApellido, "Segundo apellido: ") = False) Then
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        End If
                    End If


                    Console.Write("¿Cuántos telefonos desea ingresar?: ")
                    Dim ingString As String = Console.ReadLine
                    If (met.salir(ingString, "Se borraron los datos ingresados", 1500)) Then
                        If (met.sinDatos(ingString)) Then
                            If IsNumeric(ingString) Then
                                Dim ing As Byte = ingString
                                For i As Integer = 0 To ing - 1
                                    Console.Write("Teléfono " & i + 1 & ": ")
                                    tel1 = Console.ReadLine
                                    If (met.salir(tel1, "Se borraron los datos ingresados", 1500) = False) Then
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
                            Else
                                opIncorrecta("No debe ingresar caracteres")
                                met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                                vaciar()
                                Exit Select
                            End If
                        Else
                            met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                            vaciar()
                            Exit Select
                        End If
                    Else
                        met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                        vaciar()
                        Exit Select
                    End If


                    Console.Write("Dirección: ")
                    dire = Console.ReadLine
                    If met.sinDatos(dire) = False Then
                        met.borrarDatos(emp, nom, ced1, ape, nom2, ape2, dire, sueldo1, tipo)
                        vaciar()
                        Exit Select
                    Else
                        If (met.salir(dire, "Se borraron los datos ingresados", 1500) = False) Then
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
                        If (met.salir(sueldo1, "Se borraron los datos ingresados", 1500) = False) Then
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
                        If (met.salir(tipo, "Se borraron los datos ingresados", 1500) = False) Then
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


                    'Catch ex As Exception
                    '    mostrar("Ocurrió un error inesperado")
                    '    Exit Do
                    'End Try

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

                        Dim verificador As String = emp._cedula.Item(i)
                        If (verificador.Length = 8) Then
                            Console.WriteLine("Cédula: " + verificador.Substring(0, 1) + "." + verificador.Substring(1, 3) + "." + verificador.Substring(4, 3) + "-" + verificador.Substring(7, 1))
                        ElseIf (verificador.Length = 7) Then
                            Console.WriteLine("Cédula: " + verificador.Substring(0, 3) + "." + verificador.Substring(3, 3) + "-" + verificador.Substring(6, 1))
                        End If
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

                        Dim barrita As Integer = 0
                        For j As Integer = 0 To emp._tel.GetLength(0) - 1
                            If (emp._tel.GetValue(j, 0) = emp._cedula.Item(i)) Then
                                If (emp._tel.GetValue(j, 1) <> 0) Then
                                    Console.Write(emp._tel.GetValue(j, 1))
                                    If (j = Nothing) Then
                                        Console.Write(" - ")
                                    End If
                                End If
                            End If
                        Next

                        Console.Write(vbNewLine)
                        Console.WriteLine("Cargo: " + mostrarTipo)
                        Console.WriteLine("Sueldo base: " + "$" & emp._sueldo.Item(i))
                        Console.WriteLine("Sueldo neto: " + "$" & cal.SueldoNeto(emp, i))

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

                    Dim opModificar As Byte = 10

                    If (emp._cedula.Count <> 0) Then
                        Console.Clear()
                        Console.ForegroundColor = ConsoleColor.Cyan
                        Console.Write("-------------------------------------------------REGISTRO DE EMPLEADOS-------------------------------------------------")
                        Console.Write(vbNewLine)
                        Console.ForegroundColor = ConsoleColor.White
                        Console.Write(vbNewLine)
                        Console.Write("Cedula del empleado: ")
                        Dim cedd As String = Console.ReadLine()
                        If (met.sinDatos(cedd) = False) Then
                            Exit Select
                        Else
                            Dim busCed = cedd
                            For i As Integer = 0 To emp._cedula.Count - 1
                                If (emp._cedula.Item(i) = busCed) Then
                                    Console.Clear()

                                    Do While opModificar <> 0

                                        Console.Clear()
                                        Console.ForegroundColor = ConsoleColor.Cyan
                                        Console.WriteLine("-------------------------------------------------MODIFICAR EMPLEADOS---------------------------------------------------")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.WriteLine("Identificación de empleado: " + emp._cedula.Item(i))
                                        Console.Write(vbNewLine)
                                        Console.WriteLine("1) Nombre")
                                        Console.WriteLine("2) Segundo nombre")
                                        Console.WriteLine("3) Apellido")
                                        Console.WriteLine("4) Segundo apellido")
                                        Console.WriteLine("5) Teléfonos")
                                        Console.WriteLine("6) Dirección")
                                        Console.WriteLine("7) Sueldo")
                                        Console.WriteLine("8) Cargo")
                                        Console.WriteLine("0) Volver")
                                        Console.Write("Opción: ")

                                        opModificar = Integer.Parse(Console.ReadLine())

                                        Select Case opModificar

                                            Case 1

                                                Console.Clear()
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("-----------------------------------------------------MODIFICAR NOMBRE---------------------------------------------------")
                                                Console.SetCursorPosition(49, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                mostrar(emp._nombre, i, "Nombre: ", "Nombre nuevo: ")
                                                Dim nuevoNombre As String = Console.ReadLine
                                                If (met.salir(nuevoNombre, "", 0)) Then
                                                    If (met.sinDatos(nuevoNombre)) Then
                                                        If (met.modificar(nuevoNombre, i, emp._nombre) = False) Then
                                                            Exit Select
                                                        End If
                                                    Else
                                                        Exit Select
                                                    End If
                                                Else
                                                    Exit Select
                                                End If

                                            Case 2

                                                If (emp._SegundoNombre.Item(i) <> "no") Then
                                                    Console.Clear()
                                                    Console.ForegroundColor = ConsoleColor.Cyan
                                                    Console.WriteLine("-----------------------------------------------MODIFICAR SEGUNDO NOMBRE-------------------------------------------------")
                                                    Console.SetCursorPosition(47, 1)
                                                    Console.Write(" (Ingrese ! para salir)")
                                                    Console.ForegroundColor = ConsoleColor.White
                                                    Console.Write(vbNewLine)
                                                    mostrar(emp._SegundoNombre, i, "Segundo nombre: ", "Segundo nombre nuevo: ")
                                                    Dim nuevoSegNombre As String = Console.ReadLine
                                                    If (met.salir(nuevoSegNombre, "", 0)) Then
                                                        If (met.sinDatos(nuevoSegNombre)) Then
                                                            If (met.modificar(nuevoSegNombre, i, emp._SegundoNombre) = False) Then
                                                                Exit Select
                                                            End If
                                                        Else
                                                            Exit Select
                                                        End If
                                                    Else
                                                        Exit Select
                                                    End If
                                                Else
                                                    Console.CursorVisible = False
                                                    opIncorrecta("Este empleado no tiene segundo nombre")
                                                    Threading.Thread.Sleep(1500)
                                                    Exit Select
                                                    Console.CursorVisible = True
                                                End If

                                            Case 3

                                                Console.Clear()
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("---------------------------------------------------MODIFICAR APELLIDO---------------------------------------------------")
                                                Console.SetCursorPosition(47.5, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                mostrar(emp._apellido, i, "Apellido: ", "Apellido nuevo: ")
                                                Dim nuevoApe As String = Console.ReadLine
                                                If (met.salir(nuevoApe, "", 0)) Then
                                                    If (met.sinDatos(nuevoApe)) Then
                                                        If (met.modificar(nuevoApe, i, emp._apellido) = False) Then
                                                            Exit Select
                                                        End If
                                                    Else
                                                        Exit Select
                                                    End If
                                                Else
                                                    Exit Select
                                                End If

                                            Case 4

                                                Console.Clear()
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("------------------------------------------------MODIFICAR SEGUNDO APELLIDO----------------------------------------------")
                                                Console.SetCursorPosition(49, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                mostrar(emp._SegundoApellido, i, "Segundo apellido: ", "Segundo apellido nuevo: ")
                                                Dim nuevoSegApe As String = Console.ReadLine
                                                If (met.salir(nuevoSegApe, "", 0)) Then
                                                    If (met.sinDatos(nuevoSegApe)) Then
                                                        If (met.modificar(nuevoSegApe, i, emp._SegundoApellido) = False) Then
                                                            Exit Select
                                                        End If
                                                    Else
                                                        Exit Select
                                                    End If
                                                Else
                                                    Exit Select
                                                End If

                                            Case 5

                                                Console.Clear()
                                                Dim num As Byte = 0
                                                Dim aux As New ArrayList
                                                Dim modTel As Byte = 10
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("---------------------------------------------------MODIFICAR TELEFONOS--------------------------------------------------")
                                                Console.SetCursorPosition(47.5, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                For k As Integer = 0 To emp._tel.GetLength(0) - 1

                                                    If (emp._tel.GetValue(k, 0) = emp._cedula.Item(i)) Then
                                                        If (emp._tel.GetValue(k, 1) <> 0) Then
                                                            Console.WriteLine("Teléfono " & num + 1 & ": " & emp._tel.GetValue(k, 1))
                                                            num += 1
                                                            aux.Add(k)
                                                        End If
                                                    End If
                                                Next

                                                Console.Write(vbNewLine)
                                                Console.WriteLine("1) Modificar")
                                                Console.WriteLine("2) Eliminar")
                                                Console.Write("Opción: ")
                                                Dim opTel1 As String = Console.ReadLine
                                                If (met.salir(opTel1, "", 0) = False) Then
                                                    Exit Select
                                                Else
                                                    If (met.sinDatos(opTel1) = False) Then
                                                        Exit Select
                                                    Else
                                                        Dim opTel As Byte = opTel1
                                                        If (opTel = 1) Then
                                                            Console.Write(vbNewLine)
                                                            Console.Write("¿Qué telefono desea modificar?: ")
                                                            modTel = Byte.Parse(Console.ReadLine)
                                                            If (met.modificarTel(emp, i, aux, num, modTel, opTel) = False) Then
                                                                opIncorrecta("Ingresó una opción incorrecta")
                                                                Exit Select
                                                            End If
                                                        ElseIf (opTel = 2) Then
                                                            If (num > 1) Then
                                                                Console.Write(vbNewLine)
                                                                Console.Write("¿Qué telefono desea eliminar?: ")
                                                                modTel = Byte.Parse(Console.ReadLine)
                                                                If (met.eliminarTel(emp, i, aux, num, modTel, opTel) = False) Then
                                                                    opIncorrecta("Ingresó una opción incorrecta")
                                                                    Exit Select
                                                                End If
                                                            Else
                                                                opIncorrecta("No puede quedar sin ningún teléfono")
                                                            End If
                                                        ElseIf (opTel <> 1 And opTel <> 2) Then
                                                            opIncorrecta("Ingresó una opción incorrecta")
                                                            Exit Select
                                                        End If
                                                    End If
                                                End If


                                            Case 6

                                                Console.Clear()
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("--------------------------------------------------MODIFICAR DIRECCION--------------------------------------------------")
                                                Console.SetCursorPosition(47.5, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                mostrar(emp._direccion, i, "Dirección: ", "Dirección nueva: ")
                                                Dim nuevadireccion As String = Console.ReadLine
                                                If (met.salir(nuevadireccion, "", 0)) Then
                                                    If (met.sinDatos(nuevadireccion)) Then
                                                        If (met.modificar(nuevadireccion, i, emp._direccion) = False) Then
                                                            Exit Select
                                                        End If
                                                    Else
                                                        Exit Select
                                                    End If
                                                Else
                                                    Exit Select
                                                End If

                                            Case 7

                                                Console.Clear()
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("----------------------------------------------------MODIFICAR SUELDO----------------------------------------------------")
                                                Console.SetCursorPosition(47.5, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                mostrar(emp._sueldo, i, "Sueldo: ", "Sueldo nuevo: ")
                                                Dim nuevoSueldo As String = Console.ReadLine
                                                If (met.salir(nuevoSueldo, "", 0)) Then
                                                    If (met.sinDatos(nuevoSueldo) = False) Then
                                                        opIncorrecta("Ingresó una opción incorrecta")
                                                        Exit Select
                                                    Else
                                                        If IsNumeric(nuevoSueldo) Then
                                                            Dim nSueldo As Integer = nuevoSueldo
                                                            emp._sueldo.Insert(i, nSueldo)
                                                            emp._sueldo.RemoveAt(i + 1)
                                                        End If
                                                    End If
                                                Else
                                                    Exit Select
                                                End If

                                            Case 8

                                                Console.Clear()
                                                Console.ForegroundColor = ConsoleColor.Cyan
                                                Console.WriteLine("----------------------------------------------------MODIFICAR CARGO----------------------------------------------------")
                                                Console.SetCursorPosition(47.5, 1)
                                                Console.Write(" (Ingrese ! para salir)")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Console.Write(vbNewLine)
                                                If (emp._tipoEmpleado.Item(i) = 1) Then
                                                    Console.WriteLine("Cargo: Gerente")
                                                ElseIf (emp._tipoEmpleado.Item(i) = 2) Then
                                                    Console.WriteLine("Cargo: Operario")
                                                ElseIf (emp._tipoEmpleado.Item(i) = 3) Then
                                                    Console.WriteLine("Cargo: Administrativo")
                                                End If
                                                Console.Write(vbNewLine)
                                                Console.Write("Nuevo cargo (1.Gerente 2.Operario 3.Administrativo): ")
                                                Dim nuevoCargo As String = Console.ReadLine
                                                Dim nCargo As Integer
                                                If (met.salir(nCargo, "", 0)) Then
                                                    If (met.sinDatos(nuevoCargo)) Then
                                                        nCargo = nuevoCargo
                                                        emp._tipoEmpleado.Insert(i, nCargo)
                                                        emp._tipoEmpleado.RemoveAt(i + 1)
                                                    Else
                                                        Exit Select
                                                    End If
                                                End If

                                            Case 0

                                                Exit Select

                                            Case Else

                                                opIncorrecta("Ingresó una opción incorrecta")

                                        End Select
                                    Loop
                                Else
                                    opIncorrecta("Este usuario no está registrado en el sistema")
                                    busCed = Nothing
                                    cedd = Nothing

                                End If
                            Next
                        End If
                    Else
                        opIncorrecta("No se encuentran empleados registrados")
                        Exit Select
                    End If

                Case 0

                    Exit Do

                Case Else

                    opIncorrecta("Ingresó una opción incorrecta")

            End Select
        Loop
    End Sub

End Module
