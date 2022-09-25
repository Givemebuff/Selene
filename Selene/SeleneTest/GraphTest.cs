using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selene.Graph;

namespace SeleneTest
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void BuildTest()
        {
            var pt1 = new Point<int>();
            var pt2 = new Point<float>();
            var pt3 = new Point<double>();

            var size1 = new Size<int>();
            var size2 = new Size<float>();
            var size3 = new Size<double>();

            var rect1 = new Rect<int>() { Left = 1, Top = 1, Right = 11, Bottom = 11 };
            var rect2 = new Rect<float>() { Left = 1f, Top = 1f, Right = 11f, Bottom = 11f };
            var rect3 = new Rect<double>() { Left = 1d, Top = 1d, Right = 11d, Bottom = 11d };

            Assert.IsTrue(true);
        }
    }
}