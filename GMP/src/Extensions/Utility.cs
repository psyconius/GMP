using System;
using SideLoader;
using SLExtensions;

namespace GMP
{
	public class Utility
	{
        // Default SL Item Apply
        public static void ApplyItem(SL_Item item, string folderName)
        {
            item.SLPackName = Plugin.PACKID;
            item.SubfolderName = folderName;
            item.ApplyTemplate();
        }

        // Default SL Item Apply for Blue Scrolls
        public static void ApplyBlueScroll(SL_Item scrollTemplate)
        {
            scrollTemplate.SLPackName = Plugin.PACKID;
            scrollTemplate.SubfolderName = "BlueScroll";
            scrollTemplate.ApplyTemplate();
        }

        // ?Default SL Item Apply for Blue Scrolls - GET RID OF - KEEP OVERRIDE
        public static void ApplyRedScroll(SL_Item scrollTemplate)
        {
            scrollTemplate.SLPackName = Plugin.PACKID;
            scrollTemplate.SubfolderName = "RedScroll";
            scrollTemplate.ApplyTemplate();
        }
        // Folder Name Override
        public static void ApplyRedScroll(SL_Item scrollTemplate, string subFolderName)
        {
            // Sets SL template for blue scrolls.
            scrollTemplate.SLPackName = Plugin.PACKID;
            scrollTemplate.SubfolderName = subFolderName;
            scrollTemplate.ApplyTemplate();
        }

        //SL Effect Template Apply
        public static void ApplyEffect(SL_StatusEffect effectName, bool icon)
        {
            effectName.SLPackName = Plugin.PACKID;
            effectName.ApplyTemplate();
            if (icon == true) { effectName.ApplyIcon(); }
        }
        //SL Effect Template Apply Folder Name Override
        public static void ApplyEffect(SL_AttackSkill skillName, string subFolder, bool icon)
        {
            skillName.SLPackName = Plugin.PACKID;
            skillName.SubfolderName = subFolder;
            skillName.ApplyTemplate();
            if (icon == true) { skillName.ApplyIcon(); }
        }
    }
}
