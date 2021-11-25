

string inputFilePath = @"C:\Users\User\source\repos\ConsoleApp2\ConsoleApp2\input.txt";
string outputFilePath = @"C:\Users\User\source\repos\ConsoleApp2\ConsoleApp2\output.txt";
using (ExchangeBeetwenFiles exchangeBeetwenFiles = new ExchangeBeetwenFiles(inputFilePath, outputFilePath))
{
    exchangeBeetwenFiles.Exchange();
}

class CalculationContainer
{
    public int Attitude { get; private set; }
    public int CountOfLayers { get; private set; }
    public CalculationContainer(int attitude, int countOfLayers)
    {
        Attitude = attitude;
        CountOfLayers = countOfLayers;
    }
    public int GetNumberOfMatrasses()
    {
        return (Attitude * Attitude) * CountOfLayers;
    }
}
sealed class ExchangeBeetwenFiles : IDisposable
{
    private StreamReader _streamReader;
    private StreamWriter _streamWriter;
    private bool _isDisposed = false;
    public ExchangeBeetwenFiles(string inputFilePath, string outputFilePath)
    {
        _streamReader = new StreamReader(inputFilePath);
        _streamWriter = new StreamWriter(outputFilePath, false);
    }
    private void readFromInput(out string[] content)
    {
        content = _streamReader.ReadToEnd().Split(" ");
    }
    private void writeToFile(CalculationContainer input)
    {
        _streamWriter.Write(input.GetNumberOfMatrasses().ToString());
    }
    public void Exchange()
    {
        string[] content;
        readFromInput(out content);
        int attitude = int.Parse(content[0]);
        int countOfLayers = int.Parse(content[1]);
        CalculationContainer calculationContainer = new CalculationContainer(attitude, countOfLayers);
        writeToFile(calculationContainer);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {

            }
            _streamReader.Dispose();
            _streamWriter.Dispose();
        }
    }
    ~ExchangeBeetwenFiles()
    {
        Dispose(false);
    }
}
