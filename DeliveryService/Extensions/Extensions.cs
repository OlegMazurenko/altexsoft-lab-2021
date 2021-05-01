using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeliveryService.Extensions
{
    public static class Extensions
    {
        public static bool IsValidPhoneNumber(this string number)
        {
            var pattern = @"^([+]38)?0[(]?[0-9]{2}[)]?[\s]?[0-9]{3}[\s]?[0-9]{2}[\s]?[0-9]{2}$";
            var expression = new Regex(pattern);
            return expression.IsMatch(number);
        }

        public static bool IsValidEmail(this string email)
        {
            var pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var expression = new Regex(pattern);
            return expression.IsMatch(email);
        }

        public static bool IsValidAddress(this string address)
        {
            var pattern = @"^ул(ица)?[.]?[\s]?[А-Яа-я]{5}[А-Яа-я\s]*[.,]{1}[\s]?д(ом)?[.]?[\s]?[0-9]{1,3}(,[\s]?кв(артира)?[.]?[\s]?[0-9]{1,3})?$";
            var expression = new Regex(pattern);
            return expression.IsMatch(address);
        }
    }
}
