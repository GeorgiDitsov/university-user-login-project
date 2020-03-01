using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        private String _username;
        private String _password;
        private String _errorMsg;
        private ActionOnError _actionOnError;
        static public string currentUserUsername;
        static public UserRoles currentUserRole;

        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(String username, String password, ActionOnError actionOnError)
        {
            this._username = username;
            this._password = password;
            this._actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            currentUserRole = UserRoles.ANONYMOUS;
            if (isEmptyInput(this._username))
            {
                this._errorMsg = "No username is entered.";
                this._actionOnError(this._errorMsg);
                return false;
            } else if (isEmptyInput(this._password))
            {
                this._errorMsg = "No password is entered.";
                this._actionOnError(this._errorMsg);
                return false;
            } else if (isUnderFiveSymbols(this._username))
            {
                this._errorMsg = "Entered username is under 5 symbols long.";
                this._actionOnError(this._errorMsg);
                return false;
            } else if (isUnderFiveSymbols(this._password))
            {
                this._errorMsg = "Entered password is under 5 symbols long.";
                this._actionOnError(this._errorMsg);
                return false;
            }
            List<User> users = UserData.TestUsers;
            user = UserData.IsUserPassCorrect(this._username, this._password);
            if (user == null)
            {
                this._errorMsg = "No user found.";
            }
            currentUserUsername = user.Username;
            currentUserRole = (UserRoles)user.Role;
            Logger.LogActivity("Successfull login");
            return true;
        }

        private bool isEmptyInput(String input)
        {
            bool result = false;
            if (input.Equals(String.Empty))
            {
                result = true;
            }
            return result;
        }

        private bool isUnderFiveSymbols(String input)
        {
            bool result = false;
            if (input.Length < 5)
            {
                result = true;
            }
            return result;
        }
    }

}
