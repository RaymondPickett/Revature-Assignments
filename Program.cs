using System;
using System.Collections.Generic;
using System.Text;

namespace RevatureProject0
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string input;
            string input2;
            List<User> users = new List<User>();
            User selectedUser = new User();
            Account selectedAccount = new Account();
            Account targetAccount = new Account();
            bool dontExit = true;
            bool found = false;
            bool validInput = false;
            bool stayLoggedIn = false;
            bool viewThisAccount = false;
            bool validInput2;
            int index;
            double numInput = 0;

            while (dontExit)
            {
                Console.WriteLine("You are not logged in.");
                Console.WriteLine("Enter NEW to register a new user.");
                Console.WriteLine("Enter LOG IN to log in.");
                Console.WriteLine("Enter ADVANCE TIME to simulate one year of time passing.");
                Console.WriteLine("Enter EXIT to quit the program.");
                input = Console.ReadLine().ToUpper();

                if (input.Equals("NEW"))
                {
                    selectedUser = new User();
                    Console.WriteLine("Choose a user name.");

                    validInput = false;
                    //This loop checks to see if the chosen user name is already used. If it is, you need to choose a different user name.
                    while (!validInput)
                    {
                        selectedUser.name = Console.ReadLine();
                        found = false;
                        foreach (User user in users)
                        {
                            if (user.name.Equals(selectedUser.name))
                            {
                                found = true;
                                Console.WriteLine("A user with that name already exists. Choose a different name.");
                            }
                        }
                        if (!found)
                        {
                            validInput = true;
                        }
                    }
                    
                    Console.WriteLine("Choose a password.");
                    selectedUser.password = Console.ReadLine();

                    //Add the new user to the list of users
                    users.Add(selectedUser);
                    Console.WriteLine("User successfully added. You can now log in as this user.");
                }
                else if (input.Equals("LOG IN"))
                {
                    Console.WriteLine("Enter the user name.");
                    input = Console.ReadLine();
                    Console.WriteLine("Enter the passsword.");
                    input2 = Console.ReadLine();

                    found = false;

                    //Look for a user with the inputted user name and password
                    foreach (User user in users)
                    {
                        if (user.name.Equals(input) && user.password.Equals(input2))
                        {
                            found = true;
                            selectedUser = user;
                            Console.WriteLine("You have successfully logged in.");
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine("That user does not exist");
                    }
                    else
                    {
                        stayLoggedIn = true;
                        while (stayLoggedIn)
                        {
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("Enter NEW to create a new account.");
                            Console.WriteLine("Enter DETAILS to see details and take actions on an account.");
                            Console.WriteLine("Enter LIST to see a list of your accounts.");
                            Console.WriteLine("Enter CLOSE to close an account.");
                            Console.WriteLine("Enter LOG OUT to log out.");

                            input = Console.ReadLine().ToUpper();

                            if (input.Equals("NEW"))
                            {
                                selectedAccount = new Account();
                                Console.WriteLine("What is the name of the new account?");
                                
                                //This loop stops a single user from having two accounts with the same name.
                                validInput = false;
                                while (!validInput)
                                {
                                    selectedAccount.name = Console.ReadLine();
                                    found = false;
                                    foreach (Account account in selectedUser.accounts)
                                    {
                                        if (account.name.Equals(selectedAccount.name))
                                        {
                                            found = true;
                                            Console.WriteLine("An account with that name already exists. Choose a different name.");
                                        }
                                    }
                                    if (!found)
                                    {
                                        validInput = true;
                                    }
                                }

                                Console.WriteLine("What kind of account are you opening? Enter CHECKING or BUSINESS or TERM DEPOSIT or LOAN");
                                //This loop makes sure that the user entered a valid account type.
                                validInput = false;
                                while (!validInput)
                                {
                                    input = Console.ReadLine().ToUpper();

                                    if (input.Equals("CHECKING"))
                                    {
                                        selectedAccount.type = "CHECKING";
                                        validInput = true;
                                    }
                                    else if (input.Equals("BUSINESS"))
                                    {
                                        selectedAccount.type = "BUSINESS";
                                        validInput = true;
                                    }
                                    else if (input.Equals("TERM DEPOSIT"))
                                    {
                                        selectedAccount.type = "TERM DEPOSIT";
                                        validInput = true;
                                    }
                                    else if (input.Equals("LOAN"))
                                    {
                                        selectedAccount.type = "LOAN";
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter CHECKING or BUSINESS or TERM DEPOSIT or LOAN");
                                    }
                                }

                                //If the account is a term deposit, then the program needs to know if it's reached maturity yet or not.
                                if (selectedAccount.type.Equals("TERM DEPOSIT"))
                                {
                                    Console.WriteLine("Has the term deposit account reached maturity? Enter YES or NO");
                                    validInput = false;
                                    while (!validInput)
                                    {
                                        input = Console.ReadLine().ToUpper();

                                        if (input.Equals("YES"))
                                        {
                                            selectedAccount.mature = true;
                                            validInput = true;
                                        }
                                        else if (input.Equals("NO"))
                                        {
                                            selectedAccount.mature = false;
                                            //If the term deposit is not mature, then how many years untill it is mature?
                                            Console.WriteLine("How many years are left untill the term deposit reaches maturity? Enter an " +
                                                "integer greater than 0");
                                            while (!validInput)
                                            {
                                                try
                                                {
                                                    selectedAccount.yearsUntillMaturity = Convert.ToInt32(Console.ReadLine());
                                                    if (selectedAccount.yearsUntillMaturity > 0)
                                                    {
                                                        validInput = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid input. Enter an integer greater than 0");
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Invalid input. Please enter an integer. Do not enter " +
                                                        "any non-integer characters.");
                                                    validInput = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Please enter YES or NO");
                                        }
                                    }
                                }

                                Console.WriteLine("How much money is in your account? Enter a number. Do not enter dollar signs or any other" +
                                    " non-number characters.");
                                validInput2 = false;
                                //Input validation loop.
                                while (!validInput2)
                                {
                                    validInput = false;
                                    while (!validInput)
                                    {
                                        try
                                        {
                                            selectedAccount.money = Convert.ToDouble(Console.ReadLine());
                                            validInput = true;
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input. Please enter a number. Do not enter any non-number characters.");
                                            validInput = false;
                                        }
                                    }
                                    if (selectedAccount.money < 0 && (selectedAccount.type == "CHECKING" || selectedAccount.type == "TERM DEPOSIT"))
                                    {
                                        Console.WriteLine("This type of account cannot start with a negative ammount of money. " +
                                            "Enter a positive number.");
                                    }
                                    else if (selectedAccount.money > 0 && selectedAccount.type == "LOAN")
                                    {
                                        Console.WriteLine("Loans cannot have a positive balance. Enter a negative number.");
                                    }
                                    else
                                    {
                                        validInput2 = true;
                                    }
                                }
                                //Round the money to the nearest penny
                                selectedAccount.money = (double)System.Math.Round(selectedAccount.money, 2);
                                //Create the new account and add it to the user's account list.
                                selectedUser.accounts.Add(selectedAccount);
                                Console.WriteLine("New account created.");
                            }
                            else if (input.Equals("DETAILS"))
                            {
                                Console.WriteLine("Enter the name of the account you would like to view");
                                input = Console.ReadLine();
                                found = false;
                                index = 0;
                                //Find the account
                                while (!found && index < selectedUser.accounts.Count)
                                {
                                    if (selectedUser.accounts[index].name.Equals(input))
                                    {
                                        found = true;
                                        selectedAccount = selectedUser.accounts[index];
                                    }

                                    index++;
                                }

                                if (found)
                                {
                                    //Show the details for this account.
                                    Console.WriteLine("Account name: " + selectedAccount.name);
                                    Console.WriteLine("Ammount of money in account: $" + selectedAccount.money);
                                    if (selectedAccount.type.Equals("TERM DEPOSIT"))
                                    {
                                        if (selectedAccount.mature)
                                        {
                                            Console.WriteLine("Account type: MATURE TERM DEPOSIT");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Account type: IMMATURE TERM DEPOSIT");
                                            Console.WriteLine("Years Untill maturity: " + selectedAccount.yearsUntillMaturity);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account type: " + selectedAccount.type);
                                    }

                                    viewThisAccount = true;

                                    //Allow the user to take actions on this account.
                                    while (viewThisAccount){
                                        Console.WriteLine("What would you like to do with this account?");
                                        Console.WriteLine("Enter WITHDRAW to withdraw money.");
                                        Console.WriteLine("Enter DEPOSIT to add money or pay off a loan.");
                                        Console.WriteLine("Enter TRANSFER to transfer money to annother account.");
                                        Console.WriteLine("Enter VIEW TRANSACTIONS to view all transactions involving this account.");
                                        Console.WriteLine("Enter EXIT to go back.");
                                        input = Console.ReadLine().ToUpper();
                                        //Allow the user to withdraw money from this account. Does not work on loans or immature term deposits
                                        if (input.Equals("WITHDRAW"))
                                        {
                                            if (selectedAccount.type.Equals("TERM DEPOSIT") && !selectedAccount.mature)
                                            {
                                                Console.WriteLine("Cannot withdraw from an immature term deposit account.");
                                            }
                                            else if (selectedAccount.type.Equals("LOAN"))
                                            {
                                                Console.WriteLine("Cannot withdraw from a loan.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("How much money do you want to withdraw from your account? Enter a " +
                                                    "number. Do not enter dollar signs or any other non-number characters.");
                                                //Input validation loop
                                                validInput = false;
                                                while (!validInput)
                                                {
                                                    try
                                                    {
                                                        numInput = Convert.ToDouble(Console.ReadLine());
                                                        if (numInput >= 0)
                                                        {
                                                            validInput = true;
                                                            //round the input to the nearest penny
                                                            numInput = (double)System.Math.Round(numInput, 2);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("You cannot withdraw a negative ammount of money." +
                                                                " Enter a positive number.");
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine("Invalid Input. Please enter a number. Do not enter any " +
                                                            "non-number characters.");
                                                        validInput = false;
                                                    }
                                                }
                                                //If the account has enough money, complete the withdraw
                                                if (selectedAccount.money >= numInput && numInput >= 0)
                                                {
                                                    selectedAccount.money -= numInput;
                                                    selectedAccount.money = (double)System.Math.Round(selectedAccount.money, 2);
                                                    Console.WriteLine("Withdraw complete. You have $" + selectedAccount.money + " left in " +
                                                    "your account.");
                                                    selectedAccount.transactions.Add("Withdrew $" + numInput + " from this account.");
                                                }
                                                //If the account dosen't have enough money...
                                                else
                                                {
                                                    //...the withdraw can still be completed if it's a business account.
                                                    if (selectedAccount.type.Equals("BUSINESS"))
                                                    {
                                                        selectedAccount.money -= numInput;
                                                        selectedAccount.money = (double)System.Math.Round(selectedAccount.money, 2);
                                                        Console.WriteLine("Withdraw complete. You have $" + selectedAccount.money + " left in " +
                                                        "your account.");
                                                        Console.WriteLine("You have overdrafted this business account. It now has a " +
                                                            "negative ammount of money.");
                                                        selectedAccount.transactions.Add("Withdrew $" + numInput + " from this account.");
                                                    }
                                                    //Otherwise, tell the user that they don't have enough money.
                                                    else
                                                    {
                                                        Console.WriteLine("You do not have enough money in this account.");
                                                    }
                                                }
                                            }
                                        }
                                        //Allow the user to deposit money into an account. Also used for paying off loans.
                                        else if (input.Equals("DEPOSIT"))
                                        {
                                            //Depositing money into term deposits is not allowed.
                                            if (selectedAccount.type.Equals("TERM DEPOSIT"))
                                            {
                                                Console.WriteLine("Cannot deposit money into a term deposit account.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("How much money do you want to deposit into your account? Enter a " +
                                                "number. Do not enter dollar signs or any other non-number characters.");
                                                //Input validation loop
                                                validInput2 = false;
                                                while (!validInput2)
                                                {
                                                    validInput = false;
                                                    while (!validInput)
                                                    {
                                                        try
                                                        {
                                                            numInput = Convert.ToDouble(Console.ReadLine());
                                                            if (numInput >= 0)
                                                            {
                                                                validInput = true;
                                                                numInput = (double)System.Math.Round(numInput, 2);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("You cannot deposit a negative ammount of money." +
                                                                    " Enter a positive number.");
                                                            }
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            Console.WriteLine("Invalid Input. Please enter a number. Do not enter any " +
                                                                "non-number characters.");
                                                            validInput = false;
                                                        }
                                                    }
                                                    //If the user is paying off a loan, don't let them add more money than they owe.
                                                    if (selectedAccount.type.Equals("LOAN") && (selectedAccount.money + numInput > 0))
                                                    {
                                                        Console.WriteLine("You do not owe that much money on this loan. Enter a smaller " +
                                                            "number.");
                                                    }
                                                    else
                                                    {
                                                        validInput2 = true;
                                                    }
                                                }
                                                selectedAccount.money += numInput;
                                                selectedAccount.money = (double)System.Math.Round(selectedAccount.money, 2);
                                                Console.WriteLine("Deposit complete. You now have $" + selectedAccount.money
                                                    + " in your account");
                                                selectedAccount.transactions.Add("Deposited $" + numInput + " into this account.");
                                            }
                                        }
                                        //Allows the user to transfer money from this account to annother account.
                                        else if (input.Equals("TRANSFER"))
                                        {
                                            //Do not allow the user to transfer money out of an immature term deposit or a loan.
                                            if (selectedAccount.type.Equals("TERM DEPOSIT") && !selectedAccount.mature)
                                            {
                                                Console.WriteLine("Cannot transfer money out of an immature term deposit account.");
                                            }
                                            else if (selectedAccount.type.Equals("LOAN"))
                                            {
                                                Console.WriteLine("Cannot transfer money out of a loan.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter the name of the account you want to transfer money to.");
                                                input = Console.ReadLine();
                                                found = false;
                                                index = 0;
                                                //Find the account the user wants to transfer money to.
                                                while (!found && index < selectedUser.accounts.Count)
                                                {
                                                    if (selectedUser.accounts[index].name.Equals(input))
                                                    {
                                                        found = true;
                                                        targetAccount = selectedUser.accounts[index];
                                                    }
                                                    index++;
                                                }

                                                if (found)
                                                {
                                                    //Do not allow the user to put more money into a term deposit.
                                                    if (targetAccount.type.Equals("TERM DEPOSIT"))
                                                    {
                                                        Console.WriteLine("Cannot transfer money into a term deposit. Transfer failed.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("How much money do you want to transfer to " + targetAccount.name + "? " +
                                                        "Enter a number. Do not enter dollar signs or any other non-number characters.");
                                                        validInput = false;
                                                        //input validation loop
                                                        while (!validInput)
                                                        {
                                                            try
                                                            {
                                                                numInput = Convert.ToDouble(Console.ReadLine());
                                                                if (numInput >= 0)
                                                                {
                                                                    validInput = true;
                                                                    numInput = (double)System.Math.Round(numInput, 2);
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Cannot transfer a negative ammount of money. " +
                                                                        "Enter a positive number.");
                                                                }
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Console.WriteLine("Invalid Input. Please enter a number. Do not enter any " +
                                                                    "non-number characters.");
                                                                validInput = false;
                                                            }
                                                        }
                                                        //Do not allow the user to pay more money on a loan than they owe.
                                                        if (targetAccount.type.Equals("LOAN") && (targetAccount.money + numInput) > 0)
                                                        {
                                                            Console.WriteLine("You do not owe that much money on this loan. Transfer failed.");
                                                        }
                                                        //Make sure there is enough money in this account for the transfer, or that it's a business account
                                                        else if (numInput <= selectedAccount.money || selectedAccount.type.Equals("BUSINESS"))
                                                        {
                                                            selectedAccount.money -= numInput;
                                                            targetAccount.money += numInput;
                                                            selectedAccount.money = (double)System.Math.Round(selectedAccount.money, 2);
                                                            targetAccount.money = (double)System.Math.Round(targetAccount.money, 2);
                                                            Console.WriteLine("Transfer complete. You have $" + selectedAccount.money + " left in " +
                                                                selectedAccount.name + " and $" + targetAccount.money + " in " + targetAccount.name);
                                                            selectedAccount.transactions.Add("Transfered $" + numInput + " from this account to " +
                                                                targetAccount.name);
                                                            targetAccount.transactions.Add("Received $" + numInput + " from " + selectedAccount.name);

                                                            if (selectedAccount.money < 0)
                                                            {
                                                                Console.WriteLine("You have overdrafted this business account. It now has a " +
                                                                "negative ammount of money.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("You do not have enough money for this transaction. Transfer failed.");
                                                        }
                                                    }
                                                }
                                                //If the program can't find the account that the user wants to transfer money to, then the transfer dosen't work.
                                                else
                                                {
                                                    Console.WriteLine("That account does not exist. Transfer failed.");
                                                }
                                            }
                                        }
                                        //Transactions include withdraws, deposits, and transfers to or from annother account.
                                        else if (input.Equals("VIEW TRANSACTIONS"))
                                        {
                                            Console.WriteLine("Here is a list of all transactions that involve this account.");
                                            foreach (string transaction in selectedAccount.transactions)
                                            {
                                                Console.WriteLine(transaction);
                                            }
                                        }
                                        else if (input.Equals("EXIT"))
                                        {
                                            viewThisAccount = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Input.");
                                        }
                                    }
                                }
                                //This else statement exists in case the user tries to get details for an account that does not exist.
                                else
                                {
                                    Console.WriteLine("You do not have an account with that name.");

                                }
                            }
                            //Let the user see their account list.
                            else if (input.Equals("LIST"))
                            {
                                Console.WriteLine("Here is a list of your accounts.");
                                foreach (Account account in selectedUser.accounts)
                                {
                                    Console.Write("Account name: " + account.name + " Ammount of money in account: $" + account.money);

                                    if (account.type.Equals("TERM DEPOSIT"))
                                    {
                                        if (account.mature)
                                        {
                                            Console.WriteLine(" Account type: MATURE TERM DEPOSIT");
                                        }
                                        else
                                        {
                                            Console.WriteLine(" Account type: IMMATURE TERM DEPOSIT Years untill maturity: " + 
                                                account.yearsUntillMaturity);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(" Account type: " + account.type);
                                    }

                                }
                            }
                            //Allow the user to close an account. Does not work if the user owes money on that account.
                            else if (input.Equals("CLOSE"))
                            {
                                Console.WriteLine("Enter the name of the account you want to close.");
                                input = Console.ReadLine();
                                found = false;
                                index = 0;
                                while (!found && index < selectedUser.accounts.Count)
                                {
                                    if (selectedUser.accounts[index].name.Equals(input))
                                    {
                                        found = true;
                                        selectedAccount = selectedUser.accounts[index];
                                    }

                                    index++;
                                }
                                if (found)
                                {
                                    if (selectedAccount.money >= 0)
                                    {
                                        selectedUser.accounts.Remove(selectedAccount);
                                        Console.WriteLine("Account closed.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You cannot close an account that you owe money on.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You do not have an account with that name.");
                                }
                            }
                            else if (input.Equals("LOG OUT"))
                            {
                                stayLoggedIn = false;
                                Console.WriteLine("You have successfully logged out.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                        }
                    }
                }
                //Advancing time will cause interest to accrue on all accounts except mature term deposits
                //Checking accounts have an interest rate of 0.06%
                //Business accounts have an interest rate of 0.05% unless they are overdrafted
                //Term deposits have an interest rate of 0.84% before they reach maturity
                //Term deposits also get one year closer to maturity
                //Loans and overdrafted business accounts have an interest rate of 10%
                else if (input.Equals("ADVANCE TIME"))
                {
                    Console.WriteLine("All accounts have accrued one year of interest. All term deposits are one year closer to maturity.");
                    foreach (User user in users)
                    {
                        foreach (Account account in user.accounts)
                        {
                            if (account.type.Equals("CHECKING"))
                            {
                                account.money = account.money * 1.0006;
                                account.money = (double)System.Math.Round(account.money, 2);
                            }
                            else if (account.type.Equals("BUSINESS"))
                            {
                                if (account.money > 0)
                                {
                                    account.money = account.money * 1.0005;
                                }
                                else
                                {
                                    account.money = account.money * 1.1;
                                }

                                account.money = (double)System.Math.Round(account.money, 2);
                            }
                            else if (account.type.Equals("TERM DEPOSIT") && !account.mature)
                            {
                                account.money = account.money * 1.0084;
                                account.yearsUntillMaturity--;
                                if (account.yearsUntillMaturity == 0)
                                {
                                    account.mature = true;
                                }
                                account.money = (double)System.Math.Round(account.money, 2);
                            }
                            else if (account.type.Equals("LOAN"))
                            {
                                account.money = account.money * 1.1;
                                account.money = (double)System.Math.Round(account.money, 2);
                            }
                        }
                    }
                }
                else if (input.Equals("EXIT"))
                {
                    dontExit = false;
                    Console.WriteLine("You have quit the program.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}