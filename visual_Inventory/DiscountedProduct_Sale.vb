Public Class DiscountedProduct_Sale

    Inherits Product_Sale
    Public Property DiscountPercentage As Double

    Public Sub New(name As String, price As Double, quantity As Integer, discountPercentage As Double)
        MyBase.New(name, price, quantity)
        Me.DiscountPercentage = discountPercentage
    End Sub

    Public Function GetDiscountedPrice() As Double
        Return Price * (1 - DiscountPercentage)
    End Function

    Public Overrides Function ToString() As String
        Return "El producto" & Name & "tiene un descuento de 10%" & " y su precio final es " & GetDiscountedPrice().ToString("F2")
    End Function

End Class
