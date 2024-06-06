Public Class Perishable
    Public Property Price As Double
    Public Property Quantity As Integer
    Public Property Mark As String
    Public Property ExpirationDate As DateTime

    Public Sub New(price As Double, quantity As Integer, mark As String, expirationDate As DateTime)
        Me.Price = price
        Me.Quantity = quantity
        Me.Mark = mark
        Me.ExpirationDate = expirationDate
    End Sub

    Public Overrides Function ToString() As String
        Return Price.ToString() & " " & Quantity.ToString() & " " & Mark.Replace(" ", "-") & " " & ExpirationDate.ToString()
    End Function
End Class
