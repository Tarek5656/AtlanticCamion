<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Parcours
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
        Réinitialiser = New Button()
        txtCode = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtVille = New TextBox()
        txtTonnage = New TextBox()
        txtDistance = New TextBox()
        dateDepart = New DateTimePicker()
        txtClient = New TextBox()
        Button1 = New Button()
        Label7 = New Label()
        dateArrivee = New DateTimePicker()
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
        DataGridView1.Location = New Point(3, 270)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1400, 286)
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
        TableLayoutPanel1.Controls.Add(GroupBox1, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridView1, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 47.7638626F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 52.2361374F))
        TableLayoutPanel1.Size = New Size(1406, 559)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(dateArrivee)
        GroupBox1.Controls.Add(Réinitialiser)
        GroupBox1.Controls.Add(txtCode)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtVille)
        GroupBox1.Controls.Add(txtTonnage)
        GroupBox1.Controls.Add(txtDistance)
        GroupBox1.Controls.Add(dateDepart)
        GroupBox1.Controls.Add(txtClient)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1400, 261)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Recherche"
        ' 
        ' Réinitialiser
        ' 
        Réinitialiser.Location = New Point(1209, 96)
        Réinitialiser.Name = "Réinitialiser"
        Réinitialiser.Size = New Size(135, 32)
        Réinitialiser.TabIndex = 7
        Réinitialiser.Text = "Réinitialiser"
        Réinitialiser.UseVisualStyleBackColor = True
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(165, 43)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(21, 46)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 25)
        Label6.TabIndex = 39
        Label6.Text = "Code Camion :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(938, 46)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 25)
        Label5.TabIndex = 38
        Label5.Text = "Tonnage :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(487, 151)
        Label4.Name = "Label4"
        Label4.Size = New Size(88, 25)
        Label4.TabIndex = 37
        Label4.Text = "Distance :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(492, 100)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 25)
        Label3.TabIndex = 36
        Label3.Text = "Ville :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(492, 46)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 25)
        Label2.TabIndex = 35
        Label2.Text = "Client :"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(21, 97)
        Label1.Name = "Label1"
        Label1.Size = New Size(117, 25)
        Label1.TabIndex = 34
        Label1.Text = "Date Départ :"
        ' 
        ' txtVille
        ' 
        txtVille.Location = New Point(593, 97)
        txtVille.MaxLength = 20
        txtVille.Name = "txtVille"
        txtVille.Size = New Size(300, 31)
        txtVille.TabIndex = 4
        ' 
        ' txtTonnage
        ' 
        txtTonnage.Location = New Point(1044, 43)
        txtTonnage.MaxLength = 10
        txtTonnage.Name = "txtTonnage"
        txtTonnage.Size = New Size(300, 31)
        txtTonnage.TabIndex = 6
        ' 
        ' txtDistance
        ' 
        txtDistance.Location = New Point(593, 148)
        txtDistance.MaxLength = 10
        txtDistance.Name = "txtDistance"
        txtDistance.Size = New Size(300, 31)
        txtDistance.TabIndex = 5
        ' 
        ' dateDepart
        ' 
        dateDepart.Location = New Point(165, 95)
        dateDepart.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateDepart.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateDepart.Name = "dateDepart"
        dateDepart.Size = New Size(300, 31)
        dateDepart.TabIndex = 1
        ' 
        ' txtClient
        ' 
        txtClient.Location = New Point(593, 43)
        txtClient.MaxLength = 20
        txtClient.Name = "txtClient"
        txtClient.Size = New Size(300, 31)
        txtClient.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(97, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(22, 21)
        Button1.TabIndex = 0
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(21, 149)
        Label7.Name = "Label7"
        Label7.Size = New Size(118, 25)
        Label7.TabIndex = 42
        Label7.Text = "Date Arrivée :"
        ' 
        ' dateArrivee
        ' 
        dateArrivee.Location = New Point(165, 147)
        dateArrivee.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateArrivee.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateArrivee.Name = "dateArrivee"
        dateArrivee.Size = New Size(300, 31)
        dateArrivee.TabIndex = 2
        ' 
        ' Parcours
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1406, 559)
        Controls.Add(TableLayoutPanel1)
        Name = "Parcours"
        Text = "Parcours"
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
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVille As TextBox
    Friend WithEvents txtTonnage As TextBox
    Friend WithEvents txtDistance As TextBox
    Friend WithEvents dateDepart As DateTimePicker
    Friend WithEvents txtClient As TextBox
    Friend WithEvents Coller As ToolStripMenuItem
    Friend WithEvents Imprimer As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents dateArrivee As DateTimePicker
End Class
