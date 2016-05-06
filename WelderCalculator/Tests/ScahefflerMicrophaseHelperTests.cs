using System.Drawing;
using NUnit.Framework;
using WelderCalculator.Helpers.SchaefflerHelpers;

namespace Tests
{
    [TestFixture]
    public class ScahefflerMicrophaseHelperTests
    {
        private SchaefflerMicrophaseHelper _microphaseHelper;

        private readonly PointF inFMArea_1 = new PointF(0f, 0f);
        private readonly PointF inFMArea_2 = new PointF(0.2f, 6.1f);
        private readonly PointF inFMArea_3 = new PointF(2.3f, 0.2f);

        private readonly PointF inMArea_1 = new PointF(13f, 8f);
        private readonly PointF inMArea_2 = new PointF(4f, 15.9f);
        private readonly PointF inMArea_3 = new PointF(13.8f, 7.9f);

        private readonly PointF inAMArea_1 = new PointF(0f, 20f);
        private readonly PointF inAMArea_2 = new PointF(16, 12);
        private readonly PointF inAMArea_3 = new PointF(12, 10);

        private readonly PointF inAarea_1 = new PointF(18f, 12f);
        private readonly PointF inAarea_2 = new PointF(2f, 24f);
        private readonly PointF inAarea_3 = new PointF(28f, 24f);

        private readonly PointF inMFarea_1 = new PointF(8f, 0f);
        private readonly PointF inMFarea_2 = new PointF(16f, 6f);
        private readonly PointF inMFarea_3 = new PointF(18f, 2.4f);

        private readonly PointF inFarea_1 = new PointF(32f, 6f);
        private readonly PointF inFarea_2 = new PointF(20f, 2f);
        private readonly PointF inFarea_3 = new PointF(26f, 4f);

        private readonly PointF inAMFarea_1 = new PointF(24f, 4f);
        private readonly PointF inAMFarea_2 = new PointF(18f, 10.5f);
        private readonly PointF inAMFarea_3 = new PointF(20f, 4f);

        private readonly PointF inAFarea_1 = new PointF(28f, 18f);
        private readonly PointF inAFarea_2 = new PointF(30f, 6f);
        private readonly PointF inAFarea_3 = new PointF(22f, 10f);

        private readonly PointF inF0to5area_1 = new PointF(22f, 15.9f);
        private readonly PointF inF0to5area_2 = new PointF(26f, 20f);
        private readonly PointF inF0to5area_3 = new PointF(16f, 9f);

        private readonly PointF inF5to10area_1 = new PointF(16f, 8f);
        private readonly PointF inF5to10area_2 = new PointF(20f, 12f);
        private readonly PointF inF5to10area_3 = new PointF(26f, 18f);

        private readonly PointF inF10to20area_1 = new PointF(18f, 8f);
        private readonly PointF inF10to20area_2 = new PointF(24f, 14f);
        private readonly PointF inF10to20area_3 = new PointF(30f, 16f);

        private readonly PointF inF20to40area_1 = new PointF(18f, 6f);
        private readonly PointF inF20to40area_2 = new PointF(24f, 10f);
        private readonly PointF inF20to40area_3 = new PointF(30f, 14f);

        private readonly PointF inF40to80area_1 = new PointF(20f, 6f);
        private readonly PointF inF40to80area_2 = new PointF(22f, 7f);
        private readonly PointF inF40to80area_3 = new PointF(28f, 10f);

        private readonly PointF inF80to100area_1 = new PointF(20f, 4f);
        private readonly PointF inF80to100area_2 = new PointF(32f, 8f);
        private readonly PointF inF80to100area_3 = new PointF(24f, 6f);

        [SetUp]
        public void Init()
        {
            _microphaseHelper = new SchaefflerMicrophaseHelper();
        }

        [Test]
        public void IsInFMArea()
        {
            Assert.IsTrue(_microphaseHelper.FMContainst(inFMArea_1) &&
                          _microphaseHelper.FMContainst(inFMArea_2) &&
                          _microphaseHelper.FMContainst(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inFMArea_1) ||
                           _microphaseHelper.MContains(inFMArea_2) ||
                           _microphaseHelper.MContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inFMArea_1) ||
                           _microphaseHelper.AMContains(inFMArea_2) ||
                           _microphaseHelper.AMContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inFMArea_1) ||
                          _microphaseHelper.AContains(inFMArea_2) ||
                          _microphaseHelper.AContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inFMArea_1) ||
                         _microphaseHelper.MFContains(inFMArea_2) ||
                         _microphaseHelper.MFContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inFMArea_1) ||
                          _microphaseHelper.FContains(inFMArea_2) ||
                          _microphaseHelper.FContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.AMFContains(inFMArea_1) &&
                          _microphaseHelper.AMFContains(inFMArea_2) &&
                          _microphaseHelper.AMFContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inFMArea_1) &&
                          _microphaseHelper.AFContains(inFMArea_2) &&
                          _microphaseHelper.AFContains(inFMArea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inFMArea_1) ||
                          _microphaseHelper.F0to5Contains(inFMArea_2) ||
                          _microphaseHelper.F0to5Contains(inFMArea_3));
        }

        [Test]
        public void IsInMArea()
        {
            Assert.IsTrue(_microphaseHelper.MContains(inMArea_1) &&
                          _microphaseHelper.MContains(inMArea_2) &&
                          _microphaseHelper.MContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inMArea_1) ||
                           _microphaseHelper.FMContainst(inMArea_2) ||
                           _microphaseHelper.FMContainst(inMArea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inMArea_1) ||
                           _microphaseHelper.AMContains(inMArea_2) ||
                           _microphaseHelper.AMContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inMArea_1) ||
                          _microphaseHelper.AContains(inMArea_2) ||
                          _microphaseHelper.AContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inMArea_1) ||
                         _microphaseHelper.MFContains(inMArea_2) ||
                         _microphaseHelper.MFContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inMArea_1) ||
                          _microphaseHelper.FContains(inMArea_2) ||
                          _microphaseHelper.FContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.AMFContains(inMArea_1) &&
                          _microphaseHelper.AMFContains(inMArea_2) &&
                          _microphaseHelper.AMFContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inMArea_1) &&
                          _microphaseHelper.AFContains(inMArea_2) &&
                          _microphaseHelper.AFContains(inMArea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inMArea_1) ||
                          _microphaseHelper.F0to5Contains(inMArea_2) ||
                          _microphaseHelper.F0to5Contains(inMArea_3));
        }

        [Test]
        public void IsInAMArea()
        {
            Assert.IsTrue(_microphaseHelper.AMContains(inAMArea_1) &&
                          _microphaseHelper.AMContains(inAMArea_2) &&
                          _microphaseHelper.AMContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inAMArea_1) ||
                           _microphaseHelper.MContains(inAMArea_2) ||
                           _microphaseHelper.MContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inAMArea_1) ||
                           _microphaseHelper.FMContainst(inAMArea_2) ||
                           _microphaseHelper.FMContainst(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inAMArea_1) ||
                          _microphaseHelper.AContains(inAMArea_2) ||
                          _microphaseHelper.AContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inAMArea_1) ||
                         _microphaseHelper.MFContains(inAMArea_2) ||
                         _microphaseHelper.MFContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inAMArea_1) ||
                          _microphaseHelper.FContains(inAMArea_2) ||
                          _microphaseHelper.FContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.AMFContains(inAMArea_1) &&
                          _microphaseHelper.AMFContains(inAMArea_2) &&
                          _microphaseHelper.AMFContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inAMArea_1) &&
                          _microphaseHelper.AFContains(inAMArea_2) &&
                          _microphaseHelper.AFContains(inAMArea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inAMArea_1) ||
                          _microphaseHelper.F0to5Contains(inAMArea_2) ||
                          _microphaseHelper.F0to5Contains(inAMArea_3));
        }

        [Test]
        public void IsInAarea()
        {
            Assert.IsTrue(_microphaseHelper.AContains(inAarea_1) &&
                          _microphaseHelper.AContains(inAarea_2) &&
                          _microphaseHelper.AContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inAarea_1) ||
                         _microphaseHelper.AMContains(inAarea_2) ||
                         _microphaseHelper.AMContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inAarea_1) ||
                          _microphaseHelper.MContains(inAarea_2) ||
                          _microphaseHelper.MContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inAarea_1) ||
                          _microphaseHelper.FMContainst(inAarea_2) ||
                          _microphaseHelper.FMContainst(inAarea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inAarea_1) ||
                         _microphaseHelper.MFContains(inAarea_2) ||
                         _microphaseHelper.MFContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inAarea_1) ||
                          _microphaseHelper.FContains(inAarea_2) ||
                          _microphaseHelper.FContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.AMFContains(inAarea_1) &&
                          _microphaseHelper.AMFContains(inAarea_2) &&
                          _microphaseHelper.AMFContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inAarea_1) &&
                          _microphaseHelper.AFContains(inAarea_2) &&
                          _microphaseHelper.AFContains(inAarea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inAarea_1) ||
                          _microphaseHelper.F0to5Contains(inAarea_2) ||
                          _microphaseHelper.F0to5Contains(inAarea_3));
        }

        [Test]
        public void IsInMFArea()
        {
            Assert.IsTrue(_microphaseHelper.MFContains(inMFarea_1) &&
                         _microphaseHelper.MFContains(inMFarea_2) &&
                         _microphaseHelper.MFContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inMFarea_1) ||
                          _microphaseHelper.AContains(inMFarea_2) ||
                          _microphaseHelper.AContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inMFarea_1) ||
                          _microphaseHelper.AMContains(inMFarea_2) ||
                          _microphaseHelper.AMContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inMFarea_1) ||
                          _microphaseHelper.MContains(inMFarea_2) ||
                          _microphaseHelper.MContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inMFarea_1) ||
                          _microphaseHelper.FMContainst(inMFarea_2) ||
                          _microphaseHelper.FMContainst(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inMFarea_1) ||
                          _microphaseHelper.FContains(inMFarea_2) ||
                          _microphaseHelper.FContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.AMFContains(inMFarea_1) &&
                          _microphaseHelper.AMFContains(inMFarea_2) &&
                          _microphaseHelper.AMFContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inMFarea_1) &&
                          _microphaseHelper.AFContains(inMFarea_2) &&
                          _microphaseHelper.AFContains(inMFarea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inMFarea_1) ||
                          _microphaseHelper.F0to5Contains(inMFarea_2) ||
                          _microphaseHelper.F0to5Contains(inMFarea_3));
        }

        [Test]
        public void IsInFArea()
        {
            Assert.IsTrue(_microphaseHelper.FContains(inFarea_1) && 
                          _microphaseHelper.FContains(inFarea_2) &&
                          _microphaseHelper.FContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inFarea_1) ||
                         _microphaseHelper.AContains(inFarea_2) ||
                         _microphaseHelper.AContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inFarea_1) ||
                         _microphaseHelper.MFContains(inFarea_2) ||
                         _microphaseHelper.MFContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inFarea_1) ||
                          _microphaseHelper.AMContains(inFarea_2) ||
                          _microphaseHelper.AMContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inFarea_1) ||
                          _microphaseHelper.MContains(inFarea_2) ||
                          _microphaseHelper.MContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inFarea_1) ||
                          _microphaseHelper.FMContainst(inFarea_2) ||
                          _microphaseHelper.FMContainst(inFarea_3));

            Assert.IsFalse(_microphaseHelper.AMFContains(inFarea_1) &&
                          _microphaseHelper.AMFContains(inFarea_2) &&
                          _microphaseHelper.AMFContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inFarea_1) &&
                          _microphaseHelper.AFContains(inFarea_2) &&
                          _microphaseHelper.AFContains(inFarea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inFarea_1) ||
                          _microphaseHelper.F0to5Contains(inFarea_2) ||
                          _microphaseHelper.F0to5Contains(inFarea_3));
        }

        [Test]
        public void isInAMFArea()
        {
            Assert.IsTrue(_microphaseHelper.AMFContains(inAMFarea_1) && 
                          _microphaseHelper.AMFContains(inAMFarea_2) && 
                          _microphaseHelper.AMFContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inAMFarea_1) ||
                          _microphaseHelper.FContains(inAMFarea_2) ||
                          _microphaseHelper.FContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inAMFarea_1) ||
                         _microphaseHelper.AContains(inAMFarea_2) ||
                         _microphaseHelper.AContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inAMFarea_1) ||
                         _microphaseHelper.MFContains(inAMFarea_2) ||
                         _microphaseHelper.MFContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inAMFarea_1) ||
                          _microphaseHelper.AMContains(inAMFarea_2) ||
                          _microphaseHelper.AMContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inAMFarea_1) ||
                          _microphaseHelper.MContains(inAMFarea_2) ||
                          _microphaseHelper.MContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inAMFarea_1) ||
                          _microphaseHelper.FMContainst(inAMFarea_2) ||
                          _microphaseHelper.FMContainst(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.AFContains(inAMFarea_1) &&
                          _microphaseHelper.AFContains(inAMFarea_2) &&
                          _microphaseHelper.AFContains(inAMFarea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inAMFarea_1) ||
                          _microphaseHelper.F0to5Contains(inAMFarea_2) ||
                          _microphaseHelper.F0to5Contains(inAMFarea_3));
        }

        [Test]
        public void IsInAFArea()
        {
            Assert.IsTrue(_microphaseHelper.AFContains(inAFarea_1) &&
                          _microphaseHelper.AFContains(inAFarea_2) &&
                          _microphaseHelper.AFContains(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.AContains(inAFarea_1) ||
                         _microphaseHelper.AContains(inAFarea_1) ||
                         _microphaseHelper.AContains(inAFarea_1));

            Assert.IsFalse(_microphaseHelper.AMFContains(inAFarea_1) ||
                          _microphaseHelper.AMFContains(inAFarea_2) ||
                          _microphaseHelper.AMFContains(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.FContains(inAFarea_1) ||
                          _microphaseHelper.FContains(inAFarea_2) ||
                          _microphaseHelper.FContains(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inAFarea_1) ||
                         _microphaseHelper.MFContains(inAFarea_2) ||
                         _microphaseHelper.MFContains(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inAFarea_1) ||
                          _microphaseHelper.AMContains(inAFarea_2) ||
                          _microphaseHelper.AMContains(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.MContains(inAFarea_1) ||
                          _microphaseHelper.MContains(inAFarea_2) ||
                          _microphaseHelper.MContains(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inAFarea_1) ||
                          _microphaseHelper.FMContainst(inAFarea_2) ||
                          _microphaseHelper.FMContainst(inAFarea_3));

            Assert.IsFalse(_microphaseHelper.F0to5Contains(inAFarea_1) ||
                          _microphaseHelper.F0to5Contains(inAFarea_2) ||
                          _microphaseHelper.F0to5Contains(inAFarea_3));
        }

        [Test]
        public void IsInF0to5Area()
        {
            Assert.IsTrue(_microphaseHelper.F0to5Contains(inF0to5area_1) && 
                          _microphaseHelper.F0to5Contains(inF0to5area_2) && 
                          _microphaseHelper.F0to5Contains(inF0to5area_3));

            Assert.IsTrue((_microphaseHelper.AFContains(inF0to5area_1) || _microphaseHelper.AMFContains(inF0to5area_1)) &&
                          (_microphaseHelper.AFContains(inF0to5area_2) || _microphaseHelper.AMFContains(inF0to5area_2)) &&
                          (_microphaseHelper.AFContains(inF0to5area_3) || _microphaseHelper.AMFContains(inF0to5area_3)));

            Assert.IsFalse(_microphaseHelper.AContains(inF0to5area_1) ||
                         _microphaseHelper.AContains(inF0to5area_2) ||
                         _microphaseHelper.AContains(inF0to5area_3));

            Assert.IsFalse(_microphaseHelper.FContains(inF0to5area_1) ||
                          _microphaseHelper.FContains(inF0to5area_2) ||
                          _microphaseHelper.FContains(inF0to5area_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inF0to5area_1) ||
                         _microphaseHelper.MFContains(inF0to5area_2) ||
                         _microphaseHelper.MFContains(inF0to5area_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inF0to5area_1) ||
                          _microphaseHelper.AMContains(inF0to5area_2) ||
                          _microphaseHelper.AMContains(inF0to5area_3));

            Assert.IsFalse(_microphaseHelper.MContains(inF0to5area_1) ||
                          _microphaseHelper.MContains(inF0to5area_2) ||
                          _microphaseHelper.MContains(inF0to5area_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inF0to5area_1) ||
                          _microphaseHelper.FMContainst(inF0to5area_2) ||
                          _microphaseHelper.FMContainst(inF0to5area_3));
        }

        [Test]
        public void IsInF5to10area()
        {
            Assert.IsTrue(_microphaseHelper.F5to10Contains(inF5to10area_1) &&
                          _microphaseHelper.F5to10Contains(inF5to10area_2) &&
                          _microphaseHelper.F5to10Contains(inF5to10area_3));

            Assert.IsTrue((_microphaseHelper.AFContains(inF5to10area_1) || _microphaseHelper.AMFContains(inF5to10area_1)) &&
                          (_microphaseHelper.AFContains(inF5to10area_2) || _microphaseHelper.AMFContains(inF5to10area_2)) &&
                          (_microphaseHelper.AFContains(inF5to10area_3) || _microphaseHelper.AMFContains(inF5to10area_3)));

            Assert.IsFalse(_microphaseHelper.AContains(inF5to10area_1) ||
                         _microphaseHelper.AContains(inF5to10area_2) ||
                         _microphaseHelper.AContains(inF5to10area_3));

            Assert.IsFalse(_microphaseHelper.FContains(inF5to10area_1) ||
                          _microphaseHelper.FContains(inF5to10area_2) ||
                          _microphaseHelper.FContains(inF5to10area_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inF5to10area_1) ||
                         _microphaseHelper.MFContains(inF5to10area_2) ||
                         _microphaseHelper.MFContains(inF5to10area_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inF5to10area_1) ||
                          _microphaseHelper.AMContains(inF5to10area_2) ||
                          _microphaseHelper.AMContains(inF5to10area_3));

            Assert.IsFalse(_microphaseHelper.MContains(inF5to10area_1) ||
                          _microphaseHelper.MContains(inF5to10area_2) ||
                          _microphaseHelper.MContains(inF5to10area_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inF5to10area_1) ||
                          _microphaseHelper.FMContainst(inF5to10area_2) ||
                          _microphaseHelper.FMContainst(inF5to10area_3));
        }

        [Test]
        public void IsInF10to20area()
        {
            Assert.IsTrue(_microphaseHelper.F10to20Contains(inF10to20area_1) &&
                          _microphaseHelper.F10to20Contains(inF10to20area_2) &&
                          _microphaseHelper.F10to20Contains(inF10to20area_3));

            Assert.IsTrue((_microphaseHelper.AFContains(inF10to20area_1) || _microphaseHelper.AMFContains(inF10to20area_1)) &&
                          (_microphaseHelper.AFContains(inF10to20area_2) || _microphaseHelper.AMFContains(inF10to20area_2)) &&
                          (_microphaseHelper.AFContains(inF10to20area_3) || _microphaseHelper.AMFContains(inF10to20area_3)));

            Assert.IsFalse(_microphaseHelper.AContains(inF10to20area_1) ||
                         _microphaseHelper.AContains(inF10to20area_2) ||
                         _microphaseHelper.AContains(inF10to20area_3));

            Assert.IsFalse(_microphaseHelper.FContains(inF10to20area_1) ||
                          _microphaseHelper.FContains(inF10to20area_2) ||
                          _microphaseHelper.FContains(inF10to20area_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inF10to20area_1) ||
                         _microphaseHelper.MFContains(inF10to20area_2) ||
                         _microphaseHelper.MFContains(inF10to20area_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inF10to20area_1) ||
                          _microphaseHelper.AMContains(inF10to20area_2) ||
                          _microphaseHelper.AMContains(inF10to20area_3));

            Assert.IsFalse(_microphaseHelper.MContains(inF10to20area_1) ||
                          _microphaseHelper.MContains(inF10to20area_2) ||
                          _microphaseHelper.MContains(inF10to20area_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inF10to20area_1) ||
                          _microphaseHelper.FMContainst(inF10to20area_2) ||
                          _microphaseHelper.FMContainst(inF10to20area_3));
        }

        [Test]
        public void IsInF20to40area()
        {
            Assert.IsTrue(_microphaseHelper.F20to40Contains(inF20to40area_1) &&
                          _microphaseHelper.F20to40Contains(inF20to40area_2) &&
                          _microphaseHelper.F20to40Contains(inF20to40area_3));

            Assert.IsTrue((_microphaseHelper.AFContains(inF20to40area_1) || _microphaseHelper.AMFContains(inF20to40area_1)) &&
                          (_microphaseHelper.AFContains(inF20to40area_2) || _microphaseHelper.AMFContains(inF20to40area_2)) &&
                          (_microphaseHelper.AFContains(inF20to40area_3) || _microphaseHelper.AMFContains(inF20to40area_3)));

            Assert.IsFalse(_microphaseHelper.AContains(inF20to40area_1) ||
                         _microphaseHelper.AContains(inF20to40area_2) ||
                         _microphaseHelper.AContains(inF20to40area_3));

            Assert.IsFalse(_microphaseHelper.FContains(inF20to40area_1) ||
                          _microphaseHelper.FContains(inF20to40area_2) ||
                          _microphaseHelper.FContains(inF20to40area_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inF20to40area_1) ||
                         _microphaseHelper.MFContains(inF20to40area_2) ||
                         _microphaseHelper.MFContains(inF20to40area_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inF20to40area_1) ||
                          _microphaseHelper.AMContains(inF20to40area_2) ||
                          _microphaseHelper.AMContains(inF20to40area_3));

            Assert.IsFalse(_microphaseHelper.MContains(inF20to40area_1) ||
                          _microphaseHelper.MContains(inF20to40area_2) ||
                          _microphaseHelper.MContains(inF20to40area_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inF20to40area_1) ||
                          _microphaseHelper.FMContainst(inF20to40area_2) ||
                          _microphaseHelper.FMContainst(inF20to40area_3));
        }

        [Test]
        public void IsInF40to80area()
        {
            Assert.IsTrue(_microphaseHelper.F40to80Contains(inF40to80area_2) && 
                          _microphaseHelper.F40to80Contains(inF40to80area_2) && 
                          _microphaseHelper.F40to80Contains(inF40to80area_3));

            Assert.IsTrue((_microphaseHelper.AFContains(inF40to80area_1) || _microphaseHelper.AMFContains(inF40to80area_1)) &&
                          (_microphaseHelper.AFContains(inF40to80area_2) || _microphaseHelper.AMFContains(inF40to80area_2)) &&
                          (_microphaseHelper.AFContains(inF40to80area_3) || _microphaseHelper.AMFContains(inF40to80area_3)));

            Assert.IsFalse(_microphaseHelper.AContains(inF40to80area_1) ||
                         _microphaseHelper.AContains(inF40to80area_2) ||
                         _microphaseHelper.AContains(inF40to80area_3));

            Assert.IsFalse(_microphaseHelper.FContains(inF40to80area_1) ||
                          _microphaseHelper.FContains(inF40to80area_2) ||
                          _microphaseHelper.FContains(inF40to80area_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inF40to80area_1) ||
                         _microphaseHelper.MFContains(inF40to80area_2) ||
                         _microphaseHelper.MFContains(inF40to80area_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inF40to80area_1) ||
                          _microphaseHelper.AMContains(inF40to80area_2) ||
                          _microphaseHelper.AMContains(inF40to80area_3));

            Assert.IsFalse(_microphaseHelper.MContains(inF40to80area_1) ||
                          _microphaseHelper.MContains(inF40to80area_2) ||
                          _microphaseHelper.MContains(inF40to80area_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inF40to80area_1) ||
                          _microphaseHelper.FMContainst(inF40to80area_2) ||
                          _microphaseHelper.FMContainst(inF40to80area_3));
        }

        [Test]
        public void IsInF80to100area()
        {
            Assert.IsTrue(_microphaseHelper.F80to100Contains(inF80to100area_1) &&
                          _microphaseHelper.F80to100Contains(inF80to100area_2) &&
                          _microphaseHelper.F80to100Contains(inF80to100area_3));

            Assert.IsTrue((_microphaseHelper.AFContains(inF80to100area_1) || _microphaseHelper.AMFContains(inF80to100area_1)) &&
                          (_microphaseHelper.AFContains(inF80to100area_2) || _microphaseHelper.AMFContains(inF80to100area_2)) &&
                          (_microphaseHelper.AFContains(inF80to100area_3) || _microphaseHelper.AMFContains(inF80to100area_3)));

            Assert.IsFalse(_microphaseHelper.AContains(inF80to100area_1) ||
                         _microphaseHelper.AContains(inF80to100area_2) ||
                         _microphaseHelper.AContains(inF80to100area_3));

            Assert.IsFalse(_microphaseHelper.FContains(inF80to100area_1) ||
                          _microphaseHelper.FContains(inF80to100area_2) ||
                          _microphaseHelper.FContains(inF80to100area_3));

            Assert.IsFalse(_microphaseHelper.MFContains(inF80to100area_1) ||
                         _microphaseHelper.MFContains(inF80to100area_2) ||
                         _microphaseHelper.MFContains(inF80to100area_3));

            Assert.IsFalse(_microphaseHelper.AMContains(inF80to100area_1) ||
                          _microphaseHelper.AMContains(inF80to100area_2) ||
                          _microphaseHelper.AMContains(inF80to100area_3));

            Assert.IsFalse(_microphaseHelper.MContains(inF80to100area_1) ||
                          _microphaseHelper.MContains(inF80to100area_2) ||
                          _microphaseHelper.MContains(inF80to100area_3));

            Assert.IsFalse(_microphaseHelper.FMContainst(inF80to100area_1) ||
                          _microphaseHelper.FMContainst(inF80to100area_2) ||
                          _microphaseHelper.FMContainst(inF80to100area_3));
        }
    }
}
