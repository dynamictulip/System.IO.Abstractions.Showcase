namespace TestCode;

public class MyFileAltererTests
{
    private MockFileSystem _mockFileSystem;
    private MyFileAlterer _sut;

    [SetUp]
    public void Setup()
    {
        _mockFileSystem = new MockFileSystem();
        _sut = new MyFileAlterer(_mockFileSystem);
    }

    [Test]
    public void ReplaceAFile_Throws_when_file_doesnt_exist()
    {
        var action = () => _sut.ReplaceAFile(@"c:\file\doesnt\exist");
        Assert.That(action, Throws.InstanceOf<IOException>());
    }


    [Test]
    public void ReplaceAFile_replaces_a_given_file()
    {
        const string myfile = @"c:\myFile";

        var originalMockFile = new MockFileData("I am a file with one line");
        _mockFileSystem.AddFile(myfile, originalMockFile);

        _sut.ReplaceAFile(myfile);

        var mockFileAfterReplace = _mockFileSystem.GetFile(myfile);
        Assert.That(mockFileAfterReplace, Is.Not.SameAs(originalMockFile));
    }
}