# textlCorrection
文字批量替換  

可取代河蟹字，沒分段的可以幫忙分段，每段的前面會變成兩個全型空白

看小說寫的程式，簡轉繁之後還有許多錯字或標點符號要修改  

file裡面有 change.exe 和 data.txt  
change.exe是主程式  
data.txt是資料庫，裡面記錄說那些字(符號)要更改，又需要改成什麼樣子  

**********data.txt說明**********  
比方說  
幹淨 乾淨  
錯的 新的↑  ，中間用空白隔開  

處理的順序從上到下  
拿 里 和 裡來舉例  

如果全部取代後就會變成【敵人在前方五裡處】  

所以在 "里 裡" 之後會需要加一個"五裡 五里"  
校正回來  

想要新增的話直接在data.txt裡面加上去就好  
中間記得用空白隔開  
如果不小心把data.txt弄丟了再從建一個就行  
TXT的編碼是unicode  


![test](https://github.com/xxi511/textCorrection/tree/master/image/after.JPG)
