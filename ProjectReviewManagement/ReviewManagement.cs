using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjectReviewManagement
{
    public class ReviewManagement
    {
        // UC2
        public void TopThreeHighestRatedReviews(IList<ProductReview> productReviews)
        {
            var resultList = (from review in productReviews
                              orderby review.Rating descending
                              select review).Take(3);
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (ProductReview review in resultList)
            {
                Console.WriteLine($"{review.ProductID}\t\t{review.UserID}\t{review.Rating}\t{review.Review}\t{review.isLike}");
            }
        }

        // UC3
        public void RetrieveRequiredData(IList<ProductReview> productReviews)
        {
            var resultList = from review in productReviews
                             where  (review.Rating > 3) && (review.ProductID == 1 || review.ProductID == 4 || review.ProductID == 9)
                             select review;
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (ProductReview review in resultList)
            {
                Console.WriteLine($"{review.ProductID}\t\t{review.UserID}\t{review.Rating}\t{review.Review}\t{review.isLike}");
            }
        }

        // UC4

    }
}
