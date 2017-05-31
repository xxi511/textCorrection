# -*- coding: utf-8 -*-
# import Tkinter as tk
# import ttk
from tkinter import Text, Tk, END
from tkinter.ttk import Frame, Button, Style


class Example(Frame):
    def __init__(self, parent):
        Frame.__init__(self, parent)

        self.grid()
        self.parent = parent
        self.initUI()

    def initUI(self):
        self.parent.title("Editer")
        Style().configure("TFrame")

        self.wordtext = Text(self, height=25, width=71,
                                relief='groove', highlightthickness=0)
        self.wordtext.grid(row=0, column=0, columnspan=4, rowspan=5)

        self.autobtn = Button(self, text='auto', command=self.autoclick)
        self.autobtn.grid(row=5, column=0)

        self.alignbtn = Button(self, text='alignment', command=self.alignment)
        self.alignbtn.grid(row=5, column=3)

    def paste(self):
        # Paste clipboard word to edit area
        txt = self.clipboard_get()
        self.wordtext.insert('0.0', txt)

    def cut(self):
        # Cut word from edit area to clipboard
        self.clipboard_clear()
        txt = self.wordtext.get('1.0', END)
        self.clipboard_append(txt)
        self.wordtext.delete('1.0', END)

    def alignment(self):
        # Alignment article in edit area
        # follow the rules
        # 1. only one space line between word lines
        # 2. each line start by two space
        text = self.wordtext.get('1.0', END)
        text = text.replace(' ', '')  # remove whitespace
        text = text.replace("　", '')  # remove whitespace
        text = text.splitlines()

        spaceline = False  # This line should be space?
        modified = []
        for idx, line in enumerate(text):
            if line == '':
                if spaceline:
                    modified.append('\n')
                    spaceline = False
                else:
                    continue
            else:
                if spaceline:
                    modified.append('\n')
                line = '　　' + line if idx != 0 else line
                modified.append(line)
                spaceline = True

        str = ''.join(modified)
        str = str.replace('\n', '\n\n')
        str = str.rstrip('\n')
        self.wordtext.delete('1.0', END)
        self.wordtext.insert('0.0', str)

    def correct(self):
        # correct text, data from data.txt
        text = self.wordtext.get('1.0', END)
        with open('data.txt', 'r', encoding='utf-8-sig') as f:
            for line in f:
                old, new = line.split()
                if new == '!@#$%':
                    new = ''

                text = text.replace(old, new)

        text = self.bracket_correct(text)
        self.wordtext.delete('1.0', END)
        self.wordtext.insert('0.0', text)

    def autoclick(self):
        self.paste()
        self.alignment()
        self.correct()
        self.cut()

    def bracket_correct(self, str):
        import re
        idx_list = [(m.start(0), m.end(0)) for m in re.finditer("』(.*?)』", str, re.U)]
        tmpstr = list(str)
        for idx in idx_list:
            tmpstr[idx[0]] = "『"
        return ''.join(tmpstr)



def main():
    root = Tk()
    root.resizable(0, 0)
    root.geometry("500x400")
    app = Example(root)
    root.mainloop()


if __name__ == '__main__':
    main()