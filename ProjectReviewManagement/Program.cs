using System;
using System.Collections.Generic;

namespace ProjectReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ProductReview> productReviews = new List<ProductReview>() { };
            List<string> reviewList = new List<string>() { "Good", "Bad", "Ok" };
            Random random = new Random();
            for (int i = 1; i <= 25; i++)
            {
                ProductReview review = new ProductReview();
                review.ProductID = i;
                review.UserID = random.Next(1, 11);
                review.Rating = random.Next(1, 6);
                review.Review = reviewList[random.Next(reviewList.Count)];
                review.isLike = Convert.ToBoolean(random.Next(2));
                productReviews.Add(review);
            }
            foreach(ProductReview review in productReviews)
            {
                Console.WriteLine($"{review.ProductID}-{review.UserID}-{review.Rating}-{review.Review}-{review.isLike}");
            }
        }
    }
}
