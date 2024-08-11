﻿using SoMRandomizer.config.settings;
using SoMRandomizer.logging;
using SoMRandomizer.processing.common;
using SoMRandomizer.processing.openworld.events;
using System;
using System.Collections.Generic;
using System.Linq;
using static SoMRandomizer.processing.openworld.randomization.OpenWorldSimulator;

namespace SoMRandomizer.processing.openworld.randomization
{
    /// <summary>
    /// Injection of hints for open world.
    /// </summary>
    /// 
    /// <remarks>Author: Moppleton</remarks>
    public class OpenWorldHints
    {
        public const int NUM_NESO_HINTS = 3;
        public const string NESO_PRIZE_PREFIX = "nesoPrize";
        public const string NESO_HINT_PREFIX = "nesoHint";

        public static void addHints(RandoSettings settings, RandoContext context, Dictionary<PrizeLocation, PrizeItem> itemPlacements, SimResult simulationResult)
        {
            Random r = context.randomFunctional;
            string goal = context.workingData.get(OpenWorldGoalProcessor.GOAL_SHORT_NAME);
            Dictionary<int, byte> crystalOrbColorMap = ElementSwaps.getCrystalOrbElementMap(context);
            bool allowMissedItems = settings.getBool(OpenWorldSettings.PROPERTYNAME_ALLOW_MISSED_ITEMS);
            bool randomGrandPalaceElements = settings.getBool(OpenWorldSettings.PROPERTYNAME_RANDOMIZE_GRANDPALACE_ELEMENTS);
            bool suppressHints = settings.getBool(OpenWorldSettings.PROPERTYNAME_NO_HINTS);
            bool anySpellTriggers = context.workingData.getBool(OpenWorldClassSelection.ANY_MAGIC_EXISTS);
            bool giveMoreGrandPalaceHints = goal == OpenWorldGoalProcessor.GOAL_MANABEAST && !context.workingData.getBool(OpenWorldGoalProcessor.MANA_FORT_ACCESSIBLE_INDICATOR);
            bool girlSpellsExist = context.workingData.getBool(OpenWorldClassSelection.GIRL_MAGIC_EXISTS);
            bool spriteSpellsExist = context.workingData.getBool(OpenWorldClassSelection.SPRITE_MAGIC_EXISTS);
            List<string> grandPalaceDependencies = new List<string>();
            List<string> manafortDependencies = new List<string>();
            OpenWorldLocations.populateDependencies(settings, context, grandPalaceDependencies, manafortDependencies);

            List<string> importantPrizes = new string[] { "boy", "boy", "girl", "girl", "sprite", "sprite", "whip", "axe", "sword" }.ToList();
            if (goal == OpenWorldGoalProcessor.GOAL_MTR)
            {
                importantPrizes.Add("water seed");
                importantPrizes.Add("earth seed");
                importantPrizes.Add("wind seed");
                importantPrizes.Add("fire seed");
                importantPrizes.Add("light seed");
                importantPrizes.Add("dark seed");
                importantPrizes.Add("moon seed");
                importantPrizes.Add("dryad seed");
            }

            if (goal == OpenWorldGoalProcessor.GOAL_GIFTMODE)
            {
                for(int i=0; i < 8; i++)
                {
                    string gift = context.workingData.get(OpenWorldLocationPrizeMatcher.GIFT_SELECTION_PREFIX + i);
                    if (gift.Contains("spells") || gift == "moogle belt" || gift == "midge mallet")
                    {
                        importantPrizes.Add(gift);
                    }
                }
            }
            else
            {
                importantPrizes.Add("undine spells");
                importantPrizes.Add("gnome spells");
                importantPrizes.Add("sylphid spells");
                importantPrizes.Add("salamando spells");
                importantPrizes.Add("lumina spells");
                importantPrizes.Add("shade spells");
                importantPrizes.Add("luna spells");
                importantPrizes.Add("dryad spells");
            }

            Dictionary<string, string> nesoHints = new Dictionary<string, string>();
            int nesoHintAttempts = 0;
            while (nesoHints.Count < 3 && nesoHintAttempts < 100)
            {
                string hintPrize = importantPrizes.Count == 0 ? "" : importantPrizes[r.Next() % importantPrizes.Count];
                importantPrizes.Remove(hintPrize);
                foreach (PrizeLocation location in itemPlacements.Keys)
                {
                    if (itemPlacements[location].prizeName == hintPrize)
                    {
                        string nesoHint = location.locationHints[r.Next() % location.locationHints.Length];
                        if (nesoHint != "" && !nesoHints.ContainsKey(hintPrize))
                        {
                            nesoHints[hintPrize] = nesoHint;
                        }
                    }
                }
                nesoHintAttempts++;
            }

            int nesoHintNum = 0;
            foreach(string prize in nesoHints.Keys)
            {
                context.workingData.set(NESO_PRIZE_PREFIX + nesoHintNum, prize);
                context.workingData.set(NESO_HINT_PREFIX + nesoHintNum, nesoHints[prize]);
                nesoHintNum++;
            }

            int[] hintEvents = new int[]
            {
                0x3ce, // krissie northtown
                0x3e9, // mandala orb
                0x3ea, // mandala orb
                0x3eb, // mandala orb
                0x3ec, // mandala orb
                0x3ed, // mandala orb
                0x3ee, // mandala orb
                0x3ef, // mandala orb
                0x37c, // rudolph
                0x555, // dyluck at NT ruins
                0x21c, // flowers guy near witch forest
                0x114, // potos elder
                0x3dd, // jehk
                0x3dc, // johk
                0x2d7, // tasnica king after fight
                0x606, // potos cannon travel sign
                0x607, // water palace neko's sign
                0x608, // beware of goblins sign
                0x600, // three paths sign south of potos
                0x601, // pandora sign
                0x602, // kippo sign
                0x609, // gaia's navel sign
                0x604, // water palace sign
                0x605, // potos forest sign
            };

            string[] hintPhrases = new string[]
            {
                "You can find %1 %2.",
                "Look %2 for %1.",
                "Looking for %1? Check %2.",
                "Location of %1: %2",
                "Recently spotted %2: %1"
            };

            string[] bossHintPhrases = new string[]
                {
                    "In %1's spot? %2!",
                    "Looking for %2? Check in the %1 spot."
                };

            string A = "A  ";
            string _ = "   ";
            string U = VanillaEventUtil.UP_ARROW + "  ";
            string D = VanillaEventUtil.DOWN_ARROW + "  ";
            string L = VanillaEventUtil.LEFT_ARROW + "  ";
            string R = VanillaEventUtil.RIGHT_ARROW + "  ";

            string[] dumbHints = new string[]
            {
                "Blerf?",
                "I normally give hints.  This time, not so much.",
                "Don't forget, Gnome speed-up spell does stuff now.",
                "Fun fact, Shade's evil-gate works on bosses now!",
                "I just want to tell you both good luck.  We're all counting on you.",
                // mitch
                "I'm against picketing, but I don't know how to show it.",
                "I haven't slept for ten days, because that would be too long.",
                "I used to do drugs.  I still do, but I used to, too.",
                // ocarina
                "Play the Song of Storms:\n" +
                "     " + _ + _ + U + _ + _ + U + "\n" +
                "     " + A + D + _ + A + D + _,

                "Play Zelda's Lullaby:\n" +
                "     " + L + U + R + L + U + R + "\n" +
                "     " + _ + _ + _ + _ + _ + _,

                "Play Epona's Song:\n" +
                "     " + U + L + R + U + L + R + "\n" +
                "     " + _ + _ + _ + _ + _ + _,

                "Play Saria's Song:\n" +
                "     " + _ + R + L + _ + R + L + "\n" +
                "     " + D + _ + _ + D + _ + _,

                "Play Sun's Song:\n" +
                "     " + R + _ + U + R + _ + U + "\n" +
                "     " + _ + D + _ + _ + D + _,

                "Play the Song of Time:\n" +
                "     " + R + _ + _ + R + _ + _ + "\n" +
                "     " + _ + A + D + _ + A + D,

                "In open world, shops will only show gear as usable if it's an improvement over your current gear.",
                "Shoutouts to SimpleFlips",
                "Armor is more important than you think it is",
                "There are 16 total shops in the game!",
                "30 Extra lives:\n " +
                VanillaEventUtil.UP_ARROW + " " + VanillaEventUtil.UP_ARROW + " " +
                VanillaEventUtil.DOWN_ARROW + " " + VanillaEventUtil.DOWN_ARROW + " " +
                VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + " " +
                VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + "\n" + " B A Start",
                "Hadouken:\n" + " " + VanillaEventUtil.DOWN_ARROW + " " + VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + " A",
                "Shoryuken:\n" + " " + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.DOWN_ARROW + " " + VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.RIGHT_ARROW + " A",
                "Sonic Boom:\n" + " " + VanillaEventUtil.LEFT_ARROW + VanillaEventUtil.LEFT_ARROW + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + " A",
                "Sabin's Pummel:\n" + " " + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.LEFT_ARROW + " A",
                "Sabin's Aurabolt:\n" + " " + VanillaEventUtil.DOWN_ARROW + " " + VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.LEFT_ARROW + " A",
                "Sabin's Suplex:\n" + " X Y " + VanillaEventUtil.DOWN_ARROW + " " + VanillaEventUtil.UP_ARROW + " A",
                "Sabin's Fire Dance:\n" + " " + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.LEFT_ARROW + " " +
                VanillaEventUtil.DOWN_ARROW + " " + VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + " A",
                "Sabin's Mantra:\n" + " R L R L X Y A",
                "Sabin's Air Blade:\n" + " " + VanillaEventUtil.UP_ARROW + " " + VanillaEventUtil.UP_ARROW + VanillaEventUtil.RIGHT_ARROW + " " +
                VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.DOWN_ARROW + " " +
                VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.LEFT_ARROW +" A",
                "Sabin's Spiraler:\n" + " R L X Y " + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.LEFT_ARROW + " A",
                "Sabin's Bum Rush:\n" + " " + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.UP_ARROW + VanillaEventUtil.LEFT_ARROW + " " +
                VanillaEventUtil.UP_ARROW + " " + VanillaEventUtil.UP_ARROW + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.RIGHT_ARROW + " " +
                VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.RIGHT_ARROW + " " + VanillaEventUtil.DOWN_ARROW + " " +
                VanillaEventUtil.DOWN_ARROW + VanillaEventUtil.LEFT_ARROW + " " + VanillaEventUtil.LEFT_ARROW + " A",
                "Check in clocks for free elixirs!",
                "Dodongo dislikes smoke",
            };

            List<string> hintedPrizes = new List<string>();
            bool gaveFirePalaceHint = false;
            bool gaveMechRider3Hint = false;
            bool gaveTotalElementsHint = !randomGrandPalaceElements;
            int grandPalaceHintChance = 5;
            if (giveMoreGrandPalaceHints)
            {
                grandPalaceHintChance = 3;
            }
            foreach (int hintEvent in hintEvents)
            {
                int hintType = suppressHints ? 100 : (r.Next() % 100);
                // normal, useful hint
                if (hintType < 80)
                {
                    // a few specific ones
                    bool specialHint = (r.Next() % 5) == 0;
                    if (specialHint && !gaveFirePalaceHint && hintExistsForLocation(itemPlacements, "fire seed"))
                    {
                        string hintPhrase = "Fire palace final prize: " + getHintForLocation(itemPlacements, "fire seed");
                        hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                        VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                        gaveFirePalaceHint = true;
                        Logging.log("Adding (useful) hint: " + hintPhrase, "spoiler");
                    }
                    else if (specialHint && !gaveMechRider3Hint)
                    {
                        string hintPhrase = "Mech rider 3 prize: " + getHintForLocation(itemPlacements, "mech rider 3 (new item)");
                        hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                        VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                        gaveMechRider3Hint = true;
                        Logging.log("Adding (useful) hint: " + hintPhrase, "spoiler");
                    }
                    else if (specialHint && !gaveTotalElementsHint && anySpellTriggers)
                    {
                        HashSet<byte> uniqueElementsList = new HashSet<byte>();
                        int[] grandPalaceOrbMaps = new int[] { 420, 421, 422, 423, 424, 425, 426 };
                        foreach(int orbMap in grandPalaceOrbMaps)
                        {
                            uniqueElementsList.Add(crystalOrbColorMap[orbMap]);
                        }
                        string hintPhrase = "Total elements needed for grand palace: " + uniqueElementsList.Count;
                        hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                        VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                        gaveTotalElementsHint = true;
                        Logging.log("Adding (useful) hint: " + hintPhrase, "spoiler");
                    }
                    else if (randomGrandPalaceElements && (girlSpellsExist || spriteSpellsExist) && (r.Next() % grandPalaceHintChance) == 0)
                    {
                        HashSet<byte> validElements = new HashSet<byte>();
                        if (girlSpellsExist)
                        {
                            validElements.Add(0x83); // sala
                            validElements.Add(0x84); // lumina
                            validElements.Add(0x85); // sylphid
                        }
                        if (spriteSpellsExist)
                        {
                            // everything but lumina
                            validElements.Add(0x81);
                            validElements.Add(0x82);
                            validElements.Add(0x83);
                            validElements.Add(0x85);
                            validElements.Add(0x86);
                            validElements.Add(0x87);
                            validElements.Add(0x88);
                        }
                        byte eleNum = (byte)(0x81 + (r.Next() % 8));
                        int safety = 0;
                        while (safety < 100 && !validElements.Contains(eleNum))
                        {
                            eleNum = (byte)(0x81 + (r.Next() % 8));
                        }
                        string dependency = SomVanillaValues.elementOrbByteToName(eleNum, false) + " spells";
                        if (!grandPalaceDependencies.Contains(dependency))
                        {
                            string hintPhrase = "Not needed for grand palace: " + SomVanillaValues.elementOrbByteToName(eleNum, false);
                            hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                            VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                            Logging.log("Adding (useful) hint: " + hintPhrase, "spoiler");
                        }
                        else
                        {
                            string hintPhrase = "Needed for grand palace: " + SomVanillaValues.elementOrbByteToName(eleNum, false);
                            hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                            VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                            Logging.log("Adding (useful) hint: " + hintPhrase, "spoiler");
                        }
                    }
                    else
                    {
                        // treasure location
                        string hintPhrase = hintPhrases[r.Next() % hintPhrases.Length];
                        List<PrizeLocation> keys = Enumerable.ToList(itemPlacements.Keys);
                        PrizeLocation location = keys[r.Next() % keys.Count];
                        string prize = itemPlacements[location].prizeName;
                        int i = 0; // safety
                        if (prize.Contains("seed"))
                        {
                            // reroll once, these are less useful
                            location = keys[r.Next() % keys.Count];
                            prize = itemPlacements[location].prizeName;
                        }
                        while (i < 100 && (prize.Contains("starter weapon") || prize.Contains("nothing") || prize.Contains("orb") || prize.Contains("GP") || hintedPrizes.Contains(prize)))
                        {
                            // reroll
                            location = keys[r.Next() % keys.Count];
                            prize = itemPlacements[location].prizeName;
                            i++;
                        }

                        hintedPrizes.Add(prize);
                        string hintLoc = location.locationHints[r.Next() % location.locationHints.Length];
                        if (allowMissedItems)
                        {
                            bool visitedLocation = false;
                            foreach (List<string> cycleLocations in simulationResult.collectionCycles)
                            {
                                foreach (string loc in cycleLocations)
                                {
                                    if (loc == location.locationName)
                                    {
                                        visitedLocation = true;
                                        break;
                                    }
                                }
                            }
                            if (!visitedLocation)
                            {
                                hintLoc = "nowhere";
                            }
                        }
                        hintPhrase = hintPhrase.Replace("%1", itemPlacements[location].hintName);
                        hintPhrase = hintPhrase.Replace("%2", hintLoc);
                        Logging.log("Adding (useful) hint: " + hintPhrase, "spoiler");
                        hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                        VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                    }
                }
                else
                {
                    // mostly useless hint
                    string hintPhrase = dumbHints[r.Next() % dumbHints.Length];
                    Logging.log("Adding (useless) hint: " + hintPhrase, "spoiler");
                    hintPhrase = VanillaEventUtil.wordWrapText(hintPhrase);
                    VanillaEventUtil.replaceEventData(HintEvents.OPENWORLD_HINT_INJECTION_PATTERN.ToList(), context.replacementEvents[hintEvent], VanillaEventUtil.getBytes(hintPhrase));
                }
            }
        }

        private static bool hintExistsForLocation(Dictionary<PrizeLocation, PrizeItem> itemPlacements, string locName)
        {
            foreach(PrizeLocation loc in itemPlacements.Keys)
            {
                if (loc.locationName == locName)
                {
                    return true;
                }
            }
            return false;
        }
        private static string getHintForLocation(Dictionary<PrizeLocation, PrizeItem> itemPlacements, string locName)
        {
            foreach(PrizeLocation loc in itemPlacements.Keys)
            {
                if(loc.locationName == locName)
                {
                    return itemPlacements[loc].hintName;
                }
            }
            return "";
        }
    }
}