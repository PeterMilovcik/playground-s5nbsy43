﻿using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
 using System.Collections.Generic;
 using System.IO;

 namespace TechIo
 {
     [TestClass]
     public class GildedRoseTests
     {
         private bool shouldShowHint;
         private List<Item> items;
         private Item dexterityVest;
         private Item agedBrie;
         private Item elixir;
         private Item legendary1;
         private Item legendary2;
         private Item backstagePasses1;
         private Item backstagePasses2;
         private Item backstagePasses3;
         private Item backstagePasses4;
         private GildedRose sut;

         [TestInitialize]
         public void Initialize()
         {
             dexterityVest = new Item("+5 Dexterity Vest") {SellIn = 10, Quality = 20};
             agedBrie = new Item("Aged Brie") {SellIn = 2, Quality = 0};
             elixir = new Item("Elixir of the Mongoose") {SellIn = 5, Quality = 7};
             legendary1 = new Item("Sulfuras, Hand of Ragnaros") {SellIn = 0, Quality = 80};
             legendary2 = new Item("Sulfuras, Hand of Ragnaros") {SellIn = -1, Quality = 80};
             backstagePasses1 = new Item("Backstage passes to a TAFKAL80ETC concert") {SellIn = 15, Quality = 20};
             backstagePasses2 = new Item("Backstage passes to a TAFKAL80ETC concert") {SellIn = 10, Quality = 49};
             backstagePasses3 = new Item("Backstage passes to a TAFKAL80ETC concert") {SellIn = 5, Quality = 49};
             backstagePasses4 = new Item("Backstage passes to a TAFKAL80ETC concert") {SellIn = 3, Quality = 6};
             items = new List<Item>
             {
                 dexterityVest, agedBrie, elixir, legendary1, legendary2, backstagePasses1, backstagePasses2, backstagePasses3, backstagePasses4
             };
             sut = new GildedRose(items);
         }

         [TestMethod]
         public void DexterityVest()
         {
             shouldShowHint = true;
             sut.UpdateQuality();
             Assert.AreEqual(dexterityVest.Quality, 19, "Quality");
             Assert.AreEqual(dexterityVest.SellIn, 9, "SellIn");
             shouldShowHint = false;
         }

         [TestMethod]
         public void AgedBrie()
         {
             shouldShowHint = true;
             sut.UpdateQuality();
             Assert.AreEqual(agedBrie.Quality, 1, "Quality");
             Assert.AreEqual(agedBrie.SellIn, 1, "SellIn");
             shouldShowHint = false;
         }

        [TestCleanup()]
         public void Cleanup()
         {
             if (shouldShowHint)
             {
                 // On Failure
                 PrintMessage("Hint 💡", "Did you properly implemented all requirements? 🤔");
             }
             else
             {
                 PrintMessage("Kudos 🌟", "Congratulations!");
                 PrintMessage("Kudos 🌟", "");
                 PrintMessage("Kudos 🌟", "You've implemented all the Gilded Rose requirements!");
             }
         }

         private static void PrintMessage(String channel, String message) => 
             Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");

         private static void Success(bool success) => 
             Console.WriteLine($"TECHIO> success {success}");

         private static bool ExistsInFile(String path, String keyword) =>
             File.ReadAllText(path).Contains(keyword);
     }
 }