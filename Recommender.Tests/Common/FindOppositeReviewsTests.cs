using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;

namespace Recommender.Tests.Common
{
    [TestFixture]
    class FindOppositeReviewsTests
    {

        [Test]
        public void TwoDistinctReviewersShouldHaveOneOppositeReview()
        {
            var r1 = ReviewerBuilder.BuildOneReviewMax();
            var r2 = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            Assert.AreEqual(1, new FindOppositeReviews(r1.Reviews, r2.Reviews).Calculate().Count);
        }

        [Test]
        public void ShouldReturnSecondUsersUniqueReview()
        {
            var r1 = ReviewerBuilder.BuildOneReviewMax();
            var r2 = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            Assert.AreEqual("Chess", new FindOppositeReviews(r1.Reviews, r2.Reviews).Calculate().First());
        }

        [Test]
        public void ReviewersThatHaveTheExactSameTasteShouldHaveNoOppositeItems()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildReviewer1();
            Assert.AreEqual(0, new FindOppositeReviews(r1.Reviews, r2.Reviews).Calculate().Count);
        }

        [Test]
        public void ReviewsWithAScoreOfZeroShouldBeIgnored()
        {
            var r1 = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            var invalidReviewer = ReviewerBuilder.BuildReviewerWithInvalidReviews();
            Assert.AreEqual(0, new FindOppositeReviews(r1.Reviews, invalidReviewer.Reviews).Calculate().Count);
        }
    }
}
