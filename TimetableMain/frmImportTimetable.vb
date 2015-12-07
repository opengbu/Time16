Imports System.Xml

Public Class frmImportTimetable

    Private Sub ReadXMLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReadXMLToolStripMenuItem.Click
        Dim filepath As String = "C:\Users\Amit K Awasthi\fet-results\timetables\unnamed-single\teachers.xml"
        Dim xmldoc As New XmlDocument
        Dim str As String = ""
        xmldoc.Load(filepath)
        Dim objTeachers As XmlNode = xmldoc.SelectSingleNode("//Teachers_Timetable")
        Dim objDays As XmlNode
        Dim objHours As XmlNode ' = xmldoc.SelectSingleNode("//Day")
        Dim ts As New Timesheet
        Dim dd, pp As Integer
        dd = 0
        pp = 0
        ts.ImportStart()
        'Try
        For Each Z As XmlNode In objTeachers.ChildNodes
            objDays = Z
            dd = 0
            pp = 0
            For Each Y As XmlNode In objDays.ChildNodes
                objHours = Y
                dd += 1
                pp = 0
                For Each X As XmlNode In objHours.ChildNodes
                    pp += 1
                    'str += X.ParentNode.ParentNode.Attributes(0).Value & "," & X.ParentNode.Attributes(0).Value & "," & X.Attributes(0).Value
                    str += X.ParentNode.ParentNode.Attributes(0).Value & "," & dd & "," & pp
                    If (X.HasChildNodes) Then
                        If X.ChildNodes.Count = 4 Then
                            str += "," & X.ChildNodes(0).Attributes(0).Value & "," & X.ChildNodes(1).Attributes(0).Value & "," & X.ChildNodes(2).Attributes(0).Value & "," & X.ChildNodes(3).Attributes(0).Value
                        Else
                            str += "," & X.ChildNodes(0).Attributes(0).Value & "," & X.ChildNodes(1).Attributes(0).Value & "," & X.ChildNodes(2).Attributes(0).Value & ",VL-204"
                        End If
                        ts.ImportFET(str)
                        'ListBox1.Items.Add(str)
                        'Else
                        '   str += ",,,"
                    End If
                    str = ""
                Next
            Next
        Next
        'Catch ex As Exception

        '        End Try
        If Val(tsectionid.Text) <> 0 Then
            ts.ImportFinal(Val(tsectionid.Text))
        Else
            ts.ImportFinal()

        End If

    End Sub
    'Function IsNodeExist(tagname) As Boolean
    '    Dim num_nodes As Integer = 0
    '    Dim node_name As String = tagname
    '    'XMLNode [] 
    '    Dim nodes As XmlNode = GetNodesWithTagName(node_name)
    '    num_nodes = nodes.Length
    'End Function
End Class