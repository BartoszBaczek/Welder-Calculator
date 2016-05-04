using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;
using WelderCalculator.Helpers.SchaefflerHelpers;

namespace Tests
{
    [TestFixture]
    public class ScahefflerMicrophaseHelperTests
    {
        private SchaefflerMicrophaseHelper _microphaseHelper;

        private readonly PointF inFMArea_1 = new PointF(0, 0);
        private readonly PointF inFMArea_2 = new PointF(0.2f, 7);
        private readonly PointF inFMArea_3 = new PointF(2.3f, 0.2f);

        private PointF inMArea_1;
        private PointF inMArea_2;
        private PointF inMArea_3;

        private PointF inAMArea_1;
        private PointF inAMArea_2;
        private PointF inAMArea_3;

        private PointF inAarea_1;
        private PointF inAarea_2;
        private PointF inAarea_3;

        private PointF inMFarea_1;
        private PointF inMFarea_2;
        private PointF inMFarea_3;

        private PointF inFarea_1;
        private PointF inFarea_2;
        private PointF inFarea_3;

        private PointF inAFarea_1;
        private PointF inAFarea_2;
        private PointF inAFarea_3;

        private PointF inAMFarea_1;
        private PointF inAMFarea_2;
        private PointF inAMFarea_3;


        
        [SetUp]
        public void Init()
        {
            _microphaseHelper = new SchaefflerMicrophaseHelper();
        }

        [Test]
        public void IsInFMArea()
        {
            Assert.IsTrue(_microphaseHelper.FMContainst(inFMArea_1) &&
                          _microphaseHelper.FMContainst(inFMArea_1) &&
                          _microphaseHelper.FMContainst(inFMArea_1));
        }


    }
}
