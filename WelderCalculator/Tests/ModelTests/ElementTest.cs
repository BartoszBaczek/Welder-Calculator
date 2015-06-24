using System;
using System.Runtime.InteropServices;
using NUnit.Core;
using NUnit.Framework;
using WelderCalculator.Model;

namespace Tests.ModelTests
{
    [TestFixture]
    public class ElementTest
    {
        Element _element;

        [SetUp]
        public void Init()
        {
            _element = new Element();
        }

        [Test]
        public void ShouldSetMinToNull_WhenConstructed()
        {
            //when contructed
            //then
            Assert.IsNull(_element.Min);
        }

        [Test]
        public void ShouldSetMaxToNull_WhenConstructed()
        {
            //when constructed
            //then
            Assert.IsNull(_element.Max);
        }

        [Test]
        public void ShouldSetAverageToNull_WhenConstructed()
        {
            //when constructed
            //then
            Assert.IsNull(_element.Average);
        }

        [Test]
        public void ShouldSetHasValueToFalse_WhenConstructed()
        {
            //when costructed
            //then
            Assert.IsFalse(_element.HasValue);
        }

        [Test]
        public void ShouldCountAverage_WhenSetRange()
        {
            //given 
            const float min = 2f;
            const float max = 3f;
            var difference = min * 0.001f;
            const float expectedResult = 3.5f;

            //when
            _element.SetRange(min, max);

            //then
            Assert.That((_element.Average - expectedResult <= difference) || (_element.Average - expectedResult >= difference));
        }

        [Test]
        public void ShouldSetHasValueToTrue_WhenSetRange()
        {
            //given 
            const float min = 1f;
            const float max = 5.6f;

            //when
            _element.SetRange(min, max);

            //then
            Assert.IsTrue(_element.HasValue);
        }

        [Test]
        public void ShouldSetMin_WhenSetRange()
        {
            //given
            const float min = 1.4f;
            const float max = 10f;

            //when
            _element.SetRange(min, max);

            //then
            Assert.That(_element.Min, Is.EqualTo(min));
        }

        [Test]
        public void ShouldSetMax_WhenSetRange()
        {
            //given
            const float min = 1.4f;
            const float max = 10f;

            //when
            _element.SetRange(min, max);

            //then
            Assert.That(_element.Max, Is.EqualTo(max));
        }

        [Test]
        [ExpectedException(typeof (ElementException))]
        public void ShouldThrowElementException_WhenSetRange_MaxLessThanMin()
        {
            //given 
            const float min = 5f;
            const float max = 1f;

            //when 
            _element.SetRange(min, max);
        }

        [Test]
        [ExpectedException(typeof (ElementException))]
        public void ShouldThrowElementException_WhenSetRange_MinLessThenZero()
        {
            //given
            const float min = -0.2f;
            const float max = 4.9f;

            //when
            _element.SetRange(min, max);
        }

        [Test]
        [ExpectedException(typeof(ElementException))]
        public void ShouldThrowElementException_WhenSetRange_MaxLessThenZero()
        {
            //given
            const float min = 3f;
            const float max = -1f;

            //when
            _element.SetRange(min, max);
        }

        [Test]
        [ExpectedException(typeof(ElementException))]
        public void ShouldThrowElementException_WhenSetRange_MinBiggerThanHundred()
        {
            //given
            const float min = 100.01f;
            const float max = 4.9f;

            //when
            _element.SetRange(min, max);
        }

        [Test]
        [ExpectedException(typeof(ElementException))]
        public void ShouldThrowElementException_WhenSetRange_MaxBiggerThanHundred()
        {
            //given
            const float min = 3f;
            const float max = 134.1f;

            //when
            _element.SetRange(min, max);
        }

    }
}
