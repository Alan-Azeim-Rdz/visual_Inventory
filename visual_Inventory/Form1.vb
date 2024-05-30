Imports System.IO
Imports System.Windows.Forms
Public Class Form1
    Private Url_excel_productos As String = "C:\Users\1gren\Documents\productos.xlsx"
    Private Url_txt_productos As String = "C:\Users\1gren\Documents\archivos_R\datos.txt"

    Private _receivedImage As Image

    Public Property ReceivedImage As Image
        Get
            Return ReceivedImage
        End Get
        Set(value As Image)
            _receivedImage = value
            PicturUser.Image = _receivedImage
        End Set
    End Property

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        If Not (TxtAddName.Text = "") AndAlso Not (TxtPrice.Text = "") AndAlso Not (TxtQuanity.Text = "") AndAlso Not (TxtMark.Text = "") Then
            Dim Name_without_spaces As String = TxtAddName.Text.Replace(" ", "-")
            Dim Mark_without_spaces As String = TxtMark.Text.Replace(" ", "-")
            Dim NewItemLstData As New ListViewItem(Name_without_spaces)

            Try
                LstViewDataProductos.Items.Add(NewItemLstData)

                Dim producto As New Product(Integer.Parse(TxtPrice.Text), Integer.Parse(TxtQuanity.Text), TxtMark.Text)

                NewItemLstData.SubItems.Add(Convert.ToString(producto.Price))
                NewItemLstData.SubItems.Add(Convert.ToString(producto.Quantity))
                NewItemLstData.SubItems.Add(Mark_without_spaces)

                Dim product_for_txt As String = Name_without_spaces & " " & producto.ToString()

                Try
                    File.AppendAllText(Url_txt_productos, product_for_txt & Environment.NewLine)
                Catch ex As Exception
                    MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                End Try
            Catch ex As InvalidCastException
                LstViewDataProductos.Items.Remove(NewItemLstData)
                MessageBox.Show("Alguno de los datos enviados está mal. Por favor, verifique su escritura.")
            Catch ex As FormatException
                LstViewDataProductos.Items.Remove(NewItemLstData)
                MessageBox.Show("Alguno de los datos enviados está mal. Por favor, verifique su escritura.")
            End Try
        Else
            MessageBox.Show("Todos los campos deben estar llenos para poder ingresar.")
        End If
    End Sub

    Private Sub BtnQuantityProductTotal_Click(sender As Object, e As EventArgs) Handles BtnQuantityProductTotal.Click
        ObtenerCantidadProductosTotales()
    End Sub

    Public Function ObtenerCantidadProductosTotales() As DialogResult
        Dim totalProductos As Integer = 0

        Try
            If File.Exists(Url_txt_productos) Then
                Dim lineas As String() = File.ReadAllLines(Url_txt_productos)
                totalProductos = lineas.Length
            Else
                MessageBox.Show("El archivo no existe en la ruta especificada.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return MessageBox.Show("Los productos que se encuentran registrados en el almacén ahora son " & Convert.ToString(totalProductos.ToString()))
    End Function

    Private Sub Filllistview()
        Try
            If File.Exists(Url_txt_productos) Then
                Dim lineas As String() = File.ReadAllLines(Url_txt_productos)

                For Each linea As String In lineas
                    Dim partes As String() = linea.Split(" ")

                    Dim item As New ListViewItem(partes(0))

                    For i As Integer = 1 To partes.Length - 1
                        item.SubItems.Add(partes(i))
                    Next

                    LstViewDataProductos.Items.Add(item)
                Next
            Else
                MessageBox.Show("El archivo no existe en la ruta especificada.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
