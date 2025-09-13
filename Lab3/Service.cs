using System;
public class Service
{
    private string formatOutput; //формат виведення даних
    private string pathToFile; //шлях до файлу
    private string data; //дані
    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Service()
    {
        formatOutput = "";
        pathToFile = "";
        data = "";
    }
    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="formatOutput"> формат даних </param>
    /// <param name="pathToFile"> шлях до файлу </param>
    /// <param name="data"> дані </param>
    public Service(string formatOutput, string pathToFile, string data)
    {
        this.formatOutput = formatOutput;
        this.pathToFile = pathToFile;
        this.data = data;
    }
    /// <summary>
    /// Конструктор копії
    /// </summary>
    /// <param name="other"></param>
    public Service(Service other)
    {
        formatOutput = other.formatOutput;
        pathToFile = other.pathToFile;
        data = other.data;
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string FormatOutput
    {
        get
        {
            return formatOutput;
        }
        set
        {
            formatOutput = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string PathToFile
    {
        get
        {
            return pathToFile;
        }
        set
        {
            pathToFile = value;
        }
    }
    /// <summary>
    /// Властивість
    /// </summary>
    public string Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }
    /// <summary>
    /// Метод виведення даних
    /// </summary>
    /// <param name="data"> дані для виведення </param>
    public void PrintData(string data)
    {
        Console.Write(data);
    }
    /// <summary>
    /// Метод зчитання даних з консолі
    /// </summary>
    /// <returns></returns>
    public string ReadData()
    {
        return Console.ReadLine();
    }
    /// <summary>
    /// Метод запису даних до файлу
    /// </summary>
    public void WriteData()
    {
        StreamWriter writer = new StreamWriter(PathToFile);
        writer.WriteLine(Data); 
        writer.Close();
    }
    /// <summary>
    /// Метод зчитання даних
    /// </summary>
    /// <returns></returns>
    public string ReadFromFile()
    {
        StreamReader reader = new StreamReader(PathToFile);
        string result = reader.ReadToEnd(); 
        reader.Close();
        return result;
    }
    /// <summary>
    /// Метод перейменування файлу
    /// </summary>
    /// <param name="newFileName"> новий шлях до файлу </param>
    public void RenameFile(string newFileName)
    {
        string directory = Path.GetDirectoryName(PathToFile); //шлях до файлу
        string newFilePath = Path.Combine(directory, newFileName); //формування нового шляху
        File.Move(PathToFile, newFilePath); //перейменування файлу
        PathToFile = newFilePath; //оновлення шляху до файлу
    }
}