///-----------------------------------------------------------------
///						        Kades Obfuscator
///-----------------------------------------------------------------
///   Author:         Kade
///-----------------------------------------------------------------
////////////////////////////// IMPORTS //////////////////////////////
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using System.Linq;

// VERSION dont change this shit
string ver = "1.2";

////////////////////////////// ADD THIS TO THE BEGINNING - COLINATOR27 //////////////////////////////
UndertaleModLib.Compiler.Compiler.SetUndertaleData(Data);

// VERSION / NEWS CHECK //

if (!new WebClient().DownloadString("https://raw.githubusercontent.com/KadePcGames/Kades-Obfuscater-UTMT-SCRIPT/UTMT-Files/version").Contains(ver))
{
	MessageBox.Show("Updating!","Kades Obfuscator");
	new WebClient().DownloadFile("https://raw.githubusercontent.com/KadePcGames/Kades-Obfuscater-UTMT-SCRIPT/UTMT-Files/file","script.csx");
	MessageBox.Show("Please run script.csx in the folder were this data.win is located!","Kades Obfuscator");
}
else
{
    // Get News //
string news = new WebClient().DownloadString("https://raw.githubusercontent.com/KadePcGames/Kades-Obfuscater-UTMT-SCRIPT/UTMT-Files/news");
    // Make the form //
            Form f = new Form();
            f.Text = "Kades Obfuscator Script UI";
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Size = new System.Drawing.Size(250, 150);
            f.TopMost = true;
            System.Windows.Forms.RichTextBox NewsBox = new System.Windows.Forms.RichTextBox();
            System.Windows.Forms.Button Obfuscate = new System.Windows.Forms.Button();
            System.Windows.Forms.TextBox Junk = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Label JunkText = new System.Windows.Forms.Label();
            Obfuscate.Text = "Obfuscate!";
            Obfuscate.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                f.Close();
            });
            JunkText.Text = "The ammount of junk:";
            Obfuscate.FlatStyle = FlatStyle.Flat;
            f.Controls.Add(NewsBox);
            f.Controls.Add(JunkText);
            f.Controls.Add(Obfuscate);
            f.Controls.Add(Junk);
            NewsBox.Text = news;
            NewsBox.ReadOnly = true;
            NewsBox.Size = new System.Drawing.Size(250, 50);
            Junk.Size = new System.Drawing.Size(145, 50);
            Junk.Text = "500";
            JunkText.Size = new System.Drawing.Size(200, 20);
            JunkText.Location = new System.Drawing.Point(55, 55);
            Junk.Location = new System.Drawing.Point(45, 75);
            Obfuscate.Location = new System.Drawing.Point(75, 100);
            f.ShowDialog();
            int ammountOfJunk = int.Parse(Junk.Text);
MessageBox.Show("Started obfuscator.","Kades Obfuscator");
// GMS CHECK //

var gms = 0;

foreach (UndertaleGameObject obj in Data.GameObjects)
{
	if (obj.Name.Content == "GMS")
		gms = 1;
}

if (gms == 1)
	MessageBox.Show("GMS Detected!\nJust note that GMS is a little weird, the obfuscation can stop it from working.\nKeep that in mind while using it!","Kades Obfuscator");

// GMS CHECK //

MessageBox.Show("Obfuscating SPRITE NAMES","Kades Obfuscator");
////////////////////////////// SPRITE-OBFUSCATOR //////////////////////////////
foreach (UndertaleSprite obj in Data.Sprites)
{
    char[] chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
    byte[] data = new byte[40];
    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
    {
        crypto.GetBytes(data);
    }
    StringBuilder result = new StringBuilder(40);
    foreach (byte b in data)
    {
                result.Append(chars[b % (chars.Length)]);
    }
    obj.Name.Content = result.ToString();
}
////////////////////////////// ROOM-OBFUSCATOR //////////////////////////////
MessageBox.Show("Obfuscating ROOM NAMES","Kades Obfuscator");
foreach (UndertaleRoom obj in Data.Rooms)
{
    char[] chars =
       "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
    byte[] data = new byte[40];
    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
    {
        crypto.GetBytes(data);
    }
    StringBuilder result = new StringBuilder(40);
    foreach (byte b in data)
    {
        result.Append(chars[b % (chars.Length)]);
    }
    obj.Name.Content = result.ToString();
}
////////////////////////////// OBJECT-OBFUSCATOR //////////////////////////////
MessageBox.Show("Obfuscating OBJECTS","Kades Obfuscator");

foreach (UndertaleGameObject obj in Data.GameObjects)
{
    char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[40];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(40);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            Random rnd = new Random();
	    obj.Name.Content = result.ToString();
    string code = "";
switch(rnd.Next(1,5))
{
    case 1:
        code = @"
        var a = 025126512;
        a+=25215125;
        var b = 2512512;
        var c = 259192895912512
        var bab = 295901259012950129501295
        if a = 2512512
        {
            a++
        }
        bab++
        c++
        if (bab == c)
        {
            c = 25125;
        }
        bab = 512512512;";
    break;
    case 2:
        code = @"
        var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
        ";
    break;
    case 3:
        code = @"
        var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            
        ";
        break;
        case 4:
            code = @"
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
        case 5:
        // Alot of them 
                        code = @"
                                var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
                                var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
}
obj.EventHandlerFor(EventType.Create, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(code, null ), Data));
switch(rnd.Next(1,5))
{
    case 1:
        code = @"
        var a = 025126512;
        a+=25215125;
        var b = 2512512;
        var c = 259192895912512
        var bab = 295901259012950129501295
        if a = 2512512
        {
            a++
        }
        bab++
        c++
        if (bab == c)
        {
            c = 25125;
        }
        bab = 512512512;";
    break;
    case 2:
        code = @"
        var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
        ";
    break;
    case 3:
        code = @"
        var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            
        ";
        break;
        case 4:
            code = @"
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
        case 5:
        // Alot of them 
                        code = @"
                                var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
                                var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
}
obj.EventHandlerFor(EventType.Draw, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(code, null ), Data));
switch(rnd.Next(1,5))
{
    case 1:
        code = @"
        var a = 025126512;
        a+=25215125;
        var b = 2512512;
        var c = 259192895912512
        var bab = 295901259012950129501295
        if a = 2512512
        {
            a++
        }
        bab++
        c++
        if (bab == c)
        {
            c = 25125;
        }
        bab = 512512512;";
    break;
    case 2:
        code = @"
        var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
        ";
    break;
    case 3:
        code = @"
        var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            
        ";
        break;
        case 4:
            code = @"
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
        case 5:
        // Alot of them 
                        code = @"
                                var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
                                var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
}
obj.EventHandlerFor(EventType.Step, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(code, null ), Data));
}
////////////////////////////// JUNKER //////////////////////////////
MessageBox.Show("Adding JUNK...","Kades Obfuscator");
int i = 0;

while(i != ammountOfJunk)
{
    char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
    byte[] data = new byte[40];
    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
    {
        crypto.GetBytes(data);
    }
    StringBuilder result = new StringBuilder(40);
    foreach (byte b in data)
    {
        result.Append(chars[b % (chars.Length)]);
    }
	i++;
	var junk = new UndertaleGameObject()
    {
    Name = Data.Strings.MakeString(result.ToString()),
    Visible = true,
    Solid = true,
    Depth = 0,
    Persistent = true,
    UsesPhysics = true,
    IsSensor = true,
    Density = (float)0.5,
    Restitution = (float)0.1,
    Group = 0,
    LinearDamping = (float)0.1,
    AngularDamping = (float)0.1,
    Friction = (float)0.2,
    Awake = true,
    Kinematic = true,
    };
    Data.GameObjects.Add(junk);
    string codeJ = "";
    Random rnd = new Random();
    switch(rnd.Next(1,5))
{
    case 1:
        codeJ = @"
        var a = 025126512;
        a+=25215125;
        var b = 2512512;
        var c = 259192895912512
        var bab = 295901259012950129501295
        if a = 2512512
        {
            a++
        }
        bab++
        c++
        if (bab == c)
        {
            c = 25125;
        }
        bab = 512512512;";
    break;
    case 2:
        codeJ = @"
        var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
        ";
    break;
    case 3:
        codeJ = @"
        var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            
        ";
        break;
        case 4:
            codeJ = @"
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
        case 5:
        // Alot of them 
                        codeJ = @"
                                var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
                                var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
}
junk.EventHandlerFor(EventType.Create, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(codeJ, null ), Data));
    switch(rnd.Next(1,5))
{
    case 1:
        codeJ = @"
        var a = 025126512;
        a+=25215125;
        var b = 2512512;
        var c = 259192895912512
        var bab = 295901259012950129501295
        if a = 2512512
        {
            a++
        }
        bab++
        c++
        if (bab == c)
        {
            c = 25125;
        }
        bab = 512512512;";
    break;
    case 2:
        codeJ = @"
        var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
        ";
    break;
    case 3:
        codeJ = @"
        var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            
        ";
        break;
        case 4:
            codeJ = @"
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
        case 5:
        // Alot of them 
                        codeJ = @"
                                var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
                                var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
}
junk.EventHandlerFor(EventType.Draw, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(codeJ, null ), Data));
    switch(rnd.Next(1,5))
{
    case 1:
        codeJ = @"
        var a = 025126512;
        a+=25215125;
        var b = 2512512;
        var c = 259192895912512
        var bab = 295901259012950129501295
        if a = 2512512
        {
            a++
        }
        bab++
        c++
        if (bab == c)
        {
            c = 25125;
        }
        bab = 512512512;";
    break;
    case 2:
        codeJ = @"
        var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
        ";
    break;
    case 3:
        codeJ = @"
        var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            
        ";
        break;
        case 4:
            codeJ = @"
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
        case 5:
        // Alot of them 
                        codeJ = @"
                                var aa = 25129568129;
        var bba = 259120512;
        var ar;
        i = 0;
        ar[i] = 2512512;
        if (ar[0] = 2512512)
        {
            bba++;
        }
        aa++;
        bab = 512512512;
        if (bab == ar[0] || aa == ar[0])
        {
            ar[0] = bab + aa;
        }
                                var array = 0
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
        array[4]++;
        array[5]++;
        array[6]++;
        array[7]++;
        array[8]++;
        array[9]++;
        array[10]++;
        if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                switch (arrag[10)
                                                {
                                                    case 1:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 2:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                    case 3:
                                                       if (array[1] == 10)
            if (array[2] == 421)
                if (array[3] == 5215)
                    if (array[4] == 521512)
                        if (array[5] == 52)
                            if (array[6] == 521512)
                                if (array[7] == -512512)
                                    if (array[8] == 2512512)
                                        if (array[9] == 20)
                                            if (array[10] == 25125)
                                                    break;
                                                }
            var superStistion = 0;
            superStistion++;
            superStistion--;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;
            if (superStistion > 0 && superStistion == 0 && superStistion < 0 )
                superStistion = 900000;
            if (superStistion = 900000)
                superStistion = 0;  
            ";
        break;
}
junk.EventHandlerFor(EventType.Step, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(codeJ, null ), Data));
}
MessageBox.Show("Obfuscated.","Kades Obfuscator");
////////////////////////////// Compile shit again :) //////////////////////////////
UndertaleModLib.Compiler.Compiler.SetUndertaleData(Data);
}
