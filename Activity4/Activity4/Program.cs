interface item
{
    void setFood(string foodName);
    void setPrice(int foodPrice);
    void setQuantity(int foodQuantity);

}

class items: item
{
    private string food;
    private int price;
    private int quantity;

    public void setFood(string foodName)
    {
        food = foodName;
    }
    public void setPrice(int foodPrice)
    {
        price = foodPrice;
    }
    
    public void setQuantity(int foodQuantity)
    {
        quantity = foodQuantity;
    }
    
    public void print()
    {
        Console.WriteLine(food + "'s at " + price + " dollars " + quantity + " left");
    }
}

class indexer<T>
{
    private T[] arr = new T[100];
    public T this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }
}

class Program
{
    static void Main()
    {
        items apple = new items();
        apple.setFood("apple");
        apple.setPrice(2);
        apple.setQuantity(14);
        apple.print();
        var stringCollection = new indexer<string>();
        stringCollection[0] = "test";
        Console.WriteLine(stringCollection[0]);
    }
}

