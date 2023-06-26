namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class AquariumsTests
    {
        private Fish fish;
        private Fish fish1;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
          this.fish = new Fish("Pesho");
          this.aquarium = new Aquarium("Zona", 16);
          this.fish1 = new Fish("Gosho");

        }
        [Test]
        public void TestFishConstructor()
        {
            Fish fish = new Fish("Pesho");
            Assert.AreEqual("Pesho", fish.Name);
            Assert.AreEqual(true, fish.Available);
        }
        [Test]
        public void FishNameGetter()
        {
            Assert.AreEqual("Pesho", fish.Name);

        }
        [Test]
        public void FishNameSetter()
        {
            fish.Name = "Gosho";
            Assert.AreEqual("Gosho", fish.Name);
        }
        [Test]
        public void FishAvailableGetter()
        {
            Assert.AreEqual(true, fish.Available);
        }
        [Test]
        public void FishAvailableSetter()
        {
            fish.Available = false;
            Assert.AreEqual(false, fish.Available);
        }
        [Test]
        public void TestAquariumConstructorShouldWork_Successfully()
        {
            Aquarium aquarium = new Aquarium("IvanATri", 16);
            FieldInfo fl = aquarium.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "fish");
            List<Fish> list = new List<Fish>();
            List<Fish> actual = (List<Fish>)fl.GetValue(aquarium);
            CollectionAssert.AreEqual(list, actual);
            Assert.AreEqual("IvanATri", aquarium.Name);
            Assert.AreEqual(16, aquarium.Capacity);
        }

        public void TestNameGetter()
        {
            Assert.AreEqual("Zona", aquarium.Name);
        }
        [TestCase(null)]
        [TestCase("")]
        public void TestNameSetterShouldThrowArgumentNullException_ForNullValue(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 16);
            }, "Invalid aquarium name!");
        }
        [Test]
        public void TestCapacityGetter()
        {
            Assert.AreEqual(16, aquarium.Capacity);
        }
        [TestCase(-1)]
        [TestCase(-27)]
        [TestCase(-53)]
        public void CapacitySetterShouldThrowArgumentException_ForNegativeValue(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("zona", capacity);
            
            }, "Invalid aquarium capacity!");
        }
        [Test]
        public void TestCountGetter()
        {
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void AddMethodShouldWork_Successfully()
        {
            aquarium.Add(fish);
            FieldInfo fl = aquarium.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "fish");
            List<Fish> actual = (List<Fish>)fl.GetValue(aquarium);
            List<Fish> list = new List<Fish>();
            list.Add(fish);
            CollectionAssert.AreEqual(list, actual);
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationException_ForFullAquarium()
        {
            Aquarium aquarium = new Aquarium("Zona", 1);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
                aquarium.Add(fish1);
            });
        }

        public void RemoveMethodShouldThrowInvalidOperationException_ForInvalidFish()
        {
            //
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
                aquarium.RemoveFish("Ivana");
            }, $"Fish with the name Ivana doesn't exist!");
        }
        [Test]
        public void RemoveMethodShouldWork_Successfully()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("Pesho");
            FieldInfo fl = aquarium.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "fish");
            List<Fish> actual = (List<Fish>)fl.GetValue(aquarium);
            List<Fish> list = new List<Fish>();
            CollectionAssert.AreEqual(list, actual);
        }
        [Test]
        public void RemoveMethodShouldWork_Successfully1()
        {
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.RemoveFish("Pesho");
            aquarium.RemoveFish("Gosho");
            FieldInfo fl = aquarium.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "fish");
            List<Fish> actual = (List<Fish>)fl.GetValue(aquarium);
            List<Fish> list = new List<Fish>();
            CollectionAssert.AreEqual(list, actual);
        }
        [Test]
        public void SellFishShouldThrowInvalidOperationException_ForInvalidFish()
        {
            //
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
                aquarium.SellFish("Ivana");
            }, $"Fish with the name Ivana doesn't exist!");
        }
        [Test]
        public void SellFishShouldWork_Successfully()
        {
            aquarium.Add(fish);
            Fish actual = aquarium.SellFish("Pesho");
            Assert.AreEqual("Pesho", actual.Name);
            Assert.AreEqual(false, actual.Available);
        }
        [Test]
        public void TestReportMethod()
        {
            aquarium.Add(fish);
            aquarium.Add(fish1);
            string report = aquarium.Report();
            Assert.AreEqual($"Fish available at Zona: Pesho, Gosho", report);
        }
    }
}
