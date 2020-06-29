using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UpLoadImageAsync(IFormFile formFile, string folder)
        {
            string guid = Guid.NewGuid().ToString(); //crea un identificador
            string file = $"{guid}.jpg"; //asignamos el identificador
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{folder}", file); //asignamos la ruta para el archivo

            using (FileStream stream = new FileStream(path, FileMode.Create)) //creamos el file en memoria
            {
                await formFile.CopyToAsync(stream); //y lo copiamos en memoria
            }

            return $"~/images/{folder}/{file}";
        }
    }
}
