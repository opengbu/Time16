Public Class HTMLString
    Private tsb(7, 9) As Integer
    Private tsd(7, 9) As Integer
    Private tsd1(7, 9) As Integer
    Private ts1(7, 9) As String
    Private ts2(7, 9) As String
    Private RowHasBacth As Boolean = False
    Private err As Integer

    Public Property BatchTemplate As Integer(,)
        Get
            BatchTemplate = tsb
        End Get
        Set(value As Integer(,))
            tsb = value
        End Set
    End Property

    Public Property GetData As String(,)
        Get
            GetData = ts1
        End Get
        Set(value As String(,))
            ts1 = value
        End Set
    End Property
    Public Property GetData2 As String(,)
        Get
            GetData2 = ts2
        End Get
        Set(value As String(,))
            ts2 = value
        End Set
    End Property

    Public Property DurationTableG1 As Integer(,)
        Get
            DurationTableG1 = tsd
        End Get
        Set(value As Integer(,))
            tsd = value
        End Set
    End Property

    Public Property DurationTableG2 As Integer(,)
        Get
            DurationTableG2 = tsd1
        End Get
        Set(value As Integer(,))
            tsd1 = value
        End Set
    End Property

    Public Function DrawHTML() As String
        Dim stable As String = ""
        Try
            Dim str As String = ""
            Dim str2 As String = ""
            'chekk full row - Is there batch>0 if yes then rowspan take place

            For j = 0 To 6


                str = ""
                str2 = ""
                For i = 0 To 8
                    If err > 0 Then
                        'DrawHTML = "Error"
                        'Exit Function
                    End If
                    GetRowBatch(j, tsb)
                    If RowHasBacth Then

                        If Not(tsb(j, i) <> 0) Then
                            If tsd(j, i) > 0 Then str += "<td rowspan='2' colspan='" & tsd(j, i) & "'>" + ts1(j, i).ToString + "</td>"
                        Else
                            If tsd(j, i) > 0 Then str += "<td colspan='" & tsd(j, i) & "'>" + ts1(j, i).ToString + "</td>"
                            If tsd1(j, i) > 0 Then str2 += "<td colspan='" & tsd1(j, i) & "'>" + ts2(j, i).ToString + "</td>"
                        End If
                    Else
                        If tsd(j, i) > 0 Then str += "<td colspan='" & tsd(j, i) & "'>" + ts1(j, i).ToString + "</td>"

                    End If
                Next
                If str2.Length > 0 Then
                    stable += "<tr>" + str + "</tr>" + "<tr>" + str2 + "</tr>"
                Else
                    stable += "<tr>" + str + "</tr>"
                End If
            Next

        Catch ex As Exception
            'MsgBox(ex.Message)
            err = 1
        End Try
        DrawHTML = "<table>" + stable + "</table>"
    End Function
    Private Sub GetRowBatch(j As Integer, tsb As Object)
        Try
            Dim n As Integer = 0
            For k = 0 To 8
                If Not (tsb(j, k) Is Nothing) Then
                    n += tsb(j, k)
                End If
            Next
            If n > 0 Then
                RowHasBacth = True
            Else
                RowHasBacth = False
            End If
        Catch ex As Exception
            ' MsgBox("Rows" & ex.Message)
            err = 1
        End Try

    End Sub


End Class

