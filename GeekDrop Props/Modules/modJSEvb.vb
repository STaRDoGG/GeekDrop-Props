Module modJSEvb

    Public Sub NavigateToGd()
        ' Navigate to a GeekDrop
        Process.Start("http://geekdrop.com")
    End Sub

    Public Sub NavigateToJSEAbout()
        ' Navigate to a my About.me page
        Process.Start("http://about.me/scott.elblein")
    End Sub

    Public Sub DonateWithPaypal(strButtonID As String)
        ' Navigate to a Paypal Donate page
        '
        ' Requires the hosted Button ID that you get after creating a button on the PP site

        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=" & strButtonID)
    End Sub

End Module
