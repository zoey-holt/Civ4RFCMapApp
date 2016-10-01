﻿using System;
using System.Drawing;
using System.IO;

namespace Civ4RFCMapApp.Implementation
{
    public class ImageResizer
    {
        public void Resize(string imagePath, double widthRatio, double heightRatio)
        {
            Bitmap original = null;
            Bitmap resized = null;
            try
            {
                original = new Bitmap(imagePath);
                int newWidth = (int)(original.Width * widthRatio);
                int newHeight = (int)(original.Height * heightRatio);
                resized = new Bitmap(newWidth, newHeight);
                for (int i = 0; i < newWidth; i++)
                {
                    for (int j = 0; j < newHeight; j++)
                    {
                        resized.SetPixel(i, j, original.GetPixel(i / 4, j / 4));
                    }
                }
                original.Dispose();
                resized.Save(imagePath);
                resized.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                original?.Dispose();
                resized?.Dispose();
            }
        }
    }
}
