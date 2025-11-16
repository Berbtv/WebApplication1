using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Responses
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }

        public static Result Success()
        {
            return new Result { IsSuccess = true };
        }

        public static Result Failure(int errorCode, string errorMessage)
        {
            return new Result
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
    }
}
