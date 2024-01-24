namespace EnergiaClienteDominio
{
    public class Invoice
    {
        /// <summary>
        /// The invoice number
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// The invoice start date
        /// </summary>
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool Paid { get; set; }
        public decimal Value { get; set; }
        public DateTime limitDate { get; set; }
        public int habitation { get; set; }
        public byte[] document { get; set; }
    }
}