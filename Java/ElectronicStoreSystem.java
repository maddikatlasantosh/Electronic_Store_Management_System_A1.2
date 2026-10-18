import java.util.ArrayList;
import java.util.Scanner;

// =====================================================
// CUSTOMER CLASS
// =====================================================

class Customer {
    private int customerID;
    private String name;
    private String email;
    private String phone;
    private String address;

    Customer(int customerID, String name, String email,
             String phone, String address) {

        this.customerID = customerID;
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.address = address;
    }

    void displayCustomer() {
        System.out.println("Customer ID : " + customerID);
        System.out.println("Name        : " + name);
        System.out.println("Email       : " + email);
        System.out.println("Phone       : " + phone);
        System.out.println("Address     : " + address);
    }

    void placeOrder() {
        System.out.println(name + " placed an order.");
    }
}


// =====================================================
// CATEGORY CLASS
// =====================================================

class Category {
    private int categoryID;
    private String categoryName;
    private String description;

    Category(int categoryID, String categoryName, String description) {
        this.categoryID = categoryID;
        this.categoryName = categoryName;
        this.description = description;
    }

    void displayCategory() {
        System.out.println("Category ID   : " + categoryID);
        System.out.println("Category Name : " + categoryName);
        System.out.println("Description   : " + description);
    }
}


// =====================================================
// PRODUCT CLASS
// =====================================================

class Product {
    private int productID;
    private String name;
    private String brand;
    private double price;
    private int stock;
    private String description;
    private Category category;

    Product(int productID, String name, String brand,
            double price, int stock, String description,
            Category category) {

        this.productID = productID;
        this.name = name;
        this.brand = brand;
        this.price = price;
        this.stock = stock;
        this.description = description;
        this.category = category;
    }

    void displayProduct() {
        System.out.println("Product ID  : " + productID);
        System.out.println("Name        : " + name);
        System.out.println("Brand       : " + brand);
        System.out.println("Price       : Rs." + price);
        System.out.println("Stock       : " + stock);
        System.out.println("Description : " + description);
        System.out.println("Category    : " + categoryName());
    }

    String categoryName() {
        return "Electronic Product";
    }

    boolean isAvailable(int quantity) {
        return stock >= quantity;
    }

    void updateStock(int quantity) {
        stock -= quantity;
    }

    double getPrice() {
        return price;
    }

    String getName() {
        return name;
    }
}


// =====================================================
// SUPPLIER CLASS
// =====================================================

class Supplier {
    private int supplierID;
    private String name;
    private String phone;
    private String email;
    private String address;

    Supplier(int supplierID, String name, String phone,
             String email, String address) {

        this.supplierID = supplierID;
        this.name = name;
        this.phone = phone;
        this.email = email;
        this.address = address;
    }

    void displaySupplier() {
        System.out.println("Supplier ID : " + supplierID);
        System.out.println("Name        : " + name);
        System.out.println("Phone       : " + phone);
        System.out.println("Email       : " + email);
        System.out.println("Address     : " + address);
    }

    void supplyProducts() {
        System.out.println(name + " supplies electronic products.");
    }
}


// =====================================================
// ORDER ITEM CLASS
// =====================================================

class OrderItem {
    private Product product;
    private int quantity;

    OrderItem(Product product, int quantity) {
        this.product = product;
        this.quantity = quantity;
    }

    double getSubtotal() {
        return product.getPrice() * quantity;
    }

    void displayItem() {
        System.out.println(
            product.getName() +
            " x " + quantity +
            " = Rs." + getSubtotal()
        );
    }
}


// =====================================================
// PAYMENT CLASS
// =====================================================

class Payment {
    private int paymentID;
    private String paymentMethod;
    private double amount;
    private String status;

    Payment(int paymentID, String paymentMethod, double amount) {
        this.paymentID = paymentID;
        this.paymentMethod = paymentMethod;
        this.amount = amount;
        this.status = "Successful";
    }

    void processPayment() {
        System.out.println("Payment Method : " + paymentMethod);
        System.out.println("Amount         : Rs." + amount);
        System.out.println("Status         : " + status);
    }
}


// =====================================================
// EMPLOYEE CLASS
// =====================================================

class Employee {
    private int employeeID;
    private String name;
    private String role;
    private String phone;
    private String email;

    Employee(int employeeID, String name, String role,
             String phone, String email) {

        this.employeeID = employeeID;
        this.name = name;
        this.role = role;
        this.phone = phone;
        this.email = email;
    }

    void displayEmployee() {
        System.out.println("Employee ID : " + employeeID);
        System.out.println("Name        : " + name);
        System.out.println("Role        : " + role);
        System.out.println("Phone       : " + phone);
        System.out.println("Email       : " + email);
    }

    void manageOrders() {
        System.out.println(name + " is managing store orders.");
    }
}


// =====================================================
// ORDER CLASS
// =====================================================

class Order {
    private int orderID;
    private String orderDate;
    private String status;
    private ArrayList<OrderItem> items;
    private Customer customer;
    private Employee employee;

    Order(int orderID, String orderDate,
          Customer customer, Employee employee) {

        this.orderID = orderID;
        this.orderDate = orderDate;
        this.customer = customer;
        this.employee = employee;
        this.status = "Pending";
        this.items = new ArrayList<>();
    }

    void addProduct(Product product, int quantity) {

        if (product.isAvailable(quantity)) {

            OrderItem item = new OrderItem(product, quantity);

            items.add(item);

            product.updateStock(quantity);

            System.out.println(
                product.getName() + " added to order."
            );

        } else {

            System.out.println(
                "Sorry! Insufficient stock."
            );
        }
    }

    double calculateTotal() {

        double total = 0;

        for (OrderItem item : items) {
            total += item.getSubtotal();
        }

        return total;
    }

    void updateStatus(String status) {
        this.status = status;
    }

    void displayOrder() {

        System.out.println();
        System.out.println("========== ORDER DETAILS ==========");
        System.out.println("Order ID   : " + orderID);
        System.out.println("Order Date : " + orderDate);
        System.out.println("Customer   : " + customer);
        System.out.println("Status     : " + status);

        System.out.println("-----------------------------------");

        for (OrderItem item : items) {
            item.displayItem();
        }

        System.out.println("-----------------------------------");
        System.out.println(
            "Total Amount : Rs." + calculateTotal()
        );
    }
}


// =====================================================
// MAIN CLASS
// =====================================================

public class ElectronicStoreSystem {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        // Create Category
        Category mobileCategory = new Category(
            101,
            "Mobile Phones",
            "Smartphones and accessories"
        );

        Category laptopCategory = new Category(
            102,
            "Laptops",
            "Laptops and notebooks"
        );

        // Create Products
        Product phone = new Product(
            1001,
            "Galaxy A55",
            "Samsung",
            34999,
            10,
            "5G Smartphone",
            mobileCategory
        );

        Product laptop = new Product(
            1002,
            "IdeaPad Slim 3",
            "Lenovo",
            49999,
            5,
            "Student Laptop",
            laptopCategory
        );

        // Create Customer
        Customer customer = new Customer(
            1,
            "Rahul Naik",
            "rahul@gmail.com",
            "9876543210",
            "Goa"
        );

        // Create Employee
        Employee employee = new Employee(
            501,
            "Store Manager",
            "Sales Manager",
            "9123456789",
            "manager@electronicstore.com"
        );

        // Create Supplier
        Supplier supplier = new Supplier(
            301,
            "Tech Suppliers Pvt Ltd",
            "9000000000",
            "supplier@gmail.com",
            "Panaji, Goa"
        );

        // Create Order
        Order order = new Order(
            5001,
            "22-09-2026",
            customer,
            employee
        );

        int choice;

        do {

            System.out.println();
            System.out.println("======================================");
            System.out.println("     ELECTRONIC STORE MANAGEMENT");
            System.out.println("======================================");
            System.out.println("1. View Customer");
            System.out.println("2. View Products");
            System.out.println("3. View Supplier");
            System.out.println("4. Add Product to Order");
            System.out.println("5. View Order");
            System.out.println("6. Make Payment");
            System.out.println("7. View Employee");
            System.out.println("8. Exit");
            System.out.println("======================================");
            System.out.print("Enter your choice: ");

            choice = sc.nextInt();

            switch (choice) {

                case 1:
                    System.out.println();
                    System.out.println("===== CUSTOMER =====");
                    customer.displayCustomer();
                    break;

                case 2:
                    System.out.println();
                    System.out.println("===== PRODUCTS =====");

                    phone.displayProduct();

                    System.out.println();

                    laptop.displayProduct();
                    break;

                case 3:
                    System.out.println();
                    System.out.println("===== SUPPLIER =====");
                    supplier.displaySupplier();
                    supplier.supplyProducts();
                    break;

                case 4:

                    System.out.println();
                    System.out.println("1. Samsung Galaxy A55");
                    System.out.println("2. Lenovo IdeaPad Slim 3");
                    System.out.print("Select product: ");

                    int productChoice = sc.nextInt();

                    System.out.print("Enter quantity: ");
                    int quantity = sc.nextInt();

                    if (productChoice == 1) {
                        order.addProduct(phone, quantity);
                    } else if (productChoice == 2) {
                        order.addProduct(laptop, quantity);
                    } else {
                        System.out.println("Invalid product choice.");
                    }

                    break;

                case 5:
                    order.displayOrder();
                    break;

                case 6:

                    double total = order.calculateTotal();

                    if (total == 0) {
                        System.out.println(
                            "No products in the order."
                        );
                    } else {

                        Payment payment = new Payment(
                            9001,
                            "UPI",
                            total
                        );

                        payment.processPayment();

                        order.updateStatus("Paid");

                        System.out.println(
                            "Order payment completed successfully."
                        );
                    }

                    break;

                case 7:
                    System.out.println();
                    System.out.println("===== EMPLOYEE =====");
                    employee.displayEmployee();
                    employee.manageOrders();
                    break;

                case 8:
                    System.out.println(
                        "Thank you for using Electronic Store Management System!"
                    );
                    break;

                default:
                    System.out.println(
                        "Invalid choice. Please try again."
                    );
            }

        } while (choice != 8);

        sc.close();
    }
}