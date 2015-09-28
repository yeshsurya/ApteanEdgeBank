using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBank
{
    interface ILiability_CheckID
    {
        int checkID(int Customer_ID);
    }

    interface ILiability_CreateDB
    {
        bool createDB(int Customer_ID);

    }

    interface ILiability_IssueLoan_Cash
    {
        double issueLoan(int accountID, float amount);

    }

    interface ILiability_IssueLoanAccount
    {
        void issueLoanAccount(int accountID, float amount);
    }
}

