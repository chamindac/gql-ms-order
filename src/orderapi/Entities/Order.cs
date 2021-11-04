using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.Entities
{
    [Index(nameof(Number), IsUnique = true)]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(10)]
        public string Number{ get; set; }
        [MaxLength(10)]
        public string CustomerCode { get; set; }
        [MaxLength(250)]
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }

    public enum OrderState
    {
        New,
        CanelledLowCredit,
        Confirmed,
        Shipped
    }
}
