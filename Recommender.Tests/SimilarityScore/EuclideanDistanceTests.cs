using NUnit.Framework;
using Recommender.Data;
using Recommender.SimilarityScore;

namespace Recommender.Tests.SimilarityScore
{
    [TestFixture]
    class EuclideanDistanceTests
    {
        private EuclideanDistance euclideanDistance;

        [SetUp]
        public void SetUp()
        {
            euclideanDistance = new EuclideanDistance(ReviewerBuilder.BuildReviewer1(), ReviewerBuilder.BuildReviewer2());
        }

        [Test]
        public void TwoReviewersWithSomeSimilarReviewsShouldHaveAScoreBetweenZeroAndOne()
        {
            Assert.AreEqual(0.037, euclideanDistance.Score());
        }

        [Test]
        public void TwoReviewersWithSomeSimilarReviewsShouldHaveAPositiveScore()
        {
            euclideanDistance = new EuclideanDistance(ReviewerBuilder.BuildReviewer6(), ReviewerBuilder.BuildReviewer7());
            Assert.AreEqual(0.148, euclideanDistance.Score());
        }

        [Test]
        public void TwoReviewersWithSomeSimilarReviewsShouldHaveAPositiveScoreRegardlessOfOrder()
        {
            euclideanDistance = new EuclideanDistance(ReviewerBuilder.BuildReviewer7(), ReviewerBuilder.BuildReviewer6());
            Assert.AreEqual(0.148, euclideanDistance.Score());
        }

        [Test]
        public void ReviewersThatHaveReviewedUniqueTitlesShouldNotBeSimilar()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            euclideanDistance = new EuclideanDistance(r1, r2);
            Assert.AreEqual(0, euclideanDistance.Score());
        }

        [Test]
        public void ReviewersThatHaveTheSameTasteShouldHaveAPerfectScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            euclideanDistance = new EuclideanDistance(r1, r1);
            Assert.AreEqual(1.0, euclideanDistance.Score());
        }
    }
}
