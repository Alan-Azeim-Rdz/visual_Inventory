﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        BtnReplace = New Button()
        BtnSelect = New Button()
        ListViewDataProduct = New ListView()
        ColumnHeader1 = New ColumnHeader()
        Price = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        PictureUser = New PictureBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        BtnDelete = New Button()
        CType(PictureUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtMark
        ' 
        TxtMark.Location = New Point(193, 275)
        TxtMark.Name = "TxtMark"
        TxtMark.Size = New Size(100, 23)
        TxtMark.TabIndex = 23
        ' 
        ' TxtQuanity
        ' 
        TxtQuanity.Location = New Point(193, 217)
        TxtQuanity.Name = "TxtQuanity"
        TxtQuanity.Size = New Size(100, 23)
        TxtQuanity.TabIndex = 22
        ' 
        ' TxtPrice
        ' 
        TxtPrice.Location = New Point(193, 178)
        TxtPrice.Name = "TxtPrice"
        TxtPrice.Size = New Size(100, 23)
        TxtPrice.TabIndex = 21
        ' 
        ' TxtAddName
        ' 
        TxtAddName.Location = New Point(193, 134)
        TxtAddName.Name = "TxtAddName"
        TxtAddName.Size = New Size(100, 23)
        TxtAddName.TabIndex = 20
        ' 
        ' BtnReplace
        ' 
        BtnReplace.Location = New Point(193, 445)
        BtnReplace.Name = "BtnReplace"
        BtnReplace.Size = New Size(75, 23)
        BtnReplace.TabIndex = 19
        BtnReplace.Text = "Repalce"
        BtnReplace.UseVisualStyleBackColor = True
        ' 
        ' BtnSelect
        ' 
        BtnSelect.Location = New Point(193, 362)
        BtnSelect.Name = "BtnSelect"
        BtnSelect.Size = New Size(75, 23)
        BtnSelect.TabIndex = 18
        BtnSelect.Text = "Select"
        BtnSelect.UseVisualStyleBackColor = True
        ' 
        ' ListViewDataProduct
        ' 
        ListViewDataProduct.Columns.AddRange(New ColumnHeader() {ColumnHeader1, Price, ColumnHeader3, ColumnHeader4})
        ListViewDataProduct.Location = New Point(538, 84)
        ListViewDataProduct.Name = "ListViewDataProduct"
        ListViewDataProduct.Size = New Size(565, 582)
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
        ' PictureUser
        ' 
        PictureUser.Location = New Point(85, 52)
        PictureUser.Name = "PictureUser"
        PictureUser.Size = New Size(100, 50)
        PictureUser.SizeMode = PictureBoxSizeMode.AutoSize
        PictureUser.TabIndex = 16
        PictureUser.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(96, 283)
        Label4.Name = "Label4"
        Label4.Size = New Size(34, 15)
        Label4.TabIndex = 15
        Label4.Text = "Mark"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(96, 225)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 15)
        Label3.TabIndex = 14
        Label3.Text = "Quantity"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(96, 186)
        Label2.Name = "Label2"
        Label2.Size = New Size(33, 15)
        Label2.TabIndex = 13
        Label2.Text = "Price"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(96, 137)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 12
        Label1.Text = "Name"
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Location = New Point(193, 513)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(75, 23)
        BtnDelete.TabIndex = 24
        BtnDelete.Text = "Delete"
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' Edit_Inventory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1189, 794)
        Controls.Add(BtnDelete)
        Controls.Add(TxtMark)
        Controls.Add(TxtQuanity)
        Controls.Add(TxtPrice)
        Controls.Add(TxtAddName)
        Controls.Add(BtnReplace)
        Controls.Add(BtnSelect)
        Controls.Add(ListViewDataProduct)
        Controls.Add(PictureUser)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
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
    Friend WithEvents BtnReplace As Button
    Friend WithEvents BtnSelect As Button
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
End Class