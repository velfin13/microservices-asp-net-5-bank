using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Cqrs.Core.Event
{
    public class FundsWithdrawnEvent : BaseEvent
    {
        public double amount {  get; set; }
        public FundsWithdrawnEvent(string id) : base(id)
        {
        }
    }
}
