namespace Code.Services.FileDataServices
{
    public interface IFileDataService
    {
        string LoadJson(string dataDirPath);
        void Save(string json, string dataDirPath);
        void DeleteJson(string filename);
    }
}