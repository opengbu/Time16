Imports System.Data.SqlClient

<ComClass(TimeTable.ClassId, TimeTable.InterfaceId, TimeTable.EventsId)>
Public Class TimeTable

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "5a24bc05-fcdf-4514-a0f6-f97b7fccc0c7"
    Public Const InterfaceId As String = "52c3727a-b1a2-433f-bf6e-ce88b3fc35f8"
    Public Const EventsId As String = "8bafa438-7a8c-44a1-9e08-f39e28d18ce1"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    Public Function Version() As String
        Version = "2017.7.0"
    End Function

    Public Function Session() As Integer
        Dim _Session As Integer = 0
        Dim sql As String =
         "Select Id From Session Where CurrentActive=1"

        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                _Session = Convert.ToInt32(cmd.ExecuteScalar())
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using

        Return _Session

    End Function

    Public Function SessionName() As String
        Dim _SessionName As String = ""
        Dim sql As String =
         "Select Title From Session Where CurrentActive=1"

        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                _SessionName = Convert.ToString(cmd.ExecuteScalar())
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return _SessionName

    End Function

End Class


