using System;
using Web.Helpers;

namespace Testing
{
	public class ToplamaTests
	{

		[Test]
		public void Odd_Number()
		{
			int res = Toplama.Topla(4,4);

			Assert.AreEqual(8, res);
		}


        [Test]
        public void Negative_Number()
        {
            int res = Toplama.Topla(-4, -7);

            Assert.AreEqual(-11, res);
        }


        [Test]
        public void Negative_Big_Positive_Small_Number()
        {
            int res = Toplama.Topla(-15, 7);

            Assert.AreEqual(-8, res);
        }


    }
}

