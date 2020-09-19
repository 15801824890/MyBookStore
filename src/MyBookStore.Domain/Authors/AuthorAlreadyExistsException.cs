using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace MyBookStore.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(MyBookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            //WithData(...)method is used to provide additional data to the exception object that will later be used on the localization message or for some other purpose
            WithData("name", name);
        }
    }
}