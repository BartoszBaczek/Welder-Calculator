using System.Drawing;
using NUnit.Framework;
using WelderCalculator.Helpers.DeLongHelpers;

namespace Tests
{
    [TestFixture]
    public class DeLongMicrophaseHelperTests
    {
        private DeLongMicrophaseHelper _microphaseHelper;

        private readonly PointF AM_1 = new PointF(16.5f, 14f);
        private readonly PointF AM_2 = new PointF(21f, 10f);
        private readonly PointF AM_3 = new PointF(19f, 12f);

        private readonly PointF A_1 = new PointF(18f, 13f);
        private readonly PointF A_2 = new PointF(21.5f, 18f);
        private readonly PointF A_3 = new PointF(16f, 21f);

        private readonly PointF F0to2_1 = new PointF(17f, 11f);
        private readonly PointF F0to2_2 = new PointF(19f, 14f);
        private readonly PointF F0to2_3 = new PointF(23.5f, 20f);

        private readonly PointF F2to4_1 = new PointF(17.5f, 11f);
        private readonly PointF F2to4_2 = new PointF(19f, 13f);
        private readonly PointF F2to4_3 = new PointF(23.5f, 19f);

        private readonly PointF F4to6_1 = new PointF(18f, 11f);
        private readonly PointF F4to6_2 = new PointF(19f, 12f);
        private readonly PointF F4to6_3 = new PointF(24f, 19f);

        private readonly PointF F6to8_1 = new PointF(18f, 10f);
        private readonly PointF F6to8_2 = new PointF(19.5f, 12f);
        private readonly PointF F6to8_3 = new PointF(22.5f, 16f);

        private readonly PointF F8to10_1 = new PointF(19f, 11f);
        private readonly PointF F8to10_2 = new PointF(20f, 12.01f);
        private readonly PointF F8to10_3 = new PointF(25f, 19f);

        private readonly PointF F10to12_1 = new PointF(19.5f, 11f);
        private readonly PointF F10to12_2 = new PointF(21f, 13f);
        private readonly PointF F10to12_3 = new PointF(24f, 17f);

        private readonly PointF F12to14_1 = new PointF(20f, 11f);
        private readonly PointF F12to14_2 = new PointF(21.5f, 13f);
        private readonly PointF F12to14_3 = new PointF(25.5f, 18f);

        private readonly PointF F14to16_1 = new PointF(19.5f, 10f);
        private readonly PointF F14to16_2 = new PointF(20.5f, 11f);
        private readonly PointF F14to16_3 = new PointF(26.5f, 19f);

        private readonly PointF F16to18_1 = new PointF(20f, 10f);
        private readonly PointF F16to18_2 = new PointF(21f, 11f);
        private readonly PointF F16to18_3 = new PointF(25f, 16f);

        private readonly PointF F18Up_1 = new PointF(21.5f, 11f);
        private readonly PointF F18Up_2 = new PointF(23f, 13f);
        private readonly PointF F18Up_3 = new PointF(27f, 10f);

        [SetUp]
        public void Init()
        {
            _microphaseHelper = new DeLongMicrophaseHelper();
        }

        [Test]
        public void IsInAMArea()
        {
            Assert.IsTrue(_microphaseHelper.AMContains(AM_1) && 
                          _microphaseHelper.AMContains(AM_2) && 
                          _microphaseHelper.AMContains(AM_3));

            Assert.IsFalse(_microphaseHelper.AContains(AM_1) ||
                          _microphaseHelper.AContains(AM_2) ||
                          _microphaseHelper.AContains(AM_3));

        }

        [Test]
        public void IsInAArea()
        {
            Assert.IsTrue(_microphaseHelper.AContains(A_1) &&
                          _microphaseHelper.AContains(A_2) &&
                          _microphaseHelper.AContains(A_3));

            Assert.IsFalse(_microphaseHelper.AMContains(A_1) ||
                          _microphaseHelper.AMContains(A_2) ||
                          _microphaseHelper.AMContains(A_3));
        }

        [Test]
        public void IsInF0to2Area()
        {
            Assert.IsTrue(_microphaseHelper.F0to2Contains(F0to2_1) &&
                          _microphaseHelper.F0to2Contains(F0to2_2) &&
                          _microphaseHelper.F0to2Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F2to4Contains(F0to2_1) ||
                          _microphaseHelper.F2to4Contains(F0to2_2) ||
                          _microphaseHelper.F2to4Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F4to6Contains(F0to2_1) ||
                          _microphaseHelper.F4to6Contains(F0to2_2) ||
                          _microphaseHelper.F4to6Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F6to8Contains(F0to2_1) ||
                          _microphaseHelper.F6to8Contains(F0to2_2) ||
                          _microphaseHelper.F6to8Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F8to10Contains(F0to2_1) ||
                          _microphaseHelper.F8to10Contains(F0to2_2) ||
                          _microphaseHelper.F8to10Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F10to12Contains(F0to2_1) ||
                          _microphaseHelper.F10to12Contains(F0to2_2) ||
                          _microphaseHelper.F10to12Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F12to14Contains(F0to2_1) ||
                          _microphaseHelper.F12to14Contains(F0to2_2) ||
                          _microphaseHelper.F12to14Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F14to16Contains(F0to2_1) ||
                          _microphaseHelper.F14to16Contains(F0to2_2) ||
                          _microphaseHelper.F14to16Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F16to18Contains(F0to2_1) ||
                          _microphaseHelper.F16to18Contains(F0to2_2) ||
                          _microphaseHelper.F16to18Contains(F0to2_3));

            Assert.IsFalse(_microphaseHelper.F18PlusContains(F0to2_1) ||
                          _microphaseHelper.F18PlusContains(F0to2_2) ||
                          _microphaseHelper.F18PlusContains(F0to2_3));
        }

        [Test]
        public void IsInF2to4Area()
        {
            Assert.IsTrue(_microphaseHelper.F2to4Contains(F2to4_1) &&
                          _microphaseHelper.F2to4Contains(F2to4_2) &&
                          _microphaseHelper.F2to4Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F0to2Contains(F2to4_1) ||
                         _microphaseHelper.F0to2Contains(F2to4_2) ||
                         _microphaseHelper.F0to2Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F4to6Contains(F2to4_1) ||
                          _microphaseHelper.F4to6Contains(F2to4_2) ||
                          _microphaseHelper.F4to6Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F6to8Contains(F2to4_1) ||
                          _microphaseHelper.F6to8Contains(F2to4_2) ||
                          _microphaseHelper.F6to8Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F8to10Contains(F2to4_1) ||
                          _microphaseHelper.F8to10Contains(F2to4_2) ||
                          _microphaseHelper.F8to10Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F10to12Contains(F2to4_1) ||
                          _microphaseHelper.F10to12Contains(F2to4_2) ||
                          _microphaseHelper.F10to12Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F12to14Contains(F2to4_1) ||
                          _microphaseHelper.F12to14Contains(F2to4_2) ||
                          _microphaseHelper.F12to14Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F14to16Contains(F2to4_1) ||
                          _microphaseHelper.F14to16Contains(F2to4_2) ||
                          _microphaseHelper.F14to16Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F16to18Contains(F2to4_1) ||
                          _microphaseHelper.F16to18Contains(F2to4_2) ||
                          _microphaseHelper.F16to18Contains(F2to4_3));

            Assert.IsFalse(_microphaseHelper.F18PlusContains(F2to4_1) ||
                          _microphaseHelper.F18PlusContains(F2to4_2) ||
                          _microphaseHelper.F18PlusContains(F2to4_3));
        }

        [Test]
        public void IsInF4to6Area()
        {
            Assert.IsTrue(_microphaseHelper.F4to6Contains(F4to6_1) &&
                          _microphaseHelper.F4to6Contains(F4to6_2) &&
                          _microphaseHelper.F4to6Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F2to4Contains(F4to6_1) ||
                          _microphaseHelper.F2to4Contains(F4to6_2) ||
                          _microphaseHelper.F2to4Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F0to2Contains(F4to6_1) ||
                         _microphaseHelper.F0to2Contains(F4to6_2) ||
                         _microphaseHelper.F0to2Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F6to8Contains(F4to6_1) ||
                          _microphaseHelper.F6to8Contains(F4to6_2) ||
                          _microphaseHelper.F6to8Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F8to10Contains(F4to6_1) ||
                          _microphaseHelper.F8to10Contains(F4to6_2) ||
                          _microphaseHelper.F8to10Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F10to12Contains(F4to6_1) ||
                          _microphaseHelper.F10to12Contains(F4to6_2) ||
                          _microphaseHelper.F10to12Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F12to14Contains(F4to6_1) ||
                          _microphaseHelper.F12to14Contains(F4to6_2) ||
                          _microphaseHelper.F12to14Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F14to16Contains(F4to6_1) ||
                          _microphaseHelper.F14to16Contains(F4to6_2) ||
                          _microphaseHelper.F14to16Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F16to18Contains(F4to6_1) ||
                          _microphaseHelper.F16to18Contains(F4to6_2) ||
                          _microphaseHelper.F16to18Contains(F4to6_3));

            Assert.IsFalse(_microphaseHelper.F18PlusContains(F4to6_1) ||
                          _microphaseHelper.F18PlusContains(F4to6_2) ||
                          _microphaseHelper.F18PlusContains(F4to6_3));
        }

        [Test]
        public void IsInF6to8Area()
        {
            Assert.IsTrue(_microphaseHelper.F6to8Contains(F6to8_1) &&
                          _microphaseHelper.F6to8Contains(F6to8_2) &&
                          _microphaseHelper.F6to8Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F4to6Contains(F6to8_1) ||
                          _microphaseHelper.F4to6Contains(F6to8_2) ||
                          _microphaseHelper.F4to6Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F2to4Contains(F6to8_1) ||
                          _microphaseHelper.F2to4Contains(F6to8_2) ||
                          _microphaseHelper.F2to4Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F0to2Contains(F6to8_1) ||
                         _microphaseHelper.F0to2Contains(F6to8_2) ||
                         _microphaseHelper.F0to2Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F8to10Contains(F6to8_1) ||
                          _microphaseHelper.F8to10Contains(F6to8_2) ||
                          _microphaseHelper.F8to10Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F10to12Contains(F6to8_1) ||
                          _microphaseHelper.F10to12Contains(F6to8_2) ||
                          _microphaseHelper.F10to12Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F12to14Contains(F6to8_1) ||
                          _microphaseHelper.F12to14Contains(F6to8_2) ||
                          _microphaseHelper.F12to14Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F14to16Contains(F6to8_1) ||
                          _microphaseHelper.F14to16Contains(F6to8_2) ||
                          _microphaseHelper.F14to16Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F16to18Contains(F6to8_1) ||
                          _microphaseHelper.F16to18Contains(F6to8_2) ||
                          _microphaseHelper.F16to18Contains(F6to8_3));

            Assert.IsFalse(_microphaseHelper.F18PlusContains(F6to8_1) ||
                          _microphaseHelper.F18PlusContains(F6to8_2) ||
                          _microphaseHelper.F18PlusContains(F6to8_3));
        }

        [Test]
        public void IsInF8to10Area()
        {
            Assert.IsTrue(_microphaseHelper.F8to10Contains(F8to10_1) &&
                          _microphaseHelper.F8to10Contains(F8to10_2) &&
                          _microphaseHelper.F8to10Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F6to8Contains(F8to10_1) ||
                          _microphaseHelper.F6to8Contains(F8to10_2) ||
                          _microphaseHelper.F6to8Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F4to6Contains(F8to10_1) ||
                          _microphaseHelper.F4to6Contains(F8to10_2) ||
                          _microphaseHelper.F4to6Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F2to4Contains(F8to10_1) ||
                          _microphaseHelper.F2to4Contains(F8to10_2) ||
                          _microphaseHelper.F2to4Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F0to2Contains(F8to10_1) ||
                         _microphaseHelper.F0to2Contains(F8to10_2) ||
                         _microphaseHelper.F0to2Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F10to12Contains(F8to10_1) ||
                          _microphaseHelper.F10to12Contains(F8to10_2) ||
                          _microphaseHelper.F10to12Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F12to14Contains(F8to10_1) ||
                          _microphaseHelper.F12to14Contains(F8to10_2) ||
                          _microphaseHelper.F12to14Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F14to16Contains(F8to10_1) ||
                          _microphaseHelper.F14to16Contains(F8to10_2) ||
                          _microphaseHelper.F14to16Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F16to18Contains(F8to10_1) ||
                          _microphaseHelper.F16to18Contains(F8to10_2) ||
                          _microphaseHelper.F16to18Contains(F8to10_3));

            Assert.IsFalse(_microphaseHelper.F18PlusContains(F8to10_1) ||
                          _microphaseHelper.F18PlusContains(F8to10_2) ||
                          _microphaseHelper.F18PlusContains(F8to10_3));
        }

        [Test]
        public void IsInF10to12Area()
        {
            Assert.IsTrue(_microphaseHelper.F10to12Contains(F10to12_1) &&
                          _microphaseHelper.F10to12Contains(F10to12_2) &&
                          _microphaseHelper.F10to12Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F8to10Contains(F10to12_1) ||
                          _microphaseHelper.F8to10Contains(F10to12_2) ||
                          _microphaseHelper.F8to10Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F6to8Contains(F10to12_1) ||
                          _microphaseHelper.F6to8Contains(F10to12_2) ||
                          _microphaseHelper.F6to8Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F4to6Contains(F10to12_1) ||
                          _microphaseHelper.F4to6Contains(F10to12_2) ||
                          _microphaseHelper.F4to6Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F2to4Contains(F10to12_1) ||
                          _microphaseHelper.F2to4Contains(F10to12_2) ||
                          _microphaseHelper.F2to4Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F0to2Contains(F10to12_1) ||
                         _microphaseHelper.F0to2Contains(F10to12_2) ||
                         _microphaseHelper.F0to2Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F12to14Contains(F10to12_1) ||
                          _microphaseHelper.F12to14Contains(F10to12_2) ||
                          _microphaseHelper.F12to14Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F14to16Contains(F10to12_1) ||
                          _microphaseHelper.F14to16Contains(F10to12_2) ||
                          _microphaseHelper.F14to16Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F16to18Contains(F10to12_1) ||
                          _microphaseHelper.F16to18Contains(F10to12_2) ||
                          _microphaseHelper.F16to18Contains(F10to12_3));

            Assert.IsFalse(_microphaseHelper.F18PlusContains(F10to12_1) ||
                          _microphaseHelper.F18PlusContains(F10to12_2) ||
                          _microphaseHelper.F18PlusContains(F10to12_3));
        }

        [Test]
        public void IsInF12to14Area()
        {
            Assert.IsTrue(_microphaseHelper.F12to14Contains(F12to14_1) &&
                          _microphaseHelper.F12to14Contains(F12to14_2) &&
                          _microphaseHelper.F12to14Contains(F12to14_3));
        }

        [Test]
        public void IsInF14to16Area()
        {
            Assert.IsTrue(_microphaseHelper.F14to16Contains(F14to16_1) &&
                          _microphaseHelper.F14to16Contains(F14to16_2) &&
                          _microphaseHelper.F14to16Contains(F14to16_3));
        }

        [Test]
        public void IsInF16to18Area()
        {
            Assert.IsTrue(_microphaseHelper.F16to18Contains(F16to18_1) &&
                          _microphaseHelper.F16to18Contains(F16to18_2) &&
                          _microphaseHelper.F16to18Contains(F16to18_3));
        }

        [Test]
        public void IsInF18UpArea()
        {
            Assert.IsTrue(_microphaseHelper.F18PlusContains(F18Up_1) &&
                          _microphaseHelper.F18PlusContains(F18Up_2) &&
                          _microphaseHelper.F18PlusContains(F18Up_3));
        }
    }
}