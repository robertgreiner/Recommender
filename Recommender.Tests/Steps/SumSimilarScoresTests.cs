﻿using System;
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
    class SumSimilarScoresTests
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
            Assert.AreEqual(5.0, new SumSimilarScores(similarReviews, r1.Reviews).Calculate());
        }

        [Test]
        public void ShouldSumAllOfTheScoresFromTheFirstUser()
        {
            Assert.AreEqual(18.0, new SumSimilarScores(similarReviews, r1.Reviews).Calculate());
        }

        [Test]
        public void ShouldSumAllOfTheScoresFromTheSecondUser()
        {
            Assert.AreEqual(19.5, new SumSimilarScores(similarReviews, r2.Reviews).Calculate());
        }
    }
}