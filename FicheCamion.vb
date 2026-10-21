Imports System.Drawing.Printing
Imports System.Reflection
Imports System.Data.SQLite

Public Class FicheCamion

    Public Property consommationGasoilForm As ConsommationGasoil
    Public Property parcoursForm As Parcours
    Public Property reparationsForm As Réparations

    Dim bsFiche As New BindingSource()

    Private Sub chargerFiche()
        Try
            Connect()

            Dim statut As New SQLiteCommand("UPDATE ficheCamion SET Statut = 'Disponible' WHERE Statut <> 'Disponible' AND NOT EXISTS(
                                            SELECT 1 FROM parcours p WHERE p.[Code Camion] = ficheCamion.Code AND p.[Date Arrivée] > DATE('now','+1 day') )
                                            AND NOT EXISTS(
                                            SELECT 1 FROM réparations r WHERE r.[Code Camion] = ficheCamion.Code AND r.[Date Fin] > DATE('now','+1 day') )", con)
            statut.ExecuteNonQuery()

            Dim cmd As New SQLiteCommand("SELECT * FROM ficheCamion", con)
            Dim da As New SQLiteDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            bsFiche.DataSource = dt
            DataGridView1.DataSource = bsFiche

            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.ValueType Is GetType(Integer) OrElse
                    col.ValueType Is GetType(Double) OrElse
                    col.ValueType Is GetType(Decimal) Then

                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Erreur de connexion: " & ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint

        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        If row.IsNewRow Then
            Exit Sub
        End If

        Dim dateCarnet, dateVisiteTechnique, dateCarteGrise, dateAssurance As Date
        Dim hasCarnet = Date.TryParse(row.Cells("Date Carnet de circulation").Value.ToString(), dateCarnet)
        Dim hasVisiteTechnique = Date.TryParse(row.Cells("Date Visite technique").Value.ToString(), dateVisiteTechnique)
        Dim hasCarteGrise = Date.TryParse(row.Cells("Date Carte Grise").Value.ToString(), dateCarteGrise)
        Dim hasAssurance = Date.TryParse(row.Cells("Date Assurance").Value.ToString(), dateAssurance)

        Dim orange As Boolean = False
        Dim rouge As Boolean = False

        If (hasCarnet AndAlso dateCarnet <= Date.Today) OrElse
                (hasVisiteTechnique AndAlso dateVisiteTechnique <= Date.Today) OrElse
                (hasCarteGrise AndAlso dateCarteGrise <= Date.Today) OrElse
                (hasAssurance AndAlso dateAssurance <= Date.Today) Then
            rouge = True
        End If
        If Not rouge AndAlso (
            (hasCarnet AndAlso dateCarnet <= Date.Today.AddDays(15)) OrElse
            (hasVisiteTechnique AndAlso dateVisiteTechnique <= Date.Today.AddDays(15)) OrElse
            (hasCarteGrise AndAlso dateCarteGrise <= Date.Today.AddDays(15)) OrElse
            (hasAssurance AndAlso dateAssurance <= Date.Today.AddDays(15))) Then
            orange = True
        End If

        If rouge Then
            row.DefaultCellStyle.BackColor = Color.Red
            row.DefaultCellStyle.ForeColor = Color.White
        ElseIf orange Then
            row.DefaultCellStyle.BackColor = Color.Orange
            row.DefaultCellStyle.ForeColor = Color.White
        Else
            row.DefaultCellStyle.BackColor = SystemColors.Window
            row.DefaultCellStyle.ForeColor = SystemColors.WindowText
        End If
    End Sub

    Private Sub FicheCamion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TableLayoutPanel1.RowStyles(0).SizeType = SizeType.Percent
        TableLayoutPanel1.RowStyles(0).Height = 8
        TableLayoutPanel1.RowStyles(1).Height = 92
        clearFiltre()
        chargerFiche()

        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
        End If
        chargerInfos()

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        chargerInfos()
    End Sub

    Private Sub chargerInfos()

        If DataGridView1.CurrentCell IsNot Nothing Then
            Dim index As Integer = DataGridView1.CurrentCell.RowIndex
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(index)
            Dim code As Integer = Convert.ToInt32(selectedRow.Cells("Code").Value)
            consommationGasoilForm.code = code
            parcoursForm.code = code
            reparationsForm.code = code
            chargerTable(consommationGasoilForm.DataGridView1, "consommationGasoil", consommationGasoilForm.code, consommationGasoilForm.bsConsommationGasoil)
            chargerTable(parcoursForm.DataGridView1, "parcours", parcoursForm.code, parcoursForm.bsParcours)
            chargerTable(reparationsForm.DataGridView1, "réparations", reparationsForm.code, reparationsForm.bsRéparations)
        End If
    End Sub

    Private Sub Ajouter_Click(sender As Object, e As EventArgs) Handles Ajouter.Click
        Dim addForm As New ficheCamionAjout()
        addForm.ShowDialog()
        If addForm.DialogResult = DialogResult.OK Then
            chargerFiche()
            Dim index As Integer = Integer.Max(0, DataGridView1.Rows.Count - 1)
            DataGridView1.CurrentCell = DataGridView1.Rows(index).Cells(0)
            chargerInfos()
        End If
    End Sub

    Private Sub Modifier_Click(sender As Object, e As EventArgs) Handles Modifier.Click
        If DataGridView1.CurrentCell Is Nothing Then
            MessageBox.Show("Veuillez séléctionner un camion")
            Return
        End If
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(index)
        Dim code As Integer = Convert.ToInt32(selectedRow.Cells("Code").Value)
        Dim editForm As New ficheCamionAjout()
        editForm.edit = True
        editForm.code = code
        editForm.ShowDialog()
        If editForm.DialogResult = DialogResult.OK Then
            chargerFiche()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow AndAlso Convert.ToInt32(row.Cells("Code").Value) = code Then
                    DataGridView1.CurrentCell = row.Cells(0)
                    Exit For
                End If
            Next
            chargerInfos()
        End If
    End Sub

    Private Sub Supprimer_Click(sender As Object, e As EventArgs) Handles Supprimer.Click

        If DataGridView1.SelectedRows.Count > 1 Then
            Dim result As DialogResult = MessageBox.Show("Voulez-vous supprimer ces lignes?", "Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then

                Try
                    Connect()

                    For Each row As DataGridViewRow In DataGridView1.SelectedRows
                        Dim code As Integer = Convert.ToInt32(row.Cells("Code").Value)

                        Dim sql As New SQLiteCommand("SELECT COUNT(*) FROM (
                                            SELECT 1 FROM consommationGasoil WHERE [Code Camion] = @code
                                            UNION
                                            SELECT 1 FROM parcours WHERE [Code Camion] = @code
                                            UNION
                                            SELECT 1 FROM réparations WHERE [Code Camion] = @code) AS t ", con)
                        sql.Parameters.AddWithValue("@code", code)
                        Dim count As Integer = Convert.ToInt32(sql.ExecuteScalar())
                        If count = 0 Then
                            delete("fichecamion", "Code", code, 0)
                        Else
                            MessageBox.Show("Supprimer les infos des autres tableaux avant de supprimer le camion " & code)
                        End If
                    Next

                Catch ex As Exception
                    MessageBox.Show("Erreur de connexion: " & ex.Message)
                Finally
                    Disconnect()
                End Try
                chargerFiche()
            End If

        ElseIf DataGridView1.CurrentCell IsNot Nothing Then
            Dim index As Integer = DataGridView1.CurrentCell.RowIndex
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(index)
            Dim code As Integer = Convert.ToInt32(selectedRow.Cells("Code").Value)
            Dim prevIndex As Integer
            If index > 0 Then
                prevIndex = index - 1
            Else
                prevIndex = index + 1
            End If

            Dim result As DialogResult = MessageBox.Show("Voulez-vous supprimer cette ligne?", "Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Try
                    Connect()

                    Dim sql As New SQLiteCommand("SELECT COUNT(*) FROM (
                                            SELECT 1 FROM consommationGasoil WHERE [Code Camion] = @code
                                            UNION
                                            SELECT 1 FROM parcours WHERE [Code Camion] = @code
                                            UNION
                                            SELECT 1 FROM réparations WHERE [Code Camion] = @code) AS t ", con)
                    sql.Parameters.AddWithValue("@code", code)
                    Dim count As Integer = Convert.ToInt32(sql.ExecuteScalar())
                    If count = 0 Then
                        delete("fichecamion", "Code", code, 0)
                    Else
                        MessageBox.Show("Supprimer les infos des autres tableaux avant de supprimer ce camion")
                    End If
                    chargerFiche()
                    If DataGridView1.RowCount <> 0 Then
                        DataGridView1.CurrentCell = DataGridView1.Rows(prevIndex).Cells(0)
                    End If
                    chargerInfos()

                Catch ex As Exception
                    MessageBox.Show("Erreur de connexion: " & ex.Message)
                Finally
                    Disconnect()
                End Try
            End If
        End If
    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit1 As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)
            If hit1.RowIndex >= 0 AndAlso hit1.ColumnIndex >= 0 Then
                DataGridView1.CurrentCell = DataGridView1.Rows(hit1.RowIndex).Cells(hit1.ColumnIndex)
            End If
        End If

        Dim hit = DataGridView1.HitTest(e.X, e.Y)
        If hit.Type = DataGridViewHitTestType.None Then
            DataGridView1.ClearSelection()
            DataGridView1.CurrentCell = Nothing
        End If
    End Sub

    Private Sub Copier_Click(sender As Object, e As EventArgs) Handles Copier.Click
        copierTexte(DataGridView1)
    End Sub

    Private Sub Coller_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Coller.Enabled = collerGriser(DataGridView1)
    End Sub

    Private Sub Coller_Click(sender As Object, e As EventArgs) Handles Coller.Click
        Dim donnees As List(Of String()) = collerTexte(DataGridView1)

        Try
            Connect()

            For i As Integer = 1 To donnees.Count - 1
                Dim colonne = donnees(i)


                Dim matricule = colonne(1)
                Dim Type = colonne(2)
                Dim tonnage = Convert.ToDecimal(colonne(3))
                Dim statut = colonne(4)
                Dim dateCarnet = Convert.ToDateTime(colonne(5))
                Dim dateVisiteTechnique = Convert.ToDateTime(colonne(6))
                Dim carteGrise = colonne(7)
                Dim dateCarteGrise = Convert.ToDateTime(colonne(8))
                Dim assurance = colonne(9)
                Dim dateAssurance = Convert.ToDateTime(colonne(10))
                Dim chauffeur = colonne(11)
                Dim telephone = colonne(12)

                Dim verf = New SQLiteCommand("SELECT COUNT(*) FROM ficheCamion WHERE Matricule = @mat OR Chauffeur = @chauf OR Téléphone = @tel OR [Carte Grise] = @grise", con)
                verf.Parameters.AddWithValue("@mat", matricule)
                verf.Parameters.AddWithValue("@chauf", chauffeur)
                verf.Parameters.AddWithValue("@tel", telephone)
                verf.Parameters.AddWithValue("@grise", carteGrise)
                Dim count = Convert.ToInt32(verf.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show($"Ligne {i} : Conflit détecté (matricule, chauffeur, téléphone ou carte grise déjà existant)", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim cmd = New SQLiteCommand("INSERT INTO ficheCamion (Matricule, Type, Tonnage, Statut, [Date Carnet de circulation], " &
                                           "[Date Visite technique], [Carte Grise], [Date Carte Grise], Assurance, [Date Assurance], Chauffeur, Téléphone) 
                                       VALUES (@matricule, @type, @tonnage, @statut, @dateCarnet, @dateVisite, @carteGrise, @dateCarteGrise, @assurance, @dateAssurance, @chauffeur, @téléphone)", con)

                cmd.Parameters.AddWithValue("@matricule", matricule)
                cmd.Parameters.AddWithValue("@type", Type)
                cmd.Parameters.AddWithValue("@tonnage", tonnage)
                cmd.Parameters.AddWithValue("@statut", statut)
                cmd.Parameters.AddWithValue("@dateCarnet", dateCarnet)
                cmd.Parameters.AddWithValue("@dateVisite", dateVisiteTechnique)
                cmd.Parameters.AddWithValue("@carteGrise", carteGrise)
                cmd.Parameters.AddWithValue("@dateCarteGrise", dateCarteGrise)
                cmd.Parameters.AddWithValue("@assurance", assurance)
                cmd.Parameters.AddWithValue("@dateAssurance", dateAssurance)
                cmd.Parameters.AddWithValue("@chauffeur", chauffeur)
                cmd.Parameters.AddWithValue("@téléphone", telephone)
                cmd.ExecuteNonQuery()
            Next
            MessageBox.Show("Ligne(s) collée(s) avec succès")
            DialogResult = DialogResult.OK
            chargerFiche()
            Dim index As Integer = Integer.Max(0, DataGridView1.Rows.Count - 1)
            DataGridView1.CurrentCell = DataGridView1.Rows(index).Cells(0)
            chargerInfos()
        Catch ex As Exception
            MessageBox.Show("Erreur de sauvegarde: " & ex.Message, "Erreur",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Dim afficher As Boolean = True

    Private Sub txtCode_GotFocus(sender As Object, e As EventArgs) Handles txtCode.GotFocus
        gottFocus(txtCode)
    End Sub
    Private Sub txtCode_LostFocus(sender As Object, e As EventArgs) Handles txtCode.LostFocus
        losttFocus(txtCode)
    End Sub
    Private Sub txtMatricule_GotFocus(sender As Object, e As EventArgs) Handles txtMatricule.GotFocus
        gottFocus(txtMatricule)
    End Sub
    Private Sub txtMatricule_LostFocus(sender As Object, e As EventArgs) Handles txtMatricule.LostFocus
        losttFocus(txtMatricule)
    End Sub
    Private Sub txtType_GotFocus(sender As Object, e As EventArgs) Handles txtType.GotFocus
        gottFocus(txtType)
    End Sub
    Private Sub txtType_LostFocus(sender As Object, e As EventArgs) Handles txtType.LostFocus
        losttFocus(txtType)
    End Sub
    Private Sub txtTonnage_GotFocus(sender As Object, e As EventArgs) Handles txtTonnage.GotFocus
        gottFocus(txtTonnage)
    End Sub
    Private Sub txtTonnage_LostFocus(sender As Object, e As EventArgs) Handles txtTonnage.LostFocus
        losttFocus(txtTonnage)
    End Sub
    Private Sub txtStatut_GotFocus(sender As Object, e As EventArgs) Handles txtStatut.GotFocus
        gottFocus(txtStatut)
    End Sub
    Private Sub txtStatut_LostFocus(sender As Object, e As EventArgs) Handles txtStatut.LostFocus
        losttFocus(txtStatut)
    End Sub
    Private Sub txtCarteGrise_GotFocus(sender As Object, e As EventArgs) Handles txtCarteGrise.GotFocus
        gottFocus(txtCarteGrise)
    End Sub
    Private Sub txtCarteGrise_LostFocus(sender As Object, e As EventArgs) Handles txtCarteGrise.LostFocus
        losttFocus(txtCarteGrise)
    End Sub
    Private Sub txtAssurance_GotFocus(sender As Object, e As EventArgs) Handles txtAssurance.GotFocus
        gottFocus(txtAssurance)
    End Sub
    Private Sub txtAssurance_LostFocus(sender As Object, e As EventArgs) Handles txtAssurance.LostFocus
        losttFocus(txtAssurance)
    End Sub
    Private Sub txtChauffeur_GotFocus(sender As Object, e As EventArgs) Handles txtChauffeur.GotFocus
        gottFocus(txtChauffeur)
    End Sub
    Private Sub txtChauffeur_LostFocus(sender As Object, e As EventArgs) Handles txtChauffeur.LostFocus
        losttFocus(txtChauffeur)
    End Sub
    Private Sub txtTel_GotFocus(sender As Object, e As EventArgs) Handles txtTel.GotFocus
        gottFocus(txtTel)
    End Sub
    Private Sub txtTel_LostFocus(sender As Object, e As EventArgs) Handles txtTel.LostFocus
        losttFocus(txtTel)
    End Sub

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, txtMatricule.KeyDown, txtType.KeyDown, txtTonnage.KeyDown, txtStatut.KeyDown,
        dateCarnetcirc.KeyDown, dateVisitetech.KeyDown, txtCarteGrise.KeyDown, dateCarteGrise.KeyDown, txtAssurance.KeyDown, dateAssurance.KeyDown, txtChauffeur.KeyDown, txtTel.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TypeOf sender Is Button Then
                e.SuppressKeyPress = True
                SelectNextControl(ActiveControl, True, True, True, False)
            End If
        ElseIf e.KeyCode = Keys.Up Then
            If Not TypeOf sender Is DateTimePicker Then
                e.SuppressKeyPress = True
                SelectNextControl(ActiveControl, False, True, True, False)
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If Not TypeOf sender Is DateTimePicker Then
                e.SuppressKeyPress = True
                SelectNextControl(ActiveControl, True, True, True, False)
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not afficher Then
            TableLayoutPanel1.RowStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel1.RowStyles(0).Height = 8
            TableLayoutPanel1.RowStyles(1).Height = 92
            afficher = True
        ElseIf afficher Then
            TableLayoutPanel1.RowStyles(0).Height = 50
            TableLayoutPanel1.RowStyles(1).Height = 50
            afficher = False
        End If
    End Sub

    Private Sub appliquerFiltre()
        If bsFiche.DataSource Is Nothing Then Exit Sub
        Dim filtres As New List(Of String)

        If txtCode.Text.Trim() <> "" Then
            Dim code As Integer
            If Integer.TryParse(txtCode.Text.Trim(), code) Then
                filtres.Add($"Code = {code}")
            End If
        End If
        If txtMatricule.Text.Trim() <> "" Then
            filtres.Add($"Matricule LIKE '%{txtMatricule.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtType.Text.Trim() <> "" Then
            filtres.Add($"Type LIKE '%{txtType.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtTonnage.Text.Trim() <> "" Then
            Dim tonnage As Decimal
            If Decimal.TryParse(txtTonnage.Text.Trim(), tonnage) Then
                filtres.Add($"Tonnage = {tonnage}")
            End If
        End If
        If txtStatut.Text.Trim() <> "" Then
            filtres.Add($"Statut LIKE '%{txtStatut.Text.Trim().Replace("'", "''")}%'")
        End If
        If dateCarnetcirc.Checked Then
            filtres.Add($"[Date Carnet de circulation] = '{dateCarnetcirc.Value.ToString("dd-MM-yyyy")}'")
        End If
        If dateVisitetech.Checked Then
            filtres.Add($"[Date Visite technique] = '{dateVisitetech.Value.ToString("dd-MM-yyyy")}'")
        End If
        If txtCarteGrise.Text.Trim() <> "" Then
            filtres.Add($"[Carte Grise] LIKE '%{txtCarteGrise.Text.Trim().Replace("'", "''")}%'")
        End If
        If dateCarteGrise.Checked Then
            filtres.Add($"[Date Carte Grise] = '{dateCarteGrise.Value.ToString("dd-MM-yyyy")}'")
        End If
        If txtAssurance.Text.Trim() <> "" Then
            filtres.Add($"Assurance LIKE '%{txtAssurance.Text.Trim().Replace("'", "''")}%'")
        End If
        If dateAssurance.Checked Then
            filtres.Add($"[Date Assurance] = '{dateAssurance.Value.ToString("dd-MM-yyyy")}'")
        End If
        If txtChauffeur.Text.Trim() <> "" Then
            filtres.Add($"Chauffeur LIKE '%{txtChauffeur.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtTel.Text.Trim() <> "" Then
            filtres.Add($"Téléphone LIKE '%{txtTel.Text.Trim().Replace("'", "''")}%'")
        End If

        bsFiche.Filter = String.Join(" AND ", filtres)
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtMatricule_TextChanged(sender As Object, e As EventArgs) Handles txtMatricule.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtType_TextChanged(sender As Object, e As EventArgs) Handles txtType.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtTonnage_TextChanged(sender As Object, e As EventArgs) Handles txtTonnage.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtStatut_TextChanged(sender As Object, e As EventArgs) Handles txtStatut.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub dateCarnetcirc_ValueChanged(sender As Object, e As EventArgs) Handles dateCarnetcirc.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub dateVisitetech_ValueChanged(sender As Object, e As EventArgs) Handles dateVisitetech.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub txtCarteGrise_TextChanged(sender As Object, e As EventArgs) Handles txtCarteGrise.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub dateCarteGrise_ValueChanged(sender As Object, e As EventArgs) Handles dateCarteGrise.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub txtAssurance_TextChanged(sender As Object, e As EventArgs) Handles txtAssurance.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub dateAssurance_ValueChanged(sender As Object, e As EventArgs) Handles dateAssurance.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub txtChauffeur_TextChanged(sender As Object, e As EventArgs) Handles txtChauffeur.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtTel_TextChanged(sender As Object, e As EventArgs) Handles txtTel.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub clearFiltre()
        txtCode.Clear()
        txtMatricule.Clear()
        txtType.Clear()
        txtTonnage.Clear()
        txtStatut.Clear()
        dateCarnetcirc.Checked = False
        dateVisitetech.Checked = False
        txtCarteGrise.Clear()
        dateCarteGrise.Checked = False
        txtAssurance.Clear()
        dateAssurance.Checked = False
        txtChauffeur.Clear()
        txtTel.Clear()
        bsFiche.RemoveFilter()
    End Sub

    Private Sub réinitialiser_Click(sender As Object, e As EventArgs) Handles Réinitialiser.Click
        clearFiltre()
    End Sub

    ' Déclare les variables nécessaires
    Private lignesAAfficher As New List(Of DataGridViewRow)
    Private WithEvents doc As New PrintDocument
    Private apercu As New PrintPreviewDialog
    Private positionY As Integer = 100

    Private Sub doc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles doc.PrintPage
        printPage(e, lignesAAfficher, DataGridView1)
    End Sub


    Private Sub Imprimer_Click(sender As Object, e As EventArgs) Handles Imprimer.Click
        ImprimerLignesSelectionnees(lignesAAfficher, doc, apercu, DataGridView1)
    End Sub
End Class
