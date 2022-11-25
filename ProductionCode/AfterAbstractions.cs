namespace ProductionCode
{
    public class AfterAbstractions: IMyFileAlterer
    {
        public void ReplaceAFile(string filePath)
        {
            throw new NotImplementedException();
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
