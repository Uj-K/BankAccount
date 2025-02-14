using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CPW 211 Week 5
namespace BankAccount
{
    /// <summary>
    /// Represent a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Represents a single costumers bank account and a balance of 0
        /// </summary>
        /// <param name="accOwner">The customer full name that owns the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }

        /// <summary>
        /// The account holders full name (first and last)
        /// </summary>
        public string Owner {  get; set; }

        /// <summary>
        /// The amount of money currently in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Adds a specified amount of money to the account
        /// </summary>
        /// <param name="amt">The positive amount to deposit</param>
        /// <returns>The new balance after the deposit</returns>
        public double Deposit(double amt)
        {
            if (amt <= 0) 
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0");
                // nameof 가 나중에 저거 혹시 rename 해줄때 같이 될수있게 하는거
            }

            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraws an amount of money from the balance
        /// </summary>
        /// <param name="amt">The positive amount of money to be taken from the balance</param>
        /// <returns>Updated balance after withdrawal</returns>    
        public double Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new ArgumentException($"The {nameof(amt)} must be less than {nameof(Balance)}");
            }
        
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0");
            }

            Balance -= amt;
            return Balance;

        }
    }
}
