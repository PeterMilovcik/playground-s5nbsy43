using System;
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
            dexterityVest = new Item("+5 Dexterity Vest") {SellIn = 10, Quality = 20};
            agedBrie = new Item("Aged Brie") {SellIn = 2, Quality = 0};
            elixir = new Item("Elixir of the Mongoose") {SellIn = 5, Quality = 7};
            sulfuras = new Item("Sulfuras, Hand of Ragnaros") {SellIn = 0, Quality = 80};
            backstagePasses = new Item("Backstage passes to a TAFKAL80ETC concert") {SellIn = 15, Quality = 20};
            conjured = new Item("Conjured Mana Cake"){SellIn = 3, Quality = 6};
            items = new List<Item> {dexterityVest, agedBrie, elixir, sulfuras, backstagePasses};
            sut = new GildedRose(items);
        }

        [TestMethod]
        public void AllTests()
        {
            DexterityVest();
            AgedBrie();
            Sulfuras();
            BackstagePasses();
            Conjured();
        }

        private void DexterityVest()
        {
            shouldShowHint = true;
            sut.UpdateQuality();
            Assert.AreEqual(dexterityVest.SellIn, 9);
            Assert.AreEqual(dexterityVest.Quality, 19);
            dexterityVest.SellIn = 0;
            dexterityVest.Quality = 19;
            sut.UpdateQuality();
            Assert.AreEqual(dexterityVest.SellIn, 0);
            Assert.AreEqual(dexterityVest.Quality, 17);
            dexterityVest.SellIn = 0;
            dexterityVest.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(dexterityVest.SellIn, 0);
            Assert.AreEqual(dexterityVest.Quality, 0);
            shouldShowHint = false;
        }

        private void AgedBrie()
        {
            shouldShowHint = true;
            sut.UpdateQuality();
            Assert.AreEqual(agedBrie.Quality, 1, "Quality");
            Assert.AreEqual(agedBrie.SellIn, 1, "SellIn");
            agedBrie.SellIn = 0;
            agedBrie.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(agedBrie.Quality, 1, "Quality");
            Assert.AreEqual(agedBrie.SellIn, 0, "SellIn");
            agedBrie.SellIn = 0;
            agedBrie.Quality = 50;
            sut.UpdateQuality();
            Assert.AreEqual(agedBrie.Quality, 50, "Quality");
            Assert.AreEqual(agedBrie.SellIn, 0, "SellIn");
            shouldShowHint = false;
        }

        private void Sulfuras()
        {
            shouldShowHint = true;
            sut.UpdateQuality();
            Assert.AreEqual(sulfuras.Quality, 0, "Quality");
            Assert.AreEqual(sulfuras.SellIn, 80, "SellIn");
            shouldShowHint = false;
        }

        private void BackstagePasses()
        {
            shouldShowHint = true;
            backstagePasses.SellIn = 15;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(backstagePasses.Quality, 11, "Quality");
            Assert.AreEqual(backstagePasses.SellIn, 14, "SellIn");
            backstagePasses.SellIn = 10;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(backstagePasses.Quality, 12, "Quality");
            Assert.AreEqual(backstagePasses.SellIn, 9, "SellIn");
            backstagePasses.SellIn = 5;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(backstagePasses.Quality, 13, "Quality");
            Assert.AreEqual(backstagePasses.SellIn, 4, "SellIn");
            backstagePasses.SellIn = 0;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(backstagePasses.Quality, 0, "Quality");
            Assert.AreEqual(backstagePasses.SellIn, 0, "SellIn");
            shouldShowHint = false;
        }
        
        private void Conjured()
        {
            shouldShowHint = true;
            conjured.SellIn = 3;
            conjured.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(sulfuras.Quality, 8, "Quality");
            Assert.AreEqual(sulfuras.SellIn, 2, "SellIn");
            conjured.SellIn = 0;
            conjured.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(sulfuras.Quality, 4, "Quality");
            Assert.AreEqual(sulfuras.SellIn, 0, "SellIn");
            conjured.SellIn = 0;
            conjured.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(sulfuras.Quality, 0, "Quality");
            Assert.AreEqual(sulfuras.SellIn, 0, "SellIn");
            shouldShowHint = false;
        }

        [TestCleanup]
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

        private static void PrintMessage(string channel, string message) => 
            Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");

        private static void Success(bool success) => 
            Console.WriteLine($"TECHIO> success {success}");

        private static bool ExistsInFile(string path, string keyword) => 
            File.ReadAllText(path).Contains(keyword);
    }
}