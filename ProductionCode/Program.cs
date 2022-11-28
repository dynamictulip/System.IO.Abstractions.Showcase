Console.WriteLine(
@" _    _   _____   _      _      _____
| |  | | |  ___| | |    | |    |  _  |
| |__| | | |___  | |    | |    | | | |
|  __  | |  ___| | |    | |    | | | |
| |  | | | |___  | |___ | |___ | |_| |
|_|  |_| |_____| |_____||_____||_____|
");

IMyFileAlterer fileAlterer;
Console.WriteLine("You wanna use System.IO.Abstractions?");
Console.WriteLine("y/n?");
var useAbstractions = Console.ReadLine();
if (useAbstractions == "y")
    fileAlterer = new MyFileAlterer(new FileSystem());
else
    fileAlterer = new BeforeAbstractions();

Console.WriteLine("Gimme a file path");
var path = Console.ReadLine();

SelectOption:
Console.WriteLine("What do you want to do to that file?");
Console.WriteLine("1 - Replace it");
Console.WriteLine("2 - Alter middle of it");
Console.WriteLine("3 - It's a directory not a file! Alter middle of all files in the directory");

var option = Console.ReadLine();

switch (option)
{
    case "1":
        fileAlterer.ReplaceAFile(path);
        break;
    case "2":
        fileAlterer.AlterTheMiddleOfAFile(path);
        break;
    case "3":
        await fileAlterer.AlterTheMiddleOfManyFiles(path);
        break;
    default:
        Console.WriteLine("That wasn't an option!");
        goto SelectOption;
}

Console.WriteLine("Done");
Console.WriteLine();
Console.WriteLine(@"Have a nice day \(o.o)/");

//Note to readers of this code. GoTos are bad, don't use them