#include <stdio.h>
int main() {
    char readyToCheckout;
    
    do {
        printf("Open Catalog\n");
        printf("Select the Product\n");
        printf("Edit Quantity\n");
        printf("Add to Shopping Cart\n");
        
        printf("Ready to Checkout? (y/n): ");
        scanf(" %c", &readyToCheckout);
        
        if (readyToCheckout == 'y' || readyToCheckout == 'Y') {
            printf("Press Checkout\n");
            printf("Add Payment Info\n");
            printf("Add Shipping Info\n");
            printf("Get Tracking Print\n");
        }
    } while (readyToCheckout != 'y' && readyToCheckout != 'Y');
    
    return 0;
}
