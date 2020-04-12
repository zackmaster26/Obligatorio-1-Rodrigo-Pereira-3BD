Public Class Empleado
    Inherits Persona

    Private tipo As Integer
    Private sueldo As Integer
    Private bajaLogica(99, 1) As Integer

    Public Sub New(cedula As String, nombre As String, apellido As String, segundoNombre As String, segundoApellido As String, direccion As String, tipo As Integer, sueldo As Integer)
        MyBase.New(cedula, nombre, apellido, segundoNombre, segundoApellido, direccion)

        Me.tipo = tipo
        Me.sueldo = sueldo
    End Sub

    Public Property _sueldo As Integer
        Get
            Return sueldo
        End Get
        Set(value As Integer)
            sueldo = value
        End Set
    End Property

    Public Property _tipo As Integer
        Get
            Return tipo
        End Get
        Set(value As Integer)
            tipo = value
        End Set
    End Property

End Class
