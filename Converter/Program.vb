Imports log4net.Config
Imports log4net
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

' Configure LOG4NET Using configuration file.
<Assembly: log4net.Config.XmlConfigurator(Watch := True)>

Namespace Converter
    Class Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            BasicConfigurator.Configure()

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Class
End Namespace