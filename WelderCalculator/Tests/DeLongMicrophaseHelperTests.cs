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
        private readonly PointF F8to10_2 = new PointF(20f, 12f);
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

        }

        [Test]
        public void IsInAArea()
        {

        }

        [Test]
        public void IsInF0to2Area()
        {

        }

        [Test]
        public void IsInF2to4Area()
        {

        }

        [Test]
        public void IsInF4to6Area()
        {

        }

        [Test]
        public void IsInF6to8Area()
        {

        }

        [Test]
        public void IsInF8to10Area()
        {

        }

        [Test]
        public void IsInF10to12Area()
        {

        }

        [Test]
        public void IsInF12to14Area()
        {

        }

        [Test]
        public void IsInF14to16Area()
        {

        }

        [Test]
        public void IsInF16to18Area()
        {

        }

        [Test]
        public void IsInF18UpArea()
        {

        }
    }
}