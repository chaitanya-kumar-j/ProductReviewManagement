using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

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
        public void CountOfReviesGroupedByProductId(IList<ProductReview> productReviews)
        {
            var resultCount = productReviews.GroupBy(x => x.ProductID).OrderBy(x => x.Key)
                .Select(x => new { ProductID = x.Key, Count = x.Count() });
            Console.WriteLine("nProductID\tNumberOfReviews");
            foreach (var count in resultCount)
            {
                Console.WriteLine($"{count.ProductID}\t\t{count.Count}");
            }
        }

        // UC5
        public void GetRequiredFields(IList<ProductReview> productReviews)
        {
            var resultList = from review in productReviews select (review.ProductID, review.Review);
            Console.WriteLine("nProductID\tReview");
            foreach (var review in resultList)
            {
                Console.WriteLine($"{review.ProductID}\t\t{review.Review}");
            }
        }

        // UC6
        public void SkipTopFiveReviews(IList<ProductReview> productReviews)
        {
            var resultList = (from review in productReviews select review).Skip(5);
            // Console.WriteLine($"Number of reviews : {resultList.Count()}");
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (ProductReview review in resultList)
            {
                Console.WriteLine($"{review.ProductID}\t\t{review.UserID}\t{review.Rating}\t{review.Review}\t{review.isLike}");
            }
        }

        // UC7 
        //same as UC5

        // UC8
        DataTable table = new DataTable();
        public void AddDataToTable(IList<ProductReview> productReviews)     
        {
            table.Columns.Add("ProductID").DataType = typeof(Int32);
            table.Columns.Add("UserID").DataType = typeof(Int32);
            table.Columns.Add("Rating").DataType = typeof(double);
            table.Columns.Add("Review").DataType = typeof(string);
            table.Columns.Add("isLike").DataType = typeof(bool);

            foreach(var review in productReviews)
            {
                table.Rows.Add(review.ProductID, review.UserID, review.Rating, review.Review, review.isLike);
            }

            var reviewsTable = from review in table.AsEnumerable() select review;
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (DataRow review in reviewsTable)
            {
                Console.WriteLine($"{review.Field<int>("productId")}\t\t{review.Field<int>("UserId")}\t" +
                    $"{review.Field<double>("Rating")}\t{review.Field<string>("Review")}\t{review.Field<bool>("isLike")}");
            }
        }

        // UC9
        public void GetReviewsWithIsLikeAsTrue()
        {
            var reviewsTable = from review in table.AsEnumerable() where review.Field<bool>("isLike").Equals(true) select review;
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (DataRow review in reviewsTable)
            {
                Console.WriteLine($"{review.Field<int>("productId")}\t\t{review.Field<int>("UserId")}\t" +
                    $"{review.Field<double>("Rating")}\t{review.Field<string>("Review")}\t{review.Field<bool>("isLike")}");
            }
        }

        // UC10
        public void GetAverageRatingOfEachProductId()
        {
            var avgTable = table.AsEnumerable().GroupBy(x => x.Field<int>("ProductID")).Select(x => new { ProductID = x.Key, AverageRating = x.Average(r => r.Field<double>("Rating"))}).OrderBy(x => x.ProductID);
            Console.WriteLine("\nProductID\tAverageRating");
            foreach (var count in avgTable)
            {
                Console.WriteLine($"{count.ProductID}\t\t{count.AverageRating}");
            }
        }

        // UC11
        public void GetReviewsWithReviewAsNice()
        {
            var reviewsTable = from review in table.AsEnumerable() where review.Field<string>("Review").Equals("Nice") select review;
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (DataRow review in reviewsTable)
            {
                Console.WriteLine($"{review.Field<int>("productId")}\t\t{review.Field<int>("UserId")}\t" +
                    $"{review.Field<double>("Rating")}\t{review.Field<string>("Review")}\t{review.Field<bool>("isLike")}");
            }
        }

        // UC12
        public void AddAndGetUserIdTenOnly()
        {
            IList<ProductReview> productReviews = new List<ProductReview>();
            List<string> reviewList = new List<string>() { "Good", "Bad", "Nice" };
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                ProductReview review = new ProductReview();
                review.ProductID = random.Next(1, 10);
                review.UserID = 10;
                review.Rating = random.Next(1, 6);
                review.Review = reviewList[random.Next(reviewList.Count)];
                review.isLike = Convert.ToBoolean(random.Next(2));
                productReviews.Add(review);
            }
            foreach (var review in productReviews)
            {
                table.Rows.Add(review.ProductID, review.UserID, review.Rating, review.Review, review.isLike);
            }
            var reviewsTable = (from review in table.AsEnumerable() where review.Field<int>("UserID").Equals(10) select review).OrderBy(x => x.Field<double>("Rating"));
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (DataRow review in reviewsTable)
            {
                Console.WriteLine($"{review.Field<int>("productId")}\t\t{review.Field<int>("UserId")}\t" +
                    $"{review.Field<double>("Rating")}\t{review.Field<string>("Review")}\t{review.Field<bool>("isLike")}");
            }
        }
    }
}
