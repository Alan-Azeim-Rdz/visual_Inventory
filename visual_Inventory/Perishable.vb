Public Class Perishable
     Implements IProduct
    Public Property Price As Double Implements IProduct.Price
    Public Property Quantity As Double Implements IProduct.Quantity
    Public Property Mark As String Implements IProduct.Mark
    Public Property ExpirationDate As DateTime

    Public Sub New(price As Double, quantity As Double, mark As String, expirationDate As DateTime)
        Me.Price = price
        Me.Quantity = quantity
        Me.Mark = mark
        Me.ExpirationDate = expirationDate
    End Sub

    Public Overrides Function ToString() As String Implements IProduct.ToString
        Return Price & " " & Quantity & " " & Mark.Replace(" ", "-") & " " & ExpirationDate
    End Function
End Class
