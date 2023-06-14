namespace JSonataDemo;

public class ChargeCaptured
{

    public Guid ChargeId { get; set; }

        public Guid ActionId { get; set; }

        public string CorrelationId { get; set; }

        public Transaction Transaction { get; set; }

        public string MerchantReference { get; set; }

        public string Description { get; set; }

        public IDictionary<string, object> ProcessingSettings { get; set; }

        public IDictionary<string, string> Metadata { get; set; }

        public IEnumerable<ChargeItem> Items { get; set; }

        public IDictionary<string, string> AuthorisationProcessorSettings { get; set; }

        public IEnumerable<SubEntity> SubEntities { get; set; }

        public bool IsCkoNetworkToken { get; set; }

        public bool IsForceCaptured { get; set; }
    
}

public class SubEntity
{
   
    public string Id { get; set; }

    public Decimal Amount { get; set; }

    public string Name { get; set; }

    public string Reference { get; set; }

    public Commission Commission { get; set; }
}

public class Commission
{

    public Decimal? Amount { get; set; }

    public Decimal? Percentage { get; set; }
}

public class ChargeItem
{
    public string Sku { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public string ShippingTrackingUrl { get; set; }

    public Decimal Price { get; set; }

    public int Quantity { get; set; }

    public Decimal ShippingCost { get; set; }
}

  public class Transaction
  {
      public Guid Id { get; set; }

    public Decimal Value { get; set; }

    public int AcquirerId { get; set; }

    public int AcquirerCredentialId { get; set; }

    public DateTime ProcessedOn { get; set; }

    public DateTime? AuthorisationExpiry { get; set; }

    public string ResponseCode { get; set; }

    public string ResponseSummary { get; set; }

    public string ResponseDetails { get; set; }

    public string AcquirerTransactionId { get; set; }

    public string GlobalAcquirerId { get; set; }

    public string AcquirerCountry { get; set; }

    public string AcquirerBin { get; set; }

    public string AcquirerReferenceNumber { get; set; }

    public string AcquirerResponseCode { get; set; }

    public string AuthorisationCode { get; set; }

    public string AvsCheck { get; set; }

    public string CvvCheck { get; set; }

    public Dictionary<string, string> AcquirerMetadata { get; set; }

    public double ProcessingTime { get; set; }

    public BillingDescriptor BillingDescriptor { get; set; }

    public string SchemeTransactionId { get; set; }

    public string Eci { get; set; }

    public string AcquirerName { get; set; }

    public string MerchantCategoryCode { get; set; }

    public bool GatewayServicesOnly { get; set; }

    public string SchemeMerchantId { get; set; }

    public string ProviderKey { get; set; }

    public string RetrievalReferenceNumber { get; set; }

    public bool? Authorised { get; set; }

    public long? AcquirerTiming { get; set; }

    public bool? ExemptionExecuted { get; set; }

    public bool? Payouts { get; }

    public string FastFunds { get; }

    public string RecommendationCode { get; }

    public string ObsCode { get; set; }

    public string ObsResultCode { get; set; }

    public string AuthorizationCharacteristicsIndicator { get; set; }

    public Card ReplacementCard { get; set; }

    public string PanType { get; set; }

    public Dictionary<string, string> ProcessorSettings { get; set; }
  }

public class BillingDescriptor
{
    public string Name { get; set; }

    public string City { get; set; }
}

public class Card
  {
      public Guid? VaultId { get; set; }

    public string Fingerprint { get; set; }

    public string FingerprintHistoric { get; set; }

    public string Scheme { get; set; }

    public string MaskedNumber { get; set; }

    public int ExpiryMonth { get; set; }

    public int ExpiryYear { get; set; }

    public string Name { get; set; }

    public string Bin { get; set; }

    public string BinMax { get; set; }

    public string Category { get; set; }

    public string Type { get; set; }

    public string ProductId { get; set; }

    public string IssuerName { get; set; }

    public string IssuerCountryIso2Code { get; set; }

    public string ProductType { get; set; }

    public string NetworkTokenType { get; set; }

    public bool? IsCkoNetworkToken { get; set; }

    public Address BillingAddress { get; set; }

    public PhoneNumber Phone { get; set; }

    public string WalletType { get; set; }

    public string SchemeLocal { get; set; }

    public string TokenFormat { get; set; }

    public bool? StoreForFutureUse { get; set; }

    public bool CardOnFile { get; set; }
  }

public class Address
{

    public string Line1 { get; set; }

    public string TownCity { get; set; }

    public string Postcode { get; set; }

    public string Country { get; set; }

    public string State { get; set; }

    public string Line2 { get; set; }
}
public class PhoneNumber
{
  
    public string CountryCode { get; set; }

    public string Number { get; set; }
}