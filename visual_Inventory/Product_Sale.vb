

Public Class Product_Sale
    Public ReadOnly Property Name() As String

    Public WriteOnly Property Stock() As Integer
        Set(ByVal value As Integer)
            quantity = value
        End Set
    End Property

    Public Property Price() As Double

    Private quantity As Integer

    ' Constructor 
    Public Sub New()
        Name = ""
        Price = 0
        quantity = 0
    End Sub

    ' Constructor with Parameters
    Public Sub New(ByVal name As String, ByVal price As Double, ByVal quantity As Integer)
        Me.New()
        Me.Name = name
        Me.Price = price
        Stock = quantity ' Enforces stock validation through the setter
    End Sub

    ' Method to Reduce Stock (assuming a sale)
    Public Sub ReduceStock(ByVal soldQuantity As Integer)
        If soldQuantity <= quantity Then
            quantity -= soldQuantity
        Else
            Throw New ArgumentOutOfRangeException("Sold quantity cannot exceed available stock.")
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return "el producto " & Name & " tiene a la venta " & quantity & " artículos disponibles y el precio de cada uno es " & Price
    End Function
End Class
