using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities;

namespace ThriveEcommerce.Data.Data
{
    public class ThriveEcommerceContextSeed
    {
        public static async Task SeedAsync(ThriveEcommerceContext thriveEcommerceContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                await SeedCategoriesAsync(thriveEcommerceContext);
                await SeedSpecificationsAsync(thriveEcommerceContext);
                await SeedReviewsAsync(thriveEcommerceContext);
                await SeedTagsAsync(thriveEcommerceContext);

                // products - related products - lists
                await SeedProductsAsync(thriveEcommerceContext);
                await SeedProductAndRelatedProductsAsync(thriveEcommerceContext);
                await SeedListAndProductsAsync(thriveEcommerceContext);

                // compares and wishlists
                await SeedCompareAndProductsAsync(thriveEcommerceContext);
                await SeedWishlistAndProductsAsync(thriveEcommerceContext);

                // cart and cart items - order and order items
                await SeedCartAndItemsAsync(thriveEcommerceContext);
                await SeedOrderAndItemsAsync(thriveEcommerceContext);

                // blog
                await SeedBlogsAsync(thriveEcommerceContext);
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ThriveEcommerceContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(thriveEcommerceContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static async Task SeedCategoriesAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Categories.Any())
                return;

            var categories = new List<Category>()
            {
                new Category() { Name = "Laptop"}, 
                new Category() { Name = "Drone"},
                new Category() { Name = "TV & Audio"}, 
                new Category() { Name = "Phone & Tablet"},
                new Category() { Name = "Camera & Printer"}, 
                new Category() { Name = "Games"}, 
                new Category() { Name = "Accessories"}, 
                new Category() { Name = "Watch"},
                new Category() { Name = "Home & Kitchen Appliances"} 
            };

            thriveEcommerceContext.Categories.AddRange(categories);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedSpecificationsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Specifications.Any())
                return;

            var specifications = new List<Specification>()
            {
                new Specification
                {
                    Name = "Full HD Camcorder",
                    Description = "Full HD Camcorder"
                },
                new Specification
                {
                    Name = "Dual Video Recording",
                    Description = "Dual Video Recording"
                },
                new Specification
                {
                    Name = "X type battery operation",
                    Description = "X type battery operation"
                },
                new Specification
                {
                    Name = "Full HD Camcorder",
                    Description = "Full HD Camcorder"
                },
                new Specification
                {
                    Name = "Dual Video Recording",
                    Description = "Dual Video Recording"
                },
                new Specification
                {
                    Name = "X type battery operation",
                    Description = "X type battery operation"
                }
            };

            thriveEcommerceContext.Specifications.AddRange(specifications);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedReviewsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Reviews.Any())
                return;

            var reviews = new List<Review>()
            {
                new Review
                {
                    Name = "Cristopher Lee",
                    EMail = "cristopher@lee.com",
                    Star = 4.3,
                    Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                },
                new Review
                {
                    Name = "Nirob Khan",
                    EMail = "nirob@lee.com",
                    Star = 4.3,
                    Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                },
                new Review
                {
                    Name = "MD.ZENAUL ISLAM",
                    EMail = "zenaul@lee.com",
                    Star = 4.3,
                    Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                }
            };

            thriveEcommerceContext.Reviews.AddRange(reviews);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedTagsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Tags.Any())
                return;

            var tags = new List<Tag>()
            {
                new Tag
                {
                    Name = "Electronic"
                },
                new Tag
                {
                    Name = "Smartphone"
                },
                new Tag
                {
                    Name = "Phone"
                },
                new Tag
                {
                    Name = "Charger"
                },
                new Tag
                {
                    Name = "Powerbank"
                }
            };

            thriveEcommerceContext.Tags.AddRange(tags);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedProductsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Products.Any())
                return;

            var products = new List<Product>
            {
                // Phone
                new Product()
                {
                    Name = "uPhone X",
                    Slug = "uphone-x",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    Category = thriveEcommerceContext.Categories.FirstOrDefault(c => c.Name == "Phone & Tablet"),
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Ornet Note 9",
                    Slug = "ornet-note",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-17.png",
                    UnitPrice = 285,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Sany Experia Z5",
                    Slug = "sany-experia",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-24.png",
                    UnitPrice = 360,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Flex P 3310",
                    Slug = "flex-p",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-19.png",
                    UnitPrice = 220,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Camera                
                new Product()
                {
                    Name = "Mony Handycam Z 105",
                    Slug = "mony-handycam-z",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    UnitPrice = 145,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Axor Digital Camera",
                    Slug = "axor-digital",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    UnitPrice = 199,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Silvex DSLR Camera T 32",
                    Slug = "silvex-camera",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-7.png",
                    UnitPrice = 580,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Necta Instant Camera",
                    Slug = "necta-instant",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-8.png",
                    UnitPrice = 320,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Printer
                new Product()
                {
                    Name = "Pranon Photo Printer Y 25",
                    Slug = "pranon-printer",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-11.png",
                    UnitPrice = 210,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Game                
                new Product()
                {
                    Name = "Game Station X 22",
                    Slug = "game-station-x",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 6,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Game Stations PW 25",
                    Slug = "game-station-pw",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-13.png",
                    UnitPrice = 285,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 6,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Laptop      
                new Product()
                {
                    Name = "Zeon Zen 4 Pro",
                    Slug = "zeon-zen",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 1,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Drone                
                new Product()
                {
                    Name = "Aquet Drone D 420",
                    Slug = "aquet-drone",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    UnitPrice = 275,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 2,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Accessories
                new Product()
                {
                    Name = "Roxxe Headphone Z 75",
                    Slug = "roxxe-headphone-z",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    UnitPrice = 110,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 7,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Watch
                new Product()
                {
                    Name = "Mascut Smart Watch",
                    Slug = "mascut-smart",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-9.png",
                    UnitPrice = 365,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 8,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Z Bluetooth Headphone",
                    Slug = "z-bluetooth",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-10.png",
                    UnitPrice = 189,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 8,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // TV & Audio
                new Product()
                {
                    Name = "Roses Speaker Box",
                    Slug = "roses-speaker",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-12.png",
                    UnitPrice = 210,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 3,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Nexo Andriod TV Box",
                    Slug = "nexo-andriod",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-16.png",
                    UnitPrice = 360,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 3,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Xonet Speaker P 9",
                    Slug = "xonet-speaker",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-18.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 3,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                // Home & Kitchen Appliances
                new Product()
                {
                    Name = "Zorex Coffe Maker",
                    Slug = "zorex-coffe",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-14.png",
                    UnitPrice = 210,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Jeilips Steam Iron K 2",
                    Slug = "jeilips-steam",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-15.png",
                    UnitPrice = 365,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Jackson Toster V 27",
                    Slug = "jackson-toster",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-20.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Mega Juice Maker",
                    Slug = "mega-juice",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-21.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Shine Microwave Oven",
                    Slug = "shine-microwave",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-22.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Auto Rice Cooker",
                    Slug = "auto-rice",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-23.png",
                    UnitPrice = 130,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = thriveEcommerceContext.Specifications.ToList(),
                    Reviews = thriveEcommerceContext.Reviews.ToList(),
                    Tags = thriveEcommerceContext.Tags.ToList()
                }
            };

            thriveEcommerceContext.Products.AddRange(products);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedProductAndRelatedProductsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.ProductRelatedProducts.Any())
                return;

            var newRelatedProductLists = new List<ProductRelatedProduct>
            {
                new ProductRelatedProduct
                {
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                    RelatedProduct = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault()
                },
                new ProductRelatedProduct
                {
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                    RelatedProduct = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).Skip(2).FirstOrDefault()
                }
            };

            thriveEcommerceContext.ProductRelatedProducts.AddRange(newRelatedProductLists);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedListAndProductsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Lists.Any())
                return;

            var lists = new List<List>()
            {
                new List
                {
                    Name = "FEATURED ITEMS",
                    Description = "",
                    ImageFile = "",
                },
                new List
                {
                    Name = "BEST SELLERS",
                    Description = "",
                    ImageFile = "",
                },
                new List
                {
                    Name = "BEST DEALS",
                    Description = "",
                    ImageFile = "",
                },
                new List
                {
                    Name = "NEW ARRIVAL",
                    Description = "",
                    ImageFile = "",
                },
            };

            var newProductLists = new List<ProductList>
            {
                new ProductList
                {
                    List = lists.FirstOrDefault(l => l.Name == "FEATURED ITEMS"),
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).FirstOrDefault()
                },
                new ProductList
                {
                    List = lists.FirstOrDefault(l => l.Name == "FEATURED ITEMS"),
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault()
                },
                new ProductList
                {
                    List = lists.FirstOrDefault(l => l.Name == "BEST SELLERS"),
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).Skip(2).FirstOrDefault()
                }
            };

            thriveEcommerceContext.Lists.AddRange(lists);
            thriveEcommerceContext.ProductLists.AddRange(newProductLists);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedWishlistAndProductsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Wishlists.Any())
                return;

            var wishlists = new List<Wishlist>()
            {
                new Wishlist
                {
                    UserName = "mehmetozkaya@gmail.com"
                }
            };

            var newProductWishlists = new List<ProductWishlist>()
            {
                new ProductWishlist
                {
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                    Wishlist = wishlists.FirstOrDefault()
                },
                new ProductWishlist
                {
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault(),
                    Wishlist = wishlists.FirstOrDefault()
                }
            };

            thriveEcommerceContext.Wishlists.AddRange(wishlists);
            thriveEcommerceContext.ProductWishlists.AddRange(newProductWishlists);

            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedCompareAndProductsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Compares.Any())
                return;

            var compares = new List<Compare>()
            {
                new Compare
                {
                    UserName = "mehmetozkaya@gmail.com"
                }
            };

            var newProductCompares = new List<ProductCompare>()
            {
                new ProductCompare
                {
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                    Compare = compares.FirstOrDefault()
                },
                new ProductCompare
                {
                    Product = thriveEcommerceContext.Products.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault(),
                    Compare = compares.FirstOrDefault()
                }
            };

            thriveEcommerceContext.Compares.AddRange(compares);
            thriveEcommerceContext.ProductCompares.AddRange(newProductCompares);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedCartAndItemsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Carts.Any())
                return;

            var carts = new List<Cart>()
            {
                new Cart
                {
                    UserName = "mehmetozkaya@gmail.com",
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Product = thriveEcommerceContext.Products.FirstOrDefault(p => p.Name == "uPhone X"),
                            Quantity = 2,
                            Color = "Black",
                            UnitPrice = 295,
                            TotalPrice = 590
                        },
                        new CartItem
                        {
                            Product = thriveEcommerceContext.Products.FirstOrDefault(p => p.Name == "Game Station X 22"),
                            Quantity = 1,
                            Color = "Red",
                            UnitPrice = 295,
                            TotalPrice = 295
                        },
                        new CartItem
                        {
                            Product = thriveEcommerceContext.Products.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                            Quantity = 1,
                            Color = "Black",
                            UnitPrice = 185,
                            TotalPrice = 185
                        }
                    }
                }
            };

            thriveEcommerceContext.Carts.AddRange(carts);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedOrderAndItemsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Orders.Any())
                return;

            var address = new Address
            {
                AddressLine = "Gungoren",
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "aspnetrun@outlook.com",
                FirstName = "Mehmet",
                LastName = "Ozkaya",
                CompanyName = "AspnetRun",
                PhoneNo = "05012222222",
                State = "027",
                ZipCode = "34056"
            };

            var addressShipping = new Address
            {
                AddressLine = "Gungoren",
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "aspnetrun@outlook.com",
                FirstName = "Mehmet",
                LastName = "Ozkaya",
                CompanyName = "AspnetRun",
                PhoneNo = "05012222222",
                State = "027",
                ZipCode = "34056"
            };

            var orders = new List<Order>()
            {
                new Order
                {
                    UserName = "mehmetozkaya@gmail.com",
                    PaymentMethod = PaymentMethod.Cash,
                    Status = OrderStatus.Progress,
                    GrandTotal = 347,
                    Items = new List<OrderItem>
                    {
                       new OrderItem
                       {
                           Product = thriveEcommerceContext.Products.FirstOrDefault(p => p.Name == "uPhone X"),
                            Quantity = 2,
                            Color = "Black",
                            UnitPrice = 295,
                            TotalPrice = 590
                       },
                        new OrderItem
                        {
                            Product = thriveEcommerceContext.Products.FirstOrDefault(p => p.Name == "Game Station X 22"),
                            Quantity = 1,
                            Color = "Red",
                            UnitPrice = 295,
                            TotalPrice = 295
                        },
                        new OrderItem
                        {
                            Product = thriveEcommerceContext.Products.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                            Quantity = 1,
                            Color = "Black",
                            UnitPrice = 185,
                            TotalPrice = 185
                        }
                    }
                }
            };

            thriveEcommerceContext.Orders.AddRange(orders);
            await thriveEcommerceContext.SaveChangesAsync();
        }

        private static async Task SeedBlogsAsync(ThriveEcommerceContext thriveEcommerceContext)
        {
            if (thriveEcommerceContext.Blogs.Any())
                return;

            var blogs = new List<Blog>()
            {
                new Blog
                {
                    Name = "Latest Drone for taking sky view image and 4K video",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    ImageFile = "blog-10.jpg"
                },
                new Blog
                {
                    Name = "Zeon Z 5 Pro Laptop makes your life easy and simple",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                },
                new Blog
                {
                    Name = "Latest Play Station for plying exclusive games",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    ImageFile = "blog-11.jpg"
                },
                new Blog
                {
                    Name = "The most attractive Smart watch comming in this February",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    ImageFile = "blog-12.jpg"
                }
            };

            thriveEcommerceContext.Blogs.AddRange(blogs);
            await thriveEcommerceContext.SaveChangesAsync();
        }

    }
}
