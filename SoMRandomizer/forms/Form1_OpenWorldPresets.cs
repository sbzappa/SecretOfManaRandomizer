﻿using SoMRandomizer.config.settings;
using System.Collections.Generic;
using System.Windows.Forms;
using static SoMRandomizer.forms.PresetsForm;

namespace SoMRandomizer.forms
{
    // parts of Form1 related to presets for open world mode.
    public partial class Form1
    {
        private void makeOpenWorldPresets()
        {
            // /////////////////////////////
            // Mystery seeds
            List<Preset> openWorldPresets = new List<Preset>();
            Preset surpriseSeed_title = new Preset();
            surpriseSeed_title.separatorOnly = true;
            surpriseSeed_title.name = "Mystery seeds";
            surpriseSeed_title.fontSizeChange = 3;
            openWorldPresets.Add(surpriseSeed_title);

            Preset surpriseSeed_subtitle = new Preset();
            surpriseSeed_subtitle.separatorOnly = true;
            surpriseSeed_subtitle.name = "Mystery open world with settings chosen at random. A seed should be chosen on the main window before using these, as it determines values of any randomly chosen settings.";
            openWorldPresets.Add(surpriseSeed_subtitle);

            // /////////////////////////////
            // mystery seed - moderate difficulty
            Preset surpriseSeed = new Preset();
            surpriseSeed.name = "Mystery seed";
            surpriseSeed.description = "A mystery open world with randomly chosen, fairly-reasonable settings.";
            surpriseSeed.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Stats: Match player or bosses\n" +
                "Difficulty: Sorta easy -> Sorta hard\n" +
                "Gold/Exp: 1x, 2x, 3x\n" +
                "Start character: any\n" +
                "Other characters: various settings\n" +
                "Enemies: Swap, or random spawns\n" +
                "Bosses: Swap, or random\n" +
                "Logic: Basic, Restrictive\n" +
                "Goal: Vanilla short/long, MTR\n" +
                "MTR Mana seeds required 3-7\n" +
                "Chest traps: normal, none, many\n" +
                "Chest frequency: low, normal, high, highest\n" +
                "Status ailments: Location, enemy, or random easy\n"
            ;
            surpriseSeed.tabNameSelections[tabControl1] = new string[] { "Open" };
            // 13 - stat growth
            surpriseSeed.comboBoxSelections[comboBox13] = new string[] { "Match player", "Increase after bosses" };
            // 14 - difficulty
            surpriseSeed.comboBoxSelections[comboBox14] = new string[] { "Sorta easy", "Normal", "Normal", "Kinda hard" };
            // 15 - gold
            surpriseSeed.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER)] = new double[] { 1, 2, 2, 3 };
            // 16 - experience
            surpriseSeed.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER)] = new double[] { 1, 2, 2, 3 };
            // 19 - other chars
            surpriseSeed.comboBoxSelections[comboBox19] = new string[] { "Find both at level 1", "Find both at current level", "Start with one, find the other", "Start with one, other doesn't exist", "Find one at current level", "They don't exist" };
            // 20 - status ailments
            surpriseSeed.comboBoxSelections[comboBox20] = new string[] { "Location", "Enemy type", "Random (easy)" };
            // 21 - goal
            surpriseSeed.comboBoxSelections[comboBox21] = new string[] { "Vanilla short", "Vanilla long", "Mana tree revival" };
            // 22 - enemy swap type
            surpriseSeed.comboBoxSelections[comboBox22] = new string[] { "Swap", "Swap", "Swap", "Random spawns" };
            // 25 - bosses
            surpriseSeed.comboBoxSelections[comboBox25] = new string[] { "Swap", "Random" };
            // 26 - logic
            surpriseSeed.comboBoxSelections[comboBox26] = new string[] { "Basic", "Restrictive" };
            // 27 - start char
            surpriseSeed.comboBoxSelections[comboBox27] = new string[] { "Boy", "Girl", "Sprite" };
            // random map colors
            surpriseSeed.checkBoxSelections[checkBox37] = new bool[] { true, false };
            surpriseSeed.checkBoxSelections[checkBox39] = new bool[] { true, false, false }; // flammie drum in logic
            surpriseSeed.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED)] = new string[] { "Random" };
            surpriseSeed.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN)] = new string[] { "3" };
            surpriseSeed.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX)] = new string[] { "7" };
            // PROPERTYNAME_CHEST_TRAPS
            surpriseSeed.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS)] = new string[] { "Normal", "None", "Many" };
            // PROPERTYNAME_CHEST_FREQUENCY
            surpriseSeed.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY)] = new string[] { "Low", "Normal", "High", "Highest" };
            surpriseSeed.mainForm = this;
            surpriseSeed.hideUi = true;
            openWorldPresets.Add(surpriseSeed);

            // /////////////////////////////
            // mystery seed - casual
            Preset surpriseSeedEasy = new Preset();
            surpriseSeedEasy.name = "Mystery seed - casual";
            surpriseSeedEasy.description = "A mystery open world with randomly chosen, relatively easy settings.";
            surpriseSeedEasy.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Stats: Match player or bosses\n" +
                "Difficulty: Easy -> Normal\n" +
                "Gold/Exp: 3x\n" +
                "Start character: any\n" +
                "Other characters: various settings\n" +
                "Enemies: Swap, or random spawns\n" +
                "Bosses: Swap, or random\n" +
                "Logic: Basic, Restrictive\n" +
                "Goal: Vanilla short/long, MTR\n" +
                "MTR Mana seeds required 3-7\n" +
                "Chest traps: normal, none\n" +
                "Chest frequency: high, highest\n" +
                "Status ailments: Location, enemy\n"
            ;
            surpriseSeedEasy.tabNameSelections[tabControl1] = new string[] { "Open" };
            // 13 - stat growth
            surpriseSeedEasy.comboBoxSelections[comboBox13] = new string[] { "Match player", "Increase after bosses" };
            // 14 - difficulty
            surpriseSeedEasy.comboBoxSelections[comboBox14] = new string[] { "Easy", "Sorta easy", "Normal" };
            // 15 - gold
            surpriseSeedEasy.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER)] = new double[] { 3 };
            // 16 - experience
            surpriseSeedEasy.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER)] = new double[] { 3 };
            // 19 - other chars
            surpriseSeedEasy.comboBoxSelections[comboBox19] = new string[] { "Find both at level 1", "Find both at current level", "Start with one, find the other", "Start with both" };
            // 20 - status ailments
            surpriseSeedEasy.comboBoxSelections[comboBox20] = new string[] { "Location", "Enemy type" };
            // 21 - goal
            surpriseSeedEasy.comboBoxSelections[comboBox21] = new string[] { "Vanilla short", "Vanilla long", "Mana tree revival" };
            // 22 - enemy swap type
            surpriseSeedEasy.comboBoxSelections[comboBox22] = new string[] { "Swap", "Swap", "Swap", "Random spawns" };
            // 25 - bosses
            surpriseSeedEasy.comboBoxSelections[comboBox25] = new string[] { "Swap", "Random" };
            // 26 - logic
            surpriseSeedEasy.comboBoxSelections[comboBox26] = new string[] { "Basic", "Restrictive" };
            // 27 - start char
            surpriseSeedEasy.comboBoxSelections[comboBox27] = new string[] { "Boy", "Girl", "Sprite" };
            // random map colors
            surpriseSeedEasy.checkBoxSelections[checkBox37] = new bool[] { true, false };
            surpriseSeedEasy.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED)] = new string[] { "Random" };
            surpriseSeedEasy.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN)] = new string[] { "3" };
            surpriseSeedEasy.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX)] = new string[] { "7" };
            surpriseSeedEasy.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS)] = new string[] { "Normal", "None" };
            surpriseSeedEasy.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY)] = new string[] { "High", "Highest" };
            surpriseSeedEasy.mainForm = this;
            surpriseSeedEasy.hideUi = true;
            openWorldPresets.Add(surpriseSeedEasy);

            // /////////////////////////////
            // mystery seed - hard
            Preset surpriseSeedHard = new Preset();
            surpriseSeedHard.name = "Mystery seed - hard";
            surpriseSeedHard.description = "A mystery open world with randomly chosen, relatively difficult settings.";
            surpriseSeedHard.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Stats: Match player, bosses, or timed\n" +
                "Difficulty: Normal -> Hard\n" +
                "Gold/Exp: 1x, 2x\n" +
                "Start character: any\n" +
                "Other characters: various settings\n" +
                "Enemies: Swap, or random spawns\n" +
                "Bosses: Swap, or random\n" +
                "Logic: Basic, Restrictive\n" +
                "Goal: Vanilla short/long, MTR\n" +
                "MTR Mana seeds required 3-7\n" +
                "Chest traps: normal, many\n" +
                "Chest frequency: low, normal\n" +
                "Status ailments: Location, enemy, easy->awful\n"
            ;
            surpriseSeedHard.tabNameSelections[tabControl1] = new string[] { "Open" };
            // 13 - stat growth
            surpriseSeedHard.comboBoxSelections[comboBox13] = new string[] { "Match player", "Increase after bosses", "Timed" };
            // 14 - difficulty
            surpriseSeedHard.comboBoxSelections[comboBox14] = new string[] { "Normal", "Kinda hard", "Hard" };
            // 15 - gold
            surpriseSeedHard.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER)] = new double[] { 1, 2 };
            // 16 - experience
            surpriseSeedHard.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER)] = new double[] { 1, 2 };
            // 19 - other chars
            surpriseSeedHard.comboBoxSelections[comboBox19] = new string[] { "Find both at level 1", "Find one at level 1", "They don't exist" };
            // 20 - status ailments
            surpriseSeedHard.comboBoxSelections[comboBox20] = new string[] { "Location", "Enemy type", "Random (easy)", "Random (annoying)", "Random (awful)" };
            // 21 - goal
            surpriseSeedHard.comboBoxSelections[comboBox21] = new string[] { "Vanilla short", "Vanilla long", "Mana tree revival" };
            // 22 - enemy swap type
            surpriseSeedHard.comboBoxSelections[comboBox22] = new string[] { "Swap", "Swap", "Swap", "Random spawns" };
            // 25 - bosses
            surpriseSeedHard.comboBoxSelections[comboBox25] = new string[] { "Swap", "Random" };
            // 26 - logic
            surpriseSeedHard.comboBoxSelections[comboBox26] = new string[] { "Basic", "Restrictive" };
            // 27 - start char
            surpriseSeedHard.comboBoxSelections[comboBox27] = new string[] { "Boy", "Girl", "Sprite" };
            // random map colors
            surpriseSeedHard.checkBoxSelections[checkBox37] = new bool[] { true, false };
            surpriseSeedHard.checkBoxSelections[checkBox39] = new bool[] { true, false }; // flammie drum in logic
            surpriseSeedHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED)] = new string[] { "Random" };
            surpriseSeedHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN)] = new string[] { "3" };
            surpriseSeedHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX)] = new string[] { "7" };
            // PROPERTYNAME_CHEST_TRAPS
            surpriseSeedHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS)] = new string[] { "Normal", "Many" };
            // PROPERTYNAME_CHEST_FREQUENCY
            surpriseSeedHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY)] = new string[] { "Low", "Normal" };
            surpriseSeedHard.mainForm = this;
            surpriseSeedHard.hideUi = true;
            openWorldPresets.Add(surpriseSeedHard);



            // /////////////////////////////
            // MTR mystery seeds
            Preset surpriseMtrSeed_title = new Preset();
            surpriseMtrSeed_title.separatorOnly = true;
            surpriseMtrSeed_title.name = "Mystery seeds - Mana Tree Revival";
            surpriseMtrSeed_title.fontSizeChange = 3;
            openWorldPresets.Add(surpriseMtrSeed_title);

            Preset surpriseMtrSeed_subtitle = new Preset();
            surpriseMtrSeed_subtitle.separatorOnly = true;
            surpriseMtrSeed_subtitle.name = "Mystery \"Mana tree revival\" with settings chosen at random. A seed should be chosen on the main window before using these, as it determines values of any randomly chosen settings.";
            openWorldPresets.Add(surpriseMtrSeed_subtitle);

            // /////////////////////////////
            // mystery seed - MTR normal difficulty
            Preset surpriseMtrSeedNormal = new Preset();
            surpriseMtrSeedNormal.name = "Mystery MTR seed";
            surpriseMtrSeedNormal.description = "A mystery mana tree revival with randomly chosen, fairly-reasonable settings.";
            surpriseMtrSeedNormal.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Stats: Match player or bosses\n" +
                "Difficulty: Sorta easy -> Sorta hard\n" +
                "Gold/Exp: 1x, 2x, 3x\n" +
                "Start character: any\n" +
                "Other characters: various settings\n" +
                "Enemies: Swap, or random spawns\n" +
                "Bosses: Swap, or random\n" +
                "Logic: Basic, Restrictive\n" +
                "Goal: MTR\n" +
                "MTR Mana seeds required 3-7\n" +
                "Chest traps: normal, none, many\n" +
                "Chest frequency: low, normal, high, highest\n" +
                "Status ailments: Location, enemy, or random easy\n"
            ;
            surpriseMtrSeedNormal.tabNameSelections[tabControl1] = new string[] { "Open" };
            // 13 - stat growth
            surpriseMtrSeedNormal.comboBoxSelections[comboBox13] = new string[] { "Match player", "Increase after bosses" };
            // 14 - difficulty
            surpriseMtrSeedNormal.comboBoxSelections[comboBox14] = new string[] { "Sorta easy", "Normal", "Normal", "Kinda hard" };
            // 15 - gold
            surpriseMtrSeedNormal.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER)] = new double[] { 1, 2, 2, 3 };
            // 16 - experience
            surpriseMtrSeedNormal.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER)] = new double[] { 1, 2, 2, 3 };
            // 19 - other chars
            surpriseMtrSeedNormal.comboBoxSelections[comboBox19] = new string[] { "Find both at level 1", "Find both at current level", "Start with one, find the other", "Start with one, other doesn't exist", "Find one at current level", "They don't exist" };
            // 20 - status ailments
            surpriseMtrSeedNormal.comboBoxSelections[comboBox20] = new string[] { "Location", "Enemy type", "Random (easy)" };
            // 21 - goal
            surpriseMtrSeedNormal.comboBoxSelections[comboBox21] = new string[] { "Mana tree revival" };
            // 22 - enemy swap type
            surpriseMtrSeedNormal.comboBoxSelections[comboBox22] = new string[] { "Swap", "Swap", "Swap", "Random spawns" };
            // 25 - bosses
            surpriseMtrSeedNormal.comboBoxSelections[comboBox25] = new string[] { "Swap", "Random" };
            // 26 - logic
            surpriseMtrSeedNormal.comboBoxSelections[comboBox26] = new string[] { "Basic", "Restrictive" };
            // 27 - start char
            surpriseMtrSeedNormal.comboBoxSelections[comboBox27] = new string[] { "Boy", "Girl", "Sprite" };
            // random map colors
            surpriseMtrSeedNormal.checkBoxSelections[checkBox37] = new bool[] { true, false };
            surpriseMtrSeedNormal.checkBoxSelections[checkBox39] = new bool[] { true, false, false }; // flammie drum in logic
            surpriseMtrSeedNormal.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED)] = new string[] { "Random" };
            surpriseMtrSeedNormal.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN)] = new string[] { "3" };
            surpriseMtrSeedNormal.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX)] = new string[] { "7" };
            surpriseMtrSeedNormal.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS)] = new string[] { "Normal", "None", "Many" };
            surpriseMtrSeedNormal.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY)] = new string[] { "Low", "Normal", "High", "Highest" };
            surpriseMtrSeedNormal.mainForm = this;
            surpriseMtrSeedNormal.hideUi = true;
            openWorldPresets.Add(surpriseMtrSeedNormal);


            // /////////////////////////////
            // mystery seed - quick
            Preset surpriseMtrSeedQuick = new Preset();
            surpriseMtrSeedQuick.name = "Mystery MTR seed - quick";
            surpriseMtrSeedQuick.description = "A mystery mana tree revival with randomly chosen settings meant for quick, easy runs.";
            surpriseMtrSeedQuick.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Stats: Match player or bosses\n" +
                "Difficulty: Easy -> Normal\n" +
                "Complexity: Easy\n" +
                "Gold/Exp: 3x\n" +
                "Start character: any\n" +
                "Other characters: various settings\n" +
                "Enemies: Swap, or random spawns\n" +
                "Bosses: Swap, or random\n" +
                "Logic: Basic\n" +
                "Goal: MTR\n" +
                "MTR Mana seeds required 2-4\n" +
                "Chest traps: normal, none\n" +
                "Chest frequency: high, highest\n" +
                "Status ailments: Location, enemy\n"
            ;
            surpriseMtrSeedQuick.tabNameSelections[tabControl1] = new string[] { "Open" };
            // 13 - stat growth
            surpriseMtrSeedQuick.comboBoxSelections[comboBox13] = new string[] { "Match player", "Increase after bosses" };
            // 14 - difficulty
            surpriseMtrSeedQuick.comboBoxSelections[comboBox14] = new string[] { "Easy", "Sorta easy", "Normal" };
            surpriseMtrSeedQuick.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_COMPLEXITY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_COMPLEXITY)] = new string[] { "Easy" };
            // 15 - gold
            surpriseMtrSeedQuick.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER)] = new double[] { 3 };
            // 16 - experience
            surpriseMtrSeedQuick.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER)] = new double[] { 3 };
            // 19 - other chars
            surpriseMtrSeedQuick.comboBoxSelections[comboBox19] = new string[] { "Find both at level 1", "Find both at current level", "Start with one, find the other", "Start with both" };
            // 20 - status ailments
            surpriseMtrSeedQuick.comboBoxSelections[comboBox20] = new string[] { "Location", "Enemy type" };
            // 21 - goal
            surpriseMtrSeedQuick.comboBoxSelections[comboBox21] = new string[] { "Mana tree revival" };
            // 22 - enemy swap type
            surpriseMtrSeedQuick.comboBoxSelections[comboBox22] = new string[] { "Swap", "Swap", "Swap", "Random spawns" };
            // 25 - bosses
            surpriseMtrSeedQuick.comboBoxSelections[comboBox25] = new string[] { "Swap", "Random" };
            // 26 - logic
            surpriseMtrSeedQuick.comboBoxSelections[comboBox26] = new string[] { "Basic" };
            // 27 - start char
            surpriseMtrSeedQuick.comboBoxSelections[comboBox27] = new string[] { "Boy", "Girl", "Sprite" };
            // random map colors
            surpriseMtrSeedQuick.checkBoxSelections[checkBox37] = new bool[] { true, false };
            surpriseMtrSeedQuick.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED)] = new string[] { "Random" };
            surpriseMtrSeedQuick.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN)] = new string[] { "2" };
            surpriseMtrSeedQuick.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX)] = new string[] { "4" };
            surpriseMtrSeedQuick.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS)] = new string[] { "Normal", "None" };
            surpriseMtrSeedQuick.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY)] = new string[] { "High", "Highest" };
            surpriseMtrSeedQuick.mainForm = this;
            surpriseMtrSeedQuick.hideUi = true;
            openWorldPresets.Add(surpriseMtrSeedQuick);


            // /////////////////////////////
            // mystery seed - MTR long
            Preset surpriseSeedMtrHard = new Preset();
            surpriseSeedMtrHard.name = "Mystery MTR seed - long";
            surpriseSeedMtrHard.description = "A mystery mana tree revival with randomly chosen settings meant for longer, more difficult runs.";
            surpriseSeedMtrHard.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Stats: Match player, bosses, or timed\n" +
                "Difficulty: Normal -> Hard\n" +
                "Gold/Exp: 1x, 2x\n" +
                "Start character: any\n" +
                "Other characters: various settings\n" +
                "Enemies: Swap, or random spawns\n" +
                "Bosses: Swap, or random\n" +
                "Logic: Restrictive\n" +
                "Goal: MTR\n" +
                "MTR Mana seeds required 5-7\n" +
                "Chest traps: normal, many\n" +
                "Chest frequency: low, normal\n" +
                "Status ailments: Location, enemy, easy->awful\n"
            ;
            surpriseSeedMtrHard.tabNameSelections[tabControl1] = new string[] { "Open" };
            // 13 - stat growth
            surpriseSeedMtrHard.comboBoxSelections[comboBox13] = new string[] { "Match player", "Increase after bosses", "Timed" };
            // 14 - difficulty
            surpriseSeedMtrHard.comboBoxSelections[comboBox14] = new string[] { "Normal", "Kinda hard", "Hard" };
            surpriseSeedMtrHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_COMPLEXITY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_COMPLEXITY)] = new string[] { "Hard" };
            // 15 - gold
            surpriseSeedMtrHard.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_GOLD_MULTIPLIER)] = new double[] { 1, 2 };
            // 16 - experience
            surpriseSeedMtrHard.numericUpDownSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER).getPropertyUpDown(OpenWorldSettings.PROPERTYNAME_OPEN_WORLD_EXP_MULTIPLIER)] = new double[] { 1, 2 };
            // 19 - other chars
            surpriseSeedMtrHard.comboBoxSelections[comboBox19] = new string[] { "Find both at level 1", "Find one at level 1", "They don't exist" };
            // 20 - status ailments
            surpriseSeedMtrHard.comboBoxSelections[comboBox20] = new string[] { "Location", "Enemy type", "Random (easy)", "Random (annoying)", "Random (awful)" };
            // 21 - goal
            surpriseSeedMtrHard.comboBoxSelections[comboBox21] = new string[] { "Mana tree revival" };
            // 22 - enemy swap type
            surpriseSeedMtrHard.comboBoxSelections[comboBox22] = new string[] { "Swap", "Swap", "Swap", "Random spawns" };
            // 25 - bosses
            surpriseSeedMtrHard.comboBoxSelections[comboBox25] = new string[] { "Swap", "Random" };
            // 26 - logic
            surpriseSeedMtrHard.comboBoxSelections[comboBox26] = new string[] { "Restrictive" };
            // 27 - start char
            surpriseSeedMtrHard.comboBoxSelections[comboBox27] = new string[] { "Boy", "Girl", "Sprite" };
            // random map colors
            surpriseSeedMtrHard.checkBoxSelections[checkBox37] = new bool[] { true, false };
            surpriseSeedMtrHard.checkBoxSelections[checkBox39] = new bool[] { true, false }; // flammie drum in logic
            surpriseSeedMtrHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED)] = new string[] { "Random" };
            surpriseSeedMtrHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MIN)] = new string[] { "5" };
            surpriseSeedMtrHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_SEEDS_REQUIRED_MAX)] = new string[] { "7" };
            surpriseSeedMtrHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_TRAPS)] = new string[] { "Normal", "Many" };
            surpriseSeedMtrHard.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_CHEST_FREQUENCY)] = new string[] { "Low", "Normal" };
            surpriseSeedMtrHard.mainForm = this;
            surpriseSeedMtrHard.hideUi = true;
            openWorldPresets.Add(surpriseSeedMtrHard);

            // /////////////////////////////
            // silly mystery seeds
            Preset other_title = new Preset();
            other_title.separatorOnly = true;
            other_title.name = "Silly stuff";
            other_title.fontSizeChange = 3;
            openWorldPresets.Add(other_title);

            Preset other_subtitle = new Preset();
            other_subtitle.separatorOnly = true;
            other_subtitle.name = "Various funny or particularly difficult setting combinations.";
            openWorldPresets.Add(other_subtitle);


            // /////////////////////////////
            // owls only
            Preset owl = new Preset();
            owl.name = "Menblock's \"owl%\"";
            owl.description = "Menblock's owl thing that he does sometimes.";
            owl.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Goal: Vanilla Long\n" +
                "Difficulty: Hard\n" +
                "Enemies: Oops all owls\n" +
                "Owls enemy: Nemesis Owl\n" +
                "Logic: Restrictive\n" +
                "Confusion fix: Off";
            ;
            owl.tabNameSelections[tabControl1] = new string[] { "Open" };
            owl.comboBoxSelections[comboBox21] = new string[] { "Vanilla long" };
            owl.comboBoxSelections[comboBox14] = new string[] { "Hard" };
            owl.comboBoxSelections[comboBox22] = new string[] { "Oops! All owls" };
            owl.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_EVERY_ENEMY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_EVERY_ENEMY)] = new string[] { "21 - Nemesis Owl" };
            owl.comboBoxSelections[comboBox26] = new string[] { "Restrictive" };
            owl.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_CONFUSION_FIX).getPropertyCombo(CommonSettings.PROPERTYNAME_CONFUSION_FIX)] = new string[] { "No" };
            openWorldPresets.Add(owl);

            // /////////////////////////////
            // owls only plus some other bullshit
            Preset insanity = new Preset();
            insanity.name = "Menblock's \"insanity%\"";
            insanity.description = "Menblock's bunch of settings to make life difficult for him.";
            insanity.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Goal: Vanilla Long\n" +
                "Difficulty: Hard\n" +
                "Enemies: Oops all owls\n" +
                "Owls enemy: Nemesis Owl\n" +
                "Logic: Restrictive\n" +
                "Confusion fix: Off\n" +
                "Aggressive bosses: On\n" +
                "4 items max\n" +
                "One-hit KO: On\n" +
                "Mana Beast stats: Vanilla\n" +
                "Randomize Grand Palace elements: Off"
                ;
            ;
            insanity.tabNameSelections[tabControl1] = new string[] { "Open" };
            insanity.comboBoxSelections[comboBox21] = new string[] { "Vanilla long" };
            insanity.comboBoxSelections[comboBox14] = new string[] { "Hard" };
            insanity.comboBoxSelections[comboBox22] = new string[] { "Oops! All owls" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_EVERY_ENEMY).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_EVERY_ENEMY)] = new string[] { "21 - Nemesis Owl" };
            insanity.comboBoxSelections[comboBox26] = new string[] { "Restrictive" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_CONFUSION_FIX).getPropertyCombo(CommonSettings.PROPERTYNAME_CONFUSION_FIX)] = new string[] { "No" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_AGGRESSIVE_BOSSES).getPropertyCombo(CommonSettings.PROPERTYNAME_AGGRESSIVE_BOSSES)] = new string[] { "Yes" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_MAX_7_ITEMS).getPropertyCombo(CommonSettings.PROPERTYNAME_MAX_7_ITEMS)] = new string[] { "No" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_OHKO).getPropertyCombo(CommonSettings.PROPERTYNAME_OHKO)] = new string[] { "Yes" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_MANA_BEAST_SCALING).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_MANA_BEAST_SCALING)] = new string[] { "Vanilla" };
            insanity.comboBoxSelections[propertyManager.getFormByProperty(OpenWorldSettings.PROPERTYNAME_RANDOMIZE_GRANDPALACE_ELEMENTS).getPropertyCombo(OpenWorldSettings.PROPERTYNAME_RANDOMIZE_GRANDPALACE_ELEMENTS)] = new string[] { "No" };
            openWorldPresets.Add(insanity);


            // /////////////////////////////
            // poison mode
            Preset poisonBs = new Preset();
            poisonBs.name = "Menblock's \"ticking time bomb\"";
            poisonBs.description = "Menblock's new thing he came up with where you're poisoned all the time but don't know when you'll die";
            poisonBs.tooltip = "Sets:\n" +
                "Mode: Open World\n" +
                "Obscure Damage: On\n" +
                "Obscure HP: On\n" +
                "Permanent Poison: On"
                ;
            ;
            poisonBs.tabNameSelections[tabControl1] = new string[] { "Open" };
            poisonBs.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_OBSCURE_DAMAGE).getPropertyCombo(CommonSettings.PROPERTYNAME_OBSCURE_DAMAGE)] = new string[] { "Yes" };
            poisonBs.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_OBSCURE_OWN_HP).getPropertyCombo(CommonSettings.PROPERTYNAME_OBSCURE_OWN_HP)] = new string[] { "Yes" };
            poisonBs.comboBoxSelections[propertyManager.getFormByProperty(CommonSettings.PROPERTYNAME_PERMANENT_POISON).getPropertyCombo(CommonSettings.PROPERTYNAME_PERMANENT_POISON)] = new string[] { "Yes" };
            openWorldPresets.Add(poisonBs);

            // pull initial values and use that for reset values
            List<ComboBox> allOpenWorldCombos = new List<ComboBox>();
            List<NumericUpDown> allOpenWorldUpDowns = new List<NumericUpDown>();
            allOpenWorldCombos.AddRange(new ComboBox[] { comboBox27, comboBox25, comboBox22, comboBox21, comboBox26, comboBox13, comboBox14, comboBox19, comboBox20, });
            allOpenWorldCombos.AddRange(propertyManager.getFormCombosByPrefix("open"));
            allOpenWorldUpDowns.AddRange(propertyManager.getFormUpDownsByPrefix("open"));
            allOpenWorldCombos.AddRange(propertyManager.getFormCombosByPrefix("general"));
            allOpenWorldUpDowns.AddRange(propertyManager.getFormUpDownsByPrefix("general"));
            Preset resetPreset = new Preset();
            resetPreset.name = "blorf";
            resetPreset.description = "blorf";
            foreach (ComboBox cb in allOpenWorldCombos)
            {
                resetPreset.comboBoxSelections[cb] = new string[] { (string)cb.SelectedItem };
            }
            foreach (NumericUpDown cb in allOpenWorldUpDowns)
            {
                resetPreset.numericUpDownSelections[cb] = new double[] { (double)cb.Value };
            }
            resetPreset.checkBoxSelections[checkBox29] = new bool[] { true };
            resetPreset.checkBoxSelections[checkBox36] = new bool[] { true };
            resetPreset.checkBoxSelections[checkBox28] = new bool[] { true };
            resetPreset.checkBoxSelections[checkBox37] = new bool[] { false };
            openWorldPresetsForm = new PresetsForm("Open World Presets", openWorldPresets, textBox3, resetPreset);
        }
    }
}