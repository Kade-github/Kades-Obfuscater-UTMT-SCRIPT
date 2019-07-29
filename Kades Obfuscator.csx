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

string log = "[KO V2 loaded]\n";
Dictionary<string, string> functions = new Dictionary<string, string>();

#region Methods

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
Log("--- Sprites", LogType.Log);
#region Sprites
foreach(UndertaleSprite spr in Data.Sprites)
{
    // Not much you can do with sprites other then rename them.
    spr.Name.Content = Renamer();
}
#endregion

Log("--- Scripts", LogType.Log);

#region Scripts
foreach(UndertaleScript scr in Data.Scripts)
{
    if (!scr.Name.Content.Contains("gms")) // GMS Check
    {
        Log("Passed GMS Check for " + scr.Name.Content, LogType.Log);
        string orginalName = scr.Name.Content;
        string nameRRR = Renamer();
        scr.Name.Content = nameRRR;
        // Code locals because dab
        var codeLocalsBeforeAgain = new UndertaleCodeLocals(){Name = Data.Strings.MakeString(nameRRR),};
        scr.Code.Name = Data.Strings.MakeString(nameRRR);
        Data.CodeLocals.Add(codeLocalsBeforeAgain);
        Data.CodeLocals.Remove(FindLocal(orginalName)); // Gotta delete it so they dont know the name to the object >:)
    }
}
#endregion

Log("--- Functions", LogType.Log);

#region Functions

foreach (UndertaleFunction func in Data.Functions)
{
    string nameA = "";
    UndertaleCode code;
    UndertaleCodeLocals codeLocals;
    UndertaleScript script;
    string var = "";
    int number = 0;
    switch (func.Name.Content)
    {
        case "keyboard_check":
            AddFunction("keyboard_check",$@"
            var cappa = argument0;
            return keyboard_check(argument0);");
        break;
        case "audio_exists":
            AddFunction("audio_exists", $@"
            var cappa = argument0;return audio_exists(argument0);");
        break;
        case "audio_stop_sound":
            AddFunction("audio_stop_sound", $@"
            var cappa = argument0;audio_stop_sound(argument0);");
        break;
        case "instance_create":
            AddFunction("instance_create",$@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            instance_create(argument0,argument1,argument3);");
        break;
        case "room_goto":
            AddFunction("room_goto",$@"
            var cappa = argument0;
            room_goto(argument0);");
        break;
        case "place_free":
            AddFunction("place_free",$@"
            var cappa = argument0;
            cappa = argument1;
            return place_free(argument0, argument1);");
        break;
        case "audio_play_sound":
            AddFunction("audio_play_sound",$@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            audio_play_sound(argument0,argument1,argument2);");
        break;
        case "keyboard_check_pressed":
            AddFunction("keyboard_check_pressed", $@"
            var cappa = argument0;
            return keyboard_check_pressed(argument0);");
        break;
        case "keyboard_check_direct":
            AddFunction("keyboard_check_direct", $@"
            var cappa = argument0;
            return keyboard_check_direct(argument0);");
        break;
        case "place_meeting":
            AddFunction("place_meeting", $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            return place_meeting(argument0,argument1,argument2);");
        break;
        case "draw_set_valign":
            AddFunction("draw_set_valign", $@"
            var cappa = argument0;
            draw_set_valign(argument0);");
        break;
        case "draw_set_halign":
            AddFunction("draw_set_halign", $@"
            var cappa = argument0;
            draw_set_halign(argument0);");
        break;
        case "point_direction":
            AddFunction("point_direction", $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            cappa = argument3;
            point_direction(argument0, argument1, argument2, argument3");
        break;
        case "alarm_set":
            AddFunction("alarm_set", $@"
            var cappa = argument0;
            cappa = argument1;
            alarm_set(argument0,argument1);");
        break;
        case "instance_destroy":
            AddFunction("instance_destroy",$@"
            if (argument_count = 1)
                instance_destroy(argument0);
            else if (argument_count = 2)
                instance_destroy(argument0,argument1);
            else
                instance_destroy();
            ");
        break;
        case "draw_text":
            AddFunction("draw_text", $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            draw_text(argument0,argument1,argument2);");
        break;
        case "draw_set_font":
            AddFunction("draw_set_font", $@"
            var cappa = argument0;
            draw_set_font(argument0);");
        break;
        case "draw_text_ext":
            AddFunction("draw_text_ext", $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            cappa = argument3;
            draw_text_ext(argument0,argument1,argument2,argument3);");
        break;
        case "draw_text_colour":
            AddFunction("draw_text_colour", $@"
            var cappa = argument0;
            cappa = argument1;
            cappa = argument2;
            cappa = argument3;
            cappa = argument4;
            cappa = argument5;
            cappa = argument6;
            cappa = argument7;
            draw_text_colour(argument0,argument1,argument2,argument3,argument4,argument5,argument6,argument7);");
        break;
        case "draw_set_color":
            AddFunction("draw_set_color", $@"
            var cappa = argument0;
            draw_set_color(argument0);");
        break;
        case "random_range":
            AddFunction("random_range", $@"
            var cappa = argument0;
            cappa = argument1;
            return random_range(argument0,argument1);");
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
foreach (UndertaleGameObject obj in Data.GameObjects)
{
    bool recomp = false;
    string nameAA = Renamer();
    // Renamer
    obj.Name.Content = nameAA;
    for (var i = 0; i < obj.Events.Count; i++) {
    {
        var eventType = (int) (UndertaleModLib.Models.EventType) i;
        foreach (var evt in obj.Events[i])
        {
            foreach(UndertaleGameObject.EventAction evA in evt.Actions)
            {
                string[] code = UndertaleModLib.Decompiler.Decompiler.Decompile(evA.CodeId, new UndertaleModLib.Decompiler.DecompileContext(Data,true)).Split('\n');
                string newCode = "";
                // Search for functions
                foreach (string line in code)
                {
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
                    Log("Newline: " + newLine, LogType.Log);
                    newCode += newLine + "\n";
                }
                // Renamer x2 lol
                string orginalName = evA.CodeId.Name.Content;
                string rName = evA.CodeId.Name.Content.Replace(obj.Name.Content,nameAA);
                // Code locals A G A I N
                var codeLocalsAgain = new UndertaleCodeLocals(){Name = Data.Strings.MakeString(rName),};
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
                // And of course clean up :)
                Data.CodeLocals.Add(codeLocalsAgain);
                Data.CodeLocals.Remove(FindLocal(orginalName)); // Gotta delete it so they dont know the name to the object >:)
                if (recomp)
                    objectsToRecomp.Add(obj);
            }
        }
    }
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
foreach (UndertaleRoom rm in Data.Rooms)
{
    rm.Name.Content = Renamer();
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
