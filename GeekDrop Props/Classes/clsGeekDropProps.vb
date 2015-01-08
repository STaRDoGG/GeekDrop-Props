'
' GeekDrop Props v1.0 - J. Scott Elblein | GeekDrop.com
'
' A small class to show the standard Windows Properties sheet. To use, simply call the function with the full path of the file or folder to show the Properties sheet of.
'
' Usage:
' GeekDropProps.ShowPropertiesMethod1("C:\SomeFile.txt")
' GeekDropProps.ShowPropertiesMethod2("C:\SomeFolder")
'
' Note: Functions first check that the passed File/Folder actually exists, to prevent an error if not; returns False if the File/Folder doesn't exist.
'

Imports System.Runtime.InteropServices

Public Class GeekDropProps

#Region "Declarations"

    Public Declare Auto Function MoveWindow Lib "user32.dll" ( _
        ByVal hWnd As IntPtr, _
        ByVal X As Int32, _
        ByVal Y As Int32, _
        ByVal nWidth As Int32, _
        ByVal nHeight As Int32, _
        ByVal bRepaint As Boolean _
    ) As Boolean

#End Region

#Region "Method 1"
    ' Uses ShellExecuteEx and Shellexecuteinfo

    Private Const SW_SHOW As Integer = 5
    Private Const SEE_MASK_INVOKEIDLIST As UInteger = 12
    Private Const SEE_MASK_NOCLOSEPROCESS As UInteger = 64

    <DllImport("shell32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function ShellExecuteEx(ByRef lpExecInfo As SHELLEXECUTEINFO) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure SHELLEXECUTEINFO
        Public cbSize As Integer
        Public fMask As UInteger
        Public hwnd As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public lpVerb As String
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public lpFile As String
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public lpParameters As String
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public lpDirectory As String
        Public nShow As Integer
        Public hInstApp As IntPtr
        Public lpIDList As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public lpClass As String
        Public hkeyClass As IntPtr
        Public dwHotKey As UInteger
        Public hIcon As IntPtr
        Public hProcess As IntPtr
    End Structure

#End Region

#Region "Method 2"
    ' Uses SHObjectProperties

    ' Comment/Uncomment as needed
    ' Private Const SHOP_PRINTERNAME As UInteger = 1 ' lpObject points to a printer friendly name
    Private Const SHOP_FILEPATH As UInteger = 2 ' lpObject points to a fully qualified path+file name
    ' Private Const SHOP_VOLUMEGUID As UInteger = 4 ' lpObject points to a Volume GUID

    Private Declare Function SHObjectProperties Lib "shell32.dll" _
    (ByVal hwnd As UInt32, ByVal shopObjectType As UInt32, _
    <MarshalAs(UnmanagedType.LPWStr)> ByVal pszObjectName As String, _
    <MarshalAs(UnmanagedType.LPWStr)> ByVal pszPropertyPage As String) As Boolean

#End Region

    Public Shared Function ShowPropertiesMethod1(ByVal FileOrFolder As String) As Boolean

        If My.Computer.FileSystem.FileExists(FileOrFolder) = True OrElse My.Computer.FileSystem.DirectoryExists(FileOrFolder) = True Then

            Dim info As New SHELLEXECUTEINFO()

            With info
                .cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info)
                .lpVerb = "properties"
                .lpFile = FileOrFolder
                .nShow = SW_SHOW
                .fMask = SEE_MASK_INVOKEIDLIST + SEE_MASK_NOCLOSEPROCESS
            End With

            Return ShellExecuteEx(info)

        End If

        ' Return False if file doesn't exist
        Return False

    End Function

    Public Shared Function ShowPropertiesMethod2(ByVal FileOrFolder As String, Optional ByVal Page As String = "") As Boolean

        If My.Computer.FileSystem.FileExists(FileOrFolder) = True OrElse My.Computer.FileSystem.DirectoryExists(FileOrFolder) = True Then

            If Page = String.Empty Then
                Page = "0"
            End If

            Return SHObjectProperties(0, SHOP_FILEPATH, FileOrFolder, Page)

        End If

        ' Return False if file doesn't exist
        Return False

    End Function

    Public Shared Function GenerateScreenCoords(ByVal WindowWidthRight As Integer, ByVal WindowWidthLeft As Integer, ByVal WindowHeightBottom As Integer, ByVal WindowHeightTop As Integer) As Integer()
        ' This function generates screen X, Y coordinates that will keep a target Window within the user's visible viewing area, so that the entire window will always be shown,
        ' and never cut off.
        '
        ' The parameters are the dimensions of the target window to be shown on the user's screen. (GetWindowRect is a good API for getting these)
        '
        ' Usage example:
        '
        ' Dim intXY() As Integer = GeekDropProps.GenerateScreenCoords(1234, 1234, 1234, 1234)
        '
        ' Returns:
        ' Integer array. Element 0 = Width (X), Element 1 = Height (Y)
        '
        ' Note: Since this function takes KNOWN dimensions of the target window, use care when dealing with non-fixed sized target windows.
        '       i.e. Using this to calculate the coords of a fixed size Windows Properties sheet, no problem; using it on a resizable Notepad window, untested so far.

        ' Create an integer array of 2 elements
        Dim intCalculated(1) As Integer

        ' Generate a Random number
        Dim myRandom As New Random()

        ' These two vars take the dimensions of the target window to be displayed on the screen
        Dim intWindowWidth As Integer = WindowWidthRight - WindowWidthLeft
        Dim intWindowHeight As Integer = WindowHeightBottom - WindowHeightTop

        ' These 2 vars get the user's display resolution, then subtract the dimensions of the window to be displayed,
        ' effectively making the "display area" smaller, so that the random number generator doesn't generate a number that won't allow the target
        ' window to fit on the screen completely.
        Dim intScreenWidth As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - intWindowWidth
        Dim intScreenHeight As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - intWindowHeight

        ' Finally, generate the random numbers, using the above dimensions
        intCalculated(0) = myRandom.Next(intScreenWidth)
        intCalculated(1) = myRandom.Next(intScreenHeight)

        ' Return them in an integer array
        Return intCalculated

    End Function

End Class