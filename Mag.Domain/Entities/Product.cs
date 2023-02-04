namespace Mag.Domain.Entities;

public sealed class Product
{
    #region Fields
    private int RemainValidityDays => GetRemainingValidityDays();
    private DateTime ExpirationDate => Date.AddDays(ValidityDays);

    #endregion

    #region Properties

    public string Id { get; } = Guid.NewGuid().ToString();
    public string? Name { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;
    public double Price => GetPrice();
    public double InitialPrice { get; private set; }
    public int ValidityDays { get; private set; }
    public bool IsExpiredValidityDays => GetIsExpiredValidityDays();
    public bool IsOneMonthBeforeExpired => GetIsExpiredForOneMonth();
    public double Discount => GetDiscountRatio();

    #endregion

    #region Ctors
    private Product() {}

    #endregion

    #region FactoryMethods

    public static Product Create(string name, double initialPrice, int validityDays)
    {
        var product = new Product { Name = name };
        product.Name = name;
        product.SetInitialPrice(initialPrice).SetValidityDays(validityDays);
        return product;
    }

    public void Update(string name, double initialPrice, int validityDays )
    {
        Name = name;
        SetInitialPrice(initialPrice);
        SetValidityDays(validityDays);
    }

    #endregion

    #region LocalMethods

    public Product SetInitialPrice(double price)
    {
        if (price <= 0)
        {
            const string errorMessage = $"{nameof(InitialPrice)} must be greater than 0";
            throw new InvalidOperationException(errorMessage);
        }

        InitialPrice = price;
        return this;
    }

    public Product SetValidityDays(int validityDays)
    {
        if (validityDays <= 0)
        {
            const string errorMessage = $"{nameof(validityDays)} must be greater than 0";
            throw new InvalidOperationException(errorMessage);
        }

        ValidityDays = validityDays;
        return this;
    }

    public Product SetCreationDate(DateTime dateTime)
    {
        Date = dateTime;
        return this;
    }

    private double GetPrice()
    {
        var discountRatio = GetDiscountRatio();
        var discount = InitialPrice * discountRatio;
        return InitialPrice - discount;
    }

    private double GetDiscountRatio()
    {
        var is20PercentDate = Date.AddDays(ValidityDays * 0.5);
        var is50PercentDate = Date.AddDays(ValidityDays * 0.75);

        if (DateTime.Now > is20PercentDate && DateTime.Now < is50PercentDate)
            return 0.2;

        if (DateTime.Now >= is50PercentDate && DateTime.Now <= ExpirationDate)
        {
            return 0.5;
        }

        return RemainValidityDays < 0 ? 1 : 0;
    }

    private int GetRemainingValidityDays()
    {
        var expirationDate = Date.AddDays(ValidityDays);
        var dateDiff = (expirationDate - DateTime.Now).TotalDays;
        return (int)dateDiff;
    }

    private bool GetIsExpiredForOneMonth()
    {
        return RemainValidityDays <= 30;
    }

    private bool GetIsExpiredValidityDays()
    {
        return RemainValidityDays < 0;
    }

    #endregion
}