Public Class Not_Perishable
    Implements IProduct

    Public Property Price As Double Implements IProduct.Price
    Public Property Quantity As Double Implements IProduct.Quantity
    Public Property Mark As String Implements IProduct.Mark

    Public Sub New(price As Double, quantity As Double, mark As String)
        Me.Price = price
        Me.Quantity = quantity
        Me.Mark = mark
    End Sub

    Public Overrides Function ToString() As String Implements IProduct.ToString
        Return Price.ToString() & " " & Quantity.ToString() & " " & Mark.Replace(" ", "-")
    End Function

End Class
