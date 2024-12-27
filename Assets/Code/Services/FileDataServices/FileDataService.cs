using System;
using System.IO;
using System.Xml.Schema;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Services.FileDataServices
{
    public class FileDataService : IFileDataService
    {
        private const string ENSCRYPRION_KEY = "JACK_FRESCO_PROBLEM";
        
        private readonly bool _isEnscryption;
        private string _dataDirPath = "";

        public FileDataService(string dataDirPath, bool withEnscryption = false)
        {
            _dataDirPath = dataDirPath;
            _isEnscryption = withEnscryption;
        }

        public void DeleteJson(string filename)
        {
            try
            {
                File.Delete(Path.Combine(_dataDirPath, filename));
            }
            catch (IOException ex)
            {
                Debug.LogError($"[FILE_DATA_SERVICE]: Error while deleting file: {filename}: {ex.Message}");
            }
        }

        public string LoadJson(string dataFileName)
        { 
            string fullPath = Path.Combine(_dataDirPath, dataFileName);

            if (File.Exists(fullPath))
            {
                try
                {
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string result = reader.ReadToEnd();
                            
                            if (_isEnscryption)
                            {
                                result = result.Enscrypt(ENSCRYPRION_KEY);
                            }

                            return result;
                        }
                    }
                }
                catch (Exception)
                {
                    Debug.LogError($"[FILE_DATA_SERVICE]: Error while loading data with name {dataFileName} from {fullPath}");
                }
            }
            return null;
        }

        public void Save(string json, string dataFileName) 
        { 
            string fullpath = Path.Combine(_dataDirPath, dataFileName);
            try
            {
                using (FileStream stream = new FileStream(fullpath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        string result = json;
                        
                        if (_isEnscryption)
                        {
                            result = result.Enscrypt(ENSCRYPRION_KEY);
                        }
                        
                        writer.Write(result);
                    }
                }
            }
            catch(Exception)
            {
                Debug.LogError($"[FILE_DATA_SERVICE]: Error while saving data with name {dataFileName} to {fullpath}");
            }
        }
    }
}
