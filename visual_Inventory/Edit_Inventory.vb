Imports System
Imports System.IO
Imports System.Windows.Forms
Public Class Edit_Inventory
    Private Url_txt_productos As String = "C:\Users\1gren\Documents\archivos_R\datos.txt"

    Public Sub New()
        InitializeComponent()
        Filllistview()
    End Sub


    Private _receivedImage As System.Drawing.Image
    Public Property ReceivedImage() As System.Drawing.Image
        Get
            Return _receivedImage
        End Get
        Set
            _receivedImage = Value
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

                            Dim isDuplicate As Boolean = False
                            For Each item As ListViewItem In ListViewDataProduct.Items
                                If item.Text = Name_without_spaces AndAlso
                                   item.SubItems(1).Text = TxtPrice.Text AndAlso
                                   item.SubItems(2).Text = TxtQuanity.Text AndAlso
                                   item.SubItems(3).Text = Mark_without_spaces Then
                                    isDuplicate = True
                                    Exit For
                                End If
                            Next

                            If Not isDuplicate Then
                                Dim producto As IProduct

                                If CheckBoxPerecedero.Checked Then
                                    Dim expirationDate As DateTime

                                    If DateTime.TryParse(DateTimeExpirationDate.Text, expirationDate) Then
                                        If expirationDate < DateTime.Today Then
                                            MessageBox.Show("La fecha de caducidad no puede ser anterior a la fecha actual.")
                                            Return
                                        End If

                                        producto = New Perishable(Convert.ToDouble(TxtPrice.Text), Convert.ToDouble(TxtQuanity.Text), TxtMark.Text, expirationDate)
                                    Else
                                        ' Maneja el caso en que la entrada no se pudo convertir a una fecha válida
                                        MessageBox.Show("Por favor, ingresa una fecha de caducidad válida.")
                                    End If
                                Else
                                    producto = New Not_Perishable(Convert.ToDouble(TxtPrice.Text), Convert.ToInt32(TxtQuanity.Text), TxtMark.Text)
                                End If

                                Dim NewItemLstData As New ListViewItem(Name_without_spaces)
                                ListViewDataProduct.Items.Add(NewItemLstData)

                                NewItemLstData.SubItems.Add(Convert.ToString(producto.Price))
                                NewItemLstData.SubItems.Add(Convert.ToString(producto.Quantity))
                                NewItemLstData.SubItems.Add(Mark_without_spaces)

                                If TypeOf producto Is Perishable Then
                                    NewItemLstData.SubItems.Add(DirectCast(producto, Perishable).ExpirationDate.ToString("yyyy-MM-dd"))
                                Else
                                    NewItemLstData.SubItems.Add("N/A")
                                End If

                                Dim product_for_txt As String = Name_without_spaces & " " & producto.ToString() & " N/A"
                                Try
                                    File.AppendAllText(Url_txt_productos, product_for_txt & Environment.NewLine)
                                Catch ex As Exception
                                    MessageBox.Show("Error al guardar el archivo: " & ex.Message)
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
                        DateTimeExpirationDate.ResetText()

                    Case "Edit"
                        ListViewDataProduct.Enabled = True
                        If Not String.IsNullOrEmpty(TxtAddName.Text) AndAlso Not String.IsNullOrEmpty(TxtPrice.Text) AndAlso Not String.IsNullOrEmpty(TxtQuanity.Text) AndAlso Not String.IsNullOrEmpty(TxtMark.Text) Then
                            If ListViewDataProduct.SelectedItems.Count > 0 Then
                                Dim Name_without_spaces As String = TxtAddName.Text.Replace(" ", "-")
                                Dim Mark_without_spaces As String = TxtMark.Text.Replace(" ", "-")
                                Dim selectedItem As ListViewItem = ListViewDataProduct.SelectedItems(0)

                                selectedItem.Text = Name_without_spaces
                                selectedItem.SubItems(1).Text = TxtPrice.Text
                                selectedItem.SubItems(2).Text = TxtQuanity.Text
                                selectedItem.SubItems(3).Text = TxtMark.Text

                                Dim expirationDateText As String = If(CheckBoxPerecedero.Checked, DateTimeExpirationDate.Text, "N/A")
                                selectedItem.SubItems(4).Text = expirationDateText

                                Using writer As New StreamWriter(Url_txt_productos)
                                    For Each item As ListViewItem In ListViewDataProduct.Items
                                        Dim line As String = $"{item.Text} {item.SubItems(1).Text} {item.SubItems(2).Text} {item.SubItems(3).Text} {item.SubItems(4).Text}"
                                        writer.WriteLine(line)
                                    Next
                                End Using

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
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error al añadir el producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteSelect(ListViewDataProduct, Url_txt_productos)
        ListViewDataProduct.SelectedItems.Clear()
        ListViewDataProduct.Enabled = True

        TxtAddName.Clear()
        TxtMark.Clear()
        TxtPrice.Clear()
        TxtQuanity.Clear()
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
                    dataRow &= item.SubItems(i).Text & " "
                Next
                writer.WriteLine(dataRow.Trim())
            Next
        End Using
    End Sub

    Private Sub ListViewDataProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDataProduct.SelectedIndexChanged
        If ListViewDataProduct.SelectedItems.Count > 0 Then
            ListViewDataProduct.FullRowSelect = True

            Dim selectedItem = ListViewDataProduct.SelectedItems(0)

            TxtAddName.Text = selectedItem.Text
            TxtPrice.Text = selectedItem.SubItems(1).Text
            TxtQuanity.Text = selectedItem.SubItems(2).Text
            TxtMark.Text = selectedItem.SubItems(3).Text

            ' Verificar si el producto seleccionado es perecedero
            Dim expirationDateText As String = selectedItem.SubItems(4).Text
            If Not String.IsNullOrEmpty(expirationDateText) AndAlso expirationDateText <> "N/A" Then
                CheckBoxPerecedero.Checked = True
                DateTimeExpirationDate.Text = expirationDateText
            Else
                CheckBoxPerecedero.Checked = False
            End If

            ListViewDataProduct.Enabled = False

            ' Cambia el combo box a "Edit" y deshabilita la opción "Add"
            ComBoxElection.SelectedItem = "Edit"
            ComBoxElection.Enabled = False
        Else
            ' Si no hay ningún elemento seleccionado, habilitar el combo box
            ComBoxElection.Enabled = True
        End If
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

        Return MessageBox.Show("los productos que se encuentran registrados en el almacen ahora son " & Convert.ToString(totalProductos.ToString()))
    End Function

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ListViewDataProduct.SelectedItems.Clear()
        ListViewDataProduct.Enabled = True

        TxtAddName.Clear()
        TxtMark.Clear()
        TxtPrice.Clear()
        TxtQuanity.Clear()

    End Sub
End Class