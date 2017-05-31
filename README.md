python 3.x
pyinstaller目前只支援python 3.5

# Ubuntu, windows
`pyinstaller -F -n Editer -w GUI.py`

# Mac
Install py2app.   
`$ pip install -U py2app`

Create setup.py.   
`$ py2applet --make-setup GUI.py`

Edit setup.py to add icon.   
`OPTIONS = {'iconfile': ‘edit.icns'}`

Build.   
`$ python setup.py py2app`