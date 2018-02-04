Imports System.Diagnostics

Public Class pyth
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim proc As Process = New Process
        'proc.StartInfo.FileName = ""C:\Program Files (x86)\Wing IDE 101 5.1\bin\runtime-python2.7\python.exe"" 'Default Python Installation
        'proc.StartInfo.Arguments = "D:\Timetables2014\update.py"
        'proc.StartInfo.UseShellExecute = False 'required for redirect.
        'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        'proc.StartInfo.CreateNoWindow = True
        'proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        'proc.Start()
        ''AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived
        'proc.BeginOutputReadLine()
        'proc.WaitForExit()
        ' Shell("python D:\Timetables2014\update.py")
        'Dim pythonProcess As New Process()
        'With pythonProcess
        '    .StartInfo.FileName = "python.exe"
        '    .StartInfo.Arguments = "D:\\Timetables2014\\update.py"
        '    .Start()
        '    .WaitForExit()
        'End With
        ' My.Computer.Network.UploadFile("C:\data\logo.png", "http://www.mysite.com.au/upload.php")
        'MsgBox("l")
        Dim filePath As String = "D:\Timetables2014\update.py"
        Dim psi As New ProcessStartInfo("python.exe")
        psi.WorkingDirectory = IO.Path.GetDirectoryName(filePath)
        Process.Start("python.exe", "update.py")
        MsgBox(11)

    End Sub
End Class