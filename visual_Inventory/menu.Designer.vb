<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class menu
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
        PictureImagePhoto = New PictureBox()
        BtnEditInventory = New Button()
        BtnCashRegister = New Button()
        CType(PictureImagePhoto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureImagePhoto
        ' 
        PictureImagePhoto.BackgroundImage = My.Resources.Resources.glasses
        PictureImagePhoto.Location = New Point(12, 12)
        PictureImagePhoto.Name = "PictureImagePhoto"
        PictureImagePhoto.Size = New Size(77, 76)
        PictureImagePhoto.SizeMode = PictureBoxSizeMode.StretchImage
        PictureImagePhoto.TabIndex = 1
        PictureImagePhoto.TabStop = False
        ' 
        ' BtnEditInventory
        ' 
        BtnEditInventory.Location = New Point(279, 134)
        BtnEditInventory.Name = "BtnEditInventory"
        BtnEditInventory.Size = New Size(396, 172)
        BtnEditInventory.TabIndex = 3
        BtnEditInventory.Text = "Edit inventory"
        BtnEditInventory.UseVisualStyleBackColor = True
        ' 
        ' BtnCashRegister
        ' 
        BtnCashRegister.Location = New Point(279, 375)
        BtnCashRegister.Name = "BtnCashRegister"
        BtnCashRegister.Size = New Size(389, 172)
        BtnCashRegister.TabIndex = 4
        BtnCashRegister.Text = "Cash Register"
        BtnCashRegister.UseVisualStyleBackColor = True
        ' 
        ' menu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(996, 649)
        Controls.Add(BtnCashRegister)
        Controls.Add(BtnEditInventory)
        Controls.Add(PictureImagePhoto)
        Name = "menu"
        Text = "menu"
        CType(PictureImagePhoto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureImagePhoto As PictureBox
    Friend WithEvents BtnEditInventory As Button
    Friend WithEvents BtnCashRegister As Button
End Class
