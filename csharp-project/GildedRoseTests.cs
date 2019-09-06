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
            Assert.AreEqual(9, dexterityVest.SellIn, "SellIn");
            Assert.AreEqual(19, dexterityVest.Quality, "Quality");
            dexterityVest.SellIn = 0;
            dexterityVest.Quality = 19;
            sut.UpdateQuality();
            Assert.AreEqual(0, dexterityVest.SellIn, "SellIn");
            Assert.AreEqual(17, dexterityVest.Quality, "Quality");
            dexterityVest.SellIn = 0;
            dexterityVest.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(0, dexterityVest.SellIn, "SellIn");
            Assert.AreEqual(0, dexterityVest.Quality, "Quality");
            shouldShowHint = false;
        }

        private void AgedBrie()
        {
            shouldShowHint = true;
            sut.UpdateQuality();
            Assert.AreEqual(1, agedBrie.Quality, "Quality");
            Assert.AreEqual(1, agedBrie.SellIn, "SellIn");
            agedBrie.SellIn = 0;
            agedBrie.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(1, agedBrie.Quality, "Quality");
            Assert.AreEqual(0, agedBrie.SellIn, "SellIn");
            agedBrie.SellIn = 0;
            agedBrie.Quality = 50;
            sut.UpdateQuality();
            Assert.AreEqual(50, agedBrie.Quality, "Quality");
            Assert.AreEqual(0, agedBrie.SellIn, "SellIn");
            shouldShowHint = false;
        }

        private void Sulfuras()
        {
            shouldShowHint = true;
            sut.UpdateQuality();
            Assert.AreEqual(0, sulfuras.Quality, "Quality");
            Assert.AreEqual(80, sulfuras.SellIn, "SellIn");
            shouldShowHint = false;
        }

        private void BackstagePasses()
        {
            shouldShowHint = true;
            backstagePasses.SellIn = 15;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(11, backstagePasses.Quality, "Quality");
            Assert.AreEqual(14, backstagePasses.SellIn, "SellIn");
            backstagePasses.SellIn = 10;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(12, backstagePasses.Quality, "Quality");
            Assert.AreEqual(9, backstagePasses.SellIn, "SellIn");
            backstagePasses.SellIn = 5;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(13, backstagePasses.Quality, "Quality");
            Assert.AreEqual(4, backstagePasses.SellIn, "SellIn");
            backstagePasses.SellIn = 0;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(0, backstagePasses.Quality, "Quality");
            Assert.AreEqual(0, backstagePasses.SellIn, "SellIn");
            shouldShowHint = false;
        }
        
        private void Conjured()
        {
            shouldShowHint = true;
            conjured.SellIn = 3;
            conjured.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(8, sulfuras.Quality, "Quality");
            Assert.AreEqual(2, sulfuras.SellIn, "SellIn");
            conjured.SellIn = 0;
            conjured.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(4, sulfuras.Quality, "Quality");
            Assert.AreEqual(0, sulfuras.SellIn, "SellIn");
            conjured.SellIn = 0;
            conjured.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(0, sulfuras.Quality, "Quality");
            Assert.AreEqual(0, sulfuras.SellIn, "SellIn");
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