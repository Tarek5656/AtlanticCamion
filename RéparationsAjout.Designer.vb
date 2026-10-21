<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RéparationsAjout
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
        LabelChauffeur = New Label()
        LabelAssurance = New Label()
        LabelCartegrise = New Label()
        LabelCarnet = New Label()
        LabelTonnage = New Label()
        LabelMatricule = New Label()
        txtReference = New TextBox()
        txtNature = New TextBox()
        txtDesignation = New TextBox()
        txtReparateur = New TextBox()
        txtCode = New TextBox()
        picFacture = New PictureBox()
        Button1 = New Button()
        Annuler = New Button()
        Valider = New Button()
        Panel1 = New Panel()
        ListBox1 = New ListBox()
        Label1 = New Label()
        dateFin = New DateTimePicker()
        LabelType = New Label()
        dateDebut = New DateTimePicker()
        CType(picFacture, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' LabelChauffeur
        ' 
        LabelChauffeur.AutoSize = True
        LabelChauffeur.Location = New Point(134, 394)
        LabelChauffeur.Name = "LabelChauffeur"
        LabelChauffeur.Size = New Size(77, 25)
        LabelChauffeur.TabIndex = 33
        LabelChauffeur.Text = "Facture :"
        ' 
        ' LabelAssurance
        ' 
        LabelAssurance.AutoSize = True
        LabelAssurance.Location = New Point(134, 346)
        LabelAssurance.Name = "LabelAssurance"
        LabelAssurance.Size = New Size(88, 25)
        LabelAssurance.TabIndex = 32
        LabelAssurance.Text = "Référence"
        ' 
        ' LabelCartegrise
        ' 
        LabelCartegrise.AutoSize = True
        LabelCartegrise.Location = New Point(134, 295)
        LabelCartegrise.Name = "LabelCartegrise"
        LabelCartegrise.Size = New Size(106, 25)
        LabelCartegrise.TabIndex = 31
        LabelCartegrise.Text = "Réparateur :"
        ' 
        ' LabelCarnet
        ' 
        LabelCarnet.AutoSize = True
        LabelCarnet.Location = New Point(134, 240)
        LabelCarnet.Name = "LabelCarnet"
        LabelCarnet.Size = New Size(116, 25)
        LabelCarnet.TabIndex = 29
        LabelCarnet.Text = "Désignation :"
        ' 
        ' LabelTonnage
        ' 
        LabelTonnage.AutoSize = True
        LabelTonnage.Location = New Point(134, 187)
        LabelTonnage.Name = "LabelTonnage"
        LabelTonnage.Size = New Size(185, 25)
        LabelTonnage.TabIndex = 28
        LabelTonnage.Text = "Nature de réparation :"
        ' 
        ' LabelMatricule
        ' 
        LabelMatricule.AutoSize = True
        LabelMatricule.Location = New Point(134, 30)
        LabelMatricule.Name = "LabelMatricule"
        LabelMatricule.Size = New Size(129, 25)
        LabelMatricule.TabIndex = 26
        LabelMatricule.Text = "Code Camion :"
        ' 
        ' txtReference
        ' 
        txtReference.Location = New Point(378, 343)
        txtReference.MaxLength = 20
        txtReference.Name = "txtReference"
        txtReference.Size = New Size(300, 31)
        txtReference.TabIndex = 6
        ' 
        ' txtNature
        ' 
        txtNature.Location = New Point(378, 184)
        txtNature.MaxLength = 20
        txtNature.Name = "txtNature"
        txtNature.Size = New Size(300, 31)
        txtNature.TabIndex = 3
        ' 
        ' txtDesignation
        ' 
        txtDesignation.Location = New Point(378, 237)
        txtDesignation.MaxLength = 20
        txtDesignation.Name = "txtDesignation"
        txtDesignation.Size = New Size(300, 31)
        txtDesignation.TabIndex = 4
        ' 
        ' txtReparateur
        ' 
        txtReparateur.Location = New Point(378, 292)
        txtReparateur.MaxLength = 20
        txtReparateur.Name = "txtReparateur"
        txtReparateur.Size = New Size(300, 31)
        txtReparateur.TabIndex = 5
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(378, 27)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' picFacture
        ' 
        picFacture.Location = New Point(378, 394)
        picFacture.Name = "picFacture"
        picFacture.Size = New Size(300, 197)
        picFacture.TabIndex = 35
        picFacture.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(217, 394)
        Button1.Name = "Button1"
        Button1.Size = New Size(148, 31)
        Button1.TabIndex = 7
        Button1.Text = "Ajouter"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Annuler
        ' 
        Annuler.Location = New Point(535, 610)
        Annuler.Name = "Annuler"
        Annuler.Size = New Size(143, 32)
        Annuler.TabIndex = 9
        Annuler.Text = "Annuler"
        Annuler.UseVisualStyleBackColor = True
        ' 
        ' Valider
        ' 
        Valider.Location = New Point(378, 610)
        Valider.Name = "Valider"
        Valider.Size = New Size(143, 32)
        Valider.TabIndex = 8
        Valider.Text = "Valider"
        Valider.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ListBox1)
        Panel1.Location = New Point(816, 171)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(147, 185)
        Panel1.TabIndex = 36
        ' 
        ' ListBox1
        ' 
        ListBox1.Dock = DockStyle.Fill
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 25
        ListBox1.Location = New Point(0, 0)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(147, 185)
        ListBox1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(134, 135)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 25)
        Label1.TabIndex = 50
        Label1.Text = "Date Fin :"
        ' 
        ' dateFin
        ' 
        dateFin.Location = New Point(378, 130)
        dateFin.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateFin.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateFin.Name = "dateFin"
        dateFin.Size = New Size(300, 31)
        dateFin.TabIndex = 2
        ' 
        ' LabelType
        ' 
        LabelType.AutoSize = True
        LabelType.Location = New Point(134, 78)
        LabelType.Name = "LabelType"
        LabelType.Size = New Size(112, 25)
        LabelType.TabIndex = 49
        LabelType.Text = "Date Debut :"
        ' 
        ' dateDebut
        ' 
        dateDebut.Location = New Point(378, 73)
        dateDebut.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateDebut.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateDebut.Name = "dateDebut"
        dateDebut.Size = New Size(300, 31)
        dateDebut.TabIndex = 1
        ' 
        ' RéparationsAjout
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(994, 710)
        Controls.Add(Label1)
        Controls.Add(dateFin)
        Controls.Add(LabelType)
        Controls.Add(dateDebut)
        Controls.Add(Panel1)
        Controls.Add(Annuler)
        Controls.Add(Valider)
        Controls.Add(Button1)
        Controls.Add(picFacture)
        Controls.Add(LabelChauffeur)
        Controls.Add(LabelAssurance)
        Controls.Add(LabelCartegrise)
        Controls.Add(LabelCarnet)
        Controls.Add(LabelTonnage)
        Controls.Add(LabelMatricule)
        Controls.Add(txtReference)
        Controls.Add(txtNature)
        Controls.Add(txtDesignation)
        Controls.Add(txtReparateur)
        Controls.Add(txtCode)
        FormBorderStyle = FormBorderStyle.None
        Name = "RéparationsAjout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ajouter/Modifier Réparations"
        CType(picFacture, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents LabelChauffeur As Label
    Friend WithEvents LabelAssurance As Label
    Friend WithEvents LabelCartegrise As Label
    Friend WithEvents LabelCarnet As Label
    Friend WithEvents LabelTonnage As Label
    Friend WithEvents LabelMatricule As Label
    Friend WithEvents txtReference As TextBox
    Friend WithEvents txtNature As TextBox
    Friend WithEvents txtDesignation As TextBox
    Friend WithEvents txtReparateur As TextBox
    Friend WithEvents txtCode As TextBox
    Friend WithEvents picFacture As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Annuler As Button
    Friend WithEvents Valider As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dateFin As DateTimePicker
    Friend WithEvents LabelType As Label
    Friend WithEvents dateDebut As DateTimePicker
End Class
