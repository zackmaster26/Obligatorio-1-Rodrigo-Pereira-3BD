Public Class Persona

    Private cedula As String
    Private nombre As String
    Private apellido As String
    Private segundoNombre As String
    Private segundoApellido As String
    Private direccion As String

    Public Sub New(cedula As String, nombre As String, apellido As String, segundoNombre As String, segundoApellido As String, direccion As String)
        Me.cedula = cedula
        Me.nombre = nombre
        Me.apellido = apellido
        Me.segundoNombre = segundoNombre
        Me.segundoApellido = segundoApellido
        Me.direccion = direccion
    End Sub

    Public Property _cedula As String
        Get
            Return cedula
        End Get
        Set(value As String)
            cedula = value
        End Set
    End Property

    Public Property _nombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property _apellido As String
        Get
            Return apellido
        End Get
        Set(value As String)
            apellido = value
        End Set
    End Property

    Public Property _SegundoNombre As String
        Get
            Return segundoNombre
        End Get
        Set(value As String)
            segundoNombre = value
        End Set
    End Property

    Public Property _SegundoApellido As String
        Get
            Return segundoApellido
        End Get
        Set(value As String)
            segundoApellido = value
        End Set
    End Property

    Public Property _Direccion As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

End Class
