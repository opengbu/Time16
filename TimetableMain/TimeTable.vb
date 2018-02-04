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
        Version = "2018.1.0"
    End Function

    Public Function Session() As Integer
        Dim _Session As Integer = 0
        Dim sql As String =
         "Select Id From Session Where CurrentActive=1"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
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

        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
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

    Public Function GetLabDefaultRoom(labid) As Integer
        Dim _labroom As Integer = 0
        Dim sql As String = "SELECT Room_Id FROM Lab_Room where Subject_Id=" & labid
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                _labroom = Convert.ToInt32(cmd.ExecuteScalar())
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return _labroom
    End Function
    Public Function Room(id) As String
        Dim _labroom = ""
        Dim sql As String = "SELECT Name FROM M_Room where Room_Id=" & id
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                _labroom = Convert.ToString(cmd.ExecuteScalar())
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return _labroom
    End Function

    Public Function getSubjectId(subjectCode As String) As Integer
        Dim _sid As Integer = 0
        Dim sql As String = "SELECT id FROM Subject where TRIM(code)='" & subjectCode.Trim & "'"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                _sid = Convert.ToInt32(cmd.ExecuteScalar())
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return _sid
    End Function

    Public Function Schools() As DataSet
        Dim ds As New DataSet
        Dim sql As String = "SELECT Name, FullName FROM School order by Name"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)

            Try
                'conn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return ds
    End Function



    Public Function SectionsByProgramId(ProgramId As Integer) As DataSet
        Dim ds As New DataSet
        Dim sql As String = "SELECT Id,Name FROM Section Where Program=" & ProgramId & " and ShowTimeTable=1 order by Name"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Try
                'conn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return ds
    End Function
    Public Function Programs() As DataSet
        Dim ds As New DataSet
        Dim sql As String = "SELECT id,Code,Name,school FROM Program order by Name"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Try
                'conn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return ds
    End Function

    Public Function ProgramsBySchool(SchoolCode As String) As DataSet
        Dim ds As New DataSet
        Dim sql As String = "SELECT id,Code,Name FROM Program Where school='" & SchoolCode & "' order by Name"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Try
                'conn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return ds
    End Function

    Public Function TTCellAll() As DataSet
        Dim ds As New DataSet
        Dim sql As String = "SELECT ContGroupCode,Section_Id, TT_Day,TT_Period,CSF_Id,Room_Id, Batch_Id,ActivityTag FROM M_Time_Table"
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Try
                'conn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return ds
    End Function


    Public Function TTCellBySectionId(id) As DataSet
        Dim ds As New DataSet
        Dim sql As String = "SELECT ContGroupCode, TT_Day,TT_Period,CSF_Id,Room_Id, Batch_Id,ActivityTag FROM M_Time_Table Where Section_Id=" & id
        Using conn As New SqlConnection(My.Settings.eCollegeConnectionString1)
            Try
                'conn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return ds
    End Function
End Class


