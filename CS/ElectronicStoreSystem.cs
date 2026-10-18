using System;
using System.Collections.Generic;

// =====================================================
// CUSTOMER CLASS
// =====================================================

class Customer
{
    private int customerID;
    private string name;
    private string email;
    private string phone;
    private string address;

    public Customer(int customerID, string name, string email,
                   string phone, string address)
    {
        this.customerID = customerID;
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.address = address;
    }

    public void DisplayCustomer()
    {
        Console.WriteLine("Customer ID : " + customerID);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Email       : " + email);
        Console.WriteLine("Phone       : " + phone);
        Console.WriteLine("Address     : " + address);
    }

    public void PlaceOrder()
    {
        Console.WriteLine(name + " placed an order.");
    }

    public override string ToString()
    {
        return name;
    }
}


// =====================================================
// CATEGORY CLASS
// =====================================================

class Category
{
    private int categoryID;
    private string categoryName;
    private string description;

    public Category(int categoryID, string categoryName, string description)
    {
        this.categoryID = categoryID;
        this.categoryName = categoryName;
        this.description = description;
    }

    public void DisplayCategory()
    {
        Console.WriteLine("Category ID   : " + categoryID);
        Console.WriteLine("Category Name : " + categoryName);
        Console.WriteLine("Description   : " + description);
    }
}


// =====================================================
// PRODUCT CLASS
// =====================================================

class Product
{
    private int productID;
    private string name;
    private string brand;
    private double price;
    private int stock;
    private string description;
    private Category category;

    public Product(int productID, string name, string brand,
                   double price, int stock, string description,
                   Category category)
    {
        this.productID = productID;
        this.name = name;
        this.brand = brand;
        this.price = price;
        this.stock = stock;
        this.description = description;
        this.category = category;
    }

    public void DisplayProduct()
    {
        Console.WriteLine("Product ID  : " + productID);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Brand       : " + brand);
        Console.WriteLine("Price       : Rs." + price);
        Console.WriteLine("Stock       : " + stock);
        Console.WriteLine("Description : " + description);
        Console.WriteLine("Category    : " + CategoryName());
    }

    public string CategoryName()
    {
        return "Electronic Product";
    }

    public bool IsAvailable(int quantity)
    {
        return stock >= quantity;
    }

    public void UpdateStock(int quantity)
    {
        stock -= quantity;
    }

    public double GetPrice()
    {
        return price;
    }

    public string GetName()
    {
        return name;
    }
}


// =====================================================
// SUPPLIER CLASS
// =====================================================

class Supplier
{
    private int supplierID;
    private string name;
    private string phone;
    private string email;
    private string address;

    public Supplier(int supplierID, string name, string phone,
                    string email, string address)
    {
        this.supplierID = supplierID;
        this.name = name;
        this.phone = phone;
        this.email = email;
        this.address = address;
    }

    public void DisplaySupplier()
    {
        Console.WriteLine("Supplier ID : " + supplierID);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Phone       : " + phone);
        Console.WriteLine("Email       : " + email);
        Console.WriteLine("Address     : " + address);
    }

    public void SupplyProducts()
    {
        Console.WriteLine(name + " supplies electronic products.");
    }
}


// =====================================================
// ORDER ITEM CLASS
// =====================================================

class OrderItem
{
    private Product product;
    private int quantity;

    public OrderItem(Product product, int quantity)
    {
        this.product = product;
        this.quantity = quantity;
    }

    public double GetSubtotal()
    {
        return product.GetPrice() * quantity;
    }

    public void DisplayItem()
    {
        Console.WriteLine(product.GetName() + " x " + quantity + " = Rs." + GetSubtotal());
    }
}


// =====================================================
// PAYMENT CLASS
// =====================================================

class Payment
{
    private int paymentID;
    private string paymentMethod;
    private double amount;
    private string status;

    public Payment(int paymentID, string paymentMethod, double amount)
    {
        this.paymentID = paymentID;
        this.paymentMethod = paymentMethod;
        this.amount = amount;
        this.status = "Successful";
    }

    public void ProcessPayment()
    {
        Console.WriteLine("Payment Method : " + paymentMethod);
        Console.WriteLine("Amount         : Rs." + amount);
        Console.WriteLine("Status         : " + status);
    }
}


// =====================================================
// EMPLOYEE CLASS
// =====================================================

class Employee
{
    private int employeeID;
    private string name;
    private string role;
    private string phone;
    private string email;

    public Employee(int employeeID, string name, string role,
                   string phone, string email)
    {
        this.employeeID = employeeID;
        this.name = name;
        this.role = role;
        this.phone = phone;
        this.email = email;
    }

    public void DisplayEmployee()
    {
        Console.WriteLine("Employee ID : " + employeeID);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Role        : " + role);
        Console.WriteLine("Phone       : " + phone);
        Console.WriteLine("Email       : " + email);
    }

    public void ManageOrders()
    {
        Console.WriteLine(name + " is managing store orders.");
    }
}


// =====================================================
// ORDER CLASS
// =====================================================

class Order
{
    private int orderID;
    private string orderDate;
    private string status;
    private List<OrderItem> items;
    private Customer customer;
    private Employee employee;

    public Order(int orderID, string orderDate, Customer customer, Employee employee)
    {
        this.orderID = orderID;
        this.orderDate = orderDate;
        this.customer = customer;
        this.employee = employee;
        this.status = "Pending";
        this.items = new List<OrderItem>();
    }

    public void AddProduct(Product product, int quantity)
    {
        if (product.IsAvailable(quantity))
        {
            OrderItem item = new OrderItem(product, quantity);
            items.Add(item);
            product.UpdateStock(quantity);
            Console.WriteLine(product.GetName() + " added to order.");
        }
        else
        {
            Console.WriteLine("Sorry! Insufficient stock.");
        }
    }

    public double CalculateTotal()
    {
        double total = 0;

        foreach (OrderItem item in items)
        {
            total += item.GetSubtotal();
        }

        return total;
    }

    public void UpdateStatus(string status)
    {
        this.status = status;
    }

    public void DisplayOrder()
    {
        Console.WriteLine();
        Console.WriteLine("========== ORDER DETAILS ==========");
        Console.WriteLine("Order ID   : " + orderID);
        Console.WriteLine("Order Date : " + orderDate);
        Console.WriteLine("Customer   : " + customer);
        Console.WriteLine("Status     : " + status);

        Console.WriteLine("-----------------------------------");

        foreach (OrderItem item in items)
        {
            item.DisplayItem();
        }

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Total Amount : Rs." + CalculateTotal());
    }
}


// =====================================================
// MAIN CLASS
// =====================================================

class ElectronicStoreSystem
{
    static void Main(string[] args)
    {
        // Create Category
        Category mobileCategory = new Category(101, "Mobile Phones", "Smartphones and accessories");
        Category laptopCategory = new Category(102, "Laptops", "Laptops and notebooks");

        // Create Products
        Product phone = new Product(1001, "Galaxy A55", "Samsung", 34999, 10,
                                   "5G Smartphone", mobileCategory);
        Product laptop = new Product(1002, "IdeaPad Slim 3", "Lenovo", 49999, 5,
                                    "Student Laptop", laptopCategory);

        // Create Customer
        Customer customer = new Customer(1, "Rahul Naik", "rahul@gmail.com",
                                        "9876543210", "Goa");

        // Create Employee
        Employee employee = new Employee(501, "Store Manager", "Sales Manager",
                                        "9123456789", "manager@electronicstore.com");

        // Create Supplier
        Supplier supplier = new Supplier(301, "Tech Suppliers Pvt Ltd", "9000000000",
                                         "supplier@gmail.com", "Panaji, Goa");

        // Create Order
        Order order = new Order(5001, "22-09-2026", customer, employee);

        int choice;

        do
        {
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("     ELECTRONIC STORE MANAGEMENT");
            Console.WriteLine("======================================");
            Console.WriteLine("1. View Customer");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. View Supplier");
            Console.WriteLine("4. Add Product to Order");
            Console.WriteLine("5. View Order");
            Console.WriteLine("6. Make Payment");
            Console.WriteLine("7. View Employee");
            Console.WriteLine("8. Exit");
            Console.WriteLine("======================================");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("===== CUSTOMER =====");
                    customer.DisplayCustomer();
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("===== PRODUCTS =====");
                    phone.DisplayProduct();
                    Console.WriteLine();
                    laptop.DisplayProduct();
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine("===== SUPPLIER =====");
                    supplier.DisplaySupplier();
                    supplier.SupplyProducts();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("1. Samsung Galaxy A55");
                    Console.WriteLine("2. Lenovo IdeaPad Slim 3");
                    Console.Write("Select product: ");

                    int productChoice = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    if (productChoice == 1)
                    {
                        order.AddProduct(phone, quantity);
                    }
                    else if (productChoice == 2)
                    {
                        order.AddProduct(laptop, quantity);
                    }
                    else
                    {
                        Console.WriteLine("Invalid product choice.");
                    }
                    break;

                case 5:
                    order.DisplayOrder();
                    break;

                case 6:
                    double total = order.CalculateTotal();

                    if (total == 0)
                    {
                        Console.WriteLine("No products in the order.");
                    }
                    else
                    {
                        Payment payment = new Payment(9001, "UPI", total);
                        payment.ProcessPayment();
                        order.UpdateStatus("Paid");
                        Console.WriteLine("Order payment completed successfully.");
                    }
                    break;

                case 7:
                    Console.WriteLine();
                    Console.WriteLine("===== EMPLOYEE =====");
                    employee.DisplayEmployee();
                    employee.ManageOrders();
                    break;

                case 8:
                    Console.WriteLine("Thank you for using Electronic Store Management System!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 8);
    }
}
