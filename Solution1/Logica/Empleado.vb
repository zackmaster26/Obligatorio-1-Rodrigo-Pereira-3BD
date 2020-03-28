Public Class Empleado

    Private cedula As New ArrayList
    Private nombre As New ArrayList
    Private apellido As New ArrayList
    Private direccion As New ArrayList
    Private telefonos(999, 1) As Double
    Private sueldoBase As New ArrayList
    Private tipoEmpleado As New ArrayList
    Private sueldoTotal As New ArrayList


    Public Property _cedula As ArrayList
        Get
            Return cedula
        End Get
        Set(value As ArrayList)
            cedula = value
        End Set
    End Property

    Public Property _nombre As ArrayList
        Get
            Return nombre
        End Get
        Set(value As ArrayList)
            nombre = value
        End Set
    End Property

    Public Property _apellido As ArrayList
        Get
            Return apellido
        End Get
        Set(value As ArrayList)
            apellido = value
        End Set
    End Property

    Public Property _sueldo As ArrayList
        Get
            Return sueldoBase
        End Get
        Set(value As ArrayList)
            sueldoBase = value
        End Set
    End Property

    Public Property _tipoEmpleado As ArrayList
        Get
            Return tipoEmpleado
        End Get
        Set(value As ArrayList)
            tipoEmpleado = value
        End Set
    End Property

    Public Property _sueldoTotal As ArrayList
        Get
            Return sueldoTotal
        End Get
        Set(value As ArrayList)
            sueldoTotal = value
        End Set
    End Property

    Public Property _direccion As ArrayList
        Get
            Return direccion
        End Get
        Set(value As ArrayList)
            direccion = value
        End Set
    End Property

    Public Property tel As Double(,)
        Get
            Return telefonos
        End Get
        Set(value As Double(,))
            telefonos = value
        End Set
    End Property

End Class
