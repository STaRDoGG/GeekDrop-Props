Imports System.ComponentModel

Public Class frmMain

    Public strAppname As String = "GeekDrop Props"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Text = strAppname

        ' Check for a command-line param(s) to our app
        If My.Application.CommandLineArgs.Count > 0 Then

            ' Enable Timer to monitor the opened Properties sheet(s)
            tmrMonitor.Enabled = True

            For Each argument As String In My.Application.CommandLineArgs
                ' Open the Windows Properties sheet for the item passed as the path.
                ' We don't have to worry here whether it's actually a fully qualified file or path, because the function itself will do that.

                ' Create a new BackgroundWorker to run the request in a separate thread
                Dim bgWorker As BackgroundWorker = New BackgroundWorker

                ' Add the DoWork handler for it
                AddHandler bgWorker.DoWork, AddressOf bgWorker_DoWork

                ' Send the command to start the thread, passing the passed Path as a Parameter
                bgWorker.RunWorkerAsync(argument)
            Next
        Else

            ' Disable Timer so app doesn't close itself while viewing the About screen
            tmrMonitor.Enabled = False

            ' Open the About screen if no Parameters were passed to the .exe
            frmAbout.ShowDialog()
            Close_App()
        End If

    End Sub

    Private Sub OpenProperties(ByVal FileOrFolderPath As String)

        ' Opens the Properties sheet of the passed path
        GeekDropProps.ShowPropertiesMethod1(FileOrFolderPath)

    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)

        ' Calls the function to open the Properties sheet in it's own thread
        OpenProperties(DirectCast(e.Argument, String))

    End Sub

    Private Sub tmrMonitor_Tick(sender As Object, e As EventArgs) Handles tmrMonitor.Tick
        ' Timer checks every half second for any and all Properties sheets that are currently open. Once it finds NO more are open, the app closes itself.

        ' Create a List collection to store the upcoming running Windows list
        Dim SearchList As New List(Of String)

        ' Call the function to fill the above List
        getWindowList(SearchList)

        ' Lambda expression: Search the list looking for a match of the Properties window we launched with this app.
        '                    In our case, all Property Sheet windows are of Class #32770, & they always contain the Program/Folder Name + " Properties",
        '                    so we'll search for any item in the list that matches BOTH. Otherwise we might end up with the wrong window if we only hunt for either one.
        Dim lFound As List(Of String) = SearchList.FindAll(
            Function(FindProcess) FindProcess.Contains("#32770") AndAlso FindProcess.Contains(" Properties"))

        ' Search the List for any and all matches, once there are no more matches (i.e. the user clicked OK/Cancel on the Props sheet), the app exits.
        If lFound.Count = 0 Then
            ' Be a studious coder and stop the timer first. =)
            tmrMonitor.Enabled = False
            ' Exit the app
            Close_App()
        End If

    End Sub

End Class