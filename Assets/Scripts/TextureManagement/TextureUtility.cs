using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UO.TextureManagement
{
    public static class TextureUtility
    {
        ///<summary>
        ///Create color by only changing Hue. So that saturation and value(brightness) remains same.
        ///</summary>
        private static Color ChangePixelColorHue(Color currentColor, Color targetColor)
        {
            float targetH, targetS, targetV;
            Color.RGBToHSV(targetColor, out targetH, out targetS, out targetV);

            float currentH, currentS, currentV;
            Color.RGBToHSV(currentColor, out currentH, out currentS, out currentV);

            currentH = targetH;
            currentColor = Color.HSVToRGB(currentH, currentS, currentV);

            return currentColor;
        }

        ///<summary>
        ///Create color by only changing Saturation. So that hue and value(brightness) remains same.
        ///</summary>
        private static Color ChangePixelColorSaturation(Color currentColor, Color targetColor)
        {
            float targetH, targetS, targetV;
            Color.RGBToHSV(targetColor, out targetH, out targetS, out targetV);

            float currentH, currentS, currentV;
            Color.RGBToHSV(currentColor, out currentH, out currentS, out currentV);

            currentS = targetS;
            currentColor = Color.HSVToRGB(currentH, currentS, currentV);

            return currentColor;
        }

        ///<summary>
        ///Get coordinates of pixels to be painted.
        ///</summary>
        public static List<Vector2> GetPixelsToBePainted(Texture texture)
        {
            List<Vector2> pixelCoordinates = new List<Vector2>();

            int width = texture.width;
            int height = texture.height;

            Texture2D texture2D = (Texture2D)texture;

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    Color currentColor = texture2D.GetPixel(i, j);
                    if(currentColor.a == 0f)
                        continue;

                    Vector2 coordinate = new Vector2(i, j);
                    pixelCoordinates.Add(coordinate);
                }
            }

            return pixelCoordinates;
        }

        ///<summary>
        ///Paint all pixels of an texture given that is not transparent.
        ///</summary>
        public static Texture PaintTexture(this Texture texture, Color targetColor, bool replaceHue)
        {
            int width = texture.width;
            int height = texture.height;

            Texture2D texture2D = new Texture2D(width, height);
            texture2D.SetPixels(((Texture2D)texture).GetPixels());

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    Color currentColor = texture2D.GetPixel(i, j);
                    if(currentColor.a == 0f)
                        continue;

                    Color color = replaceHue ? ChangePixelColorHue(currentColor, targetColor) : targetColor;
                    texture2D.SetPixel(i, j, color);
                }
            }

            texture2D.Apply();
            return texture2D as Texture;
        }

        ///<summary>
        ///Paint all pixels passed of an texture given.
        ///</summary>
        public static Texture PaintTexture(Texture texture, List<Vector2> pixelCoordinates, Color targetColor, bool replaceHue)
        {
            int width = texture.width;
            int height = texture.height;

            Texture2D texture2D = new Texture2D(width, height);
            texture2D.SetPixels(((Texture2D)texture).GetPixels());

            for(int i = 0; i < pixelCoordinates.Count; i++)
            {
                Color currentColor = texture2D.GetPixel((int)pixelCoordinates[i].x, (int)pixelCoordinates[i].y);

                Color color = replaceHue ? ChangePixelColorHue(currentColor, targetColor) : targetColor;
                texture2D.SetPixel((int)pixelCoordinates[i].x, (int)pixelCoordinates[i].y, color);
            }

            texture2D.Apply();
            return texture2D as Texture;
        }
    }   
}

