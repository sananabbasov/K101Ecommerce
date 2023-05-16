using System;
using Web.Helpers;

namespace Testing
{
	public class SeoUrlTests
	{
		[Test]
		public void UpperCase_Seo_Url_Tests()
		{
			var text = "Vektor dizayn proqramlarından istifadə edin.";
			var result = "vektor-dizayn-proqramlarindan-istifade-edin";
            var methodResult = SeoHelper.SeoUrlCreater(text);
			Assert.AreEqual(result,methodResult);
		}

        [Test]
        public void Seo_Url_White_Space_Tests()
        {
            var text = "Vektor dizayn  proqramlarından  istifadə edin.";
            var result = "vektor-dizayn-proqramlarindan-istifade-edin";
            var methodResult = SeoHelper.SeoUrlCreater(text);
            Assert.AreEqual(result, methodResult);
        }

        [Test]
        public void Seo_Url_Character_Tests()
        {
            var text = "Vektor- dizayn,  proqramlarından?  istifadə edin.";
            var result = "vektor-dizayn-proqramlarindan-istifade-edin";
            var methodResult = SeoHelper.SeoUrlCreater(text);
            Assert.AreEqual(result, methodResult);
        }
    }
}

