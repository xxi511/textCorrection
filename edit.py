# -*- coding: utf-8 -*-
# import Tkinter as tk
# import ttk
from tkinter import Tk
from tkinter.ttk import Frame, Button, Style


class Example(Frame):
    def __init__(self, parent):
        Frame.__init__(self, parent)

        self.grid()
        self.parent = parent
        self.initUI()
        self.word = ""

    def initUI(self):
        self.parent.title("Editer")
        Style().configure("TFrame")

        self.autobtn = Button(self, text='auto', command=self.autoclick)
        self.autobtn.grid(row=0, column=0)

        self.alignbtn = Button(self, text='alignment', command=self.clickAlignment)
        self.alignbtn.grid(row=0, column=1)

    def paste(self):
        # Paste clipboard word to self.word
        self.word = self.clipboard_get()

    def cut(self):
        # Cut word from edit area to clipboard
        self.clipboard_clear()
        txt = self.word
        self.clipboard_append(txt)

    def alignment(self):
        # Alignment article in edit area
        # follow the rules
        # 1. only one space line between word lines
        # 2. each line start by two space
        text = self.word
        text = text.split('\n')

        modified = []
        for idx, line in enumerate(text):
            line = line.strip()
            if line is not '':
                line = line + '\n\n'
                line = '　　' + line if idx != 0 else line
                modified.append(line)

        str = ''.join(modified)
        self.word = str.rstrip('\n')

    def correct(self):
        # correct text, data from data.txt
        text = self.word
        with open('data.txt', 'r', encoding='utf-8-sig') as f:
            for line in f:
                old, new = line.split()
                if new == '!@#$%':
                    new = ''

                if old in text:
                    text = text.replace(old, new)

        self.word = text

    def autoclick(self):
        self.paste()
        self.alignment()
        self.correct()
        self.cut()

    def clickAlignment(self):
        self.paste()
        self.alignment()
        self.cut()

def main():
    root = Tk()
    root.resizable(0, 0)
    root.geometry("170x25")
    root.attributes("-topmost", True)
    app = Example(root)
    root.mainloop()


if __name__ == '__main__':
    main()