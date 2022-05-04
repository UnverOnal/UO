using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace UO.MaterialManagement
{
    public static class MaterialUtility
    {
        /// <summary>
        ///  Object's materials must be transparent. Otherwise this method has no effect.
        /// </summary>>
        /// <param name="blinkingCount">For endless blinking fx pass -1.</param>
        public static void BlinkMaterial(this GameObject objectToBlink, float targetAlpha, float duration, int blinkingCount)
        {
            Material[] materials = GetMaterials(objectToBlink);

            foreach(Material material in materials)
            {
                material.DOFade(targetAlpha, duration)
                .SetLoops(blinkingCount, LoopType.Yoyo);
            }
        }

        ///<summary>
        ///Returns first or only material of an object.
        ///</summary>
        public static Material GetMaterial(GameObject obj)
        {
            MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
            Material material = renderers[0].material;

            return material;
        }

        ///<summary>
        ///Returns all materials of an object.
        ///</summary>
        public static Material[] GetMaterials(GameObject obj)
        {
            MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
            
            List<Material> materials = new List<Material>();

            foreach(MeshRenderer renderer in renderers)
            {
                materials.AddRange(renderer.materials);
            }

            return materials.ToArray();
        }

        ///<summary>
        ///Set color by using Color struct.
        ///</summary>
        public static void ChangeColor(this Material material, Color targetColor)
        {
            material.SetColor("_BaseColor", targetColor);
        }

        ///<summary>
        ///Set color by using RGB.
        ///</summary>
        public static void ChangeColor(this Material material, float r, float g, float b, float a)
        {
            Color32 color = new Color32(((byte)r), ((byte)g), ((byte)b) , ((byte)a));

            material.color = color;
        }

        ///<summary>
        ///Set color gradually.
        ///</summary>
        public static void ChangeColor(this Material material, Color targetColor, float duration = 0f)
        {
            material.DOColor(targetColor, duration);
        }

        ///<summary>
        ///Set color by only changing Hue. So that saturation and value(brightness) remains same.
        ///</summary>
        public static void ChangeColorHue(this Material material, Color targetColor)
        {
            float targetH, targetS, targetV;
            Color.RGBToHSV(targetColor, out targetH, out targetS, out targetV);

            Color color = material.color;
            float H, S, V;
            Color.RGBToHSV(color, out H, out S, out V);

            H = targetH;
            color = Color.HSVToRGB(H, S, V);
            material.SetColor("_BaseColor", color);
        }
    }
}
