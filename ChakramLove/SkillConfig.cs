using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using BepInEx.Configuration;
using SideLoader;

namespace ChakramReloaded
{
    public class SkillConfig
    {
        public ConfigEntry<float> manaCost, cooldown;   // Define float values used in the config
        public ConfigEntry<bool> requireDiscipline;     // Define the boolean used in the config

        public SkillConfig(ConfigFile config, int itemID, string name, float defaultManaCost, float defaultCooldown, bool defaultReqDiscipline)
        {
            // Title of Configuration, Descriptor, Float Value, Hover Tip
            this.manaCost = config.Bind(name, "Mana Cost", defaultManaCost, $"The mana cost for {name} skill. (Requires Game Restart!)");
            this.cooldown = config.Bind(name, "Cooldown", defaultCooldown, $"The cooldown for {name} skill. (Requires Game Restart!)");
            this.requireDiscipline = config.Bind(name, "Disable Discipline Requirement", defaultReqDiscipline, $"Disable discipline boon requirement for {name} skill. (Requires Game Restart!");

            new SL_Skill()
            {
                Target_ItemID = itemID,     // Skill ID
                Cooldown = cooldown.Value,      // Skill Cooldown
                ManaCost = manaCost.Value,      // Skill Mana Cost
                EffectBehaviour = EditBehaviours.Override,      // Override the Effects
                EffectTransforms = requireDiscipline.Value
                ? null
                : new SL_EffectTransform[]
                {
                    new SL_EffectTransform()
                    {
                        TransformName = "AdditionalActivationConditions",       // Effect name for Discipline Requirement
                        EffectConditions = new SL_EffectCondition[0],       // Setting the Value of Discipline Boon Requirement 0(disabled) 1(enabled)
                    }
                }
            }.ApplyTemplate();
        }
    }
}
