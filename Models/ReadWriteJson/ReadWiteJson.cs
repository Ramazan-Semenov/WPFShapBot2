using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPFShapBot.Models.ReadWriteJson
{
    class  ReadWiteJson<T>
    {
        /// <summary>
        /// Запись и создание json файла
        /// </summary>
        /// <param name="path">Место расположение файла</param>
        /// <param name="collection"> Эленемты для записи</param>
        /// <returns></returns>
        public async Task WriteJson(string path,T collection)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync<T>(fs, collection);
                    Trace.WriteLine("Data has been saved to file");
                }
            }catch(Exception exp)
            {
                Trace.WriteLine(exp+ "  :WriteJson(string path,T collection)");
            }
        }
        /// <summary>
        /// Чтение Json файла
        /// </summary>
        /// <param name="path"> Место расположение файла</param>
        /// <returns></returns>
        public async Task<T> ReadJson(string path)
        {
            dynamic obj=null;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    obj = await JsonSerializer.DeserializeAsync<T>(fs);
                }
                return obj;
            }catch(Exception exp)
            {
                Trace.WriteLine(exp + "  :ReadJson(string path)");

                return obj;


            }
        }
    }
      
}
