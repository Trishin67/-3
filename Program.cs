using System;
using System.Collections.Generic;
using System.Linq;

class Color
{
    private int red;
    private int green;
    private int blue;

    public int Red
    {
        get { return red; }
        set { red = NormalizeColorValue(value); }
    }

    public int Green
    {
        get { return green; }
        set { green = NormalizeColorValue(value); }
    }

    public int Blue
    {
        get { return blue; }
        set { blue = NormalizeColorValue(value); }
    }

    public Color(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public void DisplayColor()
    {
        Console.WriteLine($"Red: {Red}, Green: {Green}, Blue: {Blue}");
    }

    private int NormalizeColorValue(int colorValue)
    {
        if (colorValue > 255)
            return 255;
        if (colorValue < 0)
            return 0;
        return colorValue;
    }
}

class SmsMessage
{
    private string messageText;
    private double price;

    public string MessageText
    {
        get { return messageText; }
        set
        {
            messageText = value.Length > MaxLength ? value.Substring(0, MaxLength) : value;
            CalculatePrice();
        }
    }

    public double Price
    {
        get { return price; }
    }

    public int MaxLength { get; set; }
    public double InitialPrice { get; set; }
    public double PricePerExtraCharacter { get; set; }

    public SmsMessage(string messageText, int maxLength, double initialPrice, double pricePerExtraCharacter)
    {
        MessageText = messageText;
        MaxLength = maxLength;
        InitialPrice = initialPrice;
        PricePerExtraCharacter = pricePerExtraCharacter;
    }

    private void CalculatePrice()
    {
        int messageLength = MessageText.Length;
        double standardPrice = InitialPrice + (messageLength <= MaxLength ? 0 : (messageLength - MaxLength) * PricePerExtraCharacter);
        price = standardPrice > 0 ? standardPrice : 0;
    }
}

class SQLCommand
{
    private string commandText;

    public string CommandText
    {
        get { return commandText; }
        set { commandText = value.ToUpper(); }
    }

    public SQLCommand(string commandText)
    {
        CommandText = commandText;
    }
}

class MyIntList
{
    private List<int> numbersList = new List<int>();
    private int maxLength;
    private double initialPrice;
    private double pricePerExtraCharacter;

    public int MaxLength
    {
        get { return maxLength; }
        set { maxLength = value; }
    }

    public double InitialPrice
    {
        get { return initialPrice; }
        set { initialPrice = value; }
    }

    public double PricePerExtraCharacter
    {
        get { return pricePerExtraCharacter; }
        set { pricePerExtraCharacter = value; }
    }

    public MyIntList(int maxLength, double initialPrice, double pricePerExtraCharacter)
    {
        MaxLength = maxLength;
        InitialPrice = initialPrice;
        PricePerExtraCharacter = pricePerExtraCharacter;
    }

    public void AddNumber(int number)
    {
        if (numbersList.Count < MaxLength)
            numbersList.Add(number);
    }

    public void RemoveNumber(int number)
    {
        numbersList.Remove(number);
    }

    private double CalculateAverage()
    {
        int sum = 0;
        foreach (int number in numbersList)
        {
            sum += number;
        }
        return numbersList.Count > 0 ? sum / (double)numbersList.Count : 0;
    }

    public double Average
    {
        get
        {
            return CalculateAverage();
        }
    }
}

class RandomNumberGenerator
{
    private List<int> randomNumbers;
    private bool isCached;
    private double average;
    private double variance;
    private double standardDeviation;
    private double median;

    public int SequenceLength { get; private set; }

    public RandomNumberGenerator(int sequenceLength)
    {
        SequenceLength = sequenceLength;
        GenerateRandomNumbers();
        isCached = false;
    }

    public List<int> RandomNumbers
    {
        get
        {
            if (!isCached)
            {
                CalculateStatistics();
            }
            return randomNumbers;
        }
    }

    public double Average
    {
        get
        {
            if (!isCached)
            {
                CalculateStatistics();
            }
            return average;
        }
    }

    public double Variance
    {
        get
        {
            if (!isCached)
            {
                CalculateStatistics();
            }
            return variance;
        }
    }

    public double StandardDeviation
    {
        get
        {
            if (!isCached)
            {
                CalculateStatistics();
            }
            return standardDeviation;
        }
    }

    public double Median
    {
        get
        {
            if (!isCached)
            {
                CalculateStatistics();
            }
            return median;
        }
    }

    private void GenerateRandomNumbers()
    {
        randomNumbers = new List<int>();
        Random random = new Random();
        for (int i = 0; i < SequenceLength; i++)
        {
            randomNumbers.Add(random.Next(1, 101)); // генерация рандомных чисел от 1 до 100
        }
    }

    private void CalculateStatistics()
    {
        average = randomNumbers.Average();
        variance = randomNumbers.Average(num => Math.Pow(num - average, 2));
        standardDeviation = Math.Sqrt(variance);
        randomNumbers.Sort();
        int mid = randomNumbers.Count / 2;
        median = (randomNumbers.Count % 2 != 0) ? (double)randomNumbers[mid] : (double)(randomNumbers[mid - 1] + randomNumbers[mid]) / 2;
        isCached = true;
    }
}

class Program
{
    static void Main()
    {
        Color color1 = new Color(200, 50, 100);
        color1.DisplayColor();

        Color color2 = new Color(300, 400, -50);
        color2.DisplayColor();

        Color color3 = new Color(0, 255, 128);
        color3.DisplayColor();

        SmsMessage sms = new SmsMessage("This is a long message that exceeds the maximum length.", 160, 1.5, 0.5);
        Console.WriteLine($"Message Text: {sms.MessageText}");
        Console.WriteLine($"Price: {sms.Price:C}");

        SQLCommand sqlCommand = new SQLCommand("select * from users");
        Console.WriteLine($"SQL Command Text: {sqlCommand.CommandText}");

        MyIntList intList = new MyIntList(5, 1.5, 0.5);
        intList.AddNumber(1);
        intList.AddNumber(2);
        intList.AddNumber(3);
        intList.AddNumber(4);
        intList.AddNumber(5);

        Console.WriteLine($"Average: {intList.Average}");

        RandomNumberGenerator generator = new RandomNumberGenerator(10);
        Console.WriteLine($"Random Numbers: {string.Join(", ", generator.RandomNumbers)}");
        Console.WriteLine($"Average: {generator.Average}");
        Console.WriteLine($"Variance: {generator.Variance}");
        Console.WriteLine($"Standard Deviation: {generator.StandardDeviation}");
        Console.WriteLine($"Median: {generator.Median}");
    }
}
