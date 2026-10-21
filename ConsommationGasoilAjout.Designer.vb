<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsommationGasoilAjout
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtKmDebut = New TextBox()
        dateRemplissage = New DateTimePicker()
        txtQtGasoil = New TextBox()
        txtKmFin = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        txtCode = New TextBox()
        Annuler = New Button()
        Valider = New Button()
        SuspendLayout()
        ' 
        ' txtKmDebut
        ' 
        txtKmDebut.Location = New Point(333, 144)
        txtKmDebut.MaxLength = 10
        txtKmDebut.Name = "txtKmDebut"
        txtKmDebut.Size = New Size(300, 31)
        txtKmDebut.TabIndex = 2
        ' 
        ' dateRemplissage
        ' 
        dateRemplissage.Location = New Point(333, 91)
        dateRemplissage.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateRemplissage.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateRemplissage.Name = "dateRemplissage"
        dateRemplissage.Size = New Size(300, 31)
        dateRemplissage.TabIndex = 1
        dateRemplissage.Value = New Date(2025, 7, 17, 0, 0, 0, 0)
        ' 
        ' txtQtGasoil
        ' 
        txtQtGasoil.Location = New Point(333, 247)
        txtQtGasoil.MaxLength = 10
        txtQtGasoil.Name = "txtQtGasoil"
        txtQtGasoil.Size = New Size(300, 31)
        txtQtGasoil.TabIndex = 4
        ' 
        ' txtKmFin
        ' 
        txtKmFin.Location = New Point(333, 196)
        txtKmFin.MaxLength = 10
        txtKmFin.Name = "txtKmFin"
        txtKmFin.Size = New Size(300, 31)
        txtKmFin.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(74, 96)
        Label1.Name = "Label1"
        Label1.Size = New Size(215, 25)
        Label1.TabIndex = 9
        Label1.Text = "Date Remplissage Gasoil :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(74, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(101, 25)
        Label2.TabIndex = 10
        Label2.Text = "Km Debut :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(79, 199)
        Label3.Name = "Label3"
        Label3.Size = New Size(75, 25)
        Label3.TabIndex = 11
        Label3.Text = "Km Fin :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(74, 250)
        Label4.Name = "Label4"
        Label4.Size = New Size(142, 25)
        Label4.TabIndex = 12
        Label4.Text = "Quantite Gasoil :"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(74, 42)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 25)
        Label6.TabIndex = 14
        Label6.Text = "Code Camion :"
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(333, 39)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' Annuler
        ' 
        Annuler.Location = New Point(490, 312)
        Annuler.Name = "Annuler"
        Annuler.Size = New Size(143, 32)
        Annuler.TabIndex = 6
        Annuler.Text = "Annuler"
        Annuler.UseVisualStyleBackColor = True
        ' 
        ' Valider
        ' 
        Valider.Location = New Point(333, 312)
        Valider.Name = "Valider"
        Valider.Size = New Size(143, 32)
        Valider.TabIndex = 5
        Valider.Text = "Valider"
        Valider.UseVisualStyleBackColor = True
        ' 
        ' ConsommationGasoilAjout
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Annuler)
        Controls.Add(Valider)
        Controls.Add(txtCode)
        Controls.Add(Label6)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtKmFin)
        Controls.Add(txtQtGasoil)
        Controls.Add(dateRemplissage)
        Controls.Add(txtKmDebut)
        FormBorderStyle = FormBorderStyle.None
        Name = "ConsommationGasoilAjout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ajouter/Modifier Consommation Gasoil"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtKmDebut As TextBox
    Friend WithEvents dateRemplissage As DateTimePicker
    Friend WithEvents txtQtGasoil As TextBox
    Friend WithEvents txtKmFin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Annuler As Button
    Friend WithEvents Valider As Button
End Class
