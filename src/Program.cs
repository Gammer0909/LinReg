using System;
using System.Linq;
using CsvHelper;


class Program {
    static void Main(string[] args) {

        // Get data/AAPL.csv
        CsvReader? reader = new CsvReader(new StreamReader("data/AAPL.csv"), System.Globalization.CultureInfo.InvariantCulture);
        List<Stock>? records = reader.GetRecords<Stock>().ToList();

        // Get X and y
        double[] X = records.Select(r => r.Open).ToArray();
        double[] y = records.Select(r => r.Close).ToArray();

        // Calculate means
        double meanX = X.Sum() / X.Length;
        double meanY = y.Sum() / y.Length;

        // Calculate slope (m)
        double numerator = 0;
        double denominator = 0;
        for (int i = 0; i < X.Length; i++)
        {
            numerator += (X[i] - meanX) * (y[i] - meanY);
            denominator += Math.Pow(X[i] - meanX, 2);
        }
        double slope = numerator / denominator;

        // Calculate intercept (b)
        double intercept = meanY - slope * meanX;

        // Make predictions
        double newX = 164.25;
        double newY = slope * newX + intercept;

        // Evaluate performance (optional)
        // You can compare the predicted newY with the actual value for newX



        // Print results, rounded to 2 decimals
        Console.WriteLine($"Predicted Close for {newX} is {Math.Round(newY, 2)}");
    }
}

class Stock {

    public DateTime Date { get; set; }
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public double Volume { get; set; }

}