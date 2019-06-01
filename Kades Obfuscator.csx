///-----------------------------------------------------------------
///						        Kades Obfuscator
///-----------------------------------------------------------------
///   Author:         Kade
///-----------------------------------------------------------------
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Windows.Forms;

// VERSION dont change this shit
string ver = "1.0";

////////////////////////////// ADD THIS TO THE BEGINNING - COLINATOR27 //////////////////////////////
UndertaleModLib.Compiler.Compiler.SetUndertaleData(Data);

// VERSION / NEWS CHECK //

if (!new WebClient().DownloadString("https://raw.githubusercontent.com/KadePcGames/Kades-Obfuscater-UTMT-SCRIPT/UTMT-Files/version").Contains(ver))
{
	MessageBox.Show("Updating!","Kades Obfuscator");
	new WebClient().DownloadFile("https://raw.githubusercontent.com/KadePcGames/Kades-Obfuscater-UTMT-SCRIPT/UTMT-Files/file","script.csx");
	MessageBox.Show("Please run script.csx","Kades Obfuscator");
}
else
{
MessageBox.Show(new WebClient().DownloadString("https://raw.githubusercontent.com/KadePcGames/Kades-Obfuscater-UTMT-SCRIPT/UTMT-Files/news"), "Kades Obfuscator News");
MessageBox.Show("Started obfuscator.","Kades Obfuscator");

MessageBox.Show("Obfuscating OBJECTS","Kades Obfuscator");

// GMS CHECK //

var gms = 0;

foreach (UndertaleGameObject obj in Data.GameObjects)
{
	if (obj.Name.Content == "GMS")
		gms = 1;
}

if (gms == 1)
	MessageBox.Show("GMS Detected! GMS Mode Activated.","Kades Obfuscator");

// GMS CHECK //

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
if (gms != 1)
	obj.Name = Data.Strings.MakeString(result.ToString());
else
	obj.Name.Content = result.ToString();
obj.EventHandlerFor(EventType.Create, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(@"
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
bab = 512512512;
var a = 025126512;
a+=25215125;", null ), Data));
obj.EventHandlerFor(EventType.Draw, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(@"
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
bab = 512512512;
", null ), Data));
obj.EventHandlerFor(EventType.Step, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(@"
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
bab = 512512512;
", null ), Data));
}


MessageBox.Show("Obfuscating SPRITE NAMES","Kades Obfuscator");
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

if (gms != 1)
	obj.Name = Data.Strings.MakeString(result.ToString());
else
	obj.Name.Content = result.ToString();
}


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

if (gms != 1)
	obj.Name = Data.Strings.MakeString(result.ToString());
else
	obj.Name.Content = result.ToString();
}

MessageBox.Show("Obfuscating SCRIPT NAMES","Kades Obfuscator");
foreach (UndertaleScript obj in Data.Scripts)
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

if (gms == 1)
	obj.Name = Data.Strings.MakeString(result.ToString());
else
	obj.Name.Content = result.ToString();
}
MessageBox.Show("Adding junk...","Kades Obfuscator");

int i = 0;

while(i != 500)
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
    //ParentId = UNUSED,
    //TextureMaskId = UNUSED,
    UsesPhysics = true,
    IsSensor = true,
    //CollisionShape = UNUSED,
    Density = (float)0.5,
    Restitution = (float)0.1,
    Group = 0,
    LinearDamping = (float)0.1,
    AngularDamping = (float)0.1,
    Friction = (float)0.2,
    Awake = true,
    Kinematic = true,
};
junk.EventHandlerFor(EventType.Create, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(@"
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
bab = 512512512;
var a = 025126512;
a+=25215125;", null ), Data));
junk.EventHandlerFor(EventType.Draw, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(@"
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
bab = 512512512;
", null ), Data));
junk.EventHandlerFor(EventType.Step, (uint)0, Data.Strings, Data.Code, Data.CodeLocals).Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(@"
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
bab = 512512512;
", null ), Data));
Data.GameObjects.Add(junk);
}
MessageBox.Show("Obfuscated.","Kades Obfuscator");

UndertaleModLib.Compiler.Compiler.SetUndertaleData(Data);
}