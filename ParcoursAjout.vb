Imports System.Data.SQLite

Public Class ParcoursAjout

    Public Property edit As Boolean = False
    Public Property id As Integer = 0
    Public Property code As Integer = 0

    Private lasttxt As TextBox = Nothing

    Private Sub txtDistance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDistance.KeyPress
        blockNoNum(txtDistance, e)
    End Sub
    Private Sub txtTonnage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTonnage.KeyPress
        blockNoNum(txtTonnage, e)
    End Sub
    Private Sub txtClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClient.KeyPress
        blockNum(e)
    End Sub
    Private Sub txtVille_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVille.KeyPress
        blockNum(e)
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

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, txtClient.KeyDown, txtVille.KeyDown,
        txtDistance.KeyDown, txtTonnage.KeyDown, dateDepart.KeyDown, dateArrivee.KeyDown

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

    Private Sub ficheCamionAjout_keyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            If txtClient.Focused Then
                afficherSuggestions("Client", "parcours", txtClient, Panel1, ListBox1)
                lasttxt = txtClient
            ElseIf txtVille.Focused Then
                afficherSuggestions("Ville", "parcours", txtVille, Panel1, ListBox1)
                lasttxt = txtVille
            End If
        End If
    End Sub

    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseClick
        If ListBox1.SelectedItem IsNot Nothing AndAlso lasttxt IsNot Nothing Then
            lasttxt.Text = ListBox1.SelectedItem.ToString()
            Panel1.Visible = False
            lasttxt.Focus()
        End If
    End Sub

    Private Sub parcours_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        If Panel1.Visible Then
            Panel1.Visible = False
            If lasttxt IsNot Nothing Then
                lasttxt.Focus()
            End If
        End If
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.SelectedItem IsNot Nothing AndAlso lasttxt IsNot Nothing Then
                lasttxt.Text = ListBox1.SelectedItem.ToString()
                Panel1.Visible = False
                lasttxt.Focus()
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Escape Then
            Panel1.Visible = False
            e.SuppressKeyPress = True
            lasttxt.Focus()
        End If
    End Sub

    Private Sub ParcoursAjout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCode.ReadOnly = True
        Me.KeyPreview = True
        Panel1.Visible = False
        Panel1.BringToFront()


        Try
            Connect()

            Dim autoCompleteClient As New AutoCompleteStringCollection()
            Dim autoCompleteVille As New AutoCompleteStringCollection()
            Dim cmdAuto As New SQLiteCommand("SELECT DISTINCT Client, Ville FROM parcours", con)
            Dim readerAuto As SQLiteDataReader = cmdAuto.ExecuteReader()

            While readerAuto.Read()
                If Not IsDBNull(readerAuto("Client")) Then
                    autoCompleteClient.Add(readerAuto("Client").ToString())
                End If
                If Not IsDBNull(readerAuto("Ville")) Then
                    autoCompleteVille.Add(readerAuto("Ville").ToString())
                End If
            End While
            readerAuto.Close()

            txtClient.AutoCompleteCustomSource = autoCompleteClient
            txtClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtClient.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtVille.AutoCompleteCustomSource = autoCompleteVille
            txtVille.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtVille.AutoCompleteSource = AutoCompleteSource.CustomSource

            If edit Then
                ' Load existing camion data for editing
                Dim cmd As New SQLiteCommand("SELECT * FROM parcours WHERE id= @id", con)
                cmd.Parameters.AddWithValue("@id", id)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtCode.Text = reader("Code Camion").ToString()
                    dateDepart.Value = Convert.ToDateTime(reader("Date Départ"))
                    dateArrivee.Value = Convert.ToDateTime(reader("Date Arrivée"))
                    txtClient.Text = reader("Client").ToString()
                    txtVille.Text = reader("Ville").ToString()
                    txtDistance.Text = reader("Distance").ToString()
                    txtTonnage.Text = reader("Tonnage").ToString()
                End If
                reader.Close()
            Else
                txtCode.Text = code.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des données " & ex.Message, "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try

    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles Valider.Click
        Try

            Dim premier As Boolean = False
            If String.IsNullOrWhiteSpace(txtClient.Text) Then
                nullFocus(txtClient)
                If Not premier Then
                    txtClient.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtClient)
            End If
            If String.IsNullOrWhiteSpace(txtVille.Text) Then
                nullFocus(txtVille)
                If Not premier Then
                    txtVille.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtVille)
            End If
            If String.IsNullOrWhiteSpace(txtDistance.Text) Then
                nullFocus(txtDistance)
                If Not premier Then
                    txtDistance.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtDistance)
            End If
            If String.IsNullOrWhiteSpace(txtTonnage.Text) Then
                nullFocus(txtTonnage)
                If Not premier Then
                    txtTonnage.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtTonnage)
            End If
            If premier Then
                MessageBox.Show("Veuillez remplir tous les champs", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim distance As Decimal = Convert.ToDecimal(txtDistance.Text)
            Dim tonnage As Decimal = Convert.ToDecimal(txtTonnage.Text)
            If distance <= 0 Then
                MessageBox.Show("La distance doit être supérieur à 0", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            If tonnage <= 0 Then
                MessageBox.Show("Le tonnage doit être supérieur à 0", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dateD As Date = Convert.ToDateTime(dateDepart.Value.Date)
            Dim dateA As Date = Convert.ToDateTime(dateArrivee.Value.Date)
            If dateD > dateA Then
                MessageBox.Show("La date d'Arrivée doit être supérieur à celle du Départ", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If


            Connect()
            Dim cmd As SQLiteCommand
            Dim tonn As SQLiteCommand
            tonn = New SQLiteCommand("SELECT Tonnage FROM ficheCamion WHERE Code = @code", con)
            tonn.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
            Dim ton = Convert.ToDecimal(tonn.ExecuteScalar)
            If Convert.ToDecimal(txtTonnage.Text) > ton Then
                MessageBox.Show("Le tonnage ne peut pas dépasser le tonnage max du camion", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If edit Then
                ' Update existing camion
                cmd = New SQLiteCommand("UPDATE parcours SET  [Date Départ]=@dateDepart, [Date Arrivée]=@dateArrivee, Client=@client, Ville=@ville, 
                                        Distance=@distance, Tonnage=@tonnage WHERE id = @id", con)
                cmd.Parameters.AddWithValue("@id", id)
            Else
                ' Insert new camion
                cmd = New SQLiteCommand("INSERT INTO parcours([Code Camion], [Date Départ], [Date Arrivée], Client, Ville, Distance, Tonnage)
                                        VALUES (@code, @dateDepart, @dateArrivee, @client, @ville, @distance, @tonnage)", con)
            End If
            cmd.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
            cmd.Parameters.AddWithValue("@dateDepart", dateDepart.Value.Date)
            cmd.Parameters.AddWithValue("@dateArrivee", dateArrivee.Value.Date)
            cmd.Parameters.AddWithValue("@client", txtClient.Text)
            cmd.Parameters.AddWithValue("@ville", txtVille.Text)
            cmd.Parameters.AddWithValue("@distance", Convert.ToDecimal(txtDistance.Text))
            cmd.Parameters.AddWithValue("@tonnage", Convert.ToDecimal(txtTonnage.Text))
            cmd.ExecuteNonQuery()

            Dim updateStatut As SQLiteCommand = New SQLiteCommand("UPDATE ficheCamion SET Statut = 'En Livraison' WHERE Code = @code AND Statut = 'Disponible'", con)
            updateStatut.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
            updateStatut.ExecuteNonQuery()

            MessageBox.Show("Ligne " & If(edit, "modifiée", "ajoutée") & " avec succès", "Validation",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Close() ' Close the form after saving
        Catch ex As Exception
            MessageBox.Show("Erreur de sauvegarde: " & ex.Message, "Erreur",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub Annuler_Click(sender As Object, e As EventArgs) Handles Annuler.Click
        Dim result As DialogResult = MessageBox.Show("Voulez-vous annuler l'opération?", "Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class