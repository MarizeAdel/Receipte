using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public List<ReceiptItem> ReceiptItems 
        { get; set; } = new List<ReceiptItem>();
        public decimal Total { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
