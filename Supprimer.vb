Imports System.Data.SQLite

Module Supprimer

    Public Sub delete(table As String, code As String, val As Object, count As Integer)
        Try
            Connect()
            Dim sql As String = "DELETE FROM " & table & " WHERE " & code & " = @id"
            Dim cmd As New SQLiteCommand(sql, con)
            cmd.Parameters.AddWithValue("@id", val)

            If cmd.ExecuteNonQuery() > 0 Then
                If table = "fichecamion" Then
                    MessageBox.Show("Camion " & val & " supprimé avec succès", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf table <> "fichecamion" And count = 0 Then
                    MessageBox.Show("Ligne supprimée avec succès", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Aucun camion trouvé avec cet ID", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression du camion: " & ex.Message, "Erreur",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
