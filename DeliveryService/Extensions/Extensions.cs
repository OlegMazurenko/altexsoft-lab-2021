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
        public static bool IsValidNumber(this string number)
        {
            var pattern = @"^[+]?[3]?[8]?0[(]?[0-9]{2}[)]?[\s]?[0-9]{3}[\s]?[0-9]{2}[\s]?[0-9]{2}$";
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
            var pattern1 = @"^ули?ц?а?[.]?[\s]?[А-Яа-я]{5}[А-Яа-я\s]*[.,]{1}[\s]?до?м?[.]?[\s]?[0-9]{1,3}$";
            var pattern2 = @"^ули?ц?а?[.]?[\s]?[А-Яа-я]{5}[А-Яа-я\s]*[.,]{1}[\s]?до?м?[.]?[\s]?[0-9]{1,3},[\s]?ква?р?т?и?р?а?[.]?[\s]?[0-9]{1,3}$";
            var expression = new Regex(pattern1 + "|" + pattern2);
            return expression.IsMatch(address);
        }
    }
}
