using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace identity_rest_service.Helpers
{
    public class ErrorHandle<T> : ICollection<T>
    {
        public ErrorHandle()
        {
            this.ErrorCount = 0;
            this.ErrorList = new List<T>();
        }
        public int ErrorCount { get; set; }

        public ICollection<T> ErrorList { get; set; }

        public int Count => this.ErrorCount;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.ErrorList.Add(item);
            this.ErrorCount++;
        }

        public void Clear()
        {
            this.ErrorList.Clear();
            this.ErrorCount = 0;
        }

        public bool Contains(T item)
        {
            return this.ErrorList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in array)
                this.ErrorList.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.ErrorList.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return this.ErrorList.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.ErrorList.GetEnumerator();
        }
    }
    public class IdentityErrors
    {
        public static ErrorHandle<string> HandleErrors(IEnumerable<IdentityError> ierrors)
        {
            var errorHandle = new ErrorHandle<string>();
            foreach (var error in ierrors)
                errorHandle.Add(error.Code);
            return errorHandle;
        }
        public static ErrorHandle<string> HandleErrors(Microsoft.AspNetCore.Identity.SignInResult serrors)
        {
            var errorHandle = new ErrorHandle<string>();

            if (!serrors.Succeeded)
                errorHandle.Add("LoginFailed");

            if (serrors.RequiresTwoFactor)
                errorHandle.Add("RequiresTwoFactor");

            if (serrors.IsLockedOut)
                errorHandle.Add("IsLockedOut");

            if (serrors.IsNotAllowed)
                errorHandle.Add("IsNotAllowed");

            return errorHandle;
        }
    }
}