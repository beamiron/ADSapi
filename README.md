ADSapi <br />

Usage:<br />
<b>ADSWriter(String_Data,File_Location,Stream_Name) <br />
ADSReader(FIle_Location,Stream_Name) </b>
<br />

Example:<br />
<b>ADSWriter("Hello","C:\\Debug.txt","hide") </b> Writes 'hello' to the alternate data stream in the file Debug.txt <br />
<b>ADSReader("C:\\Debug.txt","hide") </b> Attempts to read the data in the data stream 'hide' from the file Debug.txt
