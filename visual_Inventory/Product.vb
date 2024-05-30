Public Class Product
    Protected _price As Integer
    Protected _quantity As Integer
    Protected _mark As String

    Public Property Price() As Integer
        Get
            Return _price
        End Get
        Set(ByVal value As Integer)
            _price = value
        End Set
    End Property

    Public Property Quantity() As Integer
        Get
            Return _quantity
        End Get
        Set(ByVal value As Integer)
            _quantity = value
        End Set
    End Property

    Public Property Mark() As String
        Get
            Return _mark
        End Get
        Set(ByVal value As String)
            _mark = value
        End Set
    End Property

    Public Sub New()
        _price = 0
        _quantity = 0
        _mark = ""
    End Sub

    Public Sub New(ByVal price As Integer, ByVal quantity As Integer, ByVal mark As String)
        _price = price
        _quantity = quantity
        _mark = mark
    End Sub

    Public Overrides Function ToString() As String
        Return _price & " " & _quantity & " " & _mark.Replace(" ", "-")
    End Function
End Class
