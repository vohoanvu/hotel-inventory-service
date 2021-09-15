using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    public class Issues
    {
        public string IssueCode { get; set; }
        public string IssueType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Order { get; set; }
        public bool Alternative { get; set; }
        public NameModel Name { get; set; }
        public NameModel Description { get; set; }
    }
}
