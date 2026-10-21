Imports System.Data.SQLite

Module Connexion

    Public con As New SQLiteConnection("Data Source=ProjetAtlantic.db;Version=3;")

    Public Sub Connect()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
                Console.WriteLine("Connexion réussite")
            End If
        Catch ex As SQLiteException
            Console.WriteLine("Erreur de connexion: " & ex.Message)
        End Try
    End Sub

    Public Sub Disconnect()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
                Console.WriteLine("Connexion fermée")
            End If
        Catch ex As SQLiteException
            Console.WriteLine("Erreur lors de la déconnexion: " & ex.Message)
        End Try
    End Sub


End Module
