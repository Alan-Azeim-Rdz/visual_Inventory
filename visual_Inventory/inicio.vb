Imports System.IO
Public Class inicio

    Private Photo As String = String.Empty
    Private i As Integer = 0
    Private url_data_employee As String = "C:\Users\1gren\Documents\archivos_R\Cuentas_Nombres.txt"

    Public Sub New()
        InitializeComponent()
        ShowWelcomeMessage()
        dateandtime()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If File.Exists(url_data_employee) Then
            Dim Data As String() = File.ReadAllLines(url_data_employee)
            Dim Information_login As String = $"{TxtEmail.Text} {TxtPasword.Text}"
            For i As Integer = 0 To Data.Length - 1
                If Data(i) = Information_login Then
                    Dim menuForm As New menu()
                    menuForm.Show()
                    menuForm.ReceivedImage = PicturEmplayPhoto.Image
                    Exit For
                End If
                If i = Data.Length - 1 Then
                    MessageBox.Show("El correo o la contraseña no existen, por favor revíselo")
                    Exit For
                End If
            Next
        Else
            MessageBox.Show("El texto no se encontró en el archivo.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnUploadImage_Click(sender As Object, e As EventArgs) Handles BtnUploadImage.Click
        Dim Images As New OpenFileDialog()
        Images.Filter = "Image Files|*.jpg"
        Images.Title = "Select a Image File"

        ' If the user selects a file, set the path to the textbox
        If Images.ShowDialog() <> DialogResult.OK Then
            Return
        End If
        Try
            ' Load the image using a try-catch block for error handling
            PicturEmplayPhoto.Image = Image.FromFile(Images.FileName)
            Photo = Images.FileName
        Catch ex As Exception
            ' Handle potential exceptions like invalid file format or path issues
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Dim dialog As New SaveFileDialog()
        Dim Information_login As String = $"{TxtEmail.Text} {TxtPasword.Text}"

        If File.Exists(url_data_employee) Then
            Dim Data As String() = File.ReadAllLines(url_data_employee)
            For i As Integer = 0 To Data.Length - 1
                If Data(i) = Information_login Then
                    MessageBox.Show("El correo o la contraseña ya existen")
                    Exit For
                End If
                If i = Data.Length - 1 Then
                    Try
                        ' Write the text to the file at the predefined path
                        File.AppendAllText(url_data_employee, Information_login & Environment.NewLine)

                        ' Success notification
                        MessageBox.Show("Datos guardados exitosamente", "Information_login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        ' Error handling
                        MessageBox.Show("Error al guardar el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next
        Else
            MessageBox.Show("El texto no se encontró en el archivo.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Public Shared Sub ShowWelcomeMessage()
        MessageBox.Show("¡Bienvenido al administrador de inventario!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub dateandtime()
        MessageBox.Show("La fecha y hora actual es: " & DateTime.Now.ToString(), "Fecha y Hora", MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub

End Class