Imports System.Data.SQLite
Imports System.Drawing.Printing

Public Class ConsommationGasoil

    Public Property code As Integer

    Public Property bsConsommationGasoil As New BindingSource()

    Private Sub ConsommationGasoil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TableLayoutPanel1.RowStyles(0).SizeType = SizeType.Percent
        TableLayoutPanel1.RowStyles(0).Height = 8
        TableLayoutPanel1.RowStyles(1).Height = 92
        clearFiltre()
        chargerTable(DataGridView1, "consommationGasoil", code, bsConsommationGasoil)
    End Sub

    Private Sub Ajouter_Click(sender As Object, e As EventArgs) Handles Ajouter.Click
        Dim addForm As New ConsommationGasoilAjout()
        addForm.code = code
        addForm.ShowDialog()
        If addForm.DialogResult = DialogResult.OK Then
            chargerTable(DataGridView1, "consommationGasoil", code, bsConsommationGasoil)
            Dim index As Integer = Integer.Max(0, DataGridView1.Rows.Count - 1)
            DataGridView1.CurrentCell = DataGridView1.Rows(index).Cells(1)
        End If
    End Sub

    Private Sub Modifier_Click(sender As Object, e As EventArgs) Handles Modifier.Click
        If DataGridView1.CurrentCell Is Nothing Then
            MessageBox.Show("Veuillez séléctionner une ligne")
            Return
        End If
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(index)
        Dim id As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)
        Dim editForm As New ConsommationGasoilAjout()
        editForm.edit = True
        editForm.id = id
        editForm.ShowDialog()
        If editForm.DialogResult = DialogResult.OK Then
            chargerTable(DataGridView1, "consommationGasoil", code, bsConsommationGasoil)
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow AndAlso Convert.ToInt32(row.Cells("id").Value) = id Then
                    DataGridView1.CurrentCell = row.Cells(1)
                    Exit For
                End If
            Next
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

                        Dim id As Integer = Convert.ToInt32(row.Cells("id").Value)
                        delete("consommationGasoil", "id", id, 1)

                    Next
                    MessageBox.Show("Lignes supprimées avec succès", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Erreur de connexion: " & ex.Message)
                Finally
                    Disconnect()
                End Try
                chargerTable(DataGridView1, "consommationGasoil", code, bsConsommationGasoil)
            End If

        ElseIf DataGridView1.CurrentCell IsNot Nothing Then
            Dim index As Integer = DataGridView1.CurrentCell.RowIndex
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(index)
            Dim id As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)
            Dim prevIndex As Integer
            If index > 0 Then
                prevIndex = index - 1
            Else
                prevIndex = index + 1
            End If

            Dim result As DialogResult = MessageBox.Show("Voulez-vous supprimer cette ligne?", "Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                delete("consommationGasoil", "id", id, 0)
                chargerTable(DataGridView1, "consommationGasoil", code, bsConsommationGasoil)
                If DataGridView1.RowCount <> 0 Then
                    DataGridView1.CurrentCell = DataGridView1.Rows(prevIndex).Cells(1)
                End If
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


                Dim codeCamion = Convert.ToInt32(colonne(0))
                Dim dateRG = Convert.ToDateTime(colonne(1))
                Dim kmDebut = Convert.ToDecimal(colonne(2))
                Dim kmFin = Convert.ToDecimal(colonne(3))
                Dim kmParcouru = Convert.ToDecimal(colonne(4))
                Dim qtGasoil = Convert.ToDecimal(colonne(5))
                Dim taux = Convert.ToDecimal(colonne(6))

                Dim verf = New SQLiteCommand("SELECT MAX([Km Fin]) FROM consommationGasoil WHERE [Code Camion] = @code", con)
                verf.Parameters.AddWithValue("@code", codeCamion)
                Dim resultat = Convert.ToDecimal(verf.ExecuteScalar())
                If kmDebut < resultat Then
                    MessageBox.Show($"Ligne {i} : Km Debut doit être supérieur au Km Fin de la ligne précèdente", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim cmd = New SQLiteCommand("INSERT INTO consommationGasoil([Code Camion], [Date Remplissage Gasoil], [Km Debut], [Km Fin], 
                                        [Km Parcourus], [Quantite Gasoil], [Taux de consommation])
                                        VALUES (@code, @dateRemplissage, @kmDebut, @kmFin, @kmParcourus, @qtGasoil, @taux)", con)
                cmd.Parameters.AddWithValue("@code", codeCamion)
                cmd.Parameters.AddWithValue("@dateRemplissage", dateRG)
                cmd.Parameters.AddWithValue("@kmDebut", kmDebut)
                cmd.Parameters.AddWithValue("@kmFin", kmFin)
                cmd.Parameters.AddWithValue("@kmParcourus", kmParcouru)
                cmd.Parameters.AddWithValue("@qtGasoil", qtGasoil)
                cmd.Parameters.AddWithValue("@taux", taux)
                cmd.ExecuteNonQuery()
            Next
            MessageBox.Show("Ligne(s) collée(s) avec succès")
            DialogResult = DialogResult.OK
            chargerTable(DataGridView1, "consommationGasoil", code, bsConsommationGasoil)
            Dim index As Integer = Integer.Max(0, DataGridView1.Rows.Count - 1)
            DataGridView1.CurrentCell = DataGridView1.Rows(index).Cells(1)
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
    Private Sub txtCode_lostFocus(sender As Object, e As EventArgs) Handles txtCode.LostFocus
        losttFocus(txtCode)
    End Sub
    Private Sub txtKmDebut_GotFocus(sender As Object, e As EventArgs) Handles txtKmDebut.GotFocus
        gottFocus(txtKmDebut)
    End Sub
    Private Sub txtKmDebut_lostFocus(sender As Object, e As EventArgs) Handles txtKmDebut.LostFocus
        losttFocus(txtKmDebut)
    End Sub
    Private Sub txtKmFin_GotFocus(sender As Object, e As EventArgs) Handles txtKmFin.GotFocus
        gottFocus(txtKmFin)
    End Sub
    Private Sub txtKmFin_lostFocus(sender As Object, e As EventArgs) Handles txtKmFin.LostFocus
        losttFocus(txtKmFin)
    End Sub
    Private Sub txtKmParcourus_GotFocus(sender As Object, e As EventArgs) Handles txtKmParcourus.GotFocus
        gottFocus(txtKmParcourus)
    End Sub
    Private Sub txtKmParcourus_lostFocus(sender As Object, e As EventArgs) Handles txtKmParcourus.LostFocus
        losttFocus(txtKmParcourus)
    End Sub
    Private Sub txtQtGasoil_GotFocus(sender As Object, e As EventArgs) Handles txtQtGasoil.GotFocus
        gottFocus(txtQtGasoil)
    End Sub
    Private Sub txtQtGasoil_lostFocus(sender As Object, e As EventArgs) Handles txtQtGasoil.LostFocus
        losttFocus(txtQtGasoil)
    End Sub
    Private Sub txtTaux_GotFocus(sender As Object, e As EventArgs) Handles txtTaux.GotFocus
        gottFocus(txtTaux)
    End Sub
    Private Sub txtTaux_lostFocus(sender As Object, e As EventArgs) Handles txtTaux.LostFocus
        losttFocus(txtTaux)
    End Sub

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, txtKmDebut.KeyDown, txtKmFin.KeyDown,
        txtKmParcourus.KeyDown, txtQtGasoil.KeyDown, dateRemplissage.KeyDown, txtTaux.KeyDown

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
        If bsConsommationGasoil Is Nothing Then Exit Sub
        Dim filtres As New List(Of String)

        If txtCode.Text.Trim() <> "" Then
            Dim code As Integer
            If Integer.TryParse(txtCode.Text.Trim(), code) Then
                filtres.Add($"[Code Camion] = {code}")
            End If
        End If
        If dateRemplissage.Checked Then
            filtres.Add($"[Date Remplissage Gasoil] = '{dateRemplissage.Value.ToString("dd-MM-yyyy")}'")
        End If
        If txtKmDebut.Text.Trim() <> "" Then
            Dim kmDebut As Decimal
            If Decimal.TryParse(txtKmDebut.Text.Trim(), kmDebut) Then
                filtres.Add($"[Km Debut] = {kmDebut}")
            End If
        End If
        If txtKmFin.Text.Trim() <> "" Then
            Dim kmFin As Decimal
            If Decimal.TryParse(txtKmFin.Text.Trim(), kmFin) Then
                filtres.Add($"[Km Fin] = {kmFin}")
            End If
        End If
        If txtKmParcourus.Text.Trim() <> "" Then
            Dim kmParcourus As Decimal
            If Decimal.TryParse(txtKmParcourus.Text.Trim(), kmParcourus) Then
                filtres.Add($"[Km Parcourus] = {kmParcourus}")
            End If
        End If
        If txtQtGasoil.Text.Trim() <> "" Then
            Dim qtGasoil As Decimal
            If Decimal.TryParse(txtQtGasoil.Text.Trim(), qtGasoil) Then
                filtres.Add($"[Quantite Gasoil] = {qtGasoil}")
            End If
        End If
        If txtTaux.Text.Trim() <> "" Then
            Dim taux As Decimal
            If Decimal.TryParse(txtTaux.Text.Trim(), taux) Then
                filtres.Add($"[Taux de consommation] = {taux}")
            End If
        End If

        bsConsommationGasoil.Filter = String.Join(" AND ", filtres)
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub dateRemplissage_ValueChanged(sender As Object, e As EventArgs) Handles dateRemplissage.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub txtKmDebut_TextChanged(sender As Object, e As EventArgs) Handles txtKmDebut.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtKmFin_TextChanged(sender As Object, e As EventArgs) Handles txtKmFin.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtKmParcourus_TextChanged(sender As Object, e As EventArgs) Handles txtKmParcourus.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtQtGasoil_TextChanged(sender As Object, e As EventArgs) Handles txtQtGasoil.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtTaux_TextChanged(sender As Object, e As EventArgs) Handles txtTaux.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub clearFiltre()
        txtCode.Clear()
        dateRemplissage.Checked = False
        txtKmDebut.Clear()
        txtKmFin.Clear()
        txtKmParcourus.Clear()
        txtQtGasoil.Clear()
        txtTaux.Clear()
        bsConsommationGasoil.RemoveFilter()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearFiltre()
    End Sub

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