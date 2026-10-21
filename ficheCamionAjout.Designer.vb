<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ficheCamionAjout
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
        txtMatricule = New TextBox()
        txtCarteGrise = New TextBox()
        txtTonnage = New TextBox()
        txtType = New TextBox()
        txtAssurance = New TextBox()
        txtChauffeur = New TextBox()
        dateVisitetech = New DateTimePicker()
        dateCarnetcirc = New DateTimePicker()
        LabelMatricule = New Label()
        LabelType = New Label()
        LabelTonnage = New Label()
        LabelCarnet = New Label()
        LabelVisite = New Label()
        LabelCartegrise = New Label()
        LabelAssurance = New Label()
        LabelChauffeur = New Label()
        Valider = New Button()
        Annuler = New Button()
        Label1 = New Label()
        txtTel = New TextBox()
        Panel1 = New Panel()
        ListBox1 = New ListBox()
        Label2 = New Label()
        Label3 = New Label()
        dateCarteGrise = New DateTimePicker()
        dateAssurance = New DateTimePicker()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtMatricule
        ' 
        txtMatricule.Location = New Point(352, 29)
        txtMatricule.MaxLength = 20
        txtMatricule.Name = "txtMatricule"
        txtMatricule.Size = New Size(300, 31)
        txtMatricule.TabIndex = 0
        ' 
        ' txtCarteGrise
        ' 
        txtCarteGrise.Location = New Point(352, 295)
        txtCarteGrise.MaxLength = 20
        txtCarteGrise.Name = "txtCarteGrise"
        txtCarteGrise.Size = New Size(300, 31)
        txtCarteGrise.TabIndex = 5
        ' 
        ' txtTonnage
        ' 
        txtTonnage.Location = New Point(352, 133)
        txtTonnage.MaxLength = 10
        txtTonnage.Name = "txtTonnage"
        txtTonnage.Size = New Size(300, 31)
        txtTonnage.TabIndex = 2
        ' 
        ' txtType
        ' 
        txtType.Location = New Point(352, 84)
        txtType.MaxLength = 20
        txtType.Name = "txtType"
        txtType.Size = New Size(300, 31)
        txtType.TabIndex = 1
        ' 
        ' txtAssurance
        ' 
        txtAssurance.Location = New Point(352, 395)
        txtAssurance.MaxLength = 20
        txtAssurance.Name = "txtAssurance"
        txtAssurance.Size = New Size(300, 31)
        txtAssurance.TabIndex = 7
        ' 
        ' txtChauffeur
        ' 
        txtChauffeur.Location = New Point(352, 491)
        txtChauffeur.MaxLength = 20
        txtChauffeur.Name = "txtChauffeur"
        txtChauffeur.Size = New Size(300, 31)
        txtChauffeur.TabIndex = 9
        ' 
        ' dateVisitetech
        ' 
        dateVisitetech.Location = New Point(352, 239)
        dateVisitetech.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateVisitetech.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateVisitetech.Name = "dateVisitetech"
        dateVisitetech.Size = New Size(300, 31)
        dateVisitetech.TabIndex = 4
        ' 
        ' dateCarnetcirc
        ' 
        dateCarnetcirc.Location = New Point(352, 185)
        dateCarnetcirc.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateCarnetcirc.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateCarnetcirc.Name = "dateCarnetcirc"
        dateCarnetcirc.Size = New Size(300, 31)
        dateCarnetcirc.TabIndex = 3
        dateCarnetcirc.Value = New Date(2025, 7, 17, 0, 0, 0, 0)
        ' 
        ' LabelMatricule
        ' 
        LabelMatricule.AutoSize = True
        LabelMatricule.Location = New Point(108, 32)
        LabelMatricule.Name = "LabelMatricule"
        LabelMatricule.Size = New Size(93, 25)
        LabelMatricule.TabIndex = 9
        LabelMatricule.Text = "Matricule :"
        ' 
        ' LabelType
        ' 
        LabelType.AutoSize = True
        LabelType.Location = New Point(108, 87)
        LabelType.Name = "LabelType"
        LabelType.Size = New Size(58, 25)
        LabelType.TabIndex = 10
        LabelType.Text = "Type :"
        ' 
        ' LabelTonnage
        ' 
        LabelTonnage.AutoSize = True
        LabelTonnage.Location = New Point(108, 136)
        LabelTonnage.Name = "LabelTonnage"
        LabelTonnage.Size = New Size(88, 25)
        LabelTonnage.TabIndex = 11
        LabelTonnage.Text = "Tonnage :"
        ' 
        ' LabelCarnet
        ' 
        LabelCarnet.AutoSize = True
        LabelCarnet.Location = New Point(108, 190)
        LabelCarnet.Name = "LabelCarnet"
        LabelCarnet.Size = New Size(224, 25)
        LabelCarnet.TabIndex = 12
        LabelCarnet.Text = "Date Carnet de circulation :"
        ' 
        ' LabelVisite
        ' 
        LabelVisite.AutoSize = True
        LabelVisite.Location = New Point(108, 244)
        LabelVisite.Name = "LabelVisite"
        LabelVisite.Size = New Size(187, 25)
        LabelVisite.TabIndex = 13
        LabelVisite.Text = "Date Visite technique :"
        ' 
        ' LabelCartegrise
        ' 
        LabelCartegrise.AutoSize = True
        LabelCartegrise.Location = New Point(108, 298)
        LabelCartegrise.Name = "LabelCartegrise"
        LabelCartegrise.Size = New Size(106, 25)
        LabelCartegrise.TabIndex = 14
        LabelCartegrise.Text = "Carte Grise :"
        ' 
        ' LabelAssurance
        ' 
        LabelAssurance.AutoSize = True
        LabelAssurance.Location = New Point(108, 398)
        LabelAssurance.Name = "LabelAssurance"
        LabelAssurance.Size = New Size(101, 25)
        LabelAssurance.TabIndex = 15
        LabelAssurance.Text = "Assurance :"
        ' 
        ' LabelChauffeur
        ' 
        LabelChauffeur.AutoSize = True
        LabelChauffeur.Location = New Point(108, 494)
        LabelChauffeur.Name = "LabelChauffeur"
        LabelChauffeur.Size = New Size(98, 25)
        LabelChauffeur.TabIndex = 16
        LabelChauffeur.Text = "Chauffeur :"
        ' 
        ' Valider
        ' 
        Valider.Location = New Point(352, 595)
        Valider.Name = "Valider"
        Valider.Size = New Size(143, 32)
        Valider.TabIndex = 11
        Valider.Text = "Valider"
        Valider.UseVisualStyleBackColor = True
        ' 
        ' Annuler
        ' 
        Annuler.Location = New Point(509, 595)
        Annuler.Name = "Annuler"
        Annuler.Size = New Size(143, 32)
        Annuler.TabIndex = 12
        Annuler.Text = "Annuler"
        Annuler.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(108, 544)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 25)
        Label1.TabIndex = 19
        Label1.Text = "Téléphone"
        ' 
        ' txtTel
        ' 
        txtTel.Location = New Point(352, 541)
        txtTel.MaxLength = 10
        txtTel.Name = "txtTel"
        txtTel.Size = New Size(300, 31)
        txtTel.TabIndex = 10
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ListBox1)
        Panel1.Location = New Point(681, 84)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(97, 142)
        Panel1.TabIndex = 20
        ' 
        ' ListBox1
        ' 
        ListBox1.Dock = DockStyle.Fill
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 25
        ListBox1.Location = New Point(0, 0)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(97, 142)
        ListBox1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(108, 345)
        Label2.Name = "Label2"
        Label2.Size = New Size(139, 25)
        Label2.TabIndex = 21
        Label2.Text = "Date Carte Grise"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(108, 445)
        Label3.Name = "Label3"
        Label3.Size = New Size(134, 25)
        Label3.TabIndex = 22
        Label3.Text = "Date Assurance"
        ' 
        ' dateCarteGrise
        ' 
        dateCarteGrise.Location = New Point(352, 340)
        dateCarteGrise.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateCarteGrise.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateCarteGrise.Name = "dateCarteGrise"
        dateCarteGrise.Size = New Size(300, 31)
        dateCarteGrise.TabIndex = 6
        ' 
        ' dateAssurance
        ' 
        dateAssurance.Location = New Point(352, 440)
        dateAssurance.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateAssurance.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateAssurance.Name = "dateAssurance"
        dateAssurance.Size = New Size(300, 31)
        dateAssurance.TabIndex = 8
        ' 
        ' ficheCamionAjout
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 644)
        Controls.Add(dateAssurance)
        Controls.Add(dateCarteGrise)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Controls.Add(txtTel)
        Controls.Add(Label1)
        Controls.Add(Annuler)
        Controls.Add(Valider)
        Controls.Add(LabelChauffeur)
        Controls.Add(LabelAssurance)
        Controls.Add(LabelCartegrise)
        Controls.Add(LabelVisite)
        Controls.Add(LabelCarnet)
        Controls.Add(LabelTonnage)
        Controls.Add(LabelType)
        Controls.Add(LabelMatricule)
        Controls.Add(dateCarnetcirc)
        Controls.Add(dateVisitetech)
        Controls.Add(txtChauffeur)
        Controls.Add(txtAssurance)
        Controls.Add(txtType)
        Controls.Add(txtTonnage)
        Controls.Add(txtCarteGrise)
        Controls.Add(txtMatricule)
        FormBorderStyle = FormBorderStyle.None
        Name = "ficheCamionAjout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ajouter/Modifier un Camion"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtMatricule As TextBox
    Friend WithEvents txtCarteGrise As TextBox
    Friend WithEvents txtTonnage As TextBox
    Friend WithEvents txtType As TextBox
    Friend WithEvents txtAssurance As TextBox
    Friend WithEvents txtChauffeur As TextBox
    Friend WithEvents dateVisitetech As DateTimePicker
    Friend WithEvents dateCarnetcirc As DateTimePicker
    Friend WithEvents LabelMatricule As Label
    Friend WithEvents LabelType As Label
    Friend WithEvents LabelTonnage As Label
    Friend WithEvents LabelCarnet As Label
    Friend WithEvents LabelVisite As Label
    Friend WithEvents LabelCartegrise As Label
    Friend WithEvents LabelAssurance As Label
    Friend WithEvents LabelChauffeur As Label
    Friend WithEvents Valider As Button
    Friend WithEvents Annuler As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTel As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dateCarteGrise As DateTimePicker
    Friend WithEvents dateAssurance As DateTimePicker
End Class
