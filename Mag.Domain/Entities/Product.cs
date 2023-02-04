namespace Mag.Domain.Entities;

public class Product
{
    #region Fields
    private int _remainValidityDays => GetRemainingValidityDays();
    private DateTime _expirationDate => Date.AddDays(ValidityDays);
    
    #endregion


    #region Properties
    
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string? Name { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;
    public double Price => GetPrice();
    public double InitialPrice { get; private set; }
    public int ValidityDays { get; private set; }
    public bool IsExpiredValidityDays => GetIsExpiredValidityDays();
    public bool IsExpiredForOneMonth => GetIsExpiredForOneMonth();

    #endregion


    #region Ctors
    private Product() {}

    #endregion

    #region FactoryMethods
    
    public static Product Create(string name, double initialPrice, int validityDays)
    {
        return new Product
        {
            Name = name,
            InitialPrice = initialPrice,
            ValidityDays = validityDays
        };
    }

    #endregion


    #region LocalMethods
    private double GetPrice()
    {
        var discountRatio = GetDiscountRatio();
        var discount = InitialPrice * discountRatio;
        return InitialPrice - discount;
    }

    private double GetDiscountRatio()
    {
        var is20PercentDiscountDays = ValidityDays * 0.5;
        var is50PercentDiscountDays = ValidityDays * 0.25;

        if (_remainValidityDays >= is20PercentDiscountDays && _remainValidityDays < is50PercentDiscountDays)
            return 0.2;
        
        if (_remainValidityDays >= is50PercentDiscountDays && _remainValidityDays < 0)
        {
            return 0.5;
        }

        return _remainValidityDays < 0 ? 1 : 0;
    }

    private int GetRemainingValidityDays()
    {
        var expirationDate = Date.AddDays(ValidityDays);
        var dateDiff = (expirationDate - DateTime.Now).TotalDays;
        return (int)dateDiff;
    }
    
    private bool GetIsExpiredForOneMonth()
    {
        if (!IsExpiredValidityDays) return false;
        var oneMonthDateExpiration = _expirationDate.AddMonths(1);
        return DateTime.Now <= oneMonthDateExpiration;
    }

    private bool GetIsExpiredValidityDays()
    {
        return _remainValidityDays < 0;
    }

    #endregion
    
}