Imports System.Data.SQLite

Module ChargerTables

    Public Sub chargerTable(data As DataGridView, table As String, code As Integer, bs As BindingSource)
        Try
            Connect()

            Dim dateOrder As String = "[Date Remplissage Gasoil]"
            If table = "parcours" Then
                dateOrder = "[Date Départ]"
            ElseIf table = "réparations" Then
                dateOrder = "[Date Fin]"
            End If
            Dim sql As String = "SELECT * FROM " & table & " WHERE [Code Camion]=@code ORDER BY " & dateOrder & " DESC , id DESC"
            Dim cmd As New SQLiteCommand(sql, con)
            cmd.Parameters.AddWithValue("@code", code) ' Assuming FicheCamion.id is the selected camion ID
            Dim da As New SQLiteDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            bs.DataSource = dt
            data.DataSource = bs

            If data.Columns.Contains("id") Then
                data.Columns("id").Visible = False ' Hide the ID column
            End If
            For Each col As DataGridViewColumn In data.Columns
                If col.ValueType Is GetType(Integer) OrElse
                    col.ValueType Is GetType(Double) OrElse
                    col.ValueType Is GetType(Decimal) Then

                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Erreur de connexion: " & ex.Message, "Erreur",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Module
