<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsommationGasoil
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
        Button2 = New Button()
        Button1 = New Button()
        Label7 = New Label()
        txtTaux = New TextBox()
        Label5 = New Label()
        txtKmParcourus = New TextBox()
        txtCode = New TextBox()
        Label6 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtKmFin = New TextBox()
        txtQtGasoil = New TextBox()
        dateRemplissage = New DateTimePicker()
        txtKmDebut = New TextBox()
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
        DataGridView1.Location = New Point(4, 274)
        DataGridView1.Margin = New Padding(4, 5, 4, 5)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1916, 269)
        DataGridView1.TabIndex = 1
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
        TableLayoutPanel1.AutoScroll = True
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(DataGridView1, 0, 1)
        TableLayoutPanel1.Controls.Add(GroupBox1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 49.0875931F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.9124069F))
        TableLayoutPanel1.Size = New Size(1924, 548)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(txtTaux)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(txtKmParcourus)
        GroupBox1.Controls.Add(txtCode)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtKmFin)
        GroupBox1.Controls.Add(txtQtGasoil)
        GroupBox1.Controls.Add(dateRemplissage)
        GroupBox1.Controls.Add(txtKmDebut)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1918, 263)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Recherche"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(95, 0)
        Button2.Name = "Button2"
        Button2.Size = New Size(27, 22)
        Button2.TabIndex = 30
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1399, 90)
        Button1.Name = "Button1"
        Button1.Size = New Size(175, 31)
        Button1.TabIndex = 7
        Button1.Text = "Réinitialiser"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(1074, 37)
        Label7.Name = "Label7"
        Label7.Size = New Size(183, 25)
        Label7.TabIndex = 28
        Label7.Text = "Taux Consommation :"
        ' 
        ' txtTaux
        ' 
        txtTaux.Location = New Point(1274, 34)
        txtTaux.MaxLength = 10
        txtTaux.Name = "txtTaux"
        txtTaux.Size = New Size(300, 31)
        txtTaux.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(585, 88)
        Label5.Name = "Label5"
        Label5.Size = New Size(129, 25)
        Label5.TabIndex = 26
        Label5.Text = "Km Parcourus :"
        ' 
        ' txtKmParcourus
        ' 
        txtKmParcourus.Location = New Point(739, 85)
        txtKmParcourus.MaxLength = 10
        txtKmParcourus.Name = "txtKmParcourus"
        txtKmParcourus.Size = New Size(300, 31)
        txtKmParcourus.TabIndex = 4
        ' 
        ' txtCode
        ' 
        txtCode.Location = New Point(242, 34)
        txtCode.MaxLength = 20
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(300, 31)
        txtCode.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(21, 37)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 25)
        Label6.TabIndex = 24
        Label6.Text = "Code Camion :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(591, 137)
        Label4.Name = "Label4"
        Label4.Size = New Size(142, 25)
        Label4.TabIndex = 23
        Label4.Text = "Quantite Gasoil :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(595, 37)
        Label3.Name = "Label3"
        Label3.Size = New Size(75, 25)
        Label3.TabIndex = 22
        Label3.Text = "Km Fin :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(21, 142)
        Label2.Name = "Label2"
        Label2.Size = New Size(101, 25)
        Label2.TabIndex = 21
        Label2.Text = "Km Debut :"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(21, 91)
        Label1.Name = "Label1"
        Label1.Size = New Size(215, 25)
        Label1.TabIndex = 20
        Label1.Text = "Date Remplissage Gasoil :"
        ' 
        ' txtKmFin
        ' 
        txtKmFin.Location = New Point(739, 36)
        txtKmFin.MaxLength = 10
        txtKmFin.Name = "txtKmFin"
        txtKmFin.Size = New Size(300, 31)
        txtKmFin.TabIndex = 3
        ' 
        ' txtQtGasoil
        ' 
        txtQtGasoil.Location = New Point(739, 136)
        txtQtGasoil.MaxLength = 10
        txtQtGasoil.Name = "txtQtGasoil"
        txtQtGasoil.Size = New Size(300, 31)
        txtQtGasoil.TabIndex = 5
        ' 
        ' dateRemplissage
        ' 
        dateRemplissage.Location = New Point(242, 88)
        dateRemplissage.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dateRemplissage.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
        dateRemplissage.Name = "dateRemplissage"
        dateRemplissage.Size = New Size(300, 31)
        dateRemplissage.TabIndex = 1
        dateRemplissage.Value = New Date(2025, 7, 24, 0, 0, 0, 0)
        ' 
        ' txtKmDebut
        ' 
        txtKmDebut.Location = New Point(242, 139)
        txtKmDebut.MaxLength = 10
        txtKmDebut.Name = "txtKmDebut"
        txtKmDebut.Size = New Size(300, 31)
        txtKmDebut.TabIndex = 2
        ' 
        ' ConsommationGasoil
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1924, 548)
        Controls.Add(TableLayoutPanel1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "ConsommationGasoil"
        Text = "Consommation Gasoil"
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
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTaux As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtKmParcourus As TextBox
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtKmFin As TextBox
    Friend WithEvents txtQtGasoil As TextBox
    Friend WithEvents dateRemplissage As DateTimePicker
    Friend WithEvents txtKmDebut As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Coller As ToolStripMenuItem
    Friend WithEvents Imprimer As ToolStripMenuItem
End Class
