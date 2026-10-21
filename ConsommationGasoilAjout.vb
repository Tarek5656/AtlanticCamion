Imports System.Data.SQLite

Public Class ConsommationGasoilAjout

    Public Property edit As Boolean = False
    Public Property id As Integer = 0
    Public Property code As Integer = 0

    Private Sub txtKmDebut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKmDebut.KeyPress
        blockNoNum(txtKmDebut, e)
    End Sub
    Private Sub txtKmFin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKmFin.KeyPress
        blockNoNum(txtKmFin, e)
    End Sub
    Private Sub txtQtGasoil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtGasoil.KeyPress
        blockNoNum(txtQtGasoil, e)
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
    Private Sub txtQtGasoil_GotFocus(sender As Object, e As EventArgs) Handles txtQtGasoil.GotFocus
        gottFocus(txtQtGasoil)
    End Sub
    Private Sub txtQtGasoil_lostFocus(sender As Object, e As EventArgs) Handles txtQtGasoil.LostFocus
        losttFocus(txtQtGasoil)
    End Sub

    Private Sub nextKey(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown, txtKmDebut.KeyDown, txtKmFin.KeyDown,
        txtQtGasoil.KeyDown, dateRemplissage.KeyDown

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

    Private Sub ConsommationGasoilAjout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCode.ReadOnly = True
        Me.KeyPreview = True


        Try
            Connect()

            If edit Then
                Dim cmd As New SQLiteCommand("SELECT * FROM consommationGasoil WHERE id= @id", con)
                cmd.Parameters.AddWithValue("@id", id)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtCode.Text = reader("Code Camion").ToString()
                    dateRemplissage.Value = Convert.ToDateTime(reader("Date Remplissage Gasoil"))
                    txtKmDebut.Text = reader("Km Debut").ToString()
                    txtKmFin.Text = reader("Km Fin").ToString()
                    txtQtGasoil.Text = reader("Quantite Gasoil").ToString()
                End If
                reader.Close()
            Else
                txtCode.Text = code.ToString()
                Dim km As New SQLiteCommand("SELECT MAX([Km Fin]) FROM consommationGasoil WHERE [Code Camion] = @code", con)
                km.Parameters.AddWithValue("@code", code)
                Dim resultat = km.ExecuteScalar()
                If resultat IsNot DBNull.Value AndAlso resultat IsNot Nothing Then
                    Dim kmDebut As Decimal = resultat
                    txtKmDebut.Text = kmDebut.ToString()
                    txtKmDebut.ReadOnly = True
                End If
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
            If String.IsNullOrWhiteSpace(txtKmDebut.Text) Then
                nullFocus(txtKmDebut)
                If Not premier Then
                    premier = True
                    txtKmDebut.Focus()
                End If
            Else
                resetFocus(txtKmDebut)
            End If
            If String.IsNullOrWhiteSpace(txtKmFin.Text) Then
                nullFocus(txtKmFin)
                If Not premier Then
                    premier = True
                    txtKmFin.Focus()
                End If
            Else
                resetFocus(txtKmFin)
            End If
            If String.IsNullOrWhiteSpace(txtQtGasoil.Text) Then
                nullFocus(txtQtGasoil)
                If Not premier Then
                    premier = True
                    txtQtGasoil.Focus()
                End If
            Else
                resetFocus(txtQtGasoil)
            End If
            If premier Then
                MessageBox.Show("Veuillez remplir tous les champs", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim kmDebut As Decimal = Convert.ToDecimal(txtKmDebut.Text)
            Dim kmFin As Decimal = Convert.ToDecimal(txtKmFin.Text)
            Dim qtGasoil As Decimal = Convert.ToDecimal(txtQtGasoil.Text)
            If kmFin <= kmDebut Then
                MessageBox.Show("Le kilométrage de fin ne peut pas être inférieur au kilométrage de début", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If kmDebut < 0 Then
                MessageBox.Show("Le kilométrage doit être positif", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If qtGasoil <= 0 Then
                MessageBox.Show("La quantité de gasoil doit être supérieure à 0", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Connect()

            Dim cmd As SQLiteCommand
            If edit Then
                ' Update existing camion
                cmd = New SQLiteCommand("UPDATE consommationGasoil SET [Date Remplissage Gasoil]=@dateRemplissage, [Km Debut]=@kmDebut, 
                                        [Km Fin]=@kmFin, [Km Parcourus]=@kmParcourus, [Quantite Gasoil]=@qtGasoil, [Taux de consommation]=@taux WHERE id = @id", con)
                cmd.Parameters.AddWithValue("@id", id)
            Else
                ' Insert new camion
                cmd = New SQLiteCommand("INSERT INTO consommationGasoil([Code Camion],[Date Remplissage Gasoil], [Km Debut], [Km Fin], [Km Parcourus], [Quantite Gasoil], [Taux de consommation])
                                        VALUES (@code, @dateRemplissage, @kmDebut, @kmFin, @kmParcourus, @qtGasoil, @taux)", con)
            End If
            cmd.Parameters.AddWithValue("@code", Convert.ToInt16(txtCode.Text))
            cmd.Parameters.AddWithValue("@dateRemplissage", dateRemplissage.Value.Date)
            cmd.Parameters.AddWithValue("@kmDebut", Convert.ToDecimal(txtKmDebut.Text))
            cmd.Parameters.AddWithValue("@kmFin", Convert.ToDecimal(txtKmFin.Text))
            cmd.Parameters.AddWithValue("@kmParcourus", Convert.ToDecimal(txtKmFin.Text) - Convert.ToDecimal(txtKmDebut.Text))
            cmd.Parameters.AddWithValue("@qtGasoil", Convert.ToDecimal(txtQtGasoil.Text))
            cmd.Parameters.AddWithValue("@taux", Math.Round((Convert.ToDecimal(txtQtGasoil.Text) / (Convert.ToDecimal(txtKmFin.Text) - Convert.ToDecimal(txtKmDebut.Text))), 2))
            cmd.ExecuteNonQuery()
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
End Class