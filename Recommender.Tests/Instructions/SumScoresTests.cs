using System;
using System.Collections.Generic;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;
using Recommender.Instructions;
using Recommender.Reviews;

namespace Recommender.Tests.Instructions
{
    [TestFixture]
    class SumScoresTests
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
        public void SumASingleScoreFromOneUser()
        {
            r1 = ReviewerBuilder.BuildOneReviewMax();
            similarReviews = new List<string>(new String[] {"C# in Depth"});
            Assert.AreEqual(5.0, new SumScores(similarReviews, r1.Reviews).Calculate());
        }

        [Test]
        public void ShouldSumAllOfTheScoresFromTheFirstUser()
        {
            Assert.AreEqual(15.0, new SumScores(similarReviews, r1.Reviews).Calculate());
        }

        [Test]
        public void ShouldSumAllOfTheScoresFromTheSecondUser()
        {
            Assert.AreEqual(19.5, new SumScores(similarReviews, r2.Reviews).Calculate());
        }
    }
}
