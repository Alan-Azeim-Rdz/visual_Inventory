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
    Private resultFinish As Integer = 0

    Private Url_txt_productos As String = "C:\Users\1gren\Documents\archivos_R\datos.txt"

    Public Sub New()
        InitializeComponent()
        Filllistview()
    End Sub

    Private _receivedImage As System.Drawing.Image

    Public Property ReceivedImage() As System.Drawing.Image
        Get
            Return ReceivedImage
        End Get
        Set(ByVal value As System.Drawing.Image)
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

    Private Sub BtnSelection_Click(sender As Object, e As EventArgs) Handles BtnSelection.Click
        If LstViewDataProductos.SelectedItems.Count > 0 Then
            Dim selectedItem = LstViewDataProductos.SelectedItems(0)
            Dim Price_Rplace As String = selectedItem.SubItems(1).Text.Replace("$", "")

            Dim productName As String = selectedItem.Text
            Dim productPrice As Double = Convert.ToDouble(Price_Rplace)
            Dim productStock As Integer = Convert.ToInt32(selectedItem.SubItems(2).Text)

            selectedProduct = New Product_Sale(productName, productPrice, productStock)
            LblSelection.Text = selectedProduct.ToString()
            selectedProductStock = productStock

        Else
            selectedProduct = New Product_Sale()
            MessageBox.Show("Seleccione un ítem para editar. No puede estar vacio " & selectedProduct.ToString())
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If LstViewDataProductos.SelectedItems.Count > 0 Then
            ' Obtener el elemento seleccionado
            Dim selectedItem = LstViewDataProductos.SelectedItems(0)
            Dim Price As Integer = Convert.ToInt32(selectedItem.SubItems(1).Text)
            Dim Quantity As Integer = Convert.ToInt32(selectedItem.SubItems(2).Text)
            Dim mark As String = selectedItem.SubItems(3).Text

            Try
                Dim quantityToSell As Integer = Convert.ToInt32(TxtQuantity.Text)

                ' Validate quantity to sell against available stock
                If quantityToSell <= selectedProductStock Then
                    ' Update total result
                    resultFinish += CalculateTotalResult(selectedProduct, quantityToSell)
                    LblResult.Text = "$ " & Convert.ToString(resultFinish)

                    ' Update ListView ticket
                    Dim itemTicket As New ListViewItem(selectedProduct.Name)
                    ListVTicket.Items.Add(itemTicket)
                    itemTicket.SubItems.Add(selectedProduct.Price.ToString())
                    itemTicket.SubItems.Add(quantityToSell.ToString())
                    itemTicket.SubItems.Add(mark) ' Assuming discount is 0

                    ' Update product stock
                    selectedProduct.ReduceStock(quantityToSell)
                    selectedProductStock -= quantityToSell

                    ' Update ListView product stock
                    LstViewDataProductos.SelectedItems(0).SubItems(2).Text = selectedProductStock.ToString()

                    ' Update product file
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
                    Dim line As String = $"{item.Text} {item.SubItems(1).Text} {item.SubItems(2).Text} {item.SubItems(3).Text}"
                    writer.WriteLine(line) ' Escribir la línea en el archivo
                Next
            End Using
        Else
            MessageBox.Show("Seleccione un ítem para editar")
        End If
    End Sub

    Private Function CalculateTotalResult(selectedProduct As Product_Sale, quantityToSell As Integer) As Integer
        Dim totalResult As Integer = CInt(selectedProduct.Price * quantityToSell)
        Return totalResult
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

    Private Sub BtnTicketJason_Click(sender As Object, e As EventArgs) Handles BtnTicketJason.Click
        If LstViewDataProductos.Items.Count = 0 Then
            MessageBox.Show("No hay elementos en la lista para convertir a JSON.", "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                productList.Add(productData)
            Next

            Dim productData2 As New Dictionary(Of String, Object)()
            productData2.Add("Total", LblResult.Text)
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
        Dim itemCount As Integer = ListVTicket.Items.Count
        Dim data(itemCount - 1, 3) As String

        For i As Integer = 0 To itemCount - 1
            For j As Integer = 0 To 3
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

    Private Sub CreateExcelFile(filePath As String, data As String(,))
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

            workbookPart.Workbook.Save()
        End Using
    End Sub

    Private Sub BtnPdfTicket_Click(sender As Object, e As EventArgs) Handles BtnPdfTicket.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"
        saveFileDialog.Title = "Guardar como PDF"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportToPdf(saveFileDialog.FileName)
            MessageBox.Show("PDF creado exitosamente.")
        End If
    End Sub

    Private Sub ExportToPdf(filePath As String)
        Dim document As New iTextSharp.text.Document()
        Try
            PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))
            document.Open()

            ' Añadir el título del documento
            document.Add(New iTextSharp.text.Paragraph("Total " & LblResult.Text))
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
        Catch ex As Exception
            MessageBox.Show($"Error al crear el PDF: {ex.Message}")
        Finally
            document.Close()
        End Try
    End Sub

End Class