using System;
using System.Collections.Generic;
using System.Text;

namespace Mondays.Utility
{
    public static class SD
    {
        public const string Proc_CoverType_Create = "usp_CreateCoverType";
        public const string Proc_CoverType_Get = "usp_GetCoverType";
        public const string Proc_CoverType_GetAll = "usp_GetCoverTypes";
        public const string Proc_CoverType_Update = "usp_UpdateCoverType";
        public const string Proc_CoverType_Delete = "usp_DeleteCoverType";


        public const string Role_Admin = "Διαχειριστής";
        public const string KitchenUser = "Κουζίνα";
        public const string FrontDeskUser = "Ταμείο";
        public const string Role_Employee = "Υπάλληλος";
        public const string Role_User_Indi = "Μεμονωμένος πελάτης";
        public const string Role_User_Comp = " Εταιρικός Πελάτης";

        public const string ssShoppingCart = "Shoping Cart Session";

        public const string StatusPending = "Εκκρεμεί";
        public const string StatusApproved = "Εγκρίθηκε";
        public const string StatusInProcess = "Επεξεργασία";
        public const string StatusShipped = "Παραδόθηκε";
        public const string StatusCancelled = "Ακυρώθηκε";
        public const string StatusRefunded = "Επιστροφή χρημάτων";

        public const string PaymentStatusPending = "Εκκρεμεί";
        public const string PaymentStatusApproved = "Εγκρίθηκε";
        public const string PaymentStatusDelayedPayment = "Εγκρίθηκε για καθυστέρηση πληρωμής";
        public const string PaymentStatusRejected = "Απορρίφθηκε";



        public static double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            if(quantity < 50)
            {
                return price;
            }
            else
            {
                if(quantity < 100)
                {
                    return price50;
                }
                else
                {
                    return price100;
                }
            }
        }

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
