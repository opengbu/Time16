Public Class SessionData

    Private _ID1 As Integer
    Private _ID2 As Integer
    Private _Value As String

    Public Sub New(ByVal id1 As Integer, ByVal id2 As Integer, ByVal Value As String)
        _ID1 = id1
        _ID2 = id2
        _Value = Value
    End Sub
    Public ReadOnly Property Get_Id1() As Integer
        Get
            Return _ID1
        End Get
    End Property
    Public ReadOnly Property Get_Id2() As Integer
        Get
            Return _ID2
        End Get
    End Property
    Public ReadOnly Property Get_Value() As String
        Get
            Return _Value
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return _Value
    End Function
End Class