/// <summary>
/// namespace to hold the detals of Data transfer Obejects
/// </summary>
namespace DataTransferObjects
{
    /// <summary>
    /// DTo to hold data for advertised cars
    /// </summary>
    public class AdvertisedCarDTO
    {
        /// <summary>
        /// Id of the car
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Year of the car make
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// Make/Company of the car who made ot
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// Variant Name of the car
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Type of Advertisement
        /// </summary>
        public string AdvertisedPriceType { get; set; }
        /// <summary>
        /// excluding government charges (EGC)
        /// </summary>
        public decimal ECGAmount { get; set; }
        /// <summary>
        /// drive-away price (DAP)
        /// </summary>
        public decimal DAPAmount { get; set; }
        /// <summary>
        /// Amount to sell the car
        /// </summary>
        public decimal AdvertisedAmount { get; set; }
    }
}
