
namespace ConsoleApp2
{
    internal class CalculationOfDiscounts
    {
        static decimal TileQuantity { get; set; }
        static decimal TilePrice { get; set; }
        static decimal Rate { get; set; }

        public CalculationOfDiscounts(decimal tileQuantity, decimal tilePrice, decimal rate)
        {
            TileQuantity = tileQuantity;
            TilePrice = tilePrice;
            Rate = rate;
        }

        // Расчет цены плитки с учетом коэффициента страны
        public decimal PriceWithRate()
        {
            decimal tilePriceWithRate = TilePrice * Rate;
            return tilePriceWithRate;
        }

        // Определение процента скидки (мелкий опт от 500шт. до 1000шт. - 20%, крупный опт 1000шт. и выше - 50%)
        public decimal Persentage()
        {
            decimal discountPersentage;
            const decimal MIN_QUANTITY_FOR_DISCOUNT = 500M,
                          MAX_QUANTITY_FOR_DISCOUNT = 1000M;
            bool discount20PctAvailable = TileQuantity >= MIN_QUANTITY_FOR_DISCOUNT && TileQuantity < MAX_QUANTITY_FOR_DISCOUNT;
            bool discount50PctAvaible = TileQuantity >= MAX_QUANTITY_FOR_DISCOUNT;

            if (discount20PctAvailable)
            {
                return discountPersentage = 0.2M; // %
            }
            else if (discount50PctAvaible)
            {
                return discountPersentage = 0.5M; // %
            }
            else
            {
                return discountPersentage = 0M; // %
            }
        }

        // Расчет суммы к оплате
        public decimal PaymentAmount(decimal tilePriceWithRate, decimal discountPersentage)
        {
            decimal discount = tilePriceWithRate * discountPersentage;
            decimal totalAmount = TileQuantity * tilePriceWithRate - (TileQuantity * discount);
            return totalAmount;
        }
    }
}
