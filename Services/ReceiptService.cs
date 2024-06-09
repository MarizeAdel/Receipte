using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReceiptService
    {
        private readonly ApplicationDbContext _context;

        public ReceiptService(ApplicationDbContext context)
        {
            _context = context;
        }


        public Receipt CreateReceipt()
        {
            var receipt = new Receipt {};
            _context.Receipts.Add(receipt);
            _context.SaveChanges();
            return receipt;
        }


        public void AddItemToReceipt(int receiptId, int itemId, int quantity)
        {
            var receipt = _context.Receipts.Find(receiptId);
            var item = _context.Products.Find(itemId);

            if (item == null || receipt == null)
                throw new Exception("Item or receipt not found");

            if (item.Balance < quantity)
                throw new Exception("Insufficient item balance");

            var receiptItem = new ReceiptItem
            {
                ProductId = item.Id,
                Quantity = quantity,
                Price = item.Price,
                SubTotal = item.Price * quantity
            };

            receipt.ReceiptItems.Add(receiptItem);
            receipt.Total += receiptItem.SubTotal;

            item.Balance -= quantity;

            _context.SaveChanges();
        }


        public void CompletePayment(int receiptId, decimal paidAmount)
        {
            var receipt = _context.Receipts.Find(receiptId);
            if (receipt == null)
                throw new Exception("Receipt not found");

            if (paidAmount < receipt.Total)
                throw new Exception("Paid amount is less than the total amount");

            receipt.PaidAmount = paidAmount;

            _context.SaveChanges();
        }
        public decimal GetTotal(int receiptId)
        {
            var receipt = _context.Receipts.Find(receiptId);
            if (receipt == null)
                throw new Exception("Receipt not found");
            return receipt.Total;

        }


            public decimal GetRemainingAmount(int receiptId)
        {
            var receipt = _context.Receipts.Find(receiptId);
            if (receipt == null)
                throw new Exception("Receipt not found");

            return   receipt.PaidAmount- receipt.Total;
        }
    }
}
