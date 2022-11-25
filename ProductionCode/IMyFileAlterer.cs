namespace ProductionCode;

public interface IMyFileAlterer
{
    void ReplaceAFile(string filePath);
    void AlterTheMiddleOfAFile(string filePath);
    Task AlterTheMiddleOfAFileAsync(string filePath);
    Task AlterTheMiddleOfManyFiles(string directoryPath);
}