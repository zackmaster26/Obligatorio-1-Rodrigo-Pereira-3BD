Imports Logica

Module Module1

    'Variables
    Private cal As New Calculo
    Private met As New Metodo
    Private datos As New Datos

    Private op As Byte = 10

    Private ced As String
    Private repCed As Boolean = False
    Private nom As String
    Private nom2 As String
    Private ape As String
    Private ape2 As String
    Private tel As String
    Private sueldo As String
    Private tipo As Char
    Private dire As String
    Private opcion As Char
    Private salirBoolean As Boolean = False
    Private contador As Integer = 0
    Private bajaLogica As Integer = 0

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
            Console.WriteLine("4) Dar de baja empleados")
            Console.WriteLine("0) Salir")
            Console.Write(vbNewLine)
            Console.Write("Opción: ")

            Try
                op = Byte.Parse(Console.ReadLine())
            Catch ex As Exception

            End Try

            Select Case op

                Case 1

                    Dim index As Integer
                    Dim baja As Integer = False

                    Console.Clear()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("-------------------------------------------------REGISTRO DE EMPLEADOS-------------------------------------------------")
                    Console.SetCursorPosition(47.5, 1)
                    Console.Write(" (Ingrese ! para salir)")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine(vbNewLine)

                    Try

                        Console.Write("Cédula (sin puntos ni guión): ")
                        ced = Console.ReadLine()

                        If salir(ced) Then
                            vaciar()
                            Exit Select
                        Else
                            If IsNumeric(ced) Then

                                If (met.verificarCedula(datos, Integer.Parse(ced), repCed)) Then
                                    If met.digitoVerificador(Integer.Parse(ced)) Then
                                    Else
                                        opIncorrecta("El dígito verificador ingresado no es correcto")
                                        vaciar()
                                        Exit Select
                                    End If
                                Else
                                    For k As Integer = 0 To datos._cedula.Count - 1
                                        If (datos._cedula.Item(k) = ced) Then
                                            If (datos._bajaLogica.GetValue(k, 0) = ced) Then
                                                If (datos._bajaLogica.GetValue(k, 1) = 0) Then
                                                    index = k
                                                    baja = True
                                                End If
                                            End If

                                        End If
                                    Next

                                    If (baja) Then

                                        Console.Write(vbNewLine)
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.ForegroundColor = ConsoleColor.Red
                                        Console.Write("Este usuario fue dado de baja. ¿Desea reintegrarlo? (s/n): ")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Dim op As Char = Console.ReadLine.ToUpper

                                        If op = "S" Then
                                            datos._bajaLogica(index, 1) = 1
                                            opIncorrecta("Empleado dado de alta")
                                            Exit Select

                                        ElseIf op = "N" Then
                                            vaciar()
                                            Exit Select

                                        End If

                                    End If

                                    opIncorrecta("La cédula ingresada ya existe o ingresó un formato incorrecto")
                                    vaciar()
                                    Exit Select

                                End If

                            Else
                                opIncorrecta("La cédula no debe contener caracteres")
                                Exit Select
                            End If
                        End If

                        'Nombre

                        Console.Write("Nombre: ")
                        nom = Console.ReadLine()

                        If (salir(nom)) Then
                            vaciar()
                            Exit Select
                        Else
                            If (ingresarString("Nombre: ", nom) = False) Then
                                vaciar()
                                Exit Select
                            End If
                        End If

                        'Segundo nombre

                        Console.Write("Segundo nombre (si no posee digite 0): ")
                        nom2 = Console.ReadLine().ToUpper

                        If (nom2 <> "0") Then

                            If (salir(nom2)) Then
                                vaciar()
                                Exit Select
                            Else
                                If (ingresarString("Segundo nombre (si no posee digite 0): ", nom2.ToUpper) = False) Then
                                    vaciar()
                                    Exit Select
                                End If
                            End If

                        Else
                            nom2 = Nothing
                        End If

                        'Apellido

                        Console.Write("Apellido: ")
                        ape = Console.ReadLine()

                        If (salir(ape)) Then
                            vaciar()
                            Exit Select
                        Else
                            If (ingresarString("Apellido: ", ape) = False) Then
                                vaciar()
                                Exit Select
                            End If

                        End If

                        'Segundo apellido

                        Console.Write("Segundo apellido: ")
                        ape2 = Console.ReadLine()

                        If (salir(ape2)) Then
                            vaciar()
                            Exit Select
                        Else
                            If (ingresarString("Segundo apellido: ", ape2) = False) Then
                                vaciar()
                                Exit Select
                            End If
                        End If

                        'Teléfono

                        tel = 10
                        Dim numero As Byte = 0

                        While Integer.Parse(tel) <> 0

                            Console.Write("Teléfono " & numero + 1 & " (0 para continuar): ")
                            tel = Console.ReadLine

                            If salir(tel) Then
                                tel = 10
                                met.borrarTelefono(datos, ced)
                                vaciar()
                                Exit Select
                            Else
                                numero += 1

                                If IsNumeric(tel) Then
                                    If (Integer.Parse(tel) = 0 And numero = 1) Then
                                        opIncorrecta("El empleado debe tener al menos un teléfono")
                                        met.borrarTelefono(datos, ced)
                                        vaciar()
                                        Exit Select
                                    Else
                                        If tel <> 0 Then
                                            datos._tel(contador, 0) = ced
                                            datos._tel(contador, 1) = tel
                                            contador += 1
                                        End If
                                    End If

                                Else
                                    tel = 10
                                    opIncorrecta("Error al ingresar el dato")
                                    met.borrarTelefono(datos, ced)
                                    vaciar()
                                    Exit Select
                                End If

                            End If

                        End While
                        tel = 10

                        'Dirección

                        Console.Write("Dirección: ")
                        dire = Console.ReadLine

                        If salir(dire) Then
                            met.borrarTelefono(datos, ced)
                            vaciar()
                            Exit Select
                        End If

                        'Sueldo

                        Console.Write("Sueldo base: ")
                        sueldo = Console.ReadLine()

                        If salir(sueldo) Then
                            met.borrarTelefono(datos, ced)
                            vaciar()
                            Exit Select
                        End If

                        If (met.verificarSueldo(sueldo) = False) Then

                            Console.Write(vbNewLine)
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            Console.ForegroundColor = ConsoleColor.White
                            opcion = Console.ReadLine.ToUpper
                            Console.Write(vbNewLine)

                            If (opcion = "S") Then
                                Console.Write("Sueldo base: ")
                                sueldo = Console.ReadLine()

                                If salir(sueldo) Then
                                    met.borrarTelefono(datos, ced)
                                    vaciar()
                                    Exit Select
                                Else

                                    If (met.verificarSueldo(sueldo) = False) Then
                                        opIncorrecta("Error al ingresar el dato")
                                        met.borrarTelefono(datos, ced)
                                        vaciar()
                                        Exit Select
                                    End If

                                End If

                            ElseIf (opcion = "N") Then
                                met.borrarTelefono(datos, ced)
                                vaciar()
                                Exit Select
                            End If

                        End If

                        'Cargo

                        Console.Write("Cargo del empleado (1.Gerente 2.Operario 3.Administrativo): ")
                        tipo = Console.ReadLine

                        If salir(tipo) Then
                            met.borrarTelefono(datos, ced)
                            vaciar()
                            Exit Select
                        End If

                        If (met.verificarTipo(tipo) = False) Then

                            Console.Write(vbNewLine)
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.Write("Error al ingresar los datos. ¿Desea repetir? (s/n): ")
                            Console.ForegroundColor = ConsoleColor.White
                            opcion = Console.ReadLine.ToUpper
                            Console.Write(vbNewLine)

                            If (opcion = "S") Then
                                Console.Write("Cargo del empleado (1.Gerente 2.Operario 3.Administrativo): ")
                                tipo = Console.ReadLine

                                If salir(tipo) Then
                                    met.borrarTelefono(datos, ced)
                                    vaciar()
                                    Exit Select
                                Else

                                    If (met.verificarTipo(tipo) = False) Then
                                        opIncorrecta("Error al ingresar los datos")
                                        met.borrarTelefono(datos, ced)
                                        vaciar()
                                        Exit Select
                                    End If

                                End If

                            ElseIf (opcion = "N") Then
                                met.borrarTelefono(datos, ced)
                                vaciar()
                                Exit Select
                            End If

                        End If


                        Dim emp = New Empleado(ced, nom, ape, nom2, ape2, dire, Integer.Parse(tipo), Integer.Parse(sueldo))
                        datos.agregarEmpleado(emp)

                        datos._bajaLogica(bajaLogica, 0) = ced
                        datos._bajaLogica(bajaLogica, 1) = 1
                        bajaLogica += 1

                        opIncorrecta("Datos ingresados correctamente")

                    Catch ex As Exception
                        opIncorrecta("Ocurrió un error inesperado")
                        Exit Do
                    End Try

                Case 2

                    Console.Clear()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("-------------------------------------------------EMPLEADOS REGISTRADOS--------------------------------------------------")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.Write(vbNewLine)

                    Dim mostrarTipo As String = ""

                    For i As Integer = 0 To datos._cedula.Count - 1
                        For k As Integer = 0 To datos._bajaLogica.GetLength(0) - 1
                            If (datos._bajaLogica.GetValue(k, 0) = datos._cedula.Item(i)) Then
                                If (datos._bajaLogica.GetValue(k, 1) = 1) Then
                                    mostrarDatos(i, mostrarTipo)
                                    If (datos._cedula.Count > 1) Then
                                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------")
                                    End If
                                End If
                            End If
                        Next
                    Next

                    Dim rep As Boolean = False

                    If (datos._cedula.Count <> 0) Then
                        For i As Integer = 0 To datos._cedula.Count - 1
                            For k As Integer = 0 To datos._bajaLogica.GetLength(0) - 1
                                If (datos._cedula.Count >= 1 And datos._bajaLogica.GetValue(k, 0) = datos._cedula.Item(i)) Then
                                    If (datos._bajaLogica.GetValue(k, 1) = 1) Then
                                        rep = True
                                    End If
                                End If
                            Next
                        Next
                    End If

                    If ((datos._cedula.Count = 0) Or (datos._cedula.Count <> 0 And rep = False)) Then
                        Console.Write("No hay datos para mostrar")
                        Console.WriteLine("")
                    End If

                    If (rep) Then
                        Console.WriteLine("")
                        Console.Write("El monto total a pagarle a todos los funcionarios es: ")
                        Console.ForegroundColor = ConsoleColor.Blue
                        Console.WriteLine("$" & cal.montoTotal(datos))
                        Console.ForegroundColor = ConsoleColor.White
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

                    Dim index As Integer = 0
                    Dim repCed1 As Boolean = False
                    Dim opModificar As Byte = 10

                    If (datos._cedula.Count <> 0) Then
                        mostrarModificado("-------------------------------------------------MODIFICAR EMPLEADOS----------------------------------------------------", 47.5)
                        Console.Write("(Ingrese ! para salir)")
                        Console.ForegroundColor = ConsoleColor.White
                        Console.WriteLine(vbNewLine)

                        Console.Write("Cedula del empleado: ")
                        Dim busCed As String = Console.ReadLine()

                        If (salir(busCed)) Then
                            Exit Select
                        End If

                        For k As Integer = 0 To datos._cedula.Count - 1
                            If (datos._cedula.Item(k) = Integer.Parse(busCed)) Then
                                If (datos._bajaLogica.GetValue(k, 0) = Integer.Parse(busCed)) Then
                                    If (datos._bajaLogica.GetValue(k, 1) = 1) Then
                                        index = k
                                        repCed1 = True
                                    End If
                                End If
                            End If
                        Next

                        If (repCed1) Then

                            Do While opModificar <> 0

                                mostrarModificado("-------------------------------------------------MODIFICAR EMPLEADOS---------------------------------------------------", 0)
                                Console.ForegroundColor = ConsoleColor.White
                                Dim verificador As String = datos._cedula.Item(index)
                                If (verificador.Length = 8) Then
                                    Console.WriteLine("Identificación de empleado: " + verificador.Substring(0, 1) + "." + verificador.Substring(1, 3) + "." + verificador.Substring(4, 3) + "-" + verificador.Substring(7, 1))
                                ElseIf (verificador.Length = 7) Then
                                    Console.WriteLine("Identificación de empleado: " + verificador.Substring(0, 3) + "." + verificador.Substring(3, 3) + "-" + verificador.Substring(6, 1))
                                End If
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

                                Try
                                    opModificar = Byte.Parse(Console.ReadLine())
                                Catch ex As Exception

                                End Try

                                Select Case opModificar

                                    Case 1

                                        mostrarModificado("-----------------------------------------------------MODIFICAR NOMBRE---------------------------------------------------", 49)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)

                                        mostrar(datos._nombre, index, "Nombre: ", "Nombre nuevo: ")
                                        Dim nuevoNombre As String = Console.ReadLine

                                        If salir(nuevoNombre) Then
                                            Exit Select
                                        Else
                                            If (met.modificar(nuevoNombre)) Then
                                                datos._nombre.Insert(index, nuevoNombre.ToUpper)
                                                datos._nombre.RemoveAt(index + 1)
                                            End If
                                        End If

                                    Case 2

                                        If (datos._SegundoNombre.Item(index) IsNot Nothing) Then
                                            mostrarModificado("-----------------------------------------------MODIFICAR SEGUNDO NOMBRE-------------------------------------------------", 47)
                                            Console.Write(" (Ingrese ! para salir)")
                                            Console.ForegroundColor = ConsoleColor.White
                                            Console.Write(vbNewLine)

                                            mostrar(datos._SegundoNombre, index, "Segundo nombre: ", "Segundo nombre nuevo: ")
                                            Dim nuevoSegNombre As String = Console.ReadLine

                                            If salir(nuevoSegNombre) Then
                                                Exit Select
                                            Else
                                                If (met.modificar(nuevoSegNombre)) Then
                                                    datos._SegundoNombre.Insert(index, nuevoSegNombre.ToUpper)
                                                    datos._SegundoNombre.RemoveAt(index + 1)
                                                End If
                                            End If

                                        Else
                                            opIncorrecta("Este empleado no tiene segundo nombre")
                                            Exit Select
                                        End If

                                    Case 3

                                        mostrarModificado("---------------------------------------------------MODIFICAR APELLIDO---------------------------------------------------", 47.5)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)

                                        mostrar(datos._apellido, index, "Apellido: ", "Apellido nuevo: ")
                                        Dim nuevoApe As String = Console.ReadLine

                                        If salir(nuevoApe) Then
                                            Exit Select
                                        Else
                                            If (met.modificar(nuevoApe)) Then
                                                datos._apellido.Insert(index, nuevoApe.ToUpper)
                                                datos._apellido.RemoveAt(index + 1)
                                            End If
                                        End If

                                    Case 4

                                        mostrarModificado("------------------------------------------------MODIFICAR SEGUNDO APELLIDO----------------------------------------------", 49)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)

                                        mostrar(datos._SegundoApellido, index, "Segundo apellido: ", "Segundo apellido nuevo: ")
                                        Dim nuevoSegApe As String = Console.ReadLine

                                        If salir(nuevoSegApe) Then
                                            Exit Select
                                        Else
                                            If (met.modificar(nuevoSegApe)) Then
                                                datos._SegundoApellido.Insert(index, nuevoSegApe.ToUpper)
                                                datos._SegundoApellido.RemoveAt(index + 1)
                                            End If
                                        End If

                                    Case 5

                                        Dim num As Byte = 0
                                        Dim aux As New ArrayList

                                        mostrarModificado("---------------------------------------------------MODIFICAR TELEFONOS--------------------------------------------------", 47.5)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)

                                        For k As Integer = 0 To datos._tel.GetLength(0) - 1

                                            If (datos._tel.GetValue(k, 0) = datos._cedula.Item(index)) Then
                                                If (datos._tel.GetValue(k, 1) <> 0) Then
                                                    Console.WriteLine("Teléfono " & num + 1 & ": " & datos._tel.GetValue(k, 1))
                                                    num += 1
                                                    aux.Add(k)
                                                End If
                                            End If
                                        Next

                                        Console.Write(vbNewLine)
                                        Console.WriteLine("1) Modificar")
                                        Console.WriteLine("2) Eliminar")
                                        Console.Write("Opción: ")
                                        Dim opTel As String = Console.ReadLine

                                        If salir(opTel) Then
                                            Exit Select
                                        Else
                                            If (Byte.Parse(opTel) = 1) Then

                                                Console.Write(vbNewLine)
                                                Console.Write("¿Qué telefono desea modificar?: ")
                                                Dim modTel As String = Console.ReadLine

                                                If (modTel <> "") Then

                                                    If (Byte.Parse(modTel) > num Or Byte.Parse(modTel) = 0) Then
                                                        Exit Select
                                                    Else
                                                        Console.Write("Nuevo teléfono: ")
                                                        Dim telString As String = Console.ReadLine

                                                        If (telString <> "") Then
                                                            If (met.modificarTel(datos, aux, num, Byte.Parse(modTel), opTel, telString) = False) Then
                                                                opIncorrecta("Ingresó una opción incorrecta")
                                                                Exit Select
                                                            End If
                                                        Else
                                                            Exit Select
                                                        End If

                                                    End If
                                                Else
                                                    opIncorrecta("No ingresó ningún dato")
                                                    Exit Select
                                                End If

                                            ElseIf (opTel = 2) Then

                                                Console.Write(vbNewLine)
                                                Console.Write("¿Qué telefono desea modificar?: ")
                                                Dim modTel As String = Console.ReadLine

                                                If (modTel <> "") Then
                                                    If (Byte.Parse(modTel) > num Or Byte.Parse(modTel) = 0) Then
                                                        Exit Select
                                                    Else
                                                        If (num > 1) Then
                                                            If (met.eliminarTel(datos, aux, num, modTel, opTel) = False) Then
                                                                opIncorrecta("Ingresó una opción incorrecta")
                                                                Exit Select
                                                            End If
                                                        Else
                                                            opIncorrecta("El empleado no puede quedar sin ningún teléfono")
                                                        End If

                                                    End If
                                                End If

                                            ElseIf (opTel <> 1 And opTel <> 2) Then
                                                opIncorrecta("Ingresó una opción incorrecta")
                                                Exit Select
                                            End If

                                        End If

                                    Case 6

                                        mostrarModificado("----------------------------------------------------MODIFICAR DIRECCIÓN----------------------------------------------------", 47.5)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)
                                        mostrar(datos._direccion, index, "Dirección: ", "Dirección nueva: ")

                                        Dim nuevadireccion As String = Console.ReadLine

                                        If salir(nuevadireccion) Then
                                            Exit Select
                                        Else
                                            If (met.modificar(nuevadireccion)) Then
                                                datos._direccion.Insert(index, nuevadireccion.ToUpper)
                                                datos._direccion.RemoveAt(index + 1)
                                            End If
                                        End If

                                    Case 7

                                        mostrarModificado("----------------------------------------------------MODIFICAR SUELDO----------------------------------------------------", 47.5)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)
                                        mostrar(datos._sueldo, index, "Sueldo: ", "Sueldo nuevo: ")

                                        Dim nuevoSueldo As String = Console.ReadLine

                                        If salir(nuevoSueldo) Then
                                            Exit Select
                                        Else
                                            If IsNumeric(nuevoSueldo) Then
                                                datos._sueldo.Insert(index, Integer.Parse(nuevoSueldo))
                                                datos._sueldo.RemoveAt(index + 1)
                                            End If
                                        End If

                                    Case 8

                                        mostrarModificado("----------------------------------------------------MODIFICAR CARGO----------------------------------------------------", 47.5)
                                        Console.Write(" (Ingrese ! para salir)")
                                        Console.ForegroundColor = ConsoleColor.White
                                        Console.Write(vbNewLine)

                                        If (datos._tipoEmpleado.Item(index) = 1) Then
                                            Console.WriteLine("Cargo: Gerente")
                                        ElseIf (datos._tipoEmpleado.Item(index) = 2) Then
                                            Console.WriteLine("Cargo: Operario")
                                        ElseIf (datos._tipoEmpleado.Item(index) = 3) Then
                                            Console.WriteLine("Cargo: Administrativo")
                                        End If

                                        Console.Write(vbNewLine)
                                        Console.Write("Nuevo cargo (1.Gerente 2.Operario 3.Administrativo): ")
                                        Dim nuevoCargo As String = Console.ReadLine


                                        If salir(nuevoCargo) Then
                                            Exit Select
                                        Else
                                            datos._tipoEmpleado.Insert(index, Integer.Parse(nuevoCargo))
                                            datos._tipoEmpleado.RemoveAt(index + 1)
                                        End If

                                    Case 0

                                        Exit Do

                                    Case Else

                                        opIncorrecta("Ingresó una opción incorrecta")
                                        Exit Do

                                End Select
                            Loop
                        Else
                            opIncorrecta("Esta cédula no existe en el sistema")
                            Exit Select
                        End If

                    Else
                        opIncorrecta("No se encuentran empleados ingresados")
                    End If


                Case 4

                    If (datos._cedula.Count <> 0) Then
                        Console.Clear()
                        Console.ForegroundColor = ConsoleColor.Cyan
                        Console.Write("-------------------------------------------------DAR DE BAJA EMPLEADOS-------------------------------------------------")
                        Console.Write(vbNewLine)
                        Console.ForegroundColor = ConsoleColor.White
                        Console.Write(vbNewLine)
                        Console.Write("Cedula del empleado: ")
                        Dim busCed As String = Console.ReadLine()

                        If salir(busCed) Then
                            Exit Select
                        Else
                            For k As Integer = 0 To datos._cedula.Count - 1
                                If (IsNumeric(busCed)) Then
                                    If (datos._cedula.Item(k) = Integer.Parse(busCed)) Then
                                        If (datos._bajaLogica.GetValue(k, 0) = Integer.Parse(busCed)) Then
                                            If (datos._bajaLogica.GetValue(k, 1) = 1) Then
                                                Console.Write(vbNewLine)
                                                Console.ForegroundColor = ConsoleColor.Red
                                                Console.Write("¿Desea dar de baja a este empleado? (s/n): ")
                                                Console.ForegroundColor = ConsoleColor.White
                                                Dim opcion As Char = Console.ReadLine

                                                If opcion = "s" Then

                                                    For x As Integer = 0 To datos._bajaLogica.GetLength(0) - 1
                                                        If (datos._bajaLogica.GetValue(x, 0) = datos._cedula.Item(k)) Then
                                                            datos._bajaLogica.SetValue(0, x, 1)
                                                        End If
                                                    Next

                                                    opIncorrecta("Empleado dado de baja con éxito")

                                                    Exit Select

                                                ElseIf (opcion = "n") Then

                                                    Exit Select

                                                ElseIf (opcion <> "s" Or opcion <> "n") Then

                                                    opIncorrecta("Ingresó una opción incorrecta")
                                                    Exit Select

                                                End If

                                            Else
                                                opIncorrecta("El empleado ya fue dado de baja")
                                            End If
                                        End If
                                    Else
                                        opIncorrecta("La cédula ingresada no es correcta")
                                        Exit Select
                                    End If
                                Else
                                    opIncorrecta("No se deben ingresar caracteres")
                                    Exit Select
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

    Function ingresarString(texto As String, dato As String) As Boolean

        If (met.verificarString(dato) = False) Then

            Console.Write(vbNewLine)
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Ha habido un error al ingresar los datos. ¿Desea repetir? (s/n): ")
            Console.ForegroundColor = ConsoleColor.White
            opcion = Console.ReadLine.ToUpper
            Console.Write(vbNewLine)

            If (opcion = "S") Then
                Console.Write(texto)
                dato = Console.ReadLine()

                If (salir(dato)) Then
                    Return False
                Else
                    If (met.verificarString(dato) = True) Then
                        Return True
                    Else
                        opIncorrecta("No debe contener caracteres numéricos")
                        Return False
                    End If
                End If

            ElseIf (opcion = "N") Then
                Return False
            End If
        Else
            Return True
        End If

        Return True
    End Function

    Function salir(dato As String) As Boolean

        If (dato = "") Then
            opIncorrecta("No ingresó ningún dato")
            Return True
        End If

        If (dato = "!") Then
            Return True
        End If

        Return False
    End Function

    Private Sub vaciar()
        ced = Nothing
        repCed = Nothing
        nom = Nothing
        nom2 = Nothing
        ape = Nothing
        ape2 = Nothing
        tel = Nothing
        sueldo = Nothing
        tipo = Nothing
        dire = Nothing
    End Sub

    Private Sub mostrarDatos(i As Integer, mostrarTipo As String)

        If (datos._tipoEmpleado.Item(i) = 1) Then
            mostrarTipo = "Gerente"
        ElseIf (datos._tipoEmpleado.Item(i) = 2) Then
            mostrarTipo = "Operario"
        ElseIf (datos._tipoEmpleado.Item(i) = 3) Then
            mostrarTipo = "Administrativo"
        End If

        Dim verificador As String = datos._cedula.Item(i)
        If (verificador.Length = 8) Then
            Console.WriteLine("Cédula: " + verificador.Substring(0, 1) + "." + verificador.Substring(1, 3) + "." + verificador.Substring(4, 3) + "-" + verificador.Substring(7, 1))
        ElseIf (verificador.Length = 7) Then
            Console.WriteLine("Cédula: " + verificador.Substring(0, 3) + "." + verificador.Substring(3, 3) + "-" + verificador.Substring(6, 1))
        End If
        Console.Write("Nombre: " + datos._nombre.Item(i) + " ")

        If (datos._SegundoNombre.Item(i) Is Nothing) Then
            Console.Write(vbNewLine)
        Else
            Console.WriteLine(datos._SegundoNombre.Item(i))
        End If

        Console.Write("Apellido: " + datos._apellido.Item(i) + " ")
        Console.WriteLine(datos._SegundoApellido.Item(i))
        Console.WriteLine("Dirección: " + datos._direccion.Item(i))
        Console.Write("Teléfonos: ")

        Dim cont As Integer = 0
        For j As Integer = 0 To datos._tel.GetLength(0) - 1
            If (datos._tel.GetValue(j, 0) = datos._cedula.Item(i)) Then
                If (datos._tel.GetValue(j, 1) <> 0) Then
                    Console.Write(cont + 1 & ") ")
                    Console.Write(datos._tel.GetValue(j, 1))
                    Console.Write("   ")
                    cont += 1
                End If
            End If
        Next

        Console.Write(vbNewLine)
        Console.WriteLine("Cargo: " + mostrarTipo)
        Console.WriteLine("Sueldo base: " + "$" & datos._sueldo.Item(i))
        Console.WriteLine("Sueldo neto: " + "$" & cal.sueldoNeto(datos, i))

    End Sub

    Private Sub mostrar(array As ArrayList, i As Integer, texto1 As String, texto2 As String)
        Console.WriteLine(texto1 & array.Item(i))
        Console.Write(vbNewLine)
        Console.Write(texto2)
    End Sub

    Private Sub opIncorrecta(texto As String)
        Console.CursorVisible = False
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(vbNewLine)
        Console.Write(texto)
        Threading.Thread.Sleep(1500)
        Console.CursorVisible = True
    End Sub

    Private Sub mostrarModificado(texto As String, i As Double)
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine(texto)
        Console.SetCursorPosition(i, 1)
    End Sub

End Module
