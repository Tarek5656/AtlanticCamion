Public Class Principal
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ficheform As New FicheCamion()

        ficheform.consommationGasoilForm = New ConsommationGasoil()
        ficheform.parcoursForm = New Parcours()
        ficheform.reparationsForm = New Réparations()

        chargerFormulaire(ficheform, panelFicheCamion)
        chargerFormulaire(ficheform.consommationGasoilForm, panelConsommationGasoil)
        chargerFormulaire(ficheform.parcoursForm, panelParcours)
        chargerFormulaire(ficheform.reparationsForm, panelReparations)
    End Sub

    Private Sub chargerFormulaire(form As Form, panel As Panel)
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        panel.Controls.Clear()
        panel.Controls.Add(form)
        form.Show()
    End Sub

    Dim consommationGasoilTaille As Boolean = False
    Private Sub bttConsommationGasoil_Click(sender As Object, e As EventArgs) Handles bttConsommationGasoil.Click
        If Not consommationGasoilTaille Then
            TableLayoutPanel2.ColumnStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel2.ColumnStyles(0).Width = 100
            TableLayoutPanel2.ColumnStyles(1).Width = 0
            TableLayoutPanel2.ColumnStyles(2).Width = 0
            consommationGasoilTaille = True
            bttConsommationGasoil.Image = My.Resources.reduire

        Else
            TableLayoutPanel2.ColumnStyles(0).Width = 33.33
            TableLayoutPanel2.ColumnStyles(1).Width = 33.33
            TableLayoutPanel2.ColumnStyles(2).Width = 33.33
            consommationGasoilTaille = False
            bttConsommationGasoil.Image = My.Resources.agrandir
        End If
    End Sub

    Dim parcoursTaille As Boolean = False
    Private Sub bttParcours_Click(sender As Object, e As EventArgs) Handles bttParcours.Click
        If Not parcoursTaille Then
            TableLayoutPanel2.ColumnStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel2.ColumnStyles(0).Width = 0
            TableLayoutPanel2.ColumnStyles(1).Width = 100
            TableLayoutPanel2.ColumnStyles(2).Width = 0
            parcoursTaille = True
            bttParcours.Image = My.Resources.reduire
        Else
            TableLayoutPanel2.ColumnStyles(0).Width = 33.33
            TableLayoutPanel2.ColumnStyles(1).Width = 33.33
            TableLayoutPanel2.ColumnStyles(2).Width = 33.33
            parcoursTaille = False
            bttParcours.Image = My.Resources.agrandir
        End If
    End Sub

    Dim reparationsTaille As Boolean = False
    Private Sub bttReparations_Click(sender As Object, e As EventArgs) Handles bttReparations.Click
        If Not reparationsTaille Then
            TableLayoutPanel2.ColumnStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel2.ColumnStyles(0).Width = 0
            TableLayoutPanel2.ColumnStyles(1).Width = 0
            TableLayoutPanel2.ColumnStyles(2).Width = 100
            reparationsTaille = True
            bttReparations.Image = My.Resources.reduire
        Else
            TableLayoutPanel2.ColumnStyles(0).Width = 33.33
            TableLayoutPanel2.ColumnStyles(1).Width = 33.33
            TableLayoutPanel2.ColumnStyles(2).Width = 33.33
            reparationsTaille = False
            bttReparations.Image = My.Resources.agrandir
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Principal_Load(Nothing, Nothing)
    End Sub
End Class