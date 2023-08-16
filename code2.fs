open System

type FruitItem = { Name: string; Quantity: int }
type FruitPrice = { Name: string; Price: float }

let getRandomPrice rand =
    float ((rand.Next(1, 11)) + rand.NextDouble())

let rec main () =
    let rand = Random()

    let mutable cart = Array.create 100 { Name = ""; Quantity = 0 }
    let mutable cartSize = 0

    let fruitPrices =
        [| { Name = "Apple"; Price = getRandomPrice rand }
           { Name = "Banana"; Price = getRandomPrice rand }
           { Name = "Orange"; Price = getRandomPrice rand }
           // You can add more fruits and prices here
        |]

    while true do
        Console.WriteLine("Open Catalog")

        Console.WriteLine("Available Fruits:")
        for i in 0 .. fruitPrices.Length - 1 do
            printfn "%d. %s" (i + 1) fruitPrices.[i].Name
        printfn "%d. Other" (fruitPrices.Length + 1)

        Console.Write("Select the Product: ")
        let choice = int(Console.ReadLine())

        if choice >= 1 && choice <= fruitPrices.Length then
            cart.[cartSize] <- { Name = fruitPrices.[choice - 1].Name; Quantity = 0 }
        elif choice = fruitPrices.Length + 1 then
            Console.Write("Enter the name of the fruit: ")
            cart.[cartSize] <- { Name = Console.ReadLine(); Quantity = 0 }
        else
            Console.WriteLine("Invalid choice. Please try again.")
            continue

        Console.Write("Edit Quantity: ")
        cart.[cartSize].Quantity <- int(Console.ReadLine())

        if cart.[cartSize].Quantity <= 0 then
            Console.WriteLine("Invalid quantity. Setting to default (1).")
            cart.[cartSize].Quantity <- 1

        cartSize <- cartSize + 1

        Console.WriteLine("Add to Shopping Cart")

        Console.Write("Ready to Checkout? (y/n): ")
        let readyToCheckout = Console.ReadKey().KeyChar
        Console.WriteLine()

        if readyToCheckout = 'y' || readyToCheckout = 'Y' then
            Console.WriteLine("Shopping Cart Contents:")
            let mutable total = 0.0
            for i in 0 .. cartSize - 1 do
                let mutable price = 0.0
                for j in 0 .. fruitPrices.Length - 1 do
                    if cart.[i].Name = fruitPrices.[j].Name then
                        price <- fruitPrices.[j].Price
                        break
                let itemTotal = price * float cart.[i].Quantity
                total <- total + itemTotal
                printfn "%d %s - Price: %.2f - Total: %.2f" cart.[i].Quantity cart.[i].Name price itemTotal
            printfn "Total: %.2f" total

            Console.WriteLine("Press Checkout")
            Console.WriteLine("Add Payment Info")
            Console.WriteLine("Add Shipping Info")
            Console.WriteLine("Get Tracking Print")
        else
            main()

main ()
