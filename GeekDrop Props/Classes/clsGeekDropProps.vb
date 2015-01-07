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

End Class