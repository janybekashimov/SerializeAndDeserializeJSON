using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializeJSON
{
    public class Transaction
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public Transaction(int id, DateTime transactionDate, decimal amount)
        {
            Id = id;
            TransactionDate = transactionDate;
            Amount = amount;
        }
    }
}
