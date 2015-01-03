Imports System.Drawing
Imports System.Windows.Forms

Module modBorderlessForm

    ' This module allows moving forms when you hide the form's borders.
    '
    ' It's probably best to call these Subs in a Pic object, such as a logo on your form(s), then your user can click and drag that logo pic to move the form around as if it were the titlebar.

    Public mouseOffset As Point

    Public Sub GetMouseOffset(mouse As MouseEventArgs)
        ' Required to work.
        ' Example Usage:
        '
        ' In _MouseDown event, add GetMouseOffset(e)

        ' Get and store the mouse X,Y coordinates in the global var
        mouseOffset = New Point(-mouse.X, -mouse.Y)

    End Sub

    Public Sub Move_Form(mouse As MouseEventArgs, form_name As Form)
        ' Required to work.
        ' Example Usage:
        '
        ' In _MouseMove event, add Move_Form(e, Me)

        If mouse.Button = MouseButtons.Left Then

            Dim mousePos As Point = Control.MousePosition

            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            form_name.Location = mousePos

        End If

    End Sub

    Public Sub Close_App()
        ' Provides a central sub to call to exit the application.
        '
        ' Call it when clicking an "X" type of image on the form (of the main form, otherwise in other forms, like an "About" form you probably want to use Close_Window() below)

        Application.Exit()
    End Sub

    Public Sub Close_Window(form_name As Form)
        ' Provides a central sub to call to close a form/window.
        '
        ' Call it when clicking an "X" type of image on a form that you want to close, but NOT exit the entire application.
        '
        ' Example Usage: Close_Window(me)

        form_name.Close()
    End Sub

End Module
