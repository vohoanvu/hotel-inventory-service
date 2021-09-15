using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    public class Facility
    {
        public int FacilityCode { get; set; }
        public int FacilityGroupCode { get; set; }
        public int Order { get; set; }
        public bool IndLogic { get; set; }
        public bool IndFee { get; set; }
        public bool Voucher { get; set; }
        public bool IndYesOrNo { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int Number { get; set; }

    }
}
