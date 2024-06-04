Imports System
Imports System.IO
Imports System.Windows.Forms
Public Class Edit_Inventory
    Private Url_txt_productos As String = "C:\Users\1gren\Documents\archivos_R\datos.txt"

    Public Sub New()
        InitializeComponent()
        Filllistview()
    End Sub

    Private _receivedImage As Image
    Public Property ReceivedImage As Image
        Get
            Return _receivedImage
        End Get
        Set(ByVal value As Image)
            _receivedImage = value
            PictureUser.Image = ReceivedImage
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
                    For i As Integer = 1 To partes.Length - 1
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



    Private Sub Btnaccept_Click(sender As Object, e As EventArgs) Handles Btnaccept.Click
        Try
            If ComBoxElection.SelectedItem Is Nothing Then
                MessageBox.Show("Por favor selecciona una acción en la caja de ítems")
                Return
            Else
                Dim selection As String = ComBoxElection.SelectedItem.ToString()

                Select Case selection
                    Case "Add"
                        If ListViewDataProduct.SelectedItems.Count > 0 Then
                            MessageBox.Show("No puedes agregar un nuevo producto mientras estás editando.")
                            Return
                        End If

                        If Not String.IsNullOrEmpty(TxtAddName.Text) AndAlso Not String.IsNullOrEmpty(TxtPrice.Text) AndAlso Not String.IsNullOrEmpty(TxtQuanity.Text) AndAlso Not String.IsNullOrEmpty(TxtMark.Text) Then
                            Dim Name_without_spaces As String = TxtAddName.Text.Replace(" ", "-")
                            Dim Mark_without_spaces As String = TxtMark.Text.Replace(" ", "-")

                            ' Verificar duplicados
                            Dim isDuplicate As Boolean = False
                            For Each item As ListViewItem In ListViewDataProduct.Items
                                If item.Text = Name_without_spaces AndAlso item.SubItems(1).Text = TxtPrice.Text AndAlso item.SubItems(2).Text = TxtQuanity.Text AndAlso item.SubItems(3).Text = Mark_without_spaces Then
                                    isDuplicate = True
                                    Exit For
                                End If
                            Next

                            If Not isDuplicate Then
                                Dim NewItemLstData As New ListViewItem(Name_without_spaces)
                                Try
                                    ListViewDataProduct.Items.Add(NewItemLstData)

                                    Dim producto As New Product(Convert.ToInt32(TxtPrice.Text), Convert.ToInt32(TxtQuanity.Text), TxtMark.Text)

                                    NewItemLstData.SubItems.Add(Convert.ToString(producto.Price))
                                    NewItemLstData.SubItems.Add(Convert.ToString(producto.Quantity))
                                    NewItemLstData.SubItems.Add(Mark_without_spaces)

                                    Dim product_for_txt As String = Name_without_spaces & " " & producto.ToString()
                                    Try
                                        ' Escribe el contenido en el archivo especificado
                                        File.AppendAllText(Url_txt_productos, product_for_txt & Environment.NewLine)

                                    Catch ex As Exception
                                        MessageBox.Show("Error al guardar el archivo: " & ex.Message)
                                    End Try
                                Catch __unusedInvalidCastException1__ As System.InvalidCastException
                                    ListViewDataProduct.Items.Remove(NewItemLstData)
                                    MessageBox.Show("Alguno de los datos enviados está mal. Por favor verifique su escritura")
                                Catch __unusedFormatException1__ As System.FormatException
                                    ListViewDataProduct.Items.Remove(NewItemLstData)
                                    MessageBox.Show("Alguno de los datos enviados está mal. Por favor verifique su escritura")
                                End Try
                            Else
                                MessageBox.Show("El producto ya existe en la lista.")
                            End If
                        Else
                            MessageBox.Show("Todos los campos deben estar llenos para poder ingresar")
                        End If

                        TxtAddName.Clear()
                        TxtMark.Clear()
                        TxtPrice.Clear()
                        TxtQuanity.Clear()

                        Exit Select
                    Case "Edit"
                        ListViewDataProduct.Enabled = True
                        If Not String.IsNullOrEmpty(TxtAddName.Text) AndAlso Not String.IsNullOrEmpty(TxtPrice.Text) AndAlso Not String.IsNullOrEmpty(TxtQuanity.Text) AndAlso Not String.IsNullOrEmpty(TxtMark.Text) Then
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
                            MessageBox.Show("Todos los campos deben estar llenos para poder ingresar")
                        End If

                        TxtAddName.Clear()
                        TxtMark.Clear()
                        TxtPrice.Clear()
                        TxtQuanity.Clear()

                        Exit Select
                End Select
            End If
        Catch
            MessageBox.Show("Ha ocurrido un error, inténtalo de nuevo.")
        End Try
    End Sub


    Public Sub DeleteSelect(ByVal listView As ListView, ByVal Url As String)
        If listView.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In listView.SelectedItems
                listView.Items.Remove(item)
            Next
            ActualizarTxt(listView, Url)
        Else
            MessageBox.Show("No hay elementos seleccionados para eliminar.", "Elemento no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ActualizarTxt(ByVal listView As ListView, ByVal filePath As String)

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


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click

        ListViewDataProduct.SelectedItems.Clear()
        ListViewDataProduct.Enabled = True

        TxtAddName.Clear()
        TxtMark.Clear()
        TxtPrice.Clear()
        TxtQuanity.Clear()


    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelect(ListViewDataProduct, Url_txt_productos)

        TxtAddName.Clear()
        TxtMark.Clear()
        TxtPrice.Clear()
        TxtQuanity.Clear()
    End Sub

    Private Sub BtnQuantityProductTotal_Click(sender As Object, e As EventArgs) Handles BtnQuantityProductTotal.Click
        ObtenerCantidadProductosTotales()
    End Sub
    Public Function ObtenerCantidadProductosTotales() As DialogResult
        Dim totalProductos As Integer = 0

        Try
            If File.Exists(Url_txt_productos) Then
                ' Leer todas las líneas del archivo
                Dim lineas As String() = File.ReadAllLines(Url_txt_productos)

                ' Contar el número de líneas (cada línea representa un producto)
                totalProductos = lineas.Length
            Else
                MessageBox.Show("El archivo no existe en la ruta especificada.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return MessageBox.Show("los productos que se encuentran registrados en el almacen ahora son " & (Convert.ToString(totalProductos.ToString())))
    End Function


    Private Sub ListViewDataProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDataProduct.SelectedIndexChanged

        If ListViewDataProduct.SelectedItems.Count > 0 Then
            ListViewDataProduct.FullRowSelect = True

            Dim selectedItem = ListViewDataProduct.SelectedItems(0)

            TxtAddName.Text = selectedItem.Text
            TxtPrice.Text = selectedItem.SubItems(1).Text
            TxtQuanity.Text = selectedItem.SubItems(2).Text
            TxtMark.Text = selectedItem.SubItems(3).Text

            ListViewDataProduct.Enabled = False

            ' Cambia el combo box a "Edit" y deshabilita la opción "Add"
            ComBoxElection.SelectedItem = "Edit"
            ComBoxElection.Enabled = False

        Else
            ' Si no hay ningún elemento seleccionado, habilitar el combo box
            ComBoxElection.Enabled = True
        End If


    End Sub
End Class