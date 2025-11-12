using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yr25Mango.Web.Models.DTO
{
    public class CouponDTO
    {
        public int CouponId { get; set; }

        [DisplayName("Coupon Code")]
        [Required(ErrorMessage = "{0} is required.")]
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
