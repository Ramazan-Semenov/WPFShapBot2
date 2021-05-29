using System;
using System.IO;
using System.Threading.Tasks;

namespace WPFShapBot.Models
{
    public class Save
    {
        public string creatdir(string path = "", string subpath = "")
        {

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            string pasub = path + "\\" + subpath;
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            DirectoryInfo dirsub = new DirectoryInfo(pasub);

            if (!dirsub.Exists)
            {
                dirInfo.CreateSubdirectory(subpath);

            }
            return pasub;
        }
        public async Task sAsync(string writePath, string text)
        {

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }


                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
