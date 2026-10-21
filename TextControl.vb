Imports System.Data.SQLite

Module TextControl

    Public Sub blockNum(e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsLetter(e.KeyChar) AndAlso
           Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True ' Block non-letter characters
        End If
    End Sub

    Public Sub blockNoNum(txt As TextBox, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar <> "." AndAlso
           e.KeyChar <> "," Then
            e.Handled = True ' Block non-digit characters
        End If
        If (e.KeyChar = "." OrElse e.KeyChar = ",") AndAlso
           (txt.Text.Contains(".") OrElse txt.Text.Contains(",")) Then
            e.Handled = True ' Block multiple decimal points
        End If
    End Sub

    Public Sub gottFocus(txt As TextBox)
        txt.BackColor = Color.Blue
        txt.ForeColor = Color.White
    End Sub

    Public Sub losttFocus(txt As TextBox)
        txt.BackColor = SystemColors.Window
        txt.ForeColor = SystemColors.WindowText
        If txt.Text.Trim() = "" Then
            txt.Clear()
        End If
    End Sub

    Public Sub nullFocus(txt As TextBox)
        txt.BackColor = Color.Red
        txt.ForeColor = Color.White
    End Sub
    Public Sub resetFocus(txt As TextBox)
        txt.BackColor = SystemColors.Window
        txt.ForeColor = SystemColors.WindowText
    End Sub

    Public Sub afficherSuggestions(col As String, table As String, txt As TextBox, panel As Panel, list As ListBox)
        Try
            Connect()
            Dim valeurs As New List(Of String)
            Dim sql As String = "SELECT DISTINCT [" & col & "] FROM [" & table & "]"
            Dim cmd As New SQLiteCommand(sql, con)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            While reader.Read()
                valeurs.Add(reader(col).ToString)
            End While
            reader.Close()

            list.Items.Clear()
            list.Items.AddRange(valeurs.ToArray())

            panel.Left = txt.Left
            panel.Top = txt.Bottom + 5
            panel.Width = txt.Width
            panel.Visible = True
            panel.Focus()
            list.Focus()

            If list.Items.Count > 0 Then
                list.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur de connexion: " & ex.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

End Module
