Imports System.Data.SQLite


Public Class ficheCamionAjout

    Public Property edit As Boolean = False
    Public Property code As Integer = 0

    Private lasttxt As TextBox = Nothing

    Private Sub txtTonnage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTonnage.KeyPress
        blockNoNum(txtTonnage, e)
    End Sub
    Private Sub txtChauffeur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChauffeur.KeyPress
        blockNum(e)
    End Sub
    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        blockNoNum(txtTel, e)
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

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtMatricule.KeyDown, txtType.KeyDown, txtTonnage.KeyDown, dateCarnetcirc.KeyDown, dateVisitetech.KeyDown, txtCarteGrise.KeyDown, dateCarteGrise.KeyDown, txtAssurance.KeyDown, dateAssurance.KeyDown, txtChauffeur.KeyDown, txtTel.KeyDown
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
            If txtType.Focused Then
                afficherSuggestions("Type", "ficheCamion", txtType, Panel1, ListBox1)
                lasttxt = txtType
            ElseIf txtChauffeur.Focused Then
                afficherSuggestions("Chauffeur", "ficheCamion", txtChauffeur, Panel1, ListBox1)
                lasttxt = txtChauffeur
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

    Private Sub ficheCamionAjout_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
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

    Private Sub ficheCamionAjout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Panel1.Visible = False
        Panel1.BringToFront()


        Try
            Connect()

            Dim autoCompleteType As New AutoCompleteStringCollection()
            Dim autoCompleteChauffeur As New AutoCompleteStringCollection()
            Dim cmdAuto As New SQLiteCommand("SELECT DISTINCT Type, Chauffeur FROM ficheCamion", con)
            Dim readerAuto As SQLiteDataReader = cmdAuto.ExecuteReader

            While readerAuto.Read()
                autoCompleteType.Add(readerAuto("Type").ToString())
                autoCompleteChauffeur.Add(readerAuto("Chauffeur").ToString())
            End While
            readerAuto.Close()

            txtType.AutoCompleteCustomSource = autoCompleteType
            txtType.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtType.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtChauffeur.AutoCompleteCustomSource = autoCompleteChauffeur
            txtChauffeur.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtChauffeur.AutoCompleteSource = AutoCompleteSource.CustomSource

            If edit Then
                ' Load existing camion data for editing

                Dim cmd As New SQLiteCommand("SELECT * FROM ficheCamion WHERE Code = @code", con)
                cmd.Parameters.AddWithValue("@code", code)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtMatricule.Text = reader("Matricule").ToString()
                    txtType.Text = reader("Type").ToString()
                    txtTonnage.Text = reader("Tonnage").ToString()
                    dateCarnetcirc.Value = Convert.ToDateTime(reader("Date Carnet de circulation"))
                    dateVisitetech.Value = Convert.ToDateTime(reader("Date Visite technique"))
                    txtCarteGrise.Text = reader("Carte Grise").ToString()
                    dateCarteGrise.Value = Convert.ToDateTime(reader("Date Carte Grise"))
                    txtAssurance.Text = reader("Assurance").ToString()
                    dateAssurance.Value = Convert.ToDateTime(reader("Date Assurance"))
                    txtChauffeur.Text = reader("Chauffeur").ToString()
                    txtTel.Text = reader("Téléphone").ToString()
                End If
                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des données: " & ex.Message, "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub
    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles Valider.Click
        Try

            Dim premier As Boolean = False
            If String.IsNullOrWhiteSpace(txtMatricule.Text) Then
                nullFocus(txtMatricule)
                If Not premier Then
                    txtMatricule.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtMatricule)
            End If
            If String.IsNullOrWhiteSpace(txtType.Text) Then
                nullFocus(txtType)
                If Not premier Then
                    txtType.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtType)
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
            If String.IsNullOrWhiteSpace(txtCarteGrise.Text) Then
                nullFocus(txtCarteGrise)
                If Not premier Then
                    txtCarteGrise.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtCarteGrise)
            End If
            If String.IsNullOrWhiteSpace(txtAssurance.Text) Then
                nullFocus(txtAssurance)
                If Not premier Then
                    txtAssurance.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtAssurance)
            End If
            If String.IsNullOrWhiteSpace(txtChauffeur.Text) Then
                nullFocus(txtChauffeur)
                If Not premier Then
                    txtChauffeur.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtChauffeur)
            End If
            If String.IsNullOrWhiteSpace(txtTel.Text) Then
                nullFocus(txtTel)
                If Not premier Then
                    txtTel.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtTel)
            End If
            If premier Then
                MessageBox.Show("Veuillez remplir tous les champs", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim tonnage As Decimal = Convert.ToDecimal(txtTonnage.Text)
            If tonnage <= 0 Then
                MessageBox.Show("Le tonnage doit être supérieur à 0", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim telephone As String = txtTel.Text
            If telephone.Length <> 10 Then
                MessageBox.Show("Le numéro de téléphone doit contenir 10 chiffres", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Connect()

            Dim cmd As SQLiteCommand
            Dim mat As SQLiteCommand
            Dim chauf As SQLiteCommand
            Dim tel As SQLiteCommand
            Dim cartg As SQLiteCommand
            mat = New SQLiteCommand("SELECT COUNT(*) FROM ficheCamion WHERE Matricule = @matricule AND Code!=@code", con)
            mat.Parameters.AddWithValue("@matricule", txtMatricule.Text)
            mat.Parameters.AddWithValue("@code", If(edit, code, 0)) ' Use 0 if not editing
            Dim count As Integer = Convert.ToInt32(mat.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Matricule déjà existante", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            chauf = New SQLiteCommand("SELECT COUNT(*) FROM ficheCamion WHERE Chauffeur = @chauffeur AND Code!=@code", con)
            chauf.Parameters.AddWithValue("@chauffeur", txtChauffeur.Text)
            chauf.Parameters.AddWithValue("@code", If(edit, code, 0)) ' Use 0 if not editing
            count = Convert.ToInt32(chauf.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Chauffeur est déjà occupé", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            tel = New SQLiteCommand("SELECT COUNT(*) FROM ficheCamion WHERE Téléphone = @téléphone AND Code!=@code", con)
            tel.Parameters.AddWithValue("@téléphone", txtTel.Text)
            tel.Parameters.AddWithValue("@code", If(edit, code, 0)) ' Use 0 if not editing
            count = Convert.ToInt32(tel.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Téléphone déjà existant", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            cartg = New SQLiteCommand("SELECT COUNT(*) FROM ficheCamion WHERE `Carte Grise` = @carteGrise AND Code!=@code", con)
            cartg.Parameters.AddWithValue("@carteGrise", txtCarteGrise.Text)
            cartg.Parameters.AddWithValue("@code", If(edit, code, 0)) ' Use 0 if not editing
            count = Convert.ToInt32(cartg.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Carte Grise déjà existante", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If edit Then
                ' Update existing camion
                cmd = New SQLiteCommand("UPDATE ficheCamion SET Matricule = @matricule, Type = @type, Tonnage = @tonnage, " &
                                       "[Date Carnet de circulation] = @dateCarnet, [Date Visite technique] = @dateVisite, " &
                                       "[Carte Grise] = @carteGrise, [Date Carte Grise] = @dateCarteGrise, Assurance = @assurance, " &
                                       "[Date Assurance] = @dateAssurance, Chauffeur = @chauffeur, Téléphone = @téléphone WHERE Code = @code", con)
                cmd.Parameters.AddWithValue("@code", code)
            Else
                ' Insert new camion
                cmd = New SQLiteCommand("INSERT INTO ficheCamion (Matricule, Type, Tonnage, [Date Carnet de circulation], " &
                                        "[Date Visite technique], [Carte Grise], [Date Carte Grise], Assurance, [Date Assurance], Chauffeur, Téléphone) 
                                       VALUES (@matricule, @type, @tonnage, @dateCarnet, @dateVisite, @carteGrise, @dateCarteGrise, @assurance, @dateAssurance, @chauffeur, @téléphone)", con)
            End If
            cmd.Parameters.AddWithValue("@matricule", txtMatricule.Text)
            cmd.Parameters.AddWithValue("@type", txtType.Text)
            cmd.Parameters.AddWithValue("@tonnage", Convert.ToDecimal(txtTonnage.Text))
            cmd.Parameters.AddWithValue("@dateCarnet", dateCarnetcirc.Value.Date)
            cmd.Parameters.AddWithValue("@dateVisite", dateVisitetech.Value.Date)
            cmd.Parameters.AddWithValue("@carteGrise", txtCarteGrise.Text)
            cmd.Parameters.AddWithValue("@dateCarteGrise", dateCarteGrise.Value.Date)
            cmd.Parameters.AddWithValue("@assurance", txtAssurance.Text)
            cmd.Parameters.AddWithValue("@dateAssurance", dateAssurance.Value.Date)
            cmd.Parameters.AddWithValue("@chauffeur", txtChauffeur.Text)
            cmd.Parameters.AddWithValue("@téléphone", txtTel.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Camion " & If(edit, "modifié", "ajouté") & " avec succès")
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
End Class