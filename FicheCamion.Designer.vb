<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FicheCamion

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Ajouter = New ToolStripMenuItem()
        Modifier = New ToolStripMenuItem()
        Supprimer = New ToolStripMenuItem()
        Copier = New ToolStripMenuItem()
        Coller = New ToolStripMenuItem()
        Imprimer = New ToolStripMenuItem()
        DataGridView1 = New DataGridView()
        TableLayoutPanel1 = New TableLayoutPanel()
        GroupBox1 = New GroupBox()
        txtStatut = New TextBox()
        Label5 = New Label()
        Button1 = New Button()
        Réinitialiser = New Button()
        txtCode = New TextBox()
        Label4 = New Label()
        dateAssurance = New DateTimePicker()
        dateCarteGrise = New DateTimePicker()
        Label3 = New Label()
        Label2 = New Label()
        txtTel = New TextBox()
        Label1 = New Label()
        LabelChauffeur = New Label()
        LabelAssurance = New Label()
        txtChauffeur = New TextBox()
        txtAssurance = New TextBox()
        LabelCartegrise = New Label()
        LabelVisite = New Label()
        LabelCarnet = New Label()
        LabelTonnage = New Label()
        LabelType = New Label()
        LabelMatricule = New Label()
        dateCarnetcirc = New DateTimePicker()
        dateVisitetech = New DateTimePicker()
        txtType = New TextBox()
        txtTonnage = New TextBox()
        txtCarteGrise = New TextBox()
        txtMatricule = New TextBox()
        ContextMenuStrip1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Ajouter, Modifier, Supprimer, Copier, Coller, Imprimer})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(168, 196)
        ' 
        ' Ajouter
        ' 
        Ajouter.Name = "Ajouter"
        Ajouter.Size = New Size(167, 32)
        Ajouter.Text = "Ajouter"
        ' 
        ' Modifier
        ' 
        Modifier.Name = "Modifier"
        Modifier.Size = New Size(167, 32)
        Modifier.Text = "Modifier"
        ' 
        ' Supprimer
        ' 
        Supprimer.Name = "Supprimer"
        Supprimer.Size = New Size(167, 32)
        Supprimer.Text = "Supprimer"
        ' 
        ' Copier
        ' 
        Copier.Name = "Copier"
        Copier.Size = New Size(167, 32)
        Copier.Text = "Copier"
        ' 
        ' Coller
        ' 
        Coller.Name = "Coller"
        Coller.Size = New Size(167, 32)
        Coller.Text = "Coller"
        ' 
        ' Imprimer
        ' 
        Imprimer.Name = "Imprimer"
        Imprimer.Size = New Size(167, 32)
        Imprimer.Text = "Imprimer"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.ContextMenuStrip = ContextMenuStrip1
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 308)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1918, 270)
        DataGridView1.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(DataGridView1, 0, 1)
        TableLayoutPanel1.Controls.Add(GroupBox1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 52.6678123F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 47.3321877F))
        TableLayoutPanel1.Size = New Size(1924, 581)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtStatut)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Réinitialiser)
        GroupBox1.Controls.Add(txtCode)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(dateAssurance)
        GroupBox1.Controls.Add(dateCarteGrise)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtTel)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(LabelChauffeur)
        GroupBox1.Controls.Add(LabelAssurance)
        GroupBox1.Controls.Add(txtChauffeur)
        GroupBox1.Controls.Add(txtAssurance)
        GroupBox1.Controls.Add(LabelCartegrise)
        GroupBox1.Controls.Add(LabelVisite)
        GroupBox1.Controls.Add(LabelCarnet)
        GroupBox1.Controls.Add(LabelTonnage)
        GroupBox1.Controls.Add(LabelType)
        GroupBox1.Controls.Add(LabelMatricule)
        GroupBox1.Controls.Add(dateCarnetcirc)
        GroupBox1.Controls.Add(dateVisitetech)
        GroupBox1.Controls.Add(txtType)
        GroupBox1.Controls.Add(txtTonnage)
        GroupBox1.Controls.Add(txtCarteGrise)
        GroupBox1.Controls.Add(txtMatricule)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1918, 299)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Recherche"
        ' 
        ' txtStatut
        ' 
        txtStatut.Location = New Point(662, 33)
        txtStatut.MaxLength = 20
        txtStatut.Name = "txtStatut"
        txtStatut.Size = New Size(300, 31)
        txtStatut.TabIndex = 4
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(436, 36)
        Label5.Name = "Label5"
        Label5.Size = New Size(67, 25)
        Label5.TabIndex = 40
        Label5.Text = "Statut :"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(99, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(29, 26)
        Button1.TabIndex = 38
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Réinitialiser
        ' 
        Réinitialiser.Location = New Point(1727, 81)
        Réinitialiser.Name = "Réinitialiser"
        Réinitialiser.Size = New Size(168, 31)
        Réinitialiser.TabIndex = 13
        Réinitialiser.Text = "Réinitialiser"
        Réinitialiser.UseVisualStyleBackColor = True
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(114, 33)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(20, 36)
        Label4.Name = "Label4"
        Label4.Size = New Size(63, 25)
        Label4.TabIndex = 37
        Label4.Text = "Code :"
        ' 
        ' dateAssurance
        ' 
        dateAssurance.Location = New Point(1163, 135)
        dateAssurance.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateAssurance.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateAssurance.Name = "dateAssurance"
        dateAssurance.Size = New Size(300, 31)
        dateAssurance.TabIndex = 10
        ' 
        ' dateCarteGrise
        ' 
        dateCarteGrise.Location = New Point(1163, 31)
        dateCarteGrise.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateCarteGrise.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateCarteGrise.Name = "dateCarteGrise"
        dateCarteGrise.Size = New Size(300, 31)
        dateCarteGrise.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(989, 137)
        Label3.Name = "Label3"
        Label3.Size = New Size(143, 25)
        Label3.TabIndex = 36
        Label3.Text = "Date Assurance :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(989, 36)
        Label2.Name = "Label2"
        Label2.Size = New Size(148, 25)
        Label2.TabIndex = 35
        Label2.Text = "Date Carte Grise :"
        ' 
        ' txtTel
        ' 
        txtTel.Location = New Point(1595, 27)
        txtTel.MaxLength = 10
        txtTel.Name = "txtTel"
        txtTel.Size = New Size(300, 31)
        txtTel.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(1479, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(101, 25)
        Label1.TabIndex = 34
        Label1.Text = "Téléphone :"
        ' 
        ' LabelChauffeur
        ' 
        LabelChauffeur.AutoSize = True
        LabelChauffeur.Location = New Point(989, 186)
        LabelChauffeur.Name = "LabelChauffeur"
        LabelChauffeur.Size = New Size(98, 25)
        LabelChauffeur.TabIndex = 33
        LabelChauffeur.Text = "Chauffeur :"
        ' 
        ' LabelAssurance
        ' 
        LabelAssurance.AutoSize = True
        LabelAssurance.Location = New Point(989, 90)
        LabelAssurance.Name = "LabelAssurance"
        LabelAssurance.Size = New Size(101, 25)
        LabelAssurance.TabIndex = 32
        LabelAssurance.Text = "Assurance :"
        ' 
        ' txtChauffeur
        ' 
        txtChauffeur.Location = New Point(1163, 186)
        txtChauffeur.MaxLength = 20
        txtChauffeur.Name = "txtChauffeur"
        txtChauffeur.Size = New Size(300, 31)
        txtChauffeur.TabIndex = 11
        ' 
        ' txtAssurance
        ' 
        txtAssurance.Location = New Point(1163, 90)
        txtAssurance.MaxLength = 20
        txtAssurance.Name = "txtAssurance"
        txtAssurance.Size = New Size(300, 31)
        txtAssurance.TabIndex = 9
        ' 
        ' LabelCartegrise
        ' 
        LabelCartegrise.AutoSize = True
        LabelCartegrise.Location = New Point(436, 181)
        LabelCartegrise.Name = "LabelCartegrise"
        LabelCartegrise.Size = New Size(106, 25)
        LabelCartegrise.TabIndex = 26
        LabelCartegrise.Text = "Carte Grise :"
        ' 
        ' LabelVisite
        ' 
        LabelVisite.AutoSize = True
        LabelVisite.Location = New Point(436, 135)
        LabelVisite.Name = "LabelVisite"
        LabelVisite.Size = New Size(187, 25)
        LabelVisite.TabIndex = 25
        LabelVisite.Text = "Date Visite technique :"
        ' 
        ' LabelCarnet
        ' 
        LabelCarnet.AutoSize = True
        LabelCarnet.Location = New Point(436, 81)
        LabelCarnet.Name = "LabelCarnet"
        LabelCarnet.Size = New Size(224, 25)
        LabelCarnet.TabIndex = 24
        LabelCarnet.Text = "Date Carnet de circulation :"
        ' 
        ' LabelTonnage
        ' 
        LabelTonnage.AutoSize = True
        LabelTonnage.Location = New Point(20, 186)
        LabelTonnage.Name = "LabelTonnage"
        LabelTonnage.Size = New Size(88, 25)
        LabelTonnage.TabIndex = 23
        LabelTonnage.Text = "Tonnage :"
        ' 
        ' LabelType
        ' 
        LabelType.AutoSize = True
        LabelType.Location = New Point(20, 136)
        LabelType.Name = "LabelType"
        LabelType.Size = New Size(58, 25)
        LabelType.TabIndex = 22
        LabelType.Text = "Type :"
        ' 
        ' LabelMatricule
        ' 
        LabelMatricule.AutoSize = True
        LabelMatricule.Location = New Point(20, 81)
        LabelMatricule.Name = "LabelMatricule"
        LabelMatricule.Size = New Size(93, 25)
        LabelMatricule.TabIndex = 21
        LabelMatricule.Text = "Matricule :"
        ' 
        ' dateCarnetcirc
        ' 
        dateCarnetcirc.Location = New Point(662, 76)
        dateCarnetcirc.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateCarnetcirc.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateCarnetcirc.Name = "dateCarnetcirc"
        dateCarnetcirc.Size = New Size(300, 31)
        dateCarnetcirc.TabIndex = 5
        dateCarnetcirc.Value = New Date(2025, 7, 17, 0, 0, 0, 0)
        ' 
        ' dateVisitetech
        ' 
        dateVisitetech.Location = New Point(662, 130)
        dateVisitetech.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateVisitetech.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateVisitetech.Name = "dateVisitetech"
        dateVisitetech.Size = New Size(300, 31)
        dateVisitetech.TabIndex = 6
        ' 
        ' txtType
        ' 
        txtType.Location = New Point(114, 133)
        txtType.MaxLength = 20
        txtType.Name = "txtType"
        txtType.Size = New Size(300, 31)
        txtType.TabIndex = 2
        ' 
        ' txtTonnage
        ' 
        txtTonnage.Location = New Point(114, 183)
        txtTonnage.MaxLength = 10
        txtTonnage.Name = "txtTonnage"
        txtTonnage.Size = New Size(300, 31)
        txtTonnage.TabIndex = 3
        ' 
        ' txtCarteGrise
        ' 
        txtCarteGrise.Location = New Point(662, 178)
        txtCarteGrise.MaxLength = 20
        txtCarteGrise.Name = "txtCarteGrise"
        txtCarteGrise.Size = New Size(300, 31)
        txtCarteGrise.TabIndex = 7
        ' 
        ' txtMatricule
        ' 
        txtMatricule.Location = New Point(114, 78)
        txtMatricule.MaxLength = 20
        txtMatricule.Name = "txtMatricule"
        txtMatricule.Size = New Size(300, 31)
        txtMatricule.TabIndex = 1
        ' 
        ' FicheCamion
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1924, 581)
        Controls.Add(TableLayoutPanel1)
        Name = "FicheCamion"
        Text = "Fiche Camion"
        ContextMenuStrip1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Ajouter As ToolStripMenuItem
    Friend WithEvents Modifier As ToolStripMenuItem
    Friend WithEvents Supprimer As ToolStripMenuItem
    Friend WithEvents Copier As ToolStripMenuItem
    Friend WithEvents Coller As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelCartegrise As Label
    Friend WithEvents LabelVisite As Label
    Friend WithEvents LabelCarnet As Label
    Friend WithEvents LabelTonnage As Label
    Friend WithEvents LabelType As Label
    Friend WithEvents LabelMatricule As Label
    Friend WithEvents dateCarnetcirc As DateTimePicker
    Friend WithEvents dateVisitetech As DateTimePicker
    Friend WithEvents txtType As TextBox
    Friend WithEvents txtTonnage As TextBox
    Friend WithEvents txtCarteGrise As TextBox
    Friend WithEvents txtMatricule As TextBox
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dateAssurance As DateTimePicker
    Friend WithEvents dateCarteGrise As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelChauffeur As Label
    Friend WithEvents LabelAssurance As Label
    Friend WithEvents txtChauffeur As TextBox
    Friend WithEvents txtAssurance As TextBox
    Friend WithEvents Réinitialiser As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Imprimer As ToolStripMenuItem
    Friend WithEvents txtStatut As TextBox
    Friend WithEvents Label5 As Label

End Class
