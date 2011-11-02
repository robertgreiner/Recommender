using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recommender.Reviews
{
    public class Reviewer
    {
        public Dictionary<string, double> Reviews;
        public string Name { get; set; }

        public Reviewer()
        {
            Reviews = new Dictionary<string, double>();
        }

        public void AddReview(string title, double score)
        {
            Reviews.Add(title, score);
        }

        public List<string> SimilarReviews(Dictionary<string, double> compareTo)
        {
            return (from r in Reviews where compareTo.ContainsKey(r.Key) select r.Key).ToList();
        }
    }
}
