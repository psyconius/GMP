using SideLoader;
using UnityEngine;
using System.IO;

namespace SLExtensions
{
    public static class SLEffectExtensions
    {
        /// <summary> Force set icon.png - Use AFTER .ApplyTemplate() and MUST BE located in (SideLoader/StatusEffects/&lt;StatusIdentifier&gt;/) </summary>
        public static void ApplyIcon(this SL_StatusEffect effect)
        {
            
            SLPack pack = SL.GetSLPack(effect.SLPackName);

            // Set filepath to icon
            string filePath = pack.FolderPath + @"\StatusEffects\" + effect.StatusIdentifier + @"\icon.png";
            byte[] fileData = File.ReadAllBytes(filePath);

            // Create a new texture with icon size and setup sprite object
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            Sprite sprite = CustomTextures.CreateSprite(tex, CustomTextures.SpriteBorderTypes.NONE);

            // Find actual Outward status effect
            StatusEffect statusEffect = ResourcesPrefabManager.Instance.GetStatusEffectPrefab(effect.StatusIdentifier);

            // Replace and setup icon
            statusEffect.OverrideIcon = sprite;
            statusEffect.m_defaultStatusIcon = new StatusTypeIcon(Tag.None) { Icon = sprite };
        }
    }

    public static class SLItemExtensions
    {
        public static void ApplyIcon(this SL_Item item)
        {

        }
    }
}
