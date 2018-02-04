Namespace CommonUMS
    Public Class Subject
        Private subjectcode As String = ""
        Private subjectname As String = ""
        Private subjectL As Integer = 0
        Private subjectT As Integer = 0
        Private subjectP As Integer = 0
        Private subjectCr As Integer = 0
        Private subjectLab As Boolean = False

        Property code() As String
            Get
                Return subjectcode
            End Get
            Set(ByVal Value As String)
                subjectcode = Value
            End Set
        End Property

        Property name() As String
            Get
                Return subjectname
            End Get
            Set(ByVal Value As String)
                subjectname = Value
            End Set
        End Property

        Property Lecture() As String
            Get
                Return subjectL
            End Get
            Set(ByVal Value As String)
                subjectL = Value
            End Set
        End Property

        Property Tutorial() As String
            Get
                Return subjectT
            End Get
            Set(ByVal Value As String)
                subjectT = Value
            End Set
        End Property

        Property Practical() As String
            Get
                Return subjectP
            End Get
            Set(ByVal Value As String)
                subjectP = Value
            End Set
        End Property

        Property Credit() As String
            Get
                Return subjectCr
            End Get
            Set(ByVal Value As String)
                subjectCr = Value
            End Set
        End Property

        Property IsLab() As String
            Get
                Return subjectLab
            End Get
            Set(ByVal Value As String)
                subjectLab = Value
            End Set
        End Property
    End Class
End Namespace