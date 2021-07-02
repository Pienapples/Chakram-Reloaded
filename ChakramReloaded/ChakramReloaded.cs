using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using UnityEngine;
using SideLoader;

namespace ChakramReloaded
{
    [BepInPlugin(ID, NAME, VERSION)]
    public class ChakramReloaded : BaseUnityPlugin
    {
        const string ID = "com.pienapple.chakramreloaded";
        const string NAME = "Chakram Reloaded";
        const string VERSION = "1.0.1";

        public static SkillConfig chakramPierce;
        public static SkillConfig chakramArc;
        public static SkillConfig chakramDance;

        internal void Awake()
        {
            // Skill ID, Name of Skill, Default Mana Cost, Default Cooldown, Default Boon Requirement true(enabled) false(disabled)
            chakramPierce = new SkillConfig(Config, 8100250, "Chakram Pierce", 3f, 2.5f, false);
            chakramArc = new SkillConfig(Config, 8100252, "Chakram Arc", 4f, 6f, false);
            chakramDance = new SkillConfig(Config, 8100251, "Chakram Dance", 10f, 60f, false);
        }
    }
}
