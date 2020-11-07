using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.BackEnd
{
    class Utilities
    {
        public static string SelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName != null)
                    return openFileDialog.FileName; 
            };

            return "null";             
        }

        public static byte[] ConvertImageToByte(string path)
        {
            //создаем объект картинки
            Bitmap image = new Bitmap(path);
            //открываем поток для перевода картинки в байты 
            using (MemoryStream ms = new MemoryStream())
            {
                //сохраняем картинку в поток 
                image.Save(ms, image.RawFormat);
                //возращаем массив байт картинки
                return ms.ToArray();
            }


        }

    }
}
