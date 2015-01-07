#Region "Description"

' A Module to Enumerate all Windows.
'
' When called, scans and stores all running windows to a List. You can then look through it, picking and choosing at your will.
'
' Usage:
'
' Just Call it, passing a List as a Required parameter, and (optional) and Error Message.
'
' Dim SearchList As New List(Of String)
'
' getWindowList(SearchList)
'
' Returns each window as it's: ClassName, Hwnd, Window Title, Top, Right, Bottom, Left (Screen coordinates)
'
' Example returned item: #32770, 1510814, QSnipps Properties, T: 1234, R: 4321, B: 123, L: 321
'
' Example of how to handle the returned list:
'
' Dim lFound As List(Of String) = SearchList.FindAll(Function(FindProcess) FindProcess.Contains("#32770") AndAlso FindProcess.Contains(" Properties"))
'
' Above example will create another List and find all matches that contain both the ClassName "#32770" and the Title "Properties", adding only the matches to the new List,
' of which you can use .count, or whatever on the results.

#End Region

Imports System.Text

Module modEnumWindows

#Region "Declarations"

    Private ReadOnly lWindowList As New List(Of String)
    Private errMessage As String = String.Empty

    Public Delegate Function MyDelegateCallBack(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean
    Declare Function EnumWindows Lib "user32" (ByVal x As MyDelegateCallBack, ByVal y As Integer) As Integer

    Declare Auto Function GetClassName Lib "user32" _
        (ByVal hWnd As IntPtr, _
        ByVal lpClassName As System.Text.StringBuilder, _
        ByVal nMaxCount As Integer) As Integer

    Declare Auto Function GetWindowText Lib "user32" _
       (ByVal hWnd As IntPtr, _
       ByVal lpClassName As System.Text.StringBuilder, _
       ByVal nMaxCount As Integer) As Integer

    Private Declare Function GetWindowRect Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Long

    Friend Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

#End Region

    Private Function EnumWindowProc(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean

        ' Working vars
        Dim sTitle As New StringBuilder(255)
        Dim sClass As New StringBuilder(255)
        Dim Rect As New RECT()

        Try

            ' Fetch the ClassName of the window
            Call GetClassName(hwnd, sClass, 255)
            ' Fetch the Title of the window (if one)
            Call GetWindowText(hwnd, sTitle, 255)
            ' Fetch the Coordinates/Size of the new Window
            Call GetWindowRect(hwnd, Rect)

            ' Set a default if no Window Title was found
            If sTitle.Length = 0 Then sTitle.Append("No Title")

            ' Add it all to the List
            lWindowList.Add(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", sClass, hwnd, sTitle, "T: " & Rect.top, "R: " & Rect.right, "B: " & Rect.bottom, "L: " & Rect.left))

        Catch ex As Exception
            errMessage = ex.Message
            EnumWindowProc = False
            Exit Function
        End Try

        EnumWindowProc = True

    End Function

    Public Function getWindowList(ByRef wList As List(Of String), Optional errorMessage As String = "") As Boolean
        ' This is the function to call. See Description for details.

        ' Start fresh each time
        lWindowList.Clear()

        Try
            Dim del As MyDelegateCallBack = New MyDelegateCallBack(AddressOf EnumWindowProc)
            EnumWindows(del, 0)
            getWindowList = True
        Catch ex As Exception
            getWindowList = False
            errorMessage = errMessage
            Exit Function
        End Try

        ' Again, start fresh (with the passed List)
        wList.Clear()

        ' Transfer the fresh List over to the passed one
        wList = lWindowList

    End Function

End Module
