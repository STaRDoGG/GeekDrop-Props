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

        ' Store the previous Properties sheet(s) hwnd(s), so we don't end up moving it/them more than once per timer tick
        Static strRunning As New List(Of String)

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
        ElseIf lFound.Count = 1 Then

            ' If only 1 Properties Sheet, no sense in moving it; just store it's hwnd

            ' Get the latest Last time in the list
            Dim strWindow() As String = Split(lFound.Last, ",")

            ' ... then store it's hwnd
            strRunning.Add(Trim(strWindow(1)))
        Else

            ' More than 1 Properties sheet found in the lFound list, so we loop through them all, moving each to different spot on the screen
            For intLoop As Integer = 0 To lFound.Count - 1

                ' Split the string into an array for easier handling
                Dim strWindow() As String = Split(lFound(intLoop), ",")

                ' Trim the hwnd string once ...
                Dim strHWND As String = Trim(strWindow(1))

                If intLoop = 0 Then
                    ' If it's the very first one, don't move it, just add it's hwnd to the list
                    strRunning.Add(strHWND)
                Else

                    ' Otherwise, if it's the second one in the list, or up, move them ...

                    ' Scan the List of hwnd's we've added to see if this particular one is already in it, if not, proceed, otherwise, skip it.
                    If strRunning.Contains(strHWND) = False Then

                        ' Store this new hwnd in the List
                        strRunning.Add(strHWND)

                        ' Generate a Random number
                        Dim myRandom As New Random()

                        ' Move the new Properties sheet to another location on the screen, so they don't all overlap each other,
                        ' making them harder to see without first having to manually move them
                        GeekDropProps.MoveWindow( _
                            CType(strHWND, IntPtr), _
                            myRandom.Next(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width), _
                            myRandom.Next(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height), _
                            Convert.ToInt32(strWindow(4).Replace("R: ", "")) - Convert.ToInt32(strWindow(6).Replace("L: ", "")), _
                            Convert.ToInt32(strWindow(5).Replace("B: ", "")) - Convert.ToInt32(strWindow(3).Replace("T: ", "")), _
                            True)

                        ' We need to hold our proverbial horses a sec here, to give the Sheets time to place themselves,
                        ' otherwise they 'll still end up on top of each other ...
                        Threading.Thread.Sleep(100)
                    End If

                End If

            Next intLoop

        End If

    End Sub

End Class