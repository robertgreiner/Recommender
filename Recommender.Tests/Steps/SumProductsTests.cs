using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;
using Recommender.Reviews;
using Recommender.Steps;

namespace Recommender.Tests.Steps
{
    [TestFixture]
    class SumProductsTests
    {
        private Reviewer r1;
        private Reviewer r2;
        private List<String> similarReviews;

        [SetUp]
        public void SetUp()
        {
            r1 = ReviewerBuilder.BuildReviewer1();
            r2 = ReviewerBuilder.BuildReviewer2();
            similarReviews = new FindSimilarReviews(r1.Reviews, r2.Reviews).Calculate();
        }

        [Test]
        public void ShouldSumTheProductsOfBothReviewers()
        {
            Assert.AreEqual(59.5, new SumProducts(similarReviews, r1.Reviews, r2.Reviews).Calculate());
        }
    }
}
