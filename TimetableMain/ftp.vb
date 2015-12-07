Imports System
Imports System.IO
Imports System.Net
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Class ftp
    Private host As String = vbNull
    Private user As String = vbNull
    Private pass As String = vbNull
    Private ftpRequest As FtpWebRequest
    Private ftpRequest1 As FtpWebRequest
    Private ftpResponse As FtpWebResponse
    Private ftpStream As Stream
    Private ftphash As String
    Private bufferSize As Integer = 2048


    Sub New(hostIP As String, userName As String, password As String)
        ' TODO: Complete member initialization 
        host = hostIP
        user = userName
        pass = password
    End Sub
    Public Sub ftp(hostIP As String, userName As String, password As String)
        host = hostIP
        user = userName
        pass = password
    End Sub

    Public Sub upload(remoteFile As String, localFile As String, Optional unique As Boolean = False)
        'Create an FTP Request
        ftpRequest = FtpWebRequest.Create(host + "/" + remoteFile)
        'Log in to the FTP Server with the User Name and Password Provided 
        ftpRequest.Credentials = New NetworkCredential(user, pass)
        'When in doubt, use these options 
        ftpRequest.UseBinary = True
        ftpRequest.UsePassive = True
        ftpRequest.KeepAlive = True
        '  Specify the Type of FTP Request 
        ftpRequest.Method = WebRequestMethods.Ftp.UploadFile
        '  Establish Return Communication with the FTP Server 
        ftpStream = ftpRequest.GetRequestStream()
        '    Open a File Stream to Read the File for Upload 
        Dim localFileStream As FileStream = New FileStream(localFile, FileMode.Open)
        '    Buffer for the Downloaded Data 
        Dim byteBuffer(bufferSize) As Byte
        Dim bytesSent As Integer = localFileStream.Read(byteBuffer, 0, bufferSize)
        'MsgBox("File updated: " + Str(bytesSent) + "sent.")
        '  Upload the File by Sending the Buffered Data Until the Transfer is Complete */
        Try
            While Not (bytesSent = 0)
                ftpStream.Write(byteBuffer, 0, bytesSent)
                bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize)
            End While

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        localFileStream.Close()
        ftpStream.Close()
        ftpRequest = Nothing
    End Sub

    Sub CopyFileRev(remoteFile As String)
        'Create an FTP Request
        ftpRequest = FtpWebRequest.Create(host + "/" + remoteFile)
        ftpRequest1 = FtpWebRequest.Create(host + "/rev/" + remoteFile)
        'Log in to the FTP Server with the User Name and Password Provided 
        ftpRequest.Credentials = New NetworkCredential(user, pass)
        ftpRequest1.Credentials = New NetworkCredential(user, pass)
        'When in doubt, use these options 
        ftpRequest.UseBinary = True
        ftpRequest.UsePassive = True
        ftpRequest.KeepAlive = True

        ftpRequest1.UseBinary = True
        ftpRequest1.UsePassive = True
        ftpRequest1.KeepAlive = True
        '  Specify the Type of FTP Request 
        ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
        ftpRequest1.Method = WebRequestMethods.Ftp.UploadFileWithUniqueName

        '  Establish Return Communication with the FTP Server 
        ftpResponse = ftpRequest.GetResponse()
        Dim localFileStream As FileStream = ftpResponse.GetResponseStream()
        ftpStream = ftpRequest1.GetRequestStream()
        'Dim localFileStream As FileStream = New FileStream(localFile, FileMode.Open)
        ' Buffer for the Downloaded Data 
        Dim byteBuffer(bufferSize) As Byte
        Dim bytesSent As Integer = localFileStream.Read(byteBuffer, 0, bufferSize)

        Try
            While Not (bytesSent = 0)
                ftpStream.Write(byteBuffer, 0, bytesSent)
                'bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize)
            End While

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try


        localFileStream.Close()
        ftpStream.Close()
        ftpRequest = Nothing
        ftpRequest1 = Nothing
    End Sub

    ' VB.NET version
    Sub MyGetHash(remoteFile As String, localFile As String)
        'Create an FTP Request
        ftpRequest = FtpWebRequest.Create(host + "/" + remoteFile)
        'Log in to the FTP Server with the User Name and Password Provided 
        ftpRequest.Credentials = New NetworkCredential(user, pass)
        'When in doubt, use these options 
        ftpRequest.UseBinary = True
        ftpRequest.UsePassive = True
        ftpRequest.KeepAlive = True
        '  Specify the Type of FTP Request 
        ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
        '  Establish Return Communication with the FTP Server 
        ftpResponse = ftpRequest.GetResponse()
        ftpStream = ftpResponse.GetResponseStream()
        'ftphash = ftpStream.GetHashCode()
        ''    Open a File Stream to Read the File for Upload 
        'MsgBox(ftphash)

        Dim localFileStream As FileStream = New FileStream(localFile, FileMode.Open)
        '    Buffer for the Downloaded Data 
        Dim byteBuffer(bufferSize) As Byte
        Dim bytesReadRemote As Integer = ftpStream.Read(byteBuffer, 0, bufferSize)

        Dim bytesReadLocal As Integer = localFileStream.Read(byteBuffer, 0, bufferSize)
        MsgBox(bytesReadRemote & " *** " & bytesReadLocal)

        'localFileStream.Close()
        ftpStream.Close()
        ftpRequest = Nothing
    End Sub

    Sub download(remoteFile As String, localFile As String)
        'Create an FTP Request
        ftpRequest = FtpWebRequest.Create(host + "/" + remoteFile)
        'Log in to the FTP Server with the User Name and Password Provided 
        ftpRequest.Credentials = New NetworkCredential(user, pass)
        'When in doubt, use these options 
        ftpRequest.UseBinary = True
        ftpRequest.UsePassive = True
        ftpRequest.KeepAlive = True
        '  Specify the Type of FTP Request 
        ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
        '  Establish Return Communication with the FTP Server 
        ftpResponse = ftpRequest.GetResponse()
        ftpStream = ftpResponse.GetResponseStream()
        Dim localFileStream As FileStream = New FileStream(localFile, FileMode.Create)
        '    Buffer for the Downloaded Data 
        Dim byteBuffer(bufferSize) As Byte
        Dim bytesReadRemote As Integer = ftpStream.Read(byteBuffer, 0, bufferSize)
        'Dim bytesSent As Integer = localFileStream.Read(byteBuffer, 0, bufferSize)

        Try
            While Not (bytesReadRemote = 0)
                localFileStream.Write(byteBuffer, 0, bytesReadRemote)
                bytesReadRemote = ftpStream.Read(byteBuffer, 0, bufferSize)
            End While

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try


        localFileStream.Close()
        ftpStream.Close()
        ftpRequest = Nothing
    End Sub
End Class

