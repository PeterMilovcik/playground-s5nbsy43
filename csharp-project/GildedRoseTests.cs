﻿using System;
using System.Collections.Generic;
using System.IO;
using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechIo
{
    [TestClass]
    public class GildedRoseTests
    {
        private Item agedBrie;
        private Item backstagePasses;
        private Item dexterityVest;
        private Item elixir;
        private List<Item> items;
        private bool shouldShowHint;
        private Item sulfuras;
        private Item conjured;
        private GildedRose sut;

        [TestInitialize]
        public void Initialize()
        {
            dexterityVest = new Item("+5 Dexterity Vest");
            agedBrie = new Item("Aged Brie");
            elixir = new Item("Elixir of the Mongoose");
            sulfuras = new Item("Sulfuras, Hand of Ragnaros");
            backstagePasses = new Item("Backstage passes to a TAFKAL80ETC concert") {SellIn = 15, Quality = 20};
            conjured = new Item("Conjured Mana Cake"){SellIn = 3, Quality = 6};
            items = new List<Item> {dexterityVest, agedBrie, elixir, sulfuras, backstagePasses, conjured};
            sut = new GildedRose(items);
        }

        [TestMethod]
        public void AllTests()
        {
            DexterityVest();
            AgedBrie();
            Elixir();
            Sulfuras();
            BackstagePasses();
            Conjured();
        }

        private void DexterityVest()
        {
            shouldShowHint = true;
            try
            {
                dexterityVest.SellIn = 10;
                dexterityVest.Quality = 20;
                sut.UpdateQuality();
                Assert.AreEqual(9, dexterityVest.SellIn, "SellIn");
                Assert.AreEqual(19, dexterityVest.Quality, "Quality");
                dexterityVest.SellIn = 0;
                dexterityVest.Quality = 19;
                sut.UpdateQuality();
                Assert.AreEqual(-1, dexterityVest.SellIn, "SellIn");
                Assert.AreEqual(17, dexterityVest.Quality, "Quality");
                dexterityVest.SellIn = 0;
                dexterityVest.Quality = 0;
                sut.UpdateQuality();
                Assert.AreEqual(-1, dexterityVest.SellIn, "SellIn");
                Assert.AreEqual(0, dexterityVest.Quality, "Quality");
            }
            catch
            {
                PrintMessage("Hint 💡", "Did you properly implemented all requirements for dexterity vest? 🤔");
                throw;
            }
            shouldShowHint = false;
        }

        private void AgedBrie()
        {
            shouldShowHint = true;
            try
            {
                agedBrie.SellIn = 2;
                agedBrie.Quality = 0;
                sut.UpdateQuality();
                Assert.AreEqual(1, agedBrie.SellIn, "SellIn");
                Assert.AreEqual(1, agedBrie.Quality, "Quality");
                agedBrie.SellIn = 0;
                agedBrie.Quality = 0;
                sut.UpdateQuality();
                Assert.AreEqual(-1, agedBrie.SellIn, "SellIn");
                Assert.AreEqual(2, agedBrie.Quality, "Quality");
                agedBrie.SellIn = 0;
                agedBrie.Quality = 50;
                sut.UpdateQuality();
                Assert.AreEqual(-1, agedBrie.SellIn, "SellIn");
                Assert.AreEqual(50, agedBrie.Quality, "Quality");
            }
            catch
            {
                PrintMessage("Hint 💡", "Did you properly implemented all requirements for aged brie? 🤔");
                throw;
            }
            shouldShowHint = false;
        }

        private void Elixir()
        {
            shouldShowHint = true;
            try
            {
                elixir.SellIn = 5;
                elixir.Quality = 7;
                sut.UpdateQuality();
                Assert.AreEqual(4, elixir.SellIn, "SellIn");
                Assert.AreEqual(6, elixir.Quality, "Quality");
                elixir.SellIn = 0;
                elixir.Quality = 19;
                sut.UpdateQuality();
                Assert.AreEqual(-1, elixir.SellIn, "SellIn");
                Assert.AreEqual(17, elixir.Quality, "Quality");
                elixir.SellIn = 0;
                elixir.Quality = 0;
                sut.UpdateQuality();
                Assert.AreEqual(-1, elixir.SellIn, "SellIn");
                Assert.AreEqual(0, elixir.Quality, "Quality");
                elixir.SellIn = -1;
                elixir.Quality = 0;
                sut.UpdateQuality();
                Assert.AreEqual(-2, elixir.SellIn, "SellIn");
                Assert.AreEqual(0, elixir.Quality, "Quality");
            }
            catch
            {
                PrintMessage("Hint 💡", "Did you properly implemented all requirements for elixir? 🤔");
                throw;
            }
            shouldShowHint = false;
        }

        private void Sulfuras()
        {
            shouldShowHint = true;
            try
            {
                sulfuras.SellIn = 0;
                sulfuras.Quality = 80;
                sut.UpdateQuality();
                Assert.AreEqual(0, sulfuras.SellIn, "SellIn");
                Assert.AreEqual(80, sulfuras.Quality, "Quality");
            }
            catch
            {
                PrintMessage("Hint 💡", "Did you properly implemented all requirements for sulfuras? 🤔");
                throw;
            }
            shouldShowHint = false;
        }

        private void BackstagePasses()
        {
            shouldShowHint = true;
            try
            {
                backstagePasses.SellIn = 15;
                backstagePasses.Quality = 10;
                sut.UpdateQuality();
                Assert.AreEqual(14, backstagePasses.SellIn, "SellIn");
                Assert.AreEqual(11, backstagePasses.Quality, "Quality");
                backstagePasses.SellIn = 10;
                backstagePasses.Quality = 10;
                sut.UpdateQuality();
                Assert.AreEqual(9, backstagePasses.SellIn, "SellIn");
                Assert.AreEqual(12, backstagePasses.Quality, "Quality");
                backstagePasses.SellIn = 5;
                backstagePasses.Quality = 10;
                sut.UpdateQuality();
                Assert.AreEqual(4, backstagePasses.SellIn, "SellIn");
                Assert.AreEqual(13, backstagePasses.Quality, "Quality");
                backstagePasses.SellIn = 0;
                backstagePasses.Quality = 10;
                sut.UpdateQuality();
                Assert.AreEqual(-1, backstagePasses.SellIn, "SellIn");
                Assert.AreEqual(0, backstagePasses.Quality, "Quality");
            }
            catch
            {
                PrintMessage("Hint 💡", "Did you properly implemented all requirements for backstage passes? 🤔");
                throw;
            }
            shouldShowHint = false;
        }
        
        private void Conjured()
        {
            shouldShowHint = true;
            try
            {
                conjured.SellIn = 3;
                conjured.Quality = 10;
                sut.UpdateQuality();
                Assert.AreEqual(2, conjured.SellIn, "SellIn");
                Assert.AreEqual(8, conjured.Quality, "Quality");
                conjured.SellIn = 0;
                conjured.Quality = 10;
                sut.UpdateQuality();
                Assert.AreEqual(-1, conjured.SellIn, "SellIn");
                Assert.AreEqual(6, conjured.Quality, "Quality");
                conjured.SellIn = 0;
                conjured.Quality = 0;
                sut.UpdateQuality();
                Assert.AreEqual(-1, conjured.SellIn, "SellIn");
                Assert.AreEqual(0, conjured.Quality, "Quality");
            }
            catch
            {
                PrintMessage("Hint 💡", "Did you properly implemented all requirements for conjured mana cake? 🤔");
                throw;
            }
            shouldShowHint = false;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (!shouldShowHint)
            {
                PrintMessage("Kudos 🌟", "Congratulations!");
                PrintMessage("Kudos 🌟", "");
                PrintMessage("Kudos 🌟", "You've implemented all the Gilded Rose requirements!");
            }
        }

        private static void PrintMessage(string channel, string message) => 
            Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");

        private static void Success(bool success) => 
            Console.WriteLine($"TECHIO> success {success}");

        private static bool ExistsInFile(string path, string keyword) => 
            File.ReadAllText(path).Contains(keyword);
    }
}