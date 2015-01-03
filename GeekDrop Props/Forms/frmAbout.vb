Imports System.Windows.Forms

Public Class frmAbout

    ' Single place to change the unique PP Donation code
    Private strPayPal As String = "VTH98Y6WEAFSQ"

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim strAbout As String = String.Format("About {0} v{1}", frmMain.strAppname, Application.ProductVersion)

        Me.Text = strAbout
        lblTitle.Text = strAbout
        llJSE.Text = frmMain.strAppname & " created by J. Scott Elblein"

        Try
            ' Save the RTF file from our Resources to the Temp foler
            IO.File.WriteAllText(String.Format("{0}\{1}.rtf", My.Computer.FileSystem.SpecialDirectories.Temp, frmMain.strAppname), My.Resources.AboutRTF)

            ' Load that saved RTF file into the RichTextBox
            rtbDescription.LoadFile(String.Format("{0}\{1}.rtf", My.Computer.FileSystem.SpecialDirectories.Temp, frmMain.strAppname))
        Catch ex As Exception
            Debug.Print(ex.Message)
            rtbDescription.Text = "Woops! I couldn't seem to load the text into this box. Sorry!"
        End Try

        ' Fill in the "GodWare" Label
        ' This whole "Godware thing is actually more of a tongue-in-cheek joke, pokign fun at organized Religion, for those who don't get it. ;)
        lblGodWare.Text = frmMain.strAppname & " is 'God Ware'." _
            & Environment.NewLine & Environment.NewLine & _
            "What is God Ware?" _
            & Environment.NewLine & Environment.NewLine & _
            "It means GOD WANTS you to donate if you find this app useful." _
            & Environment.NewLine & Environment.NewLine & _
            "You can donate any amount that you feel it's worth to you, God is the only one who will judge whether you donated enough; and of course, if you're not a believer in God, you can just consider this regular donation-ware. :)"

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close_Window(Me)
    End Sub

    Private Sub picDonate_Click(sender As Object, e As EventArgs) Handles picDonate.Click
        DonateWithPaypal(strPayPal)
    End Sub

    Private Sub llJSE_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llJSE.LinkClicked
        ' Launch the GD website
        NavigateToGd()
    End Sub

    Private Sub frmAbout_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ' For the form moving code
        GetMouseOffset(e)
    End Sub

    Private Sub frmAbout_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' For the form moving code. Allows moving the form via dragging the form itself
        Move_Form(e, Me)
    End Sub

End Class