Native Input Field for Unity WebGL
=================================

Description
===========

This package implements native input field for Unity WebGL.

Unity's built-in InputField class is not support IME.

But using this package,you can get IME support.

* Some characters (ex.Japanese) are depends on IME.Many users can't input that characters.

Disclaimer
==========

This is an unsupported package provided by Unity Technologies for demonstration purposes.

Manual
======

Replace UnityEngine.UI.InputField to WebGLNativeInputField.

About WebGLNativeInputField's properties.

- Dialog Type
  There are two methods to open input dialog.

  Native popup dialog() & creating overlap html dynamically("Overlay Html").

  We recommend "Overlay Html" mode.

- Dialog Title
  You can set dialog title text.

- Dialog Ok Btn
  You can set "OK" button text.This support only "Overlay Html" mode.

- Dialog Cancel Btn
  You can set "Cancel" button text.This support only "Overlay Html" mode.


Note
=====

mplus font taken form mplus-fonts.osdn.jp