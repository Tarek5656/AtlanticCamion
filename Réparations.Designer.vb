<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Réparations
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
        components = New ComponentModel.Container()
        DataGridView1 = New DataGridView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Ajouter = New ToolStripMenuItem()
        Modifier = New ToolStripMenuItem()
        Supprimer = New ToolStripMenuItem()
        Copier = New ToolStripMenuItem()
        Coller = New ToolStripMenuItem()
        Imprimer = New ToolStripMenuItem()
        TableLayoutPanel1 = New TableLayoutPanel()
        GroupBox1 = New GroupBox()
        Label1 = New Label()
        dateFin = New DateTimePicker()
        Réinitialiser = New Button()
        LabelAssurance = New Label()
        LabelCartegrise = New Label()
        LabelCarnet = New Label()
        LabelTonnage = New Label()
        LabelType = New Label()
        LabelMatricule = New Label()
        dateDebut = New DateTimePicker()
        txtReference = New TextBox()
        txtNature = New TextBox()
        txtDesignation = New TextBox()
        txtReparateur = New TextBox()
        txtCode = New TextBox()
        Button1 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.ContextMenuStrip = ContextMenuStrip1
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 311)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1524, 220)
        DataGridView1.TabIndex = 0
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
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 57.6779022F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 42.3220978F))
        TableLayoutPanel1.Size = New Size(1530, 534)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(dateFin)
        GroupBox1.Controls.Add(Réinitialiser)
        GroupBox1.Controls.Add(LabelAssurance)
        GroupBox1.Controls.Add(LabelCartegrise)
        GroupBox1.Controls.Add(LabelCarnet)
        GroupBox1.Controls.Add(LabelTonnage)
        GroupBox1.Controls.Add(LabelType)
        GroupBox1.Controls.Add(LabelMatricule)
        GroupBox1.Controls.Add(dateDebut)
        GroupBox1.Controls.Add(txtReference)
        GroupBox1.Controls.Add(txtNature)
        GroupBox1.Controls.Add(txtDesignation)
        GroupBox1.Controls.Add(txtReparateur)
        GroupBox1.Controls.Add(txtCode)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1524, 302)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Recherche"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(25, 160)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 25)
        Label1.TabIndex = 46
        Label1.Text = "Date Fin :"
        ' 
        ' dateFin
        ' 
        dateFin.Location = New Point(216, 158)
        dateFin.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateFin.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateFin.Name = "dateFin"
        dateFin.Size = New Size(300, 31)
        dateFin.TabIndex = 2
        ' 
        ' Réinitialiser
        ' 
        Réinitialiser.Location = New Point(1366, 97)
        Réinitialiser.Name = "Réinitialiser"
        Réinitialiser.Size = New Size(157, 31)
        Réinitialiser.TabIndex = 7
        Réinitialiser.Text = "Réinitialiser"
        Réinitialiser.UseVisualStyleBackColor = True
        ' 
        ' LabelAssurance
        ' 
        LabelAssurance.AutoSize = True
        LabelAssurance.Location = New Point(1089, 49)
        LabelAssurance.Name = "LabelAssurance"
        LabelAssurance.Size = New Size(88, 25)
        LabelAssurance.TabIndex = 44
        LabelAssurance.Text = "Référence"
        ' 
        ' LabelCartegrise
        ' 
        LabelCartegrise.AutoSize = True
        LabelCartegrise.Location = New Point(566, 163)
        LabelCartegrise.Name = "LabelCartegrise"
        LabelCartegrise.Size = New Size(106, 25)
        LabelCartegrise.TabIndex = 43
        LabelCartegrise.Text = "Réparateur :"
        ' 
        ' LabelCarnet
        ' 
        LabelCarnet.AutoSize = True
        LabelCarnet.Location = New Point(566, 108)
        LabelCarnet.Name = "LabelCarnet"
        LabelCarnet.Size = New Size(116, 25)
        LabelCarnet.TabIndex = 42
        LabelCarnet.Text = "Désignation :"
        ' 
        ' LabelTonnage
        ' 
        LabelTonnage.AutoSize = True
        LabelTonnage.Location = New Point(566, 49)
        LabelTonnage.Name = "LabelTonnage"
        LabelTonnage.Size = New Size(185, 25)
        LabelTonnage.TabIndex = 41
        LabelTonnage.Text = "Nature de réparation :"
        ' 
        ' LabelType
        ' 
        LabelType.AutoSize = True
        LabelType.Location = New Point(25, 103)
        LabelType.Name = "LabelType"
        LabelType.Size = New Size(112, 25)
        LabelType.TabIndex = 40
        LabelType.Text = "Date Debut :"
        ' 
        ' LabelMatricule
        ' 
        LabelMatricule.AutoSize = True
        LabelMatricule.Location = New Point(25, 55)
        LabelMatricule.Name = "LabelMatricule"
        LabelMatricule.Size = New Size(129, 25)
        LabelMatricule.TabIndex = 39
        LabelMatricule.Text = "Code Camion :"
        ' 
        ' dateDebut
        ' 
        dateDebut.Location = New Point(216, 101)
        dateDebut.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateDebut.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateDebut.Name = "dateDebut"
        dateDebut.Size = New Size(300, 31)
        dateDebut.TabIndex = 1
        ' 
        ' txtReference
        ' 
        txtReference.Location = New Point(1223, 46)
        txtReference.MaxLength = 20
        txtReference.Name = "txtReference"
        txtReference.Size = New Size(300, 31)
        txtReference.TabIndex = 6
        ' 
        ' txtNature
        ' 
        txtNature.Location = New Point(757, 46)
        txtNature.MaxLength = 20
        txtNature.Name = "txtNature"
        txtNature.Size = New Size(300, 31)
        txtNature.TabIndex = 3
        ' 
        ' txtDesignation
        ' 
        txtDesignation.Location = New Point(757, 105)
        txtDesignation.MaxLength = 20
        txtDesignation.Name = "txtDesignation"
        txtDesignation.Size = New Size(300, 31)
        txtDesignation.TabIndex = 4
        ' 
        ' txtReparateur
        ' 
        txtReparateur.Location = New Point(757, 160)
        txtReparateur.MaxLength = 20
        txtReparateur.Name = "txtReparateur"
        txtReparateur.Size = New Size(300, 31)
        txtReparateur.TabIndex = 5
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(216, 52)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(97, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(26, 22)
        Button1.TabIndex = 0
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Réparations
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1530, 534)
        Controls.Add(TableLayoutPanel1)
        Name = "Réparations"
        Text = "Réparations"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Ajouter As ToolStripMenuItem
    Friend WithEvents Modifier As ToolStripMenuItem
    Friend WithEvents Supprimer As ToolStripMenuItem
    Friend WithEvents Copier As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Réinitialiser As Button
    Friend WithEvents LabelAssurance As Label
    Friend WithEvents LabelCartegrise As Label
    Friend WithEvents LabelCarnet As Label
    Friend WithEvents LabelTonnage As Label
    Friend WithEvents LabelType As Label
    Friend WithEvents LabelMatricule As Label
    Friend WithEvents dateDebut As DateTimePicker
    Friend WithEvents txtReference As TextBox
    Friend WithEvents txtNature As TextBox
    Friend WithEvents txtDesignation As TextBox
    Friend WithEvents txtReparateur As TextBox
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Coller As ToolStripMenuItem
    Friend WithEvents Imprimer As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents dateFin As DateTimePicker
End Class
