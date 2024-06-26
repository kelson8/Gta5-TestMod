﻿using LemonUI.Menus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;

namespace TutorialMod
{
    public class CreatePlayerMenu : Script
    {

        public void CreatePlayerMenu1()
        {
            // TODO Add force field option (Blows up cars around player and push them away.)

            // Fix player
            NativeItem itemFixPlayer = new NativeItem("Fix player", "Restores player's health and armor");
            // This is the equivalent to:
            // private void FixPlayer(object sender, EventArgs e)
            itemFixPlayer.Activated += (sender, args) =>
            {
                Game.Player.Character.Health = Game.Player.Character.MaxHealth;
                Game.Player.Character.Armor = Game.Player.MaxArmor;
                Notification.Show("Health and armor restored!");
            };
            
            playerMenu.Add(itemFixPlayer);

            // Invincible
            NativeCheckboxItem checkBoxInvincible = new NativeCheckboxItem("Invincible", "Gives you god mode");
            checkBoxInvincible.CheckboxChanged += (sender, args) =>
            {
                Game.Player.Character.IsInvincible = checkBoxInvincible.Checked;
                // Equivalent of doing this: ("IsInvincible: " + Game.Player.Character.IsInvincible.ToString())
                Notification.Show($"Invincible: {Game.Player.Character.IsInvincible}");
            };
            playerMenu.Add(checkBoxInvincible);

            // Wanted level
            NativeListItem<int> listItemWantedLevel = new NativeListItem<int>("Wanted Level", "Adjust player's wanted level", 0, 1, 2, 3, 4, 5);
            listItemWantedLevel.ItemChanged += (sender, args) =>
            {
                Game.Player.WantedLevel = args.Object;
            };
            playerMenu.Add(listItemWantedLevel);

            // Never wanted, Well it did work, I just copied what I was doing for the super jump code.
            NativeCheckboxItem checkboxNeverWanted = new NativeCheckboxItem("Never Wanted");
            checkboxNeverWanted.CheckboxChanged += (sender, args) =>
            {
                isNeverWanted = checkboxNeverWanted.Checked;
            };
            playerMenu.Add(checkboxNeverWanted);

            // Spawn player in car
            NativeCheckboxItem checkBoxSpawnIntoVehicle = new NativeCheckboxItem("Spawn into car", "This option sets you to spawn in the car instead of out of it.");
            checkBoxSpawnIntoVehicle.CheckboxChanged += (sender, args) =>
            {
                SpawnIntoVehicle = checkBoxSpawnIntoVehicle.Checked;
            };
            playerMenu.Add(checkBoxSpawnIntoVehicle);

            /* I can also use NativeListItem with string like so
             NativeListItem<string> listItemHairColor = new NativeListItem<string>("Hair Color", "Change Hair Color", "Black", "White", "Blue", "Green");
            listItemHairColor.ItemChanged += (sender, args) =>
            {
                Notification.Show($"You've selected the Hair Color: {args.Object}");
            };
            playerMenu.Add(listItemHairColor);
            */

            // Super jump
            NativeCheckboxItem checkBoxSuperJump = new NativeCheckboxItem("Super jump");
            checkBoxSuperJump.CheckboxChanged += (sender, args) =>
            {
                canSuperJump = checkBoxSuperJump.Checked;
            };
            playerMenu.Add(checkBoxSuperJump);

            // Explosive melee
            NativeCheckboxItem checkBoxExplosiveMelee = new NativeCheckboxItem("Explosive melee");
            checkBoxExplosiveMelee.CheckboxChanged += (sender, args) =>
            {
                isExplosiveMeleeEnabled = checkBoxExplosiveMelee.Checked;
            };
            playerMenu.Add(checkBoxExplosiveMelee);
        }

    }
}
