<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        PicturUser = New PictureBox()
        LstViewDataProductos = New ListView()
        ColumnHeader1 = New ColumnHeader()
        Price = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        BtnSearch = New Button()
        BtnQuantityProductTotal = New Button()
        TxtAddName = New TextBox()
        TxtPrice = New TextBox()
        TxtQuanity = New TextBox()
        TxtMark = New TextBox()
        CType(PicturUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 0
        Label1.Text = "Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(23, 114)
        Label2.Name = "Label2"
        Label2.Size = New Size(33, 15)
        Label2.TabIndex = 1
        Label2.Text = "Price"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(23, 153)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 15)
        Label3.TabIndex = 2
        Label3.Text = "Quantity"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(23, 211)
        Label4.Name = "Label4"
        Label4.Size = New Size(34, 15)
        Label4.TabIndex = 3
        Label4.Text = "Mark"
        ' 
        ' PicturUser
        ' 
        PicturUser.Location = New Point(12, 12)
        PicturUser.Name = "PicturUser"
        PicturUser.Size = New Size(100, 50)
        PicturUser.SizeMode = PictureBoxSizeMode.AutoSize
        PicturUser.TabIndex = 4
        PicturUser.TabStop = False
        ' 
        ' LstViewDataProductos
        ' 
        LstViewDataProductos.Columns.AddRange(New ColumnHeader() {ColumnHeader1, Price, ColumnHeader3, ColumnHeader4})
        LstViewDataProductos.Location = New Point(465, 12)
        LstViewDataProductos.Name = "LstViewDataProductos"
        LstViewDataProductos.Size = New Size(565, 582)
        LstViewDataProductos.TabIndex = 5
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
        ' BtnSearch
        ' 
        BtnSearch.Location = New Point(190, 303)
        BtnSearch.Name = "BtnSearch"
        BtnSearch.Size = New Size(75, 23)
        BtnSearch.TabIndex = 6
        BtnSearch.Text = "Add"
        BtnSearch.UseVisualStyleBackColor = True
        ' 
        ' BtnQuantityProductTotal
        ' 
        BtnQuantityProductTotal.Location = New Point(339, 615)
        BtnQuantityProductTotal.Name = "BtnQuantityProductTotal"
        BtnQuantityProductTotal.Size = New Size(75, 23)
        BtnQuantityProductTotal.TabIndex = 7
        BtnQuantityProductTotal.Text = "Qunatity product"
        BtnQuantityProductTotal.UseVisualStyleBackColor = True
        ' 
        ' TxtAddName
        ' 
        TxtAddName.Location = New Point(120, 62)
        TxtAddName.Name = "TxtAddName"
        TxtAddName.Size = New Size(100, 23)
        TxtAddName.TabIndex = 8
        ' 
        ' TxtPrice
        ' 
        TxtPrice.Location = New Point(120, 106)
        TxtPrice.Name = "TxtPrice"
        TxtPrice.Size = New Size(100, 23)
        TxtPrice.TabIndex = 9
        ' 
        ' TxtQuanity
        ' 
        TxtQuanity.Location = New Point(120, 145)
        TxtQuanity.Name = "TxtQuanity"
        TxtQuanity.Size = New Size(100, 23)
        TxtQuanity.TabIndex = 10
        ' 
        ' TxtMark
        ' 
        TxtMark.Location = New Point(120, 203)
        TxtMark.Name = "TxtMark"
        TxtMark.Size = New Size(100, 23)
        TxtMark.TabIndex = 11
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1042, 675)
        Controls.Add(TxtMark)
        Controls.Add(TxtQuanity)
        Controls.Add(TxtPrice)
        Controls.Add(TxtAddName)
        Controls.Add(BtnQuantityProductTotal)
        Controls.Add(BtnSearch)
        Controls.Add(LstViewDataProductos)
        Controls.Add(PicturUser)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        CType(PicturUser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PicturUser As PictureBox
    Friend WithEvents LstViewDataProductos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Price As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents BtnSearch As Button
    Friend WithEvents BtnQuantityProductTotal As Button
    Friend WithEvents TxtAddName As TextBox
    Friend WithEvents TxtPrice As TextBox
    Friend WithEvents TxtQuanity As TextBox
    Friend WithEvents TxtMark As TextBox

End Class
