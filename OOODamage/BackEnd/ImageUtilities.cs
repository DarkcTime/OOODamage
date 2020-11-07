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
    /// <summary>
    /// Class for work with Images
    /// </summary>
    class ImageUtilities
    {
        /// <summary>
        /// open dialog window for select image
        /// </summary>
        /// <returns>path image</returns>
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
        /// <summary>
        /// Convert Image to byte for add in BD
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] ConvertImageToByte(string path)
        {            
            Bitmap image = new Bitmap(path);            
            using (MemoryStream ms = new MemoryStream())
            {                
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

    }
}
