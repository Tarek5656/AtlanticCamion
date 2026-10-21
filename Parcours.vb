Imports System.Drawing.Printing
Imports System.Data.SQLite

Public Class Parcours

    Public Property code As Integer
    Public Property bsParcours As New BindingSource()

    Private Sub Parcours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TableLayoutPanel1.RowStyles(0).SizeType = SizeType.Percent
        TableLayoutPanel1.RowStyles(0).Height = 8
        TableLayoutPanel1.RowStyles(1).Height = 92
        clearFiltre()
        chargerTable(DataGridView1, "parcours", code, bsParcours)
    End Sub

    Private Sub Ajouter_Click(sender As Object, e As EventArgs) Handles Ajouter.Click
        Dim addForm As New ParcoursAjout()
        addForm.code = code
        addForm.ShowDialog()
        If addForm.DialogResult = DialogResult.OK Then
            chargerTable(DataGridView1, "parcours", code, bsParcours)
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
        Dim editForm As New ParcoursAjout()
        editForm.edit = True
        editForm.id = id
        editForm.ShowDialog()
        If editForm.DialogResult = DialogResult.OK Then
            chargerTable(DataGridView1, "parcours", code, bsParcours)
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
                        delete("parcours", "id", id, 1)

                    Next
                    MessageBox.Show("Lignes supprimées avec succès", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Erreur de connexion: " & ex.Message)
                Finally
                    Disconnect()
                End Try
                chargerTable(DataGridView1, "parcours", code, bsParcours)
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
                delete("parcours", "id", id, 0)
                chargerTable(DataGridView1, "parcours", code, bsParcours)
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
                Dim dateD = Convert.ToDateTime(colonne(1))
                Dim dateA = Convert.ToDateTime(colonne(2))
                Dim client = colonne(3)
                Dim ville = colonne(4)
                Dim distance = Convert.ToDecimal(colonne(5))
                Dim tonnage = Convert.ToDecimal(colonne(6))

                Dim verf = New SQLiteCommand("SELECT Tonnage FROM ficheCamion WHERE Code = @code", con)
                verf.Parameters.AddWithValue("@code", codeCamion)
                Dim resultat = Convert.ToDecimal(verf.ExecuteScalar())
                If tonnage > resultat Then
                    MessageBox.Show($"Ligne {i} : Le tonnage ne peut pas dépasser le tonnage max du camion", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim cmd = New SQLiteCommand("INSERT INTO parcours([Code Camion], [Date Départ], [Date Arrivée], Client, Ville, Distance, Tonnage)
                                        VALUES (@code, @dateDepart, @dateArrivee, @client, @ville, @distance, @tonnage)", con)
                cmd.Parameters.AddWithValue("@code", codeCamion)
                cmd.Parameters.AddWithValue("@dateDepart", dateD)
                cmd.Parameters.AddWithValue("@dateArrivee", dateA)
                cmd.Parameters.AddWithValue("@client", client)
                cmd.Parameters.AddWithValue("@ville", ville)
                cmd.Parameters.AddWithValue("@distance", distance)
                cmd.Parameters.AddWithValue("@tonnage", tonnage)
                cmd.ExecuteNonQuery()

                Dim updateStatut As SQLiteCommand = New SQLiteCommand("UPDATE ficheCamion SET Statut = 'En Livraison' WHERE Code = @code", con)
                updateStatut.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
                updateStatut.ExecuteNonQuery()
            Next
            MessageBox.Show("Ligne(s) collée(s) avec succès")
            DialogResult = DialogResult.OK
            chargerTable(DataGridView1, "parcours", code, bsParcours)
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
    Private Sub txtClient_GotFocus(sender As Object, e As EventArgs) Handles txtClient.GotFocus
        gottFocus(txtClient)
    End Sub
    Private Sub txtClient_LostFocus(sender As Object, e As EventArgs) Handles txtClient.LostFocus
        losttFocus(txtClient)
    End Sub
    Private Sub txtVille_GotFocus(sender As Object, e As EventArgs) Handles txtVille.GotFocus
        gottFocus(txtVille)
    End Sub
    Private Sub txtVille_LostFocus(sender As Object, e As EventArgs) Handles txtVille.LostFocus
        losttFocus(txtVille)
    End Sub
    Private Sub txtDistance_GotFocus(sender As Object, e As EventArgs) Handles txtDistance.GotFocus
        gottFocus(txtDistance)
    End Sub
    Private Sub txtDistance_LostFocus(sender As Object, e As EventArgs) Handles txtDistance.LostFocus
        losttFocus(txtDistance)
    End Sub
    Private Sub txtTonnage_GotFocus(sender As Object, e As EventArgs) Handles txtTonnage.GotFocus
        gottFocus(txtTonnage)
    End Sub
    Private Sub txtTonnage_LostFocus(sender As Object, e As EventArgs) Handles txtTonnage.LostFocus
        losttFocus(txtTonnage)
    End Sub

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, dateDepart.KeyDown, dateArrivee.KeyDown, txtClient.KeyDown,
        txtVille.KeyDown, txtDistance.KeyDown, txtTonnage.KeyDown

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
        If bsParcours Is Nothing Then Exit Sub
        Dim filtres As New List(Of String)

        If txtCode.Text.Trim() <> "" Then
            Dim code As Integer
            If Integer.TryParse(txtCode.Text.Trim(), code) Then
                filtres.Add($"[Code Camion] = {code}")
            End If
        End If
        If dateDepart.Checked Then
            filtres.Add($"[Date Départ] = '{dateDepart.Value.ToString("dd-MM-yyyy")}'")
        End If
        If dateArrivee.Checked Then
            filtres.Add($"[Date Arrivée] = '{dateArrivee.Value.ToString("dd-MM-yyyy")}'")
        End If
        If txtClient.Text.Trim() <> "" Then
            filtres.Add($"Client LIKE '%{txtClient.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtVille.Text.Trim() <> "" Then
            filtres.Add($"Ville LIKE '%{txtVille.Text.Trim().Replace("'", "''")}%'")
        End If
        If txtDistance.Text.Trim() <> "" Then
            Dim distance As Decimal
            If Decimal.TryParse(txtDistance.Text.Trim(), distance) Then
                filtres.Add($"Distance = {distance}")
            End If
        End If
        If txtTonnage.Text.Trim() <> "" Then
            Dim tonnage As Decimal
            If Decimal.TryParse(txtTonnage.Text.Trim(), tonnage) Then
                filtres.Add($"Tonnage = {tonnage}")
            End If
        End If

        bsParcours.Filter = String.Join(" AND ", filtres)
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub dateDepart_ValueChanged(sender As Object, e As EventArgs) Handles dateDepart.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub dateArrivee_ValueChanged(sender As Object, e As EventArgs) Handles dateArrivee.ValueChanged
        appliquerFiltre()
    End Sub
    Private Sub txtClient_TextChanged(sender As Object, e As EventArgs) Handles txtClient.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtVille_TextChanged(sender As Object, e As EventArgs) Handles txtVille.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtDistance_TextChanged(sender As Object, e As EventArgs) Handles txtDistance.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub txtTonnage_TextChanged(sender As Object, e As EventArgs) Handles txtTonnage.TextChanged
        appliquerFiltre()
    End Sub
    Private Sub clearFiltre()
        txtCode.Clear()
        dateDepart.Checked = False
        txtClient.Clear()
        txtVille.Clear()
        txtDistance.Clear()
        txtTonnage.Clear()
        bsParcours.RemoveFilter()
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
End Class