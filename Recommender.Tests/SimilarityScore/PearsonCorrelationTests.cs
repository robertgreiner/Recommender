using NUnit.Framework;
using Recommender.Data;
using Recommender.SimilarityScore;

namespace Recommender.Tests.SimilarityScore
{
    [TestFixture]
    class PearsonCorrelationTests
    {
        private PearsonCorrelation pearsonCorrelationScore;

        [SetUp]
        public void SetUp()
        {
            pearsonCorrelationScore = new PearsonCorrelation(ReviewerBuilder.BuildReviewer1(), ReviewerBuilder.BuildReviewer2());
        }

        [Test]
        public void ReviewersThatHaveReviewedUniqueTitlesShouldNotBeSimilar()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            pearsonCorrelationScore = new PearsonCorrelation(r1, r2);
            Assert.AreEqual(0, pearsonCorrelationScore.Score());
        }

        [Test]
        public void ReviewersThatHaveTheSameTasteShouldHaveAPerfectScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            pearsonCorrelationScore = new PearsonCorrelation(r1, r1);
            Assert.AreEqual(1.0, pearsonCorrelationScore.Score());
        }

        [Test]
        public void TwoReviewersWithSomeSimilarReviewsShouldHaveAScoreBetweenZeroAndOne()
        {
            Assert.AreEqual(0.396, pearsonCorrelationScore.Score());
        }

        [Test]
        public void TestValuesOfReviewers()
        {
            var currentUser = ReviewerBuilder.BuildReviewer1();
            Assert.AreEqual(0.396, new PearsonCorrelation(currentUser, ReviewerBuilder.BuildReviewer2()).Score());
            Assert.AreEqual(-0.141, new PearsonCorrelation(currentUser, ReviewerBuilder.BuildReviewer3()).Score());
            Assert.AreEqual(0.567, new PearsonCorrelation(currentUser, ReviewerBuilder.BuildReviewer4()).Score());
            Assert.AreEqual(0.423, new PearsonCorrelation(currentUser, ReviewerBuilder.BuildReviewer5()).Score());
        }
    }
}
