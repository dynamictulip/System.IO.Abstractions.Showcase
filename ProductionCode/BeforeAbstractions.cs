using System.Diagnostics.CodeAnalysis;

namespace ProductionCode;

[ExcludeFromCodeCoverage] //Interacting with the actual file system is untestable, this is why we need to use System.IO.Abstractions
public class BeforeAbstractions : IMyFileAlterer
{
    private const string MiddleText = " Middle ";

    public void ReplaceAFile(string filePath)
    {
        var fileContents = File.ReadAllLines(filePath);

        var count = 1;
        var newFileContents = new List<string>();
        foreach (var line in fileContents)
        {
            newFileContents.Add($"{line} altered {count}");
            count++;
        }

        File.Delete(filePath);
        File.WriteAllLines(filePath, newFileContents);
    }

    public void AlterTheMiddleOfAFile(string filePath)
    {
        using var stream = File.Open(filePath, FileMode.Open);
        var midpoint = stream.Length / 2;
        var startpoint = midpoint - MiddleText.Length / 2;
        stream.Seek(startpoint, SeekOrigin.Begin);

        using var sw = new StreamWriter(stream);
        sw.Write(MiddleText);
        
        sw.Flush();
        sw.Close();
    }

    public async Task AlterTheMiddleOfAFileAsync(string filePath)
    {
        await using var stream = File.Open(filePath, FileMode.Open);
        var midpoint = stream.Length / 2;
        var startpoint = midpoint - MiddleText.Length / 2;
        stream.Seek(startpoint, SeekOrigin.Begin);

        await using var sw = new StreamWriter(stream);
        await sw.WriteAsync(MiddleText);
        
        await sw.FlushAsync();
        sw.Close();
    }
    
    public async Task AlterTheMiddleOfManyFiles(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath);

        await Task.WhenAll(files.Select(AlterTheMiddleOfAFileAsync));
    }
}