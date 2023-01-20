﻿using BET.Data.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Contract
{
    public interface IEmailService
    {
        void SendEmailMessage(string email, string subject, string emailBody);
    }
}
