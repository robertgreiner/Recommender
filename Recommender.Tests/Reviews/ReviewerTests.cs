using System.Linq;
using NUnit.Framework;
using Recommender.Data;
using Recommender.Reviews;

namespace Recommender.Tests.Reviews
{
    [TestFixture]
    class ReviewerTests
    {
        private Reviewer reviewer;

        [SetUp]
        public void SetUp()
        {
            reviewer = new Reviewer();
        }

        [Test]
        public void ReviewerShouldHaveAName()
        {
            reviewer.Name = "Robert";
        }

        [Test]
        public void ReviewerShouldStartWithNoReviews()
        {
            Assert.IsEmpty(reviewer.Reviews);
        }

        [Test]
        public void ReviewerShouldHaveAValidReview()
        {
            reviewer.AddReview("Clean Code", 5);
            Assert.IsNotEmpty(reviewer.Reviews);
        }

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
            Assert.AreEqual(1, r1.SimilarReviews(r2.Reviews).Count);
        }

        [Test]
        public void ReviewersThatHaveTheSameTasteShouldHaveAllSimilarItems()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildReviewer1();
            Assert.AreEqual(6, r1.SimilarReviews(r2.Reviews).Count);
        }
    }
}
