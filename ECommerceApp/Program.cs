using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp
{
    internal class Program
    {
        static AppDbContext context = new AppDbContext();
        static int loggedInUserId = 0;

        static void Main(string[] args)
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\n===== E-Commerce Console App =====");
                Console.WriteLine(" 1. Register New User");
                Console.WriteLine(" 2. Login");
                Console.WriteLine(" 3. Add New Category");
                Console.WriteLine(" 4. Add New Product");
                Console.WriteLine(" 5. View All Products");
                Console.WriteLine(" 6. Place an Order");
                Console.WriteLine(" 7. View My Orders");
                Console.WriteLine(" 8. View Order Details");
                Console.WriteLine(" 9. Add a Review for an Order");
                Console.WriteLine("10. View All Reviews for a Product");
                Console.WriteLine("11. Logout");
                Console.WriteLine(" 0. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: RegisterUser(); break;
                    case 2: Login(); break;
                    case 3: AddCategory(); break;
                    case 4: AddProduct(); break;
                    case 5: ViewAllProducts(); break;
                    case 6: PlaceOrder(); break;
                    case 7: ViewMyOrders(); break;
                    case 8: ViewOrderDetails(); break;
                    case 9: AddReview(); break;
                    case 10: ViewReviewsForProduct(); break;
                    case 11: Logout(); break;
                    case 0:
                        exitApp = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // ===================== FUNCTIONS =====================

        static void RegisterUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User newUser = new User { Name = name, Email = email, Password = password };
            context.Users.Add(newUser);
            context.SaveChanges();

            Console.WriteLine("User registered successfully.");
        }

        static void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("Invalid email or password.");
                return;
            }

            loggedInUserId = user.Id;
            Console.WriteLine($"Welcome, {user.Name}!");
        }

        static void AddCategory()
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();

            Category newCategory = new Category { Name = name };
            context.Categories.Add(newCategory);
            context.SaveChanges();

            Console.WriteLine("Category added.");
        }

        static void AddProduct()
        {
            var categories = context.Categories.ToList();
            if (!categories.Any())
            {
                Console.WriteLine("No categories exist yet. Add one first.");
                return;
            }

            Console.WriteLine("Available categories:");
            foreach (var c in categories)
                Console.WriteLine($"{c.Id}. {c.Name}");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter category Id: ");
            int categoryId = int.Parse(Console.ReadLine());

            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            Product newProduct = new Product { Name = name, Price = price, CategoryId = categoryId };
            context.Products.Add(newProduct);
            context.SaveChanges();

            Console.WriteLine("Product added.");
        }

        static void ViewAllProducts()
        {
            Console.Write("Filter by category Id (leave blank for all): ");
            string input = Console.ReadLine();

            var products = context.Products.Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(input))
            {
                int categoryId = int.Parse(input);
                products = products.Where(p => p.CategoryId == categoryId);
            }

            foreach (var p in products.ToList())
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Price:C} - Category: {p.Category.Name}");
        }

        static void PlaceOrder()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to place an order.");
                return;
            }

            Order newOrder = new Order { UserId = loggedInUserId, OrderDate = DateTime.Now };
            context.Orders.Add(newOrder);
            context.SaveChanges();

            bool addingProducts = true;
            while (addingProducts)
            {
                var products = context.Products.ToList();
                Console.WriteLine("Available products:");
                foreach (var p in products)
                    Console.WriteLine($"{p.Id}. {p.Name} - {p.Price:C}");

                Console.Write("Enter product Id to add: ");
                int productId = int.Parse(Console.ReadLine());

                var product = products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                }
                else
                {
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    OrderProduct orderProduct = new OrderProduct
                    {
                        OrderId = newOrder.Id,
                        ProductId = productId,
                        Quantity = quantity
                    };
                    context.OrderProducts.Add(orderProduct);
                    context.SaveChanges();
                }

                Console.Write("Add another product? (y/n): ");
                addingProducts = Console.ReadLine().Trim().ToLower() == "y";
            }

            Console.WriteLine("Order placed successfully.");
        }

        static void ViewMyOrders()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to view your orders.");
                return;
            }

            var orders = context.Orders.Where(o => o.UserId == loggedInUserId).ToList();

            if (!orders.Any())
            {
                Console.WriteLine("You have no orders yet.");
                return;
            }

            foreach (var o in orders)
                Console.WriteLine($"Order {o.Id} - {o.OrderDate}");
        }

        static void ViewOrderDetails()
        {
            Console.Write("Enter order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            var orderProducts = context.OrderProducts
                .Include(op => op.Product)
                .Where(op => op.OrderId == orderId)
                .ToList();

            double total = 0;
            Console.WriteLine($"Order {order.Id} placed on {order.OrderDate}:");
            foreach (var op in orderProducts)
            {
                double lineTotal = op.Product.Price * op.Quantity;
                total += lineTotal;
                Console.WriteLine($"- {op.Product.Name} x{op.Quantity} = {lineTotal:C}");
            }
            Console.WriteLine($"Order total: {total:C}");

            var review = context.Reviews.FirstOrDefault(r => r.OrderId == orderId);
            Console.WriteLine(review != null
                ? $"Review: {review.Rating}/5 - {review.Comment}"
                : "No review yet for this order.");
        }

        static void AddReview()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to add a review.");
                return;
            }

            Console.Write("Enter order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders.FirstOrDefault(o => o.Id == orderId && o.UserId == loggedInUserId);
            if (order == null)
            {
                Console.WriteLine("Order not found, or it doesn't belong to you.");
                return;
            }

            bool alreadyReviewed = context.Reviews.Any(r => r.OrderId == orderId);
            if (alreadyReviewed)
            {
                Console.WriteLine("This order already has a review.");
                return;
            }

            Console.Write("Enter rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("Enter comment: ");
            string comment = Console.ReadLine();

            Review newReview = new Review { OrderId = orderId, Rating = rating, Comment = comment };
            context.Reviews.Add(newReview);
            context.SaveChanges();

            Console.WriteLine("Review added.");
        }

        static void ViewReviewsForProduct()
        {
            Console.Write("Enter product Id: ");
            int productId = int.Parse(Console.ReadLine());

            var orderIds = context.OrderProducts
                .Where(op => op.ProductId == productId)
                .Select(op => op.OrderId)
                .ToList();

            if (!orderIds.Any())
            {
                Console.WriteLine("This product has not been ordered yet.");
                return;
            }

            var reviews = context.Reviews.Where(r => orderIds.Contains(r.OrderId)).ToList();

            if (!reviews.Any())
            {
                Console.WriteLine("No reviews yet for this product.");
                return;
            }

            foreach (var r in reviews)
                Console.WriteLine($"Order {r.OrderId}: {r.Rating}/5 - {r.Comment}");
        }

        static void Logout()
        {
            loggedInUserId = 0;
            Console.WriteLine("Logged out.");
        }
    }
}
