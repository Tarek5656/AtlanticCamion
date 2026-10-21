Imports System.Data.SQLite

Public Class RéparationsAjout
    Public Property edit As Boolean = False
    Public Property id As Integer = 0
    Public Property code As Integer = 0

    Private lasttxt As TextBox = Nothing

    Private Sub txtRéparateur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReparateur.KeyPress
        blockNum(e)
    End Sub
    Private Sub txtNature_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNature.KeyPress
        blockNum(e)
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

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, txtNature.KeyDown, txtDesignation.KeyDown,
        txtReparateur.KeyDown, txtReference.KeyDown, Button1.KeyDown, dateDebut.KeyDown, dateFin.KeyDown

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
            If txtNature.Focused Then
                afficherSuggestions("Nature de réparation", "réparations", txtNature, Panel1, ListBox1)
                lasttxt = txtNature
            ElseIf txtReparateur.Focused Then
                afficherSuggestions("Réparateur", "réparations", txtReparateur, Panel1, ListBox1)
                lasttxt = txtReparateur
            ElseIf txtReference.Focused Then
                afficherSuggestions("Référence", "réparations", txtReference, Panel1, ListBox1)
                lasttxt = txtReference
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

    Private Sub reparations_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
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

    Private Sub RéparationsAjout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCode.ReadOnly = True
        Me.KeyPreview = True
        Panel1.Visible = False
        Panel1.BringToFront()


        Try
            Connect()

            Dim autoCompleteNature As New AutoCompleteStringCollection()
            Dim autoCompleteReparateur As New AutoCompleteStringCollection()
            Dim autoCompleteRéférence As New AutoCompleteStringCollection()
            Dim cmdAuto As New SQLiteCommand("SELECT DISTINCT [Nature de réparation], Réparateur, Référence FROM réparations", con)
            Dim readerAuto As SQLiteDataReader = cmdAuto.ExecuteReader()

            While readerAuto.Read()
                If Not IsDBNull(readerAuto("Nature de réparation")) Then
                    autoCompleteNature.Add(readerAuto("Nature de réparation").ToString())
                End If
                If Not IsDBNull(readerAuto("Réparateur")) Then
                    autoCompleteReparateur.Add(readerAuto("Réparateur").ToString())
                End If
                If Not IsDBNull(readerAuto("Référence")) Then
                    autoCompleteRéférence.Add(readerAuto("Référence").ToString())
                End If
            End While
            readerAuto.Close()

            txtNature.AutoCompleteCustomSource = autoCompleteNature
            txtNature.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtNature.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtReparateur.AutoCompleteCustomSource = autoCompleteReparateur
            txtReparateur.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtReparateur.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtReference.AutoCompleteCustomSource = autoCompleteRéférence
            txtReference.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtReference.AutoCompleteSource = AutoCompleteSource.CustomSource

            If edit Then
                ' Load existing camion data for editing
                Dim cmd As New SQLiteCommand("SELECT * FROM réparations WHERE id= @id", con)
                cmd.Parameters.AddWithValue("@id", id)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtCode.Text = reader("Code Camion").ToString()
                    dateDebut.Value = Convert.ToDateTime(reader("Date Debut"))
                    dateFin.Value = Convert.ToDateTime(reader("Date Fin"))
                    txtNature.Text = reader("Nature de réparation").ToString()
                    txtDesignation.Text = reader("Désignation").ToString()
                    txtReparateur.Text = reader("Réparateur").ToString()
                    txtReference.Text = reader("Référence").ToString()
                    Dim imagePath As String = reader("Facture").ToString()
                    If Not String.IsNullOrEmpty(imagePath) AndAlso IO.File.Exists(imagePath) Then
                        picFacture.Image = Image.FromFile(imagePath)
                        picFacture.SizeMode = PictureBoxSizeMode.Zoom
                    Else
                        picFacture.Image = Nothing
                    End If

                End If
                reader.Close()
            Else
                txtCode.Text = code.ToString()
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
            If String.IsNullOrWhiteSpace(txtNature.Text) Then
                nullFocus(txtNature)
                If Not premier Then
                    txtNature.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtNature)
            End If
            If String.IsNullOrWhiteSpace(txtDesignation.Text) Then
                nullFocus(txtDesignation)
                If Not premier Then
                    txtDesignation.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtDesignation)
            End If
            If String.IsNullOrWhiteSpace(txtReparateur.Text) Then
                nullFocus(txtReparateur)
                If Not premier Then
                    txtReparateur.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtReparateur)
            End If
            If String.IsNullOrWhiteSpace(txtReference.Text) Then
                nullFocus(txtReference)
                If Not premier Then
                    txtReference.Focus()
                    premier = True
                End If
            Else
                resetFocus(txtReference)
            End If
            If premier Then
                MessageBox.Show("Veuillez remplir tous les champs", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dateD As Date = Convert.ToDateTime(dateDebut.Value.Date)
            Dim dateF As Date = Convert.ToDateTime(dateFin.Value.Date)
            If dateD > dateF Then
                MessageBox.Show("La date Fin doit être supérieur à celle du Debut", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Connect()

            Dim cmd As SQLiteCommand
            If edit Then
                ' Update existing camion
                cmd = New SQLiteCommand("UPDATE réparations SET [Date Debut]=@dateDebut, [Date Fin]=@dateFin, [Nature de réparation]=@nature,
                                        Désignation=@designation, Réparateur=@reparateur, Référence=@reference, Facture=@facture
                                        WHERE id = @id", con)
                cmd.Parameters.AddWithValue("@id", id)
            Else
                ' Insert new camion
                cmd = New SQLiteCommand("INSERT INTO réparations([Code Camion],[Date Debut], [Date Fin],[Nature de réparation],Désignation,Réparateur,
                                        Référence,Facture) VALUES(@code,@dateDebut,@dateFin,@nature,@designation,@reparateur,@reference,@facture) ", con)
            End If
            cmd.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
            cmd.Parameters.AddWithValue("@dateDebut", dateDebut.Value.Date)
            cmd.Parameters.AddWithValue("@dateFin", dateFin.Value.Date)
            cmd.Parameters.AddWithValue("@nature", txtNature.Text)
            cmd.Parameters.AddWithValue("@designation", txtDesignation.Text)
            cmd.Parameters.AddWithValue("@reparateur", txtReparateur.Text)
            cmd.Parameters.AddWithValue("@reference", txtReference.Text)
            cmd.Parameters.AddWithValue("@facture", picFacture.ImageLocation)
            cmd.ExecuteNonQuery()

            Dim updateStatut As SQLiteCommand = New SQLiteCommand("UPDATE ficheCamion SET Statut = 'En Réparation' WHERE Code = @code AND Statut = 'Disponible'", con)
            updateStatut.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
            updateStatut.ExecuteNonQuery()

            MessageBox.Show("Ligne " & If(edit, "modifiée", "ajoutée") & " avec succès", "Validation",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close() ' Close the form after saving

        Catch ex As Exception
            MessageBox.Show("Erreur de sauvegarde: " & ex.Message, "Erreur",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        openFileDialog.Title = "Sélectionner une image"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            picFacture.ImageLocation = openFileDialog.FileName
            picFacture.Load()
        End If
    End Sub

    Private Sub Annuler_Click(sender As Object, e As EventArgs) Handles Annuler.Click
        Dim result As DialogResult = MessageBox.Show("Voulez-vous annuler l'opération?", "Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class