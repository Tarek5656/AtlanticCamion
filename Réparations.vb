Imports System.Drawing.Printing
Imports System.Data.SQLite

Public Class Réparations

    Public Property code As Integer
    Public Property bsRéparations As New BindingSource()
    Private Sub Réparations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TableLayoutPanel1.RowStyles(0).SizeType = SizeType.Percent
        TableLayoutPanel1.RowStyles(0).Height = 8
        TableLayoutPanel1.RowStyles(1).Height = 92
        clearFiltre()
        chargerTable(DataGridView1, "réparations", code, bsRéparations)
    End Sub

    Private Sub Ajouter_Click(sender As Object, e As EventArgs) Handles Ajouter.Click
        Dim addForm As New RéparationsAjout()
        addForm.code = code
        addForm.ShowDialog()
        If addForm.DialogResult = DialogResult.OK Then
            chargerTable(DataGridView1, "réparations", code, bsRéparations)
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
        Dim editForm As New RéparationsAjout()
        editForm.edit = True
        editForm.id = id
        editForm.ShowDialog()
        If editForm.DialogResult = DialogResult.OK Then
            chargerTable(DataGridView1, "réparations", code, bsRéparations)
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
                        delete("réparations", "id", id, 1)

                    Next
                    MessageBox.Show("Lignes supprimées avec succès", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Erreur de connexion: " & ex.Message)
                Finally
                    Disconnect()
                End Try
                chargerTable(DataGridView1, "réparations", code, bsRéparations)
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
                delete("réparations", "id", id, 0)
                chargerTable(DataGridView1, "réparations", code, bsRéparations)
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
                Dim dateDebut = Convert.ToDateTime(colonne(1))
                Dim dateFin = Convert.ToDateTime(colonne(2))
                Dim nature = colonne(3)
                Dim designation = colonne(4)
                Dim reparateur = colonne(5)
                Dim reference = colonne(6)
                Dim facture = colonne(7)

                Dim cmd = New SQLiteCommand("INSERT INTO réparations([Code Camion],[Date Debut], [Date Fin],[Nature de réparation],Désignation,Réparateur,
                                        Référence,Facture) VALUES(@code,@dateDebut, @dateFin,@nature,@designation,@reparateur,@reference,@facture) ", con)
                cmd.Parameters.AddWithValue("@code", codeCamion)
                cmd.Parameters.AddWithValue("@dateDebut", dateDebut)
                cmd.Parameters.AddWithValue("@dateFin", dateFin)
                cmd.Parameters.AddWithValue("@nature", nature)
                cmd.Parameters.AddWithValue("@designation", designation)
                cmd.Parameters.AddWithValue("@reparateur", reparateur)
                cmd.Parameters.AddWithValue("@reference", reference)
                cmd.Parameters.AddWithValue("@facture", facture)
                cmd.ExecuteNonQuery()

                Dim updateStatut As SQLiteCommand = New SQLiteCommand("UPDATE ficheCamion SET Statut = 'En Réparation' WHERE Code = @code", con)
                updateStatut.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
                updateStatut.ExecuteNonQuery()
            Next
            MessageBox.Show("Ligne(s) collée(s) avec succès")
            DialogResult = DialogResult.OK
            chargerTable(DataGridView1, "réparations", code, bsRéparations)
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

    Private Sub txtcode_GotFocus(sender As Object, e As EventArgs) Handles txtCode.GotFocus
        gottFocus(txtCode)
    End Sub
    Private Sub txtcode_LostFocus(sender As Object, e As EventArgs) Handles txtCode.LostFocus
        losttFocus(txtCode)
    End Sub
    Private Sub txtNature_GotFocus(sender As Object, e As EventArgs) Handles txtNature.GotFocus
        gottFocus(txtNature)
    End Sub
    Private Sub txtNature_LostFocus(sender As Object, e As EventArgs) Handles txtNature.LostFocus
        losttFocus(txtNature)
    End Sub
    Private Sub txtDesignation_GotFocus(sender As Object, e As EventArgs) Handles txtDesignation.GotFocus
        gottFocus(txtDesignation)
    End Sub
    Private Sub txtDesignation_LostFocus(sender As Object, e As EventArgs) Handles txtDesignation.LostFocus
        losttFocus(txtDesignation)
    End Sub
    Private Sub txtReparateur_GotFocus(sender As Object, e As EventArgs) Handles txtReparateur.GotFocus
        gottFocus(txtReparateur)
    End Sub
    Private Sub txtReparateur_LostFocus(sender As Object, e As EventArgs) Handles txtReparateur.LostFocus
        losttFocus(txtReparateur)
    End Sub
    Private Sub txtReference_GotFocus(sender As Object, e As EventArgs) Handles txtReference.GotFocus
        gottFocus(txtReference)
    End Sub
    Private Sub txtReference_LostFocus(sender As Object, e As EventArgs) Handles txtReference.LostFocus
        losttFocus(txtReference)
    End Sub

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, dateDebut.KeyDown, dateFin.KeyDown, txtNature.KeyDown,
        txtDesignation.KeyDown, txtReparateur.KeyDown, txtReference.KeyDown, Button1.KeyDown

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
        If bsRéparations Is Nothing Then Exit Sub
        Dim filtres As New List(Of String)

        If txtCode.Text.Trim() <> "" Then
            Dim code As Integer
            If Integer.TryParse(txtCode.Text.Trim(), code) Then
                filtres.Add($"[Code Camion] = {code}")
            End If
        End If
        If dateDebut.Checked Then
            filtres.Add($"[Date Debut] = '{dateDebut.Value.ToString("dd-MM-yyyy")}'")
        End If
        If dateFin.Checked Then
            filtres.Add($"[Date Fin] = '{dateFin.Value.ToString("dd-MM-yyyy")}'")
        End If
        If txtNature.Text.Trim() <> "" Then
            filtres.Add($"[Nature de réparation] LIKE '%{txtNature.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtDesignation.Text.Trim() <> "" Then
            filtres.Add($"Désignation LIKE '%{txtDesignation.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtReparateur.Text.Trim() <> "" Then
            filtres.Add($"Réparateur LIKE '%{txtReparateur.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtReference.Text.Trim() <> "" Then
            filtres.Add($"Référence LIKE '%{txtReference.Text.Trim().Replace("'", "''")}%'")
        End If

        bsRéparations.Filter = String.Join(" AND ", filtres)
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub dateDebut_ValueChanged(sender As Object, e As EventArgs) Handles dateDebut.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub dateFin_ValueChanged(sender As Object, e As EventArgs) Handles dateFin.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub txtNature_TextChanged(sender As Object, e As EventArgs) Handles txtNature.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtDesignation_TextChanged(sender As Object, e As EventArgs) Handles txtDesignation.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtReparateur_TextChanged(sender As Object, e As EventArgs) Handles txtReparateur.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtReference_TextChanged(sender As Object, e As EventArgs) Handles txtReference.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub clearFiltre()
        txtCode.Clear()
        dateDebut.Checked = False
        txtNature.Clear()
        txtDesignation.Clear()
        txtReparateur.Clear()
        txtReference.Clear()
        bsRéparations.RemoveFilter()
    End Sub

    Private Sub Réinitialiser_Click(sender As Object, e As EventArgs) Handles Réinitialiser.Click
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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class