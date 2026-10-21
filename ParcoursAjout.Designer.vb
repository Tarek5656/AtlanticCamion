<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParcoursAjout
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
        txtCode = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        txtVille = New TextBox()
        txtTonnage = New TextBox()
        txtDistance = New TextBox()
        txtClient = New TextBox()
        Annuler = New Button()
        Valider = New Button()
        Panel1 = New Panel()
        ListBox1 = New ListBox()
        Label7 = New Label()
        dateArrivee = New DateTimePicker()
        Label8 = New Label()
        dateDepart = New DateTimePicker()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(375, 52)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(121, 55)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 25)
        Label6.TabIndex = 27
        Label6.Text = "Code Camion :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(116, 353)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 25)
        Label5.TabIndex = 26
        Label5.Text = "Tonnage :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(116, 302)
        Label4.Name = "Label4"
        Label4.Size = New Size(88, 25)
        Label4.TabIndex = 25
        Label4.Text = "Distance :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(121, 251)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 25)
        Label3.TabIndex = 24
        Label3.Text = "Ville :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(121, 203)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 25)
        Label2.TabIndex = 23
        Label2.Text = "Client :"
        ' 
        ' txtVille
        ' 
        txtVille.Location = New Point(375, 248)
        txtVille.MaxLength = 20
        txtVille.Name = "txtVille"
        txtVille.Size = New Size(300, 31)
        txtVille.TabIndex = 4
        ' 
        ' txtTonnage
        ' 
        txtTonnage.Location = New Point(375, 350)
        txtTonnage.MaxLength = 10
        txtTonnage.Name = "txtTonnage"
        txtTonnage.Size = New Size(300, 31)
        txtTonnage.TabIndex = 6
        ' 
        ' txtDistance
        ' 
        txtDistance.Location = New Point(375, 299)
        txtDistance.MaxLength = 10
        txtDistance.Name = "txtDistance"
        txtDistance.Size = New Size(300, 31)
        txtDistance.TabIndex = 5
        ' 
        ' txtClient
        ' 
        txtClient.Location = New Point(375, 200)
        txtClient.MaxLength = 20
        txtClient.Name = "txtClient"
        txtClient.Size = New Size(300, 31)
        txtClient.TabIndex = 3
        ' 
        ' Annuler
        ' 
        Annuler.Location = New Point(532, 404)
        Annuler.Name = "Annuler"
        Annuler.Size = New Size(143, 32)
        Annuler.TabIndex = 8
        Annuler.Text = "Annuler"
        Annuler.UseVisualStyleBackColor = True
        ' 
        ' Valider
        ' 
        Valider.Location = New Point(375, 404)
        Valider.Name = "Valider"
        Valider.Size = New Size(143, 32)
        Valider.TabIndex = 7
        Valider.Text = "Valider"
        Valider.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ListBox1)
        Panel1.Location = New Point(699, 117)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(90, 134)
        Panel1.TabIndex = 28
        ' 
        ' ListBox1
        ' 
        ListBox1.Dock = DockStyle.Fill
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 25
        ListBox1.Location = New Point(0, 0)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(90, 134)
        ListBox1.TabIndex = 0
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(121, 157)
        Label7.Name = "Label7"
        Label7.Size = New Size(118, 25)
        Label7.TabIndex = 46
        Label7.Text = "Date Arrivée :"
        ' 
        ' dateArrivee
        ' 
        dateArrivee.Location = New Point(375, 152)
        dateArrivee.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateArrivee.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateArrivee.Name = "dateArrivee"
        dateArrivee.Size = New Size(300, 31)
        dateArrivee.TabIndex = 2
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(121, 105)
        Label8.Name = "Label8"
        Label8.Size = New Size(117, 25)
        Label8.TabIndex = 45
        Label8.Text = "Date Départ :"
        ' 
        ' dateDepart
        ' 
        dateDepart.Location = New Point(375, 100)
        dateDepart.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateDepart.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateDepart.Name = "dateDepart"
        dateDepart.Size = New Size(300, 31)
        dateDepart.TabIndex = 1
        ' 
        ' ParcoursAjout
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(845, 532)
        Controls.Add(Label7)
        Controls.Add(dateArrivee)
        Controls.Add(Label8)
        Controls.Add(dateDepart)
        Controls.Add(Panel1)
        Controls.Add(Annuler)
        Controls.Add(Valider)
        Controls.Add(txtCode)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(txtVille)
        Controls.Add(txtTonnage)
        Controls.Add(txtDistance)
        Controls.Add(txtClient)
        FormBorderStyle = FormBorderStyle.None
        Name = "ParcoursAjout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ajouter/Modifier Parcours"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtVille As TextBox
    Friend WithEvents txtTonnage As TextBox
    Friend WithEvents txtDistance As TextBox
    Friend WithEvents txtClient As TextBox
    Friend WithEvents Annuler As Button
    Friend WithEvents Valider As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dateArrivee As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents dateDepart As DateTimePicker
End Class
