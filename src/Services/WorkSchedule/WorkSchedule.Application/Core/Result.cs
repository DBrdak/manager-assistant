using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace WorkSchedule.Application.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }

        public static Result<T> Success(T value) => new (){IsSuccess = true, Value = value};

        public static Result<T> Failure(string message) =>
            new (){Message = message, IsSuccess = false};
    }
}
