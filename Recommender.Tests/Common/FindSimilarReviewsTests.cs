using System.Linq;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;

namespace Recommender.Tests.Common
{
    [TestFixture]
    class FindSimilarReviewsTests
    {
        [Test]
        public void ShouldHaveASingleMaximumReview()
        {
            var max = ReviewerBuilder.BuildOneReviewMax();
            Assert.AreEqual(5, max.Reviews.First().Value);
        }

        [Test]
        public void TwoSimilarReviewersShouldHaveOneLikeReview()
        {
            var r1 = ReviewerBuilder.BuildOneReviewMax();
            var r2 = ReviewerBuilder.BuildOneReviewMin();
            Assert.AreEqual(1, new FindSimilarReviews(r1.Reviews, r2.Reviews).Calculate().Count);
        }

        [Test]
        public void ReviewersThatHaveTheSameTasteShouldHaveAllSimilarItems()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildReviewer1();
            Assert.AreEqual(6, new FindSimilarReviews(r1.Reviews, r2.Reviews).Calculate().Count);
        }

        [Test]
        public void ReviewsWithAScoreOfZeroShouldBeIgnored()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var invalidReviewer = ReviewerBuilder.BuildReviewerWithInvalidReviews();
            Assert.AreEqual(0, new FindSimilarReviews(r1.Reviews, invalidReviewer.Reviews).Calculate().Count);
        }

        [Test]
        public void ReviewsWithAScoreOfZeroShouldBeIgnoredSwitchUsers()
        {
            var r1 = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            var invalidReviewer = ReviewerBuilder.BuildReviewerWithInvalidReviews();
            Assert.AreEqual(0, new FindSimilarReviews(invalidReviewer.Reviews, r1.Reviews).Calculate().Count);
        }
    }
}
