﻿using Microsoft.Recognizers.Text.DataDrivenTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Microsoft.Recognizers.Text.Sequence.Tests
{
    [TestClass]
    public class TestSequenceRecognizerCache
    {
        [TestInitialize]
        public void Initialization()
        {
            var recognizer = new SequenceRecognizer();
            recognizer.GetInternalCache().Clear();
        }

        [TestMethod]
        public void WithLazyInitialization_CacheEmpty()
        {
            var recognizer = new SequenceRecognizer(lazyInitialization: true);
            var internalCache = recognizer.GetInternalCache();
            Assert.AreEqual(0, internalCache.Count);
        }

        [TestMethod]
        public void WithoutLazyInitialization_CacheFull()
        {
            var recognizer = new SequenceRecognizer(lazyInitialization: false);
            var internalCache = recognizer.GetInternalCache();
            Assert.AreNotEqual(0, internalCache.Count);
        }

        [TestMethod]
        public void WithoutLazyInitializationAndCulture_CacheWithCulture()
        {
            var recognizer = new SequenceRecognizer(Culture.English, lazyInitialization: false);
            var internalCache = recognizer.GetInternalCache();
            Assert.IsTrue(internalCache.All(kv => kv.Key.culture == Culture.English));
        }
    }
}
