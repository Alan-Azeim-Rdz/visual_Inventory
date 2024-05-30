<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashRegister
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PictureUser = New PictureBox()
        LblSelection = New Label()
        Label2 = New Label()
        LblTotal = New Label()
        LblResult = New Label()
        LstViewDataProductos = New ListView()
        ColumnHeader1 = New ColumnHeader()
        Price = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        ListVTicket = New ListView()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader5 = New ColumnHeader()
        ColumnHeader6 = New ColumnHeader()
        ColumnHeader7 = New ColumnHeader()
        TxtQuantity = New TextBox()
        BtnAdd = New Button()
        BtnSelection = New Button()
        BtnPdfTicket = New Button()
        BtnTicketExcel = New Button()
        BtnTicketJason = New Button()
        CType(PictureUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureUser
        ' 
        PictureUser.Location = New Point(12, 12)
        PictureUser.Name = "PictureUser"
        PictureUser.Size = New Size(62, 50)
        PictureUser.SizeMode = PictureBoxSizeMode.StretchImage
        PictureUser.TabIndex = 0
        PictureUser.TabStop = False
        ' 
        ' LblSelection
        ' 
        LblSelection.AutoSize = True
        LblSelection.Location = New Point(228, 74)
        LblSelection.Name = "LblSelection"
        LblSelection.Size = New Size(54, 15)
        LblSelection.TabIndex = 1
        LblSelection.Text = "selection"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 192)
        Label2.Name = "Label2"
        Label2.Size = New Size(38, 15)
        Label2.TabIndex = 2
        Label2.Text = "Ticket"
        ' 
        ' LblTotal
        ' 
        LblTotal.AutoSize = True
        LblTotal.Location = New Point(105, 633)
        LblTotal.Name = "LblTotal"
        LblTotal.Size = New Size(75, 15)
        LblTotal.TabIndex = 3
        LblTotal.Text = "total payable"
        ' 
        ' LblResult
        ' 
        LblResult.AutoSize = True
        LblResult.Location = New Point(278, 637)
        LblResult.Name = "LblResult"
        LblResult.Size = New Size(0, 15)
        LblResult.TabIndex = 4
        ' 
        ' LstViewDataProductos
        ' 
        LstViewDataProductos.Columns.AddRange(New ColumnHeader() {ColumnHeader1, Price, ColumnHeader3, ColumnHeader4})
        LstViewDataProductos.Location = New Point(631, 12)
        LstViewDataProductos.Name = "LstViewDataProductos"
        LstViewDataProductos.Size = New Size(516, 584)
        LstViewDataProductos.TabIndex = 6
        LstViewDataProductos.UseCompatibleStateImageBehavior = False
        LstViewDataProductos.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Name"
        ColumnHeader1.Width = 120
        ' 
        ' Price
        ' 
        Price.Text = "pricec"
        Price.Width = 120
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Quantity"
        ColumnHeader3.Width = 120
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = "Mark"
        ColumnHeader4.Width = 120
        ' 
        ' ListVTicket
        ' 
        ListVTicket.Columns.AddRange(New ColumnHeader() {ColumnHeader2, ColumnHeader5, ColumnHeader6, ColumnHeader7})
        ListVTicket.Location = New Point(12, 210)
        ListVTicket.Name = "ListVTicket"
        ListVTicket.Size = New Size(528, 398)
        ListVTicket.TabIndex = 7
        ListVTicket.UseCompatibleStateImageBehavior = False
        ListVTicket.View = View.Details
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Name"
        ColumnHeader2.Width = 120
        ' 
        ' ColumnHeader5
        ' 
        ColumnHeader5.Text = "pricec"
        ColumnHeader5.Width = 120
        ' 
        ' ColumnHeader6
        ' 
        ColumnHeader6.Text = "Quantity"
        ColumnHeader6.Width = 120
        ' 
        ' ColumnHeader7
        ' 
        ColumnHeader7.Text = "Mark"
        ColumnHeader7.Width = 120
        ' 
        ' TxtQuantity
        ' 
        TxtQuantity.Location = New Point(165, 108)
        TxtQuantity.Name = "TxtQuantity"
        TxtQuantity.Size = New Size(167, 23)
        TxtQuantity.TabIndex = 8
        ' 
        ' BtnAdd
        ' 
        BtnAdd.Location = New Point(165, 149)
        BtnAdd.Name = "BtnAdd"
        BtnAdd.Size = New Size(75, 23)
        BtnAdd.TabIndex = 9
        BtnAdd.Text = "add"
        BtnAdd.UseVisualStyleBackColor = True
        ' 
        ' BtnSelection
        ' 
        BtnSelection.Location = New Point(257, 149)
        BtnSelection.Name = "BtnSelection"
        BtnSelection.Size = New Size(75, 23)
        BtnSelection.TabIndex = 10
        BtnSelection.Text = "select"
        BtnSelection.UseVisualStyleBackColor = True
        ' 
        ' BtnPdfTicket
        ' 
        BtnPdfTicket.Location = New Point(887, 633)
        BtnPdfTicket.Name = "BtnPdfTicket"
        BtnPdfTicket.Size = New Size(75, 50)
        BtnPdfTicket.TabIndex = 11
        BtnPdfTicket.Text = "prit ticket (Pdf)"
        BtnPdfTicket.UseVisualStyleBackColor = True
        ' 
        ' BtnTicketExcel
        ' 
        BtnTicketExcel.Location = New Point(775, 633)
        BtnTicketExcel.Name = "BtnTicketExcel"
        BtnTicketExcel.Size = New Size(75, 50)
        BtnTicketExcel.TabIndex = 12
        BtnTicketExcel.Text = "prit ticket (excel)"
        BtnTicketExcel.UseVisualStyleBackColor = True
        ' 
        ' BtnTicketJason
        ' 
        BtnTicketJason.Location = New Point(661, 633)
        BtnTicketJason.Name = "BtnTicketJason"
        BtnTicketJason.Size = New Size(75, 23)
        BtnTicketJason.TabIndex = 13
        BtnTicketJason.Text = "Print Ticket"
        BtnTicketJason.UseVisualStyleBackColor = True
        ' 
        ' CashRegister
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1159, 695)
        Controls.Add(BtnTicketJason)
        Controls.Add(BtnTicketExcel)
        Controls.Add(BtnPdfTicket)
        Controls.Add(BtnSelection)
        Controls.Add(BtnAdd)
        Controls.Add(TxtQuantity)
        Controls.Add(ListVTicket)
        Controls.Add(LstViewDataProductos)
        Controls.Add(LblResult)
        Controls.Add(LblTotal)
        Controls.Add(Label2)
        Controls.Add(LblSelection)
        Controls.Add(PictureUser)
        Name = "CashRegister"
        Text = "CashRegister"
        CType(PictureUser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureUser As PictureBox
    Friend WithEvents LblSelection As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents LblResult As Label
    Friend WithEvents LstViewDataProductos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Price As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ListVTicket As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents TxtQuantity As TextBox
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnSelection As Button
    Friend WithEvents BtnPdfTicket As Button
    Friend WithEvents BtnTicketExcel As Button
    Friend WithEvents BtnTicketJason As Button
End Class
