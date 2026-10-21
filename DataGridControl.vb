Imports System.Drawing.Printing

Module DataGridControl

    Public Sub copierTexte(dataGrid As DataGridView)
        If dataGrid.SelectedCells.Count = 0 Then Exit Sub

        Dim selectedRows = dataGrid.SelectedRows
        Dim textToCopy As New Text.StringBuilder()

        Dim fullRowsSelected As Boolean = (selectedRows.Count > 0) AndAlso
        (selectedRows.Count = dataGrid.SelectedCells.Cast(Of DataGridViewCell)().
        Select(Function(c) c.OwningRow).Distinct().Count())

        If fullRowsSelected Then

            For Each col As DataGridViewColumn In dataGrid.Columns
                If col.Visible Then
                    textToCopy.Append(col.HeaderText & vbTab)
                End If
            Next
            textToCopy.AppendLine()

            ' Copy the entire row
            For Each row As DataGridViewRow In selectedRows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible Then textToCopy.Append(cell.Value?.ToString() & vbTab)
                Next
                textToCopy.AppendLine()
            Next
        Else
            Dim selectedCells = dataGrid.SelectedCells.Cast(Of DataGridViewCell)().
                OrderBy(Function(c) c.RowIndex).ThenBy(Function(c) c.ColumnIndex)
            ' Copy only selected cells
            Dim currentRow As Integer = -1

            For Each cell In selectedCells
                If cell.RowIndex <> currentRow Then
                    If currentRow <> -1 Then textToCopy.AppendLine()
                    currentRow = cell.RowIndex
                End If
                textToCopy.Append(cell.Value?.ToString() & vbTab)
            Next
            textToCopy.AppendLine()
        End If
        Clipboard.SetText(textToCopy.ToString().TrimEnd(vbTab, vbLf, vbCr))
    End Sub

    Public Function collerGriser(dataGrid As DataGridView) As Boolean

        Dim data As IDataObject = Clipboard.GetDataObject()
        If data Is Nothing OrElse Not data.GetDataPresent(DataFormats.Text) Then Return False

        Dim clipboardText As String = Clipboard.GetText()
        Dim lignes As String() = clipboardText.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        If lignes.Count() < 2 Then Return False

        Dim clipboardColumns As String() = lignes(0).Split(vbTab)

        ' Récupérer les colonnes visibles du DataGridView
        Dim visibleColumns As New List(Of String)
        For Each col As DataGridViewColumn In dataGrid.Columns
            If col.Visible Then
                visibleColumns.Add(col.HeaderText.Trim())
            End If
        Next

        'For i As Integer = 0 To Math.Min(visibleColumns.Count - 1, clipboardColumns.Length - 1)
        'Debug.Print("clipboardColumns : " & clipboardColumns(i))
        'Debug.Print("visibleColumns : " & visibleColumns(i))
        'Next

        If clipboardColumns.Length - 1 <> visibleColumns.Count Then Return False

        For i As Integer = 0 To visibleColumns.Count - 1
            If clipboardColumns(i).Trim() <> visibleColumns(i) Then Return False
        Next

        Return True
    End Function


    Public Function collerTexte(dataGrid As DataGridView)
        Dim clipboardText As String = Clipboard.GetText()
        Dim lignes As String() = clipboardText.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

        Dim donnees As New List(Of String())
        For i As Integer = 0 To lignes.Length - 1
            Dim champs = lignes(i).Split(vbTab)
            donnees.Add(champs)
        Next
        Return donnees
    End Function

    Public Sub ImprimerLignesSelectionnees(ByRef lignesAAfficher As List(Of DataGridViewRow), doc As PrintDocument, apercu As PrintPreviewDialog, dataGrid As DataGridView)
        ' Récupère les lignes sélectionnées
        lignesAAfficher = dataGrid.SelectedRows.Cast(Of DataGridViewRow).OrderBy(Function(r) r.Index).ToList()

        If lignesAAfficher.Count = 0 Then
            MessageBox.Show("Aucune ligne sélectionnée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        doc.DefaultPageSettings.Landscape = True

        ' Configuration de l'aperçu
        apercu.Document = doc
        apercu.Width = 800
        apercu.Height = 400
        apercu.ShowDialog()
        apercu.BringToFront()
    End Sub

    Public Sub printPage(e As PrintPageEventArgs, lignesAAfficher As List(Of DataGridViewRow), dataGrid As DataGridView)
        Dim g As Graphics = e.Graphics
        Dim font As New Font("Arial", 8)
        Dim boldFont As New Font("Arial", 8, FontStyle.Bold)
        Dim margeGauche As Integer = 50
        Dim margeHaut As Integer = 100
        Dim hauteurLigne As Integer = 25
        Dim hauteurEntete As Integer = 30
        Dim largeurColonnes As New Dictionary(Of Integer, Integer)
        Dim largeurMin As Integer = 30
        Dim x As Integer = margeGauche
        Dim y As Integer = margeHaut

        ' 1. Calcul de la largeur max par mot dans chaque colonne
        For Each col As DataGridViewColumn In dataGrid.Columns
            If col.Visible Then
                Dim maxLargeur As Integer = TextRenderer.MeasureText(col.HeaderText, boldFont).Width + 40

                For Each row As DataGridViewRow In lignesAAfficher
                    Dim valeur As String = ""
                    If row.Cells(col.Index).Value IsNot Nothing Then
                        valeur = row.Cells(col.Index).Value.ToString()
                    End If

                    ' On mesure chaque mot individuellement
                    For Each mot As String In valeur.Split({" "c, vbTab, vbLf, "-"c}, StringSplitOptions.RemoveEmptyEntries)
                        Dim largeurMot = TextRenderer.MeasureText(mot, font).Width + 40
                        maxLargeur = Math.Max(maxLargeur, largeurMot)
                    Next
                Next

                largeurColonnes(col.Index) = Math.Max(maxLargeur, largeurMin)
            End If
        Next

        ' 2. Réduction proportionnelle si trop large pour la page
        Dim largeurTotale As Integer = largeurColonnes.Values.Sum()
        Dim largeurPage As Integer = e.MarginBounds.Width

        If largeurTotale > largeurPage Then
            Dim ratio As Double = largeurPage / largeurTotale
            For Each key In largeurColonnes.Keys.ToList()
                largeurColonnes(key) = Math.Max(CInt(largeurColonnes(key) * ratio), largeurMin)
            Next
        End If

        ' 3. Dessin des entêtes
        x = margeGauche
        For Each col As DataGridViewColumn In dataGrid.Columns
            If col.Visible Then
                Dim largeur = largeurColonnes(col.Index)
                g.DrawRectangle(Pens.Black, x, y, largeur, hauteurEntete)
                Dim rectEntete As New RectangleF(x + 3, y + 3, largeur - 3, hauteurEntete - 3)
                g.DrawString(col.HeaderText, boldFont, Brushes.Black, rectEntete)
                x += largeur
            End If
        Next

        y += hauteurEntete

        ' 4. Affichage des données (sans coupure)
        For Each row As DataGridViewRow In lignesAAfficher
            x = margeGauche
            For Each col As DataGridViewColumn In dataGrid.Columns
                If col.Visible Then
                    Dim valeur As String = ""
                    If row.Cells(col.Index).Value IsNot Nothing Then
                        If TypeOf row.Cells(col.Index).Value Is DateTime Then
                            valeur = CDate(row.Cells(col.Index).Value).ToString("dd/MM/yyyy")
                        Else
                            valeur = row.Cells(col.Index).Value.ToString()
                        End If
                    End If

                    Dim largeur = largeurColonnes(col.Index)
                    g.DrawRectangle(Pens.Black, x, y, largeur, hauteurLigne)

                    Dim rectCellule As New RectangleF(x + 3, y + 3, largeur - 3, hauteurLigne - 3)
                    Dim formatAlign As New StringFormat()
                    formatAlign.Alignment = If(TypeOf row.Cells(col.Index).Value Is Decimal OrElse
                                               TypeOf row.Cells(col.Index).Value Is Integer OrElse
                                               TypeOf row.Cells(col.Index).Value Is Double,
                                               StringAlignment.Far, StringAlignment.Near)
                    formatAlign.LineAlignment = StringAlignment.Center
                    formatAlign.FormatFlags = StringFormatFlags.NoWrap
                    formatAlign.Trimming = StringTrimming.None ' NE PAS tronquer

                    g.DrawString(valeur, font, Brushes.Black, rectCellule, formatAlign)
                    x += largeur
                End If
            Next
            y += hauteurLigne
        Next
    End Sub

End Module
