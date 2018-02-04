Module vars
    Public _currentSession As Integer
    Public _currentSection As Integer
    Public _currentcsf As Integer
    Public _currentfacids As String
    Public _Session As Integer
    Public _SessionName As String
    'Public _school As String



    Public Enum Semester
        Odd = 0
        Even = 1
    End Enum

    Public _currentSemester As Semester = _Session Mod 2
    Public constr As String = My.Settings.eCollegeConnectionString1
    Public cn As SqlClient.SqlConnection = New SqlClient.SqlConnection(My.Settings.eCollegeConnectionString1)



End Module
