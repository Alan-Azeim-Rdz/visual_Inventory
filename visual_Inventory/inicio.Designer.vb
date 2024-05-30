<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inicio
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
        PicturEmplayPhoto = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        TxtEmail = New TextBox()
        TxtPasword = New TextBox()
        BtnLogin = New Button()
        BtnRegister = New Button()
        BtnUploadImage = New Button()
        CType(PicturEmplayPhoto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicturEmplayPhoto
        ' 
        PicturEmplayPhoto.BackgroundImage = My.Resources.Resources.glasses
        PicturEmplayPhoto.Image = My.Resources.Resources.alan
        PicturEmplayPhoto.Location = New Point(613, 66)
        PicturEmplayPhoto.Name = "PicturEmplayPhoto"
        PicturEmplayPhoto.Size = New Size(245, 237)
        PicturEmplayPhoto.SizeMode = PictureBoxSizeMode.StretchImage
        PicturEmplayPhoto.TabIndex = 0
        PicturEmplayPhoto.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(120, 188)
        Label1.Name = "Label1"
        Label1.Size = New Size(36, 15)
        Label1.TabIndex = 1
        Label1.Text = "email"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(120, 257)
        Label2.Name = "Label2"
        Label2.Size = New Size(52, 15)
        Label2.TabIndex = 2
        Label2.Text = "pasword"
        ' 
        ' TxtEmail
        ' 
        TxtEmail.Location = New Point(245, 185)
        TxtEmail.Name = "TxtEmail"
        TxtEmail.Size = New Size(234, 23)
        TxtEmail.TabIndex = 3
        ' 
        ' TxtPasword
        ' 
        TxtPasword.Location = New Point(245, 254)
        TxtPasword.Name = "TxtPasword"
        TxtPasword.Size = New Size(234, 23)
        TxtPasword.TabIndex = 4
        ' 
        ' BtnLogin
        ' 
        BtnLogin.Location = New Point(257, 325)
        BtnLogin.Name = "BtnLogin"
        BtnLogin.Size = New Size(75, 23)
        BtnLogin.TabIndex = 5
        BtnLogin.Text = "login"
        BtnLogin.UseVisualStyleBackColor = True
        ' 
        ' BtnRegister
        ' 
        BtnRegister.Location = New Point(382, 325)
        BtnRegister.Name = "BtnRegister"
        BtnRegister.Size = New Size(75, 23)
        BtnRegister.TabIndex = 6
        BtnRegister.Text = "register"
        BtnRegister.UseVisualStyleBackColor = True
        ' 
        ' BtnUploadImage
        ' 
        BtnUploadImage.Location = New Point(667, 362)
        BtnUploadImage.Name = "BtnUploadImage"
        BtnUploadImage.Size = New Size(130, 23)
        BtnUploadImage.TabIndex = 7
        BtnUploadImage.Text = "Upload Image"
        BtnUploadImage.UseVisualStyleBackColor = True
        ' 
        ' inicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(991, 640)
        Controls.Add(BtnUploadImage)
        Controls.Add(BtnRegister)
        Controls.Add(BtnLogin)
        Controls.Add(TxtPasword)
        Controls.Add(TxtEmail)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PicturEmplayPhoto)
        Name = "inicio"
        Text = "inicio"
        CType(PicturEmplayPhoto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicturEmplayPhoto As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents TxtPasword As TextBox
    Friend WithEvents BtnLogin As Button
    Friend WithEvents BtnRegister As Button
    Friend WithEvents BtnUploadImage As Button
End Class
