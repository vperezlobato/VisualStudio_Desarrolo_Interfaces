<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHolaMundo
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
        Me.txtNombre = New System.Windows.Forms.Label()
        Me.txtSaludo = New System.Windows.Forms.TextBox()
        Me.btnSaludar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.AutoSize = True
        Me.txtNombre.Location = New System.Drawing.Point(197, 75)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(47, 13)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.Text = "Nombre:"
        '
        'txtSaludo
        '
        Me.txtSaludo.Location = New System.Drawing.Point(257, 75)
        Me.txtSaludo.Name = "txtSaludo"
        Me.txtSaludo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaludo.TabIndex = 1
        '
        'btnSaludar
        '
        Me.btnSaludar.Location = New System.Drawing.Point(257, 119)
        Me.btnSaludar.Name = "btnSaludar"
        Me.btnSaludar.Size = New System.Drawing.Size(75, 23)
        Me.btnSaludar.TabIndex = 2
        Me.btnSaludar.Text = "Saludar"
        Me.btnSaludar.UseVisualStyleBackColor = True
        '
        'frmHolaMundo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnSaludar)
        Me.Controls.Add(Me.txtSaludo)
        Me.Controls.Add(Me.txtNombre)
        Me.Name = "frmHolaMundo"
        Me.Text = "Formulario Visual Basic"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNombre As Label
    Friend WithEvents txtSaludo As TextBox
    Friend WithEvents btnSaludar As Button
End Class
