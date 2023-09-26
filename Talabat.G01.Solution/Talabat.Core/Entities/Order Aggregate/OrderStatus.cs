﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public enum OrderStatus
    {
        [EnumMember (Value = "Panding")]
        Panding,
        [EnumMember(Value = "Payment Received")]

        PaymentReceived,
        [EnumMember(Value = "Payment Failed")]
        paymetFailed
    }
}
