using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

class Program
{
    // Define the Review class
    public class Review
    {
        [BsonElement("review_id")]
        public int ReviewId { get; set; }

        [BsonElement("review_date")]
        public string ReviewDate { get; set; }

        [BsonElement("review_text")]
        public string ReviewText { get; set; }
    }

    // Define the Address class
    public class Address
    {
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("postal_code")]
        public string PostalCode { get; set; }
    }

    // Define the Property class
    public class Property
    {
        [BsonElement("property_id")]
        public int PropertyId { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("size")]
        public int Size { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("num_of_rooms")]
        public int NumOfRooms { get; set; }

        [BsonElement("reviews")]
        public List<Review> Reviews { get; set; }
    }

    static void Main(string[] args)
    {
        // MongoDB connection string
        string connectionString = "mongodb://localhost:27017"; // Replace with your connection string
        var client = new MongoClient(connectionString);

        // Database and collection
        var database = client.GetDatabase("real_estate");
        var collection = database.GetCollection<Property>("properties");

        // Data to insert
        var properties = new List<Property>
        {
            new Property
            {
                PropertyId = 1,
                Address = new Address
                {
                    Street = "123 Elm St",
                    City = "Newcastle",
                    PostalCode = "NE1 4AX"
                },
                Size = 1500,
                Price = 245000,
                Type = "Detached",
                NumOfRooms = 3,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        ReviewId = 101,
                        ReviewDate = "2024-05-01",
                        ReviewText = "Great property, well-maintained."
                    }
                }
            },
            new Property
            {
                PropertyId = 2,
                Address = new Address
                {
                    Street = "456 High St",
                    City = "Gateshead",
                    PostalCode = "NE2 5PT"
                },
                Size = 2000,
                Price = 350000,
                Type = "Semi-Detached",
                NumOfRooms = 4,
                Reviews = null // No reviews for this property
            }
        };

        // Insert the data
        collection.InsertMany(properties);

        Console.WriteLine("Data inserted successfully.");
    }
}
