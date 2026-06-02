using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchRepairApp
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int? MasterID { get; set; }
        public string MasterName { get; set; }
        public string WatchType { get; set; }
        public string MechanismType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string DefectDescription { get; set; }
        public string Status { get; set; }
        public DateTime AcceptDate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public decimal RepairCost { get; set; }
        public int WarrantyMonths { get; set; }
        public string Notes { get; set; }
    }
}
