using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recommender.Reviews;

namespace Recommender
{
    class PearsonCorrelation : SimilarityScore
    {
        private readonly Reviewer R1;
        private readonly Reviewer R2;
        private List<string> SimilarReviews;

        public PearsonCorrelation(Reviewer r1, Reviewer r2)
        {
            R1 = r1;
            R2 = r2;
        }

        public double Score()
        {
            return 0.0;
        }
    }
}
