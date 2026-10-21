<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        TableLayoutPanel1 = New TableLayoutPanel()
        GroupBox1 = New GroupBox()
        panelFicheCamion = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        GroupBox2 = New GroupBox()
        bttConsommationGasoil = New Button()
        panelConsommationGasoil = New Panel()
        GroupBox3 = New GroupBox()
        panelParcours = New Panel()
        bttParcours = New Button()
        GroupBox4 = New GroupBox()
        bttReparations = New Button()
        panelReparations = New Panel()
        Button1 = New Button()
        TableLayoutPanel1.SuspendLayout()
        GroupBox1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoScroll = True
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Controls.Add(GroupBox1, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1225, 651)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(panelFicheCamion)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1219, 319)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Fiche Camion"
        ' 
        ' panelFicheCamion
        ' 
        panelFicheCamion.AutoScroll = True
        panelFicheCamion.Dock = DockStyle.Fill
        panelFicheCamion.Font = New Font("Segoe UI", 9F)
        panelFicheCamion.Location = New Point(3, 35)
        panelFicheCamion.Name = "panelFicheCamion"
        panelFicheCamion.Size = New Size(1213, 281)
        panelFicheCamion.TabIndex = 0
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoScroll = True
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Controls.Add(GroupBox2, 0, 0)
        TableLayoutPanel2.Controls.Add(GroupBox3, 1, 0)
        TableLayoutPanel2.Controls.Add(GroupBox4, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 328)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(1219, 320)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(bttConsommationGasoil)
        GroupBox2.Controls.Add(panelConsommationGasoil)
        GroupBox2.Dock = DockStyle.Fill
        GroupBox2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        GroupBox2.Location = New Point(3, 3)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(400, 314)
        GroupBox2.TabIndex = 0
        GroupBox2.TabStop = False
        GroupBox2.Text = "Consommation Gasoil"
        ' 
        ' bttConsommationGasoil
        ' 
        bttConsommationGasoil.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        bttConsommationGasoil.BackColor = SystemColors.Control
        bttConsommationGasoil.Image = My.Resources.Resources.agrandir
        bttConsommationGasoil.Location = New Point(351, 0)
        bttConsommationGasoil.Name = "bttConsommationGasoil"
        bttConsommationGasoil.Size = New Size(46, 37)
        bttConsommationGasoil.TabIndex = 2
        bttConsommationGasoil.UseVisualStyleBackColor = False
        ' 
        ' panelConsommationGasoil
        ' 
        panelConsommationGasoil.AutoScroll = True
        panelConsommationGasoil.Dock = DockStyle.Fill
        panelConsommationGasoil.Font = New Font("Segoe UI", 9F)
        panelConsommationGasoil.Location = New Point(3, 35)
        panelConsommationGasoil.Name = "panelConsommationGasoil"
        panelConsommationGasoil.Size = New Size(394, 276)
        panelConsommationGasoil.TabIndex = 0
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(panelParcours)
        GroupBox3.Controls.Add(bttParcours)
        GroupBox3.Dock = DockStyle.Fill
        GroupBox3.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        GroupBox3.Location = New Point(409, 3)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(400, 314)
        GroupBox3.TabIndex = 1
        GroupBox3.TabStop = False
        GroupBox3.Text = "Parcours"
        ' 
        ' panelParcours
        ' 
        panelParcours.AutoScroll = True
        panelParcours.Dock = DockStyle.Fill
        panelParcours.Font = New Font("Segoe UI", 9F)
        panelParcours.Location = New Point(3, 35)
        panelParcours.Name = "panelParcours"
        panelParcours.Size = New Size(394, 276)
        panelParcours.TabIndex = 0
        ' 
        ' bttParcours
        ' 
        bttParcours.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        bttParcours.Image = My.Resources.Resources.agrandir
        bttParcours.Location = New Point(351, 0)
        bttParcours.Name = "bttParcours"
        bttParcours.Size = New Size(46, 37)
        bttParcours.TabIndex = 1
        bttParcours.UseVisualStyleBackColor = True
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(bttReparations)
        GroupBox4.Controls.Add(panelReparations)
        GroupBox4.Dock = DockStyle.Fill
        GroupBox4.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        GroupBox4.Location = New Point(815, 3)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(401, 314)
        GroupBox4.TabIndex = 2
        GroupBox4.TabStop = False
        GroupBox4.Text = "Réparations"
        ' 
        ' bttReparations
        ' 
        bttReparations.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        bttReparations.Image = My.Resources.Resources.agrandir
        bttReparations.Location = New Point(352, 0)
        bttReparations.Name = "bttReparations"
        bttReparations.Size = New Size(46, 37)
        bttReparations.TabIndex = 0
        bttReparations.UseVisualStyleBackColor = True
        ' 
        ' panelReparations
        ' 
        panelReparations.AutoScroll = True
        panelReparations.Dock = DockStyle.Fill
        panelReparations.Font = New Font("Segoe UI", 9F)
        panelReparations.Location = New Point(3, 35)
        panelReparations.Name = "panelReparations"
        panelReparations.Size = New Size(395, 276)
        panelReparations.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Image = My.Resources.Resources.actualiser
        Button1.Location = New Point(174, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(29, 32)
        Button1.TabIndex = 0
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Principal
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1225, 651)
        Controls.Add(TableLayoutPanel1)
        Name = "Principal"
        Text = "Principal"
        TableLayoutPanel1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents panelFicheCamion As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents panelConsommationGasoil As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents panelParcours As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents panelReparations As Panel
    Friend WithEvents bttConsommationGasoil As Button
    Friend WithEvents bttParcours As Button
    Friend WithEvents bttReparations As Button
    Friend WithEvents Button1 As Button
End Class
