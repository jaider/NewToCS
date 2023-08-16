#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define MAX_FRUITS 100

typedef struct {
    char name[50];
    int quantity;
} FruitItem;

typedef struct {
    char name[50];
    double price;
} FruitPrice;

double getRandomPrice() {
    return (rand() % 10 + 1) + ((double)rand() / RAND_MAX);
}

int main() {
    char readyToCheckout;
    FruitItem cart[MAX_FRUITS];
    int cartSize = 0;

    srand(time(NULL)); // Initialize random number generator
    
    FruitPrice fruitPrices[] = {
        { "Apple", getRandomPrice() },
        { "Banana", getRandomPrice() },
        { "Orange", getRandomPrice() }
        // You can add more fruits and prices here
    };

start:
    printf("Open Catalog\n");
    
    // Offer a list of fruits to choose from
    printf("Available Fruits:\n");
    for (int i = 0; i < sizeof(fruitPrices) / sizeof(FruitPrice); i++) {
        printf("%d. %s\n", i + 1, fruitPrices[i].name);
    }
    printf("%d. Other\n", sizeof(fruitPrices) / sizeof(FruitPrice) + 1);
    
    printf("Select the Product: ");
    int choice;
    scanf("%d", &choice);

    if (choice >= 1 && choice <= sizeof(fruitPrices) / sizeof(FruitPrice)) {
        strcpy(cart[cartSize].name, fruitPrices[choice - 1].name);
    } else if (choice == sizeof(fruitPrices) / sizeof(FruitPrice) + 1) {
        printf("Enter the name of the fruit: ");
        scanf("%s", cart[cartSize].name);
    } else {
        printf("Invalid choice. Please try again.\n");
        goto start;
    }

    printf("Edit Quantity: ");
    scanf("%d", &cart[cartSize].quantity);

    if (cart[cartSize].quantity <= 0) {
        printf("Invalid quantity. Setting to default (1).\n");
        cart[cartSize].quantity = 1;
    }

    cartSize++;

    printf("Add to Shopping Cart\n");

    printf("Ready to Checkout? (y/n): ");
    scanf(" %c", &readyToCheckout);

    if (readyToCheckout == 'y' || readyToCheckout == 'Y') {
        printf("Shopping Cart Contents:\n");
        double total = 0;
        for (int i = 0; i < cartSize; i++) {
            double price = 0;
            for (int j = 0; j < sizeof(fruitPrices) / sizeof(FruitPrice); j++) {
                if (strcmp(cart[i].name, fruitPrices[j].name) == 0) {
                    price = fruitPrices[j].price;
                    break;
                }
            }
            double itemTotal = price * cart[i].quantity;
            total += itemTotal;
            printf("%d %s - Price: %.2lf - Total: %.2lf\n", cart[i].quantity, cart[i].name, price, itemTotal);
        }
        printf("Total: %.2lf\n", total);
        
        printf("Press Checkout\n");
        printf("Add Payment Info\n");
        printf("Add Shipping Info\n");
        printf("Get Tracking Print\n");
    } else {
        goto start;
    }

    return 0;
}
