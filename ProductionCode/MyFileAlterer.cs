namespace ProductionCode
{
    public class MyFileAlterer: IMyFileAlterer
    {
        private readonly IFileSystem _fileSystem;

        public MyFileAlterer(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void ReplaceAFile(string filePath)
        {
            var contents = _fileSystem.File.ReadAllLines(filePath);
            contents[0] += " - altered line 1";
            _fileSystem.File.Delete(filePath);
            _fileSystem.File.WriteAllLines(filePath, contents);
        }

        public void AlterTheMiddleOfAFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task AlterTheMiddleOfAFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task AlterTheMiddleOfManyFiles(string directoryPath)
        {
            throw new NotImplementedException();
        }
    }
}
