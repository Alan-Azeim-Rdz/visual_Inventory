Public Class menu

    Private _receivedImage As Image

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Property ReceivedImage() As Image
        Get
            Return _receivedImage
        End Get
        Set(ByVal value As Image)
            _receivedImage = value
            PictureImagePhoto.Image = _receivedImage
        End Set
    End Property

    Private Sub BtnEditInventory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEditInventory.Click
        Dim products_Sold As New Edit_Inventory()
        products_Sold.Show()
        products_Sold.ReceivedImage = PictureImagePhoto.Image
    End Sub

    Private Sub BtnCashRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCashRegister.Click
        Dim cash As New CashRegister()
        cash.Show()
        cash.ReceivedImage = PictureImagePhoto.Image
    End Sub

End Class