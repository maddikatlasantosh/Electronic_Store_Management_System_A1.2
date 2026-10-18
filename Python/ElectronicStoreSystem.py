class Customer:
    def __init__(self, customer_id, name, email, phone, address):
        self.customer_id = customer_id
        self.name = name
        self.email = email
        self.phone = phone
        self.address = address

    def display_customer(self):
        print("Customer ID : " + str(self.customer_id))
        print("Name        : " + self.name)
        print("Email       : " + self.email)
        print("Phone       : " + self.phone)
        print("Address     : " + self.address)

    def place_order(self):
        print(self.name + " placed an order.")

    def __str__(self):
        return self.name


class Category:
    def __init__(self, category_id, category_name, description):
        self.category_id = category_id
        self.category_name = category_name
        self.description = description

    def display_category(self):
        print("Category ID   : " + str(self.category_id))
        print("Category Name : " + self.category_name)
        print("Description   : " + self.description)


class Product:
    def __init__(self, product_id, name, brand, price, stock, description, category):
        self.product_id = product_id
        self.name = name
        self.brand = brand
        self.price = price
        self.stock = stock
        self.description = description
        self.category = category

    def display_product(self):
        print("Product ID  : " + str(self.product_id))
        print("Name        : " + self.name)
        print("Brand       : " + self.brand)
        print("Price       : Rs." + str(self.price))
        print("Stock       : " + str(self.stock))
        print("Description : " + self.description)
        print("Category    : " + self.category_name())

    def category_name(self):
        return "Electronic Product"

    def is_available(self, quantity):
        return self.stock >= quantity

    def update_stock(self, quantity):
        self.stock -= quantity

    def get_price(self):
        return self.price

    def get_name(self):
        return self.name


class Supplier:
    def __init__(self, supplier_id, name, phone, email, address):
        self.supplier_id = supplier_id
        self.name = name
        self.phone = phone
        self.email = email
        self.address = address

    def display_supplier(self):
        print("Supplier ID : " + str(self.supplier_id))
        print("Name        : " + self.name)
        print("Phone       : " + self.phone)
        print("Email       : " + self.email)
        print("Address     : " + self.address)

    def supply_products(self):
        print(self.name + " supplies electronic products.")


class OrderItem:
    def __init__(self, product, quantity):
        self.product = product
        self.quantity = quantity

    def get_subtotal(self):
        return self.product.get_price() * self.quantity

    def display_item(self):
        print(self.product.get_name() + " x " + str(self.quantity) + " = Rs." + str(self.get_subtotal()))


class Payment:
    def __init__(self, payment_id, payment_method, amount):
        self.payment_id = payment_id
        self.payment_method = payment_method
        self.amount = amount
        self.status = "Successful"

    def process_payment(self):
        print("Payment Method : " + self.payment_method)
        print("Amount         : Rs." + str(self.amount))
        print("Status         : " + self.status)


class Employee:
    def __init__(self, employee_id, name, role, phone, email):
        self.employee_id = employee_id
        self.name = name
        self.role = role
        self.phone = phone
        self.email = email

    def display_employee(self):
        print("Employee ID : " + str(self.employee_id))
        print("Name        : " + self.name)
        print("Role        : " + self.role)
        print("Phone       : " + self.phone)
        print("Email       : " + self.email)

    def manage_orders(self):
        print(self.name + " is managing store orders.")


class Order:
    def __init__(self, order_id, order_date, customer, employee):
        self.order_id = order_id
        self.order_date = order_date
        self.customer = customer
        self.employee = employee
        self.status = "Pending"
        self.items = []

    def add_product(self, product, quantity):
        if product.is_available(quantity):
            item = OrderItem(product, quantity)
            self.items.append(item)
            product.update_stock(quantity)
            print(product.get_name() + " added to order.")
        else:
            print("Sorry! Insufficient stock.")

    def calculate_total(self):
        total = 0
        for item in self.items:
            total += item.get_subtotal()
        return total

    def update_status(self, status):
        self.status = status

    def display_order(self):
        print()
        print("========== ORDER DETAILS ==========")
        print("Order ID   : " + str(self.order_id))
        print("Order Date : " + self.order_date)
        print("Customer   : " + str(self.customer))
        print("Status     : " + self.status)

        print("-----------------------------------")

        for item in self.items:
            item.display_item()

        print("-----------------------------------")
        print("Total Amount : Rs." + str(self.calculate_total()))


class ElectronicStoreSystem:
    @staticmethod
    def main():
        mobile_category = Category(101, "Mobile Phones", "Smartphones and accessories")
        laptop_category = Category(102, "Laptops", "Laptops and notebooks")

        phone = Product(1001, "Galaxy A55", "Samsung", 34999, 10, "5G Smartphone", mobile_category)
        laptop = Product(1002, "IdeaPad Slim 3", "Lenovo", 49999, 5, "Student Laptop", laptop_category)

        customer = Customer(1, "Rahul Naik", "rahul@gmail.com", "9876543210", "Goa")

        employee = Employee(501, "Store Manager", "Sales Manager", "9123456789", "manager@electronicstore.com")

        supplier = Supplier(301, "Tech Suppliers Pvt Ltd", "9000000000", "supplier@gmail.com", "Panaji, Goa")

        order = Order(5001, "22-09-2026", customer, employee)

        choice = 0

        while choice != 8:
            print()
            print("======================================")
            print("     ELECTRONIC STORE MANAGEMENT")
            print("======================================")
            print("1. View Customer")
            print("2. View Products")
            print("3. View Supplier")
            print("4. Add Product to Order")
            print("5. View Order")
            print("6. Make Payment")
            print("7. View Employee")
            print("8. Exit")
            print("======================================")
            try:
                choice = int(input("Enter your choice: "))
            except ValueError:
                print("Invalid choice. Please try again.")
                continue

            if choice == 1:
                print()
                print("===== CUSTOMER =====")
                customer.display_customer()

            elif choice == 2:
                print()
                print("===== PRODUCTS =====")
                phone.display_product()
                print()
                laptop.display_product()

            elif choice == 3:
                print()
                print("===== SUPPLIER =====")
                supplier.display_supplier()
                supplier.supply_products()

            elif choice == 4:
                print()
                print("1. Samsung Galaxy A55")
                print("2. Lenovo IdeaPad Slim 3")
                try:
                    product_choice = int(input("Select product: "))
                    quantity = int(input("Enter quantity: "))
                except ValueError:
                    print("Invalid product choice or quantity.")
                    continue

                if product_choice == 1:
                    order.add_product(phone, quantity)
                elif product_choice == 2:
                    order.add_product(laptop, quantity)
                else:
                    print("Invalid product choice.")

            elif choice == 5:
                order.display_order()

            elif choice == 6:
                total = order.calculate_total()

                if total == 0:
                    print("No products in the order.")
                else:
                    payment = Payment(9001, "UPI", total)
                    payment.process_payment()
                    order.update_status("Paid")
                    print("Order payment completed successfully.")

            elif choice == 7:
                print()
                print("===== EMPLOYEE =====")
                employee.display_employee()
                employee.manage_orders()

            elif choice == 8:
                print("Thank you for using Electronic Store Management System!")

            else:
                print("Invalid choice. Please try again.")


if __name__ == "__main__":
    ElectronicStoreSystem.main()
