<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit_Inventory
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
        TxtMark = New TextBox()
        TxtQuanity = New TextBox()
        TxtPrice = New TextBox()
        TxtAddName = New TextBox()
        BtnCancel = New Button()
        Btnaccept = New Button()
        ListViewDataProduct = New ListView()
        ColumnHeader1 = New ColumnHeader()
        Price = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        PictureUser = New PictureBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        BtnDelete = New Button()
        BtnQuantityProductTotal = New Button()
        ComBoxElection = New ComboBox()
        CheckBoxPerecedero = New CheckBox()
        DateTimeExpirationDate = New DateTimePicker()
        CType(PictureUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtMark
        ' 
        TxtMark.Location = New Point(221, 367)
        TxtMark.Margin = New Padding(3, 4, 3, 4)
        TxtMark.Name = "TxtMark"
        TxtMark.Size = New Size(114, 27)
        TxtMark.TabIndex = 23
        ' 
        ' TxtQuanity
        ' 
        TxtQuanity.Location = New Point(221, 289)
        TxtQuanity.Margin = New Padding(3, 4, 3, 4)
        TxtQuanity.Name = "TxtQuanity"
        TxtQuanity.Size = New Size(114, 27)
        TxtQuanity.TabIndex = 22
        ' 
        ' TxtPrice
        ' 
        TxtPrice.Location = New Point(221, 237)
        TxtPrice.Margin = New Padding(3, 4, 3, 4)
        TxtPrice.Name = "TxtPrice"
        TxtPrice.Size = New Size(114, 27)
        TxtPrice.TabIndex = 21
        ' 
        ' TxtAddName
        ' 
        TxtAddName.Location = New Point(221, 179)
        TxtAddName.Margin = New Padding(3, 4, 3, 4)
        TxtAddName.Name = "TxtAddName"
        TxtAddName.Size = New Size(114, 27)
        TxtAddName.TabIndex = 20
        ' 
        ' BtnCancel
        ' 
        BtnCancel.Location = New Point(249, 508)
        BtnCancel.Margin = New Padding(3, 4, 3, 4)
        BtnCancel.Name = "BtnCancel"
        BtnCancel.Size = New Size(86, 31)
        BtnCancel.TabIndex = 19
        BtnCancel.Text = "Cancele"
        BtnCancel.UseVisualStyleBackColor = True
        ' 
        ' Btnaccept
        ' 
        Btnaccept.Location = New Point(151, 508)
        Btnaccept.Margin = New Padding(3, 4, 3, 4)
        Btnaccept.Name = "Btnaccept"
        Btnaccept.Size = New Size(86, 31)
        Btnaccept.TabIndex = 18
        Btnaccept.Text = "Accept"
        Btnaccept.UseVisualStyleBackColor = True
        ' 
        ' ListViewDataProduct
        ' 
        ListViewDataProduct.Columns.AddRange(New ColumnHeader() {ColumnHeader1, Price, ColumnHeader3, ColumnHeader4, ColumnHeader2})
        ListViewDataProduct.Location = New Point(615, 112)
        ListViewDataProduct.Margin = New Padding(3, 4, 3, 4)
        ListViewDataProduct.Name = "ListViewDataProduct"
        ListViewDataProduct.Size = New Size(818, 775)
        ListViewDataProduct.TabIndex = 17
        ListViewDataProduct.UseCompatibleStateImageBehavior = False
        ListViewDataProduct.View = View.Details
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
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "expiration date"
        ColumnHeader2.Width = 140
        ' 
        ' PictureUser
        ' 
        PictureUser.Location = New Point(97, 69)
        PictureUser.Margin = New Padding(3, 4, 3, 4)
        PictureUser.Name = "PictureUser"
        PictureUser.Size = New Size(73, 67)
        PictureUser.SizeMode = PictureBoxSizeMode.StretchImage
        PictureUser.TabIndex = 16
        PictureUser.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(110, 377)
        Label4.Name = "Label4"
        Label4.Size = New Size(42, 20)
        Label4.TabIndex = 15
        Label4.Text = "Mark"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(110, 300)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 20)
        Label3.TabIndex = 14
        Label3.Text = "Quantity"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(110, 248)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 20)
        Label2.TabIndex = 13
        Label2.Text = "Price"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(110, 183)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 12
        Label1.Text = "Name"
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Location = New Point(198, 547)
        BtnDelete.Margin = New Padding(3, 4, 3, 4)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(86, 31)
        BtnDelete.TabIndex = 24
        BtnDelete.Text = "Delete"
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' BtnQuantityProductTotal
        ' 
        BtnQuantityProductTotal.Location = New Point(443, 857)
        BtnQuantityProductTotal.Margin = New Padding(3, 4, 3, 4)
        BtnQuantityProductTotal.Name = "BtnQuantityProductTotal"
        BtnQuantityProductTotal.Size = New Size(165, 31)
        BtnQuantityProductTotal.TabIndex = 25
        BtnQuantityProductTotal.Text = "Quantity total product"
        BtnQuantityProductTotal.UseVisualStyleBackColor = True
        ' 
        ' ComBoxElection
        ' 
        ComBoxElection.FormattingEnabled = True
        ComBoxElection.Items.AddRange(New Object() {"Add", "Edit"})
        ComBoxElection.Location = New Point(168, 469)
        ComBoxElection.Margin = New Padding(3, 4, 3, 4)
        ComBoxElection.Name = "ComBoxElection"
        ComBoxElection.Size = New Size(138, 28)
        ComBoxElection.TabIndex = 26
        ' 
        ' CheckBoxPerecedero
        ' 
        CheckBoxPerecedero.AutoSize = True
        CheckBoxPerecedero.Location = New Point(416, 184)
        CheckBoxPerecedero.Margin = New Padding(3, 4, 3, 4)
        CheckBoxPerecedero.Name = "CheckBoxPerecedero"
        CheckBoxPerecedero.Size = New Size(105, 24)
        CheckBoxPerecedero.TabIndex = 27
        CheckBoxPerecedero.Text = "Perecedero"
        CheckBoxPerecedero.UseVisualStyleBackColor = True
        ' 
        ' DateTimeExpirationDate
        ' 
        DateTimeExpirationDate.Format = DateTimePickerFormat.Short
        DateTimeExpirationDate.Location = New Point(405, 215)
        DateTimeExpirationDate.Name = "DateTimeExpirationDate"
        DateTimeExpirationDate.Size = New Size(127, 27)
        DateTimeExpirationDate.TabIndex = 29
        ' 
        ' Edit_Inventory
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1613, 1055)
        Controls.Add(DateTimeExpirationDate)
        Controls.Add(CheckBoxPerecedero)
        Controls.Add(ComBoxElection)
        Controls.Add(BtnQuantityProductTotal)
        Controls.Add(BtnDelete)
        Controls.Add(TxtMark)
        Controls.Add(TxtQuanity)
        Controls.Add(TxtPrice)
        Controls.Add(TxtAddName)
        Controls.Add(BtnCancel)
        Controls.Add(Btnaccept)
        Controls.Add(ListViewDataProduct)
        Controls.Add(PictureUser)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Edit_Inventory"
        Text = "Edit_Inventory"
        CType(PictureUser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtMark As TextBox
    Friend WithEvents TxtQuanity As TextBox
    Friend WithEvents TxtPrice As TextBox
    Friend WithEvents TxtAddName As TextBox
    Friend WithEvents BtnCancel As Button
    Friend WithEvents Btnaccept As Button
    Friend WithEvents ListViewDataProduct As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Price As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents PictureUser As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnQuantityProductTotal As Button
    Friend WithEvents ComBoxElection As ComboBox
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents CheckBoxPerecedero As CheckBox
    Private WithEvents DateTimeExpirationDate As DateTimePicker
End Class
