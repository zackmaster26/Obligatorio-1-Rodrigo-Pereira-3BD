Public Class Empleado

    Private cedula As New ArrayList
    Private nombre As New ArrayList
    Private apellido As New ArrayList
    Private direccion As New ArrayList
    Private telefono As New ArrayList
    Private sueldo As New ArrayList
    Private tipoEmpleado As New ArrayList

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
            Return sueldo
        End Get
        Set(value As ArrayList)
            sueldo = value
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


End Class
