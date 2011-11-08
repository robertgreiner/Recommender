using System.Collections.Generic;
using System.Linq;

namespace Recommender.Instructions
{
    public class SumProducts : SimilarityScoreCommand
    {
        private readonly List<string> SimilarReviews;
        private readonly Dictionary<string, double> FirstUserReviews;
        private readonly Dictionary<string, double> SecondUserReviews;


        public SumProducts(List<string> similarReviews, Dictionary<string, double> firstUserReviews, Dictionary<string, double> secondUserReviews)
        {
            SimilarReviews = similarReviews;
            FirstUserReviews = firstUserReviews;
            SecondUserReviews = secondUserReviews;
        }

        public double Calculate()
        {
            return SimilarReviews.Sum(title => FirstUserReviews[title] * SecondUserReviews[title]);
        }
    }
}
