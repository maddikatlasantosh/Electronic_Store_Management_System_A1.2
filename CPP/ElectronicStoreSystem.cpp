#include <iostream>
#include <string>
#include <vector>
using namespace std;

// =====================================================
// CUSTOMER CLASS
// =====================================================

class Customer {
private:
    int customerID;
    string name;
    string email;
    string phone;
    string address;

public:
    Customer(int customerID, string name, string email,
             string phone, string address) {
        this->customerID = customerID;
        this->name = name;
        this->email = email;
        this->phone = phone;
        this->address = address;
    }

    void displayCustomer() {
        cout << "Customer ID : " << customerID << endl;
        cout << "Name        : " << name << endl;
        cout << "Email       : " << email << endl;
        cout << "Phone       : " << phone << endl;
        cout << "Address     : " << address << endl;
    }

    void placeOrder() {
        cout << name << " placed an order." << endl;
    }

    friend ostream& operator<<(ostream& os, const Customer& customer) {
        os << customer.name;
        return os;
    }
};


// =====================================================
// CATEGORY CLASS
// =====================================================

class Category {
private:
    int categoryID;
    string categoryName;
    string description;

public:
    Category(int categoryID, string categoryName, string description) {
        this->categoryID = categoryID;
        this->categoryName = categoryName;
        this->description = description;
    }

    void displayCategory() {
        cout << "Category ID   : " << categoryID << endl;
        cout << "Category Name : " << categoryName << endl;
        cout << "Description   : " << description << endl;
    }
};


// =====================================================
// PRODUCT CLASS
// =====================================================

class Product {
private:
    int productID;
    string name;
    string brand;
    double price;
    int stock;
    string description;
    Category category;

public:
    Product(int productID, string name, string brand,
            double price, int stock, string description,
            Category category)
        : productID(productID), name(name), brand(brand),
          price(price), stock(stock), description(description),
          category(category) {
    }

    void displayProduct() {
        cout << "Product ID  : " << productID << endl;
        cout << "Name        : " << name << endl;
        cout << "Brand       : " << brand << endl;
        cout << "Price       : Rs." << price << endl;
        cout << "Stock       : " << stock << endl;
        cout << "Description : " << description << endl;
        cout << "Category    : " << categoryName() << endl;
    }

    string categoryName() {
        return "Electronic Product";
    }

    bool isAvailable(int quantity) {
        return stock >= quantity;
    }

    void updateStock(int quantity) {
        stock -= quantity;
    }

    double getPrice() const {
        return price;
    }

    string getName() const {
        return name;
    }
};


// =====================================================
// SUPPLIER CLASS
// =====================================================

class Supplier {
private:
    int supplierID;
    string name;
    string phone;
    string email;
    string address;

public:
    Supplier(int supplierID, string name, string phone,
             string email, string address) {
        this->supplierID = supplierID;
        this->name = name;
        this->phone = phone;
        this->email = email;
        this->address = address;
    }

    void displaySupplier() {
        cout << "Supplier ID : " << supplierID << endl;
        cout << "Name        : " << name << endl;
        cout << "Phone       : " << phone << endl;
        cout << "Email       : " << email << endl;
        cout << "Address     : " << address << endl;
    }

    void supplyProducts() {
        cout << name << " supplies electronic products." << endl;
    }
};


// =====================================================
// ORDER ITEM CLASS
// =====================================================

class OrderItem {
private:
    Product* product;
    int quantity;

public:
    OrderItem(Product& product, int quantity) {
        this->product = &product;
        this->quantity = quantity;
    }

    double getSubtotal() {
        return product->getPrice() * quantity;
    }

    void displayItem() {
        cout << product->getName() << " x " << quantity
             << " = Rs." << getSubtotal() << endl;
    }
};


// =====================================================
// PAYMENT CLASS
// =====================================================

class Payment {
private:
    int paymentID;
    string paymentMethod;
    double amount;
    string status;

public:
    Payment(int paymentID, string paymentMethod, double amount) {
        this->paymentID = paymentID;
        this->paymentMethod = paymentMethod;
        this->amount = amount;
        this->status = "Successful";
    }

    void processPayment() {
        cout << "Payment Method : " << paymentMethod << endl;
        cout << "Amount         : Rs." << amount << endl;
        cout << "Status         : " << status << endl;
    }
};


// =====================================================
// EMPLOYEE CLASS
// =====================================================

class Employee {
private:
    int employeeID;
    string name;
    string role;
    string phone;
    string email;

public:
    Employee(int employeeID, string name, string role,
             string phone, string email) {
        this->employeeID = employeeID;
        this->name = name;
        this->role = role;
        this->phone = phone;
        this->email = email;
    }

    void displayEmployee() {
        cout << "Employee ID : " << employeeID << endl;
        cout << "Name        : " << name << endl;
        cout << "Role        : " << role << endl;
        cout << "Phone       : " << phone << endl;
        cout << "Email       : " << email << endl;
    }

    void manageOrders() {
        cout << name << " is managing store orders." << endl;
    }
};


// =====================================================
// ORDER CLASS
// =====================================================

class Order {
private:
    int orderID;
    string orderDate;
    string status;
    vector<OrderItem> items;
    Customer customer;
    Employee employee;

public:
    Order(int orderID, string orderDate,
          Customer customer, Employee employee)
        : orderID(orderID), orderDate(orderDate),
          customer(customer), employee(employee) {
        this->status = "Pending";
    }

    void addProduct(Product& product, int quantity) {
        if (product.isAvailable(quantity)) {
            items.push_back(OrderItem(product, quantity));
            product.updateStock(quantity);
            cout << product.getName() << " added to order." << endl;
        } else {
            cout << "Sorry! Insufficient stock." << endl;
        }
    }

    double calculateTotal() {
        double total = 0;
        for (size_t i = 0; i < items.size(); i++) {
            total += items[i].getSubtotal();
        }
        return total;
    }

    void updateStatus(string status) {
        this->status = status;
    }

    void displayOrder() {
        cout << endl;
        cout << "========== ORDER DETAILS ==========" << endl;
        cout << "Order ID   : " << orderID << endl;
        cout << "Order Date : " << orderDate << endl;
        cout << "Customer   : " << customer << endl;
        cout << "Status     : " << status << endl;

        cout << "-----------------------------------" << endl;

        for (size_t i = 0; i < items.size(); i++) {
            items[i].displayItem();
        }

        cout << "-----------------------------------" << endl;
        cout << "Total Amount : Rs." << calculateTotal() << endl;
    }
};


// =====================================================
// MAIN CLASS
// =====================================================

int main() {
    cout << fixed;
    cout.precision(2);

    // Create Category
    Category mobileCategory(101, "Mobile Phones", "Smartphones and accessories");
    Category laptopCategory(102, "Laptops", "Laptops and notebooks");

    // Create Products
    Product phone(1001, "Galaxy A55", "Samsung", 34999, 10,
                  "5G Smartphone", mobileCategory);
    Product laptop(1002, "IdeaPad Slim 3", "Lenovo", 49999, 5,
                   "Student Laptop", laptopCategory);

    // Create Customer
    Customer customer(1, "Rahul Naik", "rahul@gmail.com",
                      "9876543210", "Goa");

    // Create Employee
    Employee employee(501, "Store Manager", "Sales Manager",
                      "9123456789", "manager@electronicstore.com");

    // Create Supplier
    Supplier supplier(301, "Tech Suppliers Pvt Ltd", "9000000000",
                      "supplier@gmail.com", "Panaji, Goa");

    // Create Order
    Order order(5001, "22-09-2026", customer, employee);

    int choice;

    do {
        cout << endl;
        cout << "======================================" << endl;
        cout << "     ELECTRONIC STORE MANAGEMENT" << endl;
        cout << "======================================" << endl;
        cout << "1. View Customer" << endl;
        cout << "2. View Products" << endl;
        cout << "3. View Supplier" << endl;
        cout << "4. Add Product to Order" << endl;
        cout << "5. View Order" << endl;
        cout << "6. Make Payment" << endl;
        cout << "7. View Employee" << endl;
        cout << "8. Exit" << endl;
        cout << "======================================" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        switch (choice) {
            case 1:
                cout << endl;
                cout << "===== CUSTOMER =====" << endl;
                customer.displayCustomer();
                break;

            case 2:
                cout << endl;
                cout << "===== PRODUCTS =====" << endl;
                phone.displayProduct();
                cout << endl;
                laptop.displayProduct();
                break;

            case 3:
                cout << endl;
                cout << "===== SUPPLIER =====" << endl;
                supplier.displaySupplier();
                supplier.supplyProducts();
                break;

            case 4:
                cout << endl;
                cout << "1. Samsung Galaxy A55" << endl;
                cout << "2. Lenovo IdeaPad Slim 3" << endl;
                cout << "Select product: ";

                int productChoice;
                cin >> productChoice;

                cout << "Enter quantity: ";
                int quantity;
                cin >> quantity;

                if (productChoice == 1) {
                    order.addProduct(phone, quantity);
                } else if (productChoice == 2) {
                    order.addProduct(laptop, quantity);
                } else {
                    cout << "Invalid product choice." << endl;
                }
                break;

            case 5:
                order.displayOrder();
                break;

            case 6: {
                double total = order.calculateTotal();

                if (total == 0) {
                    cout << "No products in the order." << endl;
                } else {
                    Payment payment(9001, "UPI", total);
                    payment.processPayment();
                    order.updateStatus("Paid");
                    cout << "Order payment completed successfully." << endl;
                }
                break;
            }

            case 7:
                cout << endl;
                cout << "===== EMPLOYEE =====" << endl;
                employee.displayEmployee();
                employee.manageOrders();
                break;

            case 8:
                cout << "Thank you for using Electronic Store Management System!" << endl;
                break;

            default:
                cout << "Invalid choice. Please try again." << endl;
        }

    } while (choice != 8);

    return 0;
}
