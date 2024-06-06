Public Class Not_Perishable

    Public Property Price As Double
    Public Property Quantity As Integer
    Public Property Mark As String

    Public Sub New(price As Double, quantity As Integer, mark As String)
        Me.Price = price
        Me.Quantity = quantity
        Me.Mark = mark
    End Sub

    Public Overrides Function ToString() As String
        Return Price.ToString() & " " & Quantity.ToString() & " " & Mark.Replace(" ", "-")
    End Function

End Class
