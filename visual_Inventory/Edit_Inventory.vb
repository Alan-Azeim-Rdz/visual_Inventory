Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Edit_Inventory

    Private Url_txt_productos As String = "C:\Users\1gren\Documents\archivos_R\datos.txt"

    Public Sub New()
        InitializeComponent()
        Filllistview()
    End Sub

    Private _receivedImage As Image

    Public Property ReceivedImage() As Image
        Get
            Return ReceivedImage
        End Get
        Set(ByVal value As Image)
            _receivedImage = value
            PictureUser.Image = _receivedImage
        End Set
    End Property

    Private Sub Filllistview()
        Try
            If File.Exists(Url_txt_productos) Then
                ' Leer todas las líneas del archivo
                Dim lineas As String() = File.ReadAllLines(Url_txt_productos)

                ' Agregar cada línea como un elemento al ListView
                For Each linea As String In lineas
                    Dim partes As String() = linea.Split(" "c)
                    Dim item As New ListViewItem(partes(0))
                    For i As Integer = 1 To partes.Length
                        item.SubItems.Add(partes(i))
                    Next

                    ' Agregar el item al ListView
                    ListViewDataProduct.Items.Add(item)
                Next
            Else
                MessageBox.Show("El archivo no existe en la ruta especificada.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        If ListViewDataProduct.SelectedItems.Count > 0 Then
            Dim selectedItem = ListViewDataProduct.SelectedItems(0)
            TxtAddName.Text = selectedItem.Text
            TxtPrice.Text = selectedItem.SubItems(1).Text
            TxtQuanity.Text = selectedItem.SubItems(2).Text
            TxtMark.Text = selectedItem.SubItems(3).Text
        Else
            MessageBox.Show("Seleccione un ítem para editar.")
        End If
    End Sub

    Private Sub BtnReplace_Click(sender As Object, e As EventArgs) Handles BtnReplace.Click
        If Not (TxtAddName.Text = "") AndAlso Not (TxtPrice.Text = "") AndAlso Not (TxtQuanity.Text = "") AndAlso Not (TxtMark.Text = "") Then
            If ListViewDataProduct.SelectedItems.Count > 0 Then
                ' Obtener el elemento seleccionado
                Dim Name_without_spaces As String = TxtAddName.Text.Replace(" ", "-")
                Dim Mark_without_spaces As String = TxtMark.Text.Replace(" ", "-")
                Dim selectedItem = ListViewDataProduct.SelectedItems(0)

                ' Actualizar los valores en los subitems del elemento seleccionado
                selectedItem.Text = Name_without_spaces
                selectedItem.SubItems(1).Text = TxtPrice.Text
                selectedItem.SubItems(2).Text = TxtQuanity.Text
                selectedItem.SubItems(3).Text = Mark_without_spaces

                Using writer As New StreamWriter(Url_txt_productos)
                    ' Recorre los elementos del ListView y escribe cada dato en una línea
                    For Each item As ListViewItem In ListViewDataProduct.Items
                        ' Construir una cadena con todos los datos del elemento separados por espacios
                        Dim line As String = $"{item.Text} {item.SubItems(1).Text} {item.SubItems(2).Text} {item.SubItems(3).Text}"
                        writer.WriteLine(line)
                    Next
                End Using

                ' Opcionalmente, puedes mostrar un mensaje de confirmación
                MessageBox.Show("El producto ha sido actualizado correctamente.")
            Else
                MessageBox.Show("Seleccione un ítem para editar")
            End If
        Else
            MessageBox.Show("Todos los campos deven estar llenos para poder ingresar")
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelect(ListViewDataProduct, Url_txt_productos)
    End Sub

    Public Sub DeleteSelect(listView As System.Windows.Forms.ListView, Url As String)
        If listView.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In listView.SelectedItems
                listView.Items.Remove(item)
            Next
            ActualizarTxt(listView, Url)
        Else
            MessageBox.Show("No hay elementos seleccionados para eliminar.", "Elemento no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ActualizarTxt(listView As System.Windows.Forms.ListView, filePath As String)
        Using writer As New StreamWriter(filePath, False)
            For Each item As ListViewItem In listView.Items
                Dim dataRow As String = ""
                For i As Integer = 0 To item.SubItems.Count - 1
                    dataRow += item.SubItems(i).Text & " "
                Next
                writer.WriteLine(dataRow.Trim())
            Next
        End Using
    End Sub

End Class