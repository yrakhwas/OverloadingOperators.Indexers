using System.Diagnostics;

Laptop l1 = new Laptop("Lenovo", 26000.00);
Shop shop = new Shop(5);
shop.SetLaptop(l1, 0);
shop.SetLaptop(new Laptop("Asus", 600000.00), 1);
//Console.WriteLine(shop.GetLaptop(0));

shop[2] = new Laptop("Dell", 34000.00);
shop[3] = new Laptop("HP", 40000.00);
shop[4] = new Laptop("Apple", 43000.00);

shop["HP"] = new Laptop("Xiaomi", 25000.00);

shop[26000.00] = new Laptop("Dream Machine", 22000.00);
for (int i = 0; i < shop.length; i++)
{
    Console.WriteLine(shop[i].ToString()) ;
}


MulArr mulArr = new MulArr(2, 2);
mulArr[0, 0] = 58;
for (int i = 0;i<mulArr.rows;i++)
{
    for (int j = 0;j < mulArr.cols;j++)
    {
        Console.Write(mulArr[i,j] + " ");
    }
    Console.WriteLine();
}

class Laptop
{
    public string Brand { get; set; }
    public double Price { get; set; }
    public Laptop():base(){ }
    public Laptop(string b, double p)
    {
        Brand = b;
        Price = p;
    }
    public override string ToString()
    {
        return $"Brand : {Brand} Price : {Price}";
    }
}

class Shop
{
    Laptop[] laptops;
    public Shop(int size)
    {
        laptops = new Laptop[size];
    }
    public int length { get
        {
            return laptops.Length;
        }
    }
    public void SetLaptop(Laptop laptop, int index)
    {
        laptops[index] = laptop;
    }
    public Laptop GetLaptop(int index)
    {
        if(index >=0 && index <=laptops.Length)
            return laptops[index];
        else
            throw new IndexOutOfRangeException("Incorrect index");
    }
    public Laptop this[int index]
    {
        get
        {
            if (index >= 0 && index <= laptops.Length)
                return laptops[index];
            else
                throw new IndexOutOfRangeException("Incorrect index");
        }
        set
        {
            if (index >= 0 && index <= laptops.Length)
                laptops[index] = value;
            else
                throw new IndexOutOfRangeException("Out of range");
        }

    }
    public Laptop this[string brand]
    {
        get
        {
            foreach (var item in laptops)
            {
                if (brand == item.Brand)
                {
                    return item;
                }
                else
                    return null;
            }
            return null;
        }
        set
        {
            for (int i = 0; i < laptops.Length; i++)
            {
                if (laptops[i].Brand == brand)
                {
                    laptops[i] = value;
                    break;
                }
            }
        }
    }
    public int FindByPrice(double Price)
    {
        for (int i = 0; i < laptops.Length; i++)
        {
            if (Price == laptops[i].Price)
            {
                return i;
            }
        }
        return -1;
    }
    public Laptop this[double price]
    {
        get
        {
            //foreach (var item in laptops)
            //{
            //    if (price == item.Price)
            //    {
            //        return item;
            //    }
            //    else
            //        return null;
            //}
            //return null;
            int index = FindByPrice(price);
            if (index != -1)
                return laptops[index];
            else
                throw new Exception("Incorrect price");
        }
        set
        {
            //for (int i = 0; i < laptops.Length; i++)
            //{
            //    if (laptops[i].Price == price)
            //    {
            //        laptops[i] = value;
            //        break;
            //    }
            //}
            int index = FindByPrice(price);
            if(index != -1)
            {
                this[index] = value;
            }
        }
    }
}

class MulArr
{
    private int[,] arr;
    public int rows { get; set; }
    public int cols { get; set; }
    public MulArr(int r, int c)
    {
        rows = r; cols = c;
        arr = new int[rows, cols];
    }
    public int this[int r, int c]
    {
        get
        {
            return arr[r, c];
        }
        set
        {
            arr[r, c] = value;  
        }
    }

}