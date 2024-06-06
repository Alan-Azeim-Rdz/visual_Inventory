Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Newtonsoft.Json
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Paragraph = iTextSharp.text.Paragraph
Imports DocumentFormat.OpenXml.Office2010.ExcelAc

Public Class CashRegister

    Private selectedProduct As Product_Sale
    Private selectedProductStock As Integer
    Private resultFinish As Double = 0
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
                    LstViewDataProductos.Items.Add(item)
                Next
            Else
                MessageBox.Show("El archivo no existe en la ruta especificada.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If LstViewDataProductos.SelectedItems.Count > 0 Then
            ' Obtener el elemento seleccionado
            Dim selectedItem = LstViewDataProductos.SelectedItems(0)
            Dim quantity As Integer = Convert.ToInt32(TxtQuantity.Text)
            Dim mark As String = selectedItem.SubItems(3).Text

            Try
                Dim quantityToSell As Integer = Convert.ToInt32(TxtQuantity.Text)

                ' Validar la cantidad a vender contra el stock disponible
                If quantityToSell <= selectedProductStock Then
                    ' Verificar si se alcanza la cantidad para aplicar el descuento
                    Dim discountQuantityThreshold As Integer = 30

                    If quantityToSell >= discountQuantityThreshold Then
                        Dim discountPercentage As Double = 0.1 ' 10% de descuento
                        Dim remainingQuantity As Integer = quantityToSell Mod discountQuantityThreshold

                        ' Crear un producto con descuento
                        Dim discountedProduct As New DiscountedProduct_Sale(selectedProduct.Name, selectedProduct.Price, quantityToSell, discountPercentage)

                        ' Calcular el total con descuento
                        Dim discountedTotal As Double = CalculateTotalResult(discountedProduct, quantityToSell)

                        ' Actualizar total result
                        resultFinish += discountedTotal
                        LblResult.Text = "$ " & Convert.ToString(resultFinish)

                        ' Agregar el producto con descuento al ticket
                        Dim itemDiscounted As New ListViewItem(discountedProduct.Name & " (con descuento)")
                        MessageBox.Show("El producto " & selectedProduct.Name & " tiene un descuento del 10% en cada producto por comprar más de 30 de estos")
                        ListVTicket.Items.Add(itemDiscounted)
                        itemDiscounted.SubItems.Add(discountedProduct.Price.ToString())
                        itemDiscounted.SubItems.Add(quantityToSell.ToString())
                        itemDiscounted.SubItems.Add(mark) ' Assuming discount is 0
                        itemDiscounted.SubItems.Add(Convert.ToString(discountedTotal))
                        itemDiscounted.SubItems.Add(selectedItem.SubItems(4).Text)
                    Else
                        ' Actualizar total result
                        resultFinish += CalculateTotalResult(selectedProduct, quantityToSell)
                        LblResult.Text = "$ " & Convert.ToString(resultFinish)

                        ' Verificar si el producto tiene descuento
                        If TypeOf selectedProduct Is DiscountedProduct_Sale Then
                            Dim discountedProduct As DiscountedProduct_Sale = CType(selectedProduct, DiscountedProduct_Sale)
                            ' Calcular el total con descuento
                            resultFinish += CalculateTotalResult(selectedProduct, quantityToSell, discountedProduct.DiscountPercentage)
                            LblResult.Text = "$ " & Convert.ToString(resultFinish)
                        End If

                        ' Actualizar ListView ticket
                        Dim itemTicket As New ListViewItem(selectedProduct.Name)
                        ListVTicket.Items.Add(itemTicket)
                        itemTicket.SubItems.Add(selectedProduct.Price.ToString())
                        itemTicket.SubItems.Add(quantityToSell.ToString())
                        itemTicket.SubItems.Add(mark) ' Assuming discount is 0
                        itemTicket.SubItems.Add(Convert.ToString(CalculateTotalResult(selectedProduct, quantityToSell)))
                    End If

                    ' Actualizar stock del producto
                    selectedProduct.ReduceStock(quantityToSell)
                    selectedProductStock -= quantityToSell

                    ' Actualizar ListView stock del producto
                    LstViewDataProductos.SelectedItems(0).SubItems(2).Text = selectedProductStock.ToString()

                    ' Actualizar archivo del producto
                    UpdateProductFile()
                Else
                    MessageBox.Show("La cantidad seleccionada excede la cantidad disponible.")
                End If
            Catch ex As FormatException
                MessageBox.Show("El valor ingresado no es válido. Por favor, ingresa un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Using writer As New StreamWriter(Url_txt_productos)
                For Each item As ListViewItem In LstViewDataProductos.Items
                    ' Construir una cadena con todos los datos del elemento separados por espacios
                    Dim line As String = $"{item.Text} {item.SubItems(1).Text} {item.SubItems(2).Text} {item.SubItems(3).Text} {item.SubItems(4).Text}"
                    writer.WriteLine(line) ' Escribir la línea en el archivo
                Next
            End Using
        Else
            MessageBox.Show("Seleccione un ítem para editar")
        End If


    End Sub

    Private Function CalculateTotalResult(ByVal selectedProduct As Product_Sale, ByVal quantityToSell As Integer, ByVal Optional discountPercentage As Double = 0) As Double
        If TypeOf selectedProduct Is DiscountedProduct_Sale Then
            ' Calculate total result with discount
            Dim discountedProduct As DiscountedProduct_Sale = CType(selectedProduct, DiscountedProduct_Sale)
            Dim totalResult As Double = CDbl(discountedProduct.GetDiscountedPrice() * quantityToSell)
            Return totalResult
        Else
            ' Calculate total result for regular product
            Dim totalResult As Double = CDbl(selectedProduct.Price * quantityToSell)
            Return totalResult
        End If
    End Function


    Private Sub UpdateProductFile()
        Try
            If File.Exists(Url_txt_productos) Then
                ' Leer todas las líneas del archivo
                Dim lines As String() = File.ReadAllLines(Url_txt_productos)

                ' Crear una lista para almacenar los datos actualizados del producto
                Dim updatedLines As New List(Of String)()

                ' Procesar cada línea
                For Each line As String In lines
                    Dim parts As String() = line.Split(" "c)
                    Dim nombreProducto As String = parts(0)

                    ' Actualizar stock para el producto seleccionado
                    If nombreProducto = selectedProduct.Name Then
                        parts(2) = selectedProductStock.ToString() ' Actualizar valor de stock
                    End If

                    ' Construir la línea actualizada
                    Dim updatedLine As String = String.Join(" ", parts)
                    updatedLines.Add(updatedLine)
                Next

                ' Escribir los datos actualizados en el archivo
                File.WriteAllLines(Url_txt_productos, updatedLines)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el archivo de productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LstViewDataProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstViewDataProductos.SelectedIndexChanged

        If LstViewDataProductos.SelectedItems.Count > 0 Then
            LstViewDataProductos.FullRowSelect = True

            Dim selectedItem = LstViewDataProductos.SelectedItems(0)
            Dim priceRplace As String = selectedItem.SubItems(1).Text.Replace("$", "")

            Dim productName As String = selectedItem.Text
            Dim productPrice As Double = Convert.ToDouble(priceRplace)
            Dim productStock As Integer = Convert.ToInt32(selectedItem.SubItems(2).Text)

            selectedProduct = New Product_Sale(productName, productPrice, productStock)
            LblSelection.Text = selectedProduct.ToString()
            selectedProductStock = productStock
        End If


    End Sub

    Private Sub ListVTicket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListVTicket.SelectedIndexChanged

    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click

        ' Verificar si hay un elemento seleccionado
        If ListVTicket.SelectedItems.Count > 0 Then
            ' Obtener el elemento seleccionado
            Dim selectedItem = ListVTicket.SelectedItems(0)

            ' Extraer la información del producto
            Dim productName As String = selectedItem.Text
            Dim productQuantity As Integer = Convert.ToInt32(selectedItem.SubItems(2).Text)
            Dim productPrice As Double = Convert.ToDouble(selectedItem.SubItems(1).Text)
            Dim productTotalPrice As Double = Convert.ToDouble(selectedItem.SubItems(4).Text)

            ' Eliminar el elemento seleccionado del ListView
            ListVTicket.Items.Remove(selectedItem)

            ' Actualizar el total a pagar
            Dim currentTotal As Double = Convert.ToDouble(LblResult.Text.Replace("$", ""))
            resultFinish = Convert.ToInt32(currentTotal - productTotalPrice)
            LblResult.Text = Convert.ToString(resultFinish)

            ' Encontrar el producto en LstViewDataProductos y actualizar su stock
            For Each item As ListViewItem In LstViewDataProductos.Items
                If item.Text = productName Then
                    Dim currentStock As Integer = Convert.ToInt32(item.SubItems(2).Text)
                    Dim updatedStock As Integer = currentStock + productQuantity
                    item.SubItems(2).Text = updatedStock.ToString()
                    Exit For
                End If
            Next

            ' Actualizar el stock del producto seleccionado solo si no es un producto con descuento
            If Not (TypeOf selectedItem.Tag Is DiscountedProduct_Sale) Then
                selectedProduct.IncreaseStock(productQuantity)
                selectedProductStock += productQuantity
            End If

            ' Actualizar el archivo de productos
            UpdateProductFile()

            ' Actualizar la interfaz gráfica de usuario
            ListVTicket.Refresh()
            LstViewDataProductos.Refresh()

        Else
            MessageBox.Show("Seleccione un ítem para eliminar. No puede estar vacío.")
        End If


    End Sub

    Private Sub BtnTicketJason_Click(sender As Object, e As EventArgs) Handles BtnTicketJason.Click

        If ListVTicket.Items.Count = 0 Then
            selectedProduct = New Product_Sale()
            MessageBox.Show(selectedProduct.ToString() & " No hay elementos en la lista para convertir a JSON.", "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Create a List to hold product data in a JSON-friendly format
            Dim productList As New List(Of Dictionary(Of String, Object))()

            ' Extract and format product data from ListView items
            For Each item As ListViewItem In ListVTicket.Items
                Dim productData As New Dictionary(Of String, Object)()
                productData.Add("Nombre", item.Text)
                productData.Add("Precio", item.SubItems(1).Text)
                productData.Add("Stock", item.SubItems(2).Text)
                productData.Add("Marca", item.SubItems(3).Text)
                productData.Add("Total", item.SubItems(4).Text)

                productList.Add(productData)
            Next
            Dim productData2 As New Dictionary(Of String, Object)()
            productData2.Add("Total a pagar", LblResult.Text)
            productList.Add(productData2)

            Dim jsonString As String = JsonConvert.SerializeObject(productList, Formatting.Indented)

            ' Save the JSON string to a file
            Dim filePath As String = Path.Combine(Path.GetDirectoryName(Url_txt_productos), "ticket.json")
            File.WriteAllText(filePath, jsonString)

            MessageBox.Show("Ticket generado exitosamente en formato JSON: " & filePath, "Listo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al generar el ticket JSON: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub



    Private Sub BtnTicketExcel_Click(sender As Object, e As EventArgs) Handles BtnTicketExcel.Click

        If ListVTicket.Items.Count = 0 Then
            selectedProduct = New Product_Sale()
            MessageBox.Show(selectedProduct.ToString() & " No hay elementos en la lista para convertir a Xlsx.", "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim itemCount As Integer = ListVTicket.Items.Count
        Dim data(itemCount - 1, 4) As String

        For i As Integer = 0 To itemCount - 1
            For j As Integer = 0 To 4
                data(i, j) = ListVTicket.Items(i).SubItems(j).Text
            Next
        Next

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"
        saveFileDialog.FileName = "Datos.xlsx"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            CreateExcelFile(saveFileDialog.FileName, data)
            MessageBox.Show("Archivo Excel creado con éxito!")
        End If


    End Sub


    Private Sub CreateExcelFile(ByVal filePath As String, ByVal data As String(,))
        Using document As SpreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook)
            ' Crear la parte del libro de trabajo
            Dim workbookPart As WorkbookPart = document.AddWorkbookPart()
            workbookPart.Workbook = New Workbook()

            ' Crear la parte de la hoja de trabajo
            Dim worksheetPart As WorksheetPart = workbookPart.AddNewPart(Of WorksheetPart)()
            worksheetPart.Worksheet = New Worksheet(New SheetData())

            ' Crear hojas
            Dim sheets As Sheets = document.WorkbookPart.Workbook.AppendChild(New Sheets())

            ' Crear una hoja de cálculo
            Dim sheet As New Sheet() With {
             .Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
             .SheetId = 1,
             .Name = "Ticket"
         }

            sheets.Append(sheet)

            ' Llenar la hoja de cálculo con datos
            Dim sheetData As SheetData = worksheetPart.Worksheet.GetFirstChild(Of SheetData)()

            For row As Integer = 0 To data.GetLength(0) - 1
                Dim newRow As New Row()
                For col As Integer = 0 To data.GetLength(1) - 1
                    Dim newCell As New Cell() With {
                     .CellValue = New CellValue(data(row, col)),
                     .DataType = CellValues.String
                 }
                    newRow.Append(newCell)
                Next
                sheetData.Append(newRow)
            Next
            ' Agregar "Gracias" al final
            Dim Total_Price As New Row()
            Dim Celd_Total_price As New Cell() With {
             .CellValue = New CellValue("Total a pagar"),
             .DataType = CellValues.String
         }
            Total_Price.Append(Celd_Total_price)
            Dim numberCell As New Cell() With {
             .CellValue = New CellValue(LblResult.Text),
             .DataType = CellValues.String
         }
            Total_Price.Append(numberCell)

            sheetData.Append(Total_Price)


            workbookPart.Workbook.Save()

        End Using
    End Sub




    Private Sub BtnPdfTicket_Click(sender As Object, e As EventArgs) Handles BtnPdfTicket.Click

        If ListVTicket.Items.Count = 0 Then
            selectedProduct = New Product_Sale()
            MessageBox.Show(selectedProduct.ToString() & " No hay elementos en la lista para convertir a PDF.", "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"
        saveFileDialog.Title = "Guardar como PDF"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportToPdf(saveFileDialog.FileName)
            MessageBox.Show("PDF creado exitosamente.")
        End If
    End Sub

    Private Sub ExportToPdf(ByVal filePath As String)
        Dim document As New iTextSharp.text.Document()
        Try
            PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))
            document.Open()

            ' Añadir el título del documento
            document.Add(New iTextSharp.text.Paragraph("Ticket"))
            document.Add(New iTextSharp.text.Paragraph(" ")) ' Espacio en blanco

            ' Crear una tabla con el número de columnas del ListView
            Dim table As New PdfPTable(ListVTicket.Columns.Count)

            ' Añadir los encabezados de las columnas
            For Each column As ColumnHeader In ListVTicket.Columns
                Dim cell As New PdfPCell(New Phrase(column.Text))
                cell.BackgroundColor = BaseColor.LIGHT_GRAY
                table.AddCell(cell)
            Next

            ' Añadir las filas de datos
            For Each item As ListViewItem In ListVTicket.Items
                For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                    table.AddCell(subItem.Text)
                Next
            Next

            ' Añadir la tabla al documento
            document.Add(table)
            document.Add(New iTextSharp.text.Paragraph("Total a pagar " & LblResult.Text))
        Catch ex As Exception
            MessageBox.Show($"Error al crear el PDF: {ex.Message}")
        Finally
            document.Close()
        End Try


    End Sub
End Class