﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;
using Recommender.Instructions;
using Recommender.Reviews;

namespace Recommender.Tests.Instructions
{
    [TestFixture]
    class SumSquaresTests
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
        public void ShouldSumTheSquaresOfAllOfTheScoresFromTheFirstUser()
        {
            Assert.AreEqual(44.0, new SumSquares(similarReviews, r1.Reviews).Calculate());
        }

        [Test]
        public void ShouldSumTheSquaresOfAllOfTheScoresFromTheSecondUser()
        {
            Assert.AreEqual(69.75, new SumSquares(similarReviews, r2.Reviews).Calculate());
        }

    }
}
