using ProductionCode;

var beforeAbstractions = new BeforeAbstractions();

Console.WriteLine(
@" _    _   _____   _      _      _____
| |  | | |  ___| | |    | |    |  _  |
| |__| | | |___  | |    | |    | | | |
|  __  | |  ___| | |    | |    | | | |
| |  | | | |___  | |___ | |___ | |_| |
|_|  |_| |_____| |_____||_____||_____|
");

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
        beforeAbstractions.ReplaceAFile(path);
        break;
    case "2":
        beforeAbstractions.AlterTheMiddleOfAFile(path);
        break;
    case "3":
        await beforeAbstractions.AlterTheMiddleOfManyFiles(path);
        break;
    default:
        Console.WriteLine("That wasn't an option!");
        goto SelectOption;
}

Console.WriteLine("Done");
Console.WriteLine();
Console.WriteLine(@"Have a nice day \(o.o)/");

//Note to readers of this code. GoTos are bad, don't use them