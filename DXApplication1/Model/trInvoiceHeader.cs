using System;

namespace PointOfSale
{
    public class trInvoiceHeader
    {
        public string InvoiceHeaderId { get; set; }
        public string RelatedInvoiceId { get; set; }
        public string ProcessCode { get; set; }
        public string DocumentNumber { get; set; }
        public bool IsReturn { get; set; }
        public string CurrAccCode { get; set; }
        public string Description { get; set; }
        public DateTime DocumentDate { get; set; }
        public TimeSpan DocumentTime { get; set; }        
        public DateTime OperationDate { get; set; }
        public TimeSpan OperationTime { get; set; }
        public string CompanyCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string CustomsDocumentNumber { get; set; }
        public string POSTerminalId { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPrinted { get; set; }
        public string FiscalPrintedState { get; set; }
        public bool IsLocked { get; set; }
        public bool IsSalesViaInternet { get; set; }
    }
}
