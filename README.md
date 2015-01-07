**A simple command-line utility to open the standard Windows Properties sheet by passing the file/folder/drive path to it.**


**Tip:** If you want to skip reading all of this mumbo-jumbo, and just download the app right now, you can grab the compiled versions right here: https://github.com/STaRDoGG/GeekDrop-Props/releases




## Like GeekDrop Props and wanna donate? ##

Why, thank ya kindly! You can do just that via Paypal! http://geekdrop.com/x/props-donations




## What in bejesus this? ##

It's just a small app designed to be run from the command-line, passing the full Windows path to any file, folder or drive, and then it'll load up the standard Windows "Properties Sheet" that normally shows you all of the details.

The reason for its existence is because I've noticed that sometimes when you right-click on a file/folder/drive the normal "Properties" menu item doesn't show up. So I wanted to create a way to call the same exact Properties window from any 3rd Party utility that I wanted, (i.e. FileMenuTools) and it would *always* show up no matter what.

That's my personal main reason for it, however, like many apps, once it's created you may find all sorts of other uses for it that I may not have even intended or imagined while birthing it.

Interesting thing of note: while researching the making of this, it turns out something you'd *think* would be so simple to whip up, actually wasn't as easy as one would assume. It would seem to me at least, that there'd be an already built-in command-line to do this, but there's not. There's a keyboard shortcut (Alt + Enter), but even attempting to just send the keystrokes via something like a quick VBScript turned out to be a hassle. There are a handful of other awkward methods as well, but this turned out to be the most reliable, to do such a "simple" thing.




## Installation? (We dun need no steenking installation!) ##

This is a VERY easy app to use, and is designed to be 100% portable so that you can just move a single file wherever you want it; any folder, no setup program needed, it can be copied to a USB stick, whatever ya want. To use it just follow the steps below.


**Requirement:**
* .NET Framework 4.5+ (usually already installed in Windows if updated)


**1.)** Simply place **GDProps.exe** anywhere on your computer or external USB drive that you want to run it from, then call it via a command-line, passing the full path of the file/folder/drive that you want to see the properties of:

    i.e.: GDProps C:\Windows\Notepad.exe


You can pass as many paths as you like, to load up as many as you want at a time. Just add a space between each one.


    i.e. GDProps C:\Windows\Notepad.exe "D:\Some Folder\Some File.xml" "E:\Some Other Folder\Some Other Sub Folder\Some File.dat" "D:"

    Note: if there are spaces in the path, wrap the entire path in double quotes, i.e. "C:\Some File.txt"
          (Pro Tip: Just do that anyway out of habit, spaces in path or not, it’s good for ya.)


When using it with a 3rd party utility, the utility usually offers some way to pass the selected path as a variable, in which cause you'd just do something similar to this:


    GDProps.exe %P

    Where %P is the variable the utility offers. Of course it may not literally be "%P", but that’s the idea.



  **a)** This app has no dependencies other than the .NET Framework, which is included on most Windows installations by default these days, so it should be completely portable (USB Stick, any folder, etc.)

  **b)** The app will automatically validate that whatever you passed to it as a path is indeed a path, and indeed does exist on the computer before doing anything else, if it fails validation, visibly nothing happens, and the app will just close itself. If you passed multiple paths, then only the valid paths will open a Properties sheet.

  **c)** If you pass *nothing* to it as a path, it'll just load up the "About" screen, with this information, plus the usual "About Screen" type of blather. Same thing happens if you just double-click the app's .exe. But you have to admit, it's purty, right?


**2.)** Th-th-th-That’s all Folks!

Like I said, *very* simple.




## Uninstallation ##

To uninstall it, just delete GDProps.exe and it’s gone. It installs absolutely nothing whatsoever, leaves no unwanted turds behind, nada.




## Roadmap and Todo's ##

* None planned as of right now. If you have any ideas, be sure to post them.




## Screenshots ##


**This is what we're talking about here ...**

![This is what we're talking about here ...](https://github.com/STaRDoGG/GeekDrop-Props/blob/master/GeekDrop%20Props/Images/Screenshots/GeekDrop-Props-Screenshot1.jpg)



**The 'About' screen. Pretty, ain't it?**

![The 'About' screen. Pretty, ain't it?](https://github.com/STaRDoGG/GeekDrop-Props/blob/master/GeekDrop%20Props/Images/Screenshots/GeekDrop-Props-Screenshot2.png)




## Other Links ##

The "home page" of GeekDrop Props, is right here, don't be a stranger!: http://geekdrop.com/x/props




## Changelog ##

* Version 1.1
	* In Versions 1.0 when opening more than 1 Properties Sheet, they would open directly on top of each other, which got a bit confusing, so now when more than 1 is opened they'll all open in different areas of the screen.

* Version 1.0
	* First release. Hello World!