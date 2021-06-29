using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using UnityEngine;
using SideLoader;

namespace ChakramLove
{
    [BepInPlugin(ID, NAME, VERSION)]
    public class ChakramLove : BaseUnityPlugin
    {
        const string ID = "com.pienapple.chakramlove";
        const string NAME = "Chakram Love";
        const string VERSION = "1.0";

        static ConfigEntry<float> cooldownPierce;
        static ConfigEntry<float> manaCostPierce;
        static ConfigEntry<float> cooldownArc;
        static ConfigEntry<float> manaCostArc;
        static ConfigEntry<float> cooldownDance;
        static ConfigEntry<float> manaCostDance;
        static ConfigEntry<bool> removeDisciplineRequirement;

        internal void Awake()
        {
            // Chakram Pierce Configuration
            cooldownPierce = Config.Bind("Chakram Pierce",
                                   "Cooldown",
                                   3f,
                                   "The cooldown for the Chakram Pierce skill (Requires Game Restart");
            manaCostPierce = Config.Bind("Chakram Pierce",
                                   "Mana Cost",
                                   2.5f,
                                   "The mana cost for the Chakram Pierce skill (Requires Game Restart");
            removeDisciplineRequirement = Config.Bind("Chakram Pierce",
                                                      "Disable Discipline Boon Requirement",
                                                      true,
                                                      "Disable Discipline Boon for the Chakram Pierce skill (Requires Game Restart)");

            // Chakram Arc Configuration
            cooldownArc = Config.Bind("Chakram Arc",
                                   "Cooldown",
                                   6f,
                                   "The cooldown for the Chakram Arc skill (Requires Game Restart");
            manaCostArc = Config.Bind("Chakram Arc",
                                   "Mana Cost",
                                   4f,
                                   "The mana cost for the Chakram Arc skill (Requires Game Restart");
            removeDisciplineRequirement = Config.Bind("Chakram Arc",
                                                      "Disable Discipline Boon Requirement",
                                                      true,
                                                      "Disable Discipline Boon for the Chakram Arc skill (Requires Game Restart)");

            // Chakram Dance Configuration
            cooldownDance = Config.Bind("Chakram Dance",
                                   "Cooldown",
                                   60f,
                                   "The cooldown for the Chakram Dance skill (Requires Game Restart");
            manaCostDance = Config.Bind("Chakram Dance",
                                   "Mana Cost",
                                   10f,
                                   "The mana cost for the Chakram Dance skill (Requires Game Restart");
            removeDisciplineRequirement = Config.Bind("Chakram Dance",
                                                      "Disable Discipline Boon Requirement",
                                                      true,
                                                      "Disable Discipline Boon for the Chakram Dance skill (Requires Game Restart)");

            // Chakram Pierce Value and Requirement
            var pierce = new SL_MeleeSkill
            {
                Target_ItemID = 8100250,
                Cooldown = cooldownPierce.Value,
                ManaCost = manaCostPierce.Value,
            };

            if (removeDisciplineRequirement.Value)
            {
                pierce.EffectBehaviour = EditBehaviours.Override;
                pierce.EffectTransforms = new[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "AdditionalActivationConditions",
                        EffectConditions = new SL_EffectCondition[0]
                    }
                };
            }

            // Chakram Arc Value and Requirement
            var arc = new SL_MeleeSkill
            {
                Target_ItemID = 8100252,
                Cooldown = cooldownArc.Value,
                ManaCost = manaCostArc.Value,
            };

            if (removeDisciplineRequirement.Value)
            {
                arc.EffectBehaviour = EditBehaviours.Override;
                arc.EffectTransforms = new[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "AdditionalActivationConditions",
                        EffectConditions = new SL_EffectCondition[0]
                    }
                };
            }

            // Chakram Dance Value and Requirement
            var dance = new SL_MeleeSkill
            {
                Target_ItemID = 8100251,
                Cooldown = cooldownDance.Value,
                ManaCost = manaCostDance.Value,
            };

            if (removeDisciplineRequirement.Value)
            {
                dance.EffectBehaviour = EditBehaviours.Override;
                dance.EffectTransforms = new[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "AdditionalActivationConditions",
                        EffectConditions = new SL_EffectCondition[0]
                    }
                };
            }
            pierce.ApplyTemplate();
            arc.ApplyTemplate();
            dance.ApplyTemplate();
        }
    }
}
