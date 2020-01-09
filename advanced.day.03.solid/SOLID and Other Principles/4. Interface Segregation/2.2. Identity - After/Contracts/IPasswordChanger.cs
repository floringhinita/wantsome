namespace InterfaceSegregationIdentityBefore.Contracts
{
    using System.Collections.Generic;

    public interface IPasswordChanger
    {
        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }

        void ChangePassword(string oldPass, string newPass);
    }
}
