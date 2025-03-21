﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Business.Exceptions;

public class CustomException : Exception
{
    public int Code { get; set; }
    public string Message { get; set; }
    public Dictionary<string, string> Errors { get; set; } = new();
    public CustomException(int code, string message)
    {
        Code = code;
        Message = message;
    }
    public CustomException(string errorKey, string errorMessage)
    {
        Errors.Add(errorKey, errorMessage);
    }
    public CustomException(int code, string errorKey, string errorMessage, string message = null)
    {
        Code = code;
        Message = message;
        Errors.Add(errorKey, errorMessage);
    }

}
