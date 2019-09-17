///-----------------------------------------------------------------
///     K A D E S  O B F U S C A T O R  2 . 0
///-----------------------------------------------------------------
///   Author:  Kade
///-----------------------------------------------------------------
#region Imports
using System.Windows.Forms;
using System.Collections.Generic;
using UndertaleModLib;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System; 
#endregion

EnsureDataLoaded();

bool encryption = ScriptQuestion("----- String encryption -----\nWhile string encrpytion is a lot better then most of the protections, it takes awhile on GIANT games.\nOr really any big game, with over 100+ objects.\nAgain waiting for it to finish is worth the wait time.\n\nDo you still want to use it?");

string log = "[KO V2 loaded]\n";
Dictionary<string, string> functions = new Dictionary<string, string>();

#region Methods

List<string> dataStrings = new List<string>();

// Rename Method
int renamerCount = 0;

string GML_UNDEFINED = "&lt;undefined&gt;";

enum LogType
{
    Log,
    Warn,
    Error
}

void Log(string text, LogType lg)
{
    log += "[" + lg.ToString() + "] " + text + "\n";
}

string Renamer()
{
    renamerCount++;
    Random rnd = new Random();
    return @"KOu" + renamerCount + rnd.Next(100,1000);
}

string RenamerNumber()
{
    renamerCount++;
    return @"0" + renamerCount + "2" + renamerCount + "25";
}

string currentDialog = "";
int maxCount = 0;
int saveProgress = 0;
string titl = "";

void SetupProgress(string name, int totalCount, string title = "") {
	currentDialog = name;
	maxCount = totalCount;
	saveProgress = 0;
    titl = title;
	UpdateProgressBar(title, currentDialog, saveProgress, maxCount);
}

void updateProgress()
{
    try
    {
    if (saveProgress < maxCount)
		UpdateProgressBar(titl, currentDialog, saveProgress++, maxCount);
    }
    catch (Exception e)
    {
        Log("Failed to update progress bar, "  + e.ToString(), LogType.Error);
    }
}

// MessageBox Method because F U N K

void Message(string text)
{
    MessageBox.Show(text,"---- Kades Obfuscator 2.0 ----");
}

UndertaleCodeLocals FindLocal(string localName)
{
    UndertaleCodeLocals local = null;
    foreach (UndertaleCodeLocals lcl in Data.CodeLocals)
    {
        if (lcl.Name.Content == localName)
            local = lcl;
    }
    return local;
}

string getRandomJunk()
{
    switch (new Random().Next(1,10))
    {
        case 1:
            return $@"
            aaaa = 20291;
aaa = " + '"' + @"for (int i = 0; i < argument0; i++){switch(case) { case1: return break; case2: return; case3 return case; case4 return case2; } " + '"' + @"
cappap = 2552151212 * 0 - 0 + 99999002 * 00000;
cappapp = 0;
cappappp = 9241;
switch (cappap){ case 0: break; case 1: game_end() break; case 2: return cappa-p break; }
if (x < 0 && hspeed < 0) x = room_width;
if (cappapp > room_width && hspeed > 0) x = -sprite_width;
if (cappappp < 0 && vspeed < 0) y = room_height;
if (cappappp > room_height && vspeed > 0) y = cappa-pp - room_height;
var x1, y1, x2, y2, seen;
x1 = lengthdir_x(1, image_angle);
y1 = lengthdir_y(1, image_angle);
x2 = 251- x;
y2 = 52151 - y;
if dot_product(x1, y1, x2, y2) > 0 seen=true else seen=false;
if dot_product_normalised(x1, y1, x2, y2) > 0 seen=true else seen=false;
x1 = 0;
y1 = 1;
z1 = 0;
x2 = 5421- x;
y2 = 11 - y;
z2 = 521 - z; if dot_product_3d(x1, y1, z1, x2, y2, z2) > 0 above=true else above=false;
var pd = point_direction(x, y, mouse_x, mouse_y);
var dd = angle_difference(image_angle, pd);

";
        break;
        default:
            return "";
        break;
    }
}


// No decrpytion method, im not doin work for you >:)

string Encrypt(string text)
{
    string newText = "";
    for (int i = 0; i < text.Length; i++)
    {
        switch (text[i].ToString())
        {
            case "a":
                newText += "p";
            break;
            case "b":
                newText += "a";
            break;
            case "c":
                newText += "o";
            break;
            case "d":
                newText += "l";
            break;
            case "e":
                newText += "c";
            break;
            case "f":
                newText += "k";
            break;
            case "g":
                newText += "h";
            break;
            case "i":
                newText += "q";
            break;
            case "j":
                newText += "s";
            break;
            case "k":
                newText += "j";
            break;
            case "l":
                newText += "f";
            break;
            case "m":
                newText += "n";
            break;
            case "n":
                newText += "v";
            break;
            case "o":
                newText += "z";
            break;
            case "p":
                newText += "x";
            break;
            case "q":
                newText += "r";
            break;
            case "r":
                newText += "1";
            break;
            case "s":
                newText += "5";
            break;
            case "t":
                newText += "3";
            break;
            case "u":
                newText += "2";
            break;
            case "v":
                newText += "9";
            break;
            case "x":
                newText += "4";
            break;
            case "z":
                newText += "8";
            break;
            case "y":
                newText += "7";
            break;
            case "1":
                newText += "2";
            break;
            case "5":
                newText += "6";
            break;
            case "3":
                newText += "0";
            break;
            case "2":
                newText += ".";
            break;
            case "9":
                newText += "/";
            break;
            case "4":
                newText += "`";
            break;
            case "7":
                newText += ";";
            break;
            default:
                newText += text[i];
                break;
        }
    }
    return newText;
}

bool CheckScripts(string Name, UndertaleScript currentScript)
{
    foreach (UndertaleScript scr in Data.Scripts)
    {
        if (scr != currentScript)
        {
            string code = UndertaleModLib.Decompiler.Decompiler.Decompile(scr.Code, new UndertaleModLib.Decompiler.DecompileContext(Data,true));
            if (code.Contains(Name))
                return true;
            if (scr.Name.Content == Name)
                return true;
        }
    }
    return false;
}

bool CheckObjects(string Name, UndertaleGameObject currentObject)
{
    foreach (UndertaleGameObject obj in Data.GameObjects)
    {
        if (obj != currentObject)
        {
            for (var i = 0; i < obj.Events.Count; i++)
            {
                var eventType = (int) (UndertaleModLib.Models.EventType) i;
                foreach (var evt in obj.Events[i])
                {
                    foreach(UndertaleGameObject.EventAction evA in evt.Actions)
                    {
                        string code = UndertaleModLib.Decompiler.Decompiler.Decompile(evA.CodeId, new UndertaleModLib.Decompiler.DecompileContext(Data,true));
                        if (code.Contains(Name))
                            return true;
                    }
                }
            }
            if (obj.Name.Content == Name)
                return true;
        }
    }
    return false;
}

bool FunctionContains(string Name)
{
    foreach (UndertaleFunction func in Data.Functions)
    {
        if (func.Name.Content == Name)
            return true;
    }
    return false;
}

bool VariablesContains(string Name)
{
    foreach (UndertaleVariable var in Data.Variables)
    {
        if (var.Name.Content == Name)
            return true;
    }
    return false;
}

string encryptName = "";

void AddEncrypt()
{
    try
    {
    string nameA = "";
    UndertaleCode code;
    UndertaleCodeLocals codeLocals;
    UndertaleScript script;
    nameA = Renamer();
    string var = Renamer();
    // Locals from what i herd are debug info? So just keep em lol.
    codeLocals = new UndertaleCodeLocals(){Name = Data.Strings.MakeString("gml_Script_" + nameA),};
    Data.CodeLocals.Add(codeLocals);
    // Add the code because its a tab for som reason.
    code = new UndertaleCode()
    {
        Name = Data.Strings.MakeString("gml_Script_" + nameA),
    };
    // The actuall script code lol...
    script = new UndertaleScript()
    {
        Name = Data.Strings.MakeString(nameA),
        Code = code,
    };
    script.Code.Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText($@"
    var {var} = " + '"' + '"' + $@";
for(i=1;i<string_length(argument0)+1;i++)
" + '{' + $@"
  var {var}1 = string_char_at(argument0, i);
        switch ({var}1)
        " + '{' + $@"
            case 'p':
                {var} += 'a';
            break;
            case 'a':
                {var} += 'b';
            break;
            case 'o':
                {var} += 'c';
            break;
            case 'l':
                {var} += 'd';
            break;
            case 'c':
                {var} += 'e';
            break;
            case 'k':
                {var} += 'f';
            break;
            case 'h':
                {var} += 'g';
            break;
            case 'q':
                {var} += 'i';
            break;
            case 's':
                {var} += 'j';
            break;
            case 'j':
                {var} += 'k';
            break;
            case 'f':
                {var} += 'l';
            break;
            case 'n':
                {var} += 'm';
            break;
            case 'v':
                {var} += 'n';
            break;
            case 'z':
                {var} += 'o';
            break;
            case 'x':
                {var} += 'p';
            break;
            case 'r':
                {var} += 'q';
            break;
            case '1':
                {var} += 'r';
            break;
            case '5':
                {var} += 's';
            break;
            case '3':
                {var} += 't';
            break;
            case '2':
                {var} += 'u';
            break;
            case '9':
                {var} += 'v';
            break;
            case '4':
                {var} += 'x';
            break;
            case '8':
                {var} += 'z';
            break;
            case '7':
                {var} += 'y';
            break;
            case '2':
                {var} += '1';
            break;
            case '6':
                {var} += '5';
            break;
            case '0':
                {var} += '3';
            break;
            case '.':
                {var} += '2';
            break;
            case '/':
                {var} += '9';
            break;
            case '`':
                {var} += '4';
            break;
            case ';':
                {var} += '7';
            break;
            default:
                {var} += {var}1;
                break;
        " + '}' + $@"
" + '}' + $@"
return {var};", Data, script.Code).ResultAssembly, Data));
    // Add em all.
    Data.Scripts.Add(script);
    Data.Code.Add(code);
    encryptName = script.Name.Content;
    Log("Added encryption", LogType.Log);
    }
    catch (Exception ee)
    {
        Log("Failed to add encryption, exception: " + ee.Message, LogType.Warn);
        encryptName = "failedToAdd";
    }
}

void AddFunction(string functionName, string scriptCode)
{
    try
    {
        string nameA = "";
        UndertaleCode code;
        UndertaleCodeLocals codeLocals;
        UndertaleScript script;
        nameA = Renamer();
        // Locals from what i herd are debug info? So just keep em lol.
        codeLocals = new UndertaleCodeLocals(){Name = Data.Strings.MakeString("gml_Script_" + nameA),};
        Data.CodeLocals.Add(codeLocals);
        // Add the code because its a tab for som reason.
        code = new UndertaleCode()
        {
            Name = Data.Strings.MakeString("gml_Script_" + nameA),
        };
        // The actuall script code lol...
        script = new UndertaleScript()
        {
            Name = Data.Strings.MakeString(nameA),
            Code = code,
        };
        script.Code.Append( Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(scriptCode, Data, script.Code).ResultAssembly, Data));
        // Add em all.
        Data.Scripts.Add(script);
        Data.Code.Add(code);
        // Add it to the dictonary.
        functions.Add(functionName,nameA);
        Log("Added " + functionName, LogType.Log);
    }
    catch (Exception ee)
    {
        Log("Failed to add " + functionName + " as a function, exception: " + ee.Message, LogType.Warn);
    }
}
#endregion
Message("Begining obfuscation...");

List<string> nonRename = new List<string>();

/* 
    We are doing this because
    If we don't, objects crash on big games.
    While objects are still *slow* on big games,
    they are much faster then just crashing.
*/

if (encryption)
{
    Log("Locate strings...", LogType.Log);
    ScriptMessage("Gathering strings for string encryption (depending on game size, may take AWHILE.");
    SetupProgress("Other strings (1)", Data.GameObjects.Count, "Object strings... (Strings to not be included)");
    foreach (UndertaleGameObject obj in Data.GameObjects)
    {
        nonRename.Add(obj.Name.Content);
        updateProgress();
    }
    SetupProgress("Other strings (2)", Data.Scripts.Count, "Script strings... (Strings to not be included)");
    foreach (UndertaleScript obj in Data.Scripts)
    {
        nonRename.Add(obj.Name.Content);
        updateProgress();
    }
    SetupProgress("Other strings (3)", Data.Variables.Count, "Variables... (Strings to not be included)");
    foreach (UndertaleVariable obj in Data.Variables)
    {
        nonRename.Add(obj.Name.Content);
        updateProgress();
    }
    SetupProgress("Other strings (4)", Data.Functions.Count, "Functions... (Strings to not be included)");
    foreach (UndertaleFunction obj in Data.Functions)
    {
        nonRename.Add(obj.Name.Content);
        updateProgress();
    }
    SetupProgress("Strings", Data.Strings.Count - nonRename.Count, "Actual strings... (Strings to be included!)");
    int max = Data.Strings.Count - nonRename.Count;
    int ii = 0;
    foreach (UndertaleString stringa in Data.Strings)
    {
        if (ii >= max) {}
        else
        {
            if (!nonRename.Contains(stringa.Content))
                dataStrings.Add(stringa.Content);
            updateProgress();
            ii++;
        }
    }
}
Log("--- Sprites", LogType.Log);
#region Sprites
SetupProgress("Sprites", Data.Sprites.Count);
foreach(UndertaleSprite spr in Data.Sprites)
{
    // Not much you can do with sprites other then rename them.
    spr.Name.Content = Renamer();
    updateProgress();
}
#endregion

Log("--- Scripts", LogType.Log);
List<UndertaleScript> scriptsToRecomp = new List<UndertaleScript>();

#region Scripts
SetupProgress("Scripts", Data.Scripts.Count);
foreach(UndertaleScript scr in Data.Scripts)
{
    try
    {
        if (!scr.Name.Content.Contains("gms")) // GMS Check
        {
            string nameRRR = Renamer();
            scr.Name.Content = nameRRR;
        }
    }
    catch (Exception e)
    {
        Log("Failed on " + scr.Name.Content + "\n[EXCEPTION] " + e.ToString(), LogType.Error);
        ScriptMessage("Failed on script: " + scr.Name.Content + "\nException: " + e.ToString());
        File.WriteAllText("KO.Log", log);
        Process.Start("KO.Log");
        return;
    }
    updateProgress();
}
#endregion

if (encryption)
{
    Log("--- Add Decryption method", LogType.Log);
    AddEncrypt();
}

Log("--- Functions", LogType.Log);

#region Functions
int functionCount = Data.Functions.Count;
for (int iiii = 0; iiii < functionCount; iiii++)
{
    UndertaleFunction func = Data.Functions[iiii];
    string nameA = "";
    UndertaleCode code;
    UndertaleCodeLocals codeLocals;
    UndertaleScript script;
    string var = "";
    int number = 0;
    switch (func.Name.Content)
    {
        case "keyboard_check":
            AddFunction("keyboard_check",getRandomJunk() + $@"
            var cappa = argument0;
            return keyboard_check(argument0);");
        break;
        case "audio_exists":
            AddFunction("audio_exists", getRandomJunk() + $@"
            var cappa = argument0;return audio_exists(argument0);");
        break;
        case "audio_stop_sound":
            AddFunction("audio_stop_sound", getRandomJunk() + $@"
            var cappa = argument0;audio_stop_sound(argument0);
            return;");
        break;
        case "instance_create":
            AddFunction("instance_create",getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            instance_create(argument0,argument1,argument3);
            return;");
        break;
        case "room_goto":
            AddFunction("room_goto",getRandomJunk() + $@"
            var cappa = argument0;
            room_goto(argument0);
            return;");
        break;
        case "place_free":
            AddFunction("place_free",getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            return place_free(argument0, argument1);");
        break;
        case "audio_play_sound":
            AddFunction("audio_play_sound",getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            audio_play_sound(argument0,argument1,argument2);
            return;");
        break;
        case "keyboard_check_pressed":
            AddFunction("keyboard_check_pressed", getRandomJunk() + $@"
            var cappa = argument0;
            return keyboard_check_pressed(argument0);");
        break;
        case "keyboard_check_direct":
            AddFunction("keyboard_check_direct", getRandomJunk() + $@"
            var cappa = argument0;
            return keyboard_check_direct(argument0);");
        break;
        case "place_meeting":
            AddFunction("place_meeting", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            return place_meeting(argument0,argument1,argument2);");
        break;
        case "draw_set_valign":
            AddFunction("draw_set_valign", getRandomJunk() + $@"
            var cappa = argument0;
            draw_set_valign(argument0);
            return;");
        break;
        case "draw_set_halign":
            AddFunction("draw_set_halign", getRandomJunk() + $@"
            var cappa = argument0;
            draw_set_halign(argument0);
            return;");
        break;
        case "point_direction":
            AddFunction("point_direction", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            cappa = argument3;
            point_direction(argument0, argument1, argument2, argument3);
            return;");
        break;
        case "alarm_set":
            AddFunction("alarm_set", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            alarm_set(argument0,argument1);
            return;");
        break;
        case "instance_destroy":
            AddFunction("instance_destroy",getRandomJunk() + $@"
            if (argument_count = 1)
                instance_destroy(argument0);
            else if (argument_count = 2)
                instance_destroy(argument0,argument1);
            else
                instance_destroy();
            return;");
        break;
        case "draw_text":
            AddFunction("draw_text", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            draw_text(argument0,argument1,argument2);
            return;");
        break;
        case "draw_set_font":
            AddFunction("draw_set_font", getRandomJunk() + $@"
            var cappa = argument0;
            draw_set_font(argument0);
            return;");
        break;
        case "draw_text_ext":
            AddFunction("draw_text_ext", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            cappa = argument3;
            draw_text_ext(argument0,argument1,argument2,argument3);
            return;");
        break;
        case "draw_text_colour":
            AddFunction("draw_text_colour", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            cappa = argument3;
            cappa = argument4;
            cappa = argument5;
            cappa = argument6;
            cappa = argument7;
            draw_text_colour(argument0,argument1,argument2,argument3,argument4,argument5,argument6,argument7);
            return;");
        break;
        case "draw_set_color":
            AddFunction("draw_set_color", getRandomJunk() + $@"
            var cappa = argument0;
            draw_set_color(argument0);
            return;");
        break;
        case "random_range":
            AddFunction("random_range", getRandomJunk() + $@"
            var cappa = argument0;
            cappa = argument1;
            return random_range(argument0,argument1);");
        break;
        case "irandom":
            AddFunction("irandom", getRandomJunk() + $@"
            var cappa = argument0;
            return irandom(cappa);");
        break;
        case "array_length_1d":
            AddFunction("array_length_1d", getRandomJunk() + $@"
            var cappa = argument0;
            return array_length_1d(cappa);");
        break;
        case "draw_self":
            AddFunction("draw_self", getRandomJunk() + $@"
            draw_self();
            return;");
        break;
    }
}
#endregion
Log("Function list", LogType.Log);
foreach (string func in functions.Keys)
{
    Log(func, LogType.Log);
}
Log("End Function list", LogType.Log);
Log("--- Objects", LogType.Log);

List<UndertaleGameObject> objectsToRecomp = new List<UndertaleGameObject>();

#region Objects
SetupProgress("Objects", Data.GameObjects.Count);
int iii = 0;
foreach (UndertaleGameObject obj in Data.GameObjects)
{
    bool recomp = false;
    string nameAA = Renamer();
    // Renamer
    obj.Name.Content = nameAA;
    if (obj.Events.Count > 0)
    {
        for (var i = 0; i < obj.Events.Count; i++) {
        {
            var eventType = (int) (UndertaleModLib.Models.EventType) i;
            foreach (var evt in obj.Events[i])
            {
                foreach(UndertaleGameObject.EventAction evA in evt.Actions)
                {
                    string[] code = UndertaleModLib.Decompiler.Decompiler.Decompile(evA.CodeId, new UndertaleModLib.Decompiler.DecompileContext(Data,true)).Split('\n');
                    string newCode = "";
                    string lastNewLine = "";
                    // Search for functions
                    foreach (string line in code)
                    {
                        try
                        {
                            if (line.Contains("var"))
                                continue;
                            string newLine = "";
                            string lastFunc= "none|none";
                            foreach (string func in functions.Keys)
                            {
                                if (line.Contains(func))
                                {
                                    newLine = line.Replace(func, functions[func]);
                                    lastFunc = func + "|" + line.Replace(func, functions[func]);
                                    recomp = true;
                                }
                                else
                                    if (line.Contains(lastFunc.Split('|')[0]))
                                        newLine = lastFunc.Split('|')[1];
                                    else
                                        newLine = line;
                            }
                            newCode += newLine + "\n";
                            lastNewLine = newLine;
                        }
                        catch (Exception ee)
                        {
                            ScriptMessage("Failed on " + evA.CodeId.Name.Content + " Check log for details.");
                            Log("Failed on " + evA.CodeId.Name.Content + " Exception: " + ee.Message, LogType.Warn);
                        }
                    }
                    // Renamer x2 lol
                    string orginalName = evA.CodeId.Name.Content;
                    string rName = evA.CodeId.Name.Content.Replace(obj.Name.Content,nameAA);
                            if (encryption)
                            {
                                string newNewLine = "";
                                string lastString = "none|none";
                                if (string.Join("\n", code).Contains('"'))
                                {
                                    SetupProgress("Encrypting strings...", dataStrings.Count, "Object " + iii + "/" + Data.GameObjects.Count);
                                    foreach (string strin in dataStrings)
                                    {
                                        if (obj.Name.Content != strin)
                                        {
                                            if (lastNewLine.Contains('"' + strin + '"'))
                                            {
                                                if(strin.Length != 0)
                                                {
                                                    lastString = strin + "|" + lastNewLine.Replace('"' + strin + '"',encryptName + "(" + '"' + Encrypt(strin) + '"' + ")");
                                                    newNewLine = lastNewLine.Replace('"' + strin + '"',encryptName + "(" + '"' + Encrypt(strin) + '"' + ")");
                                                }
                                            }
                                            else
                                                if (lastNewLine.Contains(lastString.Split('|')[0]))
                                                    newNewLine = lastString.Split('|')[1];
                                                else
                                                    newNewLine = lastNewLine;
                                        }
                                        else
                                            if (lastNewLine.Contains(lastString.Split('|')[0]))
                                                newNewLine = lastString.Split('|')[1];
                                            else
                                                newNewLine = lastNewLine;
                                        updateProgress();
                                    }
                                }
                                newCode += newNewLine + "\n";
                            }
                    // Replace em all. and make it look good :)
                    try
                    {
                        if (newCode.Contains("@6") && !newCode.Contains('"' + "@6" + '"'))
                            newCode = newCode.Replace("@6","");
                        Log("Adding new code:\n```\n" + newCode + "\n```\nFor " + orginalName, LogType.Log);
                        evA.CodeId.Replace(Assembler.Assemble( UndertaleModLib.Compiler.Compiler.CompileGMLText(newCode, Data, evA.CodeId).ResultAssembly, Data));
                        evA.CodeId.Name = Data.Strings.MakeString(rName);
                    }
                    catch (Exception ee)
                    {
                        Log("Failed on " + orginalName + ", displaying error.", LogType.Error);
                        Message("Failed on " + orginalName + " check KO.Log for a reason for this: " + ee.Message);
                        File.WriteAllText("KO.Log",log);
                        return;
                    }
                    if (recomp)
                        objectsToRecomp.Add(obj);
                }
            }
        }
    }
    updateProgress();
    iii++;
}
}

foreach (UndertaleGameObject obj in objectsToRecomp)
{
    Data.GameObjects.Remove(obj);
    Data.GameObjects.Add(obj);
}
#endregion

Log("--- Rooms", LogType.Log);

#region Rooms
SetupProgress("Rooms", Data.Rooms.Count);
foreach (UndertaleRoom rm in Data.Rooms)
{
    rm.Name.Content = Renamer();
}
#endregion

Log("--- Misc stuff", LogType.Log);

#region Paths/Shaders/Audio/Backgrounds/Timelines

foreach (UndertaleTimeline tim in Data.Timelines)
{
    tim.Name.Content = Renamer();
}

foreach (UndertalePath path in Data.Paths)
{
    path.Name.Content = Renamer();
}

foreach (UndertaleShader shad in Data.Shaders)
{
    shad.Name.Content = Renamer();
}

foreach (UndertaleSound audio in Data.Sounds)
{
    audio.Name.Content = Renamer();
}

foreach (UndertaleBackground bg in Data.Backgrounds)
{
    bg.Name.Content = Renamer();
}

#endregion

Log("--- Metadata", LogType.Log);
#region Metadata/whaterver
Data.GeneralInfo.LastObj = 1;
Data.GeneralInfo.LastTile = 1;
Data.GeneralInfo.DebuggerPort = 1;

Data.GeneralInfo.Config = Data.Strings.MakeString(Renamer());

Data.GeneralInfo.Name = Data.Strings.MakeString(Renamer());

Data.GeneralInfo.Filename = Data.Strings.MakeString(Renamer());
#endregion

File.WriteAllText("KO.Log", log);
Process.Start("KO.Log");
Message("Complete!");
ChangeSelection(GML_UNDEFINED + "- Protection Complete! -" + GML_UNDEFINED);
