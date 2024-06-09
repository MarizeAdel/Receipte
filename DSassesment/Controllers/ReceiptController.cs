using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;

namespace DSassesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptController: ControllerBase
    {
        
        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }
        [HttpPost("createReceite")]

        public IActionResult CreateReceipt()
        {
            var receipt = _receiptService.CreateReceipt();

            
            return Ok(receipt.Id); // Returning JSON response
        }

        [HttpPost("add-item")]
        public IActionResult AddItemToReceipt(int receiptId, int itemId, int quantity)
        {
            try
            {
                _receiptService.AddItemToReceipt(receiptId, itemId, quantity);
                return Ok(); // Or return a JSON response
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Or handle the error appropriately
            }
        }
        [HttpGet("Get-info")]
        public IActionResult GetReceipt(int receiptid) { 
            var r =_receiptService.GetTotal(receiptid);
            return Ok(r);
        }

        [HttpPost("complete-payment")]
        public IActionResult CompletePayment(int receiptId, decimal paidAmount)
        {
            try
            {
                _receiptService.CompletePayment(receiptId, paidAmount);
                var remainingAmount = _receiptService.GetRemainingAmount(receiptId);
                return Ok(remainingAmount); // Or return a JSON response
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Or handle the error appropriately
            }
        }

    }
}
