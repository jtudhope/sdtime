using System.Text.RegularExpressions;

namespace GA.Core.Util
{
    public static class EntityValidationTools
    {
        private const string NameValidationExpr = @"^[^?]*$";
        private const string CodeValidationExpr = @"^[^?\s]*$";
        
        public static bool IsNameValid(string name, out string message)
        {
            message = "";
            var expr1 = new Regex(NameValidationExpr);
            if (!expr1.IsMatch(name))
            {
                message = "Name cannot contain a question mark";
                return false;
            }
            return true;
        }
        public static bool IsCodeValid(string code, out string message)
        {
            message = "";
            var expr1 = new Regex(CodeValidationExpr);
            if (!expr1.IsMatch(code))
            {
                message = "Code cannot contain a question marks or spaces";
                return false;
            }
            return true;
        }
    }
}
