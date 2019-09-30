Imports Clases

Public Class frmHolaMundo
    ''' <summary>
    ''' Evento de saludar al click del botón
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSaludar_Click(sender As Object, e As EventArgs) Handles btnSaludar.Click
        Dim objPersona As New clsPersona
        objPersona.nombre = txtSaludo.Text

        If String.IsNullOrEmpty(objPersona.nombre) Then
            MessageBox.Show("Introduzca algun caracter")

        Else
            MessageBox.Show("Hola " + objPersona.nombre)

        End If

    End Sub
End Class
