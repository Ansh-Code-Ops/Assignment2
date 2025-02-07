public class Product
{
    public int ProdID { get; set; }
    public string ProdName { get; set; }
    public int ItemPrice { get; set; }
    public int StockAmount { get; set; }

    public Product(int prodID, string prodName, int itemPrice, int stockAmount)
    {
        ProdID = prodID;
        ProdName = prodName;
        ItemPrice = itemPrice;
        StockAmount = stockAmount;
    }

    public void IncreaseStock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("amount", "Amount to increase must be positive.");
        }

        StockAmount += amount;
    }

    public void DecreaseStock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("amount", "Amount to decrease must be positive.");
        }

        if (amount > StockAmount)
        {
            
            throw new InvalidOperationException("Stock cannot be negative.");
        }

        StockAmount -= amount;
    }


}
